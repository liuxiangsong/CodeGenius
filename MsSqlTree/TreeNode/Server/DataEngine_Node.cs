using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeGenius.Frame.TreeNodeBase;
using MsSqlTree.TreeNode.DataEngine;
using System.Data.SqlClient;
using CodeGenius.Entity;
using System.Security.Principal;

namespace MsSqlTree.TreeNode.Server
{
   public class DataEngine_Node : DbTreeNode
    {
       public DataEngine_Node()
       {
           nodeType = TreeNodeType.ServerNode;
           Text = "SQL Server";
           ImageKey = SelectedImageKey = "SQLServerEngine";
       }

       public DataEngine_Node(SqlDataEngineSchema dataEngine)
           : this()
       {           
           SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(dataEngine.ConnectionString);
           //Text = builder.DataSource + " ("
           //    + "SQL Server "
           //    + SqlSchemaHelper.GetSchemaDataTableByCollectionName(dataEngine.ConnectionString).Rows[0]["DataSourceProductVersion"].ToString() + " - "
           //    //+ (string.IsNullOrEmpty(builder.UserID) ? "WINDOWS" : builder.UserID) + ")";
           //     + builder.UserID + ")";
           Text = string.Format("{0}(SQL Server {1} - {2})", builder.DataSource
                                                        , SqlSchemaHelper.GetSchemaDataTableByCollectionName(dataEngine.ConnectionString).Rows[0]["DataSourceProductVersion"].ToString()
                                                        , string.IsNullOrEmpty(builder.UserID) ? WindowsIdentity.GetCurrent().Name : builder.UserID);
           ImageKey = SelectedImageKey = "SQLServerEngine";
       }


       protected override void ExpandTreeNode(object parameters)
       {
           Nodes.Clear();
           Nodes.Add(new DataBases_Node()); 
       }


    }
}
