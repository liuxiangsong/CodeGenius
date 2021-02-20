namespace CodeGenius
{
    partial class EncodeConvert
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncodeConvert));
            this.tv = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslblFileName = new System.Windows.Forms.ToolStripStatusLabel();
            this.rtxContent = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.stiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsiGB2312 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiUnicode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiBig5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsiToCHS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiToCHT = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiToCHSAndClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiToCHTAndClipboard = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv
            // 
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.ImageIndex = 0;
            this.tv.ImageList = this.imageList1;
            this.tv.Location = new System.Drawing.Point(0, 0);
            this.tv.Name = "tv";
            this.tv.SelectedImageIndex = 3;
            this.tv.Size = new System.Drawing.Size(177, 537);
            this.tv.TabIndex = 9;
            this.tv.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterCollapse);
            this.tv.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tv_BeforeExpand);
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            this.tv.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_NodeMouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder (2).png");
            this.imageList1.Images.SetKeyName(1, "Folder (1).png");
            this.imageList1.Images.SetKeyName(2, "File.png");
            this.imageList1.Images.SetKeyName(3, "drive.png");
            this.imageList1.Images.SetKeyName(4, "Desktop.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tv);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.rtxContent);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(756, 537);
            this.splitContainer1.SplitterDistance = 177;
            this.splitContainer1.TabIndex = 10;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblFileName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 515);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(575, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslblFileName
            // 
            this.tslblFileName.AutoToolTip = true;
            this.tslblFileName.Name = "tslblFileName";
            this.tslblFileName.Size = new System.Drawing.Size(60, 17);
            this.tslblFileName.Text = "fileName";
            // 
            // rtxContent
            // 
            this.rtxContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxContent.Location = new System.Drawing.Point(0, 25);
            this.rtxContent.Name = "rtxContent";
            this.rtxContent.Size = new System.Drawing.Size(575, 487);
            this.rtxContent.TabIndex = 10;
            this.rtxContent.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(575, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stiSave,
            this.tsiSaveAs});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton1.Text = "文件";
            this.toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // stiSave
            // 
            this.stiSave.Name = "stiSave";
            this.stiSave.Size = new System.Drawing.Size(152, 22);
            this.stiSave.Text = "保存(&S)";
            this.stiSave.Click += new System.EventHandler(this.stiSave_Click);
            // 
            // tsiSaveAs
            // 
            this.tsiSaveAs.Name = "tsiSaveAs";
            this.tsiSaveAs.Size = new System.Drawing.Size(152, 22);
            this.tsiSaveAs.Text = "另存为(&A)";
            this.tsiSaveAs.Click += new System.EventHandler(this.tsiSaveAs_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiGB2312,
            this.tsiUnicode,
            this.tsiBig5});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton2.Text = "编码";
            // 
            // tsiGB2312
            // 
            this.tsiGB2312.Name = "tsiGB2312";
            this.tsiGB2312.Size = new System.Drawing.Size(182, 22);
            this.tsiGB2312.Tag = "GB2312";
            this.tsiGB2312.Text = "GB2312(&Z)";
            this.tsiGB2312.Click += new System.EventHandler(this.tsiEncodingClick);
            // 
            // tsiUnicode
            // 
            this.tsiUnicode.Name = "tsiUnicode";
            this.tsiUnicode.Size = new System.Drawing.Size(182, 22);
            this.tsiUnicode.Tag = "UTF-8";
            this.tsiUnicode.Text = "Unicode(UTF-8)(&X)";
            this.tsiUnicode.Click += new System.EventHandler(this.tsiEncodingClick);
            // 
            // tsiBig5
            // 
            this.tsiBig5.Name = "tsiBig5";
            this.tsiBig5.Size = new System.Drawing.Size(182, 22);
            this.tsiBig5.Tag = "BIG5";
            this.tsiBig5.Text = "BIG5(&C)";
            this.tsiBig5.Click += new System.EventHandler(this.tsiEncodingClick);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiToCHS,
            this.tsiToCHT,
            this.tsiToCHSAndClipboard,
            this.tsiToCHTAndClipboard});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(69, 22);
            this.toolStripDropDownButton3.Text = "简繁转化";
            // 
            // tsiToCHS
            // 
            this.tsiToCHS.Name = "tsiToCHS";
            this.tsiToCHS.Size = new System.Drawing.Size(201, 22);
            this.tsiToCHS.Text = "转化为简体(&R)";
            this.tsiToCHS.Click += new System.EventHandler(this.tsiToCHS_Click);
            // 
            // tsiToCHT
            // 
            this.tsiToCHT.Name = "tsiToCHT";
            this.tsiToCHT.Size = new System.Drawing.Size(201, 22);
            this.tsiToCHT.Text = "转化为繁体(&T)";
            this.tsiToCHT.Click += new System.EventHandler(this.tsiToCHT_Click);
            // 
            // tsiToCHSAndClipboard
            // 
            this.tsiToCHSAndClipboard.Name = "tsiToCHSAndClipboard";
            this.tsiToCHSAndClipboard.Size = new System.Drawing.Size(201, 22);
            this.tsiToCHSAndClipboard.Text = "转化为简体至剪贴板(&F)";
            this.tsiToCHSAndClipboard.Click += new System.EventHandler(this.tsiToCHS_Click);
            // 
            // tsiToCHTAndClipboard
            // 
            this.tsiToCHTAndClipboard.Name = "tsiToCHTAndClipboard";
            this.tsiToCHTAndClipboard.Size = new System.Drawing.Size(201, 22);
            this.tsiToCHTAndClipboard.Text = "转化为繁体至剪贴板(&G)";
            this.tsiToCHTAndClipboard.Click += new System.EventHandler(this.tsiToCHT_Click);
            // 
            // EncodeConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 537);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "EncodeConvert";
            this.Text = "编码转化";
            this.Load += new System.EventHandler(this.EncodeConvert_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EncodeConvert_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem stiSave;
        private System.Windows.Forms.ToolStripMenuItem tsiSaveAs;
        private System.Windows.Forms.RichTextBox rtxContent;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem tsiGB2312;
        private System.Windows.Forms.ToolStripMenuItem tsiBig5;
        private System.Windows.Forms.ToolStripMenuItem tsiUnicode;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem tsiToCHS;
        private System.Windows.Forms.ToolStripMenuItem tsiToCHT;
        private System.Windows.Forms.ToolStripMenuItem tsiToCHSAndClipboard;
        private System.Windows.Forms.ToolStripMenuItem tsiToCHTAndClipboard;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslblFileName;
    }
}