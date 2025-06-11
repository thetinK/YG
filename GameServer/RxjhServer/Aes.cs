using System;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace RxjhServer
{
	public class Aes
	{
		public const string Key1 = "QWEDCVBGHYTRDSGHJKGFD123568GFFSA";

		public const string Key2 = "dfgiuyt1235whgfyjlkmnhttrtiudsfa";

		public static string Decrypt(string key, string code)
		{
			try
			{
				using AesManaged aesManaged = new AesManaged();
				byte[] array4 = (aesManaged.Key = Encoding.ASCII.GetBytes(key));
				byte[] array = array4;
				byte[] array2 = array;
				byte[] array3 = array2;
				byte[] source = array3;
				aesManaged.IV = source.Take(16).ToArray();
				byte[] cipherText = Convert.FromBase64String(code);
				return DecryptStringFromBytes_Aes(cipherText, aesManaged.Key, aesManaged.IV);
			}
			catch
			{
				return null;
			}
		}

		public static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
		{
			if (cipherText == null || cipherText.Length == 0)
			{
				return null;
			}
			if (Key == null || Key.Length == 0)
			{
				return null;
			}
			if (IV == null || IV.Length == 0)
			{
				return null;
			}
			string result = null;
			using (AesManaged aesManaged = new AesManaged())
			{
				aesManaged.Key = Key;
				aesManaged.IV = IV;
				ICryptoTransform transform = aesManaged.CreateDecryptor(aesManaged.Key, aesManaged.IV);
				using MemoryStream stream = new MemoryStream(cipherText);
				using CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
				using StreamReader streamReader = new StreamReader(stream2);
				result = streamReader.ReadToEnd();
			}
			return result;
		}

		public static string GetMachineCode()
		{
			return GetCpuId() + GetDiskNo();
		}

		public static string GetDiskNo()
		{
			ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
			ManagementObject managementObject = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
			managementObject.Get();
			return managementObject.GetPropertyValue("VolumeSerialNumber").ToString();
		}

		public static string GetCpuId()
		{
			string result = null;
			ManagementClass managementClass = new ManagementClass("win32_Processor");
			ManagementObjectCollection instances = managementClass.GetInstances();
			using (ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = instances.GetEnumerator())
			{
				if (managementObjectEnumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
					result = managementObject.Properties["Processorid"].Value.ToString();
				}
			}
			return result;
		}
	}
}
