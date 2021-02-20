using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing;
using LibraryGenius;
using CodeGenius.Frame.Attributes;
using CodeGenius.Frame.Interface;

using CodeGenius.Entity;

namespace CodeGenius.Frame.TreeNodeBase
{
    /// <summary>
    /// 节点展开委托类型
    /// </summary>
    /// <param name="sender"></param>
    public delegate void BeforeExpandEventHandler(DbTreeNode sender);

    public class DbTreeNode : TreeNode
    {
        #region 变量及属性定义
        /// <summary>
        /// 节点展开委托类型对象
        /// </summary>
        public BeforeExpandEventHandler OnBeforeExpand { get; set; }

        /// <summary>
        /// 节点类型
        /// </summary>
        public TreeNodeType nodeType = TreeNodeType.Undefined;

        protected static readonly ContextMenuStrip menuStrip = new ContextMenuStrip();

        #region 节点的图片集合(ImageList)及其初始化
        protected static readonly ImageList listImage = new ImageList();
        public static ImageList ListImage
        {
            get
            {
                if (DbTreeNode.listImage.Images.Count <= 0)
                {
                    listImage.ColorDepth = ColorDepth.Depth32Bit;
                    listImage.ImageSize = new Size(16, 16);
                    listImage.TransparentColor = Color.Transparent;
                    InitializeImages();
                }
                return DbTreeNode.listImage;
            }
        }
        public static void InitializeImages()
        {
            string programDirPath = AppDomain.CurrentDomain.BaseDirectory + "/Images/TreeNodeImages/";
            DirectoryInfo dir = new DirectoryInfo(programDirPath);
            if (!dir.Exists) dir.Create();

            FileInfo[] files = dir.GetFiles("*.png");
            foreach (FileInfo file in files)
            {
                try
                {
                    System.Drawing.Bitmap image = new Bitmap(file.FullName);
                    DbTreeNode.listImage.Images.Add(file.Name.Substring(0, file.Name.Length - 4), image);
                }
                catch (Exception)
                {
                }
            }
        }
        #endregion

        protected DataEngineSchema dataEngineSchema;
        protected DBObjectSchema currentObjectSchema;
        protected DBObjectSchema parentObjectSchema;
        /// <summary>
        /// 当前节点实体类对象
        /// </summary>
        public DBObjectSchema CurrentObjectSchema
        {
            get
            {
                if (currentObjectSchema == null && Parent is DbTreeNode)
                    currentObjectSchema = ((DbTreeNode)Parent).CurrentObjectSchema;
                return currentObjectSchema;
            }
            set { currentObjectSchema = value; }
        }

        /// <summary>
        /// 当前节点的父节点的实体类对象
        /// </summary>
        public DBObjectSchema ParentObjectSchema
        {
            get
            {
                if (parentObjectSchema != null) return parentObjectSchema;
                DbTreeNode parentNode = (DbTreeNode)Parent;
                while (parentNode != null && parentNode.CurrentObjectSchema != null && parentNode.CurrentObjectSchema == CurrentObjectSchema)
                {
                    parentNode = (DbTreeNode)Parent.Parent;
                    parentObjectSchema = parentNode.CurrentObjectSchema;
                }
                return parentObjectSchema;
            }
            set { parentObjectSchema = value; }
        }

        /// <summary>
        /// 当前节点的DataEngineSchema对象
        /// （服务器节点下的所有节点的DataEngineSchema对象都一样）
        /// </summary>
        public DataEngineSchema DataEngineSchema
        {
            get
            {
                if (dataEngineSchema == null && Parent is DbTreeNode)
                    dataEngineSchema = ((DbTreeNode)Parent).DataEngineSchema;
                return dataEngineSchema;
            }
            set { dataEngineSchema = value; }
        } 
        #endregion

        public DbTreeNode()
        {
            ResetTreeNode();
            OnBeforeExpand += OnBeforeExpandHandler;
        }
         
