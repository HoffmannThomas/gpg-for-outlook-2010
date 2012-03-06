using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;

namespace OutlookGpg2010
{
    public partial class GpgRibbonCompose
    {
        private void GpgRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            Globals.ThisAddIn.Application.ItemSend += new ApplicationEvents_11_ItemSendEventHandler(Application_ItemSend);

            this.signMailCheck.Checked = Properties.userSettings.Default.AlwaysSign;
            this.encryptMailCheck.Checked = Properties.userSettings.Default.AlwaysEncrypt;
        }

        private void Application_ItemSend(object Item, ref bool Cancel)
        {

            if (!(!this.signMailCheck.Checked && !this.encryptMailCheck.Checked)){

            MailItem mail = Item as MailItem;

            if (mail != null)
            {
                PasswordPromt promt = new PasswordPromt();
                DialogResult res = promt.ShowDialog();

                if (res == System.Windows.Forms.DialogResult.OK)
                {
                    if (this.signMailCheck.Checked && !this.encryptMailCheck.Checked) { mail.Body = (new GPG4OutlookLib.Methods.Sign(mail.Sender.Address)).execute(mail.Body, promt.password); }
                    if (!this.encryptMailCheck.Checked && this.encryptMailCheck.Checked) { mail.Body = (new GPG4OutlookLib.Methods.Encrypt(mail.Recipients)).execute(mail.Body, promt.password); }
                    if (this.encryptMailCheck.Checked && this.encryptMailCheck.Checked) { mail.Body = (new GPG4OutlookLib.Methods.SignAndEncrypt(mail.Recipients, mail.Sender.Address)).execute(mail.Body, promt.password); }
                }
                else
                {
                    throw new GPG4OutlookLib.GPG4OutlookException("No passphrase provided");
                }

            }
            }

        }

        private void signMailCheck_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void encryptMailCheck_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void settingsButton_Click(object sender, RibbonControlEventArgs e)
        {

        }
    }
}
