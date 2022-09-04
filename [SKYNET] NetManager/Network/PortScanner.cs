using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET
{
    public class PortScanner
    {
        ProgressBar progressBarCheck;
        public delegate void ScannedPortEventHandler(int port, long miliseconds);
        public static ManualResetEvent connectDone = new ManualResetEvent(false);
        public event ScannedPortEventHandler ClosedPortScanned;
        public event ScannedPortEventHandler OpenPortScanned;
        public event ScannedPortEventHandler FailedPortScanned;

        public delegate void ScannerFinishedEventHandler();
        public event ScannedPortEventHandler ScannerFinished;

        public PortScanner(string Host, int Min, int Max, int TimeOut, ProgressBar progress)
        {
            try
            {
                progressBarCheck = progress;

                int BeginPort = Min;
                int EndPort = Max;
                int str = 0;
                int i;

                progressBarCheck.Maximum = EndPort - BeginPort + 1;

                progressBarCheck.Value = 0;

                IPAddress addr = IPAddress.Parse(Host);

                for (i = BeginPort; i <= EndPort; i++)
                {
                    
                    IPEndPoint ep = new IPEndPoint(addr, i);
                    Socket soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IAsyncResult asyncResult = soc.BeginConnect(ep, new AsyncCallback(ConnectCallback), soc);

                    if (!asyncResult.AsyncWaitHandle.WaitOne(TimeOut, false))
                    {
                        soc.Close();
                        ClosedPortScanned.Invoke(i, 0);
                        progressBarCheck.Value += 1;

                    }
                    else
                    {
                        soc.Close(); 
                        OpenPortScanned.Invoke(i, 0);
                        str++;
                        progressBarCheck.Value += 1;
                    }
                }
            }
            catch
            {
            }
        }
        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState; 
                client.EndConnect(ar); 
                connectDone.Set(); 
            }
            catch
            {
            }
        }

        public void Scan()
        {
            
        }
    }
}
