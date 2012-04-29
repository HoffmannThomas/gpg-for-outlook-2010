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
        private Process gpgProcess;
        private Stream _outputStream; // locked by output reader thread
        private String _errorString; //locked by error reader thread

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

            return new MessageContainer(new StreamReader(this._outputStream).ReadToEnd(), this._errorString);
        }

        public Byte[] execute(Byte[] bytes)
        {
            MemoryStream stream = new MemoryStream(bytes);

            this.gpgProcess = Process.Start(gpgProcessInformation());

            this.startOutputReader();
            this.startErrorReader();

            stream.CopyTo(this.gpgProcess.StandardInput.BaseStream);

            this.gpgProcess.StandardInput.BaseStream.Flush();
            this.gpgProcess.StandardInput.BaseStream.Close();
            this.gpgProcess.StandardInput.Flush();
            this.gpgProcess.StandardInput.Close();

            if (!this.gpgProcess.WaitForExit(10000)) { throw new GPG4OutlookException(Properties.messages.Default.timeOutError); }

            if (this.gpgProcess.ExitCode != 0) { throw new GPG4OutlookException(this._errorString); }

            return (new BinaryReader(this._outputStream)).ReadBytes((int)this._outputStream.Length);
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
            lock (this) { this._outputStream = this.gpgProcess.StandardOutput.BaseStream; }
        }

        public static void CopyStream(Stream src, Stream dest)
        {
            int bufferSize = 2048;
            byte[] buffer = new byte[bufferSize];

            int bytesRead = 0;
            while ((bytesRead = src.Read(buffer, 0, bufferSize)) > 0)
            {
                dest.Write(buffer, 0, bytesRead);
            }
        }

        private void StandardErrorReader()
        {
            string error = this.gpgProcess.StandardError.ReadToEnd();
            lock (this) { this._errorString = error; }
        }
    }
}