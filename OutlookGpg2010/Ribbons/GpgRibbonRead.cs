﻿using System;
using System.Windows.Forms;
using GPG4OutlookLib;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools.Ribbon;

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
                if (mail.BodyFormat == OlBodyFormat.olFormatPlain) { MessageBox.Show(GPG4OutlookLibary.Decrypt(mail.Body).information, "Verfiied information"); }
                else { MessageBox.Show(GPG4OutlookLibary.Decrypt(mail.HTMLBody).information, "Verfiied information"); }
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

                if (Properties.userSettings.Default.ShowDecryptPopUp)
                {
                    if (mail.BodyFormat == OlBodyFormat.olFormatPlain) { MessageBox.Show(GPG4OutlookLibary.Decrypt(mail.Body).output, "Decrypted message:"); }
                    else { MessageBox.Show(GPG4OutlookLibary.Decrypt(mail.HTMLBody).output, "Decrypted message:"); }
                }
                else
                {
                    if (mail.BodyFormat == OlBodyFormat.olFormatPlain) { mail.Body = GPG4OutlookLibary.Decrypt(mail.Body).output; }
                    else { mail.HTMLBody = GPG4OutlookLibary.Decrypt(mail.HTMLBody).output; }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Ein Fehler ist augetreten:");
            }
        }

        private void settingsButton_Click(object sender, RibbonControlEventArgs e)
        {
            new Tools.SettingsForm().Show();
        }

        private static void decryptAttachments(MailItem mail)
        {
            const String PR_ATTACH_DATA_BIN = "http://schemas.microsoft.com/mapi/proptag/0x37010102";

            foreach (Attachment attachment in mail.Attachments)
            {
                Object attachmentData = attachment.PropertyAccessor.GetProperty(PR_ATTACH_DATA_BIN);

                Byte[] data = null;

                attachment.PropertyAccessor.SetProperty(PR_ATTACH_DATA_BIN, data);
            }
        }
    }
}
