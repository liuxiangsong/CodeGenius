using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

using System.Data.SqlClient;
using CodeGenius.Entity;
using MsSqlTree;
using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Frame;
using System.IO;
using LibraryGenius; 

namespace CodeGenius
{
    public partial class SqlDBConnection : Form
    {
        #region 变量、属性
        private readonly string binPath = Application.StartupPath + @"\SqlStudio.bin";
        private string m_BeforeServerName;          //记录cboServerName的TextChanged触发前选择的项的值

        private SqlDataEngineSchema currentDataEngine;
        public SqlDataEngineSchema CurrentDataEngine
        {
            get
            {
                if (currentDataEngine != null) return currentDataEngine;

                currentDataEngine = new SqlDataEngineSchema();
                currentDataEngine.ConnectionString = CreateConnectionString();

                currentDataEngine.SqlDataSourceInfo.DataSource = cboServerName.Text;
                currentDataEngine.SqlDataSourceInfo.IntegratedSecurity = Equals(LoginIdentity.Windows, ((CaptionValuePair)cboAuthentication.SelectedItem).Value);
                currentDataEngine.SqlDataSourceInfo.UserID = txtLoginName.Text;
                if (chkSavePwd.Checked)
                    currentDataEngine.SqlDataSourceInfo.Password = txtPassword.Text;
                DataRow dr = SqlScriptHelper.GetDataEngineInfo(currentDataEngine.ConnectionString);
                currentDataEngine.SqlDataSourceInfo.Version = TypeHelper.ToString(dr["ProductVersion"]);
                currentDataEngine.SqlDataSourceInfo.ProductLevel = TypeHelper.ToString(dr["ProductLevel"]);

                currentDataEngine.DataBases = SqlSchemaHelper.ReadDataBaseSchema(currentDataEngine.ConnectionString);
                return currentDataEngine;
            }
        }
        private string CreateConnectionString()
        {
            if (cboAuthentication.SelectedItem == null || !(cboAuthentication.SelectedItem is CaptionValuePair))
                return string.Empty;
            SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder
            {
                PersistSecurityInfo = true,
                DataSource = cboServerName.Text.Trim(),
                InitialCatalog = "master",
                IntegratedSecurity = Equals(LoginIdentity.Windows, ((CaptionValuePair)cboAuthentication.SelectedItem).Value)
            };
            if (!connBuilder.IntegratedSecurity)
            {
                connBuilder.UserID = txtLoginName.Text;
                connBuilder.Password = txtPassword.Text;
            }
            return connBuilder.ConnectionString;
        }
        #endregion

        #region Singleton Pattern
        private static SqlDBConnection frmDBConnection = null;
        public static SqlDBConnection GetInstance()
        {
            if (frmDBConnection == null || frmDBConnection.IsDisposed)
            {
                frmDBConnection = new SqlDBConnection();
            }
            return frmDBConnection;
        }

        private SqlDBConnection()
        {
            InitializeComponent();
        }
        #endregion

        #region  Form Load Event
        private void SqlDBConnection_Load(object sender, EventArgs e)
        {
            this.InitControls();
            this.ReadRecord();
            if (string.IsNullOrEmpty(cboServerName.Text.Trim())) this.cboServerName.Text = "(local)";
            this.cboServerType.SelectedIndex = 1;
        }

        #region InitControls
        private void InitControls()
        {
            if (cboAuthentication.Items.Count > 0) return;
            cboAuthentication.Items.Add(new CaptionValuePair("Windows Authentication", LoginIdentity.Windows));
            cboAuthentication.Items.Add(new CaptionValuePair("SQL Server Authentication", LoginIdentity.SQLServer));
        }
        #endregion
        #endregion

