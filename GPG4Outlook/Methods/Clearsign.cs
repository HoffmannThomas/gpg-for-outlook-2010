using System;

namespace GPG4OutlookLib.Methods
{
    internal class Clearsign : Method
    {
        internal Clearsign(String sender)
            : base()
        {
            this.commandLine.Append("--clearsign -u ");
            this.commandLine.Append(sender);
        }
    }
}