        #region 追溯当前节点和所有父节点，返回其节点的DbObjectSchema为指定类型的DbObjectSchema
        /// <summary>
        /// 追溯 当前节点 和 所有父节点，查找 指定的 DbObjectSchema 节点对象 
        /// </summary>
        public T AscendDbObjectSchema<T>() where T : DBObjectSchema
        {
            DbTreeNode treeNode = AscendDbTreeNode<T>();
            return treeNode == null ? null : (T)treeNode.CurrentObjectSchema;
        }
        #endregion

        #region 追溯当前节点和所有父节点，返回其节点的DbObjectSchema为指定类型的节点
        /// <summary>
        /// 追溯 当前节点 和 所有父节点，查找 指定的 DbObjectSchema 节点 
        /// </summary>
        public DbTreeNode AscendDbTreeNode<T>() where T : DBObjectSchema
        {
            DbTreeNode treeNode = this;
            while (treeNode != null)
            {
                if (treeNode.CurrentObjectSchema is T)
                    return treeNode;
                else
                    treeNode = treeNode.Parent as DbTreeNode;
            }
            return null;
        }
        #endregion

        #region 取得右击菜单
        /// <summary>
        /// 取得右击菜单
        /// </summary>
        /// <returns></returns>
        public ContextMenuStrip GetContextMenuStrip()
        {
            menuStrip.Items.Clear();
            return MenuStripItemBase.RefreshContextMenuStrip(menuStrip, this);
        }
        #endregion

        #region 添加节点
        /// <summary>
        /// 添加节点
        /// </summary>
        public void ResetTreeNode()
        {
            Nodes.Add(new TreeNode());
        }
        #endregion

        #region 初始化节点展开时该节点的相关数据
        /// <summary>
        /// 初始化节点展开时该节点的相关数据
        /// </summary>
        /// <returns></returns>
        protected virtual object InitExpandTreeNodeData()
        {
            //Thread.Sleep(500);
            return null;
        }
        #endregion

        #region 节点展开虚方法
        /// <summary>
        /// 节点展开
        /// </summary>
        /// <param name="parameters"></param>
        protected virtual void ExpandTreeNode(object parameters)
        {
        }
        #endregion

        #region 节点展开委托方法
        /// <summary>
        /// 节点展开委托方法
        /// </summary>
        /// <param name="parentnode"></param>
        protected virtual void OnBeforeExpandHandler(DbTreeNode parentnode)
        {
            if (Nodes.Count == 1 && !(Nodes[0] is DbTreeNode) && Nodes[0].Text == string.Empty)
            {
                Nodes.Clear();
                string caption = Text;

                Text = string.Format("{0}(正在展开...)", caption);
                ThreadPool.QueueUserWorkItem(p =>
                {
                    object parameters = null;
                    bool initSucceed = false;

                    try
                    {
                        parameters = InitExpandTreeNodeData();
                        initSucceed = true;
                    }
                    catch (Exception exp)
                    {
                        TreeView.BeginInvoke((ThreadStart)(() => MessageBox.Show(exp.Message, "错误")));
                        Text = caption;
                    }

                    if (initSucceed)
                    {
                        TreeView.BeginInvoke(
                            (ThreadStart)(() =>
                            {
                                try
                                {
                                    TreeView.SuspendLayout();
                                    ExpandTreeNode(parameters);
                                }
                                catch (Exception exp)
                                {
                                    TreeView.BeginInvoke((ThreadStart)(() => MessageBox.Show(exp.Message, "错误")));
                                }
                                finally
                                {
                                    Text = caption;
                                    Expand();
                                    TreeView.ResumeLayout();
                                }
                            })
                        );
                    }
                });

            }
        }
        #endregion

        #region 展开当前节点
        /// <summary>
        /// 展开当前节点
        /// </summary>
        public virtual void ExpandCurrentDbTreeNode()
        {
            OnBeforeExpandHandler(this);
        }
        #endregion

    }
}
