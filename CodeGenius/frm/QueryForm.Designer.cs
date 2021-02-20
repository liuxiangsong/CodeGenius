namespace CodeGenius.frm
{
    partial class QueryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtContent = new ICSharpCode.TextEditor.TextEditorControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblLoginName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblDB = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblTimeSpan = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblRowCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageResult = new System.Windows.Forms.TabPage();
            this.gridResult = new System.Windows.Forms.DataGridView();
            this.tabPageMessage = new System.Windows.Forms.TabPage();
            this.rtxtMessage = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tscmb = new System.Windows.Forms.ToolStripComboBox();
            this.tsbtnExcute = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).BeginInit();
            this.tabPageMessage.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtContent);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl);
            this.splitContainer1.Size = new System.Drawing.Size(719, 462);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtContent
            // 
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Encoding = ((System.Text.Encoding)(resources.GetObject("txtContent.Encoding")));
            this.txtContent.Location = new System.Drawing.Point(0, 0);
            this.txtContent.Name = "txtContent";
            this.txtContent.ShowEOLMarkers = true;
            this.txtContent.ShowInvalidLines = false;
            this.txtContent.ShowSpaces = true;
            this.txtContent.ShowTabs = true;
            this.txtContent.ShowVRuler = true;
            this.txtContent.Size = new System.Drawing.Size(719, 210);
            this.txtContent.TabIndex = 0;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 222);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(719, 26);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
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
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(412, 21);
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
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageResult);
            this.tabControl.Controls.Add(this.tabPageMessage);
            this.tabControl.Location = new System.Drawing.Point(4, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(719, 210);
            this.tabControl.TabIndex = 2;
            // 
            // tabPageResult
            // 
            this.tabPageResult.Controls.Add(this.gridResult);
            this.tabPageResult.ImageIndex = 0;
            this.tabPageResult.Location = new System.Drawing.Point(4, 22);
            this.tabPageResult.Name = "tabPageResult";
            this.tabPageResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageResult.Size = new System.Drawing.Size(711, 184);
            this.tabPageResult.TabIndex = 0;
            this.tabPageResult.Text = "结果";
            this.tabPageResult.UseVisualStyleBackColor = true;
            // 
            // gridResult
            // 
            this.gridResult.AllowUserToAddRows = false;
            this.gridResult.AllowUserToDeleteRows = false;
            this.gridResult.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gridResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridResult.Location = new System.Drawing.Point(3, 3);
            this.gridResult.Name = "gridResult";
            this.gridResult.ReadOnly = true;
            this.gridResult.RowTemplate.Height = 23;
            this.gridResult.Size = new System.Drawing.Size(705, 178);
            this.gridResult.TabIndex = 0;
            // 
            // tabPageMessage
            // 
            this.tabPageMessage.Controls.Add(this.rtxtMessage);
            this.tabPageMessage.ImageIndex = 1;
            this.tabPageMessage.Location = new System.Drawing.Point(4, 22);
            this.tabPageMessage.Name = "tabPageMessage";
            this.tabPageMessage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMessage.Size = new System.Drawing.Size(711, 184);
            this.tabPageMessage.TabIndex = 1;
            this.tabPageMessage.Text = "消息";
            this.tabPageMessage.UseVisualStyleBackColor = true;
            // 
            // rtxtMessage
            // 
            this.rtxtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtMessage.Location = new System.Drawing.Point(3, 3);
            this.rtxtMessage.Name = "rtxtMessage";
            this.rtxtMessage.Size = new System.Drawing.Size(705, 178);
            this.rtxtMessage.TabIndex = 0;
            this.rtxtMessage.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscmb,
            this.tsbtnExcute});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(719, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tscmb
            // 
            this.tscmb.Name = "tscmb";
            this.tscmb.Size = new System.Drawing.Size(121, 25);
            // 
            // tsbtnExcute
            // 
            this.tsbtnExcute.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnExcute.Image")));
            this.tsbtnExcute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnExcute.Name = "tsbtnExcute";
            this.tsbtnExcute.Size = new System.Drawing.Size(52, 22);
            this.tsbtnExcute.Text = "执行";
            this.tsbtnExcute.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tsbtnExcute.Click += new System.EventHandler(this.tsbtnExcute_Click);
            // 
            // QueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 492);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "QueryForm";
            this.Text = "QueryForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).EndInit();
            this.tabPageMessage.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblServer;
        private System.Windows.Forms.ToolStripStatusLabel tsslblLoginName;
        private System.Windows.Forms.ToolStripStatusLabel tsslblDB;
        private System.Windows.Forms.ToolStripStatusLabel tsslblTimeSpan;
        private System.Windows.Forms.ToolStripStatusLabel tsslblRowCount;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageResult;
        private System.Windows.Forms.TabPage tabPageMessage;
        private System.Windows.Forms.RichTextBox rtxtMessage;
        private ICSharpCode.TextEditor.TextEditorControl txtContent;
        private System.Windows.Forms.DataGridView gridResult;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox tscmb;
        private System.Windows.Forms.ToolStripButton tsbtnExcute;
    }
}