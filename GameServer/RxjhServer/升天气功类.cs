using System;

namespace RxjhServer
{
	public class 升天气功类
	{
		private byte[] _气功_byte;

		public byte[] 气功_byte
		{
			get
			{
				return _气功_byte;
			}
			set
			{
				_气功_byte = value;
			}
		}

		public int 气功ID
		{
			get
			{
				return BitConverter.ToInt16(气功_byte, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 气功_byte, 0, 2);
			}
		}

		public int 气功量
		{
			get
			{
				return BitConverter.ToInt16(气功_byte, 2);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 气功_byte, 2, 2);
			}
		}

		public 升天气功类()
		{
			气功_byte = new byte[4];
		}

		public 升天气功类(byte[] 气功_byte_)
		{
			气功_byte = 气功_byte_;
		}
	}
}
