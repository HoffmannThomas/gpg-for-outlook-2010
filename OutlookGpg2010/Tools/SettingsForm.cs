using System;
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
            this.ShowPopUpBox.Checked = Properties.userSettings.Default.ShowDecryptPopUp;

            this.refreshKeyComboBox();
        }

        private void refreshKeyComboBox () {

            this.keyComboBox.Items.Add(Properties.Resources.defaultSMPTAddress);
            this.keyComboBox.Items.AddRange(GPG4OutlookLib.GPG4OutlookLibrary.listKeys());
            this.keyComboBox.SelectedItem = Properties.userSettings.Default.UsedEmailAddress;
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

        private void ShowPopUpBox_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.userSettings.Default.AlwaysSign = this.AlwaysSignBox.Checked;
            Properties.userSettings.Default.AlwaysEncrypt = this.AlwaysEncryptBox.Checked;
            Properties.userSettings.Default.AlwaysDecrypt = this.AlwaysDecryptBox.Checked;
            Properties.userSettings.Default.ShowDecryptPopUp = this.ShowPopUpBox.Checked;

            Properties.userSettings.Default.UsedEmailAddress = this.keyComboBox.SelectedItem.ToString();

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void keyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
