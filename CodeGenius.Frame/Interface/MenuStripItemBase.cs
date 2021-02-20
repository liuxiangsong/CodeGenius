using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CodeGenius.Frame.Attributes;
using LibraryGenius;
using System.Windows.Forms;
using CodeGenius.Frame.TreeNodeBase;

namespace CodeGenius.Frame.Interface
{
    /// 每个菜单项就是一个IMenuStripItem
    /// 每个IMenuStripItem包含一个菜单面板menuStripPanel
    /// 每个菜单面板包含多个菜单组MenuStripGroup
    /// 每个菜单组包含多个菜单项IMenuStripItem  

    /// <summary>
    /// 菜单项
    /// </summary>
    public abstract class MenuStripItemBase : IMenuStripItem
    {
        #region 变量及属性
        /// <summary>
        /// 所有菜单特性集合
        /// </summary>
        private static readonly List<MenuStripAttribute> menuStripAttributes = new List<MenuStripAttribute>();

        private ToolStripMenuItem menuStripItem;

        private string key = string.Empty;
        private string caption = string.Empty;
        private int order;
        private Image image;

        #region 菜单项的面板
        /// <summary>
        /// 菜单项的面板
        /// </summary>
        private MenuStripPanel menuStripPanel = new MenuStripPanel();
        ///// <summary>
        ///// 菜单项的面板
        ///// </summary>
        //public MenuStripPanel MenuStripPanel
        //{
        //    get { return menuStripPanel; }
        //    set { menuStripPanel = value; }
        //} 
        #endregion

        /// <summary>
        /// 菜单项的键
        /// </summary>
        public virtual string Key
        {
            get { return key; }
            set { key = value; }
        }
        /// <summary>
        /// 菜单项的标题
        /// </summary>
        public virtual string Caption
        {
            get { return caption; }
            set { caption = value; }
        }
        /// <summary>
        /// 菜单项的排序码
        /// </summary>
        public virtual int Order
        {
            get { return order; }
            set { order = value; }
        }
        /// <summary>
        /// 菜单项的图标
        /// </summary>
        public virtual Image Image
        {
            get { return image; }
            set { image = value; }
        }

        /// <summary>
        /// 菜单项是否可用
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public abstract bool Enable(DbTreeNode node);
        /// <summary>
        /// 菜单项是否可见
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public abstract bool Visible(DbTreeNode node);
        /// <summary>
        /// 菜单项点击委托事件
        /// </summary>
        public abstract MenuStripHandler MenuStripHandler { get; set; }

        #region 含有所有标注 MenuStripAttribute 特性的集合MenuStripAttributes；
        /// <summary>
        /// 整个程序运行时，所有标注 MenuStripAttribute 特性的信息；
        /// </summary>      
        public static List<MenuStripAttribute> MenuStripAttributes
        {
            get
            {
                if (menuStripAttributes.Count < 1 || menuStripAttributes == null)
                    InitializeMenuStripAttributes();
                return menuStripAttributes;
            }
        }
        public static List<MenuStripAttribute> InitializeMenuStripAttributes()
        {
            menuStripAttributes.Clear();
            Dictionary<Type, MenuStripAttribute> list = AssemblyHelper.GetAttributes<MenuStripAttribute>();
            foreach (MenuStripAttribute attribute in list.Values)
                menuStripAttributes.Add(attribute);
            return menuStripAttributes;
        }
        #endregion

        #region 取得所有特性中的父键为Key的所有特性
        private List<MenuStripAttribute> childAttributes;
        /// <summary>
        /// 取得本菜单项的所有子特性
        /// </summary> 
        /// <returns></returns>
        private List<MenuStripAttribute> ChildAttributes
        {
            get
            {
                if (childAttributes == null)
                {
                    childAttributes = new List<MenuStripAttribute>();
                    foreach (MenuStripAttribute attribute in MenuStripItemBase.MenuStripAttributes)
                        if (attribute.ParentKey.ToLower().Trim() == this.Key.ToLower().Trim())
                            childAttributes.Add(attribute);
                }
                return childAttributes;
            }
        }
        #endregion
         
        #region 取得所有特性中的父键为Key的所有特性对应菜单项的字典
        private Dictionary<MenuStripAttribute, IMenuStripItem> mapping;

        private Dictionary<MenuStripAttribute, IMenuStripItem> Mapping
        {
            get
            {
                if (mapping == null)
                {
                    mapping = new Dictionary<MenuStripAttribute, IMenuStripItem>();
                    foreach (MenuStripAttribute attribute in this.ChildAttributes)
                    {
                        IMenuStripItem item = (IMenuStripItem)Activator.CreateInstance(attribute.TrueType);
                        item.Key = attribute.Key;
                        item.Order = attribute.Order;

                        item.Initialize();
                        mapping.Add(attribute, item);
                    }
                }
                return mapping;
            }

        } 
        #endregion
       
