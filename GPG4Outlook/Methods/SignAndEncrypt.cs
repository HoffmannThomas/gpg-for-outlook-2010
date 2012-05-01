using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Outlook;

namespace GPG4OutlookLib.Methods
{
    internal class SignAndEncrypt : Encrypt
    {
        internal SignAndEncrypt(Recipients recipients, String sender, Boolean armor)
            : base(recipients, armor)
        {
            this.commandLine.Append(" --sign -u ");
            this.commandLine.AppendFormat(sender);
        }
    }
}
