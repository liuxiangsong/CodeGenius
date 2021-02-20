using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Data.SqlClient;

namespace CodeGenius.Entity
{
    [Serializable]
    public class SqlDataEngineSchema : DataEngineSchema
    {
        public SqlDataEngineSchema()
        {
        }

        public SqlDataEngineSchema(string initializedConnectionString)
            : base(initializedConnectionString)
        {
            ConnectionString = initializedConnectionString;
        }

        
        private SqlDataSourceInfo sqlDataSourceInfo=new SqlDataSourceInfo();
        public SqlDataSourceInfo SqlDataSourceInfo
        {
            get{return sqlDataSourceInfo;}
            set{sqlDataSourceInfo=value;}
        }
    }
}