        /// <summary>
        /// 取得右键菜单的所有图标
        /// </summary>
        /// <param name="imageKeyOrFile"></param>
        /// <returns></returns>
        public static Image GetStripImage(string imageKeyOrFile)
        {
            if (string.IsNullOrEmpty(imageKeyOrFile)) return null;

            string imageFile = imageKeyOrFile.Contains(":")
                                   ? imageKeyOrFile
                                   : AppDomain.CurrentDomain.BaseDirectory + imageKeyOrFile;

            return System.IO.File.Exists(imageFile) ? Image.FromFile(imageFile) : null;
        }
        #endregion

        /// <summary>
        /// 初始化菜单项
        /// </summary>
        public void Initialize()
        {
            menuStripPanel.ParentKey = Key; 
            menuStripPanel.Initialize(this.ChildAttributes,this.Mapping);
        }

        /// <summary>
        /// 生成菜单项
        /// </summary>
        /// <param name="node">右击时选中的树节点</param>
        /// <returns></returns>
        public virtual ToolStripMenuItem GetUI(DbTreeNode node)
        {
            if (menuStripItem == null)
            {
                menuStripItem = new ToolStripMenuItem();
            }
            IMenuStripContainer msc = BaseMainForm.GetInstance();

            menuStripItem = new ToolStripMenuItem();
            menuStripItem.Text = Caption + ":" + Order.ToString();
            menuStripItem.Image = Image;
            menuStripPanel.Initialize(this.ChildAttributes, this.Mapping);
            menuStripItem.DropDownItems.AddRange(menuStripPanel.GetUI(node).ToArray());

            msc.AddMenuStripInvoke(Key, MenuStripHandler);
            menuStripItem.Click += (sender, e) => msc.MenuStripClick(sender, e, Key);
            return menuStripItem;
        }

        /// <summary>
        /// 刷新右键菜单
        /// </summary>
        /// <param name="menuStrip">右键菜单</param>
        /// <param name="node">树节点，在右击时选中的节点</param>
        /// <returns>返回右键菜单</returns>
        public static ContextMenuStrip RefreshContextMenuStrip(ContextMenuStrip menuStrip, DbTreeNode node)
        {
            //如果右键菜单已存在，直接返回
            if (menuStrip.Items.Count > 0) return menuStrip;

            //取得所有标注MenuStripAttribute特性的集合
            List<MenuStripAttribute> attributeList = MenuStripItemBase.MenuStripAttributes;
            Dictionary<MenuStripAttribute, IMenuStripItem> mapping = new Dictionary<MenuStripAttribute, IMenuStripItem>();
            foreach (MenuStripAttribute attribute in attributeList)
            {
                //通过反射特性中的类型取得其对象
                IMenuStripItem item = (IMenuStripItem)Activator.CreateInstance(attribute.TrueType);
                item.Key = attribute.Key;       //键值
                item.Order = attribute.Order;   //排序码
                item.Initialize();

                mapping.Add(attribute, item);
            }

            MenuStripPanel panel = new MenuStripPanel();
            panel.Initialize(attributeList, mapping);
            List<ToolStripItem> items = panel.GetUI(node);
            foreach (ToolStripItem item in items)
            {
                menuStrip.Items.Add(item);
            }
            if (menuStrip.Items.Count > 0 && menuStrip.Items[menuStrip.Items.Count - 1] is ToolStripSeparator)
                menuStrip.Items.RemoveAt(menuStrip.Items.Count - 1);
            return menuStrip;
        }
    }

    /// <summary>
    /// 菜单组
    /// </summary>
    public class MenuStripGroup
    {
        #region 变量及属性
        protected string key = string.Empty;
        protected string parentKey = string.Empty;
        protected int order;
        public Dictionary<string, IMenuStripItem> Items = new Dictionary<string, IMenuStripItem>();

        /// <summary>
        /// 菜单组键
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        /// <summary>
        /// 菜单组的父键
        /// </summary>
        public string ParentKey
        {
            get { return parentKey; }
            set { parentKey = value; }
        }
        /// <summary>
        /// 菜单组的排序码
        /// </summary>
        public int Order
        {
            get { return order; }
            set { order = value; }
        }
        #endregion

        /// <summary>
        /// 初始化菜单组,把属性该分组的菜单项放在该组中
        /// </summary>
        /// <param name="childAttributes">菜单项下的所有子特性集合</param>
        /// <param name="paramMapping">特性与菜单项对应的字典</param>
        public void Initialize(List<MenuStripAttribute> childAttributes, Dictionary<MenuStripAttribute, IMenuStripItem> paramMapping)
        {
            Items.Clear();
            foreach (MenuStripAttribute attribute in childAttributes)
            {
                //取子特性集合中的父键值与该组的父键相同的
                if (parentKey.ToLower().Trim() == attribute.ParentKey.ToLower().Trim())
                {
                    //取得子特性集合中特性的GroupKey为本组下的特性
                    if (key.ToLower().Trim() == attribute.GroupKey.ToLower().Trim() || (Key.ToLower().Trim() == "" && (attribute.GroupKey == null || attribute.GroupKey.ToLower().Trim() == "")))
                    {
                        //如果字典中存在对应特性的菜单项，则把此菜单项添加到该分组中
                        if (paramMapping.ContainsKey(attribute) && paramMapping[attribute] != null)
                        {
                            IMenuStripItem item = paramMapping[attribute];
                            Items.Add(attribute.Key, item);
                        }
                    }
                }
            }
            Sort(false);
        }

