using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;

namespace OutlookGpg2010
{
    public partial class GpgRibbonRead
    {
        Inspector inspector;

        private void GpgRibbonRead_Load(object sender, RibbonUIEventArgs e)
        {
            inspector = Globals.ThisAddIn.Application.ActiveInspector();
        }

        private void verifyImage_Click(object sender, RibbonControlEventArgs e)
        {
            MailItem mail = (MailItem)inspector.CurrentItem;

            PasswordPromt promt = new PasswordPromt();
            DialogResult res = promt.ShowDialog();

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                mail.Body = (new GPG4OutlookLib.Methods.Verify()).execute(mail.Body, promt.password);
            }
            else
            {
                throw new GPG4OutlookLib.GPG4OutlookException("No passphrase provided");
            }

        }

        private void decryptImage_Click(object sender, RibbonControlEventArgs e)
        {
            MailItem mail = (MailItem)inspector.CurrentItem;

                        PasswordPromt promt = new PasswordPromt();
            DialogResult res = promt.ShowDialog();

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                mail.Body = (new GPG4OutlookLib.Methods.Decrypt()).execute(mail.Body, promt.password);
            }
            else
            {
                throw new GPG4OutlookLib.GPG4OutlookException("No passphrase provided");
            }

        }
    }
}
