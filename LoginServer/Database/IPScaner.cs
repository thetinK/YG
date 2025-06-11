using System;
using System.IO;
using System.Text;

namespace Database
{
	public class IPScaner
	{
		private string dataPath;

		private string ip;

		private string country;

		private string local;

		private long firstStartIp;

		private long lastStartIp;

		private FileStream objfs;

		private long startIp;

		private long endIp;

		private int countryFlag;

		private long endIpOff;

		private int QQwry()
		{
			long num = IpToInt(ip);
			int result = 0;
			if (num >= IpToInt("127.0.0.0") && num <= IpToInt("127.255.255.255"))
			{
				country = "本机内部环回地址";
				local = "";
				result = 1;
			}
			else if (num >= IpToInt("0.0.0.0") && num <= IpToInt("2.255.255.255") || num >= IpToInt("64.0.0.0") && num <= IpToInt("126.255.255.255") || num >= IpToInt("58.0.0.0") && num <= IpToInt("60.255.255.255"))
			{
				country = "网络保留地址";
				local = "";
				result = 1;
			}
			objfs = new FileStream(dataPath, FileMode.Open, FileAccess.Read);
			try
			{
				objfs.Position = 0L;
				byte[] array = new byte[8];
				objfs.Read(array, 0, 8);
				firstStartIp = array[0] + array[1] * 256 + array[2] * 256 * 256 + array[3] * 256 * 256 * 256;
				lastStartIp = array[4] + array[5] * 256 + array[6] * 256 * 256 + array[7] * 256 * 256 * 256;
				long num2 = Convert.ToInt64((lastStartIp - firstStartIp) / 7.0);
				if (num2 <= 1)
				{
					country = "FileDataError";
					objfs.Close();
					return 2;
				}
				long num3 = num2;
				long num4 = 0L;
				while (num4 < num3 - 1)
				{
					long num5 = (num3 + num4) / 2;
					GetStartIp(num5);
					if (num == startIp)
					{
						num4 = num5;
						break;
					}
					if (num > startIp)
					{
						num4 = num5;
					}
					else
					{
						num3 = num5;
					}
				}
				GetStartIp(num4);
				GetEndIp();
				if (startIp <= num && endIp >= num)
				{
					GetCountry();
					local = local.Replace("（我们一定要解放台湾！！！）", "");
				}
				else
				{
					result = 3;
					country = "未知";
					local = "";
				}
				objfs.Close();
				return result;
			}
			catch
			{
				return 1;
			}
		}

		private long IpToInt(string ip)
		{
			char[] separator = new char[1] { '.' };
			if (ip.Split(separator).Length == 3)
			{
				ip += ".0";
			}
			string[] array = ip.Split(separator);
			return long.Parse(array[0]) * 256 * 256 * 256 + long.Parse(array[1]) * 256 * 256 + long.Parse(array[2]) * 256 + long.Parse(array[3]);
		}

		private long GetStartIp(long recNO)
		{
			objfs.Position = firstStartIp + recNO * 7;
			byte[] array = new byte[7];
			objfs.Read(array, 0, 7);
			endIpOff = Convert.ToInt64(array[4].ToString()) + Convert.ToInt64(array[5].ToString()) * 256 + Convert.ToInt64(array[6].ToString()) * 256 * 256;
			startIp = Convert.ToInt64(array[0].ToString()) + Convert.ToInt64(array[1].ToString()) * 256 + Convert.ToInt64(array[2].ToString()) * 256 * 256 + Convert.ToInt64(array[3].ToString()) * 256 * 256 * 256;
			return startIp;
		}

		private long GetEndIp()
		{
			objfs.Position = endIpOff;
			byte[] array = new byte[5];
			objfs.Read(array, 0, 5);
			endIp = Convert.ToInt64(array[0].ToString()) + Convert.ToInt64(array[1].ToString()) * 256 + Convert.ToInt64(array[2].ToString()) * 256 * 256 + Convert.ToInt64(array[3].ToString()) * 256 * 256 * 256;
			countryFlag = array[4];
			return endIp;
		}

		private string GetCountry()
		{
			int num = countryFlag;
			if ((uint)(num - 1) <= 1u)
			{
				country = GetFlagStr(endIpOff + 4);
				local = 1 == countryFlag ? " " : GetFlagStr(endIpOff + 8);
			}
			else
			{
				country = GetFlagStr(endIpOff + 4);
				local = GetFlagStr(objfs.Position);
			}
			return " ";
		}

		private string GetFlagStr(long offSet)
		{
			byte[] array = new byte[3];
			while (true)
			{
				objfs.Position = offSet;
				int num = objfs.ReadByte();
				if ((uint)(num - 1) > 1u)
				{
					break;
				}
				objfs.Read(array, 0, 3);
				if (num == 2)
				{
					countryFlag = 2;
					endIpOff = offSet - 4;
				}
				offSet = Convert.ToInt64(array[0].ToString()) + Convert.ToInt64(array[1].ToString()) * 256 + Convert.ToInt64(array[2].ToString()) * 256 * 256;
			}
			if (offSet < 12)
			{
				return " ";
			}
			objfs.Position = offSet;
			return GetStr();
		}

		private string GetStr()
		{
			string text = "";
			byte[] array = new byte[2];
			while (true)
			{
				byte b = (byte)objfs.ReadByte();
				if (b == 0)
				{
					break;
				}
				if (b > 127)
				{
					byte b2 = (byte)objfs.ReadByte();
					array[0] = b;
					array[1] = b2;
					Encoding encoding = Encoding.GetEncoding("GB2312");
					text += encoding.GetString(array);
				}
				else
				{
					text += (string)(object)(char)b;
				}
			}
			return text;
		}

		public string IPLocation(string dataPath, string ip)
		{
			this.dataPath = dataPath;
			this.ip = ip;
			QQwry();
			return country + local;
		}
	}
}
