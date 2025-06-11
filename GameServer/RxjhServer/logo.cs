using System;
using System.IO;

namespace RxjhServer
{
	public class logo
	{
		public static void shopTxtLog(string ErrTxt)
		{
			try
			{
				if (!Directory.Exists("logs"))
				{
					Directory.CreateDirectory("logs");
				}
				using StreamWriter streamWriter = new StreamWriter(new FileStream("logs\\NPC商店日志_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", FileMode.Append, FileAccess.Write, FileShare.Read));
				streamWriter.Write(DateTime.Now.ToString() + " " + ErrTxt + "\r\n");
			}
			catch
			{
			}
		}

		public static void 假人反馈(string ErrTxt)
		{
			try
			{
				if (!Directory.Exists("假人反馈"))
				{
					Directory.CreateDirectory("假人反馈");
				}
				using StreamWriter streamWriter = new StreamWriter(new FileStream("假人反馈\\日志_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", FileMode.Append, FileAccess.Write, FileShare.Read));
				streamWriter.Write(DateTime.Now.ToString() + " " + ErrTxt + "\r\n");
			}
			catch
			{
			}
		}

		public static void kickid(string ErrTxt)
		{
			try
			{
				if (!Directory.Exists("logs"))
				{
					Directory.CreateDirectory("logs");
				}
				using StreamWriter streamWriter = new StreamWriter(new FileStream("logs\\踢号日志_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", FileMode.Append, FileAccess.Write, FileShare.Read));
				streamWriter.Write(DateTime.Now.ToString() + " " + ErrTxt + "\r\n");
			}
			catch
			{
			}
		}

		public static void UseItemLog(string ErrTxt)
		{
			try
			{
				if (!Directory.Exists("logs"))
				{
					Directory.CreateDirectory("logs");
				}
				using StreamWriter streamWriter = new StreamWriter(new FileStream("logs\\物品使用日志_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", FileMode.Append, FileAccess.Write, FileShare.Read));
				streamWriter.Write(DateTime.Now.ToString() + " " + ErrTxt + "\r\n");
			}
			catch
			{
			}
		}

		public static void HCItemLog(string ErrTxt)
		{
			try
			{
				if (!Directory.Exists("logs"))
				{
					Directory.CreateDirectory("logs");
				}
				using StreamWriter streamWriter = new StreamWriter(new FileStream("logs\\合成强化日志_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", FileMode.Append, FileAccess.Write, FileShare.Read));
				streamWriter.Write(DateTime.Now.ToString() + " " + ErrTxt + "\r\n");
			}
			catch
			{
			}
		}

		public static void WGTxtLog(string ErrTxt)
		{
			try
			{
				if (!Directory.Exists("logs"))
				{
					Directory.CreateDirectory("logs");
				}
				using StreamWriter streamWriter = new StreamWriter(new FileStream("logs\\外挂检测_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", FileMode.Append, FileAccess.Write, FileShare.Read));
				streamWriter.Write(DateTime.Now.ToString() + " " + ErrTxt + "\r\n");
			}
			catch
			{
			}
		}

		public static void FileTxtLog(string ErrTxt)
		{
			try
			{
				if (!Directory.Exists("logs"))
				{
					Directory.CreateDirectory("logs");
				}
				using StreamWriter streamWriter = new StreamWriter(new FileStream("logs\\错误日志_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", FileMode.Append, FileAccess.Write, FileShare.Read));
				streamWriter.Write(DateTime.Now.ToString() + " " + ErrTxt + "\r\n");
			}
			catch
			{
			}
		}

		public static void RegLog(string ErrTxt)
		{
			try
			{
				if (!Directory.Exists("logs"))
				{
					Directory.CreateDirectory("logs");
				}
				using StreamWriter streamWriter = new StreamWriter(new FileStream("logs\\硬件ID.txt", FileMode.Append, FileAccess.Write, FileShare.Read));
				streamWriter.Write(DateTime.Now.ToString() + " " + ErrTxt + "\r\n");
			}
			catch
			{
			}
		}

		public static void pzTxtLog(string ErrTxt)
		{
			try
			{
				if (!Directory.Exists("logs"))
				{
					Directory.CreateDirectory("logs");
				}
				using StreamWriter streamWriter = new StreamWriter(new FileStream("logs\\帮战日志_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", FileMode.Append, FileAccess.Write, FileShare.Read));
				streamWriter.Write(DateTime.Now.ToString() + " " + ErrTxt + "\r\n");
			}
			catch
			{
			}
		}

		public static void cfzTxtLog(string ErrTxt)
		{
			try
			{
				if (!Directory.Exists("logs"))
				{
					Directory.CreateDirectory("logs");
				}
				using StreamWriter streamWriter = new StreamWriter(new FileStream("logs\\非法物品日志_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", FileMode.Append, FileAccess.Write, FileShare.Read));
				streamWriter.Write(DateTime.Now.ToString() + " " + ErrTxt + "\r\n");
			}
			catch
			{
			}
		}

