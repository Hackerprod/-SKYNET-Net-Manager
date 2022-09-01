using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Net;
using WebSocketSharp.Server;

namespace SKYNET
{
    public class MessageProcessor
    {
        private HttpServer server;
        public EventHandler<MessageReceived> OnMessageReceived;

        public MessageProcessor()
        {
            server = new HttpServer(28082);
            server.OnGet += OnMessage;
            server.OnPost += OnMessage;
        }
        private void OnMessage(object sender, HttpRequestEventArgs e)
        {
            string EndPoint = e.Request.Url.AbsolutePath;

            switch (EndPoint)
            {
                case "/onMessage":
                    {
                        byte[] body = GetBody(e.Request.InputStream);
                        var Remote = e.Request.RemoteEndPoint;

                        e.Response.StatusCode = (int)WebSocketSharp.Net.HttpStatusCode.OK;
                        e.Response.Close();

                        string Message = Encoding.Default.GetString(body);

                        Device box = DeviceManager.GetDeviceFromIP((Remote).Address);

                        OnMessageReceived?.Invoke(this, new MessageReceived()
                        {
                            Device = box,
                            Message = Message,
                            Address = (Remote).Address
                        });
                    }
                    break;
                case "/onPing":
                    e.Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    e.Response.OutputStream.Flush();
                    break;
                default:
                    e.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                    break;
            }
        }

        private byte[] GetBody(Stream inputStream)
        {
            MemoryStream bodyStream = new MemoryStream();
            using (Stream stream = inputStream)
            {
                stream.CopyTo(bodyStream);
            }
            return bodyStream.ToArray();
        }

        public bool Start()
        {
            try
            {
                server.Start();
                return true;
            }
            catch
            {
            }
            return false;
        }

        public class MessageReceived
        {
            public Device Device { get; set; }
            public string Message { get; set; }
            public IPAddress Address { get; set; }
        }
    }
}
