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
    public partial class SelectKey : Form
    {
        public String selectedMailaddress;

        public SelectKey()
        {
            InitializeComponent();
            this.refreshKeyComboBox();
        }

        private void refreshKeyComboBox()
        {
            this.keyComboBox.Items.Add(Properties.Resources.defaultSMPTAddress);
            this.keyComboBox.Items.AddRange(GPG4OutlookLib.Toolbox.listKeys());
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
    }
}
