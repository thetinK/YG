using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Authentication
{
	public class DESDecryptor
	{
		private static string encryptKey = "abcd";

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
