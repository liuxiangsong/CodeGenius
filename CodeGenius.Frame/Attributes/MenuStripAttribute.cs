using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenius.Frame.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class MenuStripAttribute : Attribute
    {
        protected Type trueType;
        protected string key = string.Empty;
        protected int order;
        protected int important;

        protected string groupKey = string.Empty;
        protected int groupOrder;
        protected string parentKey = string.Empty;


        /// <summary>
        /// 当该特性标注 类时，记录类的 实际类型；
        /// 或者 当该特性标注 函数时，表示 该函数 想要隶属的 特性类 下；
        /// </summary>
        public Type TrueType
        {
            get { return trueType; }
            set { trueType = value; }
        }
        /// <summary>
        /// 工具栏上按钮所对应的Tag Key值；
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        /// <summary>
        /// 排序值；
        /// </summary>
        public int Order
        {
            get { return order; }
            set { order = value; }
        }
        /// <summary>
        /// 重要指数；
        /// </summary>
        public virtual int Important
        {
            get { return important; }
            set { important = value; }
        }
        /// <summary>
        /// 分组的排序值；
        /// </summary>
        public int GroupOrder
        {
            get { return groupOrder; }
            set { groupOrder = value; }
        }
        /// <summary>
        /// 分组标识，表示 那几个 按钮会在一组，组与组之间用横线隔开；
        /// </summary>
        public string GroupKey
        {
            get { return groupKey; }
            set { groupKey = value; }
        }
        /// <summary>
        /// 父选项；
        /// </summary>
        public string ParentKey
        {
            get { return parentKey; }
            set { parentKey = value; }
        }

        public MenuStripAttribute(string navBarKey, string groupKey, int orderIndex, Type trueType)
        {
            Key = navBarKey;
            GroupKey = groupKey;
            Order = orderIndex;
            TrueType = trueType;
        }
        public MenuStripAttribute(string navBarKey, int orderIndex, Type trueType)
        {
            Key = navBarKey;
            TrueType = trueType;
            Order = orderIndex;
        }
        public MenuStripAttribute()
        {
        }

        public override string ToString()
        {
            return Key;
        }
    }
}
