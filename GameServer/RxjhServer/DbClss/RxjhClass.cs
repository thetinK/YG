using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using RxjhServer.HelperTools;

namespace RxjhServer.DbClss
{
	public class RxjhClass
	{
		private static readonly ItmesIDClass ItmeId = new ItmesIDClass();

		public static string md5(string strmm)
		{
			return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(strmm))).Replace("-", string.Empty).ToLower();
		}

		public static long GetDBItmeId()
		{
			return ItmeId.AcquireBuffer();
		}

		public static DataTable 得到玩家每日任务(string userid, string username, int rwpid, bool 是否账号每日)
		{
			string sqlCommand = $"SELECT * FROM [TBL_XWWL_EveTask] where FLD_Userid='{userid}' and FLD_UserName='{username}' and FLD_TaskID={rwpid}";
			if (是否账号每日)
			{
				sqlCommand = $"SELECT * FROM [TBL_XWWL_EveTask] where FLD_Userid='{userid}' and FLD_TaskID={rwpid}";
			}
			DataTable dBToDataTable = DBA.GetDBToDataTable(sqlCommand);
			if (dBToDataTable == null)
			{
				return null;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				dBToDataTable.Dispose();
				return null;
			}
			return dBToDataTable;
		}

		public static int 添加玩家每日任务完成(string userid, string username, int rwpid)
		{
			return DBA.ExeSqlCommand($"INSERT INTO [TBL_XWWL_EveTask]([FLD_Userid], [FLD_UserName], [FLD_TaskID], [FLD_LastTime])VALUES('{userid}','{username}', {rwpid}, '{DateTime.Now}')");
		}

		public static int 更新玩家每日任务完成(int id, string username)
		{
			return DBA.ExeSqlCommand($"UPDATE [TBL_XWWL_EveTask] SET FLD_UserName = '{username}', FLD_LastTime = '{DateTime.Now}' WHERE ID = {id}");
		}

		public static DataTable 得到自定义任务阶段(int rwpid)
		{
			string sqlCommand = $"SELECT * FROM [TBL_XWWL_MISSION_STAGE] where 任务ID='{rwpid}' order by 任务阶段ID";
			DataTable dBToDataTable = DBA.GetDBToDataTable(sqlCommand, "PublicDb");
			if (dBToDataTable == null)
			{
				return null;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				dBToDataTable.Dispose();
				return null;
			}
			return dBToDataTable;
		}

		public static void 变更门服(int 帮派id, int 门服字, int 门服颜色)
		{
			DBA.ExeSqlCommand(string.Format("UPDATE TBL_XWWL_Guild SET 门服字={1}, 门服颜色={2} WHERE ID='{0}'", 帮派id, 门服字, 门服颜色));
		}

		public static void msglog(string userid, string username, string tousername, string msg, int msgType)
		{
			DBA.ExeSqlCommand($"INSERT INTO MsgLog (userid, username, ToUserName, msg, msgType) VALUES ('{userid}','{username}','{tousername}','{msg}', {msgType})");
		}

		public static void 更新登陆IP(string Userid, string ip)
		{
			SqlDBA.RunProc(new SqlConnection(DBA.getstrConnection("rxjhaccount")), "XWWL_UPDATE_ACCOUNT_ZOGINIP", new SqlParameter[2]
			{
				SqlDBA.MakeInParam("@id", SqlDbType.VarChar, 30, Userid),
				SqlDBA.MakeInParam("@ip", SqlDbType.VarChar, 30, ip)
			});
		}

		public static int GetUserIP(string ip)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_BANED WHERE FLD_BANEDIP='" + ip + "'", "rxjhaccount");
			if (dBToDataTable != null && dBToDataTable.Rows.Count != 0)
			{
				return -1;
			}
			return 0;
		}

		public static void 保存普通暴率(DropClass drop)
		{
			SqlParameter[] prams = new SqlParameter[2]
			{
				SqlDBA.MakeInParam("@id", SqlDbType.Int, 30, drop.ID),
				SqlDBA.MakeInParam("@dqsl", SqlDbType.Int, 30, drop.当前数量)
			};
			DbPoolClass obj = new DbPoolClass
			{
				Conn = DBA.getstrConnection("PublicDb"),
				Prams = prams,
				Sql = "XWWL_UPDATE_drop"
			};
			World.SqlPool.Enqueue(obj);
		}

		public static void 掉落记录(string UserId, string UserName, long 全局ID, int 物品ID, string 物品名, int FLD_MAGIC0, int FLD_MAGIC1, int FLD_MAGIC2, int FLD_MAGIC3, int FLD_MAGIC4, int FLD_MAP, int x, int y, string type)
		{
			if (World.掉落记录 == 1)
			{
				string sql = "INSERT INTO 掉落记录 (FLD_ID, FLD_NAME, FLD_QJID, FLD_PID, FLD_INAME, FLD_MAGIC0, FLD_MAGIC1, FLD_MAGIC2, FLD_MAGIC3, FLD_MAGIC4, FLD_MAP, FLD_X, FLD_Y, FLD_TYPE) VALUES (@UserId, @UserName, @qjid, @pid, @iname, @magic0, @magic1, @magic2, @magic3, @magic4, @map, @x, @y, @type)";
				SqlParameter[] prams = new SqlParameter[14]
				{
					SqlDBA.MakeInParam("@UserId", SqlDbType.VarChar, 30, UserId),
					SqlDBA.MakeInParam("@UserName", SqlDbType.VarChar, 30, UserName),
					SqlDBA.MakeInParam("@qjid", SqlDbType.Int, 4, 全局ID),
					SqlDBA.MakeInParam("@pid", SqlDbType.Int, 4, 物品ID),
					SqlDBA.MakeInParam("@iname", SqlDbType.VarChar, 30, 物品名),
					SqlDBA.MakeInParam("@magic0", SqlDbType.Int, 4, FLD_MAGIC0),
					SqlDBA.MakeInParam("@magic1", SqlDbType.Int, 4, FLD_MAGIC1),
					SqlDBA.MakeInParam("@magic2", SqlDbType.Int, 4, FLD_MAGIC2),
					SqlDBA.MakeInParam("@magic3", SqlDbType.Int, 4, FLD_MAGIC3),
					SqlDBA.MakeInParam("@magic4", SqlDbType.Int, 4, FLD_MAGIC4),
					SqlDBA.MakeInParam("@map", SqlDbType.Int, 4, FLD_MAP),
					SqlDBA.MakeInParam("@x", SqlDbType.Int, 4, x),
					SqlDBA.MakeInParam("@y", SqlDbType.Int, 4, y),
					SqlDBA.MakeInParam("@type", SqlDbType.VarChar, 30, type)
				};
				World.SqlPool.Enqueue(new DbPoolClass
				{
					Conn = DBA.getstrConnection(null),
					Prams = prams,
					Sql = sql,
					Type = 1
				});
			}
		}

		public static void 开盒记录(string UserId, string UserName, long 全局ID, int 物品ID, string 物品名, int FLD_MAGIC0, int FLD_MAGIC1, int FLD_MAGIC2, int FLD_MAGIC3, int FLD_MAGIC4, int FLD_MAP, int x, int y, string type)
		{
			if (World.开盒记录 == 1)
			{
				string sql = "INSERT INTO 开盒记录 (FLD_ID, FLD_NAME, FLD_QJID, FLD_PID, FLD_INAME, FLD_MAGIC0, FLD_MAGIC1, FLD_MAGIC2, FLD_MAGIC3, FLD_MAGIC4, FLD_MAP, FLD_X, FLD_Y, FLD_TYPE) VALUES (@UserId, @UserName, @qjid, @pid, @iname, @magic0, @magic1, @magic2, @magic3, @magic4, @map, @x, @y, @type)";
				SqlParameter[] prams = new SqlParameter[14]
				{
					SqlDBA.MakeInParam("@UserId", SqlDbType.VarChar, 30, UserId),
					SqlDBA.MakeInParam("@UserName", SqlDbType.VarChar, 30, UserName),
					SqlDBA.MakeInParam("@qjid", SqlDbType.Int, 4, 全局ID),
					SqlDBA.MakeInParam("@pid", SqlDbType.Int, 4, 物品ID),
					SqlDBA.MakeInParam("@iname", SqlDbType.VarChar, 30, 物品名),
					SqlDBA.MakeInParam("@magic0", SqlDbType.Int, 4, FLD_MAGIC0),
					SqlDBA.MakeInParam("@magic1", SqlDbType.Int, 4, FLD_MAGIC1),
					SqlDBA.MakeInParam("@magic2", SqlDbType.Int, 4, FLD_MAGIC2),
					SqlDBA.MakeInParam("@magic3", SqlDbType.Int, 4, FLD_MAGIC3),
					SqlDBA.MakeInParam("@magic4", SqlDbType.Int, 4, FLD_MAGIC4),
					SqlDBA.MakeInParam("@map", SqlDbType.Int, 4, FLD_MAP),
					SqlDBA.MakeInParam("@x", SqlDbType.Int, 4, x),
					SqlDBA.MakeInParam("@y", SqlDbType.Int, 4, y),
					SqlDBA.MakeInParam("@type", SqlDbType.VarChar, 30, type)
				};
				World.SqlPool.Enqueue(new DbPoolClass
				{
					Conn = DBA.getstrConnection(null),
					Prams = prams,
					Sql = sql,
					Type = 1
				});
			}
		}

		public static void 保存安全码数据(string id, string nip)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "PlayersBes_保存密码数据()");
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("UPDATE [TBL_ACCOUNT] SET FLD_CARD = '{1}' WHERE FLD_ID = '{0}'", id, nip);
			if (DBA.ExeSqlCommand(stringBuilder.ToString(), "rxjhaccount") == -1)
			{
				MainForm.WriteLine(1, "保存密码数据 数据出错[" + id + "]");
			}
		}

		public static void 保存元宝数据(string Userid, int rxpiont, int rxpiontx, int zjf, int SPREADER_LEVEL)
		{
			SqlDBA.RunProc(new SqlConnection(DBA.getstrConnection("rxjhaccount")), "XWWL_UPDATE_RXPIONTX", new SqlParameter[5]
			{
				SqlDBA.MakeInParam("@id", SqlDbType.VarChar, 20, Userid),
				SqlDBA.MakeInParam("@rxpiont", SqlDbType.Int, 4, rxpiont),
				SqlDBA.MakeInParam("@rxpiontx", SqlDbType.Int, 4, rxpiontx),
				SqlDBA.MakeInParam("@zjf", SqlDbType.Int, 4, zjf),
				SqlDBA.MakeInParam("@spreaderlv", SqlDbType.Int, 4, SPREADER_LEVEL)
			});
		}

		public static DataTable 得到下线账号(string strSpId)
		{
			DataTable dataTable = SqlDBA.RunProcc(new SqlConnection(DBA.getstrConnection("rxjhaccount")), "XWWL_WEB_LOAD_ACCOUNT_SPREADERID", new SqlParameter[1] { SqlDBA.MakeInParam("@id", SqlDbType.VarChar, 30, strSpId) });
			if (dataTable != null)
			{
				if (dataTable.Rows.Count > 0)
				{
					return dataTable;
				}
				dataTable.Dispose();
			}
			return null;
		}

		public static DataTable 得到上线账号(string strSpId)
		{
			DataTable dataTable = SqlDBA.RunProcc(new SqlConnection(DBA.getstrConnection("rxjhaccount")), "XWWL_WEB_LOAD_ACCOUNT_USERID", new SqlParameter[1] { SqlDBA.MakeInParam("@id", SqlDbType.VarChar, 30, strSpId) });
			if (dataTable != null)
			{
				if (dataTable.Rows.Count > 0)
				{
					return dataTable;
				}
				dataTable.Dispose();
			}
			return null;
		}

		public static DataTable 得到人物数据ID(string Userid)
		{
			DataTable dataTable = SqlDBA.RunProcc(new SqlConnection(DBA.getstrConnection(null)), "XWWL_LOAD_CHARS", new SqlParameter[1] { SqlDBA.MakeInParam("@id", SqlDbType.VarChar, 30, Userid) });
			if (dataTable != null)
			{
				if (dataTable.Rows.Count > 0)
				{
					return dataTable;
				}
				dataTable.Dispose();
			}
			return null;
		}

		public static void 商店记录(string UserId, string UserName, int 物品ID, string 物品名, string 类型, int 数量, long 单价, int MAGIC0, int MAGIC1, int MAGIC2, int MAGIC3, int MAGIC4)
		{
			if (World.商店记录 == 1)
			{
				string sql = "INSERT INTO 商店记录 (FLD_ID, FLD_NAME, FLD_PID, FLD_INAME, FLD_TYPE, FLD_NUM, FLD_PRICE, FLD_MAGIC0, FLD_MAGIC1, FLD_MAGIC2, FLD_MAGIC3, FLD_MAGIC4) VALUES (@UserId, @UserName, @pid, @iname, @type, @number, @price, @magic0, @magic1, @magic2, @magic3, @magic4)";
				SqlParameter[] prams = new SqlParameter[12]
				{
					SqlDBA.MakeInParam("@UserId", SqlDbType.VarChar, 30, UserId),
					SqlDBA.MakeInParam("@UserName", SqlDbType.VarChar, 30, UserName),
					SqlDBA.MakeInParam("@pid", SqlDbType.Int, 4, 物品ID),
					SqlDBA.MakeInParam("@iname", SqlDbType.VarChar, 30, 物品名),
					SqlDBA.MakeInParam("@type", SqlDbType.VarChar, 30, 类型),
					SqlDBA.MakeInParam("@number", SqlDbType.Int, 4, 数量),
					SqlDBA.MakeInParam("@price", SqlDbType.VarChar, 50, 单价.ToString()),
					SqlDBA.MakeInParam("@magic0", SqlDbType.Int, 4, MAGIC0),
					SqlDBA.MakeInParam("@magic1", SqlDbType.Int, 4, MAGIC1),
					SqlDBA.MakeInParam("@magic2", SqlDbType.Int, 4, MAGIC2),
					SqlDBA.MakeInParam("@magic3", SqlDbType.Int, 4, MAGIC3),
					SqlDBA.MakeInParam("@magic4", SqlDbType.Int, 4, MAGIC4)
				};
				World.SqlPool.Enqueue(new DbPoolClass
				{
					Conn = DBA.getstrConnection(null),
					Prams = prams,
					Sql = sql,
					Type = 1
				});
			}
		}

		public static void 药品记录(string UserId, string UserName, int 物品ID, string 物品名, int 数量)
		{
			if (World.药品记录 == 1)
			{
				string sql = "INSERT INTO 药品记录 (FLD_ID, FLD_NAME, FLD_PID, FLD_INAME, FLD_NUM) VALUES (@UserId, @UserName, @pid, @iname, @number)";
				SqlParameter[] prams = new SqlParameter[5]
				{
					SqlDBA.MakeInParam("@UserId", SqlDbType.VarChar, 30, UserId),
					SqlDBA.MakeInParam("@UserName", SqlDbType.VarChar, 30, UserName),
					SqlDBA.MakeInParam("@pid", SqlDbType.Int, 4, 物品ID),
					SqlDBA.MakeInParam("@iname", SqlDbType.VarChar, 30, 物品名),
					SqlDBA.MakeInParam("@number", SqlDbType.Int, 4, 数量)
				};
				World.SqlPool.Enqueue(new DbPoolClass
				{
					Conn = DBA.getstrConnection(null),
					Prams = prams,
					Sql = sql,
					Type = 1
				});
			}
		}

		public static void 合成记录(string UserId, string UserName, string 物品名, int 操作ID, string 类型, string 成败, 物品类 物品)
		{
			if (World.合成记录 == 1)
			{
				string sql = "INSERT INTO 合成记录 (FLD_ID, FLD_NAME, FLD_QJID, FLD_PID, FLD_INAME, FLD_MAGIC0, FLD_MAGIC1, FLD_MAGIC2, FLD_MAGIC3, FLD_MAGIC4, FLD_TYPE, FLD_CZID, FLD_SUCCESS, FLD_QHJD) VALUES (@UserId, @UserName, @qjid, @pid, @iname, @magic0, @magic1, @magic2, @magic3, @magic4, @type, @czid, @success, @qhjd)";
				SqlParameter[] prams = new SqlParameter[14]
				{
					SqlDBA.MakeInParam("@UserId", SqlDbType.VarChar, 30, UserId),
					SqlDBA.MakeInParam("@UserName", SqlDbType.VarChar, 30, UserName),
					SqlDBA.MakeInParam("@qjid", SqlDbType.Int, 4, (int)物品.Get物品全局ID),
					SqlDBA.MakeInParam("@pid", SqlDbType.Int, 4, (int)物品.Get物品ID),
					SqlDBA.MakeInParam("@iname", SqlDbType.VarChar, 30, 物品.得到物品名称()),
					SqlDBA.MakeInParam("@magic0", SqlDbType.Int, 4, 物品.FLD_MAGIC0),
					SqlDBA.MakeInParam("@magic1", SqlDbType.Int, 4, 物品.FLD_MAGIC1),
					SqlDBA.MakeInParam("@magic2", SqlDbType.Int, 4, 物品.FLD_MAGIC2),
					SqlDBA.MakeInParam("@magic3", SqlDbType.Int, 4, 物品.FLD_MAGIC3),
					SqlDBA.MakeInParam("@magic4", SqlDbType.Int, 4, 物品.FLD_MAGIC4),
					SqlDBA.MakeInParam("@type", SqlDbType.VarChar, 30, 类型),
					SqlDBA.MakeInParam("@czid", SqlDbType.Int, 4, 操作ID),
					SqlDBA.MakeInParam("@success", SqlDbType.VarChar, 30, 成败),
					SqlDBA.MakeInParam("@qhjd", SqlDbType.Int, 4, 物品.FLD_强化数量)
				};
				World.SqlPool.Enqueue(new DbPoolClass
				{
					Conn = DBA.getstrConnection(null),
					Prams = prams,
					Sql = sql,
					Type = 1
				});
			}
		}

		public static void 进化记录(string UserId, string UserName, int 物品ID, string 物品名, int 数量)
		{
			if (World.进化记录 == 1)
			{
				string sql = "INSERT INTO 进化记录 (FLD_ID, FLD_NAME, FLD_PID, FLD_ML, FLD_HCPID) VALUES (@UserId, @UserName, @pid, @iname, @number)";
				SqlParameter[] prams = new SqlParameter[5]
				{
					SqlDBA.MakeInParam("@UserId", SqlDbType.VarChar, 30, UserId),
					SqlDBA.MakeInParam("@UserName", SqlDbType.VarChar, 30, UserName),
					SqlDBA.MakeInParam("@pid", SqlDbType.Int, 4, 物品ID),
					SqlDBA.MakeInParam("@iname", SqlDbType.VarChar, 30, 物品名),
					SqlDBA.MakeInParam("@number", SqlDbType.Int, 4, 数量)
				};
				World.SqlPool.Enqueue(new DbPoolClass
				{
					Conn = DBA.getstrConnection(null),
					Prams = prams,
					Sql = sql,
					Type = 1
				});
			}
		}

		public static void 卡号记录(string UserId, string UserName, string 物品名, int 职业)
		{
			if (World.卡号记录 == 1)
			{
				string sql = "INSERT INTO 卡号记录 (FLD_ID, FLD_NAME, FLD_ML, FLD_职业) VALUES (@UserId, @UserName, @iname, @number)";
				SqlParameter[] prams = new SqlParameter[4]
				{
					SqlDBA.MakeInParam("@UserId", SqlDbType.VarChar, 30, UserId),
					SqlDBA.MakeInParam("@UserName", SqlDbType.VarChar, 30, UserName),
					SqlDBA.MakeInParam("@iname", SqlDbType.VarChar, 30, 物品名),
					SqlDBA.MakeInParam("@number", SqlDbType.Int, 4, 职业)
				};
				World.SqlPool.Enqueue(new DbPoolClass
				{
					Conn = DBA.getstrConnection(null),
					Prams = prams,
					Sql = sql,
					Type = 1
				});
			}
		}

		public static void 百宝记录(string UserId, string UserName, double 物品ID, string 物品名, int 物品数量, int 元宝数)
		{
			DBA.ExeSqlCommand($"INSERT INTO 百宝记录 (UserId, UserName, 物品ID, 物品名, 物品数量, 元宝数) VALUES ('{UserId}','{UserName}','{物品ID}','{物品名}', {物品数量}, {元宝数})");
		}

		public static void 元宝记录(string 账号, string 名字, string 类型, string 来源, string 币种, int 数量)
		{
			DBA.ExeSqlCommand($"INSERT INTO 元宝记录 (账号, 名字, 类型, 来源, 币种, 数量) VALUES ('{账号}','{名字}','{类型}','{来源}','{币种}', {数量})");
		}

		public static void 登陆记录(string UserId, string UserName, string UserIp, string 类型)
		{
			if (World.登陆记录 == 1)
			{
				string sql = "INSERT INTO 登陆记录 (UserId, UserName, UserIp, 类型) VALUES (@UserId, @UserName, @UserIp, @类型)";
				SqlParameter[] prams = new SqlParameter[4]
				{
					SqlDBA.MakeInParam("@UserId", SqlDbType.VarChar, 30, UserId),
					SqlDBA.MakeInParam("@UserName", SqlDbType.VarChar, 30, UserName),
					SqlDBA.MakeInParam("@UserIp", SqlDbType.VarChar, 30, UserIp),
					SqlDBA.MakeInParam("@类型", SqlDbType.VarChar, 30, 类型)
				};
				World.SqlPool.Enqueue(new DbPoolClass
				{
					Conn = DBA.getstrConnection(null),
					Prams = prams,
					Sql = sql,
					Type = 1
				});
			}
		}

		public static void 物品记录(string UserId, string UserName, string ToUserId, string ToUserName, double 全局ID, int 物品ID, string 物品名, int 物品数量, string 物品属性, int 钱数, string 类型)
		{
			if (World.物品记录 == 1)
			{
				string sql = "INSERT INTO 物品记录 (UserId, UserName, ToUserId, ToUserName, 全局ID, 物品ID, 物品名, 物品数量, 物品属性, 钱数, 类型) VALUES (@UserId, @UserName, @ToUserId, @ToUserName, @全局ID, @物品ID, @物品名, @物品数量, @物品属性, @钱数, @类型)";
				SqlParameter[] prams = new SqlParameter[11]
				{
					SqlDBA.MakeInParam("@UserId", SqlDbType.VarChar, 30, UserId),
					SqlDBA.MakeInParam("@UserName", SqlDbType.VarChar, 30, UserName),
					SqlDBA.MakeInParam("@ToUserId", SqlDbType.VarChar, 30, ToUserId),
					SqlDBA.MakeInParam("@ToUserName", SqlDbType.VarChar, 30, ToUserName),
					SqlDBA.MakeInParam("@全局ID", SqlDbType.VarChar, 30, 全局ID),
					SqlDBA.MakeInParam("@物品ID", SqlDbType.VarChar, 30, 物品ID),
					SqlDBA.MakeInParam("@物品名", SqlDbType.VarChar, 30, 物品名),
					SqlDBA.MakeInParam("@物品数量", SqlDbType.Int, 4, 物品数量),
					SqlDBA.MakeInParam("@物品属性", SqlDbType.VarChar, 100, 物品属性),
					SqlDBA.MakeInParam("@钱数", SqlDbType.Int, 4, 钱数),
					SqlDBA.MakeInParam("@类型", SqlDbType.VarChar, 10, 类型)
				};
				World.SqlPool.Enqueue(new DbPoolClass
				{
					Conn = DBA.getstrConnection(null),
					Prams = prams,
					Sql = sql,
					Type = 1
				});
			}
		}

		public static void 帮战赌注(string UserId, string UserName, int 帮派ID, int 元宝数)
		{
			DBA.ExeSqlCommand($"INSERT INTO 帮战赌注 (UserId, UserName, 帮派ID, 元宝数) VALUES ('{UserId}','{UserName}', {帮派ID}, {元宝数})");
		}

		public static void 帮战赌注删除(string UserId, string UserName, int 帮派ID, int sl)
		{
			DBA.ExeSqlCommand($"DELETE FROM 帮战赌注 WHERE UserId = '{UserId}' and UserName='{UserName}' and UserName='{帮派ID}'");
			switch (sl)
			{
			case -1:
				DBA.ExeSqlCommand($"UPDATE TBL_XWWL_Guild SET 败=败+1 WHERE ID='{帮派ID}'");
				百宝记录(UserId, UserName, 0.0, "帮战失败输掉", 1, 50);
				break;
			case 0:
				DBA.ExeSqlCommand($"UPDATE TBL_XWWL_Guild SET 平=平+1 WHERE ID='{帮派ID}'");
				break;
			case 1:
				DBA.ExeSqlCommand($"UPDATE TBL_XWWL_Guild SET 胜=胜+1 WHERE ID='{帮派ID}'");
				百宝记录(UserId, UserName, 0.0, "帮战胜利得到", 1, 50);
				break;
			}
		}

		public static void 申请门徽(int 帮派id, byte[] _门徽)
		{
			DBA.ExeSqlCommand(string.Format("UPDATE TBL_XWWL_Guild SET 门徽={1} WHERE ID='{0}'", 帮派id, Converter.ToString1(_门徽)));
		}

		public static byte[] 得到门徽(int id)
		{
			try
			{
				DataTable dBToDataTable = DBA.GetDBToDataTable($"SELECT * FROM TBL_XWWL_Guild WHERE ID = {id}");
				if (dBToDataTable == null)
				{
					return null;
				}
				if (dBToDataTable.Rows.Count == 0)
				{
					dBToDataTable.Dispose();
					return null;
				}
				if (dBToDataTable.Rows[0]["门徽"].GetType().ToString() == "System.DBNull")
				{
					dBToDataTable.Dispose();
					return null;
				}
				byte[] array = (byte[])dBToDataTable.Rows[0]["门徽"];
				if (array != null)
				{
					dBToDataTable.Dispose();
					return array;
				}
				dBToDataTable.Dispose();
				return null;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "得到门徽出错 " + ex.Message);
				return null;
			}
		}

		public static void 帮派赋予职位(int zw, string name)
		{
			DBA.ExeSqlCommand("UPDATE TBL_XWWL_GuildMember SET Leve=@zw WHERE FLD_NAME=@Username", new SqlParameter[2]
			{
				SqlDBA.MakeInParam("@zw", SqlDbType.Int, 0, zw),
				SqlDBA.MakeInParam("@Username", SqlDbType.VarChar, 30, name)
			});
		}

		public static void 赋予帮主职位(string 新帮主, string 老帮主, string 帮派名称)
		{
			string sqlCommand = "UPDATE TBL_XWWL_GuildMember SET Leve=@zw WHERE FLD_NAME=@Username";
			SqlParameter[] prams = new SqlParameter[2]
			{
				SqlDBA.MakeInParam("@zw", SqlDbType.Int, 0, 5),
				SqlDBA.MakeInParam("@Username", SqlDbType.VarChar, 30, 老帮主)
			};
			string sqlCommand2 = "UPDATE TBL_XWWL_Guild SET G_Master=@Uname WHERE G_Name=@Gname";
			SqlParameter[] prams2 = new SqlParameter[2]
			{
				SqlDBA.MakeInParam("@Uname", SqlDbType.VarChar, 30, 新帮主),
				SqlDBA.MakeInParam("@Gname", SqlDbType.VarChar, 30, 帮派名称)
			};
			DBA.ExeSqlCommand(sqlCommand, prams);
			DBA.ExeSqlCommand(sqlCommand2, prams2);
		}

		public static int 创建帮派确认(string 帮派name)
		{
			return (int)DBA.GetDBValue_3("EXEC XWWL_SELECT_Guild_DATA @bpnamea", new SqlParameter[1] { SqlDBA.MakeInParam("@bpnamea", SqlDbType.VarChar, 30, 帮派name) });
		}

		public static int 创建帮派(string name, string 帮派name, int leve)
		{
			return (int)DBA.GetDBValue_3("EXEC XWWL_INT_Guild_DATA_New @name, @bpname, @leve", new SqlParameter[3]
			{
				SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, name),
				SqlDBA.MakeInParam("@bpname", SqlDbType.VarChar, 30, 帮派name),
				SqlDBA.MakeInParam("@leve", SqlDbType.Int, 0, leve)
			});
		}

		public static int 加入帮派(string name, string 帮派name, int leve)
		{
			return (int)DBA.GetDBValue_3(string.Format("EXEC XWWL_JR_Guild_DATA_New @name, @bpname, @leve", name, 帮派name, leve), new SqlParameter[3]
			{
				SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, name),
				SqlDBA.MakeInParam("@bpname", SqlDbType.VarChar, 30, 帮派name),
				SqlDBA.MakeInParam("@leve", SqlDbType.Int, 0, leve)
			});
		}

		public static int 退出门派(string name)
		{
			return (int)DBA.GetDBValue_3("EXEC XWWL_Out_Guild_DATA @name", new SqlParameter[1] { SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, name) });
		}

		public static int 逐出门派(string name, string 帮派name)
		{
			return (int)DBA.GetDBValue_3("EXEC XWWL_OutBz_Guild_DATA @name, @bpname", new SqlParameter[2]
			{
				SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, name),
				SqlDBA.MakeInParam("@bpname", SqlDbType.VarChar, 30, 帮派name)
			});
		}

		public static int GetUserName(string name)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT FLD_NAME FROM TBL_XWWL_Char WHERE FLD_NAME=@name", new SqlParameter[1] { SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, name) });
			if (dBToDataTable == null)
			{
				return -1;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				dBToDataTable.Dispose();
				return 1;
			}
			dBToDataTable.Dispose();
			return -1;
		}

		public static DataTable 得到帮派人数(string name)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_GuildMember WHERE G_Name =@name", new SqlParameter[1] { SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, name) });
			if (dBToDataTable == null)
			{
				return null;
			}
			return (dBToDataTable.Rows.Count != 0) ? dBToDataTable : null;
		}

		public static DataTable 得到帮派数据(string name)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_Guild WHERE G_Name = @name", new SqlParameter[1] { SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, name) });
			if (dBToDataTable == null)
			{
				return null;
			}
			return (dBToDataTable.Rows.Count == 0) ? null : dBToDataTable;
		}

		public static DataTable 得到门战帮派数据(string name)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_GuildPVP WHERE 帮派 = @name", new SqlParameter[1] { SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, name) });
			if (dBToDataTable == null)
			{
				return null;
			}
			return (dBToDataTable.Rows.Count != 0) ? dBToDataTable : null;
		}

		public static DataTable GetUserNameBp(string name)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("EXEC XWWL_LOAD_Guild @name", new SqlParameter[1] { SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, name) });
			if (dBToDataTable == null)
			{
				return null;
			}
			return (dBToDataTable.Rows.Count != 0) ? dBToDataTable : null;
		}

		public static DataTable GetUserCWarehouse(string string_0, string string_1)
		{
			string sqlCommand = "select * from [TBL_XWWL_CWarehouse] where FLD_NAME =@Username";
			SqlParameter[] prams = new SqlParameter[1] { SqlDBA.MakeInParam("@Username", SqlDbType.VarChar, 50, string_1) };
			DataTable dBToDataTable = DBA.GetDBToDataTable(sqlCommand, prams);
			if (dBToDataTable == null)
			{
				return null;
			}
			if (dBToDataTable.Rows.Count != 0)
			{
				return dBToDataTable;
			}
			string sqlCommand2 = "EXEC XWWL_CW_USER_BANK @Userid, @Username, @zb";
			SqlParameter[] prams2 = new SqlParameter[3]
			{
				SqlDBA.MakeInParam("@Userid", SqlDbType.VarChar, 50, string_0),
				SqlDBA.MakeInParam("@Username", SqlDbType.VarChar, 50, string_1),
				SqlDBA.MakeInParam("@zb", SqlDbType.VarBinary, World.数据库单个物品大小 * 20, new byte[World.数据库单个物品大小 * 20])
			};
			DBA.ExeSqlCommand(sqlCommand2, prams2);
			string sqlCommand3 = "select * from [TBL_XWWL_CWarehouse] where FLD_NAME =@Username";
			SqlParameter[] prams3 = new SqlParameter[1] { SqlDBA.MakeInParam("@Username", SqlDbType.VarChar, 30, string_1) };
			DataTable dBToDataTable2 = DBA.GetDBToDataTable(sqlCommand3, prams3);
			if (dBToDataTable2 == null)
			{
				return null;
			}
			if (dBToDataTable2.Rows.Count == 0)
			{
				return null;
			}
			return dBToDataTable2;
		}

		public static DataTable GetUserLSarehouse(string string_0, string string_1)
		{
			string sqlCommand = "select * from [TBL_XWWL_LSarehouse] where FLD_NAME =@Username";
			SqlParameter[] prams = new SqlParameter[1] { SqlDBA.MakeInParam("@Username", SqlDbType.VarChar, 50, string_1) };
			DataTable dBToDataTable = DBA.GetDBToDataTable(sqlCommand, prams);
			if (dBToDataTable == null)
			{
				return null;
			}
			if (dBToDataTable.Rows.Count != 0)
			{
				return dBToDataTable;
			}
			string sqlCommand2 = "EXEC XWWL_LS_USER_BANK @Userid, @Username, @zb";
			SqlParameter[] prams2 = new SqlParameter[3]
			{
				SqlDBA.MakeInParam("@Userid", SqlDbType.VarChar, 50, string_0),
				SqlDBA.MakeInParam("@Username", SqlDbType.VarChar, 50, string_1),
				SqlDBA.MakeInParam("@zb", SqlDbType.VarBinary, World.数据库单个物品大小 * 2, new byte[World.数据库单个物品大小 * 2])
			};
			DBA.ExeSqlCommand(sqlCommand2, prams2);
			string sqlCommand3 = "select * from [TBL_XWWL_LSarehouse] where FLD_NAME =@Username";
			SqlParameter[] prams3 = new SqlParameter[1] { SqlDBA.MakeInParam("@Username", SqlDbType.VarChar, 30, string_1) };
			DataTable dBToDataTable2 = DBA.GetDBToDataTable(sqlCommand3, prams3);
			if (dBToDataTable2 == null)
			{
				return null;
			}
			if (dBToDataTable2.Rows.Count == 0)
			{
				return null;
			}
			return dBToDataTable2;
		}

		public static DataTable GetUserWarehouse(string Userid, string Username)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("select * from [TBL_XWWL_Warehouse] where FLD_ID=@Userid and FLD_NAME =@Username", new SqlParameter[2]
			{
				SqlDBA.MakeInParam("@Userid", SqlDbType.VarChar, 30, Userid),
				SqlDBA.MakeInParam("@Username", SqlDbType.VarChar, 30, Username)
			});
			if (dBToDataTable == null)
			{
				return null;
			}
			if (dBToDataTable.Rows.Count != 0)
			{
				return dBToDataTable;
			}
			DBA.ExeSqlCommand("EXEC XWWL_CREATE_USER_BANK @Userid, @Username, @aa, @zb", new SqlParameter[4]
			{
				SqlDBA.MakeInParam("@Userid", SqlDbType.VarChar, 30, Userid),
				SqlDBA.MakeInParam("@Username", SqlDbType.VarChar, 30, Username),
				SqlDBA.MakeInParam("@aa", SqlDbType.Int, 0, 0),
				SqlDBA.MakeInParam("@zb", SqlDbType.VarBinary, World.数据库单个物品大小 * 60, new byte[World.数据库单个物品大小 * 60])
			});
			DataTable dBToDataTable2 = DBA.GetDBToDataTable("select * from [TBL_XWWL_Warehouse] where FLD_ID=@Userid and FLD_NAME =@Username", new SqlParameter[2]
			{
				SqlDBA.MakeInParam("@Userid", SqlDbType.VarChar, 30, Userid),
				SqlDBA.MakeInParam("@Username", SqlDbType.VarChar, 30, Username)
			});
			if (dBToDataTable2 == null)
			{
				return null;
			}
			return (dBToDataTable2.Rows.Count != 0) ? dBToDataTable2 : null;
		}

		public static DataTable GetUserPublicWarehouse(string Userid)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("select * from [TBL_XWWL_PublicWarehouse] where FLD_ID=@Userid", new SqlParameter[1] { SqlDBA.MakeInParam("@Userid", SqlDbType.VarChar, 30, Userid) });
			if (dBToDataTable == null)
			{
				return null;
			}
			if (dBToDataTable.Rows.Count != 0)
			{
				return dBToDataTable;
			}
			Converter.ToString1(new byte[World.数据库单个物品大小 * 60]);
			Converter.ToString1(new byte[60]);
			DBA.ExeSqlCommand("EXEC XWWL_CREATE_ID_BANK @Userid, @aaa, @ck, @ck1", new SqlParameter[4]
			{
				SqlDBA.MakeInParam("@Userid", SqlDbType.VarChar, 30, Userid),
				SqlDBA.MakeInParam("@aaa", SqlDbType.Int, 0, 0),
				SqlDBA.MakeInParam("@ck", SqlDbType.VarBinary, World.数据库单个物品大小 * 60, new byte[World.数据库单个物品大小 * 60]),
				SqlDBA.MakeInParam("@ck1", SqlDbType.VarBinary, 50, new byte[50])
			});
			DataTable dBToDataTable2 = DBA.GetDBToDataTable("select * from [TBL_XWWL_PublicWarehouse] where FLD_ID='" + Userid + "'", new SqlParameter[1] { SqlDBA.MakeInParam("@Userid", SqlDbType.VarChar, 30, Userid) });
			if (dBToDataTable2 == null)
			{
				return null;
			}
			return (dBToDataTable2.Rows.Count != 0) ? dBToDataTable2 : null;
		}

		public static int SetUserName(string id, string name, int zy, byte[] coue)
		{
			byte[] array = new byte[73];
			byte[] array2 = new byte[1155];
			byte[] array3 = new byte[2772];
			byte[] array4 = new byte[385];
			byte[] bytes = BitConverter.GetBytes(GetDBItmeId());
			byte[] src = new byte[4];
			byte[] bytes2 = BitConverter.GetBytes(1);
			switch (zy)
			{
			case 1:
				src = BitConverter.GetBytes(100200002);
				break;
			case 2:
				src = BitConverter.GetBytes(200200002);
				break;
			case 3:
				src = BitConverter.GetBytes(300200002);
				break;
			case 4:
				src = BitConverter.GetBytes(400200002);
				break;
			case 5:
				src = BitConverter.GetBytes(500200002);
				break;
			case 6:
				src = BitConverter.GetBytes(700200002);
				break;
			case 7:
				src = BitConverter.GetBytes(800200001);
				break;
			case 8:
				src = BitConverter.GetBytes(100204001);
				break;
			case 9:
				src = BitConverter.GetBytes(200204001);
				break;
			case 10:
				src = BitConverter.GetBytes(900200001);
				break;
			case 11:
				src = BitConverter.GetBytes(400204001);
				break;
			case 12:
				src = BitConverter.GetBytes(300204001);
				break;
			case 13:
				src = BitConverter.GetBytes(500204001);
				break;
			}
			Buffer.BlockCopy(bytes, 0, array, 0, 4);
			Buffer.BlockCopy(src, 0, array, 8, 4);
			Buffer.BlockCopy(bytes2, 0, array, 12, 4);
			Buffer.BlockCopy(array, 0, array3, 0, 73);
			if (World.上线送礼包是否开启 == 1)
			{
				byte[] bytes3 = BitConverter.GetBytes(1);
				Buffer.BlockCopy(BitConverter.GetBytes(GetDBItmeId()), 0, array4, 0, 4);
				Buffer.BlockCopy(BitConverter.GetBytes(World.上线送礼包套装), 0, array4, 8, 4);
				Buffer.BlockCopy(bytes3, 0, array4, 12, 4);
				Buffer.BlockCopy(array4, 0, array3, 73, 385);
			}
			int num = 0;
			DataTable dBToDataTable = DBA.GetDBToDataTable("Select FLD_INDEX FROM TBL_XWWL_Char Where FLD_ID=@FLD_ID", new SqlParameter[1] { SqlDBA.MakeInParam("@FLD_ID", SqlDbType.VarChar, 30, id) });
			if (dBToDataTable.Rows.Count >= 4)
			{
				dBToDataTable.Dispose();
				return -1;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				num = 0;
			}
			else
			{
				List<int> list = new List<int>();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					int item = (int)dBToDataTable.Rows[i]["FLD_INDEX"];
					list.Add(item);
				}
				for (int j = 0; j < 4; j++)
				{
					if (!list.Contains(j))
					{
						num = j;
						break;
					}
				}
			}
			dBToDataTable.Dispose();
			int num2 = 0;
			int num3 = 0;
			switch (zy)
			{
			case 4:
				num2 = 124;
				num3 = 116;
				break;
			case 6:
				num2 = 130;
				num3 = 114;
				break;
			case 7:
				num2 = 124;
				num3 = 136;
				break;
			case 1:
			case 8:
				num2 = 145;
				num3 = 116;
				break;
			case 10:
				num2 = 145;
				num3 = 116;
				break;
			case 11:
				num2 = 124;
				num3 = 116;
				break;
			case 2:
			case 3:
			case 5:
			case 9:
			case 12:
				num2 = 133;
				num3 = 118;
				break;
			case 13:
				num2 = 118;
				num3 = 136;
				break;
			}
			return (DBA.ExeSqlCommand("EXEC XWWL_INT_USER_DATA @FLD_ID, @name, @rwid, @zy, @hp, @mp, @coue, @xrwhex, @xrwhex2", new SqlParameter[9]
			{
				SqlDBA.MakeInParam("@FLD_ID", SqlDbType.VarChar, 30, id),
				SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, name),
				SqlDBA.MakeInParam("@rwid", SqlDbType.Int, 0, num),
				SqlDBA.MakeInParam("@zy", SqlDbType.Int, 0, zy),
				SqlDBA.MakeInParam("@hp", SqlDbType.Int, 0, num2),
				SqlDBA.MakeInParam("@mp", SqlDbType.Int, 0, num3),
				SqlDBA.MakeInParam("@coue", SqlDbType.VarBinary, 10, coue),
				SqlDBA.MakeInParam("@xrwhex", SqlDbType.VarBinary, array2.Length, array2),
				SqlDBA.MakeInParam("@xrwhex2", SqlDbType.VarBinary, array3.Length, array3)
			}) != -1) ? 1 : (-1);
		}

		public static int SetUserName(string id, string name, int zy, byte[] coue, int ChessUid)
		{
			byte[] array = new byte[World.物品数据];
			byte[] array2 = new byte[15 * World.物品数据];
			byte[] array3 = new byte[36 * World.物品数据];
			byte[] array4 = new byte[5 * World.物品数据];
			byte[] bytes = BitConverter.GetBytes(GetDBItmeId());
			byte[] src = new byte[4];
			byte[] bytes2 = BitConverter.GetBytes(1);
			switch (zy)
			{
			case 1:
				src = BitConverter.GetBytes(World.新手上线礼包);
				break;
			case 2:
				src = BitConverter.GetBytes(World.新手上线礼包);
				break;
			case 3:
				src = BitConverter.GetBytes(World.新手上线礼包);
				break;
			case 4:
				src = BitConverter.GetBytes(World.新手上线礼包);
				break;
			case 5:
				src = BitConverter.GetBytes(World.新手上线礼包);
				break;
			case 6:
				src = BitConverter.GetBytes(World.新手上线礼包);
				break;
			case 7:
				src = BitConverter.GetBytes(World.新手上线礼包);
				break;
			case 8:
				src = BitConverter.GetBytes(World.新手上线礼包);
				break;
			case 9:
				src = BitConverter.GetBytes(World.新手上线礼包);
				break;
			case 10:
				src = BitConverter.GetBytes(World.新手上线礼包);
				break;
			case 11:
				src = BitConverter.GetBytes(World.新手上线礼包);
				break;
			case 12:
				src = BitConverter.GetBytes(World.新手上线礼包);
				break;
			case 13:
				src = BitConverter.GetBytes(World.新手上线礼包);
				break;
			}
			Buffer.BlockCopy(bytes, 0, array, 0, 4);
			Buffer.BlockCopy(src, 0, array, 8, 4);
			Buffer.BlockCopy(bytes2, 0, array, 12, 4);
			Buffer.BlockCopy(array, 0, array3, 0, World.物品数据);
			int num = 0;
			DataTable dataTable = 得到人物数据ID(id);
			bool flag = false;
			if (dataTable == null)
			{
				flag = true;
				num = 0;
			}
			else
			{
				if (dataTable.Rows.Count >= 4)
				{
					dataTable.Dispose();
					return -1;
				}
				List<int> list = new List<int>();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					int item = (int)dataTable.Rows[i]["FLD_INDEX"];
					list.Add(item);
				}
				for (int j = 0; j < 4; j++)
				{
					if (!list.Contains(j))
					{
						num = j;
						break;
					}
				}
				dataTable.Dispose();
			}
			int num2 = 0;
			int num3 = 0;
			switch (zy)
			{
			case 4:
				num2 = 124;
				num3 = 116;
				break;
			case 6:
				num2 = 130;
				num3 = 114;
				break;
			case 7:
				num2 = 124;
				num3 = 136;
				break;
			case 1:
			case 8:
				num2 = 145;
				num3 = 116;
				break;
			case 10:
				num2 = 145;
				num3 = 116;
				break;
			case 11:
				num2 = 124;
				num3 = 116;
				break;
			case 2:
			case 3:
			case 5:
			case 9:
			case 12:
				num2 = 133;
				num3 = 118;
				break;
			case 13:
				num2 = 118;
				num3 = 136;
				break;
			}
			if (DBA.ExeSqlCommand("EXEC XWWL_INT_USER_DATA @FLD_ID, @name, @rwid, @zy, @hp, @mp, @coue, @xrwhex, @xrwhex2", new SqlParameter[9]
			{
				SqlDBA.MakeInParam("@FLD_ID", SqlDbType.VarChar, 30, id),
				SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, name),
				SqlDBA.MakeInParam("@rwid", SqlDbType.Int, 0, num),
				SqlDBA.MakeInParam("@zy", SqlDbType.Int, 0, zy),
				SqlDBA.MakeInParam("@hp", SqlDbType.Int, 0, num2),
				SqlDBA.MakeInParam("@mp", SqlDbType.Int, 0, num3),
				SqlDBA.MakeInParam("@coue", SqlDbType.VarBinary, 10, coue),
				SqlDBA.MakeInParam("@xrwhex", SqlDbType.VarBinary, array2.Length, array2),
				SqlDBA.MakeInParam("@xrwhex2", SqlDbType.VarBinary, array3.Length, array3)
			}) == -1)
			{
				return -1;
			}
			CreateUserBank(id, name);
			if (flag)
			{
				CreateIDBank(id);
			}
			return 1;
		}

		public static void CreateIDBank(string Userid)
		{
			SqlDBA.RunProc(new SqlConnection(DBA.getstrConnection(null)), "XWWL_CREATE_ID_BANK", new SqlParameter[4]
			{
				SqlDBA.MakeInParam("@Userid", SqlDbType.VarChar, 50, Userid),
				SqlDBA.MakeInParam("@money", SqlDbType.VarChar, 50, 0),
				SqlDBA.MakeInParam("@strItem", SqlDbType.VarBinary, 4380, new byte[4380]),
				SqlDBA.MakeInParam("@strItime", SqlDbType.VarBinary, 50, new byte[50])
			});
		}

		public static void CreateUserBank(string Userid, string Username)
		{
			SqlDBA.RunProc(new SqlConnection(DBA.getstrConnection(null)), "XWWL_CREATE_USER_BANK", new SqlParameter[4]
			{
				SqlDBA.MakeInParam("@id", SqlDbType.VarChar, 50, Userid),
				SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 50, Username),
				SqlDBA.MakeInParam("@money", SqlDbType.VarChar, 50, 0),
				SqlDBA.MakeInParam("@strItem", SqlDbType.VarBinary, 4380, new byte[4380])
			});
		}

		public static int GetCwUserName(string name, string zrname, int type, long id)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable(string.Format("SELECT Name FROM TBL_XWWL_Cw WHERE Name=@name", name), new SqlParameter[1] { SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, name) });
			if (dBToDataTable == null)
			{
				return -1;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				dBToDataTable.Dispose();
				return (DBA.ExeSqlCommand(string.Format("EXEC XWWL_INT_Cw_DATA @zrname, @name, @id, @type, @zb1, @zb2", zrname, name, id, type, Converter.ToString(new byte[292]), Converter.ToString(new byte[1168])), new SqlParameter[6]
				{
					SqlDBA.MakeInParam("@zrname", SqlDbType.VarChar, 30, zrname),
					SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, name),
					SqlDBA.MakeInParam("@id", SqlDbType.Int, 0, id),
					SqlDBA.MakeInParam("@type", SqlDbType.Int, 0, type),
					SqlDBA.MakeInParam("@zb1", SqlDbType.VarBinary, 5 * World.数据库单个物品大小, new byte[5 * World.数据库单个物品大小]),
					SqlDBA.MakeInParam("@zb2", SqlDbType.VarBinary, 16 * World.数据库单个物品大小, new byte[16 * World.数据库单个物品大小])
				}) != -1) ? 1 : (-1);
			}
			dBToDataTable.Dispose();
			return -1;
		}

		public static void 更新门派荣誉(string 人物名, string 帮派名, int 势力, int 等级, int 职业, int 转职, int 荣誉, string 分区)
		{
			try
			{
				SqlParameter[] prams = new SqlParameter[8]
				{
					SqlDBA.MakeInParam("@rwname", SqlDbType.VarChar, 50, 人物名),
					SqlDBA.MakeInParam("@bpname", SqlDbType.VarChar, 50, 帮派名),
					SqlDBA.MakeInParam("@zx", SqlDbType.Int, 0, 势力),
					SqlDBA.MakeInParam("@leve", SqlDbType.Int, 0, 等级),
					SqlDBA.MakeInParam("@job", SqlDbType.Int, 0, 职业),
					SqlDBA.MakeInParam("@jobleve", SqlDbType.Int, 0, 转职),
					SqlDBA.MakeInParam("@rongyu", SqlDbType.Int, 0, 荣誉),
					SqlDBA.MakeInParam("@fq", SqlDbType.VarChar, 50, 分区)
				};
				DbPoolClass obj = new DbPoolClass
				{
					Conn = DBA.getstrConnection(null),
					Prams = prams,
					Sql = "UPDATE_menpai_DATA_New"
				};
				World.SqlPool.Enqueue(obj);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存门派排行数据出错" + ex.Message);
			}
		}

		public static void 更新武林荣誉(string string_0, string string_1, int int_0, int int_1, int int_2, int int_3, int int_4, string string_2)
		{
			try
			{
				SqlParameter[] prams = new SqlParameter[8]
				{
					SqlDBA.MakeInParam("@rwname", SqlDbType.VarChar, 50, string_0),
					SqlDBA.MakeInParam("@bpname", SqlDbType.VarChar, 50, string_1),
					SqlDBA.MakeInParam("@zx", SqlDbType.Int, 0, int_0),
					SqlDBA.MakeInParam("@leve", SqlDbType.Int, 0, int_1),
					SqlDBA.MakeInParam("@job", SqlDbType.Int, 0, int_2),
					SqlDBA.MakeInParam("@jobleve", SqlDbType.Int, 0, int_3),
					SqlDBA.MakeInParam("@rongyu", SqlDbType.Int, 0, int_4),
					SqlDBA.MakeInParam("@fq", SqlDbType.VarChar, 50, string_2)
				};
				DbPoolClass obj = new DbPoolClass
				{
					Conn = DBA.getstrConnection(null),
					Prams = prams,
					Sql = "UPDATE_wulin_DATA_New"
				};
				World.SqlPool.Enqueue(obj);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存武林排行数据出错" + ex.Message);
			}
		}

		public static void 更新势力荣誉(string string_0, string string_1, int int_0, int int_1, int int_2, int int_3, int int_4, string string_2)
		{
			try
			{
				SqlParameter[] prams = new SqlParameter[8]
				{
					SqlDBA.MakeInParam("@rwname", SqlDbType.VarChar, 50, string_0),
					SqlDBA.MakeInParam("@bpname", SqlDbType.VarChar, 50, string_1),
					SqlDBA.MakeInParam("@zx", SqlDbType.Int, 0, int_0),
					SqlDBA.MakeInParam("@leve", SqlDbType.Int, 0, int_1),
					SqlDBA.MakeInParam("@job", SqlDbType.Int, 0, int_2),
					SqlDBA.MakeInParam("@jobleve", SqlDbType.Int, 0, int_3),
					SqlDBA.MakeInParam("@rongyu", SqlDbType.Int, 0, int_4),
					SqlDBA.MakeInParam("@fq", SqlDbType.VarChar, 50, string_2)
				};
				DbPoolClass obj = new DbPoolClass
				{
					Conn = DBA.getstrConnection(null),
					Prams = prams,
					Sql = "UPDATE_shili_DATA_New"
				};
				World.SqlPool.Enqueue(obj);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存势力排行数据出错" + ex.Message);
			}
		}

		public static void 更新讨伐荣誉(string string_0, string string_1, int int_0, int int_1, int int_2, int int_3, int int_4, string string_2)
		{
			try
			{
				SqlParameter[] prams = new SqlParameter[8]
				{
					SqlDBA.MakeInParam("@rwname", SqlDbType.VarChar, 50, string_0),
					SqlDBA.MakeInParam("@bpname", SqlDbType.VarChar, 50, string_1),
					SqlDBA.MakeInParam("@zx", SqlDbType.Int, 0, int_0),
					SqlDBA.MakeInParam("@leve", SqlDbType.Int, 0, int_1),
					SqlDBA.MakeInParam("@job", SqlDbType.Int, 0, int_2),
					SqlDBA.MakeInParam("@jobleve", SqlDbType.Int, 0, int_3),
					SqlDBA.MakeInParam("@rongyu", SqlDbType.Int, 0, int_4),
					SqlDBA.MakeInParam("@fq", SqlDbType.VarChar, 50, string_2)
				};
				DbPoolClass obj = new DbPoolClass
				{
					Conn = DBA.getstrConnection(null),
					Prams = prams,
					Sql = "UPDATE_taofa_DATA_New"
				};
				World.SqlPool.Enqueue(obj);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存武林排行数据出错" + ex.Message);
			}
		}

		public static int Set个人荣誉数据(int 类型, string 人物名, int 职业, int 等级, int 势力, string 帮派名, string 帮派门主, int 分数, string 分区ID)
		{
			DataTable dataTable = 得到帮派数据(帮派名);
			if (dataTable != null)
			{
				if (dataTable.Rows.Count > 0)
				{
					帮派门主 = dataTable.Rows[0]["G_Master"].ToString();
				}
				dataTable.Dispose();
			}
			DataTable dBToDataTable = DBA.GetDBToDataTable(string.Format("SELECT FLD_人物名 FROM TBL_荣誉系统 WHERE FLD_人物名=@name and FLD_类型=@lx", 人物名, 类型), new SqlParameter[2]
			{
				SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, 人物名),
				SqlDBA.MakeInParam("@lx", SqlDbType.Int, 0, 类型)
			});
			if (dBToDataTable == null)
			{
				return -1;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				dBToDataTable.Dispose();
				return (DBA.ExeSqlCommand(string.Format("EXEC XWWL_INT_RY_DATA @lx, @name, @job, @level, @zx, @bpname, @mzname, @jf, @fq", 类型, 人物名, 职业, 等级, 势力, 帮派名, 帮派门主, 分数, 分区ID), new SqlParameter[9]
				{
					SqlDBA.MakeInParam("@lx", SqlDbType.Int, 0, 类型),
					SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, 人物名),
					SqlDBA.MakeInParam("@job", SqlDbType.Int, 0, 职业),
					SqlDBA.MakeInParam("@level", SqlDbType.Int, 0, 等级),
					SqlDBA.MakeInParam("@zx", SqlDbType.Int, 0, 势力),
					SqlDBA.MakeInParam("@bpname", SqlDbType.VarChar, 30, 帮派名),
					SqlDBA.MakeInParam("@mzname", SqlDbType.VarChar, 30, 帮派门主),
					SqlDBA.MakeInParam("@jf", SqlDbType.Int, 0, 分数),
					SqlDBA.MakeInParam("@fq", SqlDbType.VarChar, 30, 分区ID)
				}) != -1) ? 1 : (-1);
			}
			dBToDataTable.Dispose();
			return (DBA.ExeSqlCommand($"UPDATE TBL_荣誉系统 SET FLD_分数 =FLD_分数+{分数} WHERE FLD_人物名='{人物名}' and FLD_类型={类型}", "GameServer") != -1) ? 1 : (-1);
		}

		public static int Set个人元宝荣誉数据(int int_0, string string_0, int int_1, int int_2, int int_3, string string_1, string string_2, int int_4)
		{
			if (string_1 == null || string_1 == "")
			{
				string_1 = "";
			}
			DataTable dBToDataTable = DBA.GetDBToDataTable(string.Format("SELECT  FLD_人物名  FROM  TBL_荣誉系统  WHERE  FLD_人物名=@name  and  FLD_类型=@lx", string_0, int_0), new SqlParameter[2]
			{
				SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, string_0),
				SqlDBA.MakeInParam("@lx", SqlDbType.Int, 0, int_0)
			});
			if (dBToDataTable == null)
			{
				return -1;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				dBToDataTable.Dispose();
				if (DBA.ExeSqlCommand(string.Format("EXEC  XWWL_INT_RY_DATA  @lx,@name,@job,@level,@zx,@bpname,@mzname,@jf", int_0, string_0, int_1, int_2, int_3, string_1, string_2, int_4), new SqlParameter[8]
				{
					SqlDBA.MakeInParam("@lx", SqlDbType.Int, 0, int_0),
					SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, string_0),
					SqlDBA.MakeInParam("@job", SqlDbType.Int, 0, int_1),
					SqlDBA.MakeInParam("@level", SqlDbType.Int, 0, int_2),
					SqlDBA.MakeInParam("@zx", SqlDbType.Int, 0, int_3),
					SqlDBA.MakeInParam("@bpname", SqlDbType.VarChar, 30, string_1),
					SqlDBA.MakeInParam("@mzname", SqlDbType.VarChar, 30, string_2),
					SqlDBA.MakeInParam("@jf", SqlDbType.Int, 0, int_4)
				}) != -1)
				{
					return 1;
				}
				return -1;
			}
			dBToDataTable.Dispose();
			if (DBA.ExeSqlCommand(string.Format("UPDATE  TBL_荣誉系统  SET  FLD_分数  =FLD_分数+{0},FLD_帮派='{3}'  WHERE  FLD_人物名='{1}'  and    FLD_类型={2}", int_4, string_0, int_0, string_1), "GameServer") != -1)
			{
				return 1;
			}
			return -1;
		}

		public static int Set帮派荣誉数据(string 帮派, string 帮派门主, int 等级, int 职业, int 势力, int 分数, string 分区ID)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable(string.Format("SELECT * FROM TBL_荣誉系统 WHERE FLD_类型 = 3 and FLD_帮派=@mpname", 帮派), new SqlParameter[1] { SqlDBA.MakeInParam("@mpname", SqlDbType.VarChar, 30, 帮派) });
			if (dBToDataTable == null)
			{
				return -1;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				dBToDataTable.Dispose();
				int num = 3;
				string empty = string.Empty;
				return (DBA.ExeSqlCommand(string.Format("EXEC XWWL_INT_RY_DATA @lx, @name, @job, @level, @zx, @bpname, @mzname, @jf, @fq", num, empty, 职业, 等级, 势力, 帮派, 帮派门主, 分数, 分区ID), new SqlParameter[9]
				{
					SqlDBA.MakeInParam("@lx", SqlDbType.Int, 0, num),
					SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, empty),
					SqlDBA.MakeInParam("@job", SqlDbType.Int, 0, 职业),
					SqlDBA.MakeInParam("@level", SqlDbType.Int, 0, 等级),
					SqlDBA.MakeInParam("@zx", SqlDbType.Int, 0, 势力),
					SqlDBA.MakeInParam("@bpname", SqlDbType.VarChar, 30, 帮派),
					SqlDBA.MakeInParam("@mzname", SqlDbType.VarChar, 30, 帮派门主),
					SqlDBA.MakeInParam("@jf", SqlDbType.Int, 0, 分数),
					SqlDBA.MakeInParam("@fq", SqlDbType.VarChar, 30, 分区ID)
				}) != -1) ? 1 : (-1);
			}
			dBToDataTable.Dispose();
			return (DBA.ExeSqlCommand("UPDATE TBL_荣誉系统 SET FLD_分数 =FLD_分数+1 WHERE FLD_帮派='" + 帮派 + "' and FLD_类型= 3", "GameServer") != -1) ? 1 : (-1);
		}

		public static DataTable 得到传书列表(string name)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_传书系统 WHERE 接收人物名 =@name", new SqlParameter[1] { SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, name) });
			if (dBToDataTable == null)
			{
				return null;
			}
			if (dBToDataTable.Rows.Count != 0)
			{
				return dBToDataTable;
			}
			dBToDataTable.Dispose();
			return null;
		}

		public static void 设置传书已读(int id, int 是否已读)
		{
			DBA.ExeSqlCommand("UPDATE TBL_传书系统 SET 阅读标识=@rd WHERE ID=@id", new SqlParameter[2]
			{
				SqlDBA.MakeInParam("@rd", SqlDbType.Int, 0, 是否已读),
				SqlDBA.MakeInParam("@id", SqlDbType.Int, 30, id)
			});
		}

		public static void 上线删除传书已读(string sname, int 是否已读)
		{
			DBA.ExeSqlCommand("DELETE TBL_传书系统 WHERE 接收人物名=@sname and 阅读标识=@rd", new SqlParameter[2]
			{
				SqlDBA.MakeInParam("@rd", SqlDbType.Int, 0, 是否已读),
				SqlDBA.MakeInParam("@sname", SqlDbType.VarChar, 30, sname)
			});
		}

		public static void 变更婚姻状态(string name, int 状态)
		{
			DBA.ExeSqlCommand(string.Format("UPDATE TBL_XWWL_Char SET FLD_MARITAL_STATUS={1} WHERE FLD_NAME='{0}'", name, 状态));
		}

		public static void 解除情侣关系(string name)
		{
			DBA.ExeSqlCommand(string.Format("UPDATE TBL_XWWL_Char SET FLD_QlNAME='{1}', FLD_QlDu={2}, FLD_LOVE_WORD='{3}', FLD_MARITAL_STATUS={4}, FLD_MARRIED={5} WHERE FLD_NAME='{0}'", name, string.Empty, 0, string.Empty, 0, 0));
		}

		public static void 创建传书(string fname, string sname, int npcid, string msg, int Type)
		{
			DBA.GetDBValue_3("EXEC INT_CS_DATA_New @fname, @sname, @msg, @npcid, @type", new SqlParameter[5]
			{
				SqlDBA.MakeInParam("@fname", SqlDbType.VarChar, 30, fname),
				SqlDBA.MakeInParam("@sname", SqlDbType.VarChar, 30, sname),
				SqlDBA.MakeInParam("@msg", SqlDbType.VarChar, 2000, msg),
				SqlDBA.MakeInParam("@npcid", SqlDbType.Int, 0, npcid),
				SqlDBA.MakeInParam("@type", SqlDbType.Int, 0, Type)
			});
		}

		public static DataTable 得到人物名字(string 名字)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_Char WHERE FLD_NAME = @name", new SqlParameter[1] { SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, 名字) });
			if (dBToDataTable == null)
			{
				return null;
			}
			return (dBToDataTable.Rows.Count == 0) ? null : dBToDataTable;
		}

		public static void 创建门派荣誉(string 人物名, string 帮派名, int 势力, int 等级, int 职业, int 转职, int 荣誉, string 分区)
		{
			DBA.ExeSqlCommand("EXEC INT_menpai_DATA_New @rwname, @bpname, @zx, @leve, @job, @jobleve, @rongyu, @fq", new SqlParameter[8]
			{
				SqlDBA.MakeInParam("@rwname", SqlDbType.VarChar, 50, 人物名),
				SqlDBA.MakeInParam("@bpname", SqlDbType.VarChar, 50, 帮派名),
				SqlDBA.MakeInParam("@zx", SqlDbType.Int, 0, 势力),
				SqlDBA.MakeInParam("@leve", SqlDbType.Int, 0, 等级),
				SqlDBA.MakeInParam("@job", SqlDbType.Int, 0, 职业),
				SqlDBA.MakeInParam("@jobleve", SqlDbType.Int, 0, 转职),
				SqlDBA.MakeInParam("@rongyu", SqlDbType.Int, 0, 荣誉),
				SqlDBA.MakeInParam("@fq", SqlDbType.VarChar, 50, 分区)
			});
		}

		public static void 创建武林荣誉(string string_0, string string_1, int int_0, int int_1, int int_2, int int_3, int int_4, string string_2)
		{
			string sqlCommand = "EXEC INT_wulin_DATA_New @rwname, @bpname, @zx, @leve, @job, @jobleve, @rongyu, @fq";
			SqlParameter[] prams = new SqlParameter[8]
			{
				SqlDBA.MakeInParam("@rwname", SqlDbType.VarChar, 50, string_0),
				SqlDBA.MakeInParam("@bpname", SqlDbType.VarChar, 50, string_1),
				SqlDBA.MakeInParam("@zx", SqlDbType.Int, 0, int_0),
				SqlDBA.MakeInParam("@leve", SqlDbType.Int, 0, int_1),
				SqlDBA.MakeInParam("@job", SqlDbType.Int, 0, int_2),
				SqlDBA.MakeInParam("@jobleve", SqlDbType.Int, 0, int_3),
				SqlDBA.MakeInParam("@rongyu", SqlDbType.Int, 0, int_4),
				SqlDBA.MakeInParam("@fq", SqlDbType.VarChar, 50, string_2)
			};
			DBA.ExeSqlCommand(sqlCommand, prams);
		}

		public static void 创建讨伐荣誉(string string_0, string string_1, int int_0, int int_1, int int_2, int int_3, int int_4, string string_2)
		{
			string sqlCommand = "EXEC INT_taofa_DATA_New @rwname, @bpname, @zx, @leve, @job, @jobleve, @rongyu, @fq";
			SqlParameter[] prams = new SqlParameter[8]
			{
				SqlDBA.MakeInParam("@rwname", SqlDbType.VarChar, 50, string_0),
				SqlDBA.MakeInParam("@bpname", SqlDbType.VarChar, 50, string_1),
				SqlDBA.MakeInParam("@zx", SqlDbType.Int, 0, int_0),
				SqlDBA.MakeInParam("@leve", SqlDbType.Int, 0, int_1),
				SqlDBA.MakeInParam("@job", SqlDbType.Int, 0, int_2),
				SqlDBA.MakeInParam("@jobleve", SqlDbType.Int, 0, int_3),
				SqlDBA.MakeInParam("@rongyu", SqlDbType.Int, 0, int_4),
				SqlDBA.MakeInParam("@fq", SqlDbType.VarChar, 50, string_2)
			};
			DBA.ExeSqlCommand(sqlCommand, prams);
		}

		public static void 创建势力荣誉(string string_0, string string_1, int int_0, int int_1, int int_2, int int_3, int int_4, string string_2)
		{
			string sqlCommand = "EXEC INT_shili_DATA_New @rwname, @bpname, @zx, @leve, @job, @jobleve, @rongyu, @fq";
			SqlParameter[] prams = new SqlParameter[8]
			{
				SqlDBA.MakeInParam("@rwname", SqlDbType.VarChar, 50, string_0),
				SqlDBA.MakeInParam("@bpname", SqlDbType.VarChar, 50, string_1),
				SqlDBA.MakeInParam("@zx", SqlDbType.Int, 0, int_0),
				SqlDBA.MakeInParam("@leve", SqlDbType.Int, 0, int_1),
				SqlDBA.MakeInParam("@job", SqlDbType.Int, 0, int_2),
				SqlDBA.MakeInParam("@jobleve", SqlDbType.Int, 0, int_3),
				SqlDBA.MakeInParam("@rongyu", SqlDbType.Int, 0, int_4),
				SqlDBA.MakeInParam("@fq", SqlDbType.VarChar, 50, string_2)
			};
			DBA.ExeSqlCommand(sqlCommand, prams);
		}

		public static DataTable 得到门派荣誉数据(string 名字, string 分区)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM 荣誉门派排行 WHERE FLD_BP = @name and FLD_FQ=@fq", new SqlParameter[2]
			{
				SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, 名字),
				SqlDBA.MakeInParam("@fq", SqlDbType.VarChar, 30, 分区)
			});
			if (dBToDataTable == null)
			{
				return null;
			}
			return (dBToDataTable.Rows.Count == 0) ? null : dBToDataTable;
		}

		public static DataTable 得到武林荣誉数据(string 名字, string 分区)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM 荣誉武林排行 WHERE FLD_NAME = @name and FLD_FQ=@fq", new SqlParameter[2]
			{
				SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, 名字),
				SqlDBA.MakeInParam("@fq", SqlDbType.VarChar, 30, 分区)
			});
			if (dBToDataTable == null)
			{
				return null;
			}
			return (dBToDataTable.Rows.Count == 0) ? null : dBToDataTable;
		}

		public static DataTable 得到讨伐荣誉数据(string 名字, string 分区)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM 荣誉讨伐排行 WHERE FLD_NAME = @name and FLD_FQ=@fq", new SqlParameter[2]
			{
				SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, 名字),
				SqlDBA.MakeInParam("@fq", SqlDbType.VarChar, 30, 分区)
			});
			if (dBToDataTable == null)
			{
				return null;
			}
			return (dBToDataTable.Rows.Count == 0) ? null : dBToDataTable;
		}

		public static DataTable 得到势力荣誉数据(string 名字, string 分区)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM 荣誉势力排行 WHERE FLD_NAME = @name and FLD_FQ=@fq", new SqlParameter[2]
			{
				SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, 名字),
				SqlDBA.MakeInParam("@fq", SqlDbType.VarChar, 30, 分区)
			});
			if (dBToDataTable == null)
			{
				return null;
			}
			return (dBToDataTable.Rows.Count == 0) ? null : dBToDataTable;
		}

		public static DataTable 得到师傅数据(string name)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_师徒数据 WHERE FLD_TNAME =@name", new SqlParameter[1] { SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, name) });
			if (dBToDataTable == null)
			{
				return null;
			}
			return (dBToDataTable.Rows.Count == 0) ? null : dBToDataTable;
		}

		public static DataTable 得到徒弟数据(string name)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_师徒数据 WHERE FLD_SNAME =@name", new SqlParameter[1] { SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, name) });
			if (dBToDataTable == null)
			{
				return null;
			}
			return (dBToDataTable.Rows.Count == 0) ? null : dBToDataTable;
		}

		public static int 创建师徒关系(string 徒弟, string 师傅, int tlevel, int index)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable(string.Format("SELECT FLD_TNAME FROM TBL_师徒数据 WHERE FLD_TNAME=@name", 徒弟), new SqlParameter[1] { SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, 徒弟) });
			if (dBToDataTable == null)
			{
				return -1;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				dBToDataTable.Dispose();
				return (DBA.ExeSqlCommand(string.Format("EXEC INT_St_DATA @sname, @tname, @tlevel, @index", 师傅, 徒弟, tlevel, index), new SqlParameter[4]
				{
					SqlDBA.MakeInParam("@sname", SqlDbType.VarChar, 30, 师傅),
					SqlDBA.MakeInParam("@tname", SqlDbType.VarChar, 30, 徒弟),
					SqlDBA.MakeInParam("@tlevel", SqlDbType.Int, 0, tlevel),
					SqlDBA.MakeInParam("@index", SqlDbType.Int, 0, index)
				}) != -1) ? 1 : (-1);
			}
			dBToDataTable.Dispose();
			return -1;
		}

		public static int 解除师徒关系(string 徒弟, string 师傅)
		{
			return (DBA.ExeSqlCommand("delete [TBL_师徒数据] WHERE FLD_TNAME ='" + 徒弟 + "' and FLD_SNAME='" + 师傅 + "'", "GameServer") != -1) ? 1 : (-1);
		}

		public static int 取得贡献经验(string 师傅名, string 徒弟名)
		{
			int num = 0;
			try
			{
				DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT FLD_师傅 from [TBL_XWWL_Char] where FLD_NAME ='" + 徒弟名 + "'");
				if (dBToDataTable != null)
				{
					if (dBToDataTable.Rows.Count > 0)
					{
						byte[] array = new byte[28];
						byte[] array2 = (byte[])dBToDataTable.Rows[0]["FLD_师傅"];
						Buffer.BlockCopy(array2, 0, array, 0, array2.Length);
						byte[] array3 = new byte[16];
						Buffer.BlockCopy(array, 0, array3, 0, 16);
						if (Encoding.Default.GetString(array3).Replace("\0", string.Empty).Trim() == 师傅名)
						{
							int num2 = BitConverter.ToInt32(array, 18);
							if (num2 <= 0)
							{
								dBToDataTable.Dispose();
								return 0;
							}
							num += num2;
							array[18] = 0;
							array[19] = 0;
							array[20] = 0;
							array[21] = 0;
							DBA.ExeSqlCommand("UPDATE [TBL_XWWL_Char] set FLD_师傅=@sf where FLD_NAME =@name", new SqlParameter[2]
							{
								SqlDBA.MakeInParam("@sf", SqlDbType.VarBinary, 28, array),
								SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 徒弟名.Length, 徒弟名)
							});
						}
					}
					dBToDataTable.Dispose();
				}
			}
			catch
			{
				return 0;
			}
			return num;
		}

		public static string 取得门派联盟盟主(string 门派名)
		{
			string sqlCommand = "select * from TBL_XWWL_Guild where G_Name=@name";
			SqlParameter[] prams = new SqlParameter[1] { SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, 门派名) };
			DataTable dBToDataTable = DBA.GetDBToDataTable(sqlCommand, prams);
			if (dBToDataTable == null)
			{
				return "";
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				dBToDataTable.Dispose();
				return "";
			}
			string result = dBToDataTable.Rows[0]["联盟盟主"].ToString();
			dBToDataTable.Dispose();
			return result;
		}

		public static DataTable 取得门派联盟列表(string 门派名)
		{
			if (门派名 == "")
			{
				return null;
			}
			string sqlCommand = "SELECT * FROM TBL_XWWL_Guild WHERE 联盟盟主 = @name";
			SqlParameter[] prams = new SqlParameter[1] { SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, 门派名) };
			DataTable dBToDataTable = DBA.GetDBToDataTable(sqlCommand, prams);
			if (dBToDataTable == null)
			{
				return null;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				return null;
			}
			return dBToDataTable;
		}

		public static int 更新联盟宣告攻城状态(string 盟主门派名, int 宣告攻城状态)
		{
			string sqlCommand = $"UPDATE TBL_XWWL_Guild SET 宣告攻城={宣告攻城状态} WHERE 联盟盟主='{盟主门派名}'";
			return DBA.ExeSqlCommand(sqlCommand);
		}

		public static int 更新门派联盟盟主(string 申请门派名, string 盟主门派名, int 宣告攻城状态)
		{
			string sqlCommand = $"UPDATE TBL_XWWL_Guild SET 联盟盟主='{盟主门派名}', 宣告攻城={宣告攻城状态} WHERE G_Name='{申请门派名}'";
			return DBA.ExeSqlCommand(sqlCommand);
		}

		public static DataTable 得到天魔神宫占领信息()
		{
			string sqlCommand = "SELECT * FROM 天魔神宫";
			DataTable dBToDataTable = DBA.GetDBToDataTable(sqlCommand);
			if (dBToDataTable == null)
			{
				return null;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				return null;
			}
			return dBToDataTable;
		}

		public static int 更新天魔神宫信息(string 占领门派, string 占领日期, int 城门强化等级)
		{
			return DBA.ExeSqlCommand($"UPDATE 天魔神宫 SET 占领者='{占领门派}', 占领日期={占领日期}, 城门强化等级={城门强化等级}, 更新时间='{DateTime.Now}'");
		}

		public static DataTable 得到已申请攻城的门派列表()
		{
			string sqlCommand = "select * from TBL_XWWL_Guild where 联盟盟主 !='' and 联盟盟主=G_Name";
			DataTable dBToDataTable = DBA.GetDBToDataTable(sqlCommand);
			if (dBToDataTable == null)
			{
				return null;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				dBToDataTable.Dispose();
				return null;
			}
			return dBToDataTable;
		}

		public static int 寄售钻石(string UserId, int 钻石数)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("UPDATE [TBL_ACCOUNT] SET FLD_RXPIONTX = FLD_RXPIONTX + {1} WHERE FLD_ID = '{0}'", UserId, 钻石数);
			return DBA.ExeSqlCommand(stringBuilder.ToString(), "rxjhaccount");
		}

		public static int 寄售物品(寄存物品类 物品)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("INSERT INTO PLAYITEM (FLD_PID, FLD_NAME, FLD_PRICE, FLD_DESC, FLD_TYPE, FLD_MAGIC0, FLD_MAGIC1, FLD_MAGIC2, FLD_MAGIC3, FLD_MAGIC4, 初级附魂, 中级附魂, 进化, FLD_绑定, FLD_PlayID, FLD_PlayName, ID, FLD_FQ) VALUES ({0}, '{1}', {2}, '{3}', {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, '{14}','{15}', {16}, '{17}')", 物品.PID, 物品.NAME, 物品.PRICE, 物品.DESC, 物品.TYPE, 物品.MAGIC0, 物品.MAGIC1, 物品.MAGIC2, 物品.MAGIC3, 物品.MAGIC4, 物品.初级附魂, 物品.中级附魂, 物品.进化, 物品.绑定, 物品.PlayID, 物品.PlayName, 物品.ID, 物品.分区);
			return DBA.ExeSqlCommand(stringBuilder.ToString(), "BBG");
		}

		public static int 取消寄售(long id)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("DELETE PLAYITEM WHERE ID = {0}", id);
			return DBA.ExeSqlCommand(stringBuilder.ToString(), "BBG");
		}

		public static int 变更寄售类型(int id, int lx)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("UPDATE PLAYITEM SET FLD_TYPE = {1} WHERE ID = {0}", id, lx);
			return DBA.ExeSqlCommand(stringBuilder.ToString(), "BBG");
		}

		public static int 变更寄售时间(int id)
		{
			return DBA.ExeSqlCommand("UPDATE PLAYITEM SET FLD_TIME = @time WHERE ID = @id", new SqlParameter[2]
			{
				SqlDBA.MakeInParam("@id", SqlDbType.BigInt, 30, id),
				SqlDBA.MakeInParam("@time", SqlDbType.DateTime, 30, DateTime.Now)
			}, "BBG");
		}

		public static int 得到寄售数量(string id)
		{
			return DBA.GetDBToDataTable("Select * from [PLAYITEM] where FLD_TYPE = 1 AND FLD_PLAYID = '" + id + "' ", "BBG")?.Rows.Count ?? 0;
		}

		public static 寄存物品类 得到寄售物品(int 全局ID)
		{
			try
			{
				DataTable dBToDataTable = DBA.GetDBToDataTable($"Select * from [PLAYITEM] where FLD_TYPE = 1 AND ID = {全局ID}", "BBG");
				if (dBToDataTable != null)
				{
					if (dBToDataTable.Rows.Count == 0)
					{
						dBToDataTable.Dispose();
					}
					else
					{
						if (dBToDataTable.Rows.Count <= 1)
						{
							寄存物品类 result = new 寄存物品类
							{
								ID = (long)dBToDataTable.Rows[0]["ID"],
								PID = (int)dBToDataTable.Rows[0]["FLD_PID"],
								NAME = dBToDataTable.Rows[0]["FLD_NAME"].ToString(),
								PRICE = (int)dBToDataTable.Rows[0]["FLD_PRICE"],
								DESC = dBToDataTable.Rows[0]["FLD_DESC"].ToString(),
								TYPE = (int)dBToDataTable.Rows[0]["FLD_TYPE"],
								MAGIC0 = (int)dBToDataTable.Rows[0]["FLD_MAGIC0"],
								MAGIC1 = (int)dBToDataTable.Rows[0]["FLD_MAGIC1"],
								MAGIC2 = (int)dBToDataTable.Rows[0]["FLD_MAGIC2"],
								MAGIC3 = (int)dBToDataTable.Rows[0]["FLD_MAGIC3"],
								MAGIC4 = (int)dBToDataTable.Rows[0]["FLD_MAGIC4"],
								初级附魂 = (int)dBToDataTable.Rows[0]["初级附魂"],
								中级附魂 = (int)dBToDataTable.Rows[0]["中级附魂"],
								进化 = (int)dBToDataTable.Rows[0]["进化"],
								绑定 = (int)dBToDataTable.Rows[0]["FLD_绑定"],
								PlayID = dBToDataTable.Rows[0]["FLD_PlayID"].ToString(),
								PlayName = dBToDataTable.Rows[0]["FLD_PlayName"].ToString(),
								时间 = DateTime.Parse(dBToDataTable.Rows[0]["FLD_TIME"].ToString()),
								分区 = dBToDataTable.Rows[0]["FLD_FQ"].ToString()
							};
							dBToDataTable.Dispose();
							return result;
						}
						logo.寄售记录("得到寄售物品()出错 存在重复全局ID - " + (int)dBToDataTable.Rows[0]["ID"]);
						dBToDataTable.Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				string message = ex.Message;
			}
			return null;
		}

		public static string 得到账号下第一个人物名字(string userID)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT  *  FROM  TBL_XWWL_Char  WHERE  FLD_ID  =  @name", new SqlParameter[1] { SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 500, userID) });
			if (dBToDataTable == null)
			{
				return "";
			}
			if (dBToDataTable.Rows.Count != 0)
			{
				return dBToDataTable.Rows[0]["FLD_NAME"].ToString();
			}
			return "";
		}

		public static int 假人GetUserName(string string_0)
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT  FLD_NAME  FROM  TBL_XWWL_Char  WHERE  FLD_NAME=@name", new SqlParameter[1] { SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 30, string_0) });
			if (dBToDataTable == null)
			{
				return -1;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				dBToDataTable.Dispose();
				return 1;
			}
			dBToDataTable.Dispose();
			return -1;
		}

		public static string 获取注册地址(string UserId)
		{
			string result = "127.0.0.1";
			string sqlCommand = "select FLD_REGIP from [TBL_ACCOUNT] where FLD_ID='" + UserId + "'";
			DataTable dBToDataTable = DBA.GetDBToDataTable(sqlCommand, "rxjhaccount");
			if (dBToDataTable != null && dBToDataTable.Rows.Count > 0)
			{
				result = dBToDataTable.Rows[0]["FLD_REGIP"].ToString();
			}
			return result;
		}

		public static DataTable 得到帐号数据(string UserId)
		{
			DataTable dataTable = SqlDBA.RunProcc(new SqlConnection(DBA.getstrConnection("rxjhaccount")), "XWWL_LOAD_ACCOUNT", new SqlParameter[1] { SqlDBA.MakeInParam("@id", SqlDbType.VarChar, 30, UserId) });
			if (dataTable != null)
			{
				if (dataTable.Rows.Count > 0)
				{
					return dataTable;
				}
				dataTable.Dispose();
			}
			return null;
		}

		public static void 设置账号在线状态(string uid, int online)
		{
			DBA.ExeSqlCommand($"UPDATE  TBL_ACCOUNT  SET  FLD_ONLINE={online}  WHERE  FLD_ID='{uid}'", "rxjhaccount");
		}
	}
}
