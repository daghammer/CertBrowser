using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.Security.Cryptography.X509Certificates;            
using System.IO;
//using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.Diagnostics;
using System.Deployment.Application;
 
using System.Configuration;
 

namespace CertBrowser
{
    public partial class Form1 : Form
    {

        String startupDir = "";
        //String currentDir = "";
        String dataDir;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initalizeFields();
            this.AcceptButton = btnLdap;

            setupThings();
        }

        void initalizeFields()
        {
            String ldapServersSetting = "ldap.test4.buypass.no;ldap.buypass.no;ldap.commfides.com;ldap.test.commfides.com";
            String[] ldapServers = ldapServersSetting.Split(new char[] { ';' });
            cbLDAPserver.Items.Clear();
            cbLDAPserver.Items.AddRange(ldapServers);
            cbLDAPserver.SelectedIndex = 0;

        }
        private void setupThings()
        {

            String version;
            // Are we in a deployed environment? Or a combined catalog?
            //textBox1.Text = Assembly.GetExecutingAssembly().Location;

            //currentDir = textBox2.Text = Environment.CurrentDirectory;

            // Look for datakatalog in app.setting:
            string datakatalogFromAppConfig = String.Empty;


            String customDatakatalog = ConfigurationManager.AppSettings["customDatakatalog"];
            Boolean custom = false;
            Boolean.TryParse(customDatakatalog, out custom);
            if (custom) datakatalogFromAppConfig = ConfigurationManager.AppSettings["datakatalog"];


            startupDir = System.Windows.Forms.Application.StartupPath;

            // Sett dataDir til å være hvor programmet startes. Fungerer i DEBUG og stand-alone, men ikke DEPLOY
            dataDir = startupDir;

            version = System.Windows.Forms.Application.ProductVersion;
            if (ApplicationDeployment.IsNetworkDeployed != false)
            {
                // Sett datadir til den laaaange pathen under MS-deploy
                dataDir = ApplicationDeployment.CurrentDeployment.DataDirectory;
                Version v = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                version = v.ToString(4);
            }


            if (datakatalogFromAppConfig != null && datakatalogFromAppConfig != String.Empty)
            {
                if (Directory.Exists(datakatalogFromAppConfig) == false)
                {
                    try {
                        Directory.CreateDirectory((datakatalogFromAppConfig));
                    }
                    catch  ( Exception excp )
                    {
                        MessageBox.Show(excp.Message, "Kunne ikke lage datastien:" + datakatalogFromAppConfig);
                    }
                }
                if (Directory.Exists(datakatalogFromAppConfig)) dataDir = datakatalogFromAppConfig;
            }

            textBox3.Text = dataDir;
            textBox4.Text = version;

            if (!Directory.Exists(dataDir) || !Directory.Exists(dataDir + "\\xml") || !Directory.Exists(dataDir + "\\pasient") || !Directory.Exists(dataDir + "\\login"))
            {
                Directory.CreateDirectory(dataDir + "\\log");
                 
                //MessageBox.Show("Arbeidsktatlog opprettet:" + Environment.NewLine + dataDir, "Ny arbeidskatalog");

            }
            else
            {

            }
            Directory.SetCurrentDirectory(dataDir);

            if (!Directory.Exists("log")) Directory.CreateDirectory("log");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String hexcheck = checkSerialNumber();
            Form info = new formInfo("det kan ta litt til å hente sertifikatene...." + hexcheck);
            int count;
            tbCertName.Clear();

            info.Show();
            Application.DoEvents();
             
            count = searchDir() ;
            info.Close();
            info.Dispose();
            if (count == 0) MessageBox.Show("Ingen sertifikater funnet");
            
            
            
        }


        // Low level LDAP - SE DENNE LINKEN: https://msdn.microsoft.com/en-US/library/ms257181(v=vs.80).aspx


