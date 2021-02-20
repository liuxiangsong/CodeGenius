using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CodeGenius.CSharp
{
    public sealed class SQLHelper
    {
        #region 变量
        private static SqlConnection sqlCon = null;
        private static string _SqlConnectionString;

        public static string SqlConnectionString
        {
            get { return _SqlConnectionString; }
            set { _SqlConnectionString = value; }
        }
        #endregion

        #region Open Connection
        private static bool ConnectionOpen()
        {
            try
            {
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(SqlConnectionString);
                }
                if (sqlCon.State != ConnectionState.Open)
                {
                    sqlCon.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ExcuteNonQuery
        /// <summary>
        /// ExcuteNonQuery(string sqlString)
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <returns></returns>
        public static int ExcuteNonQuery(string sqlString)
        {
            int returnValue = -1;
            ConnectionOpen();
            using (SqlCommand cmd = new SqlCommand(sqlString, sqlCon))
            {
                try
                {
                    returnValue = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlCon.Dispose();
                    sqlCon.Close();
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 执行带参数的SQL语句，返回受影响的行数
        /// </summary>
        /// <param name="commandText">带参数的SQL语句</param>
        /// <param name="commandParams">SqlParameter数组</param>
        /// <returns></returns>
        public static int ExcuteNonQuery(string commandText, SqlParameter[] commandParams)
        {
            int returnValue = -1;
            ConnectionOpen();
            using (SqlCommand cmd = new SqlCommand(commandText, sqlCon))
            {
                AttachParams(cmd, commandParams);
                try
                {
                    returnValue = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlCon.Dispose();
                    sqlCon.Close();
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 执行存储过程，返回受影响的行数
        /// </summary>
        /// <param name="spName">存储过程名</param>
        /// <param name="commandParams">SqlParameter数组</param>
        /// <returns></returns>
        public static int ExcuteNonQuery(bool isProce,string spName, SqlParameter[] commandParams)
        {
            int returnValue = -1;
            if (isProce == false) return returnValue;
            ConnectionOpen();
            using (SqlCommand cmd = new SqlCommand(spName, sqlCon))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                AttachParams(cmd, commandParams);
                try
                {
                    returnValue = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlCon.Dispose();
                    sqlCon.Close();
                }
            }
            return returnValue;
        }

        public static int getExcuteNonQuery(string commandText, SqlParameter[] commandParm, SqlTransaction trans)
        {
            if (trans == null)//如果事務為空，直接失敗返回

                return 0;

            SqlCommand sqlCommand = new SqlCommand(commandText, trans.Connection);
            sqlCommand.Transaction = trans;
            AttachParams(sqlCommand, commandParm);
            int rowCount = 0;
            try
            {
                rowCount = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            return rowCount;
        }
        #endregion

        #region GetDataTableOrDataSet
        /// <summary>
        /// 执行SQL语句，返回DataSet
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sqlString)
        {
            DataSet ds = new DataSet();
            ConnectionOpen();
            using (SqlDataAdapter sda = new SqlDataAdapter(sqlString, sqlCon))
            {
                try
                {
                    sda.Fill(ds);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlCon.Dispose();
                    sqlCon.Close();
                }
            }
            return ds;
        }

        /// <summary>
        /// 执行带参数的SQL语句，返回DataSet
        /// </summary>
        /// <param name="commandText">带参数的SQL语句</param>
        /// <param name="commandParams">SqlParameter数组</param>
        /// <returns></returns>
        public static DataSet GetDataSet(string commandText, SqlParameter[] commandParams)
        {
            DataSet ds = new DataSet();
            ConnectionOpen();
            using (SqlCommand cmd = new SqlCommand(commandText, sqlCon))
            {
                AttachParams(cmd, commandParams);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    try
                    {
                        sda.Fill(ds);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        sqlCon.Dispose();
                        sqlCon.Close();
                    }
                }
            }
            return ds;
        }

        /// <summary>
        /// 执行存储过程，返回DataSet
        /// </summary>
        /// <param name="spName">存储过程名</param>
        /// <param name="commandParams">SqlParameter数组</param>
        /// <returns></returns>
        public static DataSet GetDataSet(bool isProce, string spName, SqlParameter[] commandParams)
        {
            if (isProce == false) return null;
            DataSet ds = new DataSet();
            ConnectionOpen();
            using (SqlCommand cmd = new SqlCommand(spName, sqlCon))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                AttachParams(cmd, commandParams);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    try
                    {
                        sda.Fill(ds);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        sqlCon.Dispose();
                        sqlCon.Close();
                    }
                }
                return ds;
            }
        }

        public static DataTable GetDataTable(string sqlString)
        {
            try
            {
                return GetDataSet(sqlString).Tables[0];
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public static DataTable GetDataTable(string commandText, SqlParameter[] commandParams)
        {
            try
            {
                return GetDataSet(commandText, commandParams).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetDataTable(bool isProce, string spName, SqlParameter[] commandParams)
        {
            try
            {
                return GetDataSet(isProce, spName, commandParams).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetDataReader
        public static SqlDataReader GetDataReader(string sqlString)
        {
            ConnectionOpen(); 
            using (SqlCommand cmd = new SqlCommand(sqlString, sqlCon))
            {
                try
                {
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception ex)
                {
                    sqlCon.Dispose();
                    sqlCon.Close();
                    throw ex;
                }
            } 
        }

        public static SqlDataReader GetDataReader(string commandText, SqlParameter[] commandParams)
        {
            ConnectionOpen(); 
            using (SqlCommand cmd = new SqlCommand(commandText, sqlCon))
            {
                AttachParams(cmd, commandParams);
                try
                {
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception ex)
                {
                    sqlCon.Dispose();
                    sqlCon.Close();
                    throw ex;
                }
            } 
        }

        public static SqlDataReader GetDataReader(bool isProce, string spName, SqlParameter[] commandParams)
        {
            if (isProce == false) return null;
            ConnectionOpen(); 
            using (SqlCommand cmd = new SqlCommand(spName, sqlCon))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                AttachParams(cmd, commandParams);
                try
                {
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception ex)
                {
                    sqlCon.Dispose();
                    sqlCon.Close();
                    throw ex;
                }
            }
        }
        #endregion

        #region GetExecuteScalar
        /// <summary>
        /// 执行查询，返回结果集中的第一行第一列
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <returns></returns>
        public static object GetExecuteScalar(string sqlString)
        {
            object obj = null;
            ConnectionOpen();
            using (SqlCommand cmd = new SqlCommand(sqlString, sqlCon))
            {
                try
                {
                    obj = cmd.ExecuteScalar();
                    if (obj.Equals(DBNull.Value)) obj = null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlCon.Dispose();
                    sqlCon.Close();
                }
            }
            return obj;
        }

        /// <summary>
        /// 执行查询，返回结果集中的第一行第一列
        /// </summary>
        /// <param name="commandText">带参数的SQL语句</param>
        /// <param name="commandParams">SqlParameter 数组</param>
        /// <returns></returns>
        public static object GetExecuteScalar(string commandText, SqlParameter[] commandParams)
        {
            object obj = null;
            ConnectionOpen();
            using (SqlCommand cmd = new SqlCommand(commandText, sqlCon))
            {
                AttachParams(cmd, commandParams);
                try
                {
                    obj = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlCon.Dispose();
                    sqlCon.Close();
                }
            }
            return obj;
        }
        #endregion

        #region IsExists    
        /// <summary>
        /// 执行查询，判断是否查询到数据
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <returns>true表示存在，false表示不存在</returns>
        public static bool IsExists(string sqlString)
        {
            SqlDataReader sdr = GetDataReader(sqlString);
            return sdr.HasRows ? true : false;
        }
        #endregion

        #region OtherMehods
        /// <summary>
        /// 将SqlParameter参数数组(参数值)分配给SqlCommand命令. 
        ///这个方法将给任何一个参数分配DBNull.Value,阻止默认值的使用. 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="commandParams"></param>
        private static void AttachParams(SqlCommand command, SqlParameter[] commandParams)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParams != null)
            {
                foreach (SqlParameter param in commandParams)
                {
                    if (param.Value == null)
                    {
                        param.Value = DBNull.Value;
                    }
                    command.Parameters.Add(param);
                }
            }
        }
        #endregion
    }
}
