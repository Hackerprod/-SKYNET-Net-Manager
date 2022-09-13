using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SKYNET.Helpers
{
    public static class NetHelper
    {

        public static void ListAllHosts(IPAddress address, Action<AddressStruct> itemCallback)
        {
            var ipBase = address.GetAddressBytes();

            for (int b4 = 0; b4 <= 255; b4++)
            {
                var ip = ipBase[0] + "." + ipBase[1] + "." + ipBase[2] + "." + b4;

                var ping = new Ping();
                ping.PingCompleted += (o, e) =>
                {
                    if (e.Error == null && e.Reply.Status == IPStatus.Success)
                        if (itemCallback != null)
                        {
                            GetMACAddress(e.Reply.Address, (mac) =>
                            {
                                itemCallback(new AddressStruct()
                                {
                                    IPAddress = e.Reply.Address,
                                    MacAddress = mac
                                });
                            });
                        }
                };
                ping.SendAsync(ip, null);
            }
        }

        public static string GetMACAddress(IPAddress address)
        {
            var destAddr = BitConverter.ToInt32(address.GetAddressBytes(), 0);
            var srcAddr = BitConverter.ToInt32(System.Net.IPAddress.Any.GetAddressBytes(), 0);
            var macAddress = new byte[6];
            var macAddrLen = macAddress.Length;
            var ret = SendArp(destAddr, srcAddr, macAddress, ref macAddrLen);
            if (ret != 0)
            {
                return "";
            }
            var mac = new PhysicalAddress(macAddress);
            return BitConverter.ToString(macAddress).Replace('-', ':');
        }

        public static void GetMACAddress(IPAddress address, Action<PhysicalAddress> callback)
        {
            new Thread(() =>
            {
                try
                {
                    var destAddr = BitConverter.ToInt32(address.GetAddressBytes(), 0);

                    var srcAddr = BitConverter.ToInt32(System.Net.IPAddress.Any.GetAddressBytes(), 0);

                    var macAddress = new byte[6];

                    var macAddrLen = macAddress.Length;

                    var ret = SendArp(destAddr, srcAddr, macAddress, ref macAddrLen);

                    if (ret != 0)
                    {
                        throw new System.ComponentModel.Win32Exception(ret);
                    }

                    var mac = new PhysicalAddress(macAddress);

                    if (callback != null)
                        callback(mac);
                }
                catch
                {
                    //do nothing
                }
            })
            {
                IsBackground = true
            }.Start();
        }

        public static PhysicalAddress GetPhysicalAddress(IPAddress address)
        {
            PhysicalAddress mac = new PhysicalAddress(new byte[0]);
            new Thread(() =>
            {
                try
                {
                    var destAddr = BitConverter.ToInt32(address.GetAddressBytes(), 0);

                    var srcAddr = BitConverter.ToInt32(System.Net.IPAddress.Any.GetAddressBytes(), 0);

                    var macAddress = new byte[6];

                    var macAddrLen = macAddress.Length;

                    var ret = SendArp(destAddr, srcAddr, macAddress, ref macAddrLen);

                    if (ret != 0)
                    {
                        throw new System.ComponentModel.Win32Exception(ret);
                    }

                    mac = new PhysicalAddress(macAddress);
                }
                catch
                {
                    //do nothing
                }
            })
            {
                IsBackground = true
            }.Start();
            return mac;
        }

        public static IPAddress GetFirstIPAddress(IPAddress Address)
        {
            var bytes = Address.GetAddressBytes();
            var bytes2 = new byte[] { bytes[0], bytes[1], bytes[2], 0 };
            return new IPAddress(bytes2);
        }

        public static IPAddress GetLastIPAddress(IPAddress Address)
        {
            var bytes = Address.GetAddressBytes();
            var bytes2 = new byte[] { bytes[0], bytes[1], bytes[2], 255 };
            return new IPAddress(bytes2);
        }


        public struct AddressStruct
        {
            public IPAddress IPAddress;

            public PhysicalAddress MacAddress;
        }

        [DllImport("Iphlpapi.dll", EntryPoint = "SendARP")]
        public extern static Int32 SendArp(Int32 destIpAddress, Int32 srcIpAddress, byte[] macAddress, ref Int32 macAddressLength);

        public static bool IsValidIp(string iPAddress)
        {
            return IPAddress.TryParse(iPAddress, out _);
        }

        public static List<IPAddress> GetIPAddresses()
        {
            List<IPAddress> list = new List<IPAddress>();
            List<NetworkInterface> enumerable = (from nic in NetworkInterface.GetAllNetworkInterfaces()
                                                       where nic.OperationalStatus == OperationalStatus.Up
                                                       select nic).ToList();
            foreach (NetworkInterface item in enumerable)
            {
                IPInterfaceProperties iPProperties = item.GetIPProperties();
                foreach (UnicastIPAddressInformation unicastAddress in iPProperties.UnicastAddresses)
                {
                    if (!list.Contains(unicastAddress.Address))
                    {
                        list.Add(unicastAddress.Address);
                    }
                }
            }
            return (from ip in list
                    orderby RankIpAddress(ip) descending
                    select ip).ToList();
        }

        public static int RankIpAddress(IPAddress addr)
        {
            int num = 1000;
            if (IPAddress.IsLoopback(addr))
            {
                num = 300;
            }
            else if (addr.AddressFamily == AddressFamily.InterNetwork)
            {
                num += 100;
                if (addr.GetAddressBytes().Take(2).SequenceEqual(new byte[2]
                {
                    169,
                    254
                }))
                {
                    num = 0;
                }
            }
            if (num > 500)
            {
                foreach (NetworkInterface item in TryGetCurrentNetworkInterfaces())
                {
                    IPInterfaceProperties iPProperties = item.GetIPProperties();
                    if (iPProperties.GatewayAddresses.Any())
                    {
                        if (iPProperties.UnicastAddresses.Any((UnicastIPAddressInformation u) => u.Address.Equals(addr)))
                        {
                            num += 1000;
                        }
                        break;
                    }
                }
            }
            return num;
        }
        public static IEnumerable<NetworkInterface> TryGetCurrentNetworkInterfaces()
        {
            try
            {
                return from ni in NetworkInterface.GetAllNetworkInterfaces()
                       where ni.OperationalStatus == OperationalStatus.Up
                       select ni;
            }
            catch (NetworkInformationException)
            {
                return Enumerable.Empty<NetworkInterface>();
            }
        }

        public static IPAddress ToIPAddress(this string AddressString)
        {
            if (!IPAddress.TryParse(AddressString, out var Address))
            {
                Address = IPAddress.Loopback;
            }
            return Address;
        }

    }
}
