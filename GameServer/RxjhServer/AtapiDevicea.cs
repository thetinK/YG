using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RxjhServer
{
	public class AtapiDevicea
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int CloseHandle(IntPtr hObject);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

		[DllImport("kernel32.dll")]
		private static extern int DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, IntPtr lpInBuffer, uint nInBufferSize, ref GetVersionOutParams lpOutBuffer, uint nOutBufferSize, ref uint lpBytesReturned, [Out] IntPtr lpOverlapped);

		[DllImport("kernel32.dll")]
		private static extern int DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, ref SendCmdInParams lpInBuffer, uint nInBufferSize, ref SendCmdOutParams lpOutBuffer, uint nOutBufferSize, ref uint lpBytesReturned, [Out] IntPtr lpOverlapped);

		public static HardDiskInfo GetHddInfo(byte driveIndex)
		{
			PlatformID platform = Environment.OSVersion.Platform;
			if (1 == 0)
			{
			}
			HardDiskInfo result = platform switch
			{
				PlatformID.Win32S => throw new NotSupportedException("Win32s is not supported."), 
				PlatformID.Win32Windows => GetHddInfo9x(driveIndex), 
				PlatformID.Win32NT => GetHddInfoNT(driveIndex), 
				PlatformID.WinCE => throw new NotSupportedException("WinCE is not supported."), 
				_ => throw new NotSupportedException("Unknown Platform."), 
			};
			if (1 == 0)
			{
			}
			return result;
		}

		private static HardDiskInfo GetHddInfo9x(byte driveIndex)
		{
			GetVersionOutParams lpOutBuffer = default(GetVersionOutParams);
			SendCmdInParams lpInBuffer = default(SendCmdInParams);
			SendCmdOutParams lpOutBuffer2 = default(SendCmdOutParams);
			uint lpBytesReturned = 0u;
			IntPtr intPtr = CreateFile("\\\\.\\Smartvsd", 0u, 0u, IntPtr.Zero, 1u, 0u, IntPtr.Zero);
			if (intPtr == IntPtr.Zero)
			{
				throw new Exception("Open smartvsd.vxd failed.");
			}
			if (DeviceIoControl(intPtr, 475264u, IntPtr.Zero, 0u, ref lpOutBuffer, (uint)Marshal.SizeOf(lpOutBuffer), ref lpBytesReturned, IntPtr.Zero) == 0)
			{
				CloseHandle(intPtr);
				throw new Exception("DeviceIoControl failed:DFP_GET_VERSION");
			}
			if ((lpOutBuffer.fCapabilities & 1) == 0)
			{
				CloseHandle(intPtr);
				throw new Exception("Error: IDE identify command not supported.");
			}
			if (((uint)driveIndex & (true ? 1u : 0u)) != 0)
			{
				lpInBuffer.irDriveRegs.bDriveHeadReg = 176;
			}
			else
			{
				lpInBuffer.irDriveRegs.bDriveHeadReg = 160;
			}
			if ((lpOutBuffer.fCapabilities & (16 >> (int)driveIndex)) != 0)
			{
				CloseHandle(intPtr);
				throw new Exception($"Drive {driveIndex + 1} is a ATAPI device, we don't detect it");
			}
			lpInBuffer.irDriveRegs.bCommandReg = 236;
			lpInBuffer.bDriveNumber = driveIndex;
			lpInBuffer.irDriveRegs.bSectorCountReg = 1;
			lpInBuffer.irDriveRegs.bSectorNumberReg = 1;
			lpInBuffer.cBufferSize = 512u;
			if (DeviceIoControl(intPtr, 508040u, ref lpInBuffer, (uint)Marshal.SizeOf(lpInBuffer), ref lpOutBuffer2, (uint)Marshal.SizeOf(lpOutBuffer2), ref lpBytesReturned, IntPtr.Zero) == 0)
			{
				CloseHandle(intPtr);
				throw new Exception("DeviceIoControl failed: DFP_RECEIVE_DRIVE_DATA");
			}
			CloseHandle(intPtr);
			return GetHardDiskInfo(lpOutBuffer2.bBuffer);
		}

		private static HardDiskInfo GetHddInfoNT(byte driveIndex)
		{
			GetVersionOutParams lpOutBuffer = default(GetVersionOutParams);
			SendCmdInParams lpInBuffer = default(SendCmdInParams);
			SendCmdOutParams lpOutBuffer2 = default(SendCmdOutParams);
			uint lpBytesReturned = 0u;
			IntPtr intPtr = CreateFile($"\\\\.\\PhysicalDrive{driveIndex}", 3221225472u, 3u, IntPtr.Zero, 3u, 0u, IntPtr.Zero);
			if (intPtr == IntPtr.Zero)
			{
				throw new Exception("CreateFile faild.");
			}
			if (DeviceIoControl(intPtr, 475264u, IntPtr.Zero, 0u, ref lpOutBuffer, (uint)Marshal.SizeOf(lpOutBuffer), ref lpBytesReturned, IntPtr.Zero) == 0)
			{
				CloseHandle(intPtr);
				throw new Exception($"Drive {driveIndex + 1} may not exists.");
			}
			if ((lpOutBuffer.fCapabilities & 1) == 0)
			{
				CloseHandle(intPtr);
				throw new Exception("Error: IDE identify command not supported.");
			}
			if (((uint)driveIndex & (true ? 1u : 0u)) != 0)
			{
				lpInBuffer.irDriveRegs.bDriveHeadReg = 176;
			}
			else
			{
				lpInBuffer.irDriveRegs.bDriveHeadReg = 160;
			}
			if ((lpOutBuffer.fCapabilities & (16 >> (int)driveIndex)) != 0)
			{
				CloseHandle(intPtr);
				throw new Exception($"Drive {driveIndex + 1} is a ATAPI device, we don't detect it.");
			}
			lpInBuffer.irDriveRegs.bCommandReg = 236;
			lpInBuffer.bDriveNumber = driveIndex;
			lpInBuffer.irDriveRegs.bSectorCountReg = 1;
			lpInBuffer.irDriveRegs.bSectorNumberReg = 1;
			lpInBuffer.cBufferSize = 512u;
			if (DeviceIoControl(intPtr, 508040u, ref lpInBuffer, (uint)Marshal.SizeOf(lpInBuffer), ref lpOutBuffer2, (uint)Marshal.SizeOf(lpOutBuffer2), ref lpBytesReturned, IntPtr.Zero) == 0)
			{
				CloseHandle(intPtr);
				throw new Exception("DeviceIoControl failed: DFP_RECEIVE_DRIVE_DATA");
			}
			CloseHandle(intPtr);
			return GetHardDiskInfo(lpOutBuffer2.bBuffer);
		}

		private static HardDiskInfo GetHardDiskInfo(IdSector phdinfo)
		{
			HardDiskInfo result = default(HardDiskInfo);
			ChangeByteOrder(phdinfo.sModelNumber);
			result.ModuleNumber = Encoding.ASCII.GetString(phdinfo.sModelNumber).Trim();
			ChangeByteOrder(phdinfo.sFirmwareRev);
			result.Firmware = Encoding.ASCII.GetString(phdinfo.sFirmwareRev).Trim();
			ChangeByteOrder(phdinfo.sSerialNumber);
			result.SerialNumber = Encoding.ASCII.GetString(phdinfo.sSerialNumber).Trim();
			result.Capacity = phdinfo.ulTotalAddressableSectors / 2u / 1024u;
			return result;
		}

		private static void ChangeByteOrder(byte[] charArray)
		{
			for (int i = 0; i < charArray.Length; i += 2)
			{
				byte b = charArray[i];
				charArray[i] = charArray[i + 1];
				charArray[i + 1] = b;
			}
		}

		public static string getHad()
		{
			try
			{
				return GetHddInfo(0).SerialNumber;
			}
			catch (Exception)
			{
				return "0";
			}
		}
	}
}
