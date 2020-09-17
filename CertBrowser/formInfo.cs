using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertBrowser
{
    public partial class formInfo : Form
    {
        string _info;
        public formInfo( string infotext )
        {
            InitializeComponent();
            _info = infotext;
            
        }

        private void formInfo_Load(object sender, EventArgs e)
        {
            label1.Text = _info;
            label1.Refresh();
           
        }
    }
}
