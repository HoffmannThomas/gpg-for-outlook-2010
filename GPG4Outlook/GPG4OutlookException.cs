using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPG4OutlookLib
{
    public class GPG4OutlookException : Exception
    {
        public GPG4OutlookException(string message) : base(message){    
        }
    }
}
