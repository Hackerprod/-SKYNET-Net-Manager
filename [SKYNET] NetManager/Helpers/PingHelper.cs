using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace SKYNET.Helpers
{
    public class PingHelper
    {
        public event EventHandler<long> OnPingSuccess;
        public event EventHandler<long> OnPingFailed;
        public Device Device;
        public DeviceBox DeviceBox;

        private System.Timers.Timer _timer;
        private bool Initialized;

        public PingHelper()
        {
            _timer = new System.Timers.Timer();
            _timer.AutoReset = false;

        }

        public void Initialize(Device device, DeviceBox box)
        {
            if (Initialized)
            {
                Device = device;

                _timer.Stop();
                _timer.AutoReset = false;
                _timer.Elapsed += _timer_Elapsed;
                _timer.Interval = 5;
                _timer.Start();
            }
            else
            {
                Device = device;
                DeviceBox = box;

                DoPing(false);

                _timer.AutoReset = false;
                _timer.Elapsed += _timer_Elapsed;
                _timer.Interval = 5;
                _timer.Start();

                Initialized = true;
            }
        }

        private async void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            await DoPing();
        }

        private async Task DoPing(bool awaitResponse = true)
        {
            if (IPAddress.TryParse(Device.IPAddress, out var Address) /* && modCommon.IsCableConnected()*/ )
            {
                if (Device.TCP && Device.Port != 80)
                {
                    if (awaitResponse)
                        await RequestConnectionAsync(Address, Device.Port);
                    else
                        RequestConnectionAsync(Address, Device.Port);
                }
                else
                {
                    if (awaitResponse)
                        await RequestPingAsync(Address);
                    else
                        RequestPingAsync(Address);
                }
            }
            else
            {
                OnPingFailed?.Invoke(null, 0);
            }

            _timer.Interval = (double)Device.Interval * 1000;
            _timer.Start();
        }

        public async Task RequestPingAsync(IPAddress Address)
        {
            Settings.TTL = Settings.TTL == 0 ? 32 : Settings.TTL;
            var _pingerOptions = new PingOptions(Settings.TTL, false);

            try
            {
                Ping pinger = new Ping();
                var Reply = await pinger.SendPingAsync(Address, Settings.Timeout, new byte[Settings.BufferSize], _pingerOptions);
                switch (Reply.Status)
                {
                    case IPStatus.Success:
                        OnPingSuccess?.Invoke(null, Reply.RoundtripTime);
                        break;
                    default:
                        OnPingFailed?.Invoke(null, 0);
                        break;
                }
            }
            catch
            {
                OnPingFailed?.Invoke(null, 0);
            }
        }

        public async Task RequestConnectionAsync(IPAddress Address, int Port)
        {
            try
            {
                TcpClient TcpClient = new TcpClient();


                DateTime SentDateTime = DateTime.Now;

                if (TcpClient.ConnectAsync(Address, Port).Wait(TimeSpan.FromMilliseconds(900)))
                {
                    TimeSpan span = DateTime.Now - SentDateTime;
                    long RoundtripTime = span.Milliseconds;
                    OnPingSuccess?.Invoke(null, RoundtripTime);
                    TcpClient.Close();
                }
                else
                {
                    OnPingFailed?.Invoke(null, 0);
                }
            }
            catch
            {
                OnPingFailed?.Invoke(null, 0);
            }

        }
    }
}
