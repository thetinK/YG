using Network.Protocol;
using System;

namespace Network.TCP
{
	public class TcpServerEvent
	{
		public delegate HandleResult OnSendEventHandler(IntPtr connId, byte[] bytes);

		public delegate HandleResult OnReceiveEventHandler(IntPtr connId, byte[] bytes);

		public delegate HandleResult OnPointerDataReceiveEventHandler(IntPtr connId, IntPtr pData, int length);

		public delegate HandleResult OnCloseEventHandler(IntPtr connId, SocketOperation enOperation, int errorCode);

		public delegate HandleResult OnShutdownEventHandler();

		public delegate HandleResult OnPrepareListenEventHandler(IntPtr soListen);

		public delegate HandleResult OnAcceptEventHandler(IntPtr connId, IntPtr pClient);

		public delegate HandleResult OnHandShakeEventHandler(IntPtr connId);
	}
}
