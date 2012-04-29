using System;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools.Ribbon;

namespace OutlookGpg2010
{
    public partial class GpgRibbonCompose
    {
        private static bool encrypt;
        private static bool sign;

        private void GpgRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            this.updateCheckBoxes();
            this.setVariables();
            this.checkMailFormat();
        }

        private void updateCheckBoxes() {
            this.signMailCheck.Checked = Properties.userSettings.Default.AlwaysSign;
            this.encryptMailCheck.Checked = Properties.userSettings.Default.AlwaysEncrypt;
        }

        private void setVariables() {
            encrypt = this.encryptMailCheck.Checked;
            sign = this.signMailCheck.Checked;
        }

        private void checkMailFormat() {
            if (encrypt) { this.setMailBodyFormatPlain(); }
        }

        private void signMailCheck_Click(object sender, RibbonControlEventArgs e)
        {
            this.setVariables();
        }

        private void encryptMailCheck_Click(object sender, RibbonControlEventArgs e)
        {
            this.setMailBodyFormatPlain();
            this.setVariables();
        }

        private void settingsButton_Click(object sender, RibbonControlEventArgs e)
        {
            new Tools.SettingsForm().Show();
        }

        private void setMailBodyFormatPlain()
        {
            Inspector inspector = Globals.ThisAddIn.Application.ActiveInspector();

            MailItem mail = (MailItem)inspector.CurrentItem;
            mail.BodyFormat = OlBodyFormat.olFormatPlain;
        }

        internal static void ItemSend(object Item, bool Cancel)
        {
            if (!(!encrypt && !sign))
            {
                MailItem mail = Item as MailItem;

                if (mail != null)
                {
                    try
                    {
                        if (encrypt && !sign) { mail.Body = ((new GPG4OutlookLib.Methods.Sign(getMyEmailAddress())).execute(mail.Body)).message; }
                        if (!encrypt && sign) { mail.Body = ((new GPG4OutlookLib.Methods.Encrypt(mail.Recipients)).execute(mail.Body)).message; }
                        if (encrypt && sign) { mail.Body = ((new GPG4OutlookLib.Methods.SignAndEncrypt(mail.Recipients, getMyEmailAddress())).execute(mail.Body)).message; }
                    }
                    catch (System.Exception ex)
                    {
                        string err = ex.Message;
                        Cancel = true;
                    }
                }
            }
        }

        private static String getMyEmailAddress()
        {
            return Globals.ThisAddIn.Application.ActiveExplorer().Session.CurrentUser.Address;
        }
    }
}
