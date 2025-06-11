using System.Runtime.InteropServices;

namespace RxjhServer
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct SendCmdOutParams
	{
		public uint cBufferSize;

		public DriverStatus DriverStatus;

		public IdSector bBuffer;
	}
}
