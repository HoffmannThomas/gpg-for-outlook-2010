using Microsoft.Office.Interop.Outlook;

namespace OutlookGpg2010
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Application.ItemSend += new ApplicationEvents_11_ItemSendEventHandler(Application_ItemSend);
        }

        private void Application_ItemSend(object Item, ref bool Cancel)
        {
            GpgRibbonCompose.ItemSend(Item, Cancel);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region Von VSTO generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
