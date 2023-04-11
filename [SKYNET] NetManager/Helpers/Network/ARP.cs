﻿// Contains code from: https://stackoverflow.com/a/1148861/4986782
// Modified by BornToBeRoot

using SKYNET.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SKYNET.Models.Network
{
    public class ARP
    {
        // The max number of physical addresses.
        private const int MAXLEN_PHYSADDR = 8;

        // Define the MIB_IPNETROW structure.
        [StructLayout(LayoutKind.Sequential)]
        private struct MIB_IPNETROW
        {
            [MarshalAs(UnmanagedType.U4)]
            public int dwIndex;
            [MarshalAs(UnmanagedType.U4)]
            public int dwPhysAddrLen;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac0;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac1;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac2;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac3;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac4;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac5;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac6;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac7;
            [MarshalAs(UnmanagedType.U4)]
            public int dwAddr;
            [MarshalAs(UnmanagedType.U4)]
            public int dwType;
        }

        // Declare the GetIpNetTable function.
        [DllImport("IpHlpApi.dll")]
        [return: MarshalAs(UnmanagedType.U4)]
        static extern int GetIpNetTable(IntPtr pIpNetTable, [MarshalAs(UnmanagedType.U4)] ref int pdwSize, bool bOrder);

        [DllImport("IpHlpApi.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern int FreeMibTable(IntPtr plpNetTable);

        // The insufficient buffer error.
        const int ERROR_INSUFFICIENT_BUFFER = 122;

        public event EventHandler UserHasCanceled;

        protected virtual void OnUserHasCanceled()
        {
            UserHasCanceled?.Invoke(this, EventArgs.Empty);
        }

        public static Task<List<ARPInfo>> GetTableAsync()
        {
            return Task.Run(() => GetTable());
        }

        public static List<ARPInfo> GetTable()
        {
            var list = new List<ARPInfo>();

            // The number of bytes needed.
            var bytesNeeded = 0;

            // The result from the API call.
            var result = GetIpNetTable(IntPtr.Zero, ref bytesNeeded, false);

            // Call the function, expecting an insufficient buffer.
            if (result != ERROR_INSUFFICIENT_BUFFER)
            {
                // Throw an exception.
                return list;
            }

            // Allocate the memory, do it in a try/finally block, to ensure
            // that it is released.
            var buffer = IntPtr.Zero;

            // Try/finally.
            try
            {
                // Allocate the memory.
                buffer = Marshal.AllocCoTaskMem(bytesNeeded);

                // Make the call again. If it did not succeed, then
                // raise an error.
                result = GetIpNetTable(buffer, ref bytesNeeded, false);

                // If the result is not 0 (no error), then throw an exception.
                if (result != 0)
                {
                    // Throw an exception.
                    throw new Win32Exception(result);
                }

                // Now we have the buffer, we have to marshal it. We can read
                // the first 4 bytes to get the length of the buffer.
                var entries = Marshal.ReadInt32(buffer);

                // Increment the memory pointer by the size of the int.
                var currentBuffer = new IntPtr(buffer.ToInt64() +
                   Marshal.SizeOf(typeof(int)));

                // Allocate an array of entries.
                var table = new MIB_IPNETROW[entries];

                // Cycle through the entries.
                for (var i = 0; i < entries; i++)
                {
                    // Call PtrToStructure, getting the structure information.
                    table[i] = (MIB_IPNETROW)Marshal.PtrToStructure(new
                       IntPtr(currentBuffer.ToInt64() + (i * Marshal.SizeOf(typeof(MIB_IPNETROW)))), typeof(MIB_IPNETROW));
                }

                var virtualMAC = new PhysicalAddress(new byte[] { 0, 0, 0, 0, 0, 0 });
                var broadcastMAC = new PhysicalAddress(new byte[] { 255, 255, 255, 255, 255, 255 });

                for (var i = 0; i < entries; i++)
                {
                    var row = table[i];

                    var ipAddress = new IPAddress(BitConverter.GetBytes(row.dwAddr));
                    var macAddress = new PhysicalAddress(new[] { row.mac0, row.mac1, row.mac2, row.mac3, row.mac4, row.mac5 });

                    // Filter 0.0.0.0.0.0, 255.255.255.255.255.255
                    if (!macAddress.Equals(virtualMAC) && !macAddress.Equals(broadcastMAC))
                        list.Add(new ARPInfo(ipAddress, macAddress, ipAddress.IsIPv6Multicast || IPv4Address.IsMulticast(ipAddress)));
                }

                return list;
            }
            finally
            {
                // Release the memory.
                FreeMibTable(buffer);
            }
        }
    }
}