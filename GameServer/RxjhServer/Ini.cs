using System.IO;
using System.Runtime.InteropServices;

namespace RxjhServer
{
	internal class Ini
	{
		private readonly string filePath;

		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

		public Ini(string filePath)
		{
			this.filePath = filePath;
		}

		public bool SetString(string key, string val)
		{
			return File.Exists(filePath) && WritePrivateProfileString("GameServer", key, val, filePath) == 1;
		}
	}
}
