namespace OutlookGpg2010
{
    partial class GpgRibbonCompose : Microsoft.Office.Tools.Ribbon.OfficeRibbon
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public GpgRibbonCompose()
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
            this.signMailCheck = new Microsoft.Office.Tools.Ribbon.RibbonCheckBox();
            this.encryptMailCheck = new Microsoft.Office.Tools.Ribbon.RibbonCheckBox();
            this.settingsButton = new Microsoft.Office.Tools.Ribbon.RibbonButton();
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
            this.gpg2010Group.Items.Add(this.signMailCheck);
            this.gpg2010Group.Items.Add(this.encryptMailCheck);
            this.gpg2010Group.Items.Add(this.settingsButton);
            this.gpg2010Group.Label = "GPG 2010";
            this.gpg2010Group.Name = "gpg2010Group";
            // 
            // signMailCheck
            // 
            this.signMailCheck.Label = "Sign Mail";
            this.signMailCheck.Name = "signMailCheck";
            this.signMailCheck.Click += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs>(this.signMailCheck_Click);
            // 
            // encryptMailCheck
            // 
            this.encryptMailCheck.Label = "Encrypt Mail";
            this.encryptMailCheck.Name = "encryptMailCheck";
            this.encryptMailCheck.Click += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs>(this.encryptMailCheck_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Label = "Settings";
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Click += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs>(this.settingsButton_Click);
            // 
            // GpgRibbonCompose
            // 
            this.Name = "GpgRibbonCompose";
            this.RibbonType = "Microsoft.Outlook.Mail.Compose";
            this.Tabs.Add(this.gpgTab);
            this.Load += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonUIEventArgs>(this.GpgRibbon_Load);
            this.gpgTab.ResumeLayout(false);
            this.gpgTab.PerformLayout();
            this.gpg2010Group.ResumeLayout(false);
            this.gpg2010Group.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab gpgTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup gpg2010Group;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox signMailCheck;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox encryptMailCheck;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton settingsButton;
    }

    partial class ThisRibbonCollection : Microsoft.Office.Tools.Ribbon.RibbonReadOnlyCollection
    {
        internal GpgRibbonCompose GpgRibbon
        {
            get { return this.GetRibbon<GpgRibbonCompose>(); }
        }
    }
}
