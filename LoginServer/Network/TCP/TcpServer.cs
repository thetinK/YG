using Core;
using Network.Protocol;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Utilities;

namespace Network.TCP
{
	public class TcpServer : ConnectionExtra
	{
		protected IntPtr _pServer = IntPtr.Zero;

		protected IntPtr pListener = IntPtr.Zero;

		protected bool IsCreate;

		protected Sdk.OnPrepareListen _OnPrepareListen;

		protected Sdk.OnAccept _OnAccept;

		protected Sdk.OnReceive _OnReceive;

		protected Sdk.OnSend _OnSend;

		protected Sdk.OnClose _OnClose;

		protected Sdk.OnShutdown _OnShutdown;

		protected Sdk.OnHandShake _OnHandShake;

		protected IntPtr pServer
		{
			get
			{
				return _pServer;
			}
			set
			{
				_pServer = value;
			}
		}

		public string IpAddress { get; set; }

		public ushort Port { get; set; }

		public bool IsStarted
		{
			get
			{
				if (!(pServer == IntPtr.Zero))
				{
					return Sdk.HP_Server_HasStarted(pServer);
				}
				return false;
			}
		}

		public ServiceState State => Sdk.HP_Server_GetState(pServer);

		public uint ConnectionCount => Sdk.HP_Server_GetConnectionCount(pServer);

		public bool IsSecure => Sdk.HP_Server_IsSecure(pServer);

		public uint MaxConnectionCount
		{
			get
			{
				return Sdk.HP_Server_GetMaxConnectionCount(pServer);
			}
			set
			{
				Sdk.HP_Server_SetMaxConnectionCount(pServer, value);
			}
		}

		public uint WorkerThreadCount
		{
			get
			{
				return Sdk.HP_Server_GetWorkerThreadCount(pServer);
			}
			set
			{
				Sdk.HP_Server_SetWorkerThreadCount(pServer, value);
			}
		}

		public uint AcceptSocketCount
		{
			get
			{
				return Sdk.HP_TcpServer_GetAcceptSocketCount(pServer);
			}
			set
			{
				Sdk.HP_TcpServer_SetAcceptSocketCount(pServer, value);
			}
		}

		public uint SocketBufferSize
		{
			get
			{
				return Sdk.HP_TcpServer_GetSocketBufferSize(pServer);
			}
			set
			{
				Sdk.HP_TcpServer_SetSocketBufferSize(pServer, value);
			}
		}

		public uint SocketListenQueue
		{
			get
			{
				return Sdk.HP_TcpServer_GetSocketListenQueue(pServer);
			}
			set
			{
				Sdk.HP_TcpServer_SetSocketListenQueue(pServer, value);
			}
		}

		public uint FreeSocketObjLockTime
		{
			get
			{
				return Sdk.HP_Server_GetFreeSocketObjLockTime(pServer);
			}
			set
			{
				Sdk.HP_Server_SetFreeSocketObjLockTime(pServer, value);
			}
		}

		public uint FreeSocketObjPool
		{
			get
			{
				return Sdk.HP_Server_GetFreeSocketObjPool(pServer);
			}
			set
			{
				Sdk.HP_Server_SetFreeSocketObjPool(pServer, value);
			}
		}

		public uint FreeBufferObjPool
		{
			get
			{
				return Sdk.HP_Server_GetFreeBufferObjPool(pServer);
			}
			set
			{
				Sdk.HP_Server_SetFreeBufferObjPool(pServer, value);
			}
		}

		public uint FreeSocketObjHold
		{
			get
			{
				return Sdk.HP_Server_GetFreeSocketObjHold(pServer);
			}
			set
			{
				Sdk.HP_Server_SetFreeSocketObjHold(pServer, value);
			}
		}

		public uint FreeBufferObjHold
		{
			get
			{
				return Sdk.HP_Server_GetFreeBufferObjHold(pServer);
			}
			set
			{
				Sdk.HP_Server_SetFreeBufferObjHold(pServer, value);
			}
		}

		public uint KeepAliveTime
		{
			get
			{
				return Sdk.HP_TcpServer_GetKeepAliveTime(pServer);
			}
			set
			{
				Sdk.HP_TcpServer_SetKeepAliveTime(pServer, value);
			}
		}

