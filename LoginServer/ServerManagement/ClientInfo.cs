using Network.TCP;
using System;
using System.Runtime.InteropServices;

namespace ServerManagement
{
	[StructLayout(LayoutKind.Sequential)]
	public class ClientInfo
	{
		public IntPtr ConnId { get; set; }

		public string IpAddress { get; set; }

		public ushort Port { get; set; }

		public TcpServer Server { get; set; }

		public int WorldId { get; set; }

		public NetState Client { get; set; }
	}
}
