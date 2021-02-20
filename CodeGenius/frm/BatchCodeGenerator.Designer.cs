namespace CodeGenius
{
    partial class BatchCodeGenerator
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.lstSelectedTable = new System.Windows.Forms.ListBox();
            this.lstUnSelectedTable = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBLLBrowse = new System.Windows.Forms.Button();
            this.btnDALBrowse = new System.Windows.Forms.Button();
            this.btnEntityBrowse = new System.Windows.Forms.Button();
            this.txtBLLPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDALPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEntityPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.ucSelectDB1 = new CodeGenius.UserControls.ucSelectDB();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemoveAll);
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnAddAll);
            this.groupBox2.Controls.Add(this.lstSelectedTable);
            this.groupBox2.Controls.Add(this.lstUnSelectedTable);
            this.groupBox2.Location = new System.Drawing.Point(12, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(513, 243);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择表";
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(188, 171);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(54, 23);
            this.btnRemoveAll.TabIndex = 4;
            this.btnRemoveAll.Text = "<<";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.AddOrRemoveButton_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(188, 132);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(54, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.AddOrRemoveButton_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(188, 93);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = ">";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.AddOrRemoveButton_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(188, 54);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(54, 23);
            this.btnAddAll.TabIndex = 1;
            this.btnAddAll.Text = ">>";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.AddOrRemoveButton_Click);
            // 
            // lstSelectedTable
            // 
            this.lstSelectedTable.DisplayMember = "name";
            this.lstSelectedTable.FormattingEnabled = true;
            this.lstSelectedTable.ItemHeight = 12;
            this.lstSelectedTable.Location = new System.Drawing.Point(263, 24);
            this.lstSelectedTable.Name = "lstSelectedTable";
            this.lstSelectedTable.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSelectedTable.Size = new System.Drawing.Size(147, 208);
            this.lstSelectedTable.TabIndex = 5;
            this.lstSelectedTable.ValueMember = "name";
            this.lstSelectedTable.DoubleClick += new System.EventHandler(this.ListBox_DoubleClick);
            // 
            // lstUnSelectedTable
            // 
            this.lstUnSelectedTable.DisplayMember = "name";
            this.lstUnSelectedTable.FormattingEnabled = true;
            this.lstUnSelectedTable.ItemHeight = 12;
            this.lstUnSelectedTable.Location = new System.Drawing.Point(20, 24);
            this.lstUnSelectedTable.Name = "lstUnSelectedTable";
            this.lstUnSelectedTable.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstUnSelectedTable.Size = new System.Drawing.Size(147, 208);
            this.lstUnSelectedTable.TabIndex = 0;
            this.lstUnSelectedTable.ValueMember = "name";
            this.lstUnSelectedTable.DoubleClick += new System.EventHandler(this.ListBox_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBLLBrowse);
            this.groupBox1.Controls.Add(this.btnDALBrowse);
            this.groupBox1.Controls.Add(this.btnEntityBrowse);
            this.groupBox1.Controls.Add(this.txtBLLPath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDALPath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEntityPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 293);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 109);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnBLLBrowse
            // 
            this.btnBLLBrowse.Location = new System.Drawing.Point(409, 77);
            this.btnBLLBrowse.Name = "btnBLLBrowse";
            this.btnBLLBrowse.Size = new System.Drawing.Size(57, 23);
            this.btnBLLBrowse.TabIndex = 8;
            this.btnBLLBrowse.Text = "...";
            this.btnBLLBrowse.UseVisualStyleBackColor = true;
            this.btnBLLBrowse.Click += new System.EventHandler(this.btnBLLBrowse_Click);
            // 
            // btnDALBrowse
            // 
            this.btnDALBrowse.Location = new System.Drawing.Point(409, 49);
            this.btnDALBrowse.Name = "btnDALBrowse";
            this.btnDALBrowse.Size = new System.Drawing.Size(57, 23);
            this.btnDALBrowse.TabIndex = 5;
            this.btnDALBrowse.Text = "...";
            this.btnDALBrowse.UseVisualStyleBackColor = true;
            this.btnDALBrowse.Click += new System.EventHandler(this.btnDALBrowse_Click);
            // 
            // btnEntityBrowse
            // 
            this.btnEntityBrowse.Location = new System.Drawing.Point(409, 21);
            this.btnEntityBrowse.Name = "btnEntityBrowse";
            this.btnEntityBrowse.Size = new System.Drawing.Size(57, 23);
            this.btnEntityBrowse.TabIndex = 2;
            this.btnEntityBrowse.Text = "...";
            this.btnEntityBrowse.UseVisualStyleBackColor = true;
            this.btnEntityBrowse.Click += new System.EventHandler(this.btnEntityBrowse_Click);
            // 
            // txtBLLPath
            // 
            this.txtBLLPath.BackColor = System.Drawing.SystemColors.Window;
            this.txtBLLPath.Location = new System.Drawing.Point(78, 77);
            this.txtBLLPath.Name = "txtBLLPath";
            this.txtBLLPath.Size = new System.Drawing.Size(322, 21);
            this.txtBLLPath.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "BLL";
            // 
            // txtDALPath
            // 
            this.txtDALPath.BackColor = System.Drawing.SystemColors.Window;
            this.txtDALPath.Location = new System.Drawing.Point(78, 49);
            this.txtDALPath.Name = "txtDALPath";
            this.txtDALPath.Size = new System.Drawing.Size(322, 21);
            this.txtDALPath.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Controller";
            // 
            // txtEntityPath
            // 
            this.txtEntityPath.BackColor = System.Drawing.SystemColors.Window;
            this.txtEntityPath.Location = new System.Drawing.Point(78, 21);
            this.txtEntityPath.Name = "txtEntityPath";
            this.txtEntityPath.Size = new System.Drawing.Size(322, 21);
            this.txtEntityPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Entity";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(401, 414);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(317, 414);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "生成";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 419);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "命名空间：";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(79, 416);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(100, 21);
            this.txtNamespace.TabIndex = 4;
            // 
            // ucSelectDB1
            // 
            this.ucSelectDB1.Location = new System.Drawing.Point(5, 2);
            this.ucSelectDB1.Name = "ucSelectDB1";
            this.ucSelectDB1.SelectedDB = "";
            this.ucSelectDB1.Size = new System.Drawing.Size(520, 43);
            this.ucSelectDB1.TabIndex = 0;
            // 
            // BatchCodeGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 449);
            this.Controls.Add(this.txtNamespace);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ucSelectDB1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BatchCodeGenerator";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "代码批量生成器";
            this.Load += new System.EventHandler(this.BatchCodeGenerator_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.ListBox lstSelectedTable;
        private System.Windows.Forms.ListBox lstUnSelectedTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBLLBrowse;
        private System.Windows.Forms.Button btnDALBrowse;
        private System.Windows.Forms.Button btnEntityBrowse;
        private System.Windows.Forms.TextBox txtBLLPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDALPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEntityPath;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNamespace;
        private UserControls.ucSelectDB ucSelectDB1;
    }
}