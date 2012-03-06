using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Outlook;

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
            mail.Body = mail.Body.Replace("signed by gpg", "This text was verified");
        }

        private void decryptImage_Click(object sender, RibbonControlEventArgs e)
        {
            MailItem mail = (MailItem)inspector.CurrentItem;
            mail.Body = mail.Body.Replace("encrypted by gpg", "This text was decrypted");
        }
    }
}
