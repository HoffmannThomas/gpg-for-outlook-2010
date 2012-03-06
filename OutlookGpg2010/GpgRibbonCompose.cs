using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Outlook;

namespace OutlookGpg2010
{
    public partial class GpgRibbonCompose
    {
        private void GpgRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            Application application = Globals.ThisAddIn.Application;
            application.ItemSend += new ApplicationEvents_11_ItemSendEventHandler(Application_ItemSend);
        }

        private void Application_ItemSend(object Item, ref bool Cancel)
        {
            MailItem mail = Item as MailItem;

            if (mail != null)
            {
                if (this.signMailCheck.Checked) { mail.Body = mail.Body + "\n" + "signed by gpg "; }
                if (this.encryptMailCheck.Checked) { mail.Body = mail.Body + "\n" + "encrypted by gpg "; }
            }
        }

        private void signMailCheck_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void encryptMailCheck_Click(object sender, RibbonControlEventArgs e)
        {

        }
    }
}
