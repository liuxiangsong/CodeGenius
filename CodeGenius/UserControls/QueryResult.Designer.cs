namespace CodeGenius.UserControls
{
    partial class QueryResult
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryResult));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageResult = new System.Windows.Forms.TabPage();
            this.tabPageMessage = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblLoginName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblDB = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblTimeSpan = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblRowCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.rtxtMessage = new System.Windows.Forms.RichTextBox();
            this.tabControl.SuspendLayout();
            this.tabPageMessage.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageResult);
            this.tabControl.Controls.Add(this.tabPageMessage);
            this.tabControl.ImageList = this.imageList1;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(621, 346);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageResult
            // 
            this.tabPageResult.ImageIndex = 0;
            this.tabPageResult.Location = new System.Drawing.Point(4, 23);
            this.tabPageResult.Name = "tabPageResult";
            this.tabPageResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageResult.Size = new System.Drawing.Size(613, 319);
            this.tabPageResult.TabIndex = 0;
            this.tabPageResult.Text = "结果";
            this.tabPageResult.UseVisualStyleBackColor = true;
            // 
            // tabPageMessage
            // 
            this.tabPageMessage.Controls.Add(this.rtxtMessage);
            this.tabPageMessage.ImageIndex = 1;
            this.tabPageMessage.Location = new System.Drawing.Point(4, 23);
            this.tabPageMessage.Name = "tabPageMessage";
            this.tabPageMessage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMessage.Size = new System.Drawing.Size(613, 319);
            this.tabPageMessage.TabIndex = 1;
            this.tabPageMessage.Text = "消息";
            this.tabPageMessage.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Grid.png");
            this.imageList1.Images.SetKeyName(1, "server (35).png");
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Khaki;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblStatus,
            this.toolStripStatusLabel1,
            this.tsslblServer,
            this.tsslblLoginName,
            this.tsslblDB,
            this.tsslblTimeSpan,
            this.tsslblRowCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 345);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(621, 26);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslblStatus
            // 
            this.tsslblStatus.Name = "tsslblStatus";
            this.tsslblStatus.Size = new System.Drawing.Size(44, 21);
            this.tsslblStatus.Text = "已连接";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(314, 21);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "  ";
            // 
            // tsslblServer
            // 
            this.tsslblServer.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslblServer.Name = "tsslblServer";
            this.tsslblServer.Size = new System.Drawing.Size(49, 21);
            this.tsslblServer.Text = "Server";
            // 
            // tsslblLoginName
            // 
            this.tsslblLoginName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslblLoginName.Name = "tsslblLoginName";
            this.tsslblLoginName.Size = new System.Drawing.Size(79, 21);
            this.tsslblLoginName.Text = "LoginName";
            // 
            // tsslblDB
            // 
            this.tsslblDB.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslblDB.Name = "tsslblDB";
            this.tsslblDB.Size = new System.Drawing.Size(29, 21);
            this.tsslblDB.Text = "DB";
            // 
            // tsslblTimeSpan
            // 
            this.tsslblTimeSpan.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslblTimeSpan.Name = "tsslblTimeSpan";
            this.tsslblTimeSpan.Size = new System.Drawing.Size(60, 21);
            this.tsslblTimeSpan.Text = "00:00:00";
            // 
            // tsslblRowCount
            // 
            this.tsslblRowCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslblRowCount.Name = "tsslblRowCount";
            this.tsslblRowCount.Size = new System.Drawing.Size(31, 21);
            this.tsslblRowCount.Text = "0行";
            // 
            // rtxtMessage
            // 
            this.rtxtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtMessage.Location = new System.Drawing.Point(3, 3);
            this.rtxtMessage.Name = "rtxtMessage";
            this.rtxtMessage.Size = new System.Drawing.Size(607, 313);
            this.rtxtMessage.TabIndex = 0;
            this.rtxtMessage.Text = "";
            // 
            // QueryResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl);
            this.Name = "QueryResult";
            this.Size = new System.Drawing.Size(621, 371);
            this.tabControl.ResumeLayout(false);
            this.tabPageMessage.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageResult;
        private System.Windows.Forms.TabPage tabPageMessage;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblServer;
        private System.Windows.Forms.ToolStripStatusLabel tsslblLoginName;
        private System.Windows.Forms.ToolStripStatusLabel tsslblDB;
        private System.Windows.Forms.ToolStripStatusLabel tsslblTimeSpan;
        private System.Windows.Forms.ToolStripStatusLabel tsslblRowCount;
        private System.Windows.Forms.RichTextBox rtxtMessage;
    }
}
