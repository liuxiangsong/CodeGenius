using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGenius
{
    /// <summary>
    /// 变量命名格式：如MsgAdd00 
    /// Msg为固定开头，中间字母部分Add标识其为新增。
    /// 两位数字00：第一位数：0：不成功，1：成功,2:询问语句,3：感叹语句
    ///             第二、三位数为流水号，并无实际意义。
    /// </summary>
    public class MessageInfo
    {
        /// <summary>
        /// 没有可用的数据库连接！
        /// </summary>
        public const string MsgInfo300 = "没有可用的数据库连接！";

        /// <summary>
        /// 请先选择要查询的表或视图！
        /// </summary>
        public const string MsgInfo301 = "请先选择要查询的表或视图！";
    }
}
