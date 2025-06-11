using System;
using System.Text;

namespace RxjhServer
{
	public class RC6
	{
		private string m_sEncryptionKey;

		public string m_sCryptedText;

		private int m_nChipherlen;

		private readonly uint[] m_nKeyExpandBox;

		private uint[] n_WordBox;

		public Encoding Enc_default = Encoding.Unicode;

		public string KEY
		{
			get
			{
				return m_sEncryptionKey;
			}
			set
			{
				m_sEncryptionKey = value;
			}
		}

		public int IV
		{
			get
			{
				return m_nChipherlen;
			}
			set
			{
				m_nChipherlen = value;
			}
		}

		public uint ROTL(uint x, uint y, int w)
		{
			return (x << (int)(y & 0xFF)) | (x >> (int)(w - (y & 0xFF)));
		}

		public uint ROTR(uint x, uint y, int w)
		{
			return (x >> (int)(y & 0xFF)) | (x << (int)(w - (y & 0xFF)));
		}

		public RC6()
		{
			IV = 16;
			m_nKeyExpandBox = new uint[8 * m_nChipherlen];
		}

		public RC6(int iv)
		{
			IV = iv;
			m_nKeyExpandBox = new uint[8 * m_nChipherlen];
		}

		public int _IV()
		{
			if (m_nChipherlen < 16)
			{
				m_nChipherlen = 16;
			}
			if (m_nChipherlen > 32)
			{
				m_nChipherlen = 32;
			}
			return m_nChipherlen;
		}

		private char[] String_Unicode()
		{
			string sEncryptionKey = m_sEncryptionKey;
			sEncryptionKey = ((sEncryptionKey.Length % m_nChipherlen != 0) ? sEncryptionKey.PadRight(sEncryptionKey.Length + (m_nChipherlen - sEncryptionKey.Length % m_nChipherlen), '\0') : sEncryptionKey);
			byte[] array = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, Encoding.Unicode.GetBytes(sEncryptionKey));
			char[] array2 = new char[Encoding.ASCII.GetCharCount(array, 0, array.Length)];
			Encoding.ASCII.GetChars(array, 0, array.Length, array2, 0);
			return array2;
		}

		private void KeySteup()
		{
			uint num = 3084996963u;
			uint num2 = 2654435769u;
			uint num3;
			uint num4 = (num3 = 0u);
			int num5 = 0;
			char[] array = String_Unicode();
			n_WordBox = new uint[m_nChipherlen / 4];
			for (num5 = 0; num5 < m_nChipherlen; num5++)
			{
				uint num6 = (uint)((array[num5] & 0xFF) << 8 * (num5 % 4));
				n_WordBox[num5 / 4] += num6;
			}
			m_nKeyExpandBox[0] = num;
			for (num5 = 1; num5 < 2 * m_nChipherlen + 4; num5++)
			{
				m_nKeyExpandBox[num5] = m_nKeyExpandBox[num5 - 1] + num2;
			}
			int num7 = 3 * Math.Max(n_WordBox.Length, 2 * m_nChipherlen + 4);
			num5 = 0;
			int num8 = 0;
			while (num7 > 0)
			{
				num4 = ROTL(m_nKeyExpandBox[num8] + num4 + num3, 3u, 32);
				m_nKeyExpandBox[num8] = (byte)num4;
				num3 += num4;
				num3 = ROTL(n_WordBox[num5] + num4 + num3, num4 + num3, 32);
				n_WordBox[num5] = num3;
				num8 = (num8 + 1) % (2 * m_nChipherlen + 4);
				num5 = (num5 + 1) % n_WordBox.Length;
				num7--;
			}
		}

