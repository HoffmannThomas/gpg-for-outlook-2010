namespace OutlookGpg2010
{
    partial class GpgRibbonRead : Microsoft.Office.Tools.Ribbon.OfficeRibbon
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public GpgRibbonRead()
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.gpgTab = new Microsoft.Office.Tools.Ribbon.RibbonTab();
            this.gpg2010Group = new Microsoft.Office.Tools.Ribbon.RibbonGroup();
            this.decryptButton = new Microsoft.Office.Tools.Ribbon.RibbonButton();
            this.verifyButton = new Microsoft.Office.Tools.Ribbon.RibbonButton();
            this.gpgTab.SuspendLayout();
            this.gpg2010Group.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpgTab
            // 
            this.gpgTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.gpgTab.Groups.Add(this.gpg2010Group);
            this.gpgTab.Label = "GPG 2010";
            this.gpgTab.Name = "gpgTab";
            // 
            // gpg2010Group
            // 
            this.gpg2010Group.Items.Add(this.verifyButton);
            this.gpg2010Group.Items.Add(this.decryptButton);
            this.gpg2010Group.Label = "GPG 2010";
            this.gpg2010Group.Name = "gpg2010Group";
            // 
            // decryptButton
            // 
            this.decryptButton.Image = global::OutlookGpg2010.Properties.Resources.valid;
            this.decryptButton.Label = "Decrypt";
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.ShowImage = true;
            this.decryptButton.Click += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs>(this.decryptImage_Click);
            // 
            // verifyButton
            // 
            this.verifyButton.Image = global::OutlookGpg2010.Properties.Resources.valid;
            this.verifyButton.Label = "Verify";
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.ShowImage = true;
            this.verifyButton.Click += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs>(this.verifyImage_Click);
            // 
            // GpgRibbonRead
            // 
            this.Name = "GpgRibbonRead";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.gpgTab);
            this.Load += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonUIEventArgs>(this.GpgRibbonRead_Load);
            this.gpgTab.ResumeLayout(false);
            this.gpgTab.PerformLayout();
            this.gpg2010Group.ResumeLayout(false);
            this.gpg2010Group.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab gpgTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup gpg2010Group;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton decryptButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton verifyButton;
    }

    partial class ThisRibbonCollection : Microsoft.Office.Tools.Ribbon.RibbonReadOnlyCollection
    {
        internal GpgRibbonRead GpgRibbonRead
        {
            get { return this.GetRibbon<GpgRibbonRead>(); }
        }
    }
}
