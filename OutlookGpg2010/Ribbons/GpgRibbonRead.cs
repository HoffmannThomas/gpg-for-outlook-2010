using System;
using System.Windows.Forms;
using GPG4OutlookLib;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools.Ribbon;
using System.Collections.Generic;
using System.IO;

namespace OutlookGpg2010
{
    public partial class GpgRibbonRead
    {
        Inspector inspector;

        private void GpgRibbonRead_Load(object sender, RibbonUIEventArgs e)
        {
            inspector = Globals.ThisAddIn.Application.ActiveInspector();            

            if (Properties.userSettings.Default.AlwaysDecrypt.Equals(true)) {
                this.verifyMailItem();
                this.decryptMailItem();
            }
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
                String information;

                MailItem mail = (MailItem)inspector.CurrentItem;
                if (mail.BodyFormat == OlBodyFormat.olFormatPlain) {
                    information = GPG4OutlookLibrary.Verify(mail.Body, false).information;                    
                }
                else {
                    information = GPG4OutlookLibrary.Verify(mail.HTMLBody, false).information;
                }

                this.verifyLabel2.Label = information;
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

                decryptAttachments(mail);

                if (Properties.userSettings.Default.ShowDecryptPopUp)
                {
                    if (mail.BodyFormat == OlBodyFormat.olFormatPlain) { MessageBox.Show(GPG4OutlookLibrary.Decrypt(mail.Body, false).output, "Decrypted message:"); }
                    else { MessageBox.Show(GPG4OutlookLibrary.Decrypt(mail.HTMLBody, false).output, "Decrypted message:"); }
                }
                else
                {
                    if (mail.BodyFormat == OlBodyFormat.olFormatPlain) { mail.Body = GPG4OutlookLibrary.Decrypt(mail.Body, false).output; }
                    else { mail.HTMLBody = GPG4OutlookLibrary.Decrypt(mail.HTMLBody, false).output; }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, Properties.Resources.genericError);
            }
        }

        private void settingsButton_Click(object sender, RibbonControlEventArgs e)
        {
            new Tools.SettingsForm().Show();
        }

        private static void decryptAttachments(MailItem mail)
        {
            foreach (String temporaryAttachment in GPG4OutlookLibrary.saveAttachmentsTemporary(mail.Attachments))
            {
                GPG4OutlookLibrary.Decrypt(temporaryAttachment, true);
                File.Delete(temporaryAttachment);
                mail.Attachments.Add(temporaryAttachment.Replace(".gpg", ""), OlAttachmentType.olByValue, 1, Path.GetFileName(temporaryAttachment));
                File.Delete(temporaryAttachment.Replace(".gpg", ""));
            }

        }
    }
}
