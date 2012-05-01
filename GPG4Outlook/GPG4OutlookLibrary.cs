using System;
using Microsoft.Office.Interop.Outlook;

namespace GPG4OutlookLib
{
    public static class GPG4OutlookLibrary
    {
        public static MessageContainer Clearsign(String input, String sender)
        {
            return new Methods.Clearsign(sender).execute(input);
        }

        public static MessageContainer Encrypt(String input, Recipients recipients, Boolean armor)
        {
            return new Methods.Encrypt(recipients, armor).execute(input);
        }

        public static MessageContainer SignAndEncrypt(String input, Recipients recipients, Boolean armor, String sender)
        {
            return new Methods.SignAndEncrypt(recipients, sender, armor).execute(input);
        }

        public static MessageContainer Decrypt(String input)
        {
            return new Methods.Decrypt().execute(input);
        }

        public static MessageContainer Verify(String input)
        {
            return Decrypt(input);
        }
    }
}
