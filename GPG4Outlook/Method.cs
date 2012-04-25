using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace GPG4OutlookLib
{
    public abstract class Method
    {
        protected StringBuilder commandLine;
        private Process _process;
        private string _outputString;
        private string _errorString;

        public Method()
        {
            this.commandLine = new StringBuilder();
            this.commandLine.Append("--no-verbose ");
        }

        public MessageContainer execute(String message)
        {
            _process = Process.Start(StartInfo());

            ThreadStart outputEntry = new ThreadStart(StandardOutputReader);
            Thread outputThread = new Thread(outputEntry);
            outputThread.Start();
            ThreadStart errorEntry = new ThreadStart(StandardErrorReader);
            Thread errorThread = new Thread(errorEntry);
            errorThread.Start();

            _process.StandardInput.WriteLine(message);
            _process.StandardInput.Flush();
            _process.StandardInput.Close();

            if (!_process.WaitForExit(10000))
            {
                throw new GPG4OutlookException(Properties.messages.Default.timeOutError);
            }

            if (_process.ExitCode != 0) {
                throw new GPG4OutlookException(_errorString);
            }

            return new MessageContainer(_outputString, _errorString);
        }

        private ProcessStartInfo StartInfo()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("gpg.exe", this.commandLine.ToString());

            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;

            return processStartInfo;
        }

        private void StandardOutputReader()
        {
            string output = _process.StandardOutput.ReadToEnd();
            lock (this)
            {
                _outputString = output;
            }
        }

        private void StandardErrorReader()
        {
            string error = _process.StandardError.ReadToEnd();
            lock (this)
            {
                _errorString = error;
            }
        }

    }
}