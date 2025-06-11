using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RxjhServer
{
	public class Class2
	{
		private readonly string publickey = "<RSAKeyValue><Modulus>y+XGM4lAnEKsEb23uoadipw11QLSSLrcqLR4jZqAPAMGVsVlMi+SUJOTMFO+QsN2mDzCSaAdOxH7Cn9+MqH3wO+FwFuILmIdlXG9ZNARH8hwheRJrCD9X5cENXYHKRIXSVu+INbyicjQXGiJ/ycf9e35OBHOZJgy7FBqjC6m/u8=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

		public string EncryptByPublicKey(string dataStr)
		{
			int num = 1024;
			RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider(num);
			rSACryptoServiceProvider.FromXmlString(publickey);
			RSAParameters rSAParameters = rSACryptoServiceProvider.ExportParameters(includePrivateParameters: false);
			byte[] modulus = rSAParameters.Modulus;
			byte[] exponent = rSAParameters.Exponent;
			BigInteger nNum = new BigInteger(modulus);
			BigInteger keyNum = new BigInteger(exponent);
			int num2 = num / 8;
			byte[] bytes = Encoding.UTF8.GetBytes(dataStr);
			int num3 = num2 - 42;
			int num4 = bytes.Length;
			int num5 = num4 / num3;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i <= num5; i++)
			{
				byte[] array = new byte[(num4 - num3 * i > num3) ? num3 : (num4 - num3 * i)];
				Buffer.BlockCopy(bytes, num3 * i, array, 0, array.Length);
				byte[] array2 = EncryptString(array, keyNum, nNum);
				Array.Reverse(array2);
				stringBuilder.Append(Convert.ToBase64String(array2));
			}
			return stringBuilder.ToString();
		}

		public string DecryptByPublicKey(string inputString)
		{
			int num = 1024;
			RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider(num);
			rSACryptoServiceProvider.FromXmlString(publickey);
			RSAParameters rSAParameters = rSACryptoServiceProvider.ExportParameters(includePrivateParameters: false);
			byte[] modulus = rSAParameters.Modulus;
			byte[] exponent = rSAParameters.Exponent;
			BigInteger nNum = new BigInteger(modulus);
			BigInteger keyNum = new BigInteger(exponent);
			int num2 = ((num / 8 % 3 != 0) ? (num / 8 / 3 * 4 + 4) : (num / 8 / 3 * 4));
			int num3 = inputString.Length / num2;
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < num3; i++)
			{
				byte[] array = Convert.FromBase64String(inputString.Substring(num2 * i, num2));
				Array.Reverse(array);
				arrayList.AddRange(DecryptBytes(array, keyNum, nNum));
			}
			return Encoding.UTF8.GetString(arrayList.ToArray(Type.GetType("System.Byte")) as byte[]);
		}

		private byte[] EncryptString(byte[] bytes, BigInteger keyNum, BigInteger nNum)
		{
			int num = bytes.Length;
			int num2 = 0;
			int num3 = 0;
			num2 = ((num % 120 != 0) ? (num / 120 + 1) : (num / 120));
			List<byte> list = new List<byte>();
			for (int i = 0; i < num2; i++)
			{
				num3 = ((num < 120) ? num : 120);
				byte[] array = new byte[num3];
				Array.Copy(bytes, i * 120, array, 0, num3);
				string @string = Encoding.UTF8.GetString(array);
				BigInteger bigInteger = new BigInteger(array);
				BigInteger bigInteger2 = bigInteger.modPow(keyNum, nNum);
				string text = bigInteger2.ToHexString();
				if (text.Length < 256)
				{
					while (text.Length != 256)
					{
						text = "0" + text;
					}
				}
				byte[] array2 = new byte[128];
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j] = Convert.ToByte(text.Substring(j * 2, 2), 16);
				}
				list.AddRange(array2);
				num -= num3;
			}
			return list.ToArray();
		}

		private byte[] DecryptBytes(byte[] dataBytes, BigInteger KeyNum, BigInteger nNum)
		{
			int num = dataBytes.Length;
			int num2 = 0;
			int num3 = 0;
			num2 = ((num % 128 != 0) ? (num / 128 + 1) : (num / 128));
			List<byte> list = new List<byte>();
			for (int i = 0; i < num2; i++)
			{
				num3 = ((num < 128) ? num : 128);
				byte[] array = new byte[num3];
				Array.Copy(dataBytes, i * 128, array, 0, num3);
				BigInteger bigInteger = new BigInteger(array);
				BigInteger bigInteger2 = bigInteger.modPow(KeyNum, nNum);
				byte[] bytes = bigInteger2.getBytes();
				string @string = Encoding.UTF8.GetString(bytes);
				list.AddRange(bytes);
				num -= num3;
			}
			return list.ToArray();
		}
	}
}
