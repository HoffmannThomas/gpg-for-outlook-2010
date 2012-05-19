using System;
using Microsoft.Office.Interop.Outlook;
using GPG4OutlookLib.Tools;
using System.Collections.Generic;
using System.IO;

namespace GPG4OutlookLib
{
    public static class GPG4OutlookLibrary
    {
        public static MessageContainer Clearsign(String input, String sender, Boolean isFile)
        {
            return new Methods.Clearsign(sender).execute(input, isFile);
        }

        public static MessageContainer Encrypt(String input, Recipients recipients, Boolean armor, Boolean isFile)
        {
            return new Methods.Encrypt(recipients, armor).execute(input, isFile);
        }

        public static MessageContainer SignAndEncrypt(String input, Recipients recipients, Boolean armor, String sender, Boolean isFile)
        {
            return new Methods.SignAndEncrypt(recipients, sender, armor).execute(input, isFile);
        }

        public static MessageContainer Decrypt(String input, Boolean isFile)
        {
            return new Methods.Decrypt().execute(input, isFile);
        }

        public static MessageContainer Verify(String input, Boolean isFile)
        {
            return Decrypt(input, isFile);
        }

        public static String[] listKeys()
        {
            return GPG4OutlookToolbox.listKeys();
        }

        public static List<String> saveAttachmentsTemporary(Attachments attachments)
        {
            return GPG4OutlookToolbox.saveAttachmentsTemporary(attachments);        
        }
    }
}
