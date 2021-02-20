using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.IO;
using LibraryGenius;
using System.Collections;
using System.Xml;
using System.Diagnostics;
using System.Net;
using System.Threading;

namespace AutoUpdate
{
    public partial class frmUpdate : Form
    {
        #region 变量
        readonly string localXmlPath = Path.Combine(Application.StartupPath, "UpdateList.xml");  //本地配置文件路径
        XmlHelper localXmlHelper = null;
        string mainAppName = string.Empty;      //应用程序的名称
        string serverUrl = string.Empty;        //服务器的URL
        string tempDirectory = Environment.GetEnvironmentVariable("Temp");    //保存下载文件的目录 
        #endregion

        #region 窗体初始化
        public frmUpdate()
        {
            InitializeComponent(); 
        }
        #endregion

        #region 窗体加载事件
        private void frmUpdate_Load(object sender, EventArgs e)
        {
            if (!NetworkUtil.IsConnectedInternet())
            {
                MessageBox.Show("网络连接异常！");
                this.Close();
                return;
            }

            if (!CheckLocalXmlFile())
            {
                Application.Exit();
            } 
        }
        #endregion

        #region 检查本地配置文件
        /// <summary>
        /// 检查本地配置文件
        /// </summary>
        /// <returns></returns>
        private bool CheckLocalXmlFile()
        {
            string serverXmlPath = string.Empty;    //服务器配置文件路径
            if (!File.Exists(localXmlPath))
            {
                MsgBox.ShowWarning("本地更新配置文件不存在！");
                return false;
            }
            try
            {
                localXmlHelper = new XmlHelper(localXmlPath);
                mainAppName = localXmlHelper.GetNodeInnerText("//EntryPoint");
                serverUrl = localXmlHelper.GetNodeInnerText("//Url");
                tempDirectory = Path.Combine(tempDirectory, "_" + localXmlHelper.GetNodeAttrbuteValue("//Application", "ID"));

                string localServerXmlPath = Path.Combine(tempDirectory, "UpdateList.xml");//服务器上的配置文件下载至本地的路径
                //把服务器上的配置文件下载至本地临时文件夹
                this.DownLoadFile(Path.Combine(serverUrl, "UpdateList.xml"), localServerXmlPath);

                //获取需要更新的文件
                Hashtable updateFileTable = this.GetUpdateList(localServerXmlPath);
                //将需要更新的文件名称添加到TreeList上
                this.AddNodesToTreeList(updateFileTable);
                btnInstall.Enabled = (this.treeList1.Nodes.Count > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }
        #endregion

        #region 取得需更新的文件列表
        /// <summary>
        /// 通过比较本地与服务器上的配置文件来取得需更新的文件
        /// </summary> 
        /// <param name="serverXmlPath">服务器配置文件所在路径</param>
        /// <returns></returns>
        public Hashtable GetUpdateList(string serverXmlPath)
        {
            if (!File.Exists(serverXmlPath))
            {
                return null;
            }
            
            Hashtable updateFileTable = new Hashtable();
            string filesNode = "AutoUpdater/Files";
            Dictionary<string, string> localFileDict = GetLocalFileDict(filesNode);

            XmlHelper serverXmlFiles = new XmlHelper(serverXmlPath);
            //设置更新说明
            this.memoDescription.Text=localXmlHelper.GetNodeInnerText("//Description");
            XmlNodeList serverNodeList = serverXmlFiles.GetNodeList(filesNode);
            string fileName, version = string.Empty;
            for (int index = 0; index < serverNodeList.Count; index++)
            {
                fileName = serverNodeList.Item(index).Attributes["Name"].Value.Trim();
                version = serverNodeList.Item(index).Attributes["Ver"].Value.Trim();
                //只有待更新列表中不存在该文件名时,才判断该文件是否需要更新
                if (!updateFileTable.ContainsKey(fileName))
                {
                    //如果本地配置文件中不包含该文件名,则添加该文件名至待更新列表中
                    //反之,则再比较该文件在本地配置文件与服务器上的版本号，
                    //若服务器上的版本号大于本地的则添加至待更新列表中
                    if (!localFileDict.ContainsKey(fileName))
                    {
                        updateFileTable.Add(fileName, version);
                    }
                    else if (TypeHelper.CompareOfVersion(version, localFileDict[fileName]) > 0)
                    {
                        updateFileTable.Add(fileName, version);
                    }
                }
            }
            return updateFileTable;
        }
        #endregion

        #region 下载更新文件至本地 
        #region 进度条设置
        void InitialProcessBar(int maximum)
        {
            if (this.InvokeRequired)
            {
                progressBar.Invoke((ThreadStart)(() =>
                {
                    progressBar.EditValue = 0;
                    progressBar.Properties.Maximum = maximum;
                }));
            }
            else
            {
                progressBar.EditValue = 0;
                progressBar.Properties.Maximum = maximum;
            }
        }

        void SetPosition(int current)
        {
            if (this.InvokeRequired)
            {
                progressBar.Invoke((ThreadStart)(() =>
                {
                    progressBar.EditValue = current;
                }));
            }
            else
            {
                progressBar.EditValue = current;
            }
        } 
        #endregion

        /// <summary>
        /// 将需要更新的文件下载至临时文件夹
        /// </summary>
        private void DownFilesToTempDir()
        {
            //关闭主程序
            ProcessHelper.KillProcess(mainAppName);

            WebClient wcClient = new WebClient();
            for (int i = 0; i < this.treeList1.Nodes.Count; i++)
            {
                this.treeList1.Nodes[i]["Flag"] = 1;    //1表示正在下载
                string fileName = this.treeList1.Nodes[i]["FileName"].ToString();
                string updateFileUrl = Path.Combine(serverUrl, fileName);
                long fileLength = 0;

                WebRequest webReq = WebRequest.Create(updateFileUrl);
                WebResponse webRes = webReq.GetResponse();
                fileLength = webRes.ContentLength;
                  
                this.InitialProcessBar((int)fileLength);

                try
                {
                    Stream srm = webRes.GetResponseStream();
                    StreamReader srmReader = new StreamReader(srm);
                    byte[] bufferbyte = new byte[fileLength];
                    int allByte = (int)bufferbyte.Length;
                    int startByte = 0;
                    while (fileLength > 0)
                    {
                        Application.DoEvents();
                        int downByte = srm.Read(bufferbyte, startByte, allByte);
                        if (downByte == 0) { break; };
                        startByte += downByte;
                        allByte -= downByte; 
                        SetPosition((int)progressBar.EditValue + downByte);
                        //float part = (float)startByte / 1024;
                        //float total = (float)bufferbyte.Length / 1024;
                        //int percent = Convert.ToInt32((part / total) * 100);
                    }
                    string tempPath = Path.Combine(tempDirectory, fileName);
                    FileStream fs = new FileStream(tempPath, FileMode.OpenOrCreate, FileAccess.Write);
                    fs.Write(bufferbyte, 0, bufferbyte.Length);
                    srm.Close();
                    srmReader.Close();
                    fs.Close();
                    this.treeList1.Nodes[i]["Flag"] = 2;    //2表示已下载完成
                }
                catch (WebException ex)
                {
                    MessageBox.Show("更新文件下载失败！" + ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.CopyFiles();
            //this.Cursor = Cursors.Default;
        }

        private void CopyFiles()
        {
            try
            {
                lblInfo.Invoke((ThreadStart)(() => { lblInfo.Text = "正在安装,请稍候..."; }));
                Application.DoEvents();
                FileHepler.CopyDirectory(tempDirectory, Directory.GetCurrentDirectory());
                Directory.Delete(tempDirectory, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 取得本地配置文件中的文件列表
        /// <summary>
        /// 取得本地配置文件中的文件列表
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GetLocalFileDict(string filesNode)
        {
            try
            {
                XmlHelper localXmlFiles = new XmlHelper(localXmlPath);
                XmlNodeList localNodeList = localXmlFiles.GetNodeList(filesNode);

                Dictionary<string, string> localFileDict = new Dictionary<string, string>();
                string fileName, version = string.Empty;
                for (int index = 0; index < localNodeList.Count; index++)
                {
                    fileName = localNodeList.Item(index).Attributes["Name"].Value.Trim();
                    version = localNodeList.Item(index).Attributes["Ver"].Value.Trim();
                    if (!localFileDict.ContainsKey(fileName))
                    {
                        localFileDict.Add(fileName, version);
                    }
                }
                return localFileDict;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region 从服务器上下载文件
        /// <summary>
        /// 从服务器上下载文件
        /// </summary>
        /// <param name="serverFilePath">服务器上的文件路径(含文件名)</param>
        /// <param name="localFilePath">下载到本地路径(含文件名)</param>
        private void DownLoadFile(string serverFilePath, string localFilePath)
        {
            FileHepler.CreateDirectory(localFilePath); //确保localFilePath所在的目录已存在
            try
            {
                WebRequest request = WebRequest.Create(serverFilePath);
                WebResponse response = request.GetResponse();
                if (response.ContentLength > 0)
                {
                    WebClient client = new WebClient();
                    client.DownloadFile(serverFilePath, localFilePath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 添加节点至TreeList上
        /// <summary>
        /// 添加节点至TreeList上
        /// </summary>
        /// <param name="updateFileTable"></param>
        private void AddNodesToTreeList(Hashtable updateFileTable)
        {
            if (updateFileTable == null || updateFileTable.Count < 1)
            {
                return;
            }
            btnInstall.Enabled = true;
            this.treeList1.BeginUnboundLoad();
            foreach (DictionaryEntry kv in updateFileTable)
            {
                this.treeList1.AppendNode(new object[] { kv.Key, kv.Value, 0 }, -1);
            }
            this.treeList1.EndUnboundLoad();
        }
        #endregion

        #region 安装按钮事件
        private void btnInstall_Click(object sender, EventArgs e)
        {
            this.SetControlsEnable(false);
            if (this.treeList1.Nodes.Count > 0)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("没有可用的更新!", "自动更新", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        #endregion

        #region 取消/完成按钮事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.ExitThread();
            Application.Exit();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            Process.Start(mainAppName);
            this.Close();
            Application.ExitThread();
            Application.Exit();
        }
        #endregion

        #region  设置各控件的可用性
        /// <summary>
        /// 设置各控件的可用性
        /// </summary>
        /// <param name="isFinish">为True时表时,表示已安装完,否则表示正在安装</param>
        private void SetControlsEnable(bool isFinish)
        {
            if (isFinish)
            {
                lblInfo.Visible = false;
                btnInstall.Visible = false;
                btnCancel.Visible = false;
                btnFinish.Visible = true;
                btnFinish.Location = btnCancel.Location; 
            }
            else
            {
                xtraTabControl1.SelectedTabPage = pageDetail;
                lblInfo.Visible = true;
                btnInstall.Enabled = false;
            }
        }
        #endregion

        #region 设置节点的图标
        /// <summary>
        /// 设置节点的图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList1_CustomDrawNodeImages(object sender, DevExpress.XtraTreeList.CustomDrawNodeImagesEventArgs e)
        {
            e.SelectImageIndex = Convert.ToInt16(e.Node.GetValue("Flag"));
        }
        #endregion

        #region backgroundWorker1
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.DownFilesToTempDir();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.SetControlsEnable(true);
        } 
        #endregion


    }
}
