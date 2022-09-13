using System;
using System.Collections.Generic;
using System.Net;

namespace SKYNET.Types
{
    public class ChatMessage
    {
        public string Sender { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public List<IPAddress> Addresses { get; set; }

        public ChatMessage()
        {
            Addresses = new List<IPAddress>();
        }
    }
}