		public uint KeepAliveInterval
		{
			get
			{
				return Sdk.HP_TcpServer_GetKeepAliveInterval(pServer);
			}
			set
			{
				Sdk.HP_TcpServer_SetKeepAliveInterval(pServer, value);
			}
		}

		public bool MarkSilence
		{
			get
			{
				return Sdk.HP_Server_IsMarkSilence(pServer);
			}
			set
			{
				Sdk.HP_Server_SetMarkSilence(pServer, value);
			}
		}

		public SendPolicy SendPolicy
		{
			get
			{
				return Sdk.HP_Server_GetSendPolicy(pServer);
			}
			set
			{
				Sdk.HP_Server_SetSendPolicy(pServer, value);
			}
		}

		public SocketError ErrorCode => Sdk.HP_Server_GetLastError(pServer);

		public string Version => Sdk.GetHPSocketVersion();

		public string ErrorMessage => Marshal.PtrToStringUni(Sdk.HP_Server_GetLastErrorDesc(pServer));

		public event TcpServerEvent.OnAcceptEventHandler OnAccept;

		public event TcpServerEvent.OnSendEventHandler OnSend;

		public event TcpServerEvent.OnPrepareListenEventHandler OnPrepareListen;

		public event TcpServerEvent.OnReceiveEventHandler OnReceive;

		public event TcpServerEvent.OnPointerDataReceiveEventHandler OnPointerDataReceive;

		public event TcpServerEvent.OnCloseEventHandler OnClose;

		public event TcpServerEvent.OnShutdownEventHandler OnShutdown;

		public event TcpServerEvent.OnHandShakeEventHandler OnHandShake;

		public TcpServer()
		{
			CreateListener();
		}

		~TcpServer()
		{
			Destroy();
		}

		protected virtual bool CreateListener()
		{
			if (IsCreate || pListener != IntPtr.Zero || pServer != IntPtr.Zero)
			{
				return false;
			}
			pListener = Sdk.Create_HP_TcpServerListener();
			if (pListener == IntPtr.Zero)
			{
				return false;
			}
			pServer = Sdk.Create_HP_TcpServer(pListener);
			if (pServer == IntPtr.Zero)
			{
				return false;
			}
			IsCreate = true;
			return true;
		}

		public virtual void Destroy()
		{
			Destroying();
			if (pServer != IntPtr.Zero)
			{
				Sdk.Destroy_HP_TcpServer(pServer);
				pServer = IntPtr.Zero;
			}
			if (pListener != IntPtr.Zero)
			{
				Sdk.Destroy_HP_TcpServerListener(pListener);
				pListener = IntPtr.Zero;
			}
			IsCreate = false;
		}

		public bool Start(int StartID)
		{
			if (!IsCreate || IsStarted)
			{
				return false;
			}
			ushort usServerID = (ushort)StartID;
			SetCallback();
			World.ServerIDStart++;
			return Sdk.HP_Server_Start(pServer, IpAddress, Port, usServerID);
		}

		public bool Stop()
		{
			if (IsStarted)
			{
				return Sdk.HP_Server_Stop(pServer);
			}
			return false;
		}

		public bool Destroying()
		{
			if (IsStarted)
			{
				return Sdk.HP_Server_Destroying(pServer);
			}
			return false;
		}

		public bool Send(IntPtr connId, byte[] bytes, int size)
		{
			return Sdk.HP_Server_Send(pServer, connId, bytes, size);
		}

		public bool Send(IntPtr connId, IntPtr bufferPtr, int size)
		{
			return Sdk.HP_Server_Send(pServer, connId, bufferPtr, size);
		}

		public bool Send(IntPtr connId, byte[] bytes, int offset, int size)
		{
			return Sdk.HP_Server_SendPart(pServer, connId, bytes, size, offset);
		}

		public bool Send(IntPtr connId, IntPtr bufferPtr, int offset, int size)
		{
			return Sdk.HP_Server_SendPart(pServer, connId, bufferPtr, size, offset);
		}

		public bool Send<T>(IntPtr connId, T obj)
		{
			byte[] array = StructureToByte(obj);
			return Send(connId, array, array.Length);
		}

		public bool SendBySerializable(IntPtr connId, object obj)
		{
			byte[] array = ObjectToBytes(obj);
			return Send(connId, array, array.Length);
		}

		public bool SendPackets(IntPtr connId, WSABUF[] pBuffers, int count)
		{
			return Sdk.HP_Server_SendPackets(pServer, connId, pBuffers, count);
		}

