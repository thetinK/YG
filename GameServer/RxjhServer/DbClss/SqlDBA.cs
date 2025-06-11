using System;
using System.Data;
using System.Data.SqlClient;

namespace RxjhServer.DbClss
{
	public class SqlDBA
	{
		public static int RunProc(SqlConnection conn, string procName, SqlParameter[] prams)
		{
			try
			{
				conn.Open();
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(100, "SqlDBA数据层_错误1" + ex.Message);
				return -1;
			}
			SqlCommand sqlCommand = CreateCommand(conn, procName, prams);
			try
			{
				sqlCommand.ExecuteNonQuery();
			}
			catch (Exception ex2)
			{
				MainForm.WriteLine(100, "SqlDBA数据层_错误2" + ex2.Message);
				sqlCommand.Parameters.Clear();
				return -1;
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}

		public static int RunProcSql(SqlConnection conn, string procName, SqlParameter[] prams)
		{
			int result = -1;
			try
			{
				conn.Open();
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(100, "SqlDBA数据层_错误3" + ex.Message);
				return result;
			}
			SqlCommand sqlCommand = CreateCommandSql(conn, procName, prams);
			try
			{
				return sqlCommand.ExecuteNonQuery();
			}
			catch (Exception ex2)
			{
				MainForm.WriteLine(100, "SqlDBA数据层_错误4" + ex2.Message);
				sqlCommand.Parameters.Clear();
				return result;
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
		}

		public static void RunProc(SqlConnection conn, string procName, out SqlDataReader dataReader)
		{
			SqlCommand sqlCommand = CreateCommand(conn, procName, null);
			dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
		}

		public static void RunProc(SqlConnection conn, string procName, SqlParameter[] prams, out SqlDataReader dataReader)
		{
			SqlCommand sqlCommand = CreateCommand(conn, procName, prams);
			dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
		}

		public static void RunProc(SqlConnection conn, string procName, SqlParameter[] prams, out DataSet dataReader)
		{
			SqlCommand sqlCommand = CreateCommand(conn, procName, prams);
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			sqlCommand.Parameters.Clear();
			conn.Close();
			conn.Dispose();
			dataReader = dataSet;
			sqlDataAdapter.Dispose();
		}

		public static DataTable RunProcc(SqlConnection conn, string procName, SqlParameter[] prams)
		{
			DataTable dataTable = new DataTable();
			SqlCommand sqlCommand = CreateCommand(conn, procName, prams);
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
			{
				try
				{
					sqlDataAdapter.Fill(dataTable);
				}
				catch
				{
				}
				sqlCommand.Parameters.Clear();
				sqlDataAdapter.Dispose();
				conn.Close();
				conn.Dispose();
			}
			return dataTable;
		}

		public static SqlCommand CreateCommand(SqlConnection conn, string procName, SqlParameter[] prams)
		{
			SqlCommand sqlCommand = new SqlCommand(procName, conn)
			{
				CommandType = CommandType.StoredProcedure,
				CommandTimeout = 180
			};
			if (prams != null)
			{
				foreach (SqlParameter value in prams)
				{
					sqlCommand.Parameters.Add(value);
				}
			}
			sqlCommand.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, isNullable: false, 0, 0, string.Empty, DataRowVersion.Default, null));
			return sqlCommand;
		}

		public static SqlCommand CreateCommandSql(SqlConnection conn, string procName, SqlParameter[] prams)
		{
			SqlCommand sqlCommand = new SqlCommand(procName, conn)
			{
				CommandType = CommandType.Text,
				CommandTimeout = 180
			};
			if (prams != null)
			{
				foreach (SqlParameter value in prams)
				{
					sqlCommand.Parameters.Add(value);
				}
			}
			sqlCommand.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, isNullable: false, 0, 0, string.Empty, DataRowVersion.Default, null));
			return sqlCommand;
		}

		public static SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
		{
			return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
		}

		public static SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size)
		{
			return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
		}

		public static SqlParameter MakeParam(string ParamName, SqlDbType DbType, int Size, ParameterDirection Direction, object Value)
		{
			SqlParameter sqlParameter = ((Size <= 0) ? new SqlParameter(ParamName, DbType) : new SqlParameter(ParamName, DbType, Size));
			sqlParameter.Direction = Direction;
			if (Direction != ParameterDirection.Output || Value != null)
			{
				sqlParameter.Value = Value;
			}
			return sqlParameter;
		}
	}
}
