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
            String output = null;
            Process process = new Process();
            process.StartInfo = CreateStartInfo(message);

            try
            {                
                process.Start();
                process.StandardOutput.ReadToEnd();

                if (!process.WaitForExit(10000))
                {
                    throw new GPG4OutlookException("A time out event occurred while executing the GPG program.");
                }

                if (process.ExitCode != 0)
                {
                }

            }
            catch (Exception)
            {
                throw new GPG4OutlookException(process.StandardError.ReadToEnd());
            }

            return output;
        }

        private ProcessStartInfo CreateStartInfo(String message)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();

            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.Arguments = "echo " + message + " | " + this.commandLine.ToString();
            processStartInfo.FileName = "CMD.exe";

            return processStartInfo;
        }

    }
}