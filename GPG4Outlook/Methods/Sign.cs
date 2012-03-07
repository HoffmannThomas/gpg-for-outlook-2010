using System;

namespace GPG4OutlookLib.Methods
{
    public class Sign : Method
    {
        public Sign(String sender)
            : base()
        {
            this.commandLine.Append("--clearsign -u ");
            this.commandLine.Append(sender);
        }
    }
}
