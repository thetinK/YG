using System;
using System.Diagnostics;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace RxjhServer
{
	public class Hasher
	{
		public struct CPU_INFO
		{
			public uint dwOemId;

			public uint dwPageSize;

			public uint lpMinimumApplicationAddress;

			public uint lpMaximumApplicationAddress;

			public uint dwActiveProcessorMask;

			public uint dwNumberOfProcessors;

			public uint dwProcessorType;

			public uint dwAllocationGranularity;

			public uint dwProcessorLevel;

			public uint dwProcessorRevision;
		}

		[DllImport("kernel32")]
		public static extern void GetSystemInfo(ref CPU_INFO cpuinfo);

		public static string GetCpuID()
		{
			try
			{
				ManagementObjectCollection instances = new ManagementClass("Win32_Processor").GetInstances();
				string result = "BFEBFBFF000206A7";
				using (ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = instances.GetEnumerator())
				{
					if (managementObjectEnumerator.MoveNext())
					{
						result = managementObjectEnumerator.Current.Properties["ProcessorId"].Value.ToString();
					}
				}
				return result;
			}
			catch
			{
				return "BFEBFBFF000206A7";
			}
		}

		public static string GetIP()
		{
			try
			{
				IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
				for (int i = 0; i < hostEntry.AddressList.Length; i++)
				{
					if (hostEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
					{
						return hostEntry.AddressList[i].ToString();
					}
				}
				return string.Empty;
			}
			catch
			{
				return string.Empty;
			}
		}

		public static string GetMac()
		{
			string result = string.Empty;
			try
			{
				foreach (ManagementObject instance in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
				{
					if (instance["IPEnabled"].ToString() == "True")
					{
						result = instance["MacAddress"].ToString();
					}
				}
			}
			catch
			{
				result = string.Empty;
			}
			return result;
		}

		[DllImport("kernel32.dll")]
		private static extern int GetVolumeInformation(string lpRootPathName, string lpVolumeNameBuffer, int nVolumeNameSize, ref int lpVolumeSerialNumber, int lpMaximumComponentLength, int lpFileSystemFlags, string lpFileSystemNameBuffer, int nFileSystemNameSize);

		public static string GetDriveID(string drvID)
		{
			try
			{
				return AtapiDevicea.getHad();
			}
			catch (Exception)
			{
				return "0";
			}
		}

		public static string cmd(string cmd)
		{
			string empty = string.Empty;
			string result;
			try
			{
				Process process = new Process();
				process.StartInfo.FileName = "cmd.exe";
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardInput = true;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.CreateNoWindow = true;
				process.Start();
				process.StandardInput.WriteLine(cmd);
				process.StandardInput.WriteLine("exit");
				result = process.StandardOutput.ReadToEnd();
				process.Close();
			}
			catch (Exception ex)
			{
				result = "执行DOS命令错误" + ex.Message.ToString();
			}
			return result;
		}
	}
}
