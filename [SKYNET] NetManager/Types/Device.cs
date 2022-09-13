using System;
using System.Net;

namespace SKYNET
{
    [Serializable]
    public class Device
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public bool TCP { get; set; }
        public int Port { get; set; }
        public int Interval { get; set; }
        public string OpcionalLocation { get; set; }
        public int Order { get; set; }
        public bool CircularImage { get; set; }

    }
}
