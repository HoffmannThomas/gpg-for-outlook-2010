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
            this.verifyImage = new Microsoft.Office.Tools.Ribbon.RibbonButton();
            this.decryptImage = new Microsoft.Office.Tools.Ribbon.RibbonButton();
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
            this.gpg2010Group.Items.Add(this.verifyImage);
            this.gpg2010Group.Items.Add(this.decryptImage);
            this.gpg2010Group.Label = "GPG 2010";
            this.gpg2010Group.Name = "gpg2010Group";
            // 
            // verifyImage
            // 
            this.verifyImage.Image = global::OutlookGpg2010.Properties.Resources.neutral;
            this.verifyImage.Label = "No signature";
            this.verifyImage.Name = "verifyImage";
            this.verifyImage.ShowImage = true;
            this.verifyImage.Click += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs>(this.verifyImage_Click);
            // 
            // decryptImage
            // 
            this.decryptImage.Image = global::OutlookGpg2010.Properties.Resources.neutral;
            this.decryptImage.Label = "No encryption";
            this.decryptImage.Name = "decryptImage";
            this.decryptImage.ShowImage = true;
            this.decryptImage.Click += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs>(this.decryptImage_Click);
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
        internal Microsoft.Office.Tools.Ribbon.RibbonButton verifyImage;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton decryptImage;
    }

    partial class ThisRibbonCollection : Microsoft.Office.Tools.Ribbon.RibbonReadOnlyCollection
    {
        internal GpgRibbonRead GpgRibbonRead
        {
            get { return this.GetRibbon<GpgRibbonRead>(); }
        }
    }
}
