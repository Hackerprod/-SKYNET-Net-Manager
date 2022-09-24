using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.Network
{
    public class UDPBroadcaster
    {
        public EventHandler<MessageProcessor.MessageReceived> OnMessageReceived;
        /// <summary>
        /// Endpoint to listen
        /// </summary>
        private IPEndPoint _EP1;

        /// <summary>
        /// Endpoint to broadcast
        /// </summary>
        private IPEndPoint _EP2;

        private UdpClient udpClient;

        public UDPBroadcaster()
        {
            _EP1 = new IPEndPoint(IPAddress.Any, 2048);
            _EP2 = new IPEndPoint(IPAddress.Broadcast, 10001);
            udpClient = new UdpClient(_EP1);
        }

        public void Start()
        {
            udpClient.EnableBroadcast = true;

            StartReceiving();
        }

        private async Task StartReceiving()
        {
            var udpReceiver = new UdpClient(_EP2);
            while (true)
            {
                UdpReceiveResult receiveResult;

                try
                {
                    receiveResult = await udpReceiver.ReceiveAsync();
                }
                catch 
                {
                   
                }
                string message = Encoding.Default.GetString(receiveResult.Buffer);
                //OnMessageReceived?.Invoke(this, new MessageProcessor.MessageReceived()
                //{
                //    Address = receiveResult.RemoteEndPoint.Address,
                //    Message = message
                //});

            }
        }

        public async Task Send(string message)
        {
            byte[] buffer = Encoding.Default.GetBytes(message);
            await Send(buffer);
        }

        public async Task Send(byte[] buffer)
        {
            udpClient.EnableBroadcast = true;
            await udpClient.SendAsync(buffer, buffer.Length, _EP2);
            //udpClient.EnableBroadcast = false;
        }
    }
}
