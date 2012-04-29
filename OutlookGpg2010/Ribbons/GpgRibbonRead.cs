﻿using System.Windows.Forms;
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
                MessageBox.Show(((new GPG4OutlookLib.Methods.Decrypt()).execute(mail.Body)).information, "Verfiied information");
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
                    if (mail.BodyFormat == OlBodyFormat.olFormatPlain)
                    {
                        MessageBox.Show((new GPG4OutlookLib.Methods.Decrypt()).execute(mail.Body).message, "Decrypted message:");
                    }
                    else
                    {
                        MessageBox.Show((new GPG4OutlookLib.Methods.Decrypt()).execute(mail.HTMLBody).message, "Decrypted message:");
                    }
                }
                else
                {
                    if (mail.BodyFormat == OlBodyFormat.olFormatPlain)
                    {
                        mail.Body = (new GPG4OutlookLib.Methods.Decrypt()).execute(mail.Body).message;
                    }
                    else
                    {
                        mail.HTMLBody = (new GPG4OutlookLib.Methods.Decrypt()).execute(mail.HTMLBody).message;
                    }
                }
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
