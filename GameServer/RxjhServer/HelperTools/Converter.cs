using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Globalization;
using System.Text;

namespace RxjhServer.HelperTools
{
	public class Converter
	{
		public static ConcurrentDictionary<string, byte[]> Hexstring = new ConcurrentDictionary<string, byte[]>();

		public static byte ToByte(byte[] d, ref int offset)
		{
			return d[offset++];
		}

		public static void ToBytes(byte a, byte[] b, ref int t)
		{
			b[t++] = a;
		}

		public static void ToBytes(BitArray a, byte[] b, ref int t)
		{
			a.CopyTo(b, t);
			t += a.Length / 8;
		}

		public static void ToBytes(double a, byte[] b, ref int t)
		{
			byte[] bytes = BitConverter.GetBytes(a);
			Buffer.BlockCopy(bytes, 0, b, t, bytes.Length);
			t += bytes.Length;
		}

		public static void ToBytes(short a, byte[] b, ref int t)
		{
			b[t++] = (byte)((uint)a & 0xFFu);
			b[t++] = (byte)((uint)(a >> 8) & 0xFFu);
		}

		public static void ToBytes(int a, byte[] b, ref int t)
		{
			b[t++] = (byte)((uint)a & 0xFFu);
			b[t++] = (byte)((uint)(a >> 8) & 0xFFu);
			b[t++] = (byte)((uint)(a >> 16) & 0xFFu);
			b[t++] = (byte)((uint)(a >> 24) & 0xFFu);
		}

		public static void ToBytes(long a, byte[] b, ref int t)
		{
			ToBytes((ulong)a, b, ref t);
		}

		public static void ToBytes(object a, byte[] b, ref int t)
		{
			int a2 = 0;
			int num;
			if (a is int)
			{
				a2 = (int)a;
				num = 1;
			}
			else
			{
				num = 0;
			}
			if (num != 0)
			{
				ToBytes(a2, b, ref t);
			}
			uint a3 = 0u;
			int num2;
			if (a is uint)
			{
				a3 = (uint)a;
				num2 = 1;
			}
			else
			{
				num2 = 0;
			}
			if (num2 != 0)
			{
				ToBytes(a3, b, ref t);
				return;
			}
			ulong a4 = 0uL;
			int num3;
			if (a is ulong)
			{
				a4 = (ulong)a;
				num3 = 1;
			}
			else
			{
				num3 = 0;
			}
			if (num3 != 0)
			{
				ToBytes(a4, b, ref t);
				return;
			}
			long a5 = 0L;
			int num4;
			if (a is long)
			{
				a5 = (long)a;
				num4 = 1;
			}
			else
			{
				num4 = 0;
			}
			if (num4 != 0)
			{
				ToBytes(a5, b, ref t);
				return;
			}
			ushort a6 = 0;
			int num5;
			if (a is ushort)
			{
				a6 = (ushort)a;
				num5 = 1;
			}
			else
			{
				num5 = 0;
			}
			if (num5 != 0)
			{
				ToBytes(a6, b, ref t);
				return;
			}
			short a7 = 0;
			int num6;
			if (a is short)
			{
				a7 = (short)a;
				num6 = 1;
			}
			else
			{
				num6 = 0;
			}
			if (num6 != 0)
			{
				ToBytes(a7, b, ref t);
				return;
			}
			byte a8 = 0;
			int num7;
			if (a is byte)
			{
				a8 = (byte)a;
				num7 = 1;
			}
			else
			{
				num7 = 0;
			}
			if (num7 != 0)
			{
				ToBytes(a8, b, ref t);
				return;
			}
			string text = a as string;
			if (text != null)
			{
				ToBytes(text, b, ref t);
			}
		}

		public static void ToBytes(float a, byte[] b, ref int t)
		{
			byte[] bytes = BitConverter.GetBytes(a);
			Buffer.BlockCopy(bytes, 0, b, t, bytes.Length);
			t += bytes.Length;
		}

		public static void ToBytes(string a, byte[] b, ref int t)
		{
			char[] array = a.ToCharArray();
			char[] array2 = array;
			char[] array3 = array2;
			char[] array4 = array3;
			foreach (char c in array4)
			{
				b[t++] = (byte)c;
			}
		}

		public static void ToBytes(ushort a, byte[] b, ref int t)
		{
			b[t++] = (byte)(a & 0xFFu);
			b[t++] = (byte)((uint)(a >> 8) & 0xFFu);
		}

		public static void ToBytes(uint a, byte[] b, ref int t)
		{
			b[t++] = (byte)(a & 0xFFu);
			b[t++] = (byte)((a >> 8) & 0xFFu);
			b[t++] = (byte)((a >> 16) & 0xFFu);
			b[t++] = (byte)((a >> 24) & 0xFFu);
		}