		public bool SendPackets<T>(IntPtr connId, T[] objects)
		{
			WSABUF[] array = new WSABUF[objects.Length];
			IntPtr[] array2 = new IntPtr[array.Length];
			try
			{
				for (int i = 0; i < objects.Length; i++)
				{
					array[i].Length = Marshal.SizeOf(typeof(T));
					array2[i] = Marshal.AllocHGlobal(array[i].Length);
					Marshal.StructureToPtr((object)objects[i], array2[i], fDeleteOld: true);
					array[i].Buffer = array2[i];
				}
				return SendPackets(connId, array, array.Length);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				for (int j = 0; j < array2.Length; j++)
				{
					if (array2[j] != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(array2[j]);
					}
				}
			}
		}

		public bool SendSmallFile(IntPtr connId, string filePath, ref WSABUF head, ref WSABUF tail)
		{
			return Sdk.HP_TcpServer_SendSmallFile(pServer, connId, filePath, ref head, ref tail);
		}

		public bool SendSmallFile(IntPtr connId, string filePath, byte[] head, byte[] tail)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			WSABUF wSABUF = default;
			wSABUF.Length = 0;
			wSABUF.Buffer = zero;
			WSABUF head2 = wSABUF;
			wSABUF = default;
			wSABUF.Length = 0;
			wSABUF.Buffer = zero2;
			WSABUF tail2 = wSABUF;
			if (head != null)
			{
				head2.Length = head.Length;
				head2.Buffer = Marshal.UnsafeAddrOfPinnedArrayElement((Array)head, 0);
			}
			if (tail != null)
			{
				head2.Length = tail.Length;
				head2.Buffer = Marshal.UnsafeAddrOfPinnedArrayElement((Array)tail, 0);
			}
			return SendSmallFile(connId, filePath, ref head2, ref tail2);
		}

		public bool SendSmallFile<T1, T2>(IntPtr connId, string filePath, T1 head, T2 tail)
		{
			byte[] head2 = null;
			if (head != null)
			{
				head2 = StructureToByte(head);
			}
			byte[] tail2 = null;
			if (tail != null)
			{
				tail2 = StructureToByte(tail);
			}
			return SendSmallFile(connId, filePath, head2, tail2);
		}

		public bool Disconnect(IntPtr connId, bool force = true)
		{
			return Sdk.HP_Server_Disconnect(pServer, connId, force);
		}

		public bool DisconnectLongConnections(uint period, bool force = true)
		{
			return Sdk.HP_Server_DisconnectLongConnections(pServer, period, force);
		}

		public bool DisconnectSilenceConnections(uint period, bool force = true)
		{
			return Sdk.HP_Server_DisconnectSilenceConnections(pServer, period, force);
		}

		public bool GetLocalAddress(IntPtr connId, ref string ip, ref ushort port)
		{
			int piAddressLen = 40;
			StringBuilder stringBuilder = new StringBuilder(piAddressLen);
			int num;
			if (Sdk.HP_Server_GetLocalAddress(pServer, connId, stringBuilder, ref piAddressLen, ref port))
			{
				num = piAddressLen > 0 ? 1 : 0;
				if (num != 0)
				{
					ip = stringBuilder.ToString();
				}
			}
			else
			{
				num = 0;
			}
			return (byte)num != 0;
		}

		public bool GetRemoteAddress(IntPtr connId, ref string ip, ref ushort port)
		{
			int piAddressLen = 40;
			StringBuilder stringBuilder = new StringBuilder(piAddressLen);
			int num;
			if (Sdk.HP_Server_GetRemoteAddress(pServer, connId, stringBuilder, ref piAddressLen, ref port))
			{
				num = piAddressLen > 0 ? 1 : 0;
				if (num != 0)
				{
					ip = stringBuilder.ToString();
				}
			}
			else
			{
				num = 0;
			}
			return (byte)num != 0;
		}

		public bool GetPendingDataLength(IntPtr connId, ref int length)
		{
			return Sdk.HP_Server_GetPendingDataLength(pServer, connId, ref length);
		}

		public bool GetListenAddress(ref string ip, ref ushort port)
		{
			int piAddressLen = 40;
			StringBuilder stringBuilder = new StringBuilder(piAddressLen);
			bool num = Sdk.HP_Server_GetListenAddress(pServer, stringBuilder, ref piAddressLen, ref port);
			if (num)
			{
				ip = stringBuilder.ToString();
			}
			return num;
		}

