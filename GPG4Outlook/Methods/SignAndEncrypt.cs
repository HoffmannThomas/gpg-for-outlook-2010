using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Outlook;

namespace GPG4OutlookLib.Methods
{
    public class SignAndEncrypt : Encrypt
    {
        public SignAndEncrypt(Recipients recipients, String sender) : base(recipients)
        {
            this.commandLine.Append(" --sign -u ");
            this.commandLine.AppendFormat(sender);
        }
    }
}
