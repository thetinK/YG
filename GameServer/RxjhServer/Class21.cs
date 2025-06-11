using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RxjhServer
{
	public class Class21
	{
		private static readonly string encryptKey = "abcd";

		public string Encrypt(string str)
		{
			try
			{
				byte[] bytes = Encoding.Unicode.GetBytes(encryptKey);
				byte[] bytes2 = Encoding.Unicode.GetBytes(str);
				DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
				MemoryStream memoryStream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
				cryptoStream.Write(bytes2, 0, bytes2.Length);
				cryptoStream.FlushFinalBlock();
				byte[] inArray = memoryStream.ToArray();
				cryptoStream.Close();
				memoryStream.Close();
				return Convert.ToBase64String(inArray);
			}
			catch
			{
				return str;
			}
		}

		public string Decrypt(string str)
		{
			try
			{
				byte[] bytes = Encoding.Unicode.GetBytes(encryptKey);
				byte[] array = Convert.FromBase64String(str);
				DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
				MemoryStream memoryStream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Write);
				cryptoStream.Write(array, 0, array.Length);
				cryptoStream.FlushFinalBlock();
				byte[] bytes2 = memoryStream.ToArray();
				cryptoStream.Close();
				memoryStream.Close();
				return Encoding.Unicode.GetString(bytes2);
			}
			catch
			{
				return str;
			}
		}
	}
}