		public static void ToBytes(ulong a, byte[] b, ref int t)
		{
			b[t++] = (byte)(a & 0xFF);
			b[t++] = (byte)((a >> 8) & 0xFF);
			b[t++] = (byte)((a >> 16) & 0xFF);
			b[t++] = (byte)((a >> 24) & 0xFF);
			b[t++] = (byte)((a >> 32) & 0xFF);
			b[t++] = (byte)((a >> 40) & 0xFF);
			b[t++] = (byte)((a >> 48) & 0xFF);
			b[t++] = (byte)((a >> 56) & 0xFF);
		}

		public static void ToBytes(BitArray a, byte[] b, ref int t, int len)
		{
			a.CopyTo(b, t);
			t += len;
		}

		public static double ToDouble(byte[] d, ref int offset)
		{
			double result = BitConverter.ToDouble(d, offset);
			offset += 8;
			return result;
		}

		public static float ToFloat(byte[] d, ref int offset)
		{
			float result = BitConverter.ToSingle(d, offset);
			offset += 4;
			return result;
		}

		public static short ToInt16(byte[] d, ref int offset)
		{
			short result = BitConverter.ToInt16(d, offset);
			offset += 2;
			return result;
		}

		public static int ToInt32(byte[] d, ref int offset)
		{
			int result = BitConverter.ToInt32(d, offset);
			offset += 4;
			return result;
		}

		public static long ToInt64(byte[] d, ref int offset)
		{
			long result = BitConverter.ToInt64(d, offset);
			offset += 8;
			return result;
		}

		public static ushort ToUInt16(byte[] d, ref int offset)
		{
			ushort result = BitConverter.ToUInt16(d, offset);
			offset += 2;
			return result;
		}

		public static uint ToUInt32(byte[] d, ref int offset)
		{
			uint result = BitConverter.ToUInt32(d, offset);
			offset += 4;
			return result;
		}

		public static ulong ToUInt64(byte[] d, ref int offset)
		{
			ulong result = BitConverter.ToUInt64(d, offset);
			offset += 8;
			return result;
		}

		public static void ToGuidMark(ulong a, byte[] b, ref int t)
		{
			byte b2 = 0;
			byte[] array = new byte[8];
			int num = 0;
			for (int i = 0; i < 8; i++)
			{
				if (((a >> 8 * i) & 0xFF) != 0)
				{
					b2 = (byte)(b2 + (byte)Math.Pow(2.0, i));
					array[num] = (byte)((a >> 8 * i) & 0xFF);
					num++;
				}
			}
			b[t++] = b2;
			Buffer.BlockCopy(array, 0, b, t, num);
			t += num;
		}

		public static ulong ReadGuidToUlong(byte[] d, int offset)
		{
			byte b = d[offset++];
			byte[] array = new byte[8];
			for (int i = 0; i < 8; i++)
			{
				if ((byte)((uint)(b >> i) & 1u) != 0)
				{
					array[i] = d[offset++];
				}
				else
				{
					array[i] = 0;
				}
			}
			return BitConverter.ToUInt64(array, 0);
		}

		public static string ToString(byte[] bytes)
		{
			StringBuilder stringBuilder = new StringBuilder(bytes.Length * 2);
			foreach (byte b in bytes)
			{
				stringBuilder.Append(b.ToString("X2"));
			}
			return stringBuilder.ToString();
		}

		public static string ToString1(byte[] bytes)
		{
			StringBuilder stringBuilder = new StringBuilder(bytes.Length * 2);
			foreach (byte b in bytes)
			{
				stringBuilder.Append(b.ToString("X2"));
			}
			return "0x" + stringBuilder.ToString();
		}

		public static string ToString2(byte[] bytes)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte value in bytes)
			{
				stringBuilder.Append(Convert.ToString((short)value, 16).PadLeft(2, '0').ToUpper());
			}
			return stringBuilder.ToString();
		}

		public static string DateTimeToString(DateTime dt)
		{
			return dt.ToString("yyyyMMdd");
		}

		public static DateTime StringToDateTime2(string s)
		{
			CultureInfo provider = CultureInfo.CreateSpecificCulture("en-US");
			string format = "ddd, d MMM yyyy HH:mm:ss GMT";
			DateTime.Now.ToString(format, provider);
			return DateTime.ParseExact(s, format, provider);
		}

		public static byte[] hexStringToByte(string hex)
		{
			string key = ((hex.Length > 40) ? hex.Remove(40, hex.Length - 40) : hex);
			if (!Hexstring.TryGetValue(key, out var value))
			{
				value = hexStringToByte2(hex);
				Hexstring.TryAdd(key, value);
			}
			byte[] array = new byte[value.Length];
			value.CopyTo(array, 0);
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

		public static int getitmeid(string Item)
		{
			string str = Item.Substring(4, 2);
			string str2 = Item.Substring(2, 2);
			string str3 = Item.Substring(0, 2);
			string s = str + str2 + str3;
			return int.Parse(s, NumberStyles.HexNumber);
		}

		public static int getItmeid(string Item)
		{
			string str = Item.Substring(6, 2);
			string str2 = Item.Substring(4, 2);
			string str3 = Item.Substring(2, 2);
			string str4 = Item.Substring(0, 2);
			string s = str + str2 + str3 + str4;
			return int.Parse(s, NumberStyles.HexNumber);
		}
	}
}
