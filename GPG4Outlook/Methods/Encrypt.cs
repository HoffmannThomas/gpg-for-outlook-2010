using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Outlook;

namespace GPG4OutlookLib.Methods
{
    public class Encrypt : Method
    {
        public Encrypt(Recipients recipients)
            : base()
        {
            if (recipients == null || recipients.Count == 0) { throw new GPG4OutlookException(Properties.messages.Default.recipientError); }

            this.commandLine.Append(" --encrypt");
            this.commandLine.Append(" --armor");
            this.commandLine.Append(" --always-trust");

            foreach (Recipient recipient in recipients)
            {
                this.commandLine.Append(" --recipient " + recipient.Address);
            }
        }
    }
}
