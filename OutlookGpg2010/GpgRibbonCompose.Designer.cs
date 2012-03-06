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
            this.tab1 = new Microsoft.Office.Tools.Ribbon.RibbonTab();
            this.group1 = new Microsoft.Office.Tools.Ribbon.RibbonGroup();
            this.signMailCheck = new Microsoft.Office.Tools.Ribbon.RibbonCheckBox();
            this.encryptMailCheck = new Microsoft.Office.Tools.Ribbon.RibbonCheckBox();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.signMailCheck);
            this.group1.Items.Add(this.encryptMailCheck);
            this.group1.Label = "group1";
            this.group1.Name = "group1";
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
            // GpgRibbonCompose
            // 
            this.Name = "GpgRibbonCompose";
            this.RibbonType = "Microsoft.Outlook.Mail.Compose";
            this.Tabs.Add(this.tab1);
            this.Load += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonUIEventArgs>(this.GpgRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox signMailCheck;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox encryptMailCheck;
    }

    partial class ThisRibbonCollection : Microsoft.Office.Tools.Ribbon.RibbonReadOnlyCollection
    {
        internal GpgRibbonCompose GpgRibbon
        {
            get { return this.GetRibbon<GpgRibbonCompose>(); }
        }
    }
}
