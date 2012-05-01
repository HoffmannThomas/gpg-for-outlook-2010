using System;

namespace GPG4OutlookLib.Methods
{
    internal class Sign : Method
    {
        internal Sign(String sender)
            : base()
        {
            this.commandLine.Append("--clearsign -u ");
            this.commandLine.Append(sender);
        }
    }
}
