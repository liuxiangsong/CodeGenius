using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 
using WeifenLuo.WinFormsUI.Docking; 
using System.IO; 

namespace CodeGenius
{
    public partial class ViewForm : DockContent
    {
        #region Variable
        public delegate void SetToolStripEnableEventHandler(bool isEnable);
        public static event SetToolStripEnableEventHandler OnSetToolStripEnable;

        public delegate void CloseOthersFormEventHandler();
        public static event CloseOthersFormEventHandler OnCloseOthersForm;

        private bool isDisplayBoth = true;      //Display GridControl and RichEditControl
        public bool IsDisplayBoth
        {
            set { isDisplayBoth = value; }
        }

        private string richEditValue;
        public string RichEditValue
        {
            set { richEditValue = value; }
        }

        private DataTable sourceTable;
        public DataTable SourceTable
        {
            set { sourceTable = value; }
        }

        private string sqlString=null;
        #endregion 

        #region FormLoad Event
        public ViewForm()
        {
            InitializeComponent();
            ////ASP3/XHTML","BAT","Boo","Coco","C++.NET","C#","HTML","Java","JavaScript","PHP","TeX","VBNET","XML","TSQL"
            //txtContent.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");
            //txtContent.Encoding = Encoding.Default; 

            txtContent.GotFocus += new EventHandler(FormGotFocus);
            txtContent.LostFocus += new EventHandler(FormLostFocus);
            GridView.GotFocus += new EventHandler(FormGotFocus);
            GridView.LostFocus += new EventHandler(FormLostFocus);
        }


        private void ViewForm_Load(object sender, EventArgs e)
        {
            //txtContent.ActiveTextAreaControl.SelectionManager.SelectionChanged += delegate { sqlString = txtContent.ActiveTextAreaControl.SelectionManager.SelectedText; };
            this.LoadData(); 
        }

        private void LoadData()
        {
            splitContainer1.Panel1Collapsed = !this.isDisplayBoth;
            txtContent.Text = this.richEditValue;
            GridView.DataSource = this.sourceTable;
        }
        #endregion

        #region 委托方法
        private void FormLostFocus(object sender, EventArgs e)
        {
            OnSetToolStripEnable(false);
        }

        private void FormGotFocus(object sender, EventArgs e)
        {
            OnSetToolStripEnable(true);
        }

        private void ExcuteSql()
        {
            DBHelper.SqlHelper.ExecuteNonQuery(sqlString);
        }

        private void SaveFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "All Files(*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filePath = sfd.FileName;
                string fileName = Path.GetFileName(filePath);
                if (File.Exists(filePath))
                {
                    //if (MessageBox.Show("The file " + fileName + " is Exists,do you want to replace it?",
                    //    "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)  return;
                }
                File.WriteAllText(sfd.FileName, this.txtContent.Text);
            }
        }
        #endregion

        #region Form Activated\Deactivate Event
        private void ViewForm_Deactivate(object sender, EventArgs e)
        {
            MainFormOld.OnExcuteSql -= new MainFormOld.ExcuteSqlEventHandler(this.ExcuteSql);
            MainFormOld.OnSaveFile -= new MainFormOld.SaveFileEventHandler(this.SaveFile);
        }

        private void ViewForm_Activated(object sender, EventArgs e)
        {
            MainFormOld.OnExcuteSql += new MainFormOld.ExcuteSqlEventHandler(ExcuteSql);
            MainFormOld.OnSaveFile += new MainFormOld.SaveFileEventHandler(this.SaveFile);
        } 
        #endregion

        #region 当前窗体的TabPage右击菜单事件
        private void cmsFormSave_Click(object sender, EventArgs e)
        {
            this.SaveFile();
        }

        private void cmsFormClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmsFormCloseOthers_Click(object sender, EventArgs e)
        {
            OnCloseOthersForm();
        }
        #endregion

    }
}
