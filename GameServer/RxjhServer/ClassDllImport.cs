using System;
using System.Runtime.InteropServices;

namespace RxjhServer
{
	public class ClassDllImport
	{
		public delegate int Decrypt(byte[] lpBuffer, int nDataLength);

		private static IntPtr instance;

		[DllImport("Kernel32.dll")]
		public static extern IntPtr LoadLibrary(string lpFileName);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern int GetProcAddress(IntPtr hModule, string lpProcName);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool FreeLibrary(IntPtr hModule);

		private static Delegate GetAddress(IntPtr dllModule, string functionname, Type t)
		{
			int procAddress = GetProcAddress(instance, functionname);
			return (procAddress != 0) ? Marshal.GetDelegateForFunctionPointer(new IntPtr(procAddress), t) : null;
		}

		public static void LoadLib()
		{
			instance = LoadLibrary("rxjhDeBuf.dll");
			if (instance.ToInt32() == 0)
			{
				MainForm.WriteLine(1, "rxjhDeBuf.dll不存在或无法加载！");
			}
		}

		public static void FreeLib()
		{
			FreeLibrary(instance);
		}

		public static void DecryptaBK(byte[] lpBuffer, int nDataLength)
		{
			try
			{
				int num = ((Decrypt)GetAddress(instance, "Decrypt", typeof(Decrypt)))(lpBuffer, nDataLength);
			}
			catch
			{
				MainForm.WriteLine(1, "rxjhDeBuf.dll版本错误");
			}
		}
	}
}
