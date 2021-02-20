using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using CodeGenius.DBSchema;
using System.IO;
using System.Threading;
using System.Drawing;
using LibraryGenius;
using CodeGenius.Frame.Attributes;
using CodeGenius.Frame.Interface; 

namespace CodeGenius.Component
{ 
    public class DbTreeNode : TreeNode
    { 
        public TreeNodeType nodeType=TreeNodeType.Undefined ;
        public DbTreeNode()
        {
            ResetTreeNode();
            BeforeExpandHandler += DbTreeNodeBeforeExpandHandler;
        }

        protected readonly ContextMenuStrip menuStrip = new ContextMenuStrip();
        //protected readonly MenuStripPanel menuStripPanel = new MenuStripPanel();
        //protected readonly MenuStripItemCollection collection = new MenuStripItemCollection();
        //protected readonly IgnoreHashtable sysArguments = new IgnoreHashtable();

        protected DataEngine dataEngine;
        protected DBObjectSchema currentObject; //当前表
        protected DBObjectSchema parentObject;  //当前数据库

        public DBObjectSchema CurrentObject
        {
            get
            {
                if (currentObject == null && Parent is DbTreeNode)
                    currentObject = ((DbTreeNode)Parent).CurrentObject;

                return currentObject;
            }
            set { currentObject = value; }
        }
        public DBObjectSchema ParentObject
        {
            get
            {
                if (parentObject != null) return parentObject;

                DbTreeNode parentNode = (DbTreeNode)Parent;
                while (parentNode != null && parentNode.CurrentObject != null && parentNode.CurrentObject == CurrentObject)
                {
                    parentNode = (DbTreeNode)Parent.Parent;
                    parentObject = parentNode.CurrentObject;
                }

                return parentObject;
            }
            set { parentObject = value; }
        }

        public DataEngine DataEngine
        {
            get
            {
                if (dataEngine == null && Parent is DbTreeNode)
                    dataEngine = ((DbTreeNode)Parent).DataEngine;

                return dataEngine;
            }
            set { dataEngine = value; }
        }

        /// <summary>
        /// 追溯 当前节点 和 所有父节点，查找 指定的 DbObjectSchema 节点对象 
        /// </summary>
        public T AscendDbObjectSchema<T>() where T : DBObjectSchema
        {
            DbTreeNode treeNode = AscendDbTreeNode<T>();
            return treeNode == null ? null : (T)treeNode.CurrentObject;
        }
        /// <summary>
        /// 追溯 当前节点 和 所有父节点，查找 指定的 DbObjectSchema 节点 
        /// </summary>
        public DbTreeNode AscendDbTreeNode<T>() where T : DBObjectSchema
        {
            DbTreeNode treeNode = this;

            while (treeNode != null)
            {
                if (treeNode.CurrentObject is T)
                    return treeNode;
                else
                    treeNode = treeNode.Parent as DbTreeNode;
            }

            return null;
        }

        public BeforeExpand BeforeExpandHandler { get; set; }

        //public ContextMenuStrip GetContextMenuStrip(IgnoreHashtable arguments)
        public ContextMenuStrip GetContextMenuStrip()
        {
            menuStrip.Items.Clear();

            //foreach (MenuStripAttribute attr in AssemblyHelper.listToolStripAssembly)
            //{
 
            //}
            //sysArguments.Clear();
            //sysArguments.AddRange(arguments);
            //sysArguments["TreeNode"] = this;
            //sysArguments["Trigger"] = this;
            //sysArguments["DataEngine"] = DataEngine;
            //return MenuStripItemBase.RefreshContextMenuStrip(menuStrip, collection, menuStripPanel, sysArguments);
            return MenuStripItemBase.RefreshContextMenuStrip(menuStrip, this);
        }

        //public static bool ActionMust(string key, IgnoreHashtable arguments)
        //{
        //    return (arguments != null && arguments["TreeNode"] is DbTreeNode);
        //}

        public void ResetTreeNode()
        {
            Nodes.Add(new TreeNode());
        }
        protected virtual object InitExpandTreeNodeData()
        {
            //Thread.Sleep(500);
            return null;
        }
        protected virtual void ExpandTreeNode(object parameters)
        {
        }

        protected virtual void DbTreeNodeBeforeExpandHandler(DbTreeNode parentnode)
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
                        Text = caption;
                        TreeView.BeginInvoke((ThreadStart)(() => MessageBox.Show(exp.Message, "错误")));
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
        public virtual void ExpandDbTreeNode()
        {
            DbTreeNodeBeforeExpandHandler(this);
        }


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
    }

    public delegate void BeforeExpand(DbTreeNode sender);
}
