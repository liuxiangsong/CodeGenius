namespace CodeGenius 
{
    partial class TemplateCodeGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateCodeGenerator));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboDataBase = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentServer = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.lstSelectedTable = new System.Windows.Forms.ListBox();
            this.lstUnSelectedTable = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstTemplate = new System.Windows.Forms.ListBox();
            this.tvwTemplate = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboDataBase);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblCurrentServer);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 62);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select DataBase";
            // 
            // cboDataBase
            // 
            this.cboDataBase.DisplayMember = "name";
            this.cboDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataBase.FormattingEnabled = true;
            this.cboDataBase.Location = new System.Drawing.Point(285, 25);
            this.cboDataBase.Name = "cboDataBase";
            this.cboDataBase.Size = new System.Drawing.Size(121, 20);
            this.cboDataBase.TabIndex = 2;
            this.cboDataBase.ValueMember = "name";
            this.cboDataBase.SelectedIndexChanged += new System.EventHandler(this.cboDataBase_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Database:";
            // 
            // lblCurrentServer
            // 
            this.lblCurrentServer.AutoSize = true;
            this.lblCurrentServer.Location = new System.Drawing.Point(18, 28);
            this.lblCurrentServer.Name = "lblCurrentServer";
            this.lblCurrentServer.Size = new System.Drawing.Size(77, 12);
            this.lblCurrentServer.TabIndex = 0;
            this.lblCurrentServer.Text = "Current Server:";
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
            this.groupBox2.Location = new System.Drawing.Point(12, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 279);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Table";
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
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(427, 504);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(343, 504);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstTemplate);
            this.groupBox3.Controls.Add(this.tvwTemplate);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(12, 366);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(428, 132);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select Template";
            // 
            // lstTemplate
            // 
            this.lstTemplate.FormattingEnabled = true;
            this.lstTemplate.ItemHeight = 12;
            this.lstTemplate.Location = new System.Drawing.Point(263, 21);
            this.lstTemplate.Name = "lstTemplate";
            this.lstTemplate.Size = new System.Drawing.Size(147, 88);
            this.lstTemplate.TabIndex = 6;
            // 
            // tvwTemplate
            // 
            this.tvwTemplate.ImageIndex = 0;
            this.tvwTemplate.ImageList = this.imgList;
            this.tvwTemplate.Location = new System.Drawing.Point(20, 22);
            this.tvwTemplate.Name = "tvwTemplate";
            this.tvwTemplate.SelectedImageIndex = 0;
            this.tvwTemplate.Size = new System.Drawing.Size(147, 97);
            this.tvwTemplate.TabIndex = 0;
            this.tvwTemplate.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvwTemplate_AfterCollapse);
            this.tvwTemplate.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvwTemplate_AfterExpand);
            this.tvwTemplate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwTemplate_AfterSelect);
            this.tvwTemplate.DoubleClick += new System.EventHandler(this.tvwTemplate_DoubleClick);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "File");
            this.imgList.Images.SetKeyName(1, "FolderOpen");
            this.imgList.Images.SetKeyName(2, "FolderClose");
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(188, 88);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "<<";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(188, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(54, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(188, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TemplateCodeGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 539);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TemplateCodeGenerator";
            this.Text = "TemplateCodeGenerator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TemplateCodeGenerator_FormClosed);
            this.Load += new System.EventHandler(this.TemplateCodeGenerator_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboDataBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentServer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.ListBox lstSelectedTable;
        private System.Windows.Forms.ListBox lstUnSelectedTable;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView tvwTemplate;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lstTemplate;
        private System.Windows.Forms.ImageList imgList;

    }
}