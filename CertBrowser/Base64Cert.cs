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
namespace CertBrowser
{
    public partial class Base64Cert : Form
    {
        public Base64Cert()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var base64EncodedBytes = System.Convert.FromBase64String(tbB64.Text);
                X509Certificate2 c = new X509Certificate2(base64EncodedBytes);
                 
                if (c == null) return;

                X509Certificate2UI.DisplayCertificate(c);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Decode Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbB64.Clear();
        }

        private void Base64Cert_Load(object sender, EventArgs e)
        {

        }
    }
}