		public static void zhtfTxtLog(string ErrTxt)
		{
			try
			{
				if (!Directory.Exists("logs"))
				{
					Directory.CreateDirectory("logs");
				}
				using StreamWriter streamWriter = new StreamWriter(new FileStream("logs\\帐号停封日志_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", FileMode.Append, FileAccess.Write, FileShare.Read));
				streamWriter.Write(DateTime.Now.ToString() + " " + ErrTxt + "\r\n");
			}
			catch
			{
			}
		}

		public static void FileCQTxtLog(string ErrTxt)
		{
			try
			{
				if (!Directory.Exists("logs"))
				{
					Directory.CreateDirectory("logs");
				}
				using StreamWriter streamWriter = new StreamWriter(new FileStream("logs\\CQLog_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", FileMode.Append, FileAccess.Write, FileShare.Read));
				streamWriter.Write(DateTime.Now.ToString() + " " + ErrTxt + "\r\n");
			}
			catch
			{
			}
		}

		public static void FileLoninTxtLog(string ErrTxt)
		{
			try
			{
				if (!Directory.Exists("logs"))
				{
					Directory.CreateDirectory("logs");
				}
				using StreamWriter streamWriter = new StreamWriter(new FileStream("logs\\登陆日志_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", FileMode.Append, FileAccess.Write, FileShare.Read));
				streamWriter.Write(DateTime.Now.ToString() + " " + ErrTxt + "\r\n");
			}
			catch
			{
			}
		}

		public static void FileDropItmeTxtLog(string ErrTxt)
		{
			try
			{
				if (!Directory.Exists("logs"))
				{
					Directory.CreateDirectory("logs");
				}
				using StreamWriter streamWriter = new StreamWriter(new FileStream("logs\\DropItme_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", FileMode.Append, FileAccess.Write, FileShare.Read));
				streamWriter.Write(DateTime.Now.ToString() + " " + ErrTxt + "\r\n");
			}
			catch
			{
			}
		}

		public static void FileItmeTxtLog(string ErrTxt)
		{
			try
			{
				if (!Directory.Exists("logs"))
				{
					Directory.CreateDirectory("logs");
				}
				using StreamWriter streamWriter = new StreamWriter(new FileStream("logs\\ItmeLog_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", FileMode.Append, FileAccess.Write, FileShare.Read));
				streamWriter.Write(DateTime.Now.ToString() + " " + ErrTxt + "\r\n");
			}
			catch
			{
			}
		}

		public static void FileBugTxtLog(string ErrTxt)
		{
			try
			{
				if (!Directory.Exists("logs"))
				{
					Directory.CreateDirectory("logs");
				}
				using StreamWriter streamWriter = new StreamWriter(new FileStream("logs\\BugLog_" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt", FileMode.Append, FileAccess.Write, FileShare.Read));
				streamWriter.Write(DateTime.Now.ToString() + " " + ErrTxt + "\r\n");
			}
			catch
			{
			}
		}

		public static void FilePakTxtLog(string ErrTxt)
		{
			try
			{
				if (!Directory.Exists("logs"))
				{
					Directory.CreateDirectory("logs");
				}
				using StreamWriter streamWriter = new StreamWriter(new FileStream("logs\\封包_" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt", FileMode.Append, FileAccess.Write, FileShare.Read));
				streamWriter.Write(DateTime.Now.ToString() + " " + ErrTxt + "\r\n");
			}
			catch
			{
			}
		}

		public static void SeveTxtLog(string ErrTxt)
		{
			try
			{
				if (!Directory.Exists("logs"))
				{
					Directory.CreateDirectory("logs");
				}
				using StreamWriter streamWriter = new StreamWriter(new FileStream("logs\\存档_" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt", FileMode.Append, FileAccess.Write, FileShare.Read));
				streamWriter.Write(DateTime.Now.ToString() + " " + ErrTxt + "\r\n");
			}
			catch
			{
			}
		}

		public static void 寄售记录(string ErrTxt)
		{
			try
			{
				if (!Directory.Exists("物品记录"))
				{
					Directory.CreateDirectory("物品记录");
				}
				using StreamWriter streamWriter = new StreamWriter(new FileStream("物品记录\\寄售日志_" + DateTime.Now.ToString("yyyy_MM") + ".log", FileMode.Append, FileAccess.Write, FileShare.Read));
				streamWriter.Write(DateTime.Now.ToString() + " " + ErrTxt + "\r\n");
			}
			catch
			{
			}
		}

		public static void MsGLog(string MsG)
		{
		}
	}
}
