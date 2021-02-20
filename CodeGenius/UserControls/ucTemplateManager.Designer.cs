namespace CodeGenius.UserControls
{
    partial class ucTemplateManager
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTemplateManager));
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsAddFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsAddTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tvwTemplate = new System.Windows.Forms.TreeView();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsAdd,
            this.cmsEdit,
            this.toolStripMenuItem2,
            this.cmsRefresh,
            this.cmsRename,
            this.cmsDelete,
            this.toolStripMenuItem1,
            this.cmsOpenFolder});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(179, 148);
            // 
            // cmsAdd
            // 
            this.cmsAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsAddFolder,
            this.cmsAddTemplate});
            this.cmsAdd.Image = global::CodeGenius.Properties.Resources.Add;
            this.cmsAdd.Name = "cmsAdd";
            this.cmsAdd.Size = new System.Drawing.Size(178, 22);
            this.cmsAdd.Text = "新建(N)";
            // 
            // cmsAddFolder
            // 
            this.cmsAddFolder.Image = global::CodeGenius.Properties.Resources.Folder__2_;
            this.cmsAddFolder.Name = "cmsAddFolder";
            this.cmsAddFolder.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.cmsAddFolder.Size = new System.Drawing.Size(174, 22);
            this.cmsAddFolder.Text = "文件夹(&D)";
            this.cmsAddFolder.Click += new System.EventHandler(this.cmsAddFolder_Click);
            // 
            // cmsAddTemplate
            // 
            this.cmsAddTemplate.Image = global::CodeGenius.Properties.Resources.File;
            this.cmsAddTemplate.Name = "cmsAddTemplate";
            this.cmsAddTemplate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.cmsAddTemplate.Size = new System.Drawing.Size(174, 22);
            this.cmsAddTemplate.Text = "模板(&T)";
            this.cmsAddTemplate.Click += new System.EventHandler(this.cmsAddTemplate_Click);
            // 
            // cmsEdit
            // 
            this.cmsEdit.Image = global::CodeGenius.Properties.Resources.Edit;
            this.cmsEdit.Name = "cmsEdit";
            this.cmsEdit.Size = new System.Drawing.Size(178, 22);
            this.cmsEdit.Text = "修改(&E)";
            this.cmsEdit.Click += new System.EventHandler(this.cmsEdit_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(175, 6);
            // 
            // cmsRefresh
            // 
            this.cmsRefresh.Image = global::CodeGenius.Properties.Resources.refresh;
            this.cmsRefresh.Name = "cmsRefresh";
            this.cmsRefresh.Size = new System.Drawing.Size(178, 22);
            this.cmsRefresh.Text = "刷新(R)";
            this.cmsRefresh.Click += new System.EventHandler(this.cmsRefresh_Click);
            // 
            // cmsRename
            // 
            this.cmsRename.Name = "cmsRename";
            this.cmsRename.Size = new System.Drawing.Size(178, 22);
            this.cmsRename.Text = "重命名(&M)";
            this.cmsRename.Click += new System.EventHandler(this.cmsRename_Click);
            // 
            // cmsDelete
            // 
            this.cmsDelete.Image = global::CodeGenius.Properties.Resources.Delete;
            this.cmsDelete.Name = "cmsDelete";
            this.cmsDelete.Size = new System.Drawing.Size(178, 22);
            this.cmsDelete.Text = "删除(&D)";
            this.cmsDelete.Click += new System.EventHandler(this.cmsRename_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(175, 6);
            // 
            // cmsOpenFolder
            // 
            this.cmsOpenFolder.Name = "cmsOpenFolder";
            this.cmsOpenFolder.Size = new System.Drawing.Size(178, 22);
            this.cmsOpenFolder.Text = "打开所在文件夹(&O)";
            this.cmsOpenFolder.Click += new System.EventHandler(this.cmsOpenFolder_Click);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "File");
            this.imgList.Images.SetKeyName(1, "FolderOpen");
            this.imgList.Images.SetKeyName(2, "FolderClose");
            // 
            // tvwTemplate
            // 
            this.tvwTemplate.ContextMenuStrip = this.cms;
            this.tvwTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwTemplate.ImageIndex = 0;
            this.tvwTemplate.ImageList = this.imgList;
            this.tvwTemplate.LabelEdit = true;
            this.tvwTemplate.Location = new System.Drawing.Point(0, 0);
            this.tvwTemplate.Name = "tvwTemplate";
            this.tvwTemplate.SelectedImageIndex = 2;
            this.tvwTemplate.Size = new System.Drawing.Size(251, 400);
            this.tvwTemplate.TabIndex = 1;
            this.tvwTemplate.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvwTemplate_AfterLabelEdit);
            this.tvwTemplate.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvwTemplate_AfterCollapse);
            this.tvwTemplate.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvwTemplate_AfterExpand);
            this.tvwTemplate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwTemplate_AfterSelect);
            this.tvwTemplate.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwTemplate_NodeMouseClick);
            this.tvwTemplate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvwTemplate_MouseClick);
            // 
            // ucTemplateManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvwTemplate);
            this.Name = "ucTemplateManager";
            this.Size = new System.Drawing.Size(251, 400);
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem cmsAdd;
        private System.Windows.Forms.ToolStripMenuItem cmsAddFolder;
        private System.Windows.Forms.ToolStripMenuItem cmsAddTemplate;
        private System.Windows.Forms.ToolStripMenuItem cmsEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cmsRefresh;
        private System.Windows.Forms.ToolStripMenuItem cmsRename;
        private System.Windows.Forms.ToolStripMenuItem cmsDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cmsOpenFolder;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.TreeView tvwTemplate;


    }
}
