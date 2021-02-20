namespace CodeGenius
{
    partial class GenerateDBDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerateDBDoc));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.lstSelectedTable = new System.Windows.Forms.ListBox();
            this.lstUnSelectedTable = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbHtml = new System.Windows.Forms.RadioButton();
            this.rbWord = new System.Windows.Forms.RadioButton();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ucSelectDB1 = new CodeGenius.UserControls.ucSelectDB();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.btnRemoveAll);
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnAddAll);
            this.groupBox2.Controls.Add(this.lstSelectedTable);
            this.groupBox2.Controls.Add(this.lstUnSelectedTable);
            this.groupBox2.Location = new System.Drawing.Point(6, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 279);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择表";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(20, 240);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(390, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 6;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(188, 171);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(54, 23);
            this.btnRemoveAll.TabIndex = 5;
            this.btnRemoveAll.Text = "<<";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.AddOrRemoveButton_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(188, 132);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(54, 23);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.AddOrRemoveButton_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(188, 93);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = ">";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.AddOrRemoveButton_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(188, 54);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(54, 23);
            this.btnAddAll.TabIndex = 2;
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
            this.lstSelectedTable.TabIndex = 1;
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbHtml);
            this.groupBox3.Controls.Add(this.rbWord);
            this.groupBox3.Location = new System.Drawing.Point(6, 365);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(428, 50);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "文档格式";
            // 
            // rbHtml
            // 
            this.rbHtml.AutoSize = true;
            this.rbHtml.Location = new System.Drawing.Point(226, 21);
            this.rbHtml.Name = "rbHtml";
            this.rbHtml.Size = new System.Drawing.Size(73, 16);
            this.rbHtml.TabIndex = 1;
            this.rbHtml.TabStop = true;
            this.rbHtml.Text = "Html 格式";
            this.rbHtml.UseVisualStyleBackColor = true;
            // 
            // rbWord
            // 
            this.rbWord.AutoSize = true;
            this.rbWord.Checked = true;
            this.rbWord.Location = new System.Drawing.Point(42, 21);
            this.rbWord.Name = "rbWord";
            this.rbWord.Size = new System.Drawing.Size(77, 16);
            this.rbWord.TabIndex = 0;
            this.rbWord.TabStop = true;
            this.rbWord.Text = "Word 格式";
            this.rbWord.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(275, 421);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "生成";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(359, 421);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ucSelectDB1
            // 
            this.ucSelectDB1.Location = new System.Drawing.Point(6, 12);
            this.ucSelectDB1.Name = "ucSelectDB1";
            this.ucSelectDB1.SelectedDB = "";
            this.ucSelectDB1.Size = new System.Drawing.Size(428, 51);
            this.ucSelectDB1.TabIndex = 5;
            // 
            // GenerateDBDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 448);
            this.Controls.Add(this.ucSelectDB1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenerateDBDoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "生成数据字典";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GenerateDBDoc_FormClosed);
            this.Load += new System.EventHandler(this.GenerateDBDoc_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.ListBox lstSelectedTable;
        private System.Windows.Forms.ListBox lstUnSelectedTable;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbHtml;
        private System.Windows.Forms.RadioButton rbWord;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ProgressBar progressBar1;
        private UserControls.ucSelectDB ucSelectDB1;
    }
}