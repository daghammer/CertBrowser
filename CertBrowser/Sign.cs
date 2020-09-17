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
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;
//using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.Diagnostics;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace CertBrowser
{
    public partial class Sign : Form
    {
        int antallOk = 0;
        int antallFeil = 0;

        public Sign()
        {
            InitializeComponent();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {

            if (tbPIN.Text.Trim().Length == 0)
            {
                MessageBox.Show("Du må skrive inn PIN kode før du starter!");
                return;
            }

            String logFileName = "SignTestLog.txt";
            File.AppendAllText(logFileName, Environment.NewLine + "New test started: " + DateTime.Now.ToString() + Environment.NewLine + "-----------------------------------" + Environment.NewLine);

            tbSubject.Clear();
            btnSign.Enabled = false;

            X509Certificate2 certSelected = null;
            X509Store x509Store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            x509Store.Open(OpenFlags.ReadOnly);

            X509Certificate2Collection col = x509Store.Certificates.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.NonRepudiation, true) ;
            X509Certificate2Collection sel = X509Certificate2UI.SelectFromCollection(col, "Velg Sertifikat", "Velg det sertifikatet du skal signere med", X509SelectionFlag.SingleSelection);

            if (sel.Count > 0)
            {
                X509Certificate2Enumerator en = sel.GetEnumerator();
                en.MoveNext();
                certSelected = en.Current;
            }
            else
            {
                MessageBox.Show("Sertifikat ikke funnet");
                return;
            }
            
            x509Store.Close();
            //certSelected.PrivateKey

            String password = tbPIN.Text;

            //CspParameters csp =     new CspParameters(1, "Buypass Access - CSP");
            SecureString pin = new SecureString();
            

            foreach (char c in password)
            {
                pin.AppendChar(c);
            }

            Random r = new Random((int)DateTime.Now.TimeOfDay.TotalSeconds);


            for (int iter = 0; iter < numericUpDown1.Value; iter++)
            {

                //tbSubject.Text += Environment.NewLine + DateTime.Now.ToString("HH:mm:ss.fff") +iter.ToString() + ": ";
                int nextIntervalMillisec = (int)(r.NextDouble() * 5000);

                String resultString = Environment.NewLine + DateTime.Now.ToString("HH:mm:ss.fff") + iter.ToString() + ": ";
                  
                try
                {
                    var csp = (RSACryptoServiceProvider)certSelected.PrivateKey;
                    var cspParam = new CspParameters
                    {
                        Flags = CspProviderFlags.UseUserProtectedKey | CspProviderFlags.UseNonExportableKey,
                        KeyContainerName = csp.CspKeyContainerInfo.KeyContainerName,
                        ProviderName = csp.CspKeyContainerInfo.ProviderName,
                        ProviderType = csp.CspKeyContainerInfo.ProviderType,
                        KeyNumber = (int)csp.CspKeyContainerInfo.KeyNumber,
                        KeyPassword = pin
                    };
                    var rsaKey = new RSACryptoServiceProvider(cspParam);

                    XmlDocument xmlDoc = new XmlDocument();

                    // Load an XML file into the XmlDocument object.
                    xmlDoc.PreserveWhitespace = true;
                    xmlDoc.Load("FileToBeSigned.xml");
                    // Sign the XML document. 
                    SignXml(xmlDoc, rsaKey, certSelected);

                    //Console.WriteLine("XML file signed.");

                    // Save the document.
                    xmlDoc.Save("test" + iter.ToString() + ".xml");
                    string container = rsaKey.CspKeyContainerInfo.KeyContainerName;
                    resultString += "Ok";
                    antallOk++;
                }
                catch (CryptographicException excp)
                {
                    resultString += "CryptographicException:" + excp.Message;
                    resultString += excp.StackTrace;
                    if (excp.InnerException != null)
                    {
                        resultString += "  Inner Exception:" + excp.InnerException.Message;
                        resultString += excp.InnerException.StackTrace;
                    }
                    antallFeil++;
                    nextIntervalMillisec = (int)(r.NextDouble() * 500); // More rapid retry i failure
                }
                catch (Exception excp)
                {
                    resultString += "Exception:" + excp.Message;
                    resultString += excp.StackTrace;
                    if (excp.InnerException != null)
                    {
                        resultString += "  Inner Exception:" + excp.InnerException.Message;
                        resultString += excp.InnerException.StackTrace;
                    }
                    antallFeil++;
                    nextIntervalMillisec = (int)(r.NextDouble() * 500); // More rapid retry i failure
                }
                tbFeil.Text = antallFeil.ToString();
                tbOk.Text = antallOk.ToString();

                tbSubject.Text += resultString;
                File.AppendAllText(logFileName, resultString);

                Application.DoEvents();

                System.Threading.Thread.Sleep(nextIntervalMillisec);

            }
            btnSign.Enabled = true;


        }
        // Sign an XML file. 
        // This document cannot be verified unless the verifying 
        // code has the key with which it was signed.
        public static void SignXml(XmlDocument xmlDoc, RSA Key, X509Certificate2 cert )
        {
            // Check arguments.
            if (xmlDoc == null)
                throw new ArgumentException("xmlDoc");
            if (Key == null)
                throw new ArgumentException("Key");

            // Create a SignedXml object.
            SignedXml signedXml = new SignedXml(xmlDoc);

            // Add the key to the SignedXml document.
            signedXml.SigningKey = Key;

            // Create a reference to be signed.
            Reference reference = new Reference();
            reference.Uri = "";

            // Add an enveloped transformation to the reference.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);

            KeyInfo ki = new KeyInfo ();
            
            ki.AddClause(new KeyInfoX509Data((X509Certificate) cert));
            signedXml.KeyInfo = ki;

            // Compute the signature.
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // Append the element to the XML document.
            xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));

        }


        private void Sign_Load(object sender, EventArgs e)
        {
            tbPIN.Text = ""; 
        }
    }
}
