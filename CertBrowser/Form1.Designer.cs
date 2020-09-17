namespace CertBrowser
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnLdap = new System.Windows.Forms.Button();
            this.tbCertName = new System.Windows.Forms.TextBox();
            this.groupBoxLDAP = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbOrgSerial = new System.Windows.Forms.TextBox();
            this.tbLdapSearch = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSearchBase = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCN = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbSerial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLDAPserver = new System.Windows.Forms.ComboBox();
            this.listBoxCert = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.certificateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.base64CertificateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.certStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lDAPSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxLDAP.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLdap
            // 
            this.btnLdap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLdap.Location = new System.Drawing.Point(703, 100);
            this.btnLdap.Name = "btnLdap";
            this.btnLdap.Size = new System.Drawing.Size(75, 23);
            this.btnLdap.TabIndex = 0;
            this.btnLdap.Text = "Søk";
            this.btnLdap.UseVisualStyleBackColor = true;
            this.btnLdap.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbCertName
            // 
            this.tbCertName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCertName.Location = new System.Drawing.Point(18, 578);
            this.tbCertName.Multiline = true;
            this.tbCertName.Name = "tbCertName";
            this.tbCertName.ReadOnly = true;
            this.tbCertName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbCertName.Size = new System.Drawing.Size(792, 133);
            this.tbCertName.TabIndex = 7;
            // 
            // groupBoxLDAP
            // 
            this.groupBoxLDAP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLDAP.Controls.Add(this.label9);
            this.groupBoxLDAP.Controls.Add(this.tbOrgSerial);
            this.groupBoxLDAP.Controls.Add(this.tbLdapSearch);
            this.groupBoxLDAP.Controls.Add(this.label7);
            this.groupBoxLDAP.Controls.Add(this.label6);
            this.groupBoxLDAP.Controls.Add(this.label5);
            this.groupBoxLDAP.Controls.Add(this.cbSearchBase);
            this.groupBoxLDAP.Controls.Add(this.label4);
            this.groupBoxLDAP.Controls.Add(this.label3);
            this.groupBoxLDAP.Controls.Add(this.tbCN);
            this.groupBoxLDAP.Controls.Add(this.tbName);
            this.groupBoxLDAP.Controls.Add(this.tbSerial);
            this.groupBoxLDAP.Controls.Add(this.label2);
            this.groupBoxLDAP.Controls.Add(this.cbLDAPserver);
            this.groupBoxLDAP.Controls.Add(this.btnLdap);
            this.groupBoxLDAP.Location = new System.Drawing.Point(18, 137);
            this.groupBoxLDAP.Name = "groupBoxLDAP";
            this.groupBoxLDAP.Size = new System.Drawing.Size(792, 177);
            this.groupBoxLDAP.TabIndex = 2;
            this.groupBoxLDAP.TabStop = false;
            this.groupBoxLDAP.Text = "LDAP søk";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "SerialNo:";
            // 
            // tbOrgSerial
            // 
            this.tbOrgSerial.Location = new System.Drawing.Point(121, 67);
            this.tbOrgSerial.Name = "tbOrgSerial";
            this.tbOrgSerial.Size = new System.Drawing.Size(221, 20);
            this.tbOrgSerial.TabIndex = 12;
            // 
            // tbLdapSearch
            // 
            this.tbLdapSearch.Location = new System.Drawing.Point(10, 151);
            this.tbLdapSearch.Name = "tbLdapSearch";
            this.tbLdapSearch.ReadOnly = true;
            this.tbLdapSearch.Size = new System.Drawing.Size(768, 20);
            this.tbLdapSearch.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(359, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(230, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "tegnet: * kan brukes som wildcard i søkefeltene";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Common Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(375, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Search base:";
            // 
            // cbSearchBase
            // 
            this.cbSearchBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearchBase.FormattingEnabled = true;
            this.cbSearchBase.Location = new System.Drawing.Point(461, 55);
            this.cbSearchBase.Name = "cbSearchBase";
            this.cbSearchBase.Size = new System.Drawing.Size(317, 21);
            this.cbSearchBase.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Org name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Certificate Serial #:";
            // 
            // tbCN
            // 
            this.tbCN.Location = new System.Drawing.Point(121, 119);
            this.tbCN.Name = "tbCN";
            this.tbCN.Size = new System.Drawing.Size(221, 20);
            this.tbCN.TabIndex = 4;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(121, 93);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(221, 20);
            this.tbName.TabIndex = 3;
            // 
            // tbSerial
            // 
            this.tbSerial.Location = new System.Drawing.Point(121, 25);
            this.tbSerial.Name = "tbSerial";
            this.tbSerial.Size = new System.Drawing.Size(221, 20);
            this.tbSerial.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "LDAP server:";
            // 
            // cbLDAPserver
            // 
            this.cbLDAPserver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLDAPserver.FormattingEnabled = true;
            this.cbLDAPserver.Location = new System.Drawing.Point(461, 20);
            this.cbLDAPserver.Name = "cbLDAPserver";
            this.cbLDAPserver.Size = new System.Drawing.Size(317, 21);
            this.cbLDAPserver.TabIndex = 1;
            this.cbLDAPserver.SelectedIndexChanged += new System.EventHandler(this.cbLDAPserver_SelectedIndexChanged);
            // 
            // listBoxCert
            // 
            this.listBoxCert.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxCert.FormattingEnabled = true;
            this.listBoxCert.Location = new System.Drawing.Point(19, 358);
            this.listBoxCert.Name = "listBoxCert";
            this.listBoxCert.Size = new System.Drawing.Size(792, 212);
            this.listBoxCert.TabIndex = 9;
            this.listBoxCert.SelectedIndexChanged += new System.EventHandler(this.listBoxCert_SelectedIndexChanged);
            this.listBoxCert.DoubleClick += new System.EventHandler(this.listBoxCert_DoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.certificateToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(846, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // certificateToolStripMenuItem
            // 
            this.certificateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lDAPSearchToolStripMenuItem,
            this.base64CertificateToolStripMenuItem,
            this.signToolStripMenuItem,
            this.certStoreToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.certificateToolStripMenuItem.Name = "certificateToolStripMenuItem";
            this.certificateToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.certificateToolStripMenuItem.Text = "Certificate";
            // 
            // base64CertificateToolStripMenuItem
            // 
            this.base64CertificateToolStripMenuItem.Name = "base64CertificateToolStripMenuItem";
            this.base64CertificateToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.base64CertificateToolStripMenuItem.Text = "Base64 certificate";
            this.base64CertificateToolStripMenuItem.Click += new System.EventHandler(this.base64CertificateToolStripMenuItem_Click);
            // 
            // signToolStripMenuItem
            // 
            this.signToolStripMenuItem.Name = "signToolStripMenuItem";
            this.signToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.signToolStripMenuItem.Text = "Sign";
            this.signToolStripMenuItem.Click += new System.EventHandler(this.signToolStripMenuItem_Click);
            // 
            // certStoreToolStripMenuItem
            // 
            this.certStoreToolStripMenuItem.Name = "certStoreToolStripMenuItem";
            this.certStoreToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.certStoreToolStripMenuItem.Text = "Cert Store";
            this.certStoreToolStripMenuItem.Click += new System.EventHandler(this.certStoreToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 333);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(204, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Dobbeltklikk på sertifikatet for å åpne det:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft NeoGothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(478, 63);
            this.label1.TabIndex = 12;
            this.label1.Text = "Her kan du søke etter sertifikater i både test og produksjon.\r\nDet er begrensning" +
    " på antall sertifikater som returneres, \r\nså det kan hende du må \"spisse\" søket " +
    "om du ikke finner det i listen.\r\n";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(723, 730);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 23);
            this.button2.TabIndex = 26;
            this.button2.Text = "åpne katalog";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 761);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Versjon:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 736);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Katalog for datafiler:";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(127, 758);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(583, 20);
            this.textBox4.TabIndex = 23;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(127, 733);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(583, 20);
            this.textBox3.TabIndex = 22;
            // 
            // lDAPSearchToolStripMenuItem
            // 
            this.lDAPSearchToolStripMenuItem.Name = "lDAPSearchToolStripMenuItem";
            this.lDAPSearchToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.lDAPSearchToolStripMenuItem.Text = "LDAP search";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::CertBrowser.Properties.Resources.e_helse_bare_logo_RGB_hvit;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(531, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(287, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(846, 783);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listBoxCert);
            this.Controls.Add(this.groupBoxLDAP);
            this.Controls.Add(this.tbCertName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Cert browser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxLDAP.ResumeLayout(false);
            this.groupBoxLDAP.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLdap;
        private System.Windows.Forms.TextBox tbCertName;
        private System.Windows.Forms.GroupBox groupBoxLDAP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbSearchBase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCN;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbSerial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLDAPserver;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxCert;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbLdapSearch;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem certificateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem base64CertificateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem certStoreToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbOrgSerial;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ToolStripMenuItem lDAPSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

