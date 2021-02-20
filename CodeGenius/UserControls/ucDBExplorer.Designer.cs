namespace CodeGenius.UserControls
{
    partial class ucDBExplorer
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
            this.dbTree1 = new CodeGenius.DBTree();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDBConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dbTree1
            // 
            this.dbTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbTree1.ListImage = null;
            this.dbTree1.Location = new System.Drawing.Point(0, 27);
            this.dbTree1.Name = "dbTree1";
            this.dbTree1.SelectedNode = null;
            this.dbTree1.Size = new System.Drawing.Size(275, 481);
            this.dbTree1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmConnect,
            this.tsmDBConnect,
            this.tsmDisconnect,
            this.tsmRefresh});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(275, 27);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmConnect
            // 
            this.tsmConnect.Image = global::CodeGenius.Properties.Resources.more;
            this.tsmConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmConnect.Name = "tsmConnect";
            this.tsmConnect.Size = new System.Drawing.Size(83, 23);
            this.tsmConnect.Text = "Connect";
            this.tsmConnect.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tsmConnect.Visible = false;
            // 
            // tsmDBConnect
            // 
            this.tsmDBConnect.Image = global::CodeGenius.Properties.Resources.DBConnect;
            this.tsmDBConnect.Name = "tsmDBConnect";
            this.tsmDBConnect.Size = new System.Drawing.Size(28, 23);
            this.tsmDBConnect.Click += new System.EventHandler(this.tsmDBConnect_Click);
            // 
            // tsmDisconnect
            // 
            this.tsmDisconnect.Image = global::CodeGenius.Properties.Resources.noconnect;
            this.tsmDisconnect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmDisconnect.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmDisconnect.Name = "tsmDisconnect";
            this.tsmDisconnect.Size = new System.Drawing.Size(31, 23);
            this.tsmDisconnect.Click += new System.EventHandler(this.tsmDisconnect_Click);
            // 
            // tsmRefresh
            // 
            this.tsmRefresh.Image = global::CodeGenius.Properties.Resources.refresh;
            this.tsmRefresh.Name = "tsmRefresh";
            this.tsmRefresh.Size = new System.Drawing.Size(28, 23);
            this.tsmRefresh.Click += new System.EventHandler(this.tsmRefresh_Click);
            // 
            // ucDBExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dbTree1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ucDBExplorer";
            this.Size = new System.Drawing.Size(275, 508);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DBTree dbTree1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmConnect;
        private System.Windows.Forms.ToolStripMenuItem tsmDBConnect;
        private System.Windows.Forms.ToolStripMenuItem tsmDisconnect;
        private System.Windows.Forms.ToolStripMenuItem tsmRefresh;
    }
}
