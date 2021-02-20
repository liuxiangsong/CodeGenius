using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenius.Entity
{
    [Serializable]
   public class SqlDataSourceInfo
    {
        //服务器名
       public string ServerName { get; set; }

       //服务器实例的名称。 如果服务器作为默认实例运行，则为空。
       public string InstanceName { get; set; }

       //指示服务器是否是群集的一部分
       public string IsClustered { get; set; }

       //8.00.x  (SQL Server 2000) 9.00.x  (SQL Server 2005)
       //10.0.xx (SQL Server 2008) 10.50.x (SQL Server 2008 R2)
       //11.0.xx (SQL Server 2012)
       public string Version { get; set; }


       public string ProductLevel{get;set;}
       public string Edition{get;set;}
       public string DataSource { get; set; }
       public string UserID { get; set; }
       public string Password { get; set; }
       public bool IntegratedSecurity { get; set; }

       public string CurrentDataBase { get; set; }

    }
}
