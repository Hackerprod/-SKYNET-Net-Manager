using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET
{
    public class Device
    {
        public string Name { get; set; }
        public string Ip { get; set; }
        public bool TCP { get; set; }
        public int Port { get; set; }
        public int Interval { get; set; }
        public string OpcionalLocation { get; set; }
        public int Orden { get; set; }
        public bool CircularAvatar { get; set; }

    }
}
