using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;

using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace DBHelper
{
    public class SqlHelper
    {
        #region 成员变量
        private static string _SqlConnectionString;
        private static Database db;

        public static string SqlConnectionString
        {
            get { return _SqlConnectionString; }
            set { _SqlConnectionString = value; }
        }
        #endregion

        #region MyRegion
        //private static SqlConnection sqlCon;
        //#region ConnectionOpen
        //private static bool ConnectionOpen()
        //{
        //    try
        //    {
        //        if (sqlCon == null || SqlHelper.sqlCon.State != ConnectionState.Open)
        //        {
        //            SqlHelper.sqlCon = new SqlConnection(SqlConnectionString);
        //            SqlHelper.sqlCon.Open();
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //#endregion

        //#region GetDataSet
        //public static DataSet GetDataSet(string sqlString)
        //{
        //    ConnectionOpen();
        //    using (SqlDataAdapter sda = new SqlDataAdapter(sqlString, SqlHelper.sqlCon))
        //    {
        //        sda.SelectCommand.CommandTimeout = 0;
        //        DataSet ds = new DataSet();
        //        sda.Fill(ds);
        //        SqlHelper.sqlCon.Dispose();
        //        SqlHelper.sqlCon.Close();
        //        return ds;
        //    }
        //}
        //#endregion

        //#region GetDataTable
        //public static DataTable GetDataTable(string sqlString)
        //{
        //    ConnectionOpen();
        //    using (SqlDataAdapter sda = new SqlDataAdapter(sqlString, SqlHelper.sqlCon))
        //    {
        //        sda.SelectCommand.CommandTimeout = 0;
        //        DataTable dt = new DataTable();
        //        sda.Fill(dt);
        //        SqlHelper.sqlCon.Dispose();
        //        SqlHelper.sqlCon.Close();
        //        return dt;
        //    }
        //}
        //#endregion

        //#region GetSqlDataReader
        //public static SqlDataReader GetSqlDataReader(string sqlString)
        //{
        //    ConnectionOpen();
        //    SqlDataReader sdr = null;
        //    using (SqlCommand Cmd = new SqlCommand(sqlString, SqlHelper.sqlCon))
        //    {
        //        try
        //        {
        //            sdr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //        }
        //        catch (Exception ex)
        //        {
        //            SqlHelper.sqlCon.Dispose();
        //            SqlHelper.sqlCon.Close();
        //            throw ex;
        //        }
        //    }
        //    return sdr;
        //}
        //#endregion

        //#region ExecuteSQL
        //public static bool ExecuteSQL(string sqlString)
        //{
        //    ConnectionOpen();
        //    using (SqlCommand Cmd = new SqlCommand(sqlString, SqlHelper.sqlCon))
        //    {
        //        Cmd.CommandTimeout = 0;
        //        try
        //        {
        //            Cmd.ExecuteNonQuery();
        //            SqlHelper.sqlCon.Dispose();
        //            SqlHelper.sqlCon.Close();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            SqlHelper.sqlCon.Dispose();
        //            SqlHelper.sqlCon.Close();
        //            throw ex;
        //        }
        //    }
        //}
        //#endregion 
        #endregion

        public string GetSqlServerVersion()
        {
            using (IDataReader sdr = ExecuteDataReader("SELECT SERVERPROPERTY('ProductVersion') as VersionNumber"))
            {
                if (sdr.Read())
                {
                    return sdr[0].ToString();
                }
            }
            return string.Empty;
        }
 
        public static bool ExecuteNonQuery(string commandText, SqlParameter[] sqlParams=null, DbTransaction trans = null)
        {
            DbCommand cmd = GetDbCommand(commandText, sqlParams);
            if (trans == null)
                return db.ExecuteNonQuery(cmd) > 0;
            else
                return db.ExecuteNonQuery(cmd, trans) > 0;
        }

        public static DataSet ExecuteDataSet(string commandText, SqlParameter[] sqlParams=null)
        {
            DbCommand cmd = GetDbCommand(commandText, sqlParams);
            return db.ExecuteDataSet(cmd);
        }

        public static DataTable ExecuteDataTable(string commandText, SqlParameter[] sqlParams=null)
        {
            DataSet ds = ExecuteDataSet(commandText, sqlParams);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static IDataReader ExecuteDataReader(string commandText, SqlParameter[] sqlParams=null)
        {
            DbCommand cmd = GetDbCommand(commandText, sqlParams);
            return db.ExecuteReader(cmd);
        }

        private static DbCommand GetDbCommand(string commandText, SqlParameter[] sqlParams)
        {
            db = new SqlDatabase(SqlConnectionString);
            DbCommand cmd = db.GetSqlStringCommand(commandText);
            if (sqlParams != null)
                cmd.Parameters.AddRange(sqlParams);
            return cmd;
        }
    }
}
