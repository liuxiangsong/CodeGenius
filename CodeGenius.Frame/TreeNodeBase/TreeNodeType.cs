using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenius.Frame.TreeNodeBase
{
    /// <summary>
    /// 节点类型
    /// </summary>
    public enum TreeNodeType
    {
        /// <summary>
        /// 未定义
        /// </summary>
        Undefined,
        /// <summary>
        /// 服务器节点
        /// </summary>
        ServerNode,
        /// <summary>
        /// 数据库集合节点
        /// </summary>
        DataBasesNode,
        /// <summary>
        /// 数据库节点
        /// </summary>
        DatabaseNode,
        /// <summary>
        /// 表集合节点
        /// </summary>
        TablesNode,
        /// <summary>
        /// 表节点
        /// </summary>
        TableNode,
        /// <summary>
        /// 列节点
        /// </summary>
        ColumnNode,
        /// <summary>
        /// 视图集合节点
        /// </summary>
        ViewsNode,
        /// <summary>
        /// 视图节点
        /// </summary>
        ViewNode,
        /// <summary>
        /// 存储过程节点
        /// </summary>
        ProcdureNode,
    }
}
