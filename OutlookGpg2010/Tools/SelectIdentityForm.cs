using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OutlookGpg2010.Tools
{
    public partial class SelectIdentityForm : Form
    {
        public String selectedMailaddress;

        public SelectIdentityForm()
        {
            InitializeComponent();
            this.refreshKeyComboBox();
        }

        private void refreshKeyComboBox()
        {
            this.keyComboBox.Items.Add(Properties.Resources.defaultSMPTAddress);
            this.keyComboBox.Items.AddRange(GPG4OutlookLib.GPG4OutlookLibrary.listKeys());
            this.keyComboBox.SelectedItem = Properties.userSettings.Default.UsedEmailAddress;
        }

        private void keyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.selectedMailaddress = this.keyComboBox.SelectedItem.ToString();
            this.Close();
        }

        private void SelectKey_Load(object sender, EventArgs e)
        {

        }
    }
}
