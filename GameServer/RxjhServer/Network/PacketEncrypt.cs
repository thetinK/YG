using System;
using System.Runtime.InteropServices;

namespace RxjhServer.Network
{
	public class PacketEncrypt
	{
		private readonly IntPtr _obj;

		private readonly object _lock = new object();

		[DllImport("ep.dll")]
		private static extern IntPtr GetObj();

		[DllImport("ep.dll")]
		private static extern void DisObj(IntPtr obj);

		[DllImport("ep.dll")]
		private static extern void ResetKey(IntPtr obj);

		[DllImport("ep.dll")]
		private static extern void SetKey(IntPtr obj, [In] byte[] key, int length);

		[DllImport("ep.dll")]
		private static extern void Decrypti(IntPtr obj, [In][Out] byte[] data, int length);

		public PacketEncrypt()
		{
			_obj = GetObj();
		}

		~PacketEncrypt()
		{
			DisObj(_obj);
		}

		public void Reset()
		{
			ResetKey(_obj);
		}

		public void Set(byte[] key)
		{
			lock (_lock)
			{
				SetKey(_obj, key, key.Length);
			}
		}

		public void Dec(byte[] data)
		{
			lock (_lock)
			{
				Decrypti(_obj, data, data.Length);
			}
		}
	}
}
