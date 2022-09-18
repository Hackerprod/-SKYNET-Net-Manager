
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SKYNET.Types
{
    public class DeviceStats
    {
        public IPAddress IPAddress;
        public DateTime StartTime;
        public DateTime StatusReachedAt;
        public ConnectionStatus CurrentStatus;
        public Dictionary<ConnectionStatus, TimeSpan> StatusDurations;
        public int SentPackets;
        public int ReceivedPackets;
        public int LostPackets;
        public int ConsecutivePacketsLost;
        public int ConsecutivePacketsLostReceived;
        public bool LastPacketLost;
        public long CurrentResponseTime;
        public long TotalResponseTime;
        public long MinResponseTime;
        public long MaxResponseTime;

        public DeviceStats(string address)
        {
            IPAddress.TryParse(address, out IPAddress);

            StartTime = DateTime.Now;
            StatusDurations = new Dictionary<ConnectionStatus, TimeSpan>()
            {
                {ConnectionStatus.Unknown, new TimeSpan() },
                {ConnectionStatus.Online, new TimeSpan() },
                {ConnectionStatus.Offline, new TimeSpan() },
            };
            StatusReachedAt = DateTime.Now;

            CurrentResponseTime = 0L;
            MinResponseTime = 9223372036854775807L;
            MaxResponseTime = 0L;
            ConsecutivePacketsLostReceived = 0;
            TotalResponseTime = 0L;
        }

        public void StatusChanged(ConnectionStatus value)
        {
            TimeSpan timeSpan = DateTime.Now - StatusReachedAt;
            StatusDurations[value] += timeSpan;
            StatusReachedAt = DateTime.Now;
        }

        public TimeSpan GetStatusDuration(ConnectionStatus status)
        {
            TimeSpan timeSpan = StatusDurations[status];
            if (CurrentStatus == status)
            {
                timeSpan += DateTime.Now - StatusReachedAt;
            }
            return timeSpan;
        }

        public string OnlineStatusDuration
        {
            get { return DurationToString(GetStatusDuration(ConnectionStatus.Online)); }
        }

        public string OfflineStatusDuration
        {
            get { return DurationToString(GetStatusDuration(ConnectionStatus.Offline)); }
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

        public void PingSuccess(long RoundtripTime)
        {
            long time = RoundtripTime;
            SentPackets++;
            ReceivedPackets++;
            ConsecutivePacketsLost = 0;
            LastPacketLost = false;
            TotalResponseTime += time;
            CurrentResponseTime = time;
            if (time > MaxResponseTime)
            {
                MaxResponseTime = time;
            }
            if (time < MinResponseTime)
            {
                MinResponseTime = time;
            }
        }

        public void PingLost()
        {
            SentPackets++;
            LostPackets++;
            ConsecutivePacketsLost++;
            LastPacketLost = true;
        }
    }
}
