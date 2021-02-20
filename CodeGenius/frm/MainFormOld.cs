using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;
using System.Collections;
using System.Threading;
using CodeGenius.Frame.TreeNodeBase;
using LibraryGenius;
using CodeGenius.Entity; 

namespace CodeGenius
{

    public partial class MainFormOld : Form
    {
        #region
        public Mutex mutex;
        public delegate void ExcuteSqlEventHandler();
        public static event ExcuteSqlEventHandler OnExcuteSql;

        public delegate ArrayList GetCurrentDBEventHandler();
        public static event GetCurrentDBEventHandler OnGetCurrent;

        public delegate void SaveFileEventHandler();
        public static event SaveFileEventHandler OnSaveFile;
        #endregion

        public  DockPanel DockPanel1
        {
            get { return dockPanel1; }
        }
        #region FormLoad Event
       
         #region Singleton Pattern
        private static MainFormOld frmMainFormOld = null;
        public static MainFormOld GetInstance()
        {
            if (frmMainFormOld == null || frmMainFormOld.IsDisposed)
            {
                frmMainFormOld = new MainFormOld();
            }
            return frmMainFormOld;
        }
         
        


        private MainFormOld()
        { 
            InitializeComponent();
            //this.skinEngine1.SkinFile = Application.StartupPath + @"\skins\Skins\Office2007\Office2007.ssk"; 
            this.dockPanel1.DockLeftPortion = 200;
            //DataBase.OnShowForm += new DataBase.ShowFormEventHandler(this.ShowForm); 
            ViewForm.OnSetToolStripEnable += new ViewForm.SetToolStripEnableEventHandler(this.SetToolStripEnable);
            ViewForm.OnCloseOthersForm += new ViewForm.CloseOthersFormEventHandler(this.CloseOthersForm);

            mutex = new Mutex(false, "SINGLE_INSTANCE_MUTEX_CodeGenius");
            if (!mutex.WaitOne(1, false))
            {
                mutex.Close();
                mutex = null;
            }
        }
         #endregion
        private void frMainForm_Load(object sender, EventArgs e)
        {
            this.Text += " V" + Application.ProductVersion;
            dockPanel1.AllowEndUserDocking = false; 
            //DataBase.GetInstance().Show(this.dockPanel1, DockState.DockLeft);
            //frmDBExplorer.GetInstance().Show(this.dockPanel1, DockState.DockLeft);
            //SqlDBConnection.GetInstance().ShowDialog();   
        }
        #endregion 


        #region 委托方法
        private void ShowForm(DockContent fr)
        {
            fr.Show(this.dockPanel1);            
        }

        private void SetToolStripEnable(bool isEnable)
        {
            tscboDBList.Enabled = isEnable;
            tsSQLExcute.Enabled = isEnable;
            tsSave.Enabled = isEnable;
        }

        private void CloseOthersForm()
        {
            foreach (Form fr in this.MdiChildren)
            {
                if (fr != this.ActiveMdiChild)
                {
                    fr.Close();
                }
            }
        }
        #endregion

        #region 菜单栏事件
        #region File
        private void tsSave_Click(object sender, EventArgs e)
        {
            if (OnSaveFile != null)
            {
                OnSaveFile();
            } 
        }
        #endregion

        #region View
        private void tsObjectExplorer_Click(object sender, EventArgs e)
        {
            //frmDBExplorer.GetInstance().Show(this.dockPanel1, DockState.DockLeft);
        }

        private void tsTemplateManage_Click(object sender, EventArgs e)
        {
            TemplateManage.GetInstance().Show(this.dockPanel1, DockState.DockLeft);
        }
        #endregion

        #region Tool
        #region Encryption
        private void tsEncryption_Click(object sender, EventArgs e)
        {
            Encryption fr = new Encryption();
            fr.ShowDialog(this.dockPanel1);
        }
        #endregion

        #region Generate DataBase Document
        private void tsGenerateDBDocument_Click(object sender, EventArgs e)
        {
            if (MainFormDX.ucDBTree == null)
            {
                MsgBox.ShowInformation("Please select a database server");
                return;
            }
            DbTreeNode selectedNode = MainFormDX.ucDBTree.SelectedNode as DbTreeNode;
            if (selectedNode == null) return;
            SqlDataEngineSchema engineSchema = selectedNode.AscendDbObjectSchema<SqlDataEngineSchema>();
            
            GenerateDBDoc fr =new GenerateDBDoc() ;
            //ArrayList tempAL = OnGetCurrent();
            //if (tempAL == null)
            //{
            //    MessageBox.Show("Please select a database server", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //fr.al = tempAL;
            //fr.EngineSchema = engineSchema;
            fr.ShowDialog(this.dockPanel1);
        }
        #endregion

        #region 单表代码生成器
        private void tsSingleCodeGenerator_Click(object sender, EventArgs e)
        {
            SingleCodeGenerator fr =SingleCodeGenerator.GetInstance();
            ArrayList tempAL = OnGetCurrent();
            if (tempAL == null)
            {
                MessageBox.Show("Please select a database server", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            fr.al = tempAL;
            fr.Show(this.dockPanel1);
            fr.Activate();
        }
        #endregion

        private void tsTemplateCodeGenerator_Click(object sender, EventArgs e)
        {
            TemplateCodeGenerator fr = TemplateCodeGenerator.GetInstance();
            ArrayList tempAL = OnGetCurrent();
            if (tempAL == null)
            {
                MessageBox.Show("Please select a database server", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            fr.al = tempAL;
            fr.ShowDialog(this.dockPanel1);
        }

        private void tsStringBuilderTool_Click(object sender, EventArgs e)
        {
            StringBuilderTool fr = new StringBuilderTool();
            fr.Show(this.dockPanel1);
        }

        #endregion

        #endregion

        #region 工具栏事件
        private void tsbtnExcute_Click(object sender, EventArgs e)
        {
            OnExcuteSql();
        }
        #endregion

        #region NotifyIcon相关事件
        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        //如果不想让程序在任务栏中显示，请把窗体的属性ShowInTaskbar设置为false
        //可以为NotifyIcon加一个ContextMenuStrip右键菜单
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(1000);
            }
        }
        #endregion

        #region Form Closed Event        
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.notifyIcon.Visible = false;
            this.notifyIcon.Dispose();
        }
        #endregion

        private void tsCodeGenerator_Click(object sender, EventArgs e)
        {
             DbTreeNode selectedNode = MainFormDX.ucDBTree.SelectedNode as DbTreeNode;
             if (selectedNode == null)
             {
                 MessageBox.Show("Please select a database server", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return;
             }
             BatchCodeGenerator fr = new BatchCodeGenerator();
             fr.ShowDialog(this.dockPanel1);
        }


    }
}
