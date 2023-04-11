﻿using System.Net;
using System.Net.NetworkInformation;

namespace SKYNET.Models.Network
{
    public class ARPInfo
    {
        public IPAddress IPAddress { get; set; }
        public PhysicalAddress MACAddress { get; set; }
        public bool IsMulticast { get; set; }

        public int IPAddressInt32 => IPAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork ? IPv4Address.ToInt32(IPAddress) : 0;
        public string MACAddressString => MACAddress.ToString().Replace("-", "").Replace("-", "");

        public ARPInfo()
        {

        }

        public ARPInfo(IPAddress ipAddress, PhysicalAddress macAddress, bool isMulticast)
        {
            IPAddress = ipAddress;
            MACAddress = macAddress;
            IsMulticast = isMulticast;
        }
    }
}