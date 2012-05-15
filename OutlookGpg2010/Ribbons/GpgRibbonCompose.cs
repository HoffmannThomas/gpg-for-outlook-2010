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
                        mail.Body = Properties.Resources.cancelErrorMailBody;
                        Cancel = true;                        
                        MessageBox.Show(ex.Message, "Ein Fehler ist aufgetreten:");                        
                    }
                }
            }
        }

        private static String getMyEmailAddress()
        {
            if (Properties.userSettings.Default.AlwaysUseMailAddress)
            {
                if (Properties.userSettings.Default.UsedEmailAddress.Equals(Properties.Resources.defaultSMPTAddress)) {
                    return Globals.ThisAddIn.Application.ActiveExplorer().Session.CurrentUser.Address;
                }else{
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
            Dictionary<String, String> attachmentDictionary = GPG4OutlookLibrary.saveAttachmentsTemporary(mail.Attachments);

            foreach (String temporaryAttachment in attachmentDictionary.Keys)
            {
                GPG4OutlookLibrary.Encrypt(temporaryAttachment, mail.Recipients, false, true);
            }

            List<Microsoft.Office.Interop.Outlook.Attachment> attachments = new List<Attachment>();

            foreach (String temporaryAttachment in attachmentDictionary.Keys)
            {
                mail.Attachments.Add(temporaryAttachment + ".gpg", OlAttachmentType.olByValue, 1, attachmentDictionary[temporaryAttachment]);
            }

            GPG4OutlookLibrary.cleanupTemporaryAttachments(attachmentDictionary);
        }
    }
}
