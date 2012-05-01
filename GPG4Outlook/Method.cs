﻿using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.IO;

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

        internal MessageContainer execute(String message)
        {
            return Toolbox.execute(this.commandLine.ToString(), message);
        }

        internal Byte[] execute(Byte[] bytes)
        {
            return Toolbox.execute(bytes, this.commandLine.ToString());
        }
    }
}