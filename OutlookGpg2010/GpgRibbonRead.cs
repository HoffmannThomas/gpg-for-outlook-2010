using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools.Ribbon;
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
            try
            {
                MailItem mail = (MailItem)inspector.CurrentItem;
                mail.Body = (new GPG4OutlookLib.Methods.Verify()).execute(mail.Body);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void decryptImage_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                MailItem mail = (MailItem)inspector.CurrentItem;
                mail.Body = (new GPG4OutlookLib.Methods.Decrypt()).execute(mail.Body);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
