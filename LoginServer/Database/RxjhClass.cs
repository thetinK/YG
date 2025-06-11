using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UI;
using Utilities;

namespace Database
{
	public class RxjhClass
	{
		public static string GetUserIpadds(string ip)
		{
			try
			{
				return new IPScaner().IPLocation(Application.StartupPath + "\\QQWry.Dat", ip);
			}
			catch
			{
				return "";
			}
		}

		public static void SetUserIdZT()
		{
			DBA.ExeSqlCommand("UPDATE TBL_ACCOUNT SET FLD_ZT=FLD_ZT-1 WHERE FLD_ZT>0", "rxjhaccount");
		}

		public static void UpdateLoginIP(string Userid, string ip)
		{
			DBA.RunProc(new SqlConnection(DBA.getstrConnection("rxjhaccount")), "XWWL_UPDATE_ACCOUNT_LOGINIP", new SqlParameter[2]
			{
				DBA.MakeInParam("@id", SqlDbType.VarChar, 30, Userid),
				DBA.MakeInParam("@ip", SqlDbType.VarChar, 30, ip)
			});
		}

		public static void SetUserIdONLINE(string id)
		{
			DBA.ExeSqlCommand("UPDATE TBL_ACCOUNT SET FLD_ONLINE=0 where FLD_ID='" + id + "'");
		}

		public static int GetUserId(string id, string pwd, string ip)
		{
			string sqlCommand = "EXEC   CHECK_ACCOUNT   '" + id + "','" + ip + "'";
			string sqlCommand2 = "UPDATE   TBL_ACCOUNT   SET   FLD_ONLINE=1   where   FLD_ID='" + id + "'";
			DBA.ExeSqlCommand(sqlCommand2);
			DataTable dBToDataTable = DBA.GetDBToDataTable(sqlCommand);
			if (dBToDataTable == null)
			{
				return -1;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				dBToDataTable.Dispose();
				return -1;
			}
			if (dBToDataTable.Rows[0]["FLD_LOCK"].ToString() == "10")
			{
				string text = dBToDataTable.Rows[0]["FLD_LASTLOGINIP"].ToString();
				if (text != "127.0.0.1")
				{
					string[] array = text.Split('.');
					string[] array2 = ip.Split('.');
					if (array[0] != array2[0] && array[1] != array2[1] && array[2] != array2[2])
					{
						return -3;
					}
				}
			}
			string text2;
			if (pwd.Length >= 36)
			{
				byte[] obj = new byte[12]
				{
					170, 171, 172, 173, 174, 175, 186, 187, 188, 189,
					190, 191
				};
				text2 = BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(dBToDataTable.Rows[0]["FLD_PASSWORD"].ToString()))).Replace("-", "").ToLower();
				int num = Convert.ToInt32(pwd.Remove(2, pwd.Length - 2), 16);
				int num2 = obj[num];
				byte[] array3 = Converter.hexStringToByte(pwd);
				for (int i = 0; i < array3.Length; i++)
				{
					array3[i] ^= (byte)num2;
				}
				string text3 = Converter.ToString(array3).Replace("   ", "").ToLower();
				pwd = text3.Substring(2, text3.Length - 4);
				Console.WriteLine(text3.Substring(2, text3.Length - 4));
			}
			else
			{
				text2 = dBToDataTable.Rows[0]["FLD_PASSWORD"].ToString();
			}
			if (text2 != pwd)
			{
				dBToDataTable.Dispose();
				return 0;
			}
			if (int.Parse(dBToDataTable.Rows[0]["FLD_ZT"].ToString()) != 0)
			{
				return int.Parse(dBToDataTable.Rows[0]["FLD_ZT"].ToString());
			}
			dBToDataTable.Dispose();
			return -99;
		}

		public static int ReplaceComma(string WebString)
		{
			if (Regex.IsMatch(WebString, "^(?:[\\u4e00-\\u9fa5]*\\w*\\s*)+$"))
			{
				return 0;
			}
			return -1;
		}

		public static int DAXIE(string WebString)
		{
			if (Regex.IsMatch(WebString, "^[a-z0-9]+$"))
			{
				return 0;
			}
			MainForm.WriteLine(5, "用户非法复制注入[" + WebString + "]拦截成功");
			return -1;
		}

		public static int GetUserIP(string ip)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_BANED WHERE FLD_BANEDIP='" + ip + "'");
			if (dBToDataTable != null && dBToDataTable.Rows.Count != 0)
			{
				return -1;
			}
			return 0;
		}

		public static int GetUserNIP(string nip)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_BANED WHERE FLD_BANEDNIP='" + nip + "'");
			if (dBToDataTable != null && dBToDataTable.Rows.Count != 0)
			{
				return -1;
			}
			return 0;
		}

		public unsafe static bool IsEquals(string str1, string str2)
		{
			if (str1.Length != str2.Length)
			{
				return false;
			}
			bool result = true;
			int num = str1.Length % 4 != 0 ? 4 - str1.Length % 4 : 0;
			int num2 = str2.Length % 4 != 0 ? 4 - str1.Length % 4 : 0;
			int num3 = num > num2 ? num : num2;
			int i;
			for (i = 0; i < num3; i++)
			{
				if (i < num)
				{
					str1 += "  ";
				}
				if (i < num2)
				{
					str2 += "  ";
				}
			}
			fixed (char* ptr = str1)
			{
				fixed (char* ptr3 = str2)
				{
					char* ptr2 = ptr;
					char* ptr4 = ptr3;
					while (i < str1.Length)
					{
						if (*(long*)ptr2 != *(long*)ptr4)
						{
							result = false;
							break;
						}
						i += 4;
						ptr2 += 4;
						ptr4 += 4;
					}
				}
			}
			return result;
		}

		public static string GetPartitionID(string account)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_ACCOUNT WHERE FLD_ID='" + account + "'");
			string result = "";
			if (dBToDataTable != null)
			{
				if (dBToDataTable.Rows.Count == 0)
				{
					dBToDataTable.Dispose();
					return result;
				}
				string result2 = dBToDataTable.Rows[0]["FLD_FQ"].ToString();
				dBToDataTable.Dispose();
				return result2;
			}
			dBToDataTable.Dispose();
			return result;
		}
	}
}
