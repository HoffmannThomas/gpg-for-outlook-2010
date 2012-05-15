using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.Office.Interop.Outlook;

namespace GPG4OutlookLib.Tools
{
    internal static class GPG4OutlookToolbox
    {
        private static Object thisLock = new Object();
        private static Process gpgProcess;
        private static Stream _outputStream; // locked by output reader thread
        private static String _errorString; //locked by error reader thread
        private static String mailRegexPattern = @"(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)+)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]";

        internal static String[] listKeys()
        {
            MatchCollection matches = Regex.Matches(execute("--list-secret-keys", "", false).output, mailRegexPattern, RegexOptions.Multiline);

            List<String> keys = new List<String>();

            foreach (Match match in matches)
            {
                keys.Add(match.Value);
            }

            return keys.ToArray();
        }

        internal static MessageContainer execute(String commandLine, String input, Boolean isFile)
        {
            PleaseWaitForm pleaseWaitForm = new PleaseWaitForm();
            pleaseWaitForm.Show();


            if (isFile && commandLine.Contains("--decrypt")) {
                commandLine = commandLine.Replace("--decrypt", "--output " + input.Replace(".gpg","") + " --decrypt"); }
            if (isFile) { commandLine = commandLine + " " + input; }

            gpgProcess = GPG4OutlookToolbox.createNewGPGProcess(commandLine);

            startOutputReader();
            startErrorReader();

            if (!isFile)
            {
                gpgProcess.StandardInput.WriteLine(input);
                gpgProcess.StandardInput.Flush();
                gpgProcess.StandardInput.Close();
            }

            if (!gpgProcess.WaitForExit(60000))
            {
                pleaseWaitForm.Close();
                gpgProcess.Kill();
                throw new GPG4OutlookException(Properties.messages.Default.timeOutError);
            }

            pleaseWaitForm.Close();

            if (gpgProcess.ExitCode != 0) { throw new GPG4OutlookException(_errorString); }

            return new MessageContainer(new StreamReader(_outputStream).ReadToEnd(), _errorString);
        }

        internal static Dictionary<String, String> saveAttachmentsTemporary(Attachments attachments)
        {
            Dictionary<String, String> attachmentDictionary = new Dictionary<String, String>();

            foreach (Attachment attachment in attachments)
            {
                String tempfileName = Path.GetTempPath() + attachment.FileName.Replace(" ", "_");
                attachment.SaveAsFile(tempfileName);
                attachmentDictionary.Add(tempfileName, attachment.DisplayName);
            }

            for (int i = 0; i <= attachments.Count; i++) { attachments.Remove(i); }         

            return attachmentDictionary;
        }

        internal static void cleanupTemporaryAttachments(Dictionary<String, String> attachmentDictionary)
        {
            foreach (String temporaryAttachment in attachmentDictionary.Keys)
            {
                File.Delete(temporaryAttachment);
                File.Delete(temporaryAttachment + ".gpg");
                File.Delete(temporaryAttachment + ".asc");
            }
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
