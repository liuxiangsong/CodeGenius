namespace Paging
{
    partial class PagingControl
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
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnLast = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrevious = new DevExpress.XtraEditors.SimpleButton();
            this.btnFirst = new DevExpress.XtraEditors.SimpleButton();
            this.txtPageIndex = new DevExpress.XtraEditors.TextEdit();
            this.lblPagingInfo = new System.Windows.Forms.Label();
            this.btnExportAll = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageIndex.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(458, 7);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 40;
            this.btnExport.Text = "導出當前頁";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnLast
            // 
            this.btnLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLast.Image = global::Paging.Properties.Resources.GoToLastRecord;
            this.btnLast.Location = new System.Drawing.Point(429, 7);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(22, 23);
            this.btnLast.TabIndex = 38;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Image = global::Paging.Properties.Resources.GoToNextRecord;
            this.btnNext.Location = new System.Drawing.Point(402, 7);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(22, 23);
            this.btnNext.TabIndex = 39;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Image = global::Paging.Properties.Resources.GoToPreviousRecord;
            this.btnPrevious.Location = new System.Drawing.Point(335, 7);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(22, 23);
            this.btnPrevious.TabIndex = 36;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirst.Image = global::Paging.Properties.Resources.GoToFirstRecord;
            this.btnFirst.Location = new System.Drawing.Point(308, 7);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(22, 23);
            this.btnFirst.TabIndex = 37;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // txtPageIndex
            // 
            this.txtPageIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPageIndex.EditValue = "1";
            this.txtPageIndex.Location = new System.Drawing.Point(362, 8);
            this.txtPageIndex.Name = "txtPageIndex";
            this.txtPageIndex.Properties.Mask.EditMask = "[0-9]{1,9}";
            this.txtPageIndex.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtPageIndex.Size = new System.Drawing.Size(35, 20);
            this.txtPageIndex.TabIndex = 35;
            this.txtPageIndex.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtPageIndex_EditValueChanging);
            this.txtPageIndex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPageIndex_KeyDown);
            // 
            // lblPagingInfo
            // 
            this.lblPagingInfo.AutoSize = true;
            this.lblPagingInfo.Location = new System.Drawing.Point(13, 13);
            this.lblPagingInfo.Name = "lblPagingInfo";
            this.lblPagingInfo.Size = new System.Drawing.Size(203, 12);
            this.lblPagingInfo.TabIndex = 34;
            this.lblPagingInfo.Text = "共 {0} 条记录，每页 {1} 条，共 {2} 页";
            // 
            // btnExportAll
            // 
            this.btnExportAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportAll.Location = new System.Drawing.Point(539, 7);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(75, 23);
            this.btnExportAll.TabIndex = 40;
            this.btnExportAll.Text = "導出所有頁";
            this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
            // 
            // PagingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExportAll);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.txtPageIndex);
            this.Controls.Add(this.lblPagingInfo);
            this.Name = "PagingControl";
            this.Size = new System.Drawing.Size(620, 39);
            ((System.ComponentModel.ISupportInitialize)(this.txtPageIndex.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnLast;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnPrevious;
        private DevExpress.XtraEditors.SimpleButton btnFirst;
        private DevExpress.XtraEditors.TextEdit txtPageIndex;
        private System.Windows.Forms.Label lblPagingInfo;
        private DevExpress.XtraEditors.SimpleButton btnExportAll;
    }
}
