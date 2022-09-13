using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET
{
    public class Host
    {
        public string HostName { get; set; }
        public IPAddress IPAddress { get; set; }
        public string MAC { get; set; }
        public int Port { get; set; }
        public int Interval { get; set; }
        
    }
}
