namespace CodeGenius
{
    partial class frmDBExplorer
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
            this.dbTree1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dbTree1.ListImage = null;
            this.dbTree1.Location = new System.Drawing.Point(0, 30);
            this.dbTree1.Name = "dbTree1";
            this.dbTree1.SelectedNode = null;
            this.dbTree1.Size = new System.Drawing.Size(254, 329);
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
            this.menuStrip1.Size = new System.Drawing.Size(254, 27);
            this.menuStrip1.TabIndex = 1;
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
            // frmDBExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 359);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dbTree1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmDBExplorer";
            this.Text = "frmDBExplorer";
            this.Load += new System.EventHandler(this.frmDBExplorer_Load);
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