using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Outlook;

namespace GPG4OutlookLib.Methods
{
    internal class Encrypt : Method
    {
        internal Encrypt(Recipients recipients, Boolean armor)
            : base()
        {
            if (recipients == null || recipients.Count == 0) { throw new GPG4OutlookException(Properties.messages.Default.recipientError); }

            foreach (Recipient recipient in recipients)
            {
                this.commandLine.Append(" --recipient " + recipient.Address);
            }

            if (armor) { this.commandLine.Append(" --armor"); }
            this.commandLine.Append(" --always-trust");

            this.commandLine.Append(" --encrypt");
        }
    }
}
