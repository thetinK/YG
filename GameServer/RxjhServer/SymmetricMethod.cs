using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RxjhServer
{
	public class SymmetricMethod
	{
		public string Key;

		private readonly SymmetricAlgorithm mobjCryptoService;

		public SymmetricMethod()
		{
			mobjCryptoService = new RijndaelManaged();
			Key = Get_key1() + Hasher.GetIP();
		}

		internal string Get_key1()
		{
			return "b.U:Z$L$/_H]S?ISLg(7KMd{*WZ1Ckyg6>?/4^}3W[+E<1[V}if9{P8'GY43((Ti#OwM!5Q50}MHuSlvo*9Bnp%I_a!Uf=>&ZQROX7.7yG;JPUGxJ)jcIsbLj~XWA+Y)";
		}

		public string Decrypto(string Source)
		{
			try
			{
				byte[] array = Convert.FromBase64String(Source);
				MemoryStream stream = new MemoryStream(array, 0, array.Length);
				string text = "";
				int length = Source.Length;
				text = "";
				int num = Convert.ToInt32(Source.ToCharArray(0, 1)[0]) % 10;
				for (int i = 2; i < length; i += 2)
				{
					int num2 = Convert.ToInt32(Source.ToCharArray(i, 1)[0]);
					string str = ((Convert.ToInt32(Source.ToCharArray(i - 1, 1)[0]) % 2 != 0) ? ((char)(num2 - (i - 1) / 2 - num)).ToString() : ((char)(num2 + (i - 1) / 2 + num)).ToString());
					text += str;
				}
				mobjCryptoService.Key = GetLegalKey();
				mobjCryptoService.IV = GetLegalIV();
				ICryptoTransform transform = mobjCryptoService.CreateDecryptor();
				CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
				StreamReader streamReader = new StreamReader(stream2);
				return streamReader.ReadToEnd();
			}
			catch
			{
				return "";
			}
		}

		public string Encrypto(string Source)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(Source);
			MemoryStream memoryStream = new MemoryStream();
			mobjCryptoService.Key = GetLegalKey();
			mobjCryptoService.IV = GetLegalIV();
			ICryptoTransform transform = mobjCryptoService.CreateEncryptor();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			memoryStream.Close();
			byte[] inArray = memoryStream.ToArray();
			return Convert.ToBase64String(inArray);
		}

		internal string Get_key2()
		{
			return "SrKpQX]wrh=&Iv9JCXc!BDUlc>Qx3bR8~]{+.ymyMji(['^LmZ7#*F@)7P`, ~d.ZW;n{t`G~;(D7l, bOHb$2dIY_$RU/Wftb1HIFO!_>p-(AGL6o+!a48i3BaT?N$%Od";
		}

		private byte[] GetLegalIV()
		{
			string text = Get_key2();
			mobjCryptoService.GenerateIV();
			int num = mobjCryptoService.IV.Length;
			if (text.Length > num)
			{
				text = text.Substring(text.Length - num, num);
			}
			else if (text.Length < num)
			{
				text = text.PadRight(num, ' ');
			}
			return Encoding.ASCII.GetBytes(text);
		}

		private byte[] GetLegalKey()
		{
			string text = Key;
			mobjCryptoService.GenerateKey();
			int num = mobjCryptoService.Key.Length;
			if (text.Length > num)
			{
				text = text.Substring(text.Length - num, num);
			}
			else if (text.Length < num)
			{
				text = text.PadRight(num, ' ');
			}
			return Encoding.ASCII.GetBytes(text);
		}
	}
}
