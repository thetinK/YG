using System;
using System.Data.SqlClient;

namespace RxjhServer.DbClss
{
	public class DbPoolClass
	{
		private string conn;

		private SqlParameter[] prams;

		private int type;

		private string sql;

		public string Conn
		{
			get
			{
				return conn;
			}
			set
			{
				conn = value;
			}
		}

		public SqlParameter[] Prams
		{
			get
			{
				return prams;
			}
			set
			{
				prams = value;
			}
		}

		public int Type
		{
			get
			{
				return type;
			}
			set
			{
				type = value;
			}
		}

		public string Sql
		{
			get
			{
				return sql;
			}
			set
			{
				sql = value;
			}
		}

		public static int DbPoolClassRun(string SqlConnection, string procName, SqlParameter[] prams, int Type)
		{
			try
			{
				SqlConnection sqlConnection = new SqlConnection(SqlConnection);
				return (Type != 1) ? ((SqlDBA.RunProc(sqlConnection, procName, prams) == -1) ? (-1) : 0) : ((SqlDBA.RunProcSql(sqlConnection, procName, prams) == -1) ? (-1) : 0);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "DbPoolClassRun出错" + ex);
				return -1;
			}
		}
	}
}
