namespace CodeGenius
{
    partial class frmTableProperty
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
            this.ucSelectDB1 = new CodeGenius.UserControls.ucSelectDB();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridMain = new DevExpress.XtraGrid.GridControl();
            this.viewMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridSub = new DevExpress.XtraGrid.GridControl();
            this.viewSub = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSub)).BeginInit();
            this.SuspendLayout();
            // 
            // ucSelectDB1
            // 
            this.ucSelectDB1.Location = new System.Drawing.Point(10, 8);
            this.ucSelectDB1.Name = "ucSelectDB1";
            this.ucSelectDB1.SelectedDB = "";
            this.ucSelectDB1.Size = new System.Drawing.Size(435, 51);
            this.ucSelectDB1.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 65);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridSub);
            this.splitContainer1.Size = new System.Drawing.Size(708, 387);
            this.splitContainer1.SplitterDistance = 192;
            this.splitContainer1.TabIndex = 7;
            // 
            // gridMain
            // 
            this.gridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMain.Location = new System.Drawing.Point(0, 0);
            this.gridMain.MainView = this.viewMain;
            this.gridMain.Name = "gridMain";
            this.gridMain.Size = new System.Drawing.Size(708, 192);
            this.gridMain.TabIndex = 2;
            this.gridMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewMain});
            // 
            // viewMain
            // 
            this.viewMain.GridControl = this.gridMain;
            this.viewMain.Name = "viewMain";
            this.viewMain.OptionsBehavior.ReadOnly = true;
            this.viewMain.OptionsView.ShowFooter = true;
            this.viewMain.OptionsView.ShowGroupPanel = false;
            this.viewMain.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.viewMain_FocusedRowChanged);
            // 
            // gridSub
            // 
            this.gridSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSub.Location = new System.Drawing.Point(0, 0);
            this.gridSub.MainView = this.viewSub;
            this.gridSub.Name = "gridSub";
            this.gridSub.Size = new System.Drawing.Size(708, 191);
            this.gridSub.TabIndex = 3;
            this.gridSub.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewSub});
            // 
            // viewSub
            // 
            this.viewSub.GridControl = this.gridSub;
            this.viewSub.Name = "viewSub";
            this.viewSub.OptionsBehavior.ReadOnly = true;
            this.viewSub.OptionsView.ShowFooter = true;
            this.viewSub.OptionsView.ShowGroupPanel = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(499, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmTableProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 464);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ucSelectDB1);
            this.Name = "frmTableProperty";
            this.Text = "表属性";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSub)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucSelectDB ucSelectDB1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridMain;
        private DevExpress.XtraGrid.Views.Grid.GridView viewMain;
        private DevExpress.XtraGrid.GridControl gridSub;
        private DevExpress.XtraGrid.Views.Grid.GridView viewSub;
        private System.Windows.Forms.Button button1;
    }
}