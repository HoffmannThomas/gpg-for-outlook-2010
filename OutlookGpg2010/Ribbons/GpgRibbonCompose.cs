using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools.Ribbon;
using GPG4OutlookLib;
using System.IO;
using System.Collections.Generic;

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
            // just in case...
            Cancel = true;

            if (!(!encrypt && !sign))
            {
                MailItem mail = Item as MailItem;

                if (mail != null)
                {
                    try
                    {
                        encryptAttachments(mail);

                        if (mail.BodyFormat == OlBodyFormat.olFormatPlain)
                        {
                            if (!encrypt && sign) { mail.Body = GPG4OutlookLibrary.Clearsign(mail.Body, getMyEmailAddress(), false).output; }
                            if (encrypt && !sign) { mail.Body = GPG4OutlookLibrary.Encrypt(mail.Body, mail.Recipients, true, false).output; }
                            if (encrypt && sign) { mail.Body = GPG4OutlookLibrary.SignAndEncrypt(mail.Body, mail.Recipients, true, getMyEmailAddress(), false).output; }
                        }
                        else
                        {
                            if (!encrypt && sign) { mail.HTMLBody = GPG4OutlookLibrary.Clearsign(mail.HTMLBody, getMyEmailAddress(), false).output; }
                            if (encrypt && !sign) { mail.HTMLBody = GPG4OutlookLibrary.Encrypt(mail.HTMLBody, mail.Recipients, true, false).output; }
                            if (encrypt && sign) { mail.HTMLBody = GPG4OutlookLibrary.SignAndEncrypt(mail.HTMLBody, mail.Recipients, true, getMyEmailAddress(), false).output; }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        cleanupMailAfterError(mail);
                        MessageBox.Show(ex.Message, Properties.Resources.genericError);
                    }
                }
            }

            // everything seems to be fine
            Cancel = false;
        }

        private static void cleanupMailAfterError(MailItem mail)
        {
            mail.Body = Properties.Resources.cancelErrorMailBody;
            removeAllAttachments(mail.Attachments);
        }

        private static String getMyEmailAddress()
        {
            if (Properties.userSettings.Default.AlwaysUseMailAddress)
            {
                if (Properties.userSettings.Default.UsedEmailAddress.Equals(Properties.Resources.defaultSMPTAddress))
                {
                    return Globals.ThisAddIn.Application.ActiveExplorer().Session.CurrentUser.Address;
                }
                else
                {
                    return Properties.userSettings.Default.UsedEmailAddress;
                }
            }
            else
            {
                Tools.SelectIdentityForm selectKey = new Tools.SelectIdentityForm();

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
        }

        private static void encryptAttachments(MailItem mail)
        {
            List<String> encryptedAttachments = new List<String>();

            foreach (Attachment attachment in mail.Attachments)
            {                
                String tempFile = Path.GetTempPath() + attachment.DisplayName;
                File.Delete(tempFile);                
                attachment.SaveAsFile(tempFile);

                File.Delete(tempFile + ".gpg");
                GPG4OutlookLibrary.Encrypt(tempFile, mail.Recipients, false, true);
                File.Delete(tempFile);

                encryptedAttachments.Add(tempFile + ".gpg");
            }

            removeAllAttachments(mail.Attachments);

            foreach (String newAttachment in encryptedAttachments)
            {
                mail.Attachments.Add(newAttachment, OlAttachmentType.olByValue, 1, Path.GetFileName(newAttachment));
                File.Delete(newAttachment);
            }
        }

        private static void removeAllAttachments(Attachments attachments)
        {
            while (attachments.Count > 0)
            {
                attachments.Remove(1);
            }
        }
    }
}
