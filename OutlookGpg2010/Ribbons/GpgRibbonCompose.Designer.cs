namespace OutlookGpg2010
{
    partial class GpgRibbonCompose : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public GpgRibbonCompose()
            : base(Globals.Factory.GetRibbonFactory())
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
            this.gpgTab = Factory.CreateRibbonTab();
            this.gpg2010Group = Factory.CreateRibbonGroup();
            this.signMailCheck = Factory.CreateRibbonCheckBox();
            this.encryptMailCheck = Factory.CreateRibbonCheckBox();
            this.settingsButton = Factory.CreateRibbonButton();
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
            this.signMailCheck.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.signMailCheck_Click);
            // 
            // encryptMailCheck
            // 
            this.encryptMailCheck.Label = "Encrypt Mail";
            this.encryptMailCheck.Name = "encryptMailCheck";
            this.encryptMailCheck.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.encryptMailCheck_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Label = "Settings";
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.settingsButton_Click);
            // 
            // GpgRibbonCompose
            // 
            this.Name = "GpgRibbonCompose";
            this.RibbonType = "Microsoft.Outlook.Mail.Compose";
            this.Tabs.Add(this.gpgTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.GpgRibbon_Load);
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

    partial class ThisRibbonCollection
    {
        internal GpgRibbonCompose GpgRibbon
        {
            get { return this.GetRibbon<GpgRibbonCompose>(); }
        }
    }
}
