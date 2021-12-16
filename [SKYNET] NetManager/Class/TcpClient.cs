using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Security.Permissions;
using SKYNET;

namespace TCPClient
{
    public class Client
    {
        /// <summary>
        /// A delegate type called when a client recieves data from a server.  Void return type.
        /// </summary>
        /// <param name="message">A byte array representing the message received from the server.</param>
        /// <param name="messageSize">The size, in bytes of the message.</param>
        public delegate void ReceiveDataCallback(byte[] message, int messageSize);

        /// <summary>
        /// A delegate type called when a client receives a broadcast message.  Void return type.
        /// </summary>
        /// <param name="message">A byte array representing the message received from the server.</param>
        /// <param name="messageSize">The size, in bytes of the message.</param>
        public delegate void ReceiveBroadcastCallback(byte[] message, int messageSize);

        /// <summary>
        /// A delegate called when disconnected from the server.
        /// </summary>
        public delegate void DisconnectCallback();

        private ReceiveDataCallback _receive = null;
        private DisconnectCallback _disconnect = null;

        private TcpClient client;
        public DateTime LastDataFromServer;
        DateTime SentDateTime;

        public ReceiveDataCallback OnReceiveData
        {
            get
            {
                return _receive;
            }
            set
            {
                _receive = value;
            }
        }
        public Socket socket
        {
            get
            {
                return client.Client;
            }
        }
        public DisconnectCallback OnDisconnected
        {
            get
            {
                return _disconnect;
            }
            set
            {
                _disconnect = value;
            }
        }

        public bool Connected
        {
            get
            {
                if (client == null)
                    return false;
                else
                    return client.Connected;
            }
        }
        public Client()
        {
            client = new TcpClient();
        }
        public void Connect(IPAddress address, int port, out IPEndPoint socket)
        {
            client = new TcpClient();

            client.Connect(new IPEndPoint(address, port));

            socket = client.Client.RemoteEndPoint as IPEndPoint;

            client.Close();
            //client.Client.Close();

            /*
            if (!Connected)
            {
                client = new TcpClient();
                client.Connect(new IPEndPoint(address, port));
            }

            SendData();

            if (client.Connected)
                WaitForData();
            */
        }

        /// <summary>
        /// Disconnect a client from a server.  If the client is not connected to a server when this function is called, there is no effect.
        /// </summary>
        public void Disconnect()
        {
            try
            {
                if (client != null)
                {
                    client.Close();
                    client.Client.Close();
                }
            }
            catch { }
        }

        /// <summary>
        /// Start an asynchronous wait for data from the server.  When data is recieved, a callback will be triggered.
        /// </summary>
        private void WaitForData()
        {
            try
            {
                Packet pack = new Packet(client.Client);
                client.Client.BeginReceive(pack.DataBuffer, 0, pack.DataBuffer.Length, SocketFlags.None, new AsyncCallback(OnDataReceived), pack);
            }
            catch
            {

            }
        }
        /// <summary>
        /// A callback triggered by receiving data from the server.
        /// </summary>
        /// <param name="asyn">The packet object received from the server containing the received message.</param>
        private void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                Packet socketData = (Packet)asyn.AsyncState;
                WaitForData();

                TimeSpan span = DateTime.Now - SentDateTime;
            }
            catch (SocketException)
            {
                if (OnDisconnected != null)
                    OnDisconnected();
            }
        }


        /// <summary>
        /// Represents a TCP/IP transmission containing the socket it is using, the clientNumber
        ///  (used by server communication only), and a data buffer representing the message.
        /// </summary>
        private class Packet
        {
            public Socket CurrentSocket;
            //public byte[] DataBuffer = new byte[4096];
            public byte[] DataBuffer = new byte[1024];

            /// <summary>
            /// Construct a Packet Object
            /// </summary>
            /// <param name="sock">The socket this Packet is being used on.</param>
            /// <param name="client">The client number that this packet is from.</param>
            public Packet(Socket sock)
            {
                CurrentSocket = sock;
            }
        }

        public void SendData()
        {
            try
            {
                byte[] buffer = new byte[4];
                client.Client.Send(buffer);
            }   catch { }

            SentDateTime = DateTime.Now;
        }
    }
}
