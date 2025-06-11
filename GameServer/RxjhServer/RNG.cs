using System;
using System.Security.Cryptography;

namespace RxjhServer
{
	public static class RNG
	{
		private static readonly RNGCryptoServiceProvider rngp = new RNGCryptoServiceProvider();

		private static readonly byte[] rb = new byte[4];

		public static int Next()
		{
			rngp.GetBytes(rb);
			int num = BitConverter.ToInt32(rb, 0);
			if (num < 0)
			{
				num = -num;
			}
			return num;
		}

		public static int Next(int max)
		{
			rngp.GetBytes(rb);
			int num = BitConverter.ToInt32(rb, 0) % (max + 1);
			if (num < 0)
			{
				num = -num;
			}
			return num;
		}

		public static int Next(int min, int max)
		{
			return Next(max - min) + min;
		}
	}
}
