using System;

namespace SKYNET.Types
{
    public class ChatMessage
    {
        public string Sender { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public string Address { get; set; }
    }

    public class ChatMessageHistory
    {
        public ChatMessage Message;
        public bool Me;
    }
}
