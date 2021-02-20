using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;

using CodeGenius.Entity;
using CodeGenius.Frame.TreeNodeBase;
using LibraryGenius;

namespace CodeGenius
{
    public partial class MainFormDX : DevExpress.XtraEditors.XtraForm
    {
        public static readonly List<SqlDataSourceInfo> DataSourceInfoList = new List<SqlDataSourceInfo>();
        public static DBTree ucDBTree
        {
            get
            {
                return Instance.ucDBExplorer1.ucDBTree;
            }
        }

        #region 窗体初始化
        private static MainFormDX frm = null;
        public static MainFormDX Instance
        {
            get
            {
                if (frm == null || frm.IsDisposed)
                {
                    frm = new MainFormDX();
                }
                return frm;
            }
        }

        private MainFormDX()
        {
            InitializeComponent();
            this.InitDocument();
        }

        void InitDocument()
        {
            //不允许子窗体飘浮
            this.documentManager1.View.DocumentProperties.AllowFloat = false;
            this.documentManager1.View.DocumentProperties.UseFormIconAsDocumentImage = true;
        }
        #endregion

        #region 窗体加载
        private void MainFormDX_Load(object sender, EventArgs e)
        {
            this.Text += " V" + Application.ProductVersion;
        }
        #endregion

        #region 窗体右键菜单
        /// <summary>
        /// 窗体右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabbedView1_PopupMenuShowing(object sender, DevExpress.XtraBars.Docking2010.Views.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.Document != null)
                e.Menu.Insert(2, DevExpress.XtraBars.Docking2010.Views.BaseViewControllerCommand.CloseAll, tabbedView1);
            for (int i = 0; i < e.Menu.Items.Count; i++)
            {
                switch (e.Menu.Items[i].Caption)
                {
                    case "Close":
                        e.Menu.Items[i].Caption = "关闭(&C)";
                        e.Menu.Items[i].Shortcut = Shortcut.CtrlF4;
                        //e.Menu.Items[i].ShowHotKeyPrefix = true;
                        break;
                    case "Close All But This":
                        e.Menu.Items[i].Caption = "除此之外全部关闭(&E)";
                        break;
                    case "Close All Documents":
                        e.Menu.Items[i].Caption = "全部关闭(&A)";
                        break;
                    case "Float":
                        e.Menu.Items[i].Visible = false;
                        break;
                    case "New Horizontal Tab Group":
                        e.Menu.Items[i].Caption = "新建水平选项卡组(&Z)";
                        break;
                    case "New Vertical Tab Group":
                        e.Menu.Items[i].Caption = "新建垂直选项卡组(&V)";
                        break;
                    case "Move to Previous Tab Group":
                        e.Menu.Items[i].Caption = "移动到上一个选项卡组(&R)";
                        break;
                    case "Move to Next Tab Group":
                        e.Menu.Items[i].Caption = "移动到下一个选项卡组(&X)";
                        break;

                }
            }
        }
        #endregion

        #region NotifyIcon相关事件
        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            this.notifyPopupMenu.ShowPopup(Cursor.Position);
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.notifyPopupMenu.ItemLinks[0].Caption = "显示主窗体(&S)";
            }
            else
            {
                this.notifyPopupMenu.ItemLinks[0].Caption = "隐藏主窗体(&H)";
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon1.Visible = false;
        }

        //如果不想让程序在任务栏中显示，请把窗体的属性ShowInTaskbar设置为false
        //可以为NotifyIcon加一个ContextMenuStrip右键菜单
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
        }

        #region NotifyIcon右键菜单
        private void barbtnMainForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Visible = (this.WindowState == FormWindowState.Minimized);
            this.notifyIcon1.Visible = !this.Visible;
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void barbtnAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmAbout fr = new frmAbout();
            //fr.StartPosition = FormStartPosition.CenterScreen;
            //fr.ShowDialog();
        }

        private void barbtnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #endregion

        #region  关闭所有已打开的窗体
        /// <summary>
        /// 关闭所有已打开的窗体
        /// </summary>
        void CloseAllForm()
        {
            foreach (Form fr in this.MdiChildren)
            {
                fr.Close();
            }
        }
        #endregion

        #region 【视图】 菜单相关方法
        private void biDBExplorer_ItemClick(object sender, ItemClickEventArgs e)
        {
            dockDBExplorer.Show();
        }

        private void biTemplateManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            dockTemplateManager.Show();
        }
        #endregion

        #region 【工具】 菜单相关方法
        private void biEncryption_ItemClick(object sender, ItemClickEventArgs e)
        {
            Encryption fr = new Encryption();
            fr.Show();
        }

        private void biGenerateDBDocument_ItemClick(object sender, ItemClickEventArgs e)
        {
            DbTreeNode selectedNode = MainFormDX.ucDBTree.SelectedNode as DbTreeNode;
            if (selectedNode == null)
            {
                MsgBox.ShowInformation(MessageInfo.MsgInfo300);
                return;
            }
            GenerateDBDoc fr = new GenerateDBDoc();
            fr.MdiParent = this;
            fr.Show();
        }

        private void biStringBuilderTool_ItemClick(object sender, ItemClickEventArgs e)
        {
            StringBuilderTool fr = new StringBuilderTool();
            fr.MdiParent = this;
            fr.Show();
        }

        private void biEncodeConvert_ItemClick(object sender, ItemClickEventArgs e)
        {
            EncodeConvert fr = new EncodeConvert();
            fr.MdiParent = this;
            fr.Show();
        }

        private void biBatchCodeGenerator_ItemClick(object sender, ItemClickEventArgs e)
        {
            DbTreeNode selectedNode = MainFormDX.ucDBTree.SelectedNode as DbTreeNode;
            if (selectedNode == null)
            {
                MsgBox.ShowInformation(MessageInfo.MsgInfo300);
                return;
            }
            BatchCodeGenerator fr = new BatchCodeGenerator();
            fr.MdiParent = this;
            fr.Show();
        }

        private void biTableProperty_ItemClick(object sender, ItemClickEventArgs e)
        {
            DbTreeNode selectedNode = MainFormDX.ucDBTree.SelectedNode as DbTreeNode;
            if (selectedNode == null)
            {
                MsgBox.ShowInformation(MessageInfo.MsgInfo300);
                return;
            }
            frmTableProperty fr = frmTableProperty.Instance;
            fr.MdiParent = this;
            fr.Show();
        }

        #endregion






    }
}