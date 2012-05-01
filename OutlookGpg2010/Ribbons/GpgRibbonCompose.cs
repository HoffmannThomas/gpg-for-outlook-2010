using System;
using System.Windows.Forms;
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
        }

        private void updateCheckBoxes()
        {
            this.signMailCheck.Checked = Properties.userSettings.Default.AlwaysSign;
            this.encryptMailCheck.Checked = Properties.userSettings.Default.AlwaysEncrypt;
            this.setVariables();
        }

        private void setVariables()
        {
            encrypt = this.encryptMailCheck.Checked;
            sign = this.signMailCheck.Checked;
        }

        private void signMailCheck_Click(object sender, RibbonControlEventArgs e)
        {
            this.setVariables();
        }

        private void encryptMailCheck_Click(object sender, RibbonControlEventArgs e)
        {
            this.setVariables();
        }

        private void settingsButton_Click(object sender, RibbonControlEventArgs e)
        {
            new Tools.SettingsForm().Show();
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
                        if (!encrypt && sign)
                        {
                            mail.Body = ((new GPG4OutlookLib.Methods.Sign(getMyEmailAddress())).execute(mail.Body)).message;
                        }
                        if (encrypt && !sign)
                        {
                            mail.Body = ((new GPG4OutlookLib.Methods.Encrypt(mail.Recipients, true)).execute(mail.Body)).message;
                            encryptAttachments(mail);
                        }
                        if (encrypt && sign)
                        {

                            if (mail.BodyFormat == OlBodyFormat.olFormatPlain)
                            {
                                mail.Body = ((new GPG4OutlookLib.Methods.SignAndEncrypt(mail.Recipients, getMyEmailAddress(), true)).execute(mail.Body)).message;
                            }
                            else
                            {
                                mail.HTMLBody = ((new GPG4OutlookLib.Methods.SignAndEncrypt(mail.Recipients, getMyEmailAddress(), true)).execute(mail.HTMLBody)).message;
                            }

                            encryptAttachments(mail);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ein Fehler ist augetreten:");
                        Cancel = true;
                    }
                }
            }
        }

        private static String getMyEmailAddress()
        {
            Tools.SelectKey selectKey = new Tools.SelectKey();

            selectKey.ShowDialog();

            if (!selectKey.selectedMailaddress.Equals(Properties.Resources.defaultSMPTAddress))
            {
                return selectKey.selectedMailaddress;
            }
            else
            {
                return Globals.ThisAddIn.Application.ActiveExplorer().Session.CurrentUser.Address;
            }
        }

        private static void encryptAttachments(MailItem mail)
        {
            const String PR_ATTACH_DATA_BIN = "http://schemas.microsoft.com/mapi/proptag/0x37010102";

            foreach (Attachment attachment in mail.Attachments)
            {
                Object attachmentData = attachment.PropertyAccessor.GetProperty(PR_ATTACH_DATA_BIN);

                Byte[] data = new GPG4OutlookLib.Methods.Encrypt(mail.Recipients, false).execute((Byte[])attachmentData);

                attachment.PropertyAccessor.SetProperty(PR_ATTACH_DATA_BIN, data);
            }
        }
    }
}