        /// <summary>
        ///生成菜单组
        /// </summary>
        /// <param name="haveMany">该组别所在的菜单面板是否包含多个分组。
        /// 存在多个分组时，在上个组别后加一横线分隔</param>
        /// <param name="lastItem">是否是该组别所在的菜单面板上的最后一个组别</param>
        /// <param name="node">右击时选中的树节点</param>
        /// <returns></returns>
        public List<ToolStripItem> GetUI(bool haveMany, ToolStripItem lastItem, DbTreeNode node)
        {
            List<ToolStripItem> list = new List<ToolStripItem>();
            if (Items.Count < 1) return list;

            if (!string.IsNullOrEmpty(Key) && haveMany && !(lastItem is ToolStripSeparator))
            {
                ToolStripSeparator uiLine = new ToolStripSeparator();
                list.Add(uiLine);
            }
            foreach (string itemKey in Items.Keys)
            {
                IMenuStripItem item = Items[itemKey];
                if (item.Visible(node) != true) continue;
                ToolStripMenuItem uiItem = item.GetUI(node);
                if (uiItem != null) list.Add(uiItem);
            }
            return list;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="flag">为True时表示排序码小的排在前面</param>
        private void Sort(bool flag)
        {
            List<KeyValuePair<string, IMenuStripItem>> list = new List<KeyValuePair<string, IMenuStripItem>>();
            foreach (var pair in Items)
                list.Add(pair);
            KeyValuePair<string, IMenuStripItem>[] array = list.ToArray();

            for (int j = 0; j < array.Length - 1; j++)
            {
                for (int k = j + 1; k < array.Length; k++)
                {
                    if ((array[j].Value.Order < array[k].Value.Order) == flag)
                    {
                        KeyValuePair<string, IMenuStripItem> temp = array[k];
                        array[k] = array[j];
                        array[j] = temp;
                    }
                }
            }
            Items.Clear();
            foreach (KeyValuePair<string, IMenuStripItem> pair in array)
            {
                Items.Add(pair.Key, pair.Value);
            }
        }
    }

    /// <summary>
    /// 菜单面板
    /// </summary>
    public class MenuStripPanel
    {
        #region 变量及属性
        private string parentKey = string.Empty;
        /// <summary>
        /// 菜单面板的父键
        /// </summary>
        public string ParentKey
        {
            get { return parentKey; }
            set { parentKey = value; }
        }
        //菜单面板的组别集合
        private List<MenuStripGroup> groupList = new List<MenuStripGroup>();
        #endregion

        /// <summary>
        /// 初始化面板
        /// </summary>
        /// <param name="childAttributes">菜单项下的所有子特性集合</param>
        /// <param name="paramMapping">特性与菜单项对应的字典</param>
        public void Initialize(List<MenuStripAttribute> childAttributes, Dictionary<MenuStripAttribute, IMenuStripItem> paramMapping)
        {
            groupList.Clear();
            foreach (MenuStripAttribute attribute in childAttributes)
            {
                if (groupList.Find(g => g.Key.ToLower().Trim() == attribute.GroupKey.ToLower().Trim()) == null)
                {
                    MenuStripGroup group = new MenuStripGroup
                    {
                        Key = attribute.GroupKey.Trim(),
                        Order = attribute.GroupOrder,
                        ParentKey = ParentKey.Trim()
                    };
                    group.Initialize(childAttributes, paramMapping);
                    groupList.Add(group);
                }
            }

            int index = 0;
            while (groupList.Count > index)
            {
                MenuStripGroup group = groupList[index];
                if (group != null && group.Items.Count < 1)
                    groupList.Remove(group);
                else index++;
            }
            Sort(false);
        }

        /// <summary>
        /// 生成菜单面板
        /// </summary>
        /// <param name="node">右击时选中的树节点</param>
        /// <returns></returns>
        public List<ToolStripItem> GetUI(DbTreeNode node)
        {
            List<ToolStripItem> list = new List<ToolStripItem>();

            bool haveMany = false;     //标识是否该Panel下只有一个分组
            ToolStripItem lastItem = null;
            foreach (MenuStripGroup group in groupList)
            {
                List<ToolStripItem> groupItems = group.GetUI(haveMany, lastItem, node);
                if (groupItems != null && groupItems.Count > 0)
                {
                    list.AddRange(groupItems);
                    haveMany = true;

                    lastItem = (groupItems != null) ? groupItems[groupItems.Count - 1] : null;
                }
            }
            return list;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="flag">为True时表示排序码小的排在前面</param>
        private void Sort(bool flag)
        {
            MenuStripGroup[] array = groupList.ToArray();

            for (int j = 0; j < array.Length - 1; j++)
            {
                for (int k = j + 1; k < array.Length; k++)
                {
                    if ((array[j].Order < array[k].Order) == flag)
                    {
                        MenuStripGroup temp = array[k];
                        array[k] = array[j];
                        array[j] = temp;
                    }
                }
            }
            groupList.Clear();
            groupList.AddRange(array);
        }
    }

}
