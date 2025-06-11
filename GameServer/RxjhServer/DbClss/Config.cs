using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace RxjhServer.DbClss
{
	public class Config
	{
		private static string iniPath = Application.StartupPath + "\\config\\config.ini";

		public static string Path
		{
			set
			{
				iniPath = value;
			}
		}

		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

		public static void IniWriteValue(string Section, string Key, string Value)
		{
			WritePrivateProfileString(Section, Key, Value, iniPath);
		}

		public static string IniReadValue(string Section, string Key)
		{
			StringBuilder stringBuilder = new StringBuilder(1024);
			GetPrivateProfileString(Section, Key, string.Empty, stringBuilder, 1024, iniPath);
			return stringBuilder.ToString();
		}
	}
}
