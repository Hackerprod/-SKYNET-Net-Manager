using SKYNET;

namespace SKYNET.NetUtils
{
    public interface IPingLogger
    {
        void LogStart(HostPinger host);

        void LogStop(HostPinger host);

        void LogStatusChange(ConnectionStatus host, ConnectionStatus oldStatus, ConnectionStatus newStatus);
    }
}