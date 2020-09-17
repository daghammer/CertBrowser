using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.IdentityModel;

namespace CertBrowser
{
    public partial class FormCertStore : Form
    {
        public FormCertStore()
        {
            InitializeComponent();
        }

        private void FormCertStore_Load(object sender, EventArgs e)
        {
            certselect();
        }

        void certselect()
        {
            X509Certificate2 certSelected = null;
            X509Store x509Store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            System.IdentityModel.Tokens.X509SecurityToken securityToken;
            
            x509Store.Open(OpenFlags.ReadOnly);
            
            X509Certificate2Collection col = x509Store.Certificates;
            X509Certificate2Collection sel = X509Certificate2UI.SelectFromCollection(col, "Velg sertifikat", "Velg sertifikat som du skal signere med:", X509SelectionFlag.SingleSelection);


            RSACryptoServiceProvider csp = null;

            String stringToBeSigned = "Dags tekst som skal signeres!";

            if (sel.Count > 0)
            {
                X509Certificate2Enumerator en = sel.GetEnumerator();
                en.MoveNext();
                certSelected = en.Current;
                //trenger vi denne?
                securityToken = new System.IdentityModel.Tokens.X509SecurityToken(certSelected);

                // se her for XML: https://msdn.microsoft.com/en-us/library/ms229745(v=vs.110).aspx
                // Key info: https://msdn.microsoft.com/en-us/library/system.security.cryptography.xml.keyinfox509data(v=vs.90).aspx

                SignedXml signedXml = new SignedXml();
               
                KeyInfo keyInfo = new KeyInfo();
                keyInfo.AddClause(new KeyInfoX509Data(certSelected));



                if (certSelected.HasPrivateKey == true)
                {
                    // signer med privat nøkkel
                    textBox1.Text += "Dette sertifikatet har privat nøkkel";
                    csp = (RSACryptoServiceProvider)certSelected.PrivateKey;

                    SignXmlFile("orig.xml", "signed.xml", csp, certSelected);


                        //        SHA1Managed sha1 = new SHA1Managed();
                        //        UnicodeEncoding encoding = new UnicodeEncoding();
                        //byte[] data = encoding.GetBytes(stringToBeSigned);
                        //byte[] hash = sha1.ComputeHash(data);
                        // Sign the hash
                        // byte[] signature =  csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));

                }
                else
                {
                    // Signer med offentlig nøkkel
                }
            }
            x509Store.Close();

        }

        // Sign an XML file and save the signature in a new file. 
        public static void SignXmlFile(string FileName, string SignedFileName, RSA Key, X509Certificate2 Certificate)
        {
            // Create a new XML document.
            XmlDocument doc = new XmlDocument();

            // Format the document to ignore white spaces.
            doc.PreserveWhitespace = false;

            // Load the passed XML file using it's name.
            doc.Load(new XmlTextReader(FileName));

            // Create a SignedXml object.
            SignedXml signedXml = new SignedXml(doc);

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

            // Create a new KeyInfo object.
            KeyInfo keyInfo = new KeyInfo();

            // Load the X509 certificate.
            //X509Certificate MSCert = X509Certificate.CreateFromCertFile(Certificate);

            // Load the certificate into a KeyInfoX509Data object 
            // and add it to the KeyInfo object.
            keyInfo.AddClause(new KeyInfoX509Data(Certificate));

            // Add the KeyInfo object to the SignedXml object.
            signedXml.KeyInfo = keyInfo;

            // Compute the signature.
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save 
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // Append the element to the XML document.
            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));


            if (doc.FirstChild is XmlDeclaration)
            {
                doc.RemoveChild(doc.FirstChild);
            }

            // Save the signed XML document to a file specified 
            // using the passed string.
            XmlTextWriter xmltw = new XmlTextWriter(SignedFileName, new UTF8Encoding(false));
            doc.WriteTo(xmltw);
            xmltw.Close();
        }

    }
}
