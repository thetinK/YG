using System;
using System.IO;
using System.Text;

namespace RxjhServer.Network
{
	public class PacketReader
	{
		private readonly byte[] m_Data;

		private readonly int m_Size;

		private int m_Index;

		public byte[] Buffer => m_Data;

		public int Size => m_Size;

		public PacketReader(byte[] data, int size, bool fixedSize)
		{
			m_Data = data;
			m_Size = size;
			m_Index = (fixedSize ? 1 : 3);
		}

		public void Trace(ClientInfo state)
		{
			try
			{
				using StreamWriter streamWriter = new StreamWriter("Packets.log", append: true);
				byte[] data = m_Data;
				if (data.Length != 0)
				{
					streamWriter.WriteLine("Client: {0}: Unhandled 包ID 0x{1:X2}{2:X2} 包长{3} 时间{4}", state, data[8], data[7], data.Length, DateTime.Now);
				}
				using (MemoryStream input = new MemoryStream(data))
				{
					Utility.FormatBuffer(streamWriter, input, data.Length);
				}
				streamWriter.WriteLine();
				streamWriter.WriteLine();
			}
			catch
			{
			}
		}

		public int Seek(int offset, SeekOrigin origin)
		{
			switch (origin)
			{
			case SeekOrigin.Begin:
				m_Index = offset;
				break;
			case SeekOrigin.Current:
				m_Index += offset;
				break;
			case SeekOrigin.End:
				m_Index = m_Size - offset;
				break;
			}
			return m_Index;
		}

		public int ReadInt32()
		{
			if (m_Index + 4 > m_Size)
			{
				return 0;
			}
			return m_Data[m_Index++] | (m_Data[m_Index++] << 8) | (m_Data[m_Index++] << 16) | (m_Data[m_Index++] << 24);
		}

		public int ReadInt16()
		{
			if (m_Index + 2 > m_Size)
			{
				return 0;
			}
			return m_Data[m_Index++] | (m_Data[m_Index++] << 8);
		}

		public int ReadInt8()
		{
			if (m_Index + 1 > m_Size)
			{
				return 0;
			}
			return m_Data[m_Index++];
		}

		public float Readfloat()
		{
			if (m_Index + 4 > m_Size)
			{
				return 0f;
			}
			float result = BitConverter.ToSingle(m_Data, m_Index);
			m_Index += 4;
			return result;
		}

		public uint ReadUInt32()
		{
			if (m_Index + 4 > m_Size)
			{
				return 0u;
			}
			return (uint)(m_Data[m_Index++] | (m_Data[m_Index++] << 8) | (m_Data[m_Index++] << 16) | (m_Data[m_Index++] << 24));
		}

		public ushort ReadUInt16()
		{
			if (m_Index + 2 > m_Size)
			{
				return 0;
			}
			return (ushort)(m_Data[m_Index++] | (m_Data[m_Index++] << 8));
		}

		public byte ReadByte()
		{
			if (m_Index + 1 > m_Size)
			{
				return 0;
			}
			return m_Data[m_Index++];
		}

		public sbyte ReadSByte()
		{
			if (m_Index + 1 > m_Size)
			{
				return 0;
			}
			return (sbyte)m_Data[m_Index++];
		}

		public bool ReadBoolean()
		{
			if (m_Index + 1 > m_Size)
			{
				return false;
			}
			return m_Data[m_Index++] != 0;
		}

		public string ReadUnicodeStringLE()
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (m_Index + 1 < m_Size)
			{
				int num = m_Data[m_Index++];
				int num2 = m_Data[m_Index++] << 8;
				int num3;
				if ((num3 = num | num2) != 0)
				{
					stringBuilder.Append((char)num3);
					continue;
				}
				break;
			}
			return stringBuilder.ToString();
		}

