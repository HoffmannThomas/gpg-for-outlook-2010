using System;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools.Ribbon;

namespace OutlookGpg2010
{
    public partial class GpgRibbonCompose
    {
        private void GpgRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            Globals.ThisAddIn.Application.ItemSend += new ApplicationEvents_11_ItemSendEventHandler(Application_ItemSend);

            this.signMailCheck.Checked = Properties.userSettings.Default.AlwaysSign;
            this.encryptMailCheck.Checked = Properties.userSettings.Default.AlwaysEncrypt;

            if (this.encryptMailCheck.Checked) { this.setMailBodyFormatPlain(); }
        }

        private void Application_ItemSend(object Item, ref bool Cancel)
        {

            if (!(!this.signMailCheck.Checked && !this.encryptMailCheck.Checked))
            {

                MailItem mail = Item as MailItem;

                if (mail != null)
                {
                    try
                    {
                        string myEmailAddress = Globals.ThisAddIn.Application.ActiveExplorer().Session.CurrentUser.Address;

                        if (this.signMailCheck.Checked && !this.encryptMailCheck.Checked) { mail.Body = ((new GPG4OutlookLib.Methods.Sign(myEmailAddress)).execute(mail.Body)).message; }
                        if (!this.signMailCheck.Checked && this.encryptMailCheck.Checked) { mail.Body = ((new GPG4OutlookLib.Methods.Encrypt(mail.Recipients)).execute(mail.Body)).message; }
                        if (this.signMailCheck.Checked && this.encryptMailCheck.Checked) { mail.Body = ((new GPG4OutlookLib.Methods.SignAndEncrypt(mail.Recipients, myEmailAddress)).execute(mail.Body)).message; }
                    }
                    catch (System.Exception ex)
                    {
                        string err = ex.Message;
                    }
                }
            }

        }

        private void signMailCheck_Click(object sender, RibbonControlEventArgs e)
        {
        }

        private void encryptMailCheck_Click(object sender, RibbonControlEventArgs e)
        {
            this.setMailBodyFormatPlain();
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
    }
}
