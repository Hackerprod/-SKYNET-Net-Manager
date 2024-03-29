﻿using SKYNET.GUI;
using SKYNET.Helpers;
using SKYNET.NetUtils;
using SKYNET.Properties;
using SKYNET.Types;
using System;
using System.Drawing;
using System.Media;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class frmDeviceInfo : frmBase
    {
        private DeviceBox DeviceBox;
        private DeviceStats DeviceStats => DeviceBox.DeviceStats;

        private Image BoxImage;
        private AsyncHostNameResolver _nameResolver = new AsyncHostNameResolver();
        private int PingCount = 0;
        private ConnectionStatus LastStatus;


        public frmDeviceInfo(DeviceBox deviceBox = null)
        {
            InitializeComponent();
            base.SetMouseMove(PN_Top);
            CheckForIllegalCrossThreadCalls = false;  
            StatusLabel.Text = "";

            if (deviceBox != null)
            {
                DeviceBox = deviceBox;
                deviceBox.OnInfoUpdated += DeviceBox_OnInfoUpdated;

                for (int i = 1; i < DeviceBox.PingHistory.Count; i++)
                {
                    AddBarGraphic(DeviceBox.PingHistory[i]);
                }

                BoxImage = DeviceBox.PB_Image.Image;

                if (DeviceBox.CircularImage)
                {
                    Avatar.Image = ImageHelper.CropToCircle(BoxImage);
                }
                else
                    Avatar.Image = BoxImage;

                if (DeviceBox.Device.TCP && DeviceBox.Device.Port == 0)
                    DeviceBox.Device.Port = 80;

                DeviceName.Text = DeviceBox.Device.Name;

                if (DeviceBox.Device.TCP)
                {
                    DeviceIp.Text = DeviceBox.Device.IPAddress + ":" + DeviceBox.Device.Port;
                }
                else
                { 
                    DeviceIp.Text = DeviceBox.Device.IPAddress.ToString();
                }
                MAC.Text = DeviceBox.MAC;

                D_Status.Image = GetImageFromStatus(DeviceBox.Status);

                StatusDevice.Text = DeviceBox.Status.ToString();

                _nameResolver.ResolveHostName(DeviceBox.Device.IPAddress.ToIPAddress(), StoreHostName);
            }
            else
            {
                Close();
            }

            D_Status.Parent = Avatar;
        }

        private void DeviceBox_OnInfoUpdated(object sender, EventArgs e)
        {
            try
            {
                _Status = DeviceBox.Status;

                //Avatar.Image = device.PB_Image.Image;

                // Graphic ///////////////////////////////////////
                if (PingCount != DeviceStats.SentPackets)
                {

                    int GraphicTime = (int)DeviceStats.CurrentResponseTime;
                    AddBarGraphic(GraphicTime);

                    if (LastStatus != DeviceBox.Status)
                    {
                        SoundPlayer beep = null;
                        switch (DeviceBox.Status)
                        {
                            case ConnectionStatus.Online:
                                beep = new SoundPlayer(Resources.Online1);
                                break;
                            case ConnectionStatus.Offline:
                                beep = new SoundPlayer(Resources.Offline);
                                break;
                        }
                        beep.Play();
                        LastStatus = DeviceBox.Status;
                    }
                }
                else
                    LastStatus = DeviceBox.Status;
                //////////////////////////////////////////////////


                DeviceName.Text = DeviceBox.Device.Name;

                if (DeviceBox.Device.TCP)
                {
                    DeviceIp.Text = DeviceBox.Device.IPAddress + ":" + DeviceBox.Device.Port;
                }
                else
                {
                    DeviceIp.Text = DeviceBox.Device.IPAddress.ToString();
                }
                HostName.Text = DeviceBox.Device.IPAddress.ToString();
                MAC.Text = DeviceBox.MAC;

                StatusDevice.Text = DeviceBox.Status.ToString();
                D_Status.Image = GetImageFromStatus(DeviceBox.Status);

                if (string.IsNullOrEmpty(HostDescription.Text) || HostDescription.Text == "Loading info...")
                {
                    HostDescription.Text = DeviceBox.Device.Name;
                }
                if (DeviceBox.Device.Name.Length > 12)
                {
                    HostDescription.Font = new Font("Segoe UI Emoji", 7.7F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                }

                Status.Text = DeviceBox.Status.ToString();
                SentPackets.Text = DeviceStats.SentPackets.ToString();
                ReceivedPackets.Text = DeviceStats.ReceivedPackets.ToString();
                ReceivedPacketsPercent.Text = PercentToString(GetPacketsPercent(DeviceStats.ReceivedPackets, DeviceStats.SentPackets));
                LostPackets.Text = DeviceStats.LostPackets.ToString();
                LostPacketsPercent.Text = PercentToString(GetPacketsPercent(DeviceStats.LostPackets, DeviceStats.SentPackets));

                if (DeviceStats.LastPacketLost)
                    LastPacketLost.Text = "Si";
                else
                    LastPacketLost.Text = "No";

                ConsecutivePacketsLost.Text = DeviceStats.ConsecutivePacketsLost.ToString();
                CurrentResponseTime.Text = DeviceStats.CurrentResponseTime + " ms";
                AverageResponseTime.Text = ToString(GetAverageResponseTime(DeviceStats.ReceivedPackets, DeviceStats.TotalResponseTime)) + " ms";

                if (DeviceStats.MinResponseTime == 9223372036854775807L)
                    MinResponseTime.Text = "1000" + " ms";
                else
                    MinResponseTime.Text = DeviceStats.MinResponseTime + " ms";

                MaxResponseTime.Text = DeviceStats.MaxResponseTime + " ms";
                CurrentStatusDuration.Text = DurationToString(DateTime.Now.Subtract(DeviceStats.StatusReachedAt));

                GetAliveDuration.Text = DeviceStats.OnlineStatusDuration;
                GetDeadDuration.Text = DeviceStats.OfflineStatusDuration;
                TotalTime.Text = GetTotalTime(DeviceStats.StartTime);
                //HostAvailability.Text = Box.HostAvailability;
            }
            catch
            {

            }

        Jump:;

        }

        private ConnectionStatus _Status
        {
            get { return _Status; }
            set
            {
                label23.Text = "Duración del estado actual (            )";

                if (value == ConnectionStatus.Online)
                {
                    StatusICON.Image = Resources.D_Online;
                    StatusLabel.Text = "Online";
                }
                else
                {
                    StatusICON.Image = Resources.D_Offline;
                    StatusLabel.Text = "Offline";
                }
            }
        }

        private Image GetImageFromStatus(ConnectionStatus status)
        {
            if (status == ConnectionStatus.Online)
                return Resources.D_Online;

            else
                return Resources.D_Offline;
        }

        public void StoreHostName(string name)
        {
            if (name.Length > 12)
            {
                HostDescription.Font = new Font("Segoe UI Emoji", 7F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            HostDescription.Text = name;
        }

        private void AddBarGraphic(int GraphicTime)
        {
            if (DeviceBox.Status == ConnectionStatus.Offline)
                GraphicTime = 200;
            
            deviceHistory1.Add(GraphicTime);
        }

        private string ToString(float v)
        {
            string Float = v.ToString();
            string[] parts = Float.Split(',');
            if (parts.Length == 2)
            {
                Float = parts[0] + ",";
                for (int i = 0; i < parts[1].Length; i++)
                {
                    Float += parts[1][i];
                    if (i == 2)
                        break;
                }
            }

            return Float;
        }

        private string GetTotalTime(DateTime startTime)
        {
            TimeSpan duration = DateTime.Now - startTime;
            StringBuilder stringBuilder = new StringBuilder();
            if (duration.Days > 0)
            {
                stringBuilder.Append(duration.Days);
                stringBuilder.Append((duration.Days > 1) ? " days " : " day ");
            }
            stringBuilder.AppendFormat("{0:d2} : {1:d2} : {2:d2}", duration.Hours, duration.Minutes, duration.Seconds);
            return stringBuilder.ToString();
        }

        private string DurationToString(TimeSpan duration)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (duration.Days > 0)
            {
                stringBuilder.Append(duration.Days);
                stringBuilder.Append((duration.Days > 1) ? " days " : " day ");
            }
            stringBuilder.AppendFormat("{0:d2} : {1:d2} : {2:d2}", duration.Hours, duration.Minutes, duration.Seconds);
            return stringBuilder.ToString();
        }

        public TimeSpan GetStatusDuration(ConnectionStatus status, DeviceBox Box)
        {
            TimeSpan timeSpan = DeviceStats.StatusDurations[Box.Status];
            if (Box.Status == status)
            {
                timeSpan += DateTime.Now - DeviceStats.StatusReachedAt;
            }
            return timeSpan;
        }

        private string PercentToString(float percent)
        {
            return $"{percent / 100f:P}";
        }

        public float GetAverageResponseTime(long receivedPackets, long totalResponseTime)
        {
            return (receivedPackets != 0) ? ((float)totalResponseTime / (float)receivedPackets) : 0f;
        }

        public float GetPacketsPercent(long LostPackets, long SentPackets)
        {
            return (float)LostPackets / (float)SentPackets * 100f;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            int attrValue = 2;
            DwmApi.DwmSetWindowAttribute(base.Handle, 2, ref attrValue, 4);
            DwmApi.MARGINS mARGINS = default(DwmApi.MARGINS);
            mARGINS.cyBottomHeight = 1;
            mARGINS.cxLeftWidth = 0;
            mARGINS.cxRightWidth = 0;
            mARGINS.cyTopHeight = 0;
            DwmApi.MARGINS marInset = mARGINS;
            DwmApi.DwmExtendFrameIntoClientArea(base.Handle, ref marInset);
        }

        private void CloseBox_BoxClicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}
