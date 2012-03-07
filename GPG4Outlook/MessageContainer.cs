using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPG4OutlookLib
{
    public class MessageContainer
    {
        public String message { get; private set; }
        public String information { get; private set; }

        public MessageContainer(String message, String information)
        {
            this.message = message;
            this.information = information;
        }
    }
}