		public string Encrypt(string str, string prssword)
		{
			str = ((str.Length % 32 != 0) ? str.PadRight(str.Length + (32 - str.Length % 32), '\0') : str);
			KEY = prssword;
			KeySteup();
			uint num = 0u;
			uint num4;
			uint num2;
			uint num3;
			uint num5 = (num4 = (num3 = (num2 = 0u)));
			uint num6 = 0u;
			byte[] bytes = Encoding.Unicode.GetBytes(str);
			char[] chars = new char[Encoding.ASCII.GetCharCount(bytes, 0, bytes.Length)];
			Encoding.ASCII.GetChars(bytes, 0, bytes.Length, chars, 0);
			byte[] array = new byte[bytes.Length];
			for (int i = 0; i < 4; i++)
			{
				num5 += (uint)((bytes[2 * i] & 0xFF) << 8 * i);
				num4 += (uint)((bytes[2 * i + 8] & 0xFF) << 8 * i);
				num3 += (uint)((bytes[2 * i + 16] & 0xFF) << 8 * i);
				num2 += (uint)((bytes[2 * i + 24] & 0xFF) << 8 * i);
			}
			num4 += m_nKeyExpandBox[0];
			num2 += m_nKeyExpandBox[1];
			for (int j = 1; j <= m_nChipherlen; j++)
			{
				num = ROTL(num2 * (2 * num2 + 1), 5u, 32);
				uint num7 = ROTL(num4 * (2 * num4 + 1), 5u, 32);
				num5 = ROTL(num5 ^ num7, num, 32) + m_nKeyExpandBox[2 * j];
				num3 = ROTL(num3 ^ num, num7, 32) + m_nKeyExpandBox[2 * j + 1];
				num6 = num5;
				num5 = num4;
				num4 = num3;
				num3 = num2;
				num2 = num6;
			}
			uint[] array2 = new uint[4];
			num5 += m_nKeyExpandBox[42];
			num3 += m_nKeyExpandBox[43];
			array2[0] = num5;
			array2[1] = num4;
			array2[2] = num3;
			array2[3] = num2;
			for (int k = 0; k < 4; k++)
			{
				array[2 * k] = (byte)((array2[0] >> 8 * k) & 0xFFu);
				array[2 * k + 8] = (byte)((array2[1] >> 8 * k) & 0xFFu);
				array[2 * k + 16] = (byte)((array2[2] >> 8 * k) & 0xFFu);
				array[2 * k + 24] = (byte)((array2[3] >> 8 * k) & 0xFFu);
			}
			char[] array3 = new char[array.Length];
			Encoding.Unicode.GetChars(array, 0, array.Length, array3, 0);
			m_sCryptedText = new string(array3, 0, array3.Length);
			byte[] bytes2 = Enc_default.GetBytes(m_sCryptedText);
			return m_sCryptedText;
		}

		public string Decrypt(string str, string prssword)
		{
			str = ((str.Length % 32 != 0) ? str.PadRight(str.Length + (32 - str.Length % 32), '\0') : str);
			KEY = prssword;
			KeySteup();
			uint num = 0u;
			uint num3;
			uint num2;
			uint num4;
			uint num5 = (num4 = (num3 = (num2 = 0u)));
			uint num6 = 0u;
			byte[] bytes = Enc_default.GetBytes(str);
			byte[] array = new byte[bytes.Length];
			for (int i = 0; i < 4; i++)
			{
				num5 += (uint)((bytes[2 * i] & 0xFF) << 8 * i);
				num4 += (uint)((bytes[2 * i + 8] & 0xFF) << 8 * i);
				num3 += (uint)((bytes[2 * i + 16] & 0xFF) << 8 * i);
				num2 += (uint)((bytes[2 * i + 24] & 0xFF) << 8 * i);
			}
			num3 -= m_nKeyExpandBox[43];
			num5 -= m_nKeyExpandBox[42];
			for (int j = 1; j <= m_nChipherlen; j++)
			{
				num6 = num2;
				num2 = num3;
				num3 = num4;
				num4 = num5;
				num5 = num6;
				num = ROTL(num2 * (2 * num2 + 1), 5u, 32);
				uint num7 = ROTL(num4 * (2 * num4 + 1), 5u, 32);
				num3 = ROTR(num3 - m_nKeyExpandBox[2 * (m_nChipherlen - j) + 3], num7, 32) ^ num;
				num5 = ROTR(num5 - m_nKeyExpandBox[2 * (m_nChipherlen - j) + 2], num, 32) ^ num7;
			}
			num2 -= m_nKeyExpandBox[1];
			num4 -= m_nKeyExpandBox[0];
			for (int k = 0; k < 4; k++)
			{
				array[2 * k] = (byte)((num5 >> 8 * k) & 0xFFu);
				array[2 * k + 8] = (byte)((num4 >> 8 * k) & 0xFFu);
				array[2 * k + 16] = (byte)((num3 >> 8 * k) & 0xFFu);
				array[2 * k + 24] = (byte)((num2 >> 8 * k) & 0xFFu);
			}
			char[] array2 = new char[Enc_default.GetCharCount(array, 0, array.Length)];
			Enc_default.GetChars(array, 0, array.Length, array2, 0);
			m_sCryptedText = new string(array2, 0, array2.Length);
			byte[] bytes2 = Enc_default.GetBytes(m_sCryptedText);
			return m_sCryptedText;
		}
	}
}
