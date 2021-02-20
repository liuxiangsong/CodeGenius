namespace CodeGenius
{
    partial class ViewForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cmsForm = new System.Windows.Forms.ContextMenuStrip();
            this.cmsFormSave = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFormClose = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFormCloseOthers = new System.Windows.Forms.ToolStripMenuItem();
            this.GridView = new System.Windows.Forms.DataGridView();
            this.txtContent = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.cmsForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(641, 454);
            this.splitContainer1.SplitterDistance = 154;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtContent);
            this.splitContainer2.Panel2Collapsed = true;
            this.splitContainer2.Size = new System.Drawing.Size(641, 296);
            this.splitContainer2.SplitterDistance = 187;
            this.splitContainer2.TabIndex = 1;
            // 
            // cmsForm
            // 
            this.cmsForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsFormSave,
            this.cmsFormClose,
            this.cmsFormCloseOthers});
            this.cmsForm.Name = "cmsForm";
            this.cmsForm.Size = new System.Drawing.Size(184, 70);
            // 
            // cmsFormSave
            // 
            this.cmsFormSave.Image = global::CodeGenius.Properties.Resources.Save;
            this.cmsFormSave.Name = "cmsFormSave";
            this.cmsFormSave.Size = new System.Drawing.Size(183, 22);
            this.cmsFormSave.Text = "Save(&S)";
            this.cmsFormSave.Click += new System.EventHandler(this.cmsFormSave_Click);
            // 
            // cmsFormClose
            // 
            this.cmsFormClose.Name = "cmsFormClose";
            this.cmsFormClose.Size = new System.Drawing.Size(183, 22);
            this.cmsFormClose.Text = "Close(C)";
            this.cmsFormClose.Click += new System.EventHandler(this.cmsFormClose_Click);
            // 
            // cmsFormCloseOthers
            // 
            this.cmsFormCloseOthers.Name = "cmsFormCloseOthers";
            this.cmsFormCloseOthers.Size = new System.Drawing.Size(183, 22);
            this.cmsFormCloseOthers.Text = "Close all but this(&A)";
            this.cmsFormCloseOthers.Click += new System.EventHandler(this.cmsFormCloseOthers_Click);
            // 
            // GridView
            // 
            this.GridView.AllowUserToAddRows = false;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridView.Location = new System.Drawing.Point(0, 0);
            this.GridView.Name = "GridView";
            this.GridView.RowTemplate.Height = 24;
            this.GridView.Size = new System.Drawing.Size(641, 154);
            this.GridView.TabIndex = 0;
            // 
            // txtContent
            // 
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Location = new System.Drawing.Point(0, 0);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(641, 296);
            this.txtContent.TabIndex = 0;
            this.txtContent.Text = "";
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 454);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "ViewForm";
            this.TabPageContextMenuStrip = this.cmsForm;
            this.Text = "ViewForm";
            this.Activated += new System.EventHandler(this.ViewForm_Activated);
            this.Deactivate += new System.EventHandler(this.ViewForm_Deactivate);
            this.Load += new System.EventHandler(this.ViewForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.cmsForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ContextMenuStrip cmsForm;
        private System.Windows.Forms.ToolStripMenuItem cmsFormSave;
        private System.Windows.Forms.ToolStripMenuItem cmsFormClose;
        private System.Windows.Forms.ToolStripMenuItem cmsFormCloseOthers;
        private System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.RichTextBox txtContent;
    }
}