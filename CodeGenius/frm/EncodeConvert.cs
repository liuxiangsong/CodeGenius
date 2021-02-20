using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibraryGenius;
using System.IO;

namespace CodeGenius
{

    public partial class EncodeConvert : Form
    {
        public EncodeConvert()
        {
            InitializeComponent();
        }

        private void EncodeConvert_Load(object sender, EventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            MyTreeNode newNode = new MyTreeNode("桌面", desktopPath, 4, "desktop");
            newNode.Nodes.Add("");
            tv.Nodes.Add(newNode);
            InitDrives();
        }

        #region 加载本地磁盘
        /// <summary>
        /// 加载本地磁盘
        /// </summary>
        private void InitDrives()
        {
            tv.BeginUpdate();
            try
            {
                foreach (DriveInfo di in DriveInfo.GetDrives())
                {
                    if (di.DriveType == DriveType.Fixed)
                    {
                        string diskName = string.IsNullOrEmpty(di.VolumeLabel) ? "本地磁盘" : di.VolumeLabel;
                        diskName = string.Format("{0}({1})", diskName, di.Name.Trim('\\'));
                        MyTreeNode newNode = new MyTreeNode(diskName, di.Name, 3, "drive");
                        if (FileHepler.ExistsFileOrDir(di.Name))
                            newNode.Nodes.Add("");
                        tv.Nodes.Add(newNode);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            tv.EndUpdate();
        }
        #endregion

        #region 添加子文件夹节点及文件节点
        /// <summary>
        /// 添加子文件夹节点及文件节点
        /// </summary>
        /// <param name="myNode"></param>
        private void AppendSubDirsOrFiles(MyTreeNode myNode)
        {
            if (myNode == null) return;
            DirectoryInfo directoryInfo = new DirectoryInfo(myNode.path);
            tv.BeginUpdate();
            foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
            {
                MyTreeNode newNode = new MyTreeNode(dir.Name, dir.FullName, 0, dir);
                if (FileHepler.ExistsFileOrDir(dir.FullName))
                    newNode.Nodes.Add("");
                myNode.Nodes.Add(newNode);
            }

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                MyTreeNode newNode = new MyTreeNode(file.Name, file.FullName, 2, file);
                myNode.Nodes.Add(newNode);
            }
            tv.EndUpdate();
        }
        #endregion

        #region TreeView相关事件
        private void tv_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Node.Nodes[0].Text))
            {
                e.Node.Nodes.Clear();
                AppendSubDirsOrFiles(e.Node as MyTreeNode);
            }
            if (e.Node.Tag != null && e.Node.Tag.GetType() == typeof(DirectoryInfo))
                e.Node.ImageIndex = 1;
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //设置treeView的选中图标为本节点的图标
            ((TreeView)sender).SelectedImageIndex = e.Node.ImageIndex;
        }

        private void tv_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Tag.GetType() == typeof(DirectoryInfo))
                e.Node.ImageIndex = 0;
        }

        private void tv_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag.GetType() == typeof(FileInfo))
            {
                FileInfo file = (FileInfo)e.Node.Tag;
                rtxContent.Text = FileHepler.ReadText(file.FullName, EncodingUtil.GetFileEncode(file.FullName));
                rtxContent.Tag = file;
                tslblFileName.Text = file.Name;
                tslblFileName.ToolTipText = file.FullName;
            }
        }

        #endregion

        #region 根据编码读取文件文本内容
        /// <summary>
        /// 转化编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsiEncodingClick(object sender, EventArgs e)
        {
            if (rtxContent.Tag == null || rtxContent.Tag.GetType() != typeof(FileInfo))
            {
                MessageBox.Show("系统提示:rtxContent.Tag为null。\r\n请确保文本内容是读取自指定文件！");
                return;
            }
            string currentFilePath = ((FileInfo)rtxContent.Tag).FullName;

            ToolStripMenuItem tsi = (ToolStripMenuItem)sender;
            Encoding encoding = Encoding.GetEncoding(TypeHelper.ToString(tsi.Tag));
            rtxContent.Text = FileHepler.ReadText(currentFilePath, encoding);
        }
        #endregion
 
        #region 保存、另存为
        private void stiSave_Click(object sender, EventArgs e)
        {
            if (rtxContent.Tag == null || rtxContent.Tag.GetType() != typeof(FileInfo))
            {
                MessageBox.Show("系统提示:rtxContent.Tag为null,不可使用保存功能！");
                return;
            }
            string filePath = ((FileInfo)rtxContent.Tag).FullName;

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                byte[] byteFile = Encoding.Default.GetBytes(rtxContent.Text);
                fs.Write(byteFile, 0, byteFile.Length);
            }
            MessageBox.Show("保存成功!");
        }
         
        private void EncodeConvert_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
                stiSave_Click(null, null);
        }

        private void tsiSaveAs_Click(object sender, EventArgs e)
        {
            string path = FileDialogHelper.SaveFile("请选择保存路径", null, tslblFileName.Text);
            if (!string.IsNullOrEmpty(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    byte[] byteFile = Encoding.Default.GetBytes(rtxContent.Text);
                    fs.Write(byteFile, 0, byteFile.Length);
                }
                MessageBox.Show("保存成功!");
            }
        }
        #endregion

        #region 简繁体转化
        private void tsiToCHS_Click(object sender, EventArgs e)
        {
            rtxContent.Text = EncodingUtil.LanguageToSimplified(rtxContent.Text);
            if (((ToolStripMenuItem)sender) == tsiToCHSAndClipboard)
            {
                Clipboard.SetDataObject(rtxContent.Text);
            }
        }

        private void tsiToCHT_Click(object sender, EventArgs e)
        {
            rtxContent.Text = EncodingUtil.LanguageToTraditional(rtxContent.Text);
            if (((ToolStripMenuItem)sender) == tsiToCHTAndClipboard)
            {
                Clipboard.SetDataObject(rtxContent.Text);
            }
        }
        #endregion
 
    }

    class MyTreeNode : TreeNode
    {
        public MyTreeNode()
            : base()
        {

        }
        public MyTreeNode(string nodeText)
            : base(nodeText)
        {
        }

        public MyTreeNode(string nodeText, string path, int imageIndex, object tag)
            : base(nodeText)
        {
            this.path = path;
            this.ImageIndex = imageIndex;
            this.Tag = tag;
        }
        public string path = null;
    }
}
