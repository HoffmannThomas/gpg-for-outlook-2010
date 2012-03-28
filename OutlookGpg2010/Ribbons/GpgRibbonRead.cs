using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;

namespace OutlookGpg2010
{
    public partial class GpgRibbonRead
    {
        Inspector inspector;

        private void GpgRibbonRead_Load(object sender, RibbonUIEventArgs e)
        {
            inspector = Globals.ThisAddIn.Application.ActiveInspector();

            if (Properties.userSettings.Default.AlwaysDecrypt.Equals(true)) { decryptMailItem(); }

        }

        private void verifyImage_Click(object sender, RibbonControlEventArgs e)
        {
            verifyMailItem();
        }

        private void decryptImage_Click(object sender, RibbonControlEventArgs e)
        {
            decryptMailItem();
        }

        private void verifyMailItem()
        {
            try
            {
                MailItem mail = (MailItem)inspector.CurrentItem;
                MessageBox.Show(((new GPG4OutlookLib.Methods.Decrypt()).execute(mail.Body)).information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void decryptMailItem()
        {
            try
            {
                MailItem mail = (MailItem)inspector.CurrentItem;
                MessageBox.Show((new GPG4OutlookLib.Methods.Decrypt()).execute(mail.Body).message);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void settingsButton_Click(object sender, RibbonControlEventArgs e)
        {
            new Tools.SettingsForm().Show();
        }
    }
}
