using SKYNET;

namespace SKYNET.NetUtils
{
    public delegate void OnPingDelegate(HostPinger host);
    public delegate void OnHostStatusChangeDelegate(HostPinger host, ConnectionStatus oldStatus, ConnectionStatus newStatus);
    public delegate void OnHostPingerCommandDelegate(HostPinger host);
    public delegate void OnHostNameChangedDelegate(HostPinger host);

}