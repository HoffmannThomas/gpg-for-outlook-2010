using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace GPG4OutlookLib
{
    public static class Toolbox
    {
        private static Object thisLock = new Object();
        private static Process gpgProcess;
        private static Stream _outputStream; // locked by output reader thread
        private static String _errorString; //locked by error reader thread
        private static String mailRegexPattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

        public static String[] listKeys()
        {
            MatchCollection matches = Regex.Matches(execute("--list-keys", null).output, mailRegexPattern, RegexOptions.Multiline);

            List<String> keys = new List<String>();

            foreach (Match match in matches)
            {
                keys.Add(match.Value);
            }

            return keys.ToArray();
        }

        internal static MessageContainer execute(String commandLine, String input)
        {
            gpgProcess = Toolbox.createNewGPGProcess(commandLine);

            startOutputReader();
            startErrorReader();

            if (input != null)
            {
                gpgProcess.StandardInput.WriteLine(input);
                gpgProcess.StandardInput.Flush();
                gpgProcess.StandardInput.Close();
            }

            if (!gpgProcess.WaitForExit(10000)) { throw new GPG4OutlookException(Properties.messages.Default.timeOutError); }

            if (gpgProcess.ExitCode != 0) { throw new GPG4OutlookException(_errorString); }

            return new MessageContainer(new StreamReader(_outputStream).ReadToEnd(), _errorString);
        }

        internal static Byte[] execute(Byte[] bytes, String commandLine)
        {
            MemoryStream stream = new MemoryStream(bytes);

            gpgProcess = Toolbox.createNewGPGProcess(commandLine);

            startOutputReader();
            startErrorReader();

            stream.CopyTo(gpgProcess.StandardInput.BaseStream);

            gpgProcess.StandardInput.BaseStream.Flush();
            gpgProcess.StandardInput.BaseStream.Close();
            gpgProcess.StandardInput.Flush();
            gpgProcess.StandardInput.Close();

            if (!gpgProcess.WaitForExit(10000)) { throw new GPG4OutlookException(Properties.messages.Default.timeOutError); }

            if (gpgProcess.ExitCode != 0) { throw new GPG4OutlookException(_errorString); }

            return (new BinaryReader(_outputStream)).ReadBytes((int)_outputStream.Length);
        }

        private static Process createNewGPGProcess(String commandLine)
        {
            return Process.Start(gpgProcessInformation(commandLine));
        }

        private static ProcessStartInfo gpgProcessInformation(String commandLine)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("gpg.exe", commandLine);

            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;

            return processStartInfo;
        }

        private static void startOutputReader()
        {
            ThreadStart outputEntry = new ThreadStart(StandardOutputReader);
            Thread outputThread = new Thread(outputEntry);
            outputThread.Start();
        }
        private static void startErrorReader()
        {
            ThreadStart errorEntry = new ThreadStart(StandardErrorReader);
            Thread errorThread = new Thread(errorEntry);
            errorThread.Start();
        }

        private static void StandardOutputReader()
        {
            lock (thisLock)
            {
                _outputStream = gpgProcess.StandardOutput.BaseStream;
            }
        }

        private static void StandardErrorReader()
        {
            string error = gpgProcess.StandardError.ReadToEnd();
            lock (thisLock)
            {
                _errorString = error;
            }
        }
    }
}
