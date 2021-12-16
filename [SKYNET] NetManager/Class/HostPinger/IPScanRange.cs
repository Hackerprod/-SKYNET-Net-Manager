using System;
using System.Net;
using System.Net.Sockets;

namespace NetUtils
{
    public class IPScanRange
    {
        private IPAddress _start;

        private IPAddress _end;

        public IPAddress Start => _start;

        public IPAddress End => _end;

        public ulong RangeSize => Extract(_end) - Extract(_start);

        public IPScanRange(IPAddress start, IPAddress end)
        {
            SetRange(start, end);
        }

        public IPScanRange(IPAddress start, int subnet)
        {
            SetRange(start, subnet);
        }

        public IPAddress GetNext(IPAddress current)
        {
            if (current != null)
            {
                ulong num = Extract(current);
                if (num == Extract(_end))
                {
                    return null;
                }
                return Pack(current.AddressFamily, num + 1);
            }
            return null;
        }

        public long Compare(IPAddress addr1, IPAddress addr2)
        {
            return (long)(Extract(addr1) - Extract(addr2));
        }

        public ulong GetDistance(IPAddress address)
        {
            return Extract(address) - Extract(_start);
        }

        public void SetRange(IPAddress start, IPAddress end)
        {
            if (Extract(start) > Extract(end))
            {
                throw new ArgumentException("end");
            }
            _start = start;
            _end = end;
        }

        public void SetRange(IPAddress start, int subnet)
        {
            int num = (start.AddressFamily == AddressFamily.InterNetwork) ? 32 : 64;
            if (subnet < 1 || subnet > num - 1)
            {
                throw new ArgumentOutOfRangeException("subnet");
            }
            ulong ip = (ulong)((long)Extract(start) | ((1L << num - subnet) - 1));
            SetRange(start, Pack(start.AddressFamily, ip));
        }

        public static ulong Extract(IPAddress ip)
        {
            byte[] addressBytes = ip.GetAddressBytes();
            Array.Reverse(addressBytes);
            if (addressBytes.Length != 8)
            {
                return BitConverter.ToUInt32(addressBytes, 0);
            }
            return BitConverter.ToUInt64(addressBytes, 0);
        }

        public static IPAddress Pack(AddressFamily family, ulong ip)
        {
            byte[] array = (family == AddressFamily.InterNetwork) ? BitConverter.GetBytes((uint)ip) : BitConverter.GetBytes(ip);
            Array.Reverse(array);
            return new IPAddress(array);
        }
    }

}