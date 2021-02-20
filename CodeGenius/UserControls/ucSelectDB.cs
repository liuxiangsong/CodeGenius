using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeGenius.Entity;
using CodeGenius.Frame.TreeNodeBase;

namespace CodeGenius.UserControls
{
    public partial class ucSelectDB : UserControl
    {
        public event EventHandler OnDBSelectedChange;

        /// <summary>
        /// 加載所有數據庫名
        /// </summary>
        public DataTable DBDataSource
        {
            set
            {
                cboDataBase.DataSource = value;
            }
        }

        /// <summary>
        /// 當前服務器
        /// </summary>
        public string CurrentServer
        {
            set
            {
                lblCurrentServer.Text += value;
            }
        }

        /// <summary>
        /// 选择的数据库名称
        /// </summary>
        public string SelectedDB
        {
            get
            {
                return cboDataBase.Text;
            }
            set
            {
                cboDataBase.Text = value;
            }
        }

        public ucSelectDB()
        {
            InitializeComponent();            
        }  

        private void cboDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.OnDBSelectedChange != null)
            {
                OnDBSelectedChange(sender, e);
            }
        }
    }
}
