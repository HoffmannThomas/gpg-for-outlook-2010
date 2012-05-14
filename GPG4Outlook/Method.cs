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

        internal MessageContainer execute(String input, Boolean isFile)
        {
            return GPG4OutlookToolbox.execute(this.commandLine.ToString(), input, isFile);
        }
    }
}