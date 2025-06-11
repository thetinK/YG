using System;
using System.Text;

namespace RxjhServer.RxjhTool
{
	public class HelperTools
	{
		public static byte[] hexStringToByte(string hex)
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

		public static string ByteToString(byte[] bytes)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte value in bytes)
			{
				stringBuilder.Append(Convert.ToString((short)value, 16).PadLeft(2, '0').ToUpper());
			}
			return stringBuilder.ToString();
		}
	}
}
