using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Database
{
	public class Config
	{
		private static string iniPath = Application.StartupPath + "\\config.ini";

		public static string Path
		{
			set
			{
				iniPath = value;
			}
		}

		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

		public static string IniReadValue(string Section, string Key)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			GetPrivateProfileString(Section, Key, "", stringBuilder, 255, iniPath);
			return stringBuilder.ToString();
		}
	}
}
