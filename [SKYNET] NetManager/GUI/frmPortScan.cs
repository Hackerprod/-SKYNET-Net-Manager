using SKYNET.GUI;
using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class frmPortScan : frmBase
    {
        public static ManualResetEvent connectDone = new ManualResetEvent(false);
        private bool Cancel;
        private int Max;
        private int Min;

        public frmPortScan(IPAddress host, int InitPort = 20, int FinishPort = 150)
        {
            InitializeComponent();
            base.SetMouseMove(PN_Top);
            CheckForIllegalCrossThreadCalls = false;

            SBox.Text = InitPort.ToString();
            FBox.Text = FinishPort.ToString();
            RemoteHost.Text = host.ToString();
        }

        private void LaunchBtn_Click(object sender, EventArgs e)
        {
            bool portS = int.TryParse(SBox.Text, out int PortS);
            bool portF = int.TryParse(SBox.Text, out int PortF);

            if (!portS || !portF)
            {
                Common.Show("Asegúrace de que los puertos tienen formato correcto.");
                return;
            }
            if (PortS <= IPEndPoint.MinPort || PortS > 65534 || PortF > IPEndPoint.MaxPort || PortF < 2)
            {
                Common.Show("Los puertos a buscar deben encontrarse en el rango de 1 hasta 65535");
                return;
            }

            if (PortWorker.IsBusy)
            {
                Cancel = true;
                return;
            }
            txtInfo.Text = "";
            Info.Text = "Chequeando puertos... por favor espere.";
            progressBarCheck.Visible = true;

            PortWorker.RunWorkerAsync();
        }
        private static void ConnectCallback(IAsyncResult ar) // статистический метод с параметром ar, отображ-м инфу - дошел сигнал до порта или нет
        {
            try
            {
                Socket client = (Socket)ar.AsyncState; // создаем сокет client и заносим в него инфу - дошел сигнал до порта или нет
                client.EndConnect(ar); // завершаем посылку сигнала на сокет client
                connectDone.Set();  // отсылаем сигнал от порта обратно
            }
            catch
            {
            }
        }

        private void AddPort(int port)
        {
            txtInfo.Text += GetSpace(port.ToString()) + GetPortType(port) + Environment.NewLine + Environment.NewLine;

        }

        private string GetSpace(string port)
        {
            string response = port;
            for (int i = port.Length; i < 17; i++)
            {
                response += " "; 
            }
            return response;
        }

        private string GetPortType(int port)
        {
            switch (port)
            {
                case 0: return "Reserved(TCP/UDP - Official)";
                case 1: return "TCP Port Service Multiplexer(TCP/UDP - Official)";
                case 2: return "Management Utility(TCP/UDP - Official)";
                case 3: return "Compression Process(TCP/UDP - Official)";
                case 4: return "Unassigned(TCP/UDP - Official)";
                case 5: return "Remote Job Entry(TCP/UDP - Official)";
                case 6: return "Unassigned(TCP/UDP - Official)";
                case 7: return "Echo(TCP/UDP - Official)";
                case 8: return "Unassigned(TCP/UDP - Official)";
                case 9: return "Discard(TCP/UDP - Official)";
                case 11: return "Active Users(TCP/UDP - Official)";
                case 13: return "DAYTIME – (RFC 867)(TCP/UDP - Official)";
                case 17: return "Quote of the Day(TCP/UDP - Official)";
                case 18: return "Message Send Protocol(TCP/UDP - Official)";
                case 19: return "Character Generator(TCP/UDP - Official)";
                case 20: return "FTP – data(TCP - Official)";
                case 21: return "FTP – control (command)(TCP - Official)";
                case 22: return "Secure Shell (SSH)—used for secure logins, file transfers (scp, sftp)and port forwarding(TCP/UDP - Official)";
                case 23: return "Telnet protocol—unencrypted text communications(TCP - Official USAonly)";
                case 25: return "Simple Mail Transfer Protocol (SMTP)—used for e-mail routing betweenmail servers(TCP - Official)";
                case 26: return "Unknown Found while scanning website with Nmap. Looks to be SMTPrelated(TCP - Unofficial)";
                case 34: return "Remote File (RF)—used to transfer files between machines(TCP/UDP -Unofficial)";
                case 35: return "Any private printer server protocol(TCP/UDP - Official)";
                case 37: return "TIME protocol(TCP/UDP - Official)";
                case 39: return "Resource Location Protocol[2] (RLP)—used for determining the locationof higher level services from hosts on a network(TCP/UDP - Official)";
                case 41: return "Graphics(TCP/UDP - Official)";
                case 42: return "nameserver, ARPA Host Name Server Protocol(TCP/UDP - Official)";
                case 43: return "WHOIS protocol(TCP - Official)";
                case 47: return "GRE protocol(TCP - Official)";
                case 49: return "TACACS Login Host protocol(TCP/UDP - Official)";
                case 52: return "XNS (Xerox Network Systems) Time Protocol(TCP/UDP - Official)";
                case 53: return "Domain Name System (DNS)(TCP/UDP - Official)";
                case 54: return "XNS (Xerox Network Systems) Clearinghouse(TCP/UDP - Official)";
                case 55: return "ISI Graphics Language (ISI-GL)(TCP/UDP - Unofficial)";
                case 56: return "XNS (Xerox Network Systems) Authentication(TCP/UDP - Official)";
                case 57: return "Mail Transfer Protocol (MTP)(TCP - Unofficial)";
                case 58: return "XNS (Xerox Network Systems) Mail(TCP/UDP - Official)";
                case 67: return "Bootstrap Protocol (BOOTP) Server; also used by Dynamic HostConfiguration Protocol (DHCP)(UDP - Official)";
                case 68: return "Bootstrap Protocol (BOOTP) Client; also used by Dynamic HostConfiguration Protocol (DHCP)(UDP - Official)";
                case 69: return "Trivial File Transfer Protocol (TFTP)(UDP - Official)";
                case 70: return "Gopher protocol(TCP - Official)";
                case 79: return "Finger protocol(TCP - Official)";
                case 80: return "Hypertext Transfer Protocol (HTTP)(TCP/UDP - Official)";
                case 81: return "Torpark—Onion routing(TCP - Unofficial)";
                case 82: return "Torpark—Control(UDP - Unofficial)";
                case 83: return "MIT ML Device(TCP - Official)";
                case 88: return "Kerberos—authentication system(TCP/UDP - Official)";
                case 90: return "dnsix (DoD Network Security for Information Exchange) SecuritAttribute Token Map(TCP/UDP - Official)";
                case 99: return "WIP Message Protocol(TCP - Unofficial)";
                case 101: return "NIC host name(TCP - Official)";
                case 102: return "ISO-TSAP (Transport Service Access Point) Class 0 protocol[4](TCP -Official)";
                case 104: return "ACR/NEMA Digital Imaging and Communications in Medicine(TCP/UDP -Official)";
                case 105: return "CCSO Nameserver Protocol (Qi/Ph)(TCP/UDP - Official)";
                case 107: return "Remote TELNET Service[5] protocol(TCP - Official)";
                case 108: return "SNA Gateway Access Server [6](TCP/UDP - Official)";
                case 109: return "Post Office Protocol 2 (POP2)(TCP - Official)";
                case 110: return "Post Office Protocol 3 (POP3)(TCP - Official)";
                case 111: return "ONC RPC (SunRPC)(TCP/UDP - Official)";
                case 113: return "ident—user identification system, used by IRC servers to identify users(TCP - Official)";
                case 115: return "Simple File Transfer Protocol (SFTP)(TCP - Official)";
                case 117: return "UUCP Path Service(TCP - Official)";
                case 118: return "SQL (Structured Query Language) Services(TCP/UDP - Official)";
                case 119: return "Network News Transfer Protocol (NNTP)—used for retrieving newsgroup messages(TCP - Official)";
                case 123: return "Network Time Protocol (NTP)—used for time synchronization(UDP - Official)";
                case 135: return "DCE endpoint resolution(TCP/UDP - Official)";
                case 137: return "NetBIOS NetBIOS Name Service(TCP/UDP - Official)";
                case 138: return "NetBIOS NetBIOS Datagram Service(TCP/UDP - Official)";
                case 139: return "NetBIOS NetBIOS Session Service(TCP/UDP - Official)";
                case 143: return "Internet Message Access Protocol (IMAP)—used for retrieving,organizing, and synchronizing e-mail messages(TCP/UDP - Official)";
                case 152: return "Background File Transfer Program (BFTP)[8](TCP/UDP - Official)";
                case 153: return "SGMP, Simple Gateway Monitoring Protocol(TCP/UDP - Official)";
                case 156: return "SQL Service(TCP/UDP - Official)";
                case 158: return "DMSP, Distributed Mail Service Protocol(TCP/UDP - Unofficial)";
                case 161: return "Simple Network Management Protocol (SNMP)(UDP - Official)";
                case 162: return "Simple Network Management Protocol Trap (SNMPTRAP)[9](TCP/UDP -Official)";
                case 170: return "Print-srv, Network PostScript(TCP - Official)";
                case 177: return "X Display Manager Control Protocol (XDMCP)(TCP/UDP - Official)";
                case 179: return "BGP (Border Gateway Protocol)(TCP - Official)";
                case 194: return "IRC (Internet Relay Chat)(TCP/UDP - Official)";
                case 199: return "SMUX, SNMP Unix Multiplexer(TCP/UDP - Official)";
                case 201: return "AppleTalk Routing Maintenance(TCP/UDP - Official)";
                case 209: return "The Quick Mail Transfer Protocol(TCP/UDP - Official)";
                case 210: return "ANSI Z39.50: return \"(TCP / UDP - Official)";
                case 213: return "Internetwork Packet Exchange (IPX)(TCP/UDP - Official)";
                case 218: return "Message posting protocol (MPP)(TCP/UDP - Official)";
                case 220: return "Internet Message Access Protocol (IMAP), version 3: return \"(TCP / UDP - Official)";
                case 256: return "2DEV \"2SP\" Port(TCP/UDP - Unofficial)";
                case 259: return "ESRO, Efficient Short Remote Operations(TCP/UDP - Official)";
                case 264: return "BGMP, Border Gateway Multicast Protocol(TCP/UDP - Official)";
                case 308: return "Novastor Online Backup(TCP - Official)";
                case 311: return "Mac OS X Server Admin (officially AppleShare IP Web administration) (TCP - Official)";
                case 318: return "PKIX TSP, Time Stamp Protocol(TCP/UDP - Official)";
                case 323: return "IMMP, Internet Message Mapping Protocol(TCP/UDP - Unofficial)";
                case 350: return "MATIP-Type A, Mapping of Airline Traffic over Internet Protocol (TCP/UDP - Official)";
                case 351: return "MATIP-Type B, Mapping of Airline Traffic over Internet Protocol (TCP/UDP - Official)";
                case 366: return "ODMR, On-Demand Mail Relay(TCP/UDP - Official)";
                case 369: return "Rpc2portmap(TCP/UDP - Official)";
                case 370: return "codaauth2 – Coda authentication server(TCP/UDP - Unofficial)";
                case 371: return "ClearCase albd(TCP/UDP - Official)";
                case 383: return "HP data alarm manager(TCP/UDP - Official)";
                case 384: return "A Remote Network Server System(TCP/UDP - Official)";
                case 387: return "AURP, AppleTalk Update-based Routing Protocol(TCP/UDP - Official)";
                case 389: return "Lightweight Directory Access Protocol (LDAP)(TCP/UDP - Official)";
                case 401: return "UPS Uninterruptible Power Supply(TCP/UDP - Official)";
                case 402: return "Altiris, Altiris Deployment Client(TCP - Unofficial)";
                case 411: return "Direct Connect Hub(TCP - Unofficial)";
                case 412: return "Direct Connect Client-to-Client(TCP - Unofficial)";
                case 427: return "Service Location Protocol (SLP)(TCP/UDP - Official)";
                case 443: return "HTTPS (Hypertext Transfer Protocol over SSL/TLS)(TCP - Official)";
                case 444: return "SNPP, Simple Network Paging Protocol (RFC 1568)(TCP/UDP - Official)";
                case 445: return "Microsoft-DS Active Directory, Windows shares(TCP - Official)";
                case 464: return "Kerberos Change/Set password(TCP/UDP - Official)";
                case 465: return "Cisco protocol(TCP - Unofficial)";
                case 475: return "tcpnethaspsrv (Aladdin Knowledge Systems Hasp services, TCP/IPversion)(TCP - Official)";
                case 497: return "Dantz Retrospect(TCP - Official)";
                case 500: return "Internet Security Association and Key Management Protocol (ISAKMP) (UDP - Official)";
                case 501: return "STMF, Simple Transportation Management Framework – DOT NTCIP 1101 (TCP - Unofficial)";
                case 502: return "Modbus, Protocol(TCP/UDP - Unofficial)";
                case 504: return "Citadel – multiservice protocol for dedicated clients for the Citadelgroupware system(TCP/UDP - Official)";
                case 510: return "First Class Protocol(TCP - Unofficial)";
                case 512: return "Rexec, Remote Process Execution(TCP - Official)";
                case 513: return "rlogin(TCP - Official)";
                case 514: return "Shell—used to execute non-interactive commands on a remote system (TCP - Official)";
                case 515: return "Line Printer Daemon—print service(TCP - Official)";
                case 517: return "Talk(UDP - Official)";
                case 518: return "NTalk(UDP - Official)";
                case 520: return "efs, extended file name server(TCP - Official)";
                case 524: return "NetWare Core Protocol (NCP) is used for a variety things such asaccess to primary NetWare server resources, Time Synchronization, etc.(TCP/UDP - Official)";
                case 525: return "Timed, Timeserver(UDP - Official)";
                case 530: return "RPC(TCP/UDP - Official)";
                case 531: return "AOL Instant Messenger, IRC(TCP/UDP - Unofficial)";
                case 532: return "netnews(TCP - Official)";
                case 533: return "netwall, For Emergency Broadcasts(UDP - Official)";
                case 540: return "UUCP (Unix-to-Unix Copy Protocol)(TCP - Official)";
                case 542: return "commerce (Commerce Applications)(TCP/UDP - Official)";
                case 543: return "klogin, Kerberos login(TCP - Official)";
                case 544: return "kshell, Kerberos Remote shell(TCP - Official)";
                case 545: return "OSIsoft PI (VMS), OSISoft PI Server Client Access(TCP - Unofficial)";
                case 546: return "DHCPv6 client(TCP/UDP - Official)";
                case 547: return "DHCPv6 server(TCP/UDP - Official)";
                case 548: return "Apple Filing Protocol (AFP) over TCP(TCP - Official)";
                case 550: return "new-rwho, new-who(UDP - Official)";
                case 554: return "Real Time Streaming Protocol (RTSP)(TCP/UDP - Official)";
                case 556: return "Remotefs, RFS, rfs_server(TCP - Official)";
                case 560: return "rmonitor, Remote Monitor(UDP - Official)";
                case 561: return "monitor(UDP - Official)";
                case 563: return "NNTP protocol over TLS/SSL (NNTPS)(TCP/UDP - Official)";
                case 587: return "e-mail message submission[10] (SMTP)(TCP - Official)";
                case 591: return "FileMaker 6.0 (and later) Web Sharing (HTTP Alternate, also see port 80 (TCP - Official)";
                case 593: return "HTTP RPC Ep Map, Remote procedure call over Hypertext TransferProtocol, often used by Distributed Component Object Model servicesand Microsoft Exchange Server(TCP/UDP - Official)";
                case 604: return "TUNNEL profile[11], a protocol for BEEP peers to form an applicationlayer tunnel(TCP - Official)";
                case 623: return "ASF Remote Management and Control Protocol (ASF-RMCP)(UDP -Official)";
                case 631: return "Internet Printing Protocol (IPP)(TCP/UDP - Official)";
                case 636: return "Lightweight Directory Access Protocol over TLS/SSL (LDAPS)(TCP/UDP -Official)";
                case 639: return "MSDP, Multicast Source Discovery Protocol(TCP/UDP - Official)";
                case 641: return "SupportSoft Nexus Remote Command (control/listening): A proxy gatewayconnecting remote control traffic(TCP/UDP - Official)";
                case 646: return "LDP, Label Distribution Protocol, a routing protocol used in MPLSnetworks(TCP/UDP - Official)";
                case 647: return "DHCP Failover protocol[12](TCP - Official)";
                case 648: return "RRP (Registry Registrar Protocol)[13](TCP - Official)";
                case 652: return "DTCP, Dynamic Tunnel Configuration Protocol(TCP - Unofficial)";
                case 653: return "SupportSoft Nexus Remote Command (data): A proxy gateway connectingremote control traffic(TCP/UDP - Official)";
                case 654: return "Media Management System (MMS) Media Management Protocol (MMP)[14] (TCP - Official)";
                case 657: return "IBM RMC (Remote monitoring and Control) protocol, used by System p5AIX Integrated Virtualization Manager (IVM)[15] and HardwareManagement Console to connect managed logical partitions (LPAR) toenable dynamic partition reconfiguration(TCP/UDP - Official)";
                case 660: return "Mac OS X Server administration(TCP - Official)";
                case 665: return "sun-dr, Remote Dynamic Reconfiguration(TCP - Unofficial)";
                case 666: return "Doom, first online first-person shooter(UDP - Official)";
                case 674: return "ACAP (Application Configuration Access Protocol)(TCP - Official)";
                case 691: return "MS Exchange Routing(TCP - Official)";
                case 692: return "Hyperwave-ISP(TCP - Official)";
                case 694: return "Linux-HA High availability Heartbeat(TCP/UDP - Official)";
                case 695: return "IEEE-MMS-SSL (IEEE Media Management System over SSL)[16](TCP -Official)";
                case 698: return "OLSR (Optimized Link State Routing)(UDP - Official)";
                case 699: return "Access Network(TCP - Official)";
                case 700: return "EPP (Extensible Provisioning Protocol), a protocol for communicationbetween domain name registries and registrars (RFC 5734)(TCP -Official)";
                case 701: return "LMP (Link Management Protocol (Internet))[17], a protocol that runsbetween a pair of nodes and is used to manage traffic engineering (TE)links(TCP - Official)";
                case 702: return "IRIS[18][19] (Internet Registry Information Service) over BEEP (BlocksExtensible Exchange Protocol)[20] (RFC 3983)(TCP - Official)";
                case 706: return "Secure Internet Live Conferencing (SILC)(TCP - Official)";
                case 711: return "Cisco Tag Distribution Protocol[21][22][23]—being replaced by the MPLSLabel Distribution Protocol[24](TCP - Official)";
                case 712: return "Topology Broadcast based on Reverse-Path Forwarding routing protocol(TBRPF) (RFC 3684)(TCP - Official)";
                case 720: return "SMQP, Simple Message Queue Protocol(TCP - Unofficial)";
                case 749: return "Kerberos (protocol) administration(TCP/UDP - Official)";
                case 750: return "kerberos-iv, Kerberos version IV(UDP - Official)";
                case 751: return "pump(TCP/UDP - Official)";
                case 752: return "qrh(TCP/UDP - Official)";
                case 753: return "Reverse Routing Header (rrh)[25](TCP - Official)";
                case 754: return "tell send(TCP - Official)";
                case 760: return "ns(TCP/UDP - Official)";
                case 782: return "Conserver serial-console management server(TCP - Unofficial)";
                case 783: return "SpamAssassin spamd daemon(TCP - Unofficial)";
                case 829: return "CMP (Certificate Management Protocol)(TCP - Unofficial)";
                case 843: return "Adobe Flash socket policy server(TCP - Unofficial)";
                case 860: return "iSCSI (RFC 3720)(TCP - Official)";
                case 873: return "rsync file synchronisation protocol(TCP - Official USA only)";
                case 888: return "cddbp, CD DataBase (CDDB) protocol (CDDBP)—unassigned but widespreaduse(TCP - Unofficial)";
                case 901: return "Samba Web Administration Tool (SWAT)(TCP - Unofficial)";
                case 902: return "ideafarm-door 902/tcp self documenting Door: send 0x00 for info(TCP- Official)";
                case 903: return "VMware Remote Console [26](TCP - Unofficial)";
                case 904: return "VMware Server Alternate (if 902 is in use, i.e. SUSE linux)(TCP -Unofficial)";
                case 911: return "Network Console on Acid (NCA)—local tty redirection over OpenSSH(TCP- Unofficial)";
                case 953: return "Domain Name System (DNS) RNDC Service(TCP/UDP - Unofficial)";
                case 981: return "SofaWare Technologies Remote HTTPS management for firewall devicesrunning embedded Check Point FireWall-1 software(TCP - Unofficial)";
                case 989: return "FTPS Protocol (data): FTP over TLS/SSL(TCP/UDP - Official)";
                case 990: return "FTPS Protocol (control): FTP over TLS/SSL(TCP/UDP - Official)";
                case 991: return "NAS (Netnews Administration System)(TCP/UDP - Official)";
                case 992: return "TELNET protocol over TLS/SSL(TCP/UDP - Official)";
                case 993: return "Internet Message Access Protocol over SSL (IMAPS)(TCP - Official)";
                case 995: return "Post Office Protocol 3 over TLS/SSL (POP3S)(TCP - Official)";
                case 999: return "ScimoreDB Database System(TCP - Unofficial)";
                case 1001: return "JtoMB(TCP - Unofficial)";
                case 1002: return "Opsware agent (aka cogbot)(TCP - Unofficial)";
                case 1023: return "Reserved[1](TCP/UDP - Official)";
                case 1024: return "Reserved[1](TCP/UDP - Official)";
                case 1025: return "NFS-or-IIS(TCP - Unofficial)";
                case 1026: return "Often utilized by Microsoft DCOM services(TCP - Unofficial)";
                case 1029: return "Often utilized by Microsoft DCOM services(TCP - Unofficial)";
                case 1058: return "nim, IBM AIX Network Installation Manager (NIM)(TCP/UDP - Official)";
                case 1059: return "nimreg, IBM AIX Network Installation Manager (NIM)(TCP/UDP -Official)";
                case 1080: return "SOCKS proxy(TCP - Official)";
                case 1085: return "WebObjects(TCP/UDP - Official)";
                case 1098: return "rmiactivation, RMI Activation(TCP/UDP - Official)";
                case 1099: return "rmiregistry, RMI Registry(TCP/UDP - Official)";
                case 1109: return "Reserved[1](TCP/UDP - Official)";
                case 1111: return "EasyBits School network discovery protocol (for Intel's CMPC platform)(UDP - Unofficial)";
                case 1140: return "AutoNOC protocol(TCP/UDP - Official)";
                case 1167: return "phone, conference calling(UDP - Unofficial)";
                case 1169: return "Tripwire(TCP/UDP - Official)";
                case 1176: return "Perceptive Automation Indigo Home automation server(TCP - Official)";
                case 1182: return "AcceleNet Intelligent Transfer Protocol(TCP/UDP - Official)";
                case 1194: return "OpenVPN(TCP/UDP - Official)";
                case 1198: return "The cajo project Free dynamic transparent distributed computing inJava(TCP/UDP - Official)";
                case 1200: return "scol, protocol used by SCOL 3D virtual worlds server to answer worldname resolution client request[27](TCP - Official)";
                case 1214: return "Kazaa(TCP - Official)";
                case 1217: return "Uvora Online(TCP - Unofficial)";
                case 1220: return "QuickTime Streaming Server administration(TCP - Official)";
                case 1223: return "TGP, TrulyGlobal Protocol, also known as \"The Gur Protocol\" (named forGur Kimchi of TrulyGlobal)(TCP/UDP - Official)";
                case 1234: return "VLC media player Default port for UDP/RTP stream(UDP - Unofficial)";
                case 1236: return "Symantec BindView Control UNIX Default port for TCP management serverconnections(TCP - Unofficial)";
                case 1241: return "Nessus Security Scanner(TCP/UDP - Official)";
                case 1248: return "NSClient/NSClient++/NC_Net (Nagios)(TCP - Unofficial)";
                case 1270: return "Microsoft System Center Operations Manager (SCOM) (formerly MicrosoftOperations Manager (MOM)) agent(TCP/UDP - Official)";
                case 1293: return "IPSec (Internet Protocol Security)(TCP/UDP - Official)";
                case 1311: return "Dell Open Manage HTTPS(TCP - Unofficial)";
                case 1313: return "Xbiim (Canvii server)(TCP - Unofficial)";
                case 1337: return "Men and Mice DNS(TCP/UDP - Official)";
                case 1352: return "IBM Lotus Notes/Domino Remote Procedure Call (RPC) protocol(TCP -Official)";
                case 1387: return "cadsi-lm, LMS International (formerly Computer Aided Design Software,Inc. (CADSI)) LM(TCP/UDP - Official)";
                case 1414: return "IBM WebSphere MQ (formerly known as MQSeries)(TCP - Official)";
                case 1417: return "Timbuktu Service 1 Port(TCP/UDP - Official)";
                case 1418: return "Timbuktu Service 2 Port(TCP/UDP - Official)";
                case 1419: return "Timbuktu Service 3 Port(TCP/UDP - Official)";
                case 1420: return "Timbuktu Service 4 Port(TCP/UDP - Official)";
                case 1431: return "Reverse Gossip Transport Protocol (RGTP), used to access aGeneral-purpose Reverse-Ordered Gossip Gathering System (GROGGS)bulletin board, such as that implemented on the Cambridge University'sPhoenix system(TCP - Official)";
                case 1433: return "MSSQL (Microsoft SQL Server database management system) Server(TCP -Official)";
                case 1434: return "MSSQL (Microsoft SQL Server database management system) Monitor(UDP- Official)";
                case 1470: return "Solarwinds Kiwi Log Server(TCP - Official)";
                case 1494: return "Citrix XenApp Independent Computing Architecture (ICA) thin clientprotocol(TCP - Official)";
                case 1500: return "NetGuard GuardianPro firewall (NT4-based) Remote Management(TCP -Unofficial)";
                case 1501: return "NetGuard GuardianPro firewall (NT4-based) Authentication Client(UDP- Unofficial)";
                case 1503: return "Windows Live Messenger (Whiteboard and Application Sharing)(TCP/UDP- Unofficial)";
                case 1512: return "Microsoft Windows Internet Name Service (WINS)(TCP/UDP - Official)";
                case 1513: return "Garena Garena Gaming Client(TCP/UDP - Official)";
                case 1521: return "nCube License Manager(TCP - Official)";
                case 2483: return "(TCP - Unofficial)";
                case 1524: return "ingreslock, ingres(TCP/UDP - Official)";
                case 1526: return "Oracle database common alternative for listener(TCP - Unofficial)";
                case 1533: return "IBM Sametime IM—Virtual Places Chat Microsoft SQL Server(TCP -Official)";
                case 1547: return "Laplink(TCP/UDP - Official)";
                case 1550: return "Gadu-Gadu (direct client-to-client)(Unofficial)";
                case 1581: return "MIL STD 2045-47001 VMF(UDP - Official)";
                case 1589: return "Cisco VQP (VLAN Query Protocol) / VMPS(UDP - Unofficial)";
                case 1645: return "radius/radacct, RADIUS authentication protocol (default for Cisco andJuniper Networks RADIUS servers)(TCP/UDP - Unofficial)";
                case 1627: return "iSketch(Unofficial)";
                case 1677: return "Novell GroupWise clients in client/server access mode(TCP/UDP -Official)";
                case 1701: return "Layer 2 Forwarding Protocol (L2F) & Layer 2 Tunneling Protocol (L2TP) (UDP - Official)";
                case 1716: return "America's Army Massively multiplayer online game (MMO)(TCP -Unofficial)";
                case 1719: return "H.323 Registration and alternate communication(UDP - Official)";
                case 1720: return "H.323 Call signalling(TCP - Official)";
                case 1723: return "Microsoft Point-to-Point Tunneling Protocol (PPTP)(TCP/UDP -Official)";
                case 1725: return "Valve Steam Client(UDP - Unofficial)";
                case 1755: return "Microsoft Media Services (MMS, ms-streaming)(TCP/UDP - Official)";
                case 1761: return "cft-0: return \"(TCP / UDP - Official)";
                case 1762: return "cft-1 to cft-7: return \"(TCP / UDP - Official)";
                case 1801: return "Microsoft Message Queuing(TCP/UDP - Official)";
                case 1812: return "radius, RADIUS authentication protocol(TCP/UDP - Official)";
                case 1813: return "radacct, RADIUS accounting protocol(TCP/UDP - Official)";
                case 1863: return "MSNP (Microsoft Notification Protocol), used by the .NET MessengerService and a number of Instant Messaging clients(TCP - Official)";
                case 1900: return "Microsoft SSDP Enables discovery of UPnP devices(UDP - Official)";
                case 1920: return "IBM Tivoli Monitoring Console (https)(TCP - Unofficial)";
                case 1935: return "Adobe Systems Macromedia Flash Real Time Messaging Protocol (RTMP)\"plain\" protocol(TCP - Official)";
                case 1947: return "hasplm, Aladdin HASP Licenz Manager(TCP - Official)";
                case 1967: return "Cisco IOS IP Service Level Agreements (IP SLAs) Control Protocol(UDP- Unofficial)";
                case 1970: return "Danware NetOp Remote Control(TCP/UDP - Official)";
                case 1971: return "Danware NetOp School(TCP/UDP - Official)";
                case 1972: return "InterSystems Caché(TCP/UDP - Official)";
                case 1975: return "Cisco TCO (Documentation)(UDP - Official)";
                case 1984: return "Big Brother System and Network Monitor(TCP - Official)";
                case 1985: return "Cisco HSRP(UDP - Official)";
                case 1994: return "Cisco STUN-SDLC (Serial Tunneling—Synchronous Data Link Control)protocol(TCP/UDP - Official)";
                case 1997: return "Chizmo Networks Transfer Tool(TCP - Unofficial)";
                case 1998: return "Cisco X.25 over TCP (XOT) service(TCP/UDP - Official)";
                case 2000: return "Cisco SCCP (Skinny)(TCP/UDP - Official)";
                case 2001: return "CAPTAN Test Stand System(UDP - Unofficial)";
                case 2002: return "Secure Access Control Server (ACS) for Windows(TCP - Unofficial)";
                case 2030: return "Oracle Services for Microsoft Transaction Server(Unofficial)";
                case 2031: return "mobrien-chat—obsolete (ex-http://www.mobrien.com)(TCP/UDP -Official)";
                case 2041: return "Mail.Ru Agent communication protocol(TCP - Unofficial)";
                case 2049: return "Network File System(UDP - Official)";
                case 2053: return "lot105-ds-upd Lot105 DSuper Updates(TCP/UDP - Official)";
                case 2056: return "Civilization 4 multiplayer(UDP - Unofficial)";
                case 2073: return "DataReel Database(TCP/UDP - Official)";
                case 2074: return "Vertel VMF SA (i.e. App.. SpeakFreely)(TCP/UDP - Official)";
                case 2082: return "Infowave Mobility Server(TCP - Official)";
                case 2083: return "Secure Radius Service (radsec)(TCP - Official)";
                case 2086: return "GNUnet(TCP - Official)";
                case 2087: return "WebHost Manager default SSL(TCP - Unofficial)";
                case 2095: return "CPanel default Web mail(TCP - Unofficial)";
                case 2096: return "CPanel default SSL Web mail(TCP - Unofficial)";
                case 2102: return "zephyr-srv Project Athena Zephyr Notification Service server(TCP/UDP- Official)";
                case 2103: return "zephyr-clt Project Athena Zephyr Notification Service serv-hmconnection(TCP/UDP - Official)";
                case 2104: return "zephyr-hm Project Athena Zephyr Notification Service hostmanager (TCP/UDP - Official)";
                case 2105: return "IBM MiniPay(TCP/UDP - Official)";
                case 2144: return "Iron Mountain LiveVault Agent(TCP - UnOfficial)";
                case 2161: return "APC Agent(TCP - Official)";
                case 2181: return "EForward-document transport system(TCP/UDP - Official)";
                case 2190: return "TiVoConnect Beacon(UDP - Unofficial)";
                case 2200: return "Tuxanci game server[28](UDP - Unofficial)";
                case 2210: return "NOAAPORT Broadcast Network(TCP/UDP - Official)";
                case 2211: return "EMWIN(TCP/UDP - Official)";
                case 2212: return "LeeCO POS Server Service(TCP/UDP - Official)";
                case 2219: return "NetIQ NCAP Protocol(TCP/UDP - Official)";
                case 2220: return "NetIQ End2End(TCP/UDP - Official)";
                case 2221: return "ESET Anti-virus updates(TCP - Unofficial)";
                case 2222: return "DirectAdmin default & ESET Remote Administration(TCP - Unofficial)";
                case 2261: return "CoMotion Master(TCP/UDP - Official)";
                case 2262: return "CoMotion Backup(TCP/UDP - Official)";
                case 2223: return "Microsoft Office OS X antipiracy network monitor(UDP - Unofficial)";
                case 2301: return "HP System Management Redirect to port 2381 (TCP - Unofficial)";
                case 2302: return "ArmA multiplayer (default for game)(UDP - Unofficial)";
                case 2303: return "ArmA multiplayer (default for server reporting) (default port for game+1)(UDP - Unofficial)";
                case 2305: return "ArmA multiplayer (default for VoN) (default port for game +3)(UDP -Unofficial)";
                case 2369: return "Default for BMC Software Control-M/Server—Configuration Agent, thoughoften changed during installation(TCP - Official)";
                case 2370: return "Default for BMC Software Control-M/Server—to allow theControl-M/Enterprise Manager to connect to the Control-M/Server,though often changed during installation(TCP - Official)";
                case 2381: return "HP Insight Manager default for Web server(TCP - Unofficial)";
                case 2401: return "CVS version control system(TCP - Unofficial)";
                case 2404: return "IEC 60870-5-104, used to send electric power telecontrol messagesbetween two systems via directly connected data circuits(TCP -Official)";
                case 2420: return "Westell Remote Access(UDP - Official)";
                case 2427: return "Cisco MGCP(UDP - Official)";
                case 2447: return "ovwdb—OpenView Network Node Manager (NNM) daemon(TCP/UDP - Official)";
                case 2484: return "Oracle database listening for SSL client connections to the listener (TCP/UDP - Official)";
                case 2500: return "THEÒSMESSENGER listening for TheòsMessenger client connections(TCP -Official)";
                case 2546: return "EVault—Data Protection Services(TCP/UDP - Unofficial)";
                case 2593: return "RunUO—Ultima Online server(TCP/UDP - Unofficial)";
                case 2598: return "new ICA—when Session Reliability is enabled, TCP port 2598 replacesport 1494 (TCP - Unofficial)";
                case 2610: return "Dark Ages(TCP - Unofficial)";
                case 2612: return "QPasa from MQSoftware(TCP/UDP - Official)";
                case 2638: return "Sybase database listener(TCP - Unofficial)";
                case 2700: return "KnowShowGo P2P(TCP - Official)";
                case 2710: return "XBT Bittorrent Tracker(TCP - Unofficial)";
                case 2713: return "Raven Trinity Broker Service(TCP/UDP - Official)";
                case 2714: return "Raven Trinity Data Mover(TCP/UDP - Official)";
                case 2735: return "NetIQ Monitor Console(TCP/UDP - Official)";
                case 2809: return "corbaloc:iiop URL, per the CORBA 3.0.3 specification(TCP - Official)";
                case 2868: return "Norman Proprietary Event Protocol NPEP(TCP/UDP - Official)";
                case 2944: return "Megaco Text H.248 (UDP - Unofficial)";
                case 2945: return "Megaco Binary (ASN.1) H.248 (UDP - Unofficial)";
                case 2947: return "gpsd GPS daemon(TCP - Official)";
                case 2948: return "WAP-push Multimedia Messaging Service (MMS)(TCP/UDP - Official)";
                case 2949: return "WAP-pushsecure Multimedia Messaging Service (MMS)(TCP/UDP -Official)";
                case 2967: return "Symantec AntiVirus Corporate Edition(TCP - Unofficial)";
                case 3000: return "Miralix License server(TCP - Unofficial)";
                case 3001: return "Miralix Phone Monitor(TCP - Unofficial)";
                case 3002: return "Miralix CSTA(TCP - Unofficial)";
                case 3003: return "Miralix GreenBox API(TCP - Unofficial)";
                case 3004: return "Miralix InfoLink(TCP - Unofficial)";
                case 3005: return "Miralix TimeOut(TCP - Unofficial)";
                case 3006: return "Miralix SMS Client Connector(TCP - Unofficial)";
                case 3007: return "Miralix OM Server(TCP - Unofficial)";
                case 3017: return "Miralix IVR and Voicemail(TCP - Unofficial)";
                case 3025: return "netpd.org(TCP - Unofficial)";
                case 3030: return "NetPanzer(TCP/UDP - Unofficial)";
                case 3050: return "gds_db (Interbase/Firebird)(TCP/UDP - Official)";
                case 3051: return "Galaxy Server (Gateway Ticketing Systems)(TCP/UDP - Official)";
                case 3074: return "Xbox LIVE and/or Games for Windows - LIVE(TCP/UDP - Official)";
                case 3100: return "HTTP used by Tatsoft as the default listen port(TCP - Unofficial)";
                case 3101: return "Blackberry Enterprise Server communcation to cloud(TCP - Unofficial)";
                case 3128: return "HTTP used by Web caches and the default for the Squid cache(TCP -Unofficial)";
                case 3225: return "FCIP (Fiber Channel over Internet Protocol)(TCP/UDP - Official)";
                case 3233: return "WhiskerControl research control protocol(TCP/UDP - Official)";
                case 3235: return "Galaxy Network Service (Gateway Ticketing Systems)(TCP/UDP -Official)";
                case 3260: return "iSCSI target(TCP - Official)";
                case 3268: return "msft-gc, Microsoft Global Catalog (LDAP service which contains datafrom Active Directory forests)(TCP/UDP - Official)";
                case 3269: return "msft-gc-ssl, Microsoft Global Catalog over SSL (similar to port 3268,LDAP over SSL)(TCP/UDP - Official)";
                case 3283: return "Apple Remote Desktop reporting (officially Net Assistant, referring toan earlier product)(TCP - Official)";
                case 3299: return "SAP-Router (routing application proxy for SAP R/3)(TCP - Unofficial)";
                case 3300: return "Debate Gopher backend database system(TCP/UDP - Unofficial)";
                case 3305: return "odette-ftp, Odette File Transfer Protocol (OFTP)(TCP/UDP - Official)";
                case 3306: return "MySQL database system(TCP/UDP - Official)";
                case 3333: return "Network Caller ID server(TCP - Unofficial)";
                case 3386: return "GTP' 3GPP GSM/UMTS CDR logging protocol(TCP/UDP - Official)";
                case 3389: return "Microsoft Terminal Server (RDP) officially registered as Windows BasedTerminal (WBT) - Link(TCP/UDP - Official)";
                case 3396: return "Novell NDPS Printer Agent(TCP/UDP - Official)";
                case 3455: return "[RSVP] Reservation Protocol(TCP/UDP - Official)";
                case 3423: return "Xware xTrm Communication Protocol(TCP - Official)";
                case 3424: return "Xware xTrm Communication Protocol over SSL(TCP - Official)";
                case 3478: return "STUN, a protocol for NAT traversal(TCP/UDP - Official)";
                case 3483: return "Slim Devices discovery protocol(UDP - Official)";
                case 3516: return "Smartcard Port(TCP/UDP - Official)";
                case 3527: return "Microsoft Message Queuing(UDP - Official)";
                case 3532: return "Raven Remote Management Control(TCP/UDP - Official)";
                case 3533: return "Raven Remote Management Data(TCP/UDP - Official)";
                case 3537: return "ni-visa-remote(TCP/UDP - Unofficial)";
                case 3544: return "Teredo tunneling(UDP - Official)";
                case 3605: return "ComCam IO Port(UDP - Official)";
                case 3606: return "Splitlock Server(TCP/UDP - Official)";
                case 3632: return "distributed compiler(TCP - Official)";
                case 3689: return "Digital Audio Access Protocol (DAAP)—used by Apple’s iTunes andAirPort Express(TCP - Official)";
                case 3690: return "Subversion version control system(TCP/UDP - Official)";
                case 3702: return "Web Services Dynamic Discovery (WS-Discovery), used by variouscomponents of Windows Vista(TCP/UDP - Official)";
                case 3723: return "Used by many Battle.net Blizzard games (Diablo II, Warcraft II,Warcraft III, StarCraft)(TCP/UDP - Unofficial)";
                case 3724: return "World of Warcraft Online gaming MMORPG(TCP/UDP - Unofficial)";
                case 3784: return "Ventrilo VoIP program used by Ventrilo(TCP/UDP - Unofficial)";
                case 3800: return "Used by HGG programs(TCP - Unofficial)";
                case 3880: return "IGRS(TCP/UDP - Unknown)";
                case 3868: return "Diameter base protocol (RFC 3588)(TCP/SCTP - Official)";
                case 3872: return "Oracle Management Remote Agent(TCP - Unofficial)";
                case 3899: return "Remote Administrator(TCP - Unofficial)";
                case 3900: return "udt_os, IBM UniData UDT OS[29](TCP - Official)";
                case 3945: return "EMCADS service, a Giritech product used by G/On(TCP/UDP - Official)";
                case 3978: return "OpenTTD game serverlist masterserver(UDP - Unofficial)";
                case 3979: return "OpenTTD game(TCP/UDP - Unofficial)";
                case 3999: return "Norman distributed scanning service(TCP/UDP - Official)";
                case 4000: return "Diablo II game(TCP/UDP - Unofficial)";
                case 4001: return "Microsoft Ants game(TCP - Unofficial)";
                case 4007: return "PrintBuzzer printer monitoring socket server(TCP - Unofficial)";
                case 4018: return "protocol information and warnings(TCP/UDP - Official)";
                case 4069: return "Minger Email Address Verification Protocol[30](UDP - Official)";
                case 4089: return "OpenCORE Remote Control Service(TCP/UDP - Official)";
                case 4093: return "PxPlus Client server interface ProvideX(TCP/UDP - Official)";
                case 4096: return "Ascom Timeplex BRE (Bridge Relay Element)(TCP/UDP - Official)";
                case 4100: return "WatchGuard Authentication Applet—default(Unofficial)";
                case 4111: return "Xgrid(TCP - Official)";
                case 4116: return "Smartcard-TLS(TCP/UDP - Official)";
                case 4125: return "Microsoft Remote Web Workplace administration(TCP - Unofficial)";
                case 4201: return "TinyMUD and various derivatives(TCP - Unofficial)";
                case 4226: return "Aleph One (game)(TCP/UDP - Unofficial)";
                case 4224: return "Cisco Audio Session Tunneling(TCP - Unofficial)";
                case 4321: return "Referral Whois (RWhois) Protocol[31](TCP - Official)";
                case 4323: return "Lincoln Electric's ArcLink/XT(UDP - Unofficial)";
                case 4500: return "IPSec NAT Traversal (RFC 3947)(UDP - Official)";
                case 4534: return "Armagetron Advanced default server port(UDP - Unofficial)";
                case 4569: return "Inter-Asterisk eXchange(UDP - Official)";
                case 4610: return "QualiSystems TestShell Suite Services(TCP - Unofficial)";
                case 4662: return "OrbitNet Message Service(TCP/UDP - Official)";
                case 4664: return "Google Desktop Search(TCP - Unofficial)";
                case 4672: return "eMule—often used(UDP - Unofficial)";
                case 4747: return "Apprentice(TCP - Unofficial)";
                case 4750: return "BladeLogic Agent(TCP - Unofficial)";
                case 4840: return "OPC UA TCP Protocol for OPC Unified Architecture from OPC Foundation (TCP/UDP - Official)";
                case 4843: return "OPC UA TCP Protocol over TLS/SSL for OPC Unified Architecture from OPCFoundation(TCP/UDP - Official)";
                case 4847: return "Web Fresh Communication, Quadrion Software & Odorless Entertainment (TCP/UDP - Official)";
                case 4993: return "Home FTP Server web Interface Default Port(TCP/UDP - ???)";
                case 4894: return "LysKOM Protocol A(TCP/UDP - Official)";
                case 4899: return "Radmin remote administration tool (program sometimes used by a Trojanhorse)(TCP/UDP - Official)";
                case 4982: return "Solar Data Log (JK client app for PV solar inverters )(TCP/UDP -Unofficial)";
                case 5000: return "commplex-main(TCP - Official)";
                case 5001: return "commplex-link(TCP - Official)";
                case 5003: return "FileMaker(TCP/UDP - Official)";
                case 5004: return "RTP (Real-time Transport Protocol) media data (RFC 3551, RFC 4571) (TCP/UDP/DCCP - Official)";
                case 5005: return "RTP (Real-time Transport Protocol) control protocol (RFC 3551, RFC 4571)(TCP/UDP/DCCP - Official)";
                case 5031: return "AVM CAPI-over-TCP (ISDN over Ethernet tunneling)(TCP/UDP -Unofficial)";
                case 5050: return "Yahoo! Messenger(TCP - Unofficial)";
                case 5051: return "ita-agent Symantec Intruder Alert[32](TCP - Official)";
                case 5060: return "Session Initiation Protocol (SIP)(TCP/UDP - Official)";
                case 5061: return "Session Initiation Protocol (SIP) over TLS(TCP - Official)";
                case 5070: return "Session Initiation Protocol (SIP) preferred port for PUBLISH on SIPTrunk to Cisco Unified Presence Server (CUPS)(TCP - Unofficial)";
                case 5084: return "EPCglobal Low Level Reader Protocol (LLRP)(TCP/UDP - Official)";
                case 5085: return "EPCglobal Low Level Reader Protocol (LLRP) over TLS(TCP/UDP -Official)";
                case 5093: return "SPSS (Statistical Package for the Social Sciences) LicenseAdministrator(UDP - Unofficial)";
                case 5104: return "IBM Tivoli Framework NetCOOL/Impact[33] HTTP Service(TCP -Unofficial)";
                case 5106: return "A-Talk Common connection(TCP - Unofficial)";
                case 5107: return "A-Talk Remote server connection(TCP - Unofficial)";
                case 5110: return "ProRat Server(TCP - Unofficial)";
                case 5121: return "Neverwinter Nights(TCP - Unofficial)";
                case 5151: return "ESRI SDE Instance(TCP - Official)";
                case 5154: return "BZFlag(TCP/UDP - Official)";
                case 5176: return "ConsoleWorks default UI interface(TCP - Unofficial)";
                case 5190: return "ICQ and AOL Instant Messenger(TCP - Official)";
                case 5222: return "Extensible Messaging and Presence Protocol (XMPP) client connection(RFC 3920)(TCP - Official)";
                case 5223: return "Extensible Messaging and Presence Protocol (XMPP) client connectionover SSL(TCP - Unofficial)";
                case 5246: return "Control And Provisioning of Wireless Access Points (CAPWAP) CAPWAPcontrol (RFC 5415)(UDP - Official)";
                case 5247: return "Control And Provisioning of Wireless Access Points (CAPWAP) CAPWAPdata (RFC 5415)(UDP - Official)";
                case 5269: return "Extensible Messaging and Presence Protocol (XMPP) server connection(RFC 3920)(TCP - Official)";
                case 5298: return "Extensible Messaging and Presence Protocol (XMPP) JEP-0174: Link-LocalMessaging / XEP-0174: Serverless Messaging(TCP/UDP - Official)";
                case 5310: return "Ginever.net data communication port(TCP/UDP - Unofficial)";
                case 5351: return "NAT Port Mapping Protocol—client-requested configuration for inboundconnections through network address translators(TCP/UDP - Official)";
                case 5353: return "Multicast DNS (mDNS)(UDP - Official)";
                case 5355: return "LLMNR—Link-Local Multicast Name Resolution, allows hosts to performname resolution for hosts on the same local link (only provided byWindows Vista and Server 2008)(TCP/UDP - Official)";
                case 5357: return "Web Services for Devices (WSDAPI) (only provided by Windows Vista,Windows 7 and Server 2008)(TCP/UDP - Unofficial)";
                case 5358: return "WSDAPI Applications to Use a Secure Channel (only provided by WindowsVista, Windows 7 and Server 2008)(TCP/UDP - Unofficial)";
                case 5402: return "mftp, Stratacache OmniCast content delivery system MFTP file sharingprotocol(TCP/UDP - Official)";
                case 5405: return "NetSupport Manager(TCP/UDP - Official)";
                case 5421: return "NetSupport Manager(TCP/UDP - Official)";
                case 5432: return "PostgreSQL database system(TCP/UDP - Official)";
                case 5433: return "Bouwsoft file/webserver (http://www.bouwsoft.be)(TCP - Unofficial)";
                case 5445: return "Cisco Unified Video Advantage(UDP - Unofficial)";
                case 5450: return "OSIsoft PI Server Client Access(TCP - Unofficial)";
                case 5495: return "Applix TM1 Admin server(TCP - Unofficial)";
                case 5498: return "Hotline tracker server connection(TCP - Unofficial)";
                case 5499: return "Hotline tracker server discovery(UDP - Unofficial)";
                case 5500: return "VNC remote desktop protocol—for incoming listening viewer, Hotlinecontrol connection(TCP - Unofficial)";
                case 5501: return "Hotline file transfer connection(TCP - Unofficial)";
                case 5517: return "Setiqueue Proxy server client for SETI@Home project(TCP -Unofficial)";
                case 5550: return "Hewlett-Packard Data Protector(TCP - Unofficial)";
                case 5555: return "Freeciv versions up to 2.0, Hewlett-Packard Data Protector, McAfeeEndPoint Encryption Database Server, SAP(TCP - Unofficial)";
                case 5556: return "Freeciv(TCP/UDP - Official)";
                case 5631: return "pcANYWHEREdata, Symantec pcAnywhere (version 7.52 and later[34])[35]data(TCP - Official)";
                case 5632: return "pcANYWHEREstat, Symantec pcAnywhere (version 7.52 and later) status (UDP - Official)";
                case 5656: return "IBM Sametime p2p file transfer(TCP - Unofficial)";
                case 5666: return "NRPE (Nagios)(TCP - Unofficial)";
                case 5667: return "NSCA (Nagios)(TCP - Unofficial)";
                case 5721: return "Kaseya(TCP - Unofficial)";
                case 5723: return "Operations Manager(TCP - Unofficial)";
                case 5800: return "VNC remote desktop protocol—for use over HTTP(TCP - Unofficial)";
                case 5814: return "Hewlett-Packard Support Automation (HP OpenView Self-Healing Services)(TCP/UDP - Official)";
                case 5850: return "COMIT SE (PCR)(TCP - Unofficial)";
                case 5852: return "Adeona client: communications to OpenDHT(TCP - Unofficial)";
                case 5900: return "Virtual Network Computing (VNC) remote desktop protocol (used by AppleRemote Desktop and others)(TCP/UDP - Official)";
                case 5938: return "TeamViewer[36] remote desktop protocol(TCP/UDP - Unofficial)";
                case 5984: return "CouchDB database server(TCP/UDP - Official)";
                case 5999: return "CVSup [37] file update tool(TCP - Official)";
                case 6000: return "X11—used between an X client and server over the network(TCP/UDP -Official)";
                case 6005: return "Default for BMC Software Control-M/Server—Socket used forcommunication between Control-M processes—though often changed duringinstallation(TCP - Official)";
                case 6050: return "Brightstor Arcserve Backup(TCP - Unofficial)";
                case 6051: return "Brightstor Arcserve Backup(TCP - Unofficial)";
                case 6072: return "iOperator Protocol Signal Port(TCP - Unofficial)";
                case 6086: return "PDTP—FTP like file server in a P2P network(TCP - Official)";
                case 6100: return "Vizrt System(TCP - Unofficial)";
                case 6101: return "Backup Exec Agent Browser(TCP - Unofficial)";
                case 6110: return "softcm, HP Softbench CM(TCP/UDP - Official)";
                case 6111: return "spc, HP Softbench Sub-Process Control(TCP/UDP - Official)";
                case 6112: return "dtspcd—a network daemon that accepts requests from clients to executecommands and launch applications remotely(TCP/UDP - Official)";
                case 6129: return "DameWare Remote Control(TCP - Official)";
                case 6257: return "WinMX (see also 6699)(UDP - Unofficial)";
                case 6262: return "Sybase Advantage Database Server(TCP - Unofficial)";
                case 6343: return "SFlow, sFlow traffic monitoring(UDP - Unofficial)";
                case 6346: return "gnutella-svc, Gnutella (FrostWire, Limewire, Shareaza, etc.)(TCP/UDP- Official)";
                case 6347: return "gnutella-rtr, Gnutella alternate(TCP/UDP - Official)";
                case 6389: return "EMC CLARiiON(TCP - Unofficial)";
                case 6432: return "PgBouncer - A connection pooler for PostgreSQL(TCP - Official)";
                case 6444: return "Sun Grid Engine—Qmaster Service(TCP/UDP - Official)";
                case 6445: return "Sun Grid Engine—Execution Service(TCP/UDP - Official)";
                case 6502: return "Danware Data NetOp Remote Control(TCP/UDP - Unofficial)";
                case 6522: return "Gobby (and other libobby-based software)(TCP - Unofficial)";
                case 6523: return "Gobby 0.5 (and other libinfinity-based software)(TCP - Unofficial)";
                case 6543: return "Paradigm Research & Development Jetnet[38] default(UDP - Unofficial)";
                case 6566: return "SANE (Scanner Access Now Easy)—SANE network scanner daemon(TCP -Unofficial)";
                case 6571: return "Windows Live FolderShare client(Unofficial)";
                case 6600: return "Music Playing Daemon (MPD)(TCP - Unofficial)";
                case 6619: return "odette-ftps, Odette File Transfer Protocol (OFTP) over TLS/SSL (TCP/UDP - Official)";
                case 6646: return "McAfee Network Agent(UDP - Unofficial)";
                case 6660: return "Internet Relay Chat(TCP - Unofficial)";
                case 6665: return "Internet Relay Chat(TCP - Official)";
                case 6679: return "IRC SSL (Secure Internet Relay Chat)—often used(TCP - Unofficial)";
                case 6697: return "IRC SSL (Secure Internet Relay Chat)—often used(TCP - Unofficial)";
                case 6699: return "WinMX (see also 6257)(TCP - Unofficial)";
                case 6771: return "Polycom server broadcast(UDP - Unofficial)";
                case 6789: return "Datalogger Support Software Campbell Scientific Loggernet Software (TCP - Unofficial)";
                case 6881: return "BitTorrent part of full range of ports used most often(TCP/UDP -Unofficial)";
                case 6888: return "MUSE(TCP/UDP - Official)";
                case 6891: return "Windows Live Messenger (File transfer)(TCP/UDP - Unofficial)";
                case 6901: return "Windows Live Messenger (Voice)(TCP/UDP - Unofficial)";
                case 6969: return "acmsoda(TCP/UDP - Official)";
                case 6970: return "BitTorrent part of full range of ports used most often(TCP/UDP -Unofficial)";
                case 7000: return "Default for Vuze's built in HTTPS Bittorrent Tracker(TCP -Unofficial)";
                case 7001: return "Default for BEA WebLogic Server's HTTP server, though often changedduring installation(TCP - Unofficial)";
                case 7002: return "Default for BEA WebLogic Server's HTTPS server, though often changedduring installation(TCP - Unofficial)";
                case 7005: return "Default for BMC Software Control-M/Server and Control-M/Agent forAgent-to-Server, though often changed during installation(TCP -Official)";
                case 7006: return "Default for BMC Software Control-M/Server and Control-M/Agent forServer-to-Agent, though often changed during installation(TCP -Official)";
                case 7010: return "Default for Cisco AON AMC (AON Management Console) [2](TCP -Unofficial)";
                case 7025: return "Zimbra LMTP [mailbox]—local mail delivery(TCP - Unofficial)";
                case 7047: return "Zimbra conversion server(TCP - Unofficial)";
                case 7133: return "Enemy Territory: Quake Wars(TCP - Unofficial)";
                case 7144: return "Peercast(TCP - Unofficial)";
                case 7171: return "Tibia(TCP - Unofficial)";
                case 7306: return "Zimbra mysql [mailbox](TCP - Unofficial)";
                case 7307: return "Zimbra mysql [logger](TCP - Unofficial)";
                case 7312: return "Sibelius License Server(UDP - Unofficial)";
                case 7400: return "RTPS (Real Time Publish Subscribe) DDS Discovery(TCP/UDP - Official)";
                case 7401: return "RTPS (Real Time Publish Subscribe) DDS User-Traffic(TCP/UDP -Official)";
                case 7402: return "RTPS (Real Time Publish Subscribe) DDS Meta-Traffic(TCP/UDP -Official)";
                case 7670: return "BrettspielWelt BSW Boardgame Portal(TCP - Unofficial)";
                case 7676: return "Aqumin AlphaVision Remote Command Interface(TCP - Unofficial)";
                case 7777: return "iChat server file transfer proxy(TCP - Unofficial)";
                case 7787: return "GFI EventsManager 7 & 8 (TCP - Official)";
                case 7831: return "Default used by Smartlaunch Internet Cafe Administration[39] software (TCP - Unofficial)";
                case 7915: return "Default for YSFlight server [3](TCP - Unofficial)";
                case 7935: return "Fixed port used for Adobe Flash Debug Player to communicate with adebugger (Flash IDE, Flex Builder or fdb). [4](TCP - Unofficial)";
                case 7937: return "EMC2 (Legato) Networker or Sun Solcitice Backup(TCP/UDP - Official)";
                case 8000: return "iRDMI (Intel Remote Desktop Management Interface)[40]—sometimeserroneously used instead of port 8080 (TCP / UDP - Official)";
                case 8002: return "Cisco Systems Unified Call Manager Intercluster(TCP - Unofficial)";
                case 8008: return "HTTP Alternate(TCP - Official)";
                case 8009: return "ajp13 – Apache JServ Protocol AJP Connector(TCP - Unofficial)";
                case 8010: return "XMPP File transfers(TCP - Unofficial)";
                case 8011: return "HTTP/TCP Symon Communications Event and Query Engine(TCP -Unofficial)";
                case 8074: return "Gadu-Gadu(TCP - Unofficial)";
                case 8080: return "HTTP alternate (http_alt)—commonly used for Web proxy and cachingserver, or for running a Web server as a non-root user(TCP -Official)";
                case 8081: return "HTTP alternate, e.g. McAfee ePolicy Orchestrator (ePO)(TCP -Unofficial)";
                case 8086: return "HELM Web Host Automation Windows Control Panel(TCP - Unofficial)";
                case 8087: return "Hosting Accelerator Control Panel(TCP - Unofficial)";
                case 8090: return "HTTP Alternate (http_alt_alt)—used as an alternative to port 8080 (TCP - Unofficial)";
                case 8116: return "Check Point Cluster Control Protocol(UDP - Unofficial)";
                case 8118: return "Privoxy—advertisement-filtering Web proxy(TCP - Official)";
                case 8123: return "Polipo Web proxy(TCP - Official)";
                case 8192: return "Sophos Remote Management System(TCP - Unofficial)";
                case 8200: return "GoToMyPC(TCP - Unofficial)";
                case 8222: return "VMware Server Management User Interface (insecure Web interface)[41].See also port 8333 (Unofficial)";
                case 8243: return "HTTPS listener for Apache Synapse [42](TCP/UDP - Official)";
                case 8280: return "HTTP listener for Apache Synapse [42](TCP/UDP - Official)";
                case 8291: return "Winbox—Default on a MikroTik RouterOS for a Windows application usedto administer MikroTik RouterOS(TCP - Unofficial)";
                case 8333: return "VMware Server Management User Interface (secure Web interface)[41].See also port 8222(Unofficial)";
                case 8400: return "cvp, Commvault Unified Data Management(TCP/UDP - Official)";
                case 8443: return "SW Soft Plesk Control Panel, Apache Tomcat SSL, Promise WebPAM SSL (TCP - Unofficial)";
                case 8484: return "MapleStory(TCP/UDP - Unofficial)";
                case 8500: return "ColdFusion Macromedia/Adobe ColdFusion default and Duke Nukem 3D—default(TCP/IPX - Unofficial)";
                case 8501: return "[5] DukesterX —default(TCP - Unofficial)";
                case 8691: return "Ultra Fractal default server port for distributing calculations overnetwork computers(TCP - Unofficial)";
                case 8701: return "SoftPerfect Bandwidth Manager(UDP - Unofficial)";
                case 8767: return "TeamSpeak—default(UDP - Unofficial)";
                case 8768: return "TeamSpeak—alternate(UDP - Unofficial)";
                case 8880: return "WebSphere Application Server SOAP connector default(TCP -Unofficial)";
                case 8881: return "Atlasz Informatics Research Ltd [6] Secure Application Server(TCP -Unofficial)";
                case 8882: return "Atlasz Informatics Research Ltd [7] Secure Application Server(TCP -Unofficial)";
                case 8888: return "NewsEDGE server(TCP/UDP - Official)";
                case 8889: return "Earthland Relams 2 Server (AU1_1)(TCP - Unofficial)";
                case 9000: return "Buffalo LinkSystem Web access(TCP - Unofficial)";
                case 9001: return "Microsoft Sharepoint Authoring Environment(Official)";
                case 9009: return "Pichat Server—Peer to peer chat software(TCP/UDP - Official)";
                case 9030: return "Tor often used(TCP - Unofficial)";
                case 9043: return "WebSphere Application Server Administration Console secure(TCP -Unofficial)";
                case 9050: return "Tor(TCP - Unofficial)";
                case 9060: return "WebSphere Application Server Administration Console(TCP -Unofficial)";
                case 9080: return "glrpc, Groove Collaboration software GLRPC(TCP/UDP - Official)";
                case 9090: return "Openfire Administration Console(TCP - Unofficial)";
                case 9091: return "Openfire Administration Console (SSL Secured)(TCP - Unofficial)";
                case 9100: return "PDL Data Stream(TCP - Official)";
                case 9101: return "Bacula Director(Official)";
                case 9102: return "Bacula File Daemon(Official)";
                case 9103: return "Bacula Storage Daemon(Official)";
                case 9105: return "Xadmin Control Daemon(TCP/UDP - Official)";
                case 9110: return "SSMP Message protocol(UDP - Unofficial)";
                case 9119: return "MXit Instant Messenger(TCP/UDP - Official)";
                case 9293: return "Sony Playstation RemotePlay(TCP - Unofficial)";
                case 9300: return "IBM Cognos 8 SOAP Business Intelligence and Performance Management (TCP - Unofficial)";
                case 9303: return "D-Link Shareport Share storage and MFP printers(UDP - Unofficial)";
                case 9306: return "Sphinx Native API(TCP - Official)";
                case 9312: return "Sphinx SphinxQL(TCP - Official)";
                case 9418: return "git, Git pack transfer service(TCP/UDP - Official)";
                case 9420: return "MooseFS distributed file system – master server to chunk servers(TCP- Unofficial)";
                case 9421: return "MooseFS distributed file system – master server to clients(TCP -Unofficial)";
                case 9422: return "MooseFS distributed file system – chunk servers to clients(TCP -Unofficial)";
                case 9535: return "mngsuite, LANDesk Management Suite Remote Control(TCP/UDP -Official)";
                case 9561: return "Network Time System Server(TCP/UDP - Unofficial)";
                case 9600: return "Omron FINS, OMRON FINS PLC communication(UDP - Official)";
                case 9800: return "WebDAV Source(TCP/UDP - Official)";
                case 9875: return "Club Penguin Disney online game for kids(TCP - Unofficial)";
                case 9898: return "MonkeyCom(TCP/UDP - Official)";
                case 9987: return "TeamSpeak 3 server default (voice) port (for the conflicting servicesee the IANA list)(TCP - Unofficial)";
                case 9996: return "The Palace \"The Palace\" Virtual Reality Chat software. – 5 (TCP / UDP - Official)";
                case 9999: return "Hydranode—edonkey2000 TELNET control(Unofficial)";
                case 10000: return "Webmin—Web-based Linux admin tool(Unofficial)";
                case 10001: return "Lantronix UDS-10/UDS100[44] RS-485 to Ethernet Converter default(TCP- Unofficial)";
                case 10008: return "Octopus Multiplexer, primary port for the CROMP protocol, whichprovides a platform-independent means for communication of objectsacross a network(TCP/UDP - Official)";
                case 10010: return "Open Object Rexx (ooRexx) rxapi daemon(TCP - Official)";
                case 10017: return "AIX,NeXT, HPUX—rexd daemon control(Unofficial)";
                case 10024: return "Zimbra smtp [mta]—to amavis from postfix(TCP - Unofficial)";
                case 10025: return "Zimbra smtp [mta]—back to postfix from amavis(TCP - Unofficial)";
                case 10050: return "Zabbix-Agent(TCP/UDP - Official)";
                case 10051: return "Zabbix-Trapper(TCP/UDP - Official)";
                case 10113: return "NetIQ Endpoint(TCP/UDP - Official)";
                case 10114: return "NetIQ Qcheck(TCP/UDP - Official)";
                case 10115: return "NetIQ Endpoint(TCP/UDP - Official)";
                case 10116: return "NetIQ VoIP Assessor(TCP/UDP - Official)";
                case 10200: return "FRISK Software International's fpscand virus scanning daemon for Unixplatforms [8](TCP - Unofficial)";
                case 10308: return "Lock-on: Modern Air Combat(Unofficial)";
                case 10480: return "SWAT 4 Dedicated Server(Unofficial)";
                case 11211: return "memcached(Unofficial)";
                case 11235: return "Savage:Battle for Newerth Server Hosting(Unofficial)";
                case 11294: return "Blood Quest Online Server(Unofficial)";
                case 11371: return "OpenPGP HTTP key server(Official)";
                case 11576: return "IPStor Server management communication(Unofficial)";
                case 12010: return "ElevateDB default database port [10](TCP - Unofficial)";
                case 12012: return "Audition Online Dance Battle, Korea Server – Status/Version Check (TCP/UDP - Unofficial)";
                case 12013: return "Audition Online Dance Battle, Korea Server(TCP/UDP - Unofficial)";
                case 12035: return "Linden Lab viewer to sim(UDP - Unofficial)";
                case 12222: return "Light Weight Access Point Protocol (LWAPP) LWAPP data (RFC 5412)(UDP- Official)";
                case 12223: return "Light Weight Access Point Protocol (LWAPP) LWAPP control (RFC 5412) (UDP - Official)";
                case 12345: return "NetBus—remote administration tool (often Trojan horse). Also used byNetBuster. Little Fighter 2 (TCP).(Unofficial)";
                case 12975: return "LogMeIn Hamachi (VPN tunnel software; also port 32976)—used to connectto Mediation Server (bibi.hamachi.cc); will attempt to use SSL (TCPport 443) if both 12975 & 32976 fail to connect(TCP - Unofficial)";
                case 12998: return "Takenaka RDI Mirror World on SL(UDP - Unofficial)";
                case 13000: return "Linden Lab viewer to sim(UDP - Unofficial)";
                case 13076: return "Default for BMC Software Control-M/Enterprise Manager Corbacommunication, though often changed during installation(TCP -Official)";
                case 13720: return "Symantec NetBackup—bprd (formerly VERITAS)(TCP/UDP - Official)";
                case 13721: return "Symantec NetBackup—bpdbm (formerly VERITAS)(TCP/UDP - Official)";
                case 13724: return "Symantec Network Utility—vnetd (formerly VERITAS)(TCP/UDP -Official)";
                case 13782: return "Symantec NetBackup—bpcd (formerly VERITAS)(TCP/UDP - Official)";
                case 13783: return "Symantec VOPIED protocol (formerly VERITAS)(TCP/UDP - Official)";
                case 13785: return "Symantec NetBackup Database—nbdb (formerly VERITAS)(TCP/UDP -Official)";
                case 13786: return "Symantec nomdb (formerly VERITAS)(TCP/UDP - Official)";
                case 14439: return "APRS UI-View Amateur Radio[45] UI-WebServer(TCP - Unofficial)";
                case 14567: return "Battlefield 1942 and mods(UDP - Unofficial)";
                case 15000: return "hydap, Hypack Hydrographic Software Packages Data Acquisition (TCP/UDP - Official)";
                case 15567: return "Battlefield Vietnam and mods(UDP - Unofficial)";
                case 15345: return "XPilot Contact(TCP/UDP - Official)";
                case 16000: return "shroudBNC(TCP - Unofficial)";
                case 16080: return "Mac OS X Server Web (HTTP) service with performance cache[46](TCP -Unofficial)";
                case 16384: return "Iron Mountain Digital online backup(UDP - Unofficial)";
                case 16567: return "Battlefield 2 and mods(UDP - Unofficial)";
                case 17500: return "Dropbox LanSync Protocol (db-lsp); used to synchronize file catalogsbetween Dropbox clients on your local network.(TCP - Official)";
                case 18010: return "Super Dancer Online Extreme(SDO-X) – CiB Net Station Malaysia Server (TCP - Unofficial)";
                case 18180: return "DART Reporting server(TCP - Unofficial)";
                case 18200: return "Audition Online Dance Battle, AsiaSoft Thailand Server –Status/Version Check(TCP/UDP - Unofficial)";
                case 18201: return "Audition Online Dance Battle, AsiaSoft Thailand Server(TCP/UDP -Unofficial)";
                case 18206: return "Audition Online Dance Battle, AsiaSoft Thailand Server – FAM Database (TCP/UDP - Unofficial)";
                case 18300: return "Audition Online Dance Battle, AsiaSoft SEA Server – Status/VersionCheck(TCP/UDP - Unofficial)";
                case 18301: return "Audition Online Dance Battle, AsiaSoft SEA Server(TCP/UDP -Unofficial)";
                case 18306: return "Audition Online Dance Battle, AsiaSoft SEA Server – FAM Database (TCP/UDP - Unofficial)";
                case 18400: return "Audition Online Dance Battle, KAIZEN Brazil Server – Status/VersionCheck(TCP/UDP - Unofficial)";
                case 18401: return "Audition Online Dance Battle, KAIZEN Brazil Server(TCP/UDP -Unofficial)";
                case 18505: return "Audition Online Dance Battle, Nexon Server – Status/Version Check (TCP/UDP - Unofficial)";
                case 18506: return "Audition Online Dance Battle, Nexon Server(TCP/UDP - Unofficial)";
                case 18605: return "X-BEAT – Status/Version Check(TCP/UDP - Unofficial)";
                case 18606: return "X-BEAT(TCP/UDP - Unofficial)";
                case 19000: return "Audition Online Dance Battle, G10/alaplaya Server – Status/VersionCheck(TCP/UDP - Unofficial)";
                case 19001: return "Audition Online Dance Battle, G10/alaplaya Server(TCP/UDP -Unofficial)";
                case 19226: return "Panda Software AdminSecure Communication Agent(TCP - Unofficial)";
                case 19283: return "K2 - KeyAuditor & KeyServer, Sassafras Software Inc. Software AssetManagement tools(TCP/UDP - Official)";
                case 19315: return "KeyShadow for K2 - KeyAuditor & KeyServer, Sassafras Software Inc.Software Asset Management tools(TCP/UDP - Official)";
                case 19638: return "Ensim Control Panel(TCP - Unofficial)";
                case 19771: return "Softros LAN Messenger(TCP/UDP - Unofficial)";
                case 19813: return "4D database Client Server Communication(TCP - Unofficial)";
                case 19880: return "Softros LAN Messenger(TCP - Unofficial)";
                case 20000: return "DNP (Distributed Network Protocol), a protocol used in SCADA systemsbetween communicating RTU's and IED's(Official)";
                case 20014: return "DART Reporting server(TCP - Unofficial)";
                case 20720: return "Symantec i3 Web GUI server(TCP - Unofficial)";
                case 21001: return "AMLFilter, AMLFilter Inc. amlf-admin default port(TCP - Unofficial)";
                case 21011: return "AMLFilter, AMLFilter Inc. amlf-engine-01 default http port(TCP -Unofficial)";
                case 21012: return "AMLFilter, AMLFilter Inc. amlf-engine-01 default https port(TCP -Unofficial)";
                case 21021: return "AMLFilter, AMLFilter Inc. amlf-engine-02 default http port(TCP -Unofficial)";
                case 21022: return "AMLFilter, AMLFilter Inc. amlf-engine-02 default https port(TCP -Unofficial)";
                case 22347: return "WibuKey, WIBU-SYSTEMS AG Software protection system(TCP/UDP -Official)";
                case 22350: return "CodeMeter, WIBU-SYSTEMS AG Software protection system(TCP/UDP -Official)";
                case 23073: return "Soldat Dedicated Server(Unofficial)";
                case 23399: return "Skype Default Protocol(Unofficial)";
                case 23513: return "Duke Nukem 3D#Source code Duke Nukem Ports(Unofficial)";
                case 24444: return "NetBeans integrated development environment(Unofficial)";
                case 24465: return "Tonido Directory Server for Tonido which is a Personal Web app andpeer-to-peer platform(TCP/UDP - Official)";
                case 24554: return "BINKP, Fidonet mail transfers over TCP/IP(TCP/UDP - Official)";
                case 24800: return "Synergy: keyboard/mouse sharing software(Unofficial)";
                case 24842: return "StepMania: Online: Dance Dance Revolution Simulator(Unofficial)";
                case 25888: return "Xfire (Firewall Report, UDP_IN) IP Address (206.220.40.146) resolvesto gameservertracking.xfire.com. Use unknown.(UDP - Unofficial)";
                case 25999: return "Xfire(TCP - Unofficial)";
                case 26000: return "id Software's Quake server(TCP/UDP - Official)";
                case 26900: return "CCP's EVE Online Online gaming MMORPG(TCP - Unofficial)";
                case 27000: return "FlexNet Publisher's License server (from the range of default ports) (TCP - Unofficial)";
                case 27010: return "Source engine dedicated server port(Unofficial)";
                case 27014: return "Source engine dedicated server port (rare)(Unofficial)";
                case 27015: return "GoldSrc and Source engine dedicated server port(Unofficial)";
                case 27017: return "mongoDB server port(Unofficial)";
                case 27374: return "Sub7 default. Most script kiddies do not change from this (Unofficial)";
                case 27500: return "(through 27900) id Software's QuakeWorld(UDP - Unofficial)";
                case 27888: return "Kaillera server(UDP - Unofficial)";
                case 27900: return "(through 27901) Nintendo Wi-Fi Connection(Unofficial)";
                case 27901: return "(through 27910) id Software's Quake II master server(UDP -Unofficial)";
                case 27960: return "(through 27969) Activision's Enemy Territory and id Software's QuakeIII Arena, Quake III and Quake Live and some ioquake3 derived games (UDP - Unofficial)";
                case 28000: return "Bitfighter Common/default Bitfighter Server(Unofficial)";
                case 28001: return "Starsiege: Tribes Common/default Tribes v.1 Server(Unofficial)";
                case 28395: return "www.SmartSystemsLLC.com Used by Smart Sale 5.0: return \"(TCP - Unofficial)";
                case 28910: return "Nintendo Wi-Fi Connection(Unofficial)";
                case 28960: return "Call of Duty – Call of Duty: United Offensive – Call of Duty 2 – Callof Duty 4: Modern Warfare – Call of Duty: World at War (PC Version) (UDP - Unofficial)";
                case 29900: return "(through 29901) Nintendo Wi-Fi Connection(Unofficial)";
                case 29920: return "Nintendo Wi-Fi Connection(Unofficial)";
                case 30000: return "Pokémon Netbattle(Unofficial)";
                case 30301: return "BitTorrent(Unofficial)";
                case 30564: return "Multiplicity: keyboard/mouse/clipboard sharing software(TCP -Unofficial)";
                case 31337: return "Back Orifice—remote administration tool (often Trojan horse)(TCP -Unofficial)";
                case 31415: return "ThoughtSignal—Server Communication Service (often Informational) (Unofficial)";
                case 31456: return "TetriNET IRC gateway on some servers(TCP - Unofficial)";
                case 31457: return "TetriNET(TCP - Official)";
                case 31458: return "TetriNET Used for game spectators(TCP - Unofficial)";
                case 32245: return "MMTSG-mutualed over MMT (encrypted transmission)(TCP - Unofficial)";
                case 32976: return "LogMeIn Hamachi (VPN tunnel software; also port 12975)—used to connectto Mediation Server (bibi.hamachi.cc); will attempt to use SSL (TCPport 443) if both 12975 & 32976 fail to connect(TCP - Unofficial)";
                case 30033: return "Team Speak Server (TCP/UDP - Unofficial)";
                case 33434: return "traceroute(TCP/UDP - Official)";
                case 34443: return "Linksys PSUS4 print server(Unofficial)";
                case 36963: return "Counter Strike 2D multiplayer (2D clone of popular CounterStrikecomputer game)(Unofficial)";
                case 37777: return "Digital Video Recorder hardware(TCP - Unofficial)";
                case 40000: return "SafetyNET p Real-time Industrial Ethernet protocol(TCP/UDP -Official)";
                case 43047: return "TheòsMessenger second port for service TheòsMessenger(TCP -Official)";
                case 43048: return "TheòsMessenger third port for service TheòsMessenger(TCP - Official)";
                case 43594: return "RuneScape Servers(TCP - Unofficial)";
                case 47808: return "BACnet Building Automation and Control Networks(TCP/UDP - Official)";
                case 49151: return "Reserved[1](TCP/UDP - Official)";
                default: return "TCP Connection";
            }

        }

        private void TxtInfo_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void PortWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Cancel = false;
            launchBtn.Text = "Cancelar";
            launchBtn.Refresh();

            try
            {
                Max = Convert.ToInt32(FBox.Text);
                Min = Convert.ToInt32(SBox.Text);
                int TimeOut = Convert.ToInt32(timeOut.Text);

                int BeginPort = Convert.ToInt32(Min);
                int EndPort = Convert.ToInt32(Max);
                int str = 0;
                int i;

                progressBarCheck.Maximum = EndPort - BeginPort + 1; // установление максимума полоски заполнения
                progressBarCheck.Value = 0;

                txtInfo.Clear();

                IPAddress addr = IPAddress.Parse(RemoteHost.Text);

                for (i = BeginPort; i <= EndPort; i++)
                {
                    if (Cancel)
                        goto Label_End;

                    Info.Text = "Chequeando puertos... por favor espere. [Puerto: " + i + "]";

                    IPEndPoint ep = new IPEndPoint(addr, i);
                    Socket soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IAsyncResult asyncResult = soc.BeginConnect(ep, new AsyncCallback(ConnectCallback), soc);

                    if (!asyncResult.AsyncWaitHandle.WaitOne(TimeOut, false))
                    {
                        soc.Close();
                        progressBarCheck.Value += 1;

                    }
                    else
                    {
                        soc.Close(); // закрываем сокет и далее пишем, что порт открыт
                        AddPort(i);
                        str++;
                        progressBarCheck.Value += 1;
                    }
                }
            }
            catch
            {
            }
            Label_End:;
        }

        private void PortWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            progressBarCheck.Visible = false;
            progressBarCheck.Value = 0;
            Info.Text = "Listo.";
            launchBtn.Text = "Buscar";
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
