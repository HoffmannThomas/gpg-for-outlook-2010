using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.IO;

namespace GPG4OutlookLib
{
    public abstract class Method
    {
        protected StringBuilder commandLine;

        public Method()
        {
            this.commandLine = new StringBuilder();
            this.commandLine.Append("--no-verbose ");
        }

        public MessageContainer execute(String message)
        {
            return Toolbox.execute(this.commandLine.ToString(), message);
        }

        public Byte[] execute(Byte[] bytes)
        {
            return Toolbox.execute(bytes, this.commandLine.ToString());
        }
    }
}