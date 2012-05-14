using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.IO;
using GPG4OutlookLib.Tools;

namespace GPG4OutlookLib
{
    internal abstract class Method
    {
        protected StringBuilder commandLine;

        internal Method()
        {
            this.commandLine = new StringBuilder();
            this.commandLine.Append("--no-verbose ");
        }

        internal MessageContainer execute(String input)
        {
            return GPG4OutlookToolbox.execute(this.commandLine.ToString(), input);
        }

        internal Byte[] execute(Byte[] bytes)
        {
            return GPG4OutlookToolbox.execute(this.commandLine.ToString(), bytes);
        }
    }
}