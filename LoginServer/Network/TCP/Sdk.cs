using System;
using System.Runtime.InteropServices;
using System.Text;
using Core;
using Network.Protocol;
using Utilities;

public class Sdk
{
	public delegate HandleResult OnSend(IntPtr pSender, IntPtr connId, IntPtr pData, int length);

	public delegate HandleResult OnReceive(IntPtr pSender, IntPtr connId, IntPtr pData, int length);

	public delegate HandleResult OnPullReceive(IntPtr pSender, IntPtr connId, int length);

	public delegate HandleResult OnClose(IntPtr pSender, IntPtr connId, SocketOperation enOperation, int errorCode);

	public delegate HandleResult OnHandShake(IntPtr pSender, IntPtr connId);

	public delegate HandleResult OnShutdown(IntPtr pSender);

	public delegate HandleResult OnPrepareConnect(IntPtr pSender, IntPtr connId, IntPtr socket);

	public delegate HandleResult OnConnect(IntPtr pSender, IntPtr connId);

	public delegate HandleResult OnPrepareListen(IntPtr pSender, IntPtr soListen);

	public delegate HandleResult OnAccept(IntPtr pSender, IntPtr connId, IntPtr pClient);

	public const string HPSOCKET_DLL_PATH = "HPSocket4C_U.dll";

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_TcpServer(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_TcpClient(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_TcpAgent(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_TcpPullServer(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_TcpPullClient(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_TcpPullAgent(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_TcpPackServer(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_TcpPackAgent(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_TcpPackClient(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_UdpServer(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_UdpClient(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_TcpServer(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_TcpClient(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_TcpAgent(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_TcpPullServer(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_TcpPullClient(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_TcpPullAgent(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_TcpPackServer(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_TcpPackAgent(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_TcpPackClient(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_UdpServer(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_UdpClient(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_TcpServerListener();

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_TcpClientListener();

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_TcpAgentListener();

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_TcpPullServerListener();

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_TcpPullClientListener();

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_TcpPullAgentListener();

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_TcpPackServerListener();

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_TcpPackClientListener();

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_TcpPackAgentListener();

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_UdpServerListener();

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr Create_HP_UdpClientListener();

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_TcpServerListener(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_TcpClientListener(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_TcpAgentListener(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_TcpPullServerListener(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_TcpPullClientListener(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_TcpPullAgentListener(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_TcpPackServerListener(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_TcpPackClientListener(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_TcpPackAgentListener(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_UdpServerListener(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void Destroy_HP_UdpClientListener(IntPtr pListener);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Server_OnPrepareListen(IntPtr pListener, OnPrepareListen fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Server_OnAccept(IntPtr pListener, OnAccept fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Server_OnHandShake(IntPtr pListener, OnHandShake fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Server_OnSend(IntPtr pListener, OnSend fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Server_OnReceive(IntPtr pListener, OnReceive fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Server_OnPullReceive(IntPtr pListener, OnPullReceive fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Server_OnClose(IntPtr pListener, OnClose fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Server_OnShutdown(IntPtr pListener, OnShutdown fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Client_OnPrepareConnect(IntPtr pListener, OnPrepareConnect fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Client_OnConnect(IntPtr pListener, OnConnect fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Client_OnHandShake(IntPtr pListener, OnHandShake fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Client_OnSend(IntPtr pListener, OnSend fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Client_OnReceive(IntPtr pListener, OnReceive fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Client_OnPullReceive(IntPtr pListener, OnPullReceive fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Client_OnClose(IntPtr pListener, OnClose fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Agent_OnPrepareConnect(IntPtr pListener, OnPrepareConnect fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Agent_OnConnect(IntPtr pListener, OnConnect fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Agent_OnHandShake(IntPtr pListener, OnHandShake fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Agent_OnSend(IntPtr pListener, OnSend fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Agent_OnReceive(IntPtr pListener, OnReceive fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Agent_OnPullReceive(IntPtr pListener, OnPullReceive fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Agent_OnClose(IntPtr pListener, OnClose fn);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Set_FN_Agent_OnShutdown(IntPtr pListener, OnShutdown fn);

	[DllImport("HPSocket4C_U.dll", CharSet = CharSet.Unicode)]
	public static extern bool HP_Server_Start(IntPtr pServer, string pszBindAddress, ushort usPort, ushort usServerID);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Server_Stop(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Server_Destroying(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll", CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern bool HP_Server_Send(IntPtr pServer, IntPtr connId, byte[] pBuffer, int length);

	[DllImport("HPSocket4C_U.dll", SetLastError = true)]
	public static extern bool HP_Server_Send(IntPtr pServer, IntPtr connId, IntPtr pBuffer, int length);

	[DllImport("HPSocket4C_U.dll", CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern bool HP_Server_SendPart(IntPtr pServer, IntPtr connId, byte[] pBuffer, int length, int iOffset);

	[DllImport("HPSocket4C_U.dll", SetLastError = true)]
	public static extern bool HP_Server_SendPart(IntPtr pServer, IntPtr connId, IntPtr pBuffer, int length, int iOffset);

	[DllImport("HPSocket4C_U.dll", SetLastError = true)]
	public static extern bool HP_Server_SendPackets(IntPtr pServer, IntPtr connId, WSABUF[] pBuffers, int iCount);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Server_Disconnect(IntPtr pServer, IntPtr connId, bool bForce);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Server_DisconnectLongConnections(IntPtr pServer, uint dwPeriod, bool bForce);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Server_DisconnectSilenceConnections(IntPtr pServer, uint dwPeriod, bool bForce);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Server_SetSendPolicy(IntPtr pServer, SendPolicy enSendPolicy);

	[DllImport("HPSocket4C_U.dll")]
	public static extern SendPolicy HP_Server_GetSendPolicy(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Server_SetConnectionExtra(IntPtr pServer, IntPtr connId, IntPtr pExtra);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Server_GetConnectionExtra(IntPtr pServer, IntPtr connId, ref IntPtr pExtra);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Server_IsSecure(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Server_HasStarted(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern ServiceState HP_Server_GetState(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern SocketError HP_Server_GetLastError(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr HP_Server_GetLastErrorDesc(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Server_GetPendingDataLength(IntPtr pServer, IntPtr connId, ref int piPending);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_Server_GetConnectionCount(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Server_GetAllConnectionIDs(IntPtr pServer, IntPtr[] pIDs, ref uint pdwCount);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Server_GetConnectPeriod(IntPtr pServer, IntPtr connId, ref uint pdwPeriod);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Server_GetSilencePeriod(IntPtr pServer, IntPtr connId, ref uint pdwPeriod);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Server_GetListenAddress(IntPtr pServer, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpszAddress, ref int piAddressLen, ref ushort pusPort);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Server_GetLocalAddress(IntPtr pServer, IntPtr connId, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpszAddress, ref int piAddressLen, ref ushort pusPort);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Server_GetRemoteAddress(IntPtr pServer, IntPtr connId, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpszAddress, ref int piAddressLen, ref ushort pusPort);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Server_SetFreeSocketObjLockTime(IntPtr pServer, uint dwFreeSocketObjLockTime);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Server_SetFreeSocketObjPool(IntPtr pServer, uint dwFreeSocketObjPool);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Server_SetFreeBufferObjPool(IntPtr pServer, uint dwFreeBufferObjPool);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Server_SetFreeSocketObjHold(IntPtr pServer, uint dwFreeSocketObjHold);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Server_SetFreeBufferObjHold(IntPtr pServer, uint dwFreeBufferObjHold);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Server_SetMaxConnectionCount(IntPtr pServer, uint dwWMaxConnectionCount);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Server_SetWorkerThreadCount(IntPtr pServer, uint dwWorkerThreadCount);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Server_SetMarkSilence(IntPtr pServer, bool bMarkSilence);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_Server_GetFreeSocketObjLockTime(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_Server_GetFreeSocketObjPool(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_Server_GetFreeBufferObjPool(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_Server_GetFreeSocketObjHold(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_Server_GetFreeBufferObjHold(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_Server_GetMaxConnectionCount(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_Server_GetWorkerThreadCount(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Server_IsMarkSilence(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool HP_TcpServer_SendSmallFile(IntPtr pServer, IntPtr connId, string lpszFileName, ref WSABUF pHead, ref WSABUF pTail);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_TcpServer_SetAcceptSocketCount(IntPtr pServer, uint dwAcceptSocketCount);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_TcpServer_SetSocketBufferSize(IntPtr pServer, uint dwSocketBufferSize);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_TcpServer_SetSocketListenQueue(IntPtr pServer, uint dwSocketListenQueue);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_TcpServer_SetKeepAliveTime(IntPtr pServer, uint dwKeepAliveTime);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_TcpServer_SetKeepAliveInterval(IntPtr pServer, uint dwKeepAliveInterval);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_TcpServer_GetAcceptSocketCount(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_TcpServer_GetSocketBufferSize(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_TcpServer_GetSocketListenQueue(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_TcpServer_GetKeepAliveTime(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_TcpServer_GetKeepAliveInterval(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_UdpServer_SetMaxDatagramSize(IntPtr pServer, uint dwMaxDatagramSize);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_UdpServer_GetMaxDatagramSize(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_UdpServer_SetPostReceiveCount(IntPtr pServer, uint dwPostReceiveCount);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_UdpServer_GetPostReceiveCount(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_UdpServer_SetDetectAttempts(IntPtr pServer, uint dwMaxDatagramSize);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_UdpServer_SetDetectInterval(IntPtr pServer, uint dwMaxDatagramSize);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_UdpServer_GetDetectAttempts(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_UdpServer_GetDetectInterval(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll", CharSet = CharSet.Unicode)]
	public static extern bool HP_Client_Start(IntPtr pClient, string pszRemoteAddress, ushort usPort, bool bAsyncConnect);

	[DllImport("HPSocket4C_U.dll", CharSet = CharSet.Unicode)]
	public static extern bool HP_Client_StartWithBindAddress(IntPtr pClient, string lpszRemoteAddress, ushort usPort, bool bAsyncConnect, string lpszBindAddress);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Client_Stop(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll", CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern bool HP_Client_Send(IntPtr pClient, byte[] pBuffer, int length);

	[DllImport("HPSocket4C_U.dll", SetLastError = true)]
	public static extern bool HP_Client_Send(IntPtr pClient, IntPtr pBuffer, int length);

	[DllImport("HPSocket4C_U.dll", CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern bool HP_Client_SendPart(IntPtr pClient, byte[] pBuffer, int length, int iOffset);

	[DllImport("HPSocket4C_U.dll", SetLastError = true)]
	public static extern bool HP_Client_SendPart(IntPtr pClient, IntPtr pBuffer, int length, int iOffset);

	[DllImport("HPSocket4C_U.dll", SetLastError = true)]
	public static extern bool HP_Client_SendPackets(IntPtr pClient, WSABUF[] pBuffers, int iCount);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Client_SetExtra(IntPtr pClient, IntPtr pExtra);

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr HP_Client_GetExtra(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Client_IsSecure(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Client_HasStarted(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll")]
	public static extern ServiceState HP_Client_GetState(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll")]
	public static extern SocketError HP_Client_GetLastError(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr HP_Client_GetLastErrorDesc(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr HP_Client_GetConnectionID(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Client_GetLocalAddress(IntPtr pClient, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpszAddress, ref int piAddressLen, ref ushort pusPort);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Client_GetRemoteHost(IntPtr pClient, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpszHost, ref int piHostLen, ref ushort pusPort);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Client_GetPendingDataLength(IntPtr pClient, ref int piPending);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Client_SetFreeBufferPoolSize(IntPtr pClient, uint dwFreeBufferPoolSize);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Client_SetFreeBufferPoolHold(IntPtr pClient, uint dwFreeBufferPoolHold);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_Client_GetFreeBufferPoolSize(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_Client_GetFreeBufferPoolHold(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool HP_TcpClient_SendSmallFile(IntPtr pClient, string lpszFileName, ref WSABUF pHead, ref WSABUF pTail);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_TcpClient_SetSocketBufferSize(IntPtr pClient, uint dwSocketBufferSize);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_TcpClient_SetKeepAliveTime(IntPtr pClient, uint dwKeepAliveTime);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_TcpClient_SetKeepAliveInterval(IntPtr pClient, uint dwKeepAliveInterval);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_TcpClient_GetSocketBufferSize(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_TcpClient_GetKeepAliveTime(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_TcpClient_GetKeepAliveInterval(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_UdpClient_SetMaxDatagramSize(IntPtr pClient, uint dwMaxDatagramSize);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_UdpClient_GetMaxDatagramSize(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_UdpClient_SetDetectAttempts(IntPtr pClient, uint dwDetectAttempts);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_UdpClient_SetDetectInterval(IntPtr pClient, uint dwDetectInterval);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_UdpClient_GetDetectAttempts(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_UdpClient_GetDetectInterval(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll", CharSet = CharSet.Unicode)]
	public static extern bool HP_Agent_Start(IntPtr pAgent, string pszBindAddress, bool bAsyncConnect);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Agent_Stop(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool HP_Agent_Connect(IntPtr pAgent, string pszBindAddress, ushort usPort, ref IntPtr pconnId);

	[DllImport("HPSocket4C_U.dll", CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern bool HP_Agent_Send(IntPtr pAgent, IntPtr connId, byte[] pBuffer, int length);

	[DllImport("HPSocket4C_U.dll", SetLastError = true)]
	public static extern bool HP_Agent_Send(IntPtr pAgent, IntPtr connId, IntPtr pBuffer, int length);

	[DllImport("HPSocket4C_U.dll", SetLastError = true)]
	public static extern bool HP_Agent_SendPart(IntPtr pAgent, IntPtr connId, byte[] pBuffer, int length, int iOffset);

	[DllImport("HPSocket4C_U.dll", SetLastError = true)]
	public static extern bool HP_Agent_SendPart(IntPtr pAgent, IntPtr connId, IntPtr pBuffer, int length, int iOffset);

	[DllImport("HPSocket4C_U.dll", SetLastError = true)]
	public static extern bool HP_Agent_SendPackets(IntPtr pAgent, IntPtr connId, WSABUF[] pBuffers, int iCount);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Agent_Disconnect(IntPtr pAgent, IntPtr connId, bool bForce);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Agent_DisconnectLongConnections(IntPtr pAgent, uint dwPeriod, bool bForce);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Agent_DisconnectSilenceConnections(IntPtr pAgent, uint dwPeriod, bool bForce);

	[DllImport("HPSocket4C_U.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool HP_TcpAgent_SendSmallFile(IntPtr pAgent, IntPtr connId, string lpszFileName, ref WSABUF pHead, ref WSABUF pTail);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Agent_SetSendPolicy(IntPtr pAgent, SendPolicy enSendPolicy);

	[DllImport("HPSocket4C_U.dll")]
	public static extern SendPolicy HP_Agent_GetSendPolicy(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Agent_SetConnectionExtra(IntPtr pAgent, IntPtr connId, IntPtr pExtra);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Agent_GetConnectionExtra(IntPtr pAgent, IntPtr connId, ref IntPtr pExtra);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Agent_IsSecure(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Agent_HasStarted(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern ServiceState HP_Agent_GetState(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_Agent_GetConnectionCount(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Agent_GetAllConnectionIDs(IntPtr pAgent, IntPtr[] pIDs, ref uint pdwCount);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Agent_GetConnectPeriod(IntPtr pAgent, IntPtr connId, ref uint pdwPeriod);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Agent_GetSilencePeriod(IntPtr pAgent, IntPtr connId, ref uint pdwPeriod);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Agent_GetLocalAddress(IntPtr pAgent, IntPtr connId, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpszAddress, ref int piAddressLen, ref ushort pusPort);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Agent_GetRemoteAddress(IntPtr pAgent, IntPtr connId, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpszAddress, ref int piAddressLen, ref ushort pusPort);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Agent_GetRemoteHost(IntPtr pAgent, IntPtr dwConnID, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpszAddress, ref int piHostLen, ref ushort pusPort);

	[DllImport("HPSocket4C_U.dll")]
	public static extern SocketError HP_Agent_GetLastError(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr HP_Agent_GetLastErrorDesc(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Agent_GetPendingDataLength(IntPtr pAgent, IntPtr connId, ref int piPending);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Agent_SetFreeSocketObjLockTime(IntPtr pAgent, uint dwFreeSocketObjLockTime);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Agent_SetFreeSocketObjPool(IntPtr pAgent, uint dwFreeSocketObjPool);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Agent_SetFreeBufferObjPool(IntPtr pAgent, uint dwFreeBufferObjPool);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Agent_SetFreeSocketObjHold(IntPtr pAgent, uint dwFreeSocketObjHold);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Agent_SetFreeBufferObjHold(IntPtr pAgent, uint dwFreeBufferObjHold);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Agent_SetMaxConnectionCount(IntPtr pAgent, uint dwMaxConnectionCount);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Agent_SetWorkerThreadCount(IntPtr pAgent, uint dwWorkerThreadCount);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_Agent_SetMarkSilence(IntPtr pAgent, bool bMarkSilence);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_Agent_GetFreeSocketObjLockTime(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_Agent_GetFreeSocketObjPool(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_Agent_GetFreeBufferObjPool(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_Agent_GetFreeSocketObjHold(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_Agent_GetFreeBufferObjHold(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_Agent_GetMaxConnectionCount(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_Agent_GetWorkerThreadCount(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Agent_IsMarkSilence(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_TcpAgent_SetReuseAddress(IntPtr pAgent, bool bReuseAddress);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_TcpAgent_IsReuseAddress(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_TcpAgent_SetSocketBufferSize(IntPtr pAgent, uint dwSocketBufferSize);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_TcpAgent_SetKeepAliveTime(IntPtr pAgent, uint dwKeepAliveTime);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_TcpAgent_SetKeepAliveInterval(IntPtr pAgent, uint dwKeepAliveInterval);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_TcpAgent_GetSocketBufferSize(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_TcpAgent_GetKeepAliveTime(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_TcpAgent_GetKeepAliveInterval(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern FetchResult HP_TcpPullServer_Fetch(IntPtr pServer, IntPtr connId, IntPtr pBuffer, int length);

	[DllImport("HPSocket4C_U.dll")]
	public static extern FetchResult HP_TcpPullServer_Peek(IntPtr pServer, IntPtr connId, IntPtr pBuffer, int length);

	[DllImport("HPSocket4C_U.dll")]
	public static extern FetchResult HP_TcpPullClient_Fetch(IntPtr pClient, IntPtr pBuffer, int length);

	[DllImport("HPSocket4C_U.dll")]
	public static extern FetchResult HP_TcpPullClient_Peek(IntPtr pClient, IntPtr pBuffer, int length);

	[DllImport("HPSocket4C_U.dll")]
	public static extern FetchResult HP_TcpPullAgent_Fetch(IntPtr pAgent, IntPtr connId, IntPtr pBuffer, int length);

	[DllImport("HPSocket4C_U.dll")]
	public static extern FetchResult HP_TcpPullAgent_Peek(IntPtr pAgent, IntPtr connId, IntPtr pBuffer, int length);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_TcpPackServer_SetMaxPackSize(IntPtr pServer, uint dwMaxPackSize);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_TcpPackServer_SetPackHeaderFlag(IntPtr pServer, ushort usPackHeaderFlag);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_TcpPackServer_GetMaxPackSize(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern ushort HP_TcpPackServer_GetPackHeaderFlag(IntPtr pServer);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_TcpPackAgent_SetMaxPackSize(IntPtr pAgent, uint dwMaxPackSize);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_TcpPackAgent_SetPackHeaderFlag(IntPtr pAgent, ushort usPackHeaderFlag);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_TcpPackAgent_GetMaxPackSize(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern ushort HP_TcpPackAgent_GetPackHeaderFlag(IntPtr pAgent);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_TcpPackClient_SetMaxPackSize(IntPtr pClient, uint dwMaxPackSize);

	[DllImport("HPSocket4C_U.dll")]
	public static extern void HP_TcpPackClient_SetPackHeaderFlag(IntPtr pClient, ushort usPackHeaderFlag);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_TcpPackClient_GetMaxPackSize(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll")]
	public static extern ushort HP_TcpPackClient_GetPackHeaderFlag(IntPtr pClient);

	[DllImport("HPSocket4C_U.dll")]
	public static extern uint HP_GetHPSocketVersion();

	public static string GetHPSocketVersion()
	{
		uint num = HP_GetHPSocketVersion();
		return $"{num >> 24}.{num << 8 >> 24}.{num << 16 >> 24}_{num << 24 >> 24}";
	}

	[DllImport("HPSocket4C_U.dll")]
	public static extern IntPtr HP_GetSocketErrorDesc(SocketError enCode);

	public static int SYS_GetLastError()
	{
		return Marshal.GetLastWin32Error();
	}

	[DllImport("HPSocket4C_U.dll", SetLastError = true)]
	public static extern int SYS_WSAGetLastError();

	[DllImport("HPSocket4C_U.dll", SetLastError = true)]
	public static extern int SYS_SetSocketOption(IntPtr sock, int level, int name, IntPtr val, int len);

	[DllImport("HPSocket4C_U.dll", SetLastError = true)]
	public static extern int SYS_GetSocketOption(IntPtr sock, int level, int name, IntPtr val, ref int len);

	[DllImport("HPSocket4C_U.dll", SetLastError = true)]
	public static extern int SYS_IoctlSocket(IntPtr sock, long cmd, IntPtr arg);

	[DllImport("HPSocket4C_U.dll", SetLastError = true)]
	public static extern int SYS_WSAIoctl(IntPtr sock, uint dwIoControlCode, IntPtr lpvInBuffer, uint cbInBuffer, IntPtr lpvOutBuffer, uint cbOutBuffer, uint lpcbBytesReturned);

	[DllImport("HPSocket4C_U.dll")]
	public static extern int SYS_SSO_NoDelay(IntPtr sock, bool bNoDelay);

	[DllImport("HPSocket4C_U.dll")]
	public static extern int SYS_SSO_DontLinger(IntPtr sock, bool bDont);

	[DllImport("HPSocket4C_U.dll")]
	public static extern int SYS_SSO_Linger(IntPtr sock, ushort l_onoff, ushort l_linger);

	[DllImport("HPSocket4C_U.dll")]
	public static extern int SYS_SSO_RecvBuffSize(IntPtr sock, int size);

	[DllImport("HPSocket4C_U.dll")]
	public static extern int SYS_SSO_SendBuffSize(IntPtr sock, int size);

	[DllImport("HPSocket4C_U.dll")]
	public static extern int SYS_SSO_ReuseAddress(IntPtr sock, bool bReuse);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool SYS_GetSocketLocalAddress(IntPtr pSocket, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpszAddress, ref int piAddressLen, ref ushort pusPort);

	[DllImport("HPSocket4C_U.dll")]
	public static extern bool HP_Server_GetRemoteAddress(IntPtr pSocket, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpszAddress, ref int piAddressLen, ref ushort pusPort);

	[DllImport("HPSocket4C_U.dll", CharSet = CharSet.Unicode)]
	public static extern uint SYS_GetIPv4InAddr(string lpszAddress);

	[DllImport("HPSocket4C_U.dll", CharSet = CharSet.Unicode)]
	public static extern bool SYS_IsIPAddress(string lpszAddress);

	[DllImport("HPSocket4C_U.dll", CharSet = CharSet.Unicode)]
	public static extern bool SYS_GetIPAddress(string lpszHost, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpszIP, ref int piIPLenth);

	[DllImport("HPSocket4C_U.dll", CharSet = CharSet.Unicode)]
	public static extern bool SYS_GetOptimalIPByHostName(string lpszHost, ref uint pulAddr);

	[DllImport("HPSocket4C_U.dll")]
	public static extern ulong SYS_NToH64(ulong value);

	[DllImport("HPSocket4C_U.dll")]
	public static extern ulong SYS_HToN64(ulong value);
}
