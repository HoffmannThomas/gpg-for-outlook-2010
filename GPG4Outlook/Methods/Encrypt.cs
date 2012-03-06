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

            foreach (Recipient recipient in recipients)
            {
                this.commandLine.Append(" --recipient " + recipient.Address);

                this.commandLine.Append(" --encrypt");
            }
        }
    }
}
