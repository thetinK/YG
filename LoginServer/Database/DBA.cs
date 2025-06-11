using Core;
using System;
using System.Data;
using System.Data.SqlClient;
using UI;
using Utilities;

namespace Database
{
    public class DBA
    {
        // Default command timeout (seconds)
        public static int DefaultCommandTimeout = 60;

        public static string getstrConnection(string db)
        {
            try
            {
                if (db == null)
                {
                    db = "rxjhaccount";
                }
                DbClass value;
                return World.Db.TryGetValue(db, out value) ? value.SqlConnect : null;
            }
            catch
            {
                return null;
            }
        }

        public static int ExeSqlCommand(string sqlCommand)
        {
            return ExeSqlCommand(sqlCommand, null, DefaultCommandTimeout);
        }

        public static int ExeSqlCommand(string sqlCommand, string server)
        {
            return ExeSqlCommand(sqlCommand, server, DefaultCommandTimeout);
        }

        /// <summary>
        /// Execute SQL command with custom timeout
        /// </summary>
        public static int ExeSqlCommand(string sqlCommand, string server, int commandTimeout)
        {
            using SqlConnection sqlConnection = new SqlConnection(getstrConnection(server));
            using SqlCommand sqlCommand2 = new SqlCommand(sqlCommand, sqlConnection);

            // ✅ ตั้ง Command Timeout ที่นี่
            sqlCommand2.CommandTimeout = commandTimeout;

            int result = -1;
            try
            {
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"Database connection failed: {ex.Message}");
                return -1;
            }

            try
            {
                result = sqlCommand2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"DBA数据层_错误: {ex.Message}");
                MainForm.WriteLine(1, "DBA数据层_错误" + ex.Message);
            }

            sqlCommand2.Dispose();
            sqlConnection.Close();
            sqlConnection.Dispose();
            return result;
        }

        public static DataTable GetDBToDataTable(string sqlCommand)
        {
            return GetDBToDataTable(sqlCommand, null, DefaultCommandTimeout);
        }

        public static DataTable GetDBToDataTable(string sqlCommand, string server)
        {
            return GetDBToDataTable(sqlCommand, server, DefaultCommandTimeout);
        }

        /// <summary>
        /// Get DataTable with custom timeout
        /// </summary>
        public static DataTable GetDBToDataTable(string sqlCommand, string server, int commandTimeout)
        {
            using SqlConnection sqlConnection = new SqlConnection(getstrConnection(server));
            using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            SqlCommand sqlCommand4 = sqlDataAdapter.SelectCommand = new SqlCommand(sqlCommand, sqlConnection);
            SqlCommand sqlCommand2 = sqlCommand4;

            // ✅ ตั้ง Command Timeout
            sqlCommand2.CommandTimeout = commandTimeout;

            using (sqlCommand2)
            {
                try
                {
                    sqlConnection.Open();
                }
                catch (Exception ex)
                {
                    ComprehensiveLogger.WriteError($"Database connection failed: {ex.Message}");
                    return null;
                }

                DataTable dataTable = new DataTable();
                try
                {
                    sqlDataAdapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    ComprehensiveLogger.WriteError($"DBA数据层_错误: {ex.Message}");
                    MainForm.WriteLine(1, "DBA数据层_错误" + ex.Message);
                }

                sqlDataAdapter.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return dataTable;
            }
        }

        public static int RunProc(SqlConnection conn, string procName, SqlParameter[] prams)
        {
            int result = -1;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"SqlDBA数据层_错误3: {ex.Message}");
                MainForm.WriteLine(100, "SqlDBA数据层_错误3" + ex.Message);
                return result;
            }

            SqlCommand sqlCommand = CreateCommand(conn, procName, prams);
            try
            {
                return sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex2)
            {
                ComprehensiveLogger.WriteError($"SqlDBA数据层_错误4: {ex2.Message}");
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

        public static SqlCommand CreateCommand(SqlConnection conn, string procName, SqlParameter[] prams)
        {
            SqlCommand sqlCommand = new SqlCommand(procName, conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // ✅ ใช้ configurable timeout แทนค่าคงที่
            sqlCommand.CommandTimeout = DefaultCommandTimeout;

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

        public static SqlParameter MakeParam(string ParamName, SqlDbType DbType, int Size, ParameterDirection Direction, object Value)
        {
            SqlParameter sqlParameter = Size <= 0 ? new SqlParameter(ParamName, DbType) : new SqlParameter(ParamName, DbType, Size);
            sqlParameter.Direction = Direction;
            if (Direction != ParameterDirection.Output || Value != null)
            {
                sqlParameter.Value = Value;
            }
            return sqlParameter;
        }

        /// <summary>
        /// Set global command timeout from configuration
        /// </summary>
        public static void SetCommandTimeout(int timeoutSeconds)
        {
            DefaultCommandTimeout = timeoutSeconds;
            ComprehensiveLogger.WriteDatabase($"Database command timeout set to {timeoutSeconds} seconds");
        }
    }
}