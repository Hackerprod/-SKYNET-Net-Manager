using SKYNET.Helpers;
using System;
using System.IO;
using System.Net;
using System.Text;
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
                        if (!frmMain.ReceiveMessages)
                        {
                            e.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                            return;
                        }

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
                    {
                        Common.Show("Ping");
                        if (!frmMain.ReceiveMessages)
                        {
                            e.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                            return;
                        }
                        e.Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        e.Response.OutputStream.Flush();
                    }
                    break;
                case "/Avatar":
                    ResponseAvatar(e);
                    break;
                default:
                    e.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                    break;
            }
        }

        private void ResponseAvatar(HttpRequestEventArgs e)
        {
            string avatarPath = Path.Combine(Common.GetPath(), "Data", "Images", "Avatar.jpg");
            if (!File.Exists(avatarPath))
            {
                var Avatar = ImageHelper.Resize(ImageHelper.GetDesktopWallpaper(true), 200, 200);
                Avatar.Save(avatarPath);
            }

            if (!File.Exists(avatarPath))
            {
                e.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return;
            }

            try
            {
                Stream input = new FileStream(avatarPath, FileMode.Open);

                e.Response.ContentType = "image/jpeg";
                e.Response.ContentLength64 = input.Length;

                byte[] buffer = new byte[input.Length];
                int nbytes;
                while ((nbytes = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    e.Response.OutputStream.Write(buffer, 0, nbytes);
                    e.Response.ContentLength64 = buffer.Length;
                }
                input.Close();

                e.Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                e.Response.OutputStream.Flush();
            }
            catch
            {
                e.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
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