		public bool GetConnectPeriod(IntPtr connId, ref uint period)
		{
			return Sdk.HP_Server_GetConnectPeriod(pServer, connId, ref period);
		}

		public bool GetSilencePeriod(IntPtr connId, ref uint period)
		{
			return Sdk.HP_Server_GetSilencePeriod(pServer, connId, ref period);
		}

		public int SYSGetLastError()
		{
			return Sdk.SYS_GetLastError();
		}

		public int SYSWSAGetLastError()
		{
			return Sdk.SYS_WSAGetLastError();
		}

		protected virtual void SetCallback()
		{
			_OnPrepareListen = SDK_OnPrepareListen;
			_OnAccept = SDK_OnAccept;
			_OnSend = SDK_OnSend;
			_OnReceive = SDK_OnReceive;
			_OnClose = SDK_OnClose;
			_OnShutdown = SDK_OnShutdown;
			_OnHandShake = SDK_OnHandShake;
			Sdk.HP_Set_FN_Server_OnPrepareListen(pListener, _OnPrepareListen);
			Sdk.HP_Set_FN_Server_OnAccept(pListener, _OnAccept);
			Sdk.HP_Set_FN_Server_OnSend(pListener, _OnSend);
			Sdk.HP_Set_FN_Server_OnReceive(pListener, _OnReceive);
			Sdk.HP_Set_FN_Server_OnClose(pListener, _OnClose);
			Sdk.HP_Set_FN_Server_OnShutdown(pListener, _OnShutdown);
			Sdk.HP_Set_FN_Server_OnHandShake(pListener, _OnHandShake);
		}

		protected HandleResult SDK_OnHandShake(IntPtr pSender, IntPtr connId)
		{
			if (OnHandShake == null)
			{
				return HandleResult.Ignore;
			}
			return OnHandShake(connId);
		}

		protected HandleResult SDK_OnPrepareListen(IntPtr pSender, IntPtr soListen)
		{
			if (OnPrepareListen == null)
			{
				return HandleResult.Ignore;
			}
			return OnPrepareListen(soListen);
		}

		protected HandleResult SDK_OnAccept(IntPtr pSender, IntPtr connId, IntPtr pClient)
		{
			if (OnAccept == null)
			{
				return HandleResult.Ignore;
			}
			return OnAccept(connId, pClient);
		}

		protected HandleResult SDK_OnSend(IntPtr pSender, IntPtr connId, IntPtr pData, int length)
		{
			if (OnSend == null)
			{
				return HandleResult.Ignore;
			}
			byte[] array = new byte[length];
			Marshal.Copy(pData, array, 0, length);
			return OnSend(connId, array);
		}

		protected HandleResult SDK_OnReceive(IntPtr pSender, IntPtr connId, IntPtr pData, int length)
		{
			if (OnPointerDataReceive != null)
			{
				return OnPointerDataReceive(connId, pData, length);
			}
			if (OnReceive == null)
			{
				return HandleResult.Ignore;
			}
			byte[] array = new byte[length];
			Marshal.Copy(pData, array, 0, length);
			return OnReceive(connId, array);
		}

		protected HandleResult SDK_OnClose(IntPtr pSender, IntPtr connId, SocketOperation enOperation, int errorCode)
		{
			if (OnClose == null)
			{
				return HandleResult.Ignore;
			}
			return OnClose(connId, enOperation, errorCode);
		}

		protected HandleResult SDK_OnShutdown(IntPtr pSender)
		{
			if (OnShutdown == null)
			{
				return HandleResult.Ignore;
			}
			return OnShutdown();
		}

		public byte[] StructureToByte<T>(T structure)
		{
			int num = Marshal.SizeOf(typeof(T));
			byte[] array = new byte[num];
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			try
			{
				Marshal.StructureToPtr((object)structure, intPtr, fDeleteOld: true);
				Marshal.Copy(intPtr, array, 0, num);
				return array;
			}
			finally
			{
				Marshal.FreeHGlobal(intPtr);
			}
		}

		public byte[] ObjectToBytes(object obj)
		{
			using MemoryStream memoryStream = new MemoryStream();
			new BinaryFormatter().Serialize(memoryStream, obj);
			return memoryStream.GetBuffer();
		}
	}
}
