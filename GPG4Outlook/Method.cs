using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace GPG4OutlookLib
{
    public abstract class Method
    {
        protected StringBuilder commandLine;
        private Process gpgProcess;
        private string _outputString; // locked by output reader thread
        private string _errorString; //locked by error reader thread

        public Method()
        {
            this.commandLine = new StringBuilder();
            this.commandLine.Append("--no-verbose ");
        }

        public MessageContainer execute(String message)
        {
            this.gpgProcess = Process.Start(gpgProcessInformation());

            this.startOutputReader();
            this.startErrorReader();

            this.gpgProcess.StandardInput.WriteLine(message);
            this.gpgProcess.StandardInput.Flush();
            this.gpgProcess.StandardInput.Close();

            if (!this.gpgProcess.WaitForExit(10000)) { throw new GPG4OutlookException(Properties.messages.Default.timeOutError); }

            if (this.gpgProcess.ExitCode != 0) { throw new GPG4OutlookException(this._errorString); }

            return new MessageContainer(this._outputString, this._errorString);
        }

        private ProcessStartInfo gpgProcessInformation()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("gpg.exe", this.commandLine.ToString());

            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;

            return processStartInfo;
        }

        private void startOutputReader()
        {
            ThreadStart outputEntry = new ThreadStart(StandardOutputReader);
            Thread outputThread = new Thread(outputEntry);
            outputThread.Start();
        }
        private void startErrorReader()
        {
            ThreadStart errorEntry = new ThreadStart(StandardErrorReader);
            Thread errorThread = new Thread(errorEntry);
            errorThread.Start();
        }

        private void StandardOutputReader()
        {
            string output = this.gpgProcess.StandardOutput.ReadToEnd();
            lock (this) { this._outputString = output; }
        }

        private void StandardErrorReader()
        {
            string error = this.gpgProcess.StandardError.ReadToEnd();
            lock (this) { this._errorString = error; }
        }
    }
}