using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
	public class Converter
	{
		public static Dictionary<string, byte[]> Hexstring = new Dictionary<string, byte[]>();

		public static string ToString(byte[] bytes)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte b in bytes)
			{
				stringBuilder.Append(Convert.ToString((short)b, 16).PadLeft(2, '0').ToUpper());
			}
			return stringBuilder.ToString();
		}

		public static byte[] hexStringToByte(string hex)
		{
			string key = hex.Length > 40 ? hex.Remove(40, hex.Length - 40) : hex;
			if (!Hexstring.TryGetValue(key, out var value))
			{
				value = hexStringToByte2(hex);
				Hexstring.Add(key, value);
			}
			byte[] array = new byte[value.Length];
			Buffer.BlockCopy(value, 0, array, 0, value.Length);
			return array;
		}

		public static byte[] hexStringToByte2(string hex)
		{
			try
			{
				int num = hex.Length / 2;
				byte[] array = new byte[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
				}
				return array;
			}
			catch (Exception)
			{
				return new byte[hex.Length];
			}
		}
	}
}