        //void searchDir()
        //{
        //// ldap://ldap.test4.buypass.no/dc=Buypass,dc=no,CN=Buypass%20Class%203%20Test4%20CA%203?usercertificate;binary?sub?(sn=100100126)
        //    DirectorySearcher dsearch = new DirectorySearcher("LDAP://ldap.test4.buypass.no/dc=Buypass,dc=no,CN=Buypass%20Class%203%20Test4%20CA%203?usercertificate;binary?sub?(sn=100100126)");
        //    //dsearch.Filter = "usercertificate;binary?sub?(sn=100100126)"; //Search how you want.  Google "LDAP Filter" for more.
        //    SearchResultCollection rc = dsearch.FindAll();
        //    X509Certificate stt = new X509Certificate();

        //    foreach (SearchResult r in rc)
        //    {

        //        if (r.Properties.Contains("userCertificate"))
        //        {
        //            Byte[] b = (Byte[])r.Properties["userCertificate"][0];  //This is hard coded to the first element.  Some users may have multiples.  Use ADSI Edit to find out more.
        //            X509Certificate cert1 = new X509Certificate(b);
        //        }
        //    }
        //}


        int searchDir()
        {
            
            String filter = "";
            SearchRequest sReq;
            SearchResponse sResp = null;
            string[] attributeList = new string[] { "usercertificate;binary" };
            int certCount = 0;

            listBoxCert.Items.Clear();


            LdapConnection connection = new LdapConnection(cbLDAPserver.Text);

            // To use version 3, a bind is neccessary:
            connection.SessionOptions.ProtocolVersion = 3;
            //connection.Timeout = new TimeSpan(0, 0, 10);
            connection.SessionOptions.SecureSocketLayer = false;
            connection.AuthType = AuthType.Anonymous;
            connection.Bind();

            int fieldCount = 0;

            String filterSerial = "";
            if (tbSerial.Text.Trim().Length > 0)
            {
//               filterSerial = "(serialNumber=" + tbSerial.Text.Trim() + ")";
                filterSerial = "(certificateSerialNumber=" + tbSerial.Text.Trim() + ")";
                fieldCount++;
            }

            String filerOrgSerial = "";
            if (tbOrgSerial.Text.Trim().Length > 0)
            {
                filerOrgSerial = "(serialNumber=" + this.tbOrgSerial.Text.Trim() + ")";
                fieldCount++;
            }


            String filterOrgno = "";
            if (tbName.Text.Trim().Length > 0)
            {
                filterOrgno = "(o=" + this.tbName.Text.Trim() + ")";
                fieldCount++;
            }
            String filterCommonName = "";
            if (tbCN.Text.Trim().Length > 0)
            {
                filterCommonName = "(CN=" + tbCN.Text.Trim() + ")";
                fieldCount++;
            }
            if (fieldCount == 0) filter = "CN=*";
            if (fieldCount >= 1) filter = filterCommonName + filterOrgno + filterSerial + filerOrgSerial; // Combine the filters
            if (fieldCount >= 2) filter = "(&" + filter + ")"; // Add wrapper if more than one


            tbLdapSearch.Text = "ldap://" + cbLDAPserver.Text + "/" + cbSearchBase.Text + "?" + attributeList[0] + "?sub?" + filter;
            sReq = new SearchRequest(cbSearchBase.Text, filter, System.DirectoryServices.Protocols.SearchScope.Subtree, attributeList);
            
            try
            {
                sResp = (SearchResponse)connection.SendRequest(sReq);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Søket gikk ikke så bra!");
                return 0;
            }

            ResultCode rs = sResp.ResultCode;
            
            List<X509Certificate2> certList = new List<X509Certificate2>();
            int count = sResp.Entries.Count;

            if (count > 0)
            {

            
                foreach (SearchResultEntry result in sResp.Entries)
                {
                    String dn = result.DistinguishedName;
                    foreach (DirectoryAttribute a in result.Attributes.Values)
                    {
                        String attribInfo = a.Name;
                        Byte[] certBytes = null;


                        for (int i = 0; i < a.Count; i++)
                        {
                            if (a[i] is string)
                            {
                            
                            }
                            else if (a[i] is byte[])
                            {
                                if (a.Name.Equals("usercertificate;binary", StringComparison.OrdinalIgnoreCase))
                                {
                                }
                                certBytes = (Byte[])a[i];
                            }
                            else
                            {

                            }
                        }

                        if (certBytes != null)
                        {

                            X509Certificate2 certificate = new X509Certificate2(certBytes);
                            string name = certificate.Subject;
                            string serial = certificate.GetSerialNumberString();
                            certList.Add(certificate);

                            String certFile = dataDir + "\\log" + "\\cert_"+ serial +".cer";
                            File.WriteAllText(certFile, ExportToPEM(certificate));

                       
                        }

                    }
                
                }
                
                listBoxCert.DisplayMember = "Subject";
                foreach (X509Certificate c in certList)
                {
                    String test = c.ToString(false);
                    
                    listBoxCert.Items.Add(c );
                    certCount++;
                }

            }
             
            return certCount;
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
                
        //        String certFile = Environment.CurrentDirectory +"\\certTemp.cer";
        //        var base64EncodedBytes = System.Convert.FromBase64String( tbB64.Text);
        //        X509Certificate cert1 = new X509Certificate(base64EncodedBytes);
        //        string name = cert1.Subject;
        //        string cert2 = ExportToPEM(cert1);
        //        File.WriteAllText(certFile, cert2);

        //        showCert(certFile);

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Decode Error");
        //    }
        //}
        /// <summary>
        /// Export a certificate to a PEM format string
        /// </summary>
        /// <param name="cert">The certificate to export</param>
        /// <returns>A PEM encoded string</returns>
        public static string ExportToPEM(X509Certificate cert)
        {
            StringBuilder builder = new StringBuilder();
            String b64 = Convert.ToBase64String(cert.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks);

            builder.AppendLine("-----BEGIN CERTIFICATE-----");
            builder.AppendLine(b64);
            builder.AppendLine("-----END CERTIFICATE-----");

            return builder.ToString();
        }

        public void showCert(string certPath) {

            Process.Start(certPath);

            //Process explorer = new Process();
            //explorer.StartInfo.FileName =
            //    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "explorer.exe");
            //if (explorer.Start() == false)
            //{
            //    MessageBox.Show("Explorer failed to start.");
            //}
            //else
            //{

            //    //(Snip) some other code that is not relevant.

            //    explorer.WaitForExit();
            //}
       
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    tbB64.Clear();
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{

        //    X509Certificate2 certSelected = null;
        //    X509Store x509Store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
        //    x509Store.Open(OpenFlags.ReadOnly);

        //    X509Certificate2Collection col = x509Store.Certificates;
        //    X509Certificate2Collection sel = X509Certificate2UI.SelectFromCollection(col, "Velg Sertifikat", "Velg det sertifikatet du skal signere med", X509SelectionFlag.SingleSelection);

        //    if (sel.Count > 0)
        //    {
        //        X509Certificate2Enumerator en = sel.GetEnumerator();
        //        en.MoveNext();
        //        certSelected = en.Current;
        //    }

        //    x509Store.Close();

        //   // return certSelected;

             

        //}

 

        private void cbLDAPserver_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            String[] baseChoices = null;
            if (cb.Text.Contains("test4.buypass"))
            {
                baseChoices = new String[] { "dc=Buypass,dc=NO,CN=Buypass Class 3 Test4 CA 3"  };                
            } 
            else if (cb.Text.Contains("buypass"))
            {
                baseChoices = new String[] { "dc=Buypass,dc=NO,CN=Buypass Class 3 CA 3", "dc=Buypass,dc=NO,CN=Buypass Class 3 CA 1" };                
            }
            else if (cb.Text.Contains("commfides"))
            {
                baseChoices = new String[] { "ou=Enterprise,dc=commfides,dc=com" };                

            }


            cbSearchBase.Items.Clear();
            if (baseChoices != null)
            {
                cbSearchBase.Items.AddRange(baseChoices);
                cbSearchBase.SelectedIndex = 0;
            }

        }

        private void listBoxCert_SelectedIndexChanged(object sender, EventArgs e)
        {
            X509Certificate2 c = (X509Certificate2) ((ListBox)sender).SelectedItem;

            if (c == null) return;

            X509KeyUsageFlags keyFlags = X509KeyUsageFlags.None;
            String crldist = String.Empty;

            String certSerialNumber = c.GetSerialNumberString();
            tbCertName.Text = certSerialNumber + " / " + HexToDecimal(certSerialNumber) ;
            tbCertName.Text += Environment.NewLine + c.GetExpirationDateString();
            foreach (X509Extension ext in c.Extensions)
            {
                String oid = ext.Oid.Value;
                // 2.5.29.15 Bruk av nøkler
                // 2.5.29.31 CRL-distib
                if (ext.Oid.Value == "2.5.29.15")
                {
                    X509KeyUsageExtension keyext = (X509KeyUsageExtension)ext;
                    keyFlags = keyext.KeyUsages;

                }
                else if (ext.Oid.Value == "2.5.29.31")
                {
                    crldist = ext.Format(true);
                }

            }

            tbCertName.Text += Environment.NewLine + "Key usage:" + keyFlags.ToString();

            tbCertName.Text += Environment.NewLine + crldist;

            //Form info = new formInfo("Bygger sertifikatkjede....");
            //info.Show();

            X509Chain chain = new X509Chain();
            chain.Build(c);
            //info.Close();
            //info.Dispose();
            int i = chain.ChainElements.Count;
            foreach (X509ChainElement che in chain.ChainElements) {
                tbCertName.Text += Environment.NewLine + "Chain:" + che.Certificate.Subject;
                //X509Certificate2UI.DisplayCertificate(che.Certificate);
            }

         
        }

        private void listBoxCert_DoubleClick(object sender, EventArgs e)
        {
            X509Certificate2 c = (X509Certificate2)((ListBox)sender).SelectedItem;

            if (c == null) return;

            X509Certificate2UI.DisplayCertificate(c);

        }

        private void base64CertificateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Base64Cert b64 = new Base64Cert();
            b64.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void certStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCertStore fCertStore = new FormCertStore();
            fCertStore.Show();
        }

        private void signToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sign sign = new Sign();
            sign.Show();
        }
        String checkSerialNumber()
        {
            String resultText = "";
            String number = tbSerial.Text.Trim();
            number = number.Replace(" ", "").Replace(":", "");
            Boolean tryHex = false;

            
            foreach (char c in number) {
                if ((c > '9' || c < '0') && c != '*' )
                {
                    tryHex = true;
                    break;
                }
            }
            if (tryHex)
            {
                tbSerial.Text= HexToDecimal(number);
                resultText = Environment.NewLine + "Serienummeret ble konvertert (hex->dec) før søk!";
            }
            return resultText;
        }
        static string HexToDecimal(string hex)
        {
            List<int> dec = new List<int> { 0 };   // decimal result

            foreach (char c in hex)
            {
                int carry = Convert.ToInt32(c.ToString(), 16);
                // initially holds decimal value of current hex digit;
                // subsequently holds carry-over for multiplication

                for (int i = 0; i < dec.Count; ++i)
                {
                    int val = dec[i] * 16 + carry;
                    dec[i] = val % 10;
                    carry = val / 10;
                }

                while (carry > 0)
                {
                    dec.Add(carry % 10);
                    carry /= 10;
                }
            }

            var chars = dec.Select(d => (char)('0' + d));
            var cArr = chars.Reverse().ToArray();
            return new string(cArr);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                Process.Start("explorer.exe", dataDir);
            }

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                setupThings();
            }
            s.Dispose();

        }
    }
}
