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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            this.AlwaysSignBox.Checked = Properties.userSettings.Default.AlwaysSign;
            this.AlwaysEncryptBox.Checked = Properties.userSettings.Default.AlwaysEncrypt;
            this.AlwaysDecryptBox.Checked = Properties.userSettings.Default.AlwaysDecrypt;
        }

        private void AlwaysSignBox_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void AlwaysEncryptBox_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void AlwaysDecryptBox_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.userSettings.Default.AlwaysSign = this.AlwaysSignBox.Checked;
            Properties.userSettings.Default.AlwaysEncrypt = this.AlwaysEncryptBox.Checked;
            Properties.userSettings.Default.AlwaysDecrypt = this.AlwaysDecryptBox.Checked;

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
