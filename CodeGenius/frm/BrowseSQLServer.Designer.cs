namespace CodeGenius
{
    partial class BrowseSQLServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowseSQLServer));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageLocal = new System.Windows.Forms.TabPage();
            this.tvwLocal = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList();
            this.tabPageNetwork = new System.Windows.Forms.TabPage();
            this.tvwNetwork = new System.Windows.Forms.TreeView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageLocal.SuspendLayout();
            this.tabPageNetwork.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageLocal);
            this.tabControl1.Controls.Add(this.tabPageNetwork);
            this.tabControl1.Location = new System.Drawing.Point(0, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(326, 330);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageLocal
            // 
            this.tabPageLocal.Controls.Add(this.tvwLocal);
            this.tabPageLocal.Location = new System.Drawing.Point(4, 22);
            this.tabPageLocal.Name = "tabPageLocal";
            this.tabPageLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLocal.Size = new System.Drawing.Size(318, 304);
            this.tabPageLocal.TabIndex = 0;
            this.tabPageLocal.Text = "Local Server";
            this.tabPageLocal.UseVisualStyleBackColor = true;
            // 
            // tvwLocal
            // 
            this.tvwLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwLocal.ImageIndex = 0;
            this.tvwLocal.ImageList = this.imgList;
            this.tvwLocal.Location = new System.Drawing.Point(3, 3);
            this.tvwLocal.Name = "tvwLocal";
            this.tvwLocal.SelectedImageIndex = 0;
            this.tvwLocal.Size = new System.Drawing.Size(312, 298);
            this.tvwLocal.TabIndex = 0;
            this.tvwLocal.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterExpand);
            this.tvwLocal.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            this.tvwLocal.DoubleClick += new System.EventHandler(this.btnOK_Click);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "DataBase");
            this.imgList.Images.SetKeyName(1, "Server");
            this.imgList.Images.SetKeyName(2, "Loading");
            // 
            // tabPageNetwork
            // 
            this.tabPageNetwork.Controls.Add(this.tvwNetwork);
            this.tabPageNetwork.Location = new System.Drawing.Point(4, 22);
            this.tabPageNetwork.Name = "tabPageNetwork";
            this.tabPageNetwork.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNetwork.Size = new System.Drawing.Size(318, 304);
            this.tabPageNetwork.TabIndex = 1;
            this.tabPageNetwork.Text = "Network Server";
            this.tabPageNetwork.UseVisualStyleBackColor = true;
            // 
            // tvwNetwork
            // 
            this.tvwNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwNetwork.ImageIndex = 0;
            this.tvwNetwork.ImageList = this.imgList;
            this.tvwNetwork.Location = new System.Drawing.Point(3, 3);
            this.tvwNetwork.Name = "tvwNetwork";
            this.tvwNetwork.SelectedImageIndex = 0;
            this.tvwNetwork.Size = new System.Drawing.Size(312, 298);
            this.tvwNetwork.TabIndex = 1;
            this.tvwNetwork.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterExpand);
            this.tvwNetwork.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            this.tvwNetwork.DoubleClick += new System.EventHandler(this.btnOK_Click);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(163, 339);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(244, 339);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BrowseSQLServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 365);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BrowseSQLServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BrowseSQLServer";
            this.Load += new System.EventHandler(this.BrowseSQLServer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageLocal.ResumeLayout(false);
            this.tabPageNetwork.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageLocal;
        private System.Windows.Forms.TreeView tvwLocal;
        private System.Windows.Forms.TabPage tabPageNetwork;
        private System.Windows.Forms.TreeView tvwNetwork;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ImageList imgList;
    }
}