        #region cboServerName Event
        private void cboServerName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboServerName.SelectedIndex == cboServerName.Items.Count - 1)
            {
                BrowseSQLServer.GetInstance().ShowDialog(this);

                if (this.Tag == null)
                {
                    BeginInvoke(new MethodInvoker(() => { cboServerName.Text = m_BeforeServerName; }));
                }
                else
                {
                    BeginInvoke(new MethodInvoker(() => { cboServerName.Text = this.Tag.ToString(); this.Tag = null; }));
                }
            }
            else
            {
                SqlDataSourceInfo dataSourceInfo = MainFormDX.DataSourceInfoList.Find(d => d.DataSource == cboServerName.Text);
                this.SetControlsValueByRecord(dataSourceInfo);
            }
        }

        private void cboServerName_TextChanged(object sender, EventArgs e)
        {
            int count = cboServerName.Items.Count;
            if (count > 0 && cboServerName.Text != cboServerName.Items[count - 1].ToString())
            {
                m_BeforeServerName = cboServerName.Text;
            }
        }
        #endregion

        #region Authentication Type Change Event
        private void cboAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool enableFlag = Convert.ToBoolean(cboAuthentication.SelectedIndex);
            txtLoginName.Enabled = enableFlag;
            txtPassword.Enabled = enableFlag;
            chkSavePwd.Enabled = enableFlag;

            if (cboAuthentication.SelectedIndex == 0)
            {
                chkSavePwd.Checked = false;
                txtLoginName.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                txtPassword.Text = string.Empty;
            }
        }
        #endregion

        #region Connection Event
        private void btnConnection_Click(object sender, EventArgs e)
        {
            currentDataEngine = null;

            if (!this.TryConnect(this.CreateConnectionString())) return;

            this.WriteRecord();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool TryConnect(string connectionString)
        {
            DBHelper.SqlHelper.SqlConnectionString = connectionString;
            try
            {
                DBHelper.SqlHelper.ExecuteNonQuery("select 1");
            }
            catch (Exception ex)
            {
                MsgBox.ShowError(ex.Message);
                return false;
            }
            return true;
        }
        #endregion

        #region Cancel Event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion
 
        #region 读、写历史记录
        /// <summary>
        /// 读取记录
        /// </summary>
        private void ReadRecord()
        {
            this.cboServerName.Items.Clear();
            try
            {
                if (MainFormDX.DataSourceInfoList.Count < 1)
                {
                    if (File.Exists(binPath) == false)
                    {
                        cboAuthentication.SelectedIndex = 0;
                        return;
                    }
                    List<SqlDataSourceInfo> dataSourceInfoList = new List<SqlDataSourceInfo>();
                    string decryptString =DESEncrypt.Decrypt(File.ReadAllText(binPath));
                    //dataEngineList = SerializationHelper.BinaryDeserialize<List<SqlDataEngineSchema>>(Encoding.Default.GetBytes(decryptString));
                    dataSourceInfoList = SerializationHelper.XmlDeserialize<List<SqlDataSourceInfo>>(Encoding.Default.GetBytes(decryptString));
                    MainFormDX.DataSourceInfoList.AddRange(dataSourceInfoList);
                }
                this.cboServerName.Items.AddRange(MainFormDX.DataSourceInfoList.Select(d => d.DataSource).ToArray());
                this.cboServerName.Items.Add("<Browse Others>");

                if (MainFormDX.DataSourceInfoList.Count > 0)
                    this.SetControlsValueByRecord(MainFormDX.DataSourceInfoList[0]);
                else
                    this.cboAuthentication.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                this.cboAuthentication.SelectedIndex = 0;
                File.Delete(binPath);
                if (ex.GetType() != typeof(System.Runtime.Serialization.SerializationException) && ex.Source != "Encryption")
                    MsgBox.ShowError(ex.Message);
            }
        }

        private void WriteRecord()
        {
            try
            {
                if (MainFormDX.DataSourceInfoList.Count < 1)
                {
                    MainFormDX.DataSourceInfoList.Add(this.CurrentDataEngine.SqlDataSourceInfo);
                }
                else
                {
                    MainFormDX.DataSourceInfoList.RemoveAll(d => d.DataSource == cboServerName.Text.Trim());
                    MainFormDX.DataSourceInfoList.Insert(0, this.CurrentDataEngine.SqlDataSourceInfo);
                }
                //byte[] bytes = SerializationHelper.BinarySerialize<List<SqlDataEngineSchema>>(MainFormDX.DataEngineList);
                byte[] bytes = SerializationHelper.XmlSerialize<List<SqlDataSourceInfo>>(MainFormDX.DataSourceInfoList);
                string encryptString = Encoding.Default.GetString(bytes);
                File.WriteAllText(binPath, DESEncrypt.Encrypt(encryptString));
            }
            catch (Exception ex)
            {
                MsgBox.ShowError(ex.Message);
            }

        }

        /// <summary>
        /// 根据保存的历史记录给控件赋值
        /// </summary>
        /// <param name="dataSourceInfo"></param>
        private void SetControlsValueByRecord(SqlDataSourceInfo dataSourceInfo)
        {
            if (dataSourceInfo == null) return;
            cboServerName.Text = dataSourceInfo.DataSource.Trim();
            cboAuthentication.SelectedIndex = (dataSourceInfo.IntegratedSecurity) ? 0 : 1;
            if (dataSourceInfo.IntegratedSecurity == false)
            {
                txtLoginName.Text = dataSourceInfo.UserID;
                txtPassword.Text = dataSourceInfo.Password;
                if (txtPassword.Text.Length > 0)
                    chkSavePwd.Checked = true;
            }
        }
        #endregion
    }


    public enum LoginIdentity
    {
        Windows,
        SQLServer,
    }
}