		public string ReadUnicodeStringLESafe(int fixedLength)
		{
			int num = m_Index + (fixedLength << 1);
			int index = num;
			if (num > m_Size)
			{
				num = m_Size;
			}
			StringBuilder stringBuilder = new StringBuilder();
			while (m_Index + 1 < num)
			{
				int num2 = m_Data[m_Index++];
				int num3 = m_Data[m_Index++] << 8;
				int num4;
				if ((num4 = num2 | num3) != 0)
				{
					if (IsSafeChar(num4))
					{
						stringBuilder.Append((char)num4);
					}
					continue;
				}
				break;
			}
			m_Index = index;
			return stringBuilder.ToString();
		}

		public string ReadUnicodeStringLESafe()
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (m_Index + 1 < m_Size)
			{
				int num = m_Data[m_Index++];
				int num2 = m_Data[m_Index++] << 8;
				int num3;
				if ((num3 = num | num2) != 0)
				{
					if (IsSafeChar(num3))
					{
						stringBuilder.Append((char)num3);
					}
					continue;
				}
				break;
			}
			return stringBuilder.ToString();
		}

		public string ReadUnicodeStringSafe()
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (m_Index + 1 < m_Size)
			{
				int num = m_Data[m_Index++] << 8;
				int num2 = m_Data[m_Index++];
				int num3;
				if ((num3 = num | num2) != 0)
				{
					if (IsSafeChar(num3))
					{
						stringBuilder.Append((char)num3);
					}
					continue;
				}
				break;
			}
			return stringBuilder.ToString();
		}

		public string ReadUnicodeString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (m_Index + 1 < m_Size)
			{
				int num = m_Data[m_Index++] << 8;
				int num2 = m_Data[m_Index++];
				int num3;
				if ((num3 = num | num2) != 0)
				{
					stringBuilder.Append((char)num3);
					continue;
				}
				break;
			}
			return stringBuilder.ToString();
		}

		public bool IsSafeChar(int c)
		{
			if (c >= 32)
			{
				return c < 65534;
			}
			return false;
		}

		public string ReadUTF8StringSafe(int fixedLength)
		{
			if (m_Index >= m_Size)
			{
				m_Index += fixedLength;
				return string.Empty;
			}
			int num = m_Index + fixedLength;
			if (num > m_Size)
			{
				num = m_Size;
			}
			int num2 = 0;
			int index = m_Index;
			int index2 = m_Index;
			while (index < num && m_Data[index++] != 0)
			{
				num2++;
			}
			int num3 = 0;
			byte[] array = new byte[num2];
			while (m_Index < num)
			{
				byte[] data = m_Data;
				int num4;
				if ((num4 = data[m_Index++]) != 0)
				{
					array[num3++] = (byte)num4;
					continue;
				}
				break;
			}
			string @string = Utility.UTF8.GetString(array);
			bool flag = true;
			int num5 = 0;
			while (flag && num5 < @string.Length)
			{
				flag = IsSafeChar(@string[num5]);
				num5++;
			}
			m_Index = index2 + fixedLength;
			if (flag)
			{
				return @string;
			}
			StringBuilder stringBuilder = new StringBuilder(@string.Length);
			for (int i = 0; i < @string.Length; i++)
			{
				if (IsSafeChar(@string[i]))
				{
					stringBuilder.Append(@string[i]);
				}
			}
			return stringBuilder.ToString();
		}

		public string ReadUTF8StringSafe()
		{
			if (m_Index >= m_Size)
			{
				return string.Empty;
			}
			int num = 0;
			int index = m_Index;
			while (index < m_Size && m_Data[index++] != 0)
			{
				num++;
			}
			int num2 = 0;
			byte[] array = new byte[num];
			while (m_Index < m_Size)
			{
				byte[] data = m_Data;
				int num3;
				if ((num3 = data[m_Index++]) != 0)
				{
					array[num2++] = (byte)num3;
					continue;
				}
				break;
			}
			string @string = Utility.UTF8.GetString(array);
			bool flag = true;
			int num4 = 0;
			while (flag && num4 < @string.Length)
			{
				flag = IsSafeChar(@string[num4]);
				num4++;
			}
			if (flag)
			{
				return @string;
			}
			StringBuilder stringBuilder = new StringBuilder(@string.Length);
			for (int i = 0; i < @string.Length; i++)
			{
				if (IsSafeChar(@string[i]))
				{
					stringBuilder.Append(@string[i]);
				}
			}
			return stringBuilder.ToString();
		}

		public string ReadUTF8String()
		{
			if (m_Index >= m_Size)
			{
				return string.Empty;
			}
			int num = 0;
			int index = m_Index;
			while (index < m_Size && m_Data[index++] != 0)
			{
				num++;
			}
			int num2 = 0;
			byte[] array = new byte[num];
			while (m_Index < m_Size)
			{
				byte[] data = m_Data;
				int num3;
				if ((num3 = data[m_Index++]) != 0)
				{
					array[num2++] = (byte)num3;
					continue;
				}
				break;
			}
			return Utility.UTF8.GetString(array);
		}

		public string ReadString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (m_Index < m_Size)
			{
				byte[] data = m_Data;
				int num;
				if ((num = data[m_Index++]) != 0)
				{
					stringBuilder.Append((char)num);
					continue;
				}
				break;
			}
			return stringBuilder.ToString();
		}

		public string ReadStringSafe()
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (m_Index < m_Size)
			{
				byte[] data = m_Data;
				int num;
				if ((num = data[m_Index++]) != 0)
				{
					if (IsSafeChar(num))
					{
						stringBuilder.Append((char)num);
					}
					continue;
				}
				break;
			}
			return stringBuilder.ToString();
		}

		public string ReadUnicodeStringSafe(int fixedLength)
		{
			int num = m_Index + (fixedLength << 1);
			int index = num;
			if (num > m_Size)
			{
				num = m_Size;
			}
			StringBuilder stringBuilder = new StringBuilder();
			while (m_Index + 1 < num)
			{
				int num2 = m_Data[m_Index++] << 8;
				int num3 = m_Data[m_Index++];
				int num4;
				if ((num4 = num2 | num3) != 0)
				{
					if (IsSafeChar(num4))
					{
						stringBuilder.Append((char)num4);
					}
					continue;
				}
				break;
			}
			m_Index = index;
			return stringBuilder.ToString();
		}

		public string ReadUnicodeString(int fixedLength)
		{
			int num = m_Index + (fixedLength << 1);
			int index = num;
			if (num > m_Size)
			{
				num = m_Size;
			}
			StringBuilder stringBuilder = new StringBuilder();
			while (m_Index + 1 < num)
			{
				int num2 = m_Data[m_Index++] << 8;
				int num3 = m_Data[m_Index++];
				int num4;
				if ((num4 = num2 | num3) != 0)
				{
					stringBuilder.Append((char)num4);
					continue;
				}
				break;
			}
			m_Index = index;
			return stringBuilder.ToString();
		}

		public string ReadStringSafe(int fixedLength)
		{
			int num = m_Index + fixedLength;
			int index = num;
			if (num > m_Size)
			{
				num = m_Size;
			}
			StringBuilder stringBuilder = new StringBuilder();
			while (m_Index < num)
			{
				byte[] data = m_Data;
				int num2;
				if ((num2 = data[m_Index++]) != 0)
				{
					if (IsSafeChar(num2))
					{
						stringBuilder.Append((char)num2);
					}
					continue;
				}
				break;
			}
			m_Index = index;
			return stringBuilder.ToString();
		}

		public string ReadString(int fixedLength)
		{
			int num = m_Index + fixedLength;
			int index = num;
			if (num > m_Size)
			{
				num = m_Size;
			}
			StringBuilder stringBuilder = new StringBuilder();
			while (m_Index < num)
			{
				byte[] data = m_Data;
				int num2;
				if ((num2 = data[m_Index++]) != 0)
				{
					stringBuilder.Append((char)num2);
					continue;
				}
				break;
			}
			m_Index = index;
			return stringBuilder.ToString();
		}
	}
}
