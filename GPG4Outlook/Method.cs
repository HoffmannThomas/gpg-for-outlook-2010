using System;
using System.Diagnostics;
using System.Text;

namespace GPG4OutlookLib
{
    public abstract class Method
    {
        protected StringBuilder commandLine;

        public Method()
        {
            this.commandLine = new StringBuilder();
            this.commandLine.Append("gpg");
        }

        public String execute(String message)
        {
            String output = "";
            String error = "";
            Process process = null;

            process = Process.Start(StartInfo());

            process.StandardInput.WriteLine(@"Echo on");
            process.StandardInput.WriteLine(@"echo " + message + " | " + this.commandLine.ToString());
            process.StandardInput.WriteLine(@"EXIT");

            output = process.StandardOutput.ReadToEnd();
            error = process.StandardError.ReadToEnd();

            if (!process.WaitForExit(10000))
            {
                throw new GPG4OutlookException("A time out event occurred while executing the GPG program.");
            }

            if (error.Length > 1) { throw new GPG4OutlookException(error); }

            return output;
        }

        private ProcessStartInfo StartInfo()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe");

            processStartInfo.CreateNoWindow = false;
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;

            return processStartInfo;
        }

    }
}