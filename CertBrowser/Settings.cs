using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace CertBrowser
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void tbFolder_DoubleClick(object sender, EventArgs e)
        {

            DialogResult folderBrowserResult =  folderBrowserDialog1.ShowDialog();
            if (folderBrowserResult == System.Windows.Forms.DialogResult.OK)
            {
                tbFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            String datakatalog = ConfigurationManager.AppSettings["datakatalog"];
            tbFolder.Text = datakatalog;
            String customDatakatalog = ConfigurationManager.AppSettings["customDatakatalog"];
            Boolean custom = false;
            Boolean.TryParse(customDatakatalog, out custom);
            if (custom) rbCustom.Select();
            else rbDefault.Select();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save the current settings:

            Configuration configuration =
            ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings["customDatakatalog"].Value = rbCustom.Checked? "true":"false";
            configuration.AppSettings.Settings["datakatalog"].Value = tbFolder.Text;

            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");

            DialogResult = System.Windows.Forms.DialogResult.OK;

 
            Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
