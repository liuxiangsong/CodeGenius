namespace CodeGenius
{
    partial class SingleCodeGenerator
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtContain = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTable = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDataBase = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentServer = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cboCondition = new System.Windows.Forms.ComboBox();
            this.btnSetConditon = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInverse = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSubfolder = new System.Windows.Forms.TextBox();
            this.txtTLN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbLFThreeTier = new System.Windows.Forms.RadioButton();
            this.gbxLFTwoTier = new System.Windows.Forms.GroupBox();
            this.chkVBProcedure = new System.Windows.Forms.CheckBox();
            this.chkVBMiddle = new System.Windows.Forms.CheckBox();
            this.chkVBModel = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtSaveFilePath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCS = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkCSDALCommon = new System.Windows.Forms.CheckBox();
            this.chkCSBLL = new System.Windows.Forms.CheckBox();
            this.chkCSDAL = new System.Windows.Forms.CheckBox();
            this.chkCSModel = new System.Windows.Forms.CheckBox();
            this.tabPageVB = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rbLFTwoTier = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.gbxLFTwoTier.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageCS.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPageVB.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtContain);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboTable);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboDataBase);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblCurrentServer);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 70);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select DataBase";
            // 
            // txtContain
            // 
            this.txtContain.Location = new System.Drawing.Point(128, 43);
            this.txtContain.Name = "txtContain";
            this.txtContain.Size = new System.Drawing.Size(76, 22);
            this.txtContain.TabIndex = 6;
            this.txtContain.TextChanged += new System.EventHandler(this.cboDataBase_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Table Name Contain:";
            // 
            // cboTable
            // 
            this.cboTable.DisplayMember = "name";
            this.cboTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTable.FormattingEnabled = true;
            this.cboTable.Location = new System.Drawing.Point(306, 43);
            this.cboTable.Name = "cboTable";
            this.cboTable.Size = new System.Drawing.Size(121, 20);
            this.cboTable.TabIndex = 4;
            this.cboTable.ValueMember = "name";
            this.cboTable.SelectedIndexChanged += new System.EventHandler(this.cboTable_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Table:";
            // 
            // cboDataBase
            // 
            this.cboDataBase.DisplayMember = "name";
            this.cboDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataBase.FormattingEnabled = true;
            this.cboDataBase.Location = new System.Drawing.Point(306, 15);
            this.cboDataBase.Name = "cboDataBase";
            this.cboDataBase.Size = new System.Drawing.Size(121, 20);
            this.cboDataBase.TabIndex = 2;
            this.cboDataBase.ValueMember = "name";
            this.cboDataBase.SelectedIndexChanged += new System.EventHandler(this.cboDataBase_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Database:";
            // 
            // lblCurrentServer
            // 
            this.lblCurrentServer.AutoSize = true;
            this.lblCurrentServer.Location = new System.Drawing.Point(45, 18);
            this.lblCurrentServer.Name = "lblCurrentServer";
            this.lblCurrentServer.Size = new System.Drawing.Size(77, 12);
            this.lblCurrentServer.TabIndex = 0;
            this.lblCurrentServer.Text = "Current Server:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(13, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(584, 257);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Table Info";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(578, 236);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGenerate);
            this.groupBox3.Controls.Add(this.cboCondition);
            this.groupBox3.Controls.Add(this.btnSetConditon);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.btnInverse);
            this.groupBox3.Controls.Add(this.btnSelectAll);
            this.groupBox3.Location = new System.Drawing.Point(16, 327);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(581, 57);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Operation";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(518, 20);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(57, 23);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cboCondition
            // 
            this.cboCondition.DisplayMember = "name";
            this.cboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondition.FormattingEnabled = true;
            this.cboCondition.Location = new System.Drawing.Point(370, 23);
            this.cboCondition.Name = "cboCondition";
            this.cboCondition.Size = new System.Drawing.Size(116, 20);
            this.cboCondition.TabIndex = 5;
            this.cboCondition.ValueMember = "name";
            // 
            // btnSetConditon
            // 
            this.btnSetConditon.Location = new System.Drawing.Point(234, 21);
            this.btnSetConditon.Name = "btnSetConditon";
            this.btnSetConditon.Size = new System.Drawing.Size(130, 23);
            this.btnSetConditon.TabIndex = 3;
            this.btnSetConditon.Text = "Set To Condition Field";
            this.btnSetConditon.UseVisualStyleBackColor = true;
            this.btnSetConditon.Click += new System.EventHandler(this.btnSetConditon_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(143, 21);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(57, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnSelectOperation);
            // 
            // btnInverse
            // 
            this.btnInverse.Location = new System.Drawing.Point(79, 21);
            this.btnInverse.Name = "btnInverse";
            this.btnInverse.Size = new System.Drawing.Size(57, 23);
            this.btnInverse.TabIndex = 1;
            this.btnInverse.Text = "Inverse ";
            this.btnInverse.UseVisualStyleBackColor = true;
            this.btnInverse.Click += new System.EventHandler(this.btnSelectOperation);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(16, 21);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(57, 23);
            this.btnSelectAll.TabIndex = 0;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectOperation);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtClassName);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtSubfolder);
            this.groupBox4.Controls.Add(this.txtTLN);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(16, 384);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(581, 82);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Parameter Set";
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(124, 48);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(100, 22);
            this.txtClassName.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "Class Name:";
            // 
            // txtSubfolder
            // 
            this.txtSubfolder.Location = new System.Drawing.Point(380, 15);
            this.txtSubfolder.Name = "txtSubfolder";
            this.txtSubfolder.Size = new System.Drawing.Size(100, 22);
            this.txtSubfolder.TabIndex = 4;
            // 
            // txtTLN
            // 
            this.txtTLN.Location = new System.Drawing.Point(124, 15);
            this.txtTLN.Name = "txtTLN";
            this.txtTLN.Size = new System.Drawing.Size(100, 22);
            this.txtTLN.TabIndex = 3;
            this.txtTLN.Text = "Lab";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "Top-level Namespace:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "SubFolder Name:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbLFThreeTier);
            this.groupBox6.Location = new System.Drawing.Point(11, 13);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(563, 44);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Framework Select";
            // 
            // rbLFThreeTier
            // 
            this.rbLFThreeTier.AutoSize = true;
            this.rbLFThreeTier.Checked = true;
            this.rbLFThreeTier.Location = new System.Drawing.Point(16, 20);
            this.rbLFThreeTier.Name = "rbLFThreeTier";
            this.rbLFThreeTier.Size = new System.Drawing.Size(82, 16);
            this.rbLFThreeTier.TabIndex = 2;
            this.rbLFThreeTier.TabStop = true;
            this.rbLFThreeTier.Text = "LFThreeTier";
            this.rbLFThreeTier.UseVisualStyleBackColor = true;
            // 
            // gbxLFTwoTier
            // 
            this.gbxLFTwoTier.Controls.Add(this.chkVBProcedure);
            this.gbxLFTwoTier.Controls.Add(this.chkVBMiddle);
            this.gbxLFTwoTier.Controls.Add(this.chkVBModel);
            this.gbxLFTwoTier.Location = new System.Drawing.Point(6, 53);
            this.gbxLFTwoTier.Name = "gbxLFTwoTier";
            this.gbxLFTwoTier.Size = new System.Drawing.Size(571, 54);
            this.gbxLFTwoTier.TabIndex = 7;
            this.gbxLFTwoTier.TabStop = false;
            this.gbxLFTwoTier.Text = " ";
            // 
            // chkVBProcedure
            // 
            this.chkVBProcedure.AutoSize = true;
            this.chkVBProcedure.Checked = true;
            this.chkVBProcedure.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVBProcedure.Location = new System.Drawing.Point(262, 22);
            this.chkVBProcedure.Name = "chkVBProcedure";
            this.chkVBProcedure.Size = new System.Drawing.Size(71, 16);
            this.chkVBProcedure.TabIndex = 2;
            this.chkVBProcedure.Text = "Procedure";
            this.chkVBProcedure.UseVisualStyleBackColor = true;
            // 
            // chkVBMiddle
            // 
            this.chkVBMiddle.AutoSize = true;
            this.chkVBMiddle.Checked = true;
            this.chkVBMiddle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVBMiddle.Location = new System.Drawing.Point(147, 22);
            this.chkVBMiddle.Name = "chkVBMiddle";
            this.chkVBMiddle.Size = new System.Drawing.Size(87, 16);
            this.chkVBMiddle.TabIndex = 1;
            this.chkVBMiddle.Text = "Middle Layer";
            this.chkVBMiddle.UseVisualStyleBackColor = true;
            // 
            // chkVBModel
            // 
            this.chkVBModel.AutoSize = true;
            this.chkVBModel.Checked = true;
            this.chkVBModel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVBModel.Location = new System.Drawing.Point(31, 22);
            this.chkVBModel.Name = "chkVBModel";
            this.chkVBModel.Size = new System.Drawing.Size(84, 16);
            this.chkVBModel.TabIndex = 0;
            this.chkVBModel.Text = "Model Layer";
            this.chkVBModel.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnBrowse);
            this.groupBox8.Controls.Add(this.txtSaveFilePath);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Location = new System.Drawing.Point(13, 620);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(584, 40);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "File SavePath";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(504, 13);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(57, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtSaveFilePath
            // 
            this.txtSaveFilePath.BackColor = System.Drawing.SystemColors.Window;
            this.txtSaveFilePath.Location = new System.Drawing.Point(71, 15);
            this.txtSaveFilePath.Name = "txtSaveFilePath";
            this.txtSaveFilePath.ReadOnly = true;
            this.txtSaveFilePath.Size = new System.Drawing.Size(427, 22);
            this.txtSaveFilePath.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "File Path:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageCS);
            this.tabControl1.Controls.Add(this.tabPageVB);
            this.tabControl1.Location = new System.Drawing.Point(16, 472);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(591, 142);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPageCS
            // 
            this.tabPageCS.Controls.Add(this.groupBox5);
            this.tabPageCS.Controls.Add(this.groupBox6);
            this.tabPageCS.Location = new System.Drawing.Point(4, 22);
            this.tabPageCS.Name = "tabPageCS";
            this.tabPageCS.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCS.Size = new System.Drawing.Size(583, 116);
            this.tabPageCS.TabIndex = 0;
            this.tabPageCS.Text = "C#";
            this.tabPageCS.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkCSDALCommon);
            this.groupBox5.Controls.Add(this.chkCSBLL);
            this.groupBox5.Controls.Add(this.chkCSDAL);
            this.groupBox5.Controls.Add(this.chkCSModel);
            this.groupBox5.Location = new System.Drawing.Point(11, 56);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(563, 54);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = " ";
            // 
            // chkCSDALCommon
            // 
            this.chkCSDALCommon.AutoSize = true;
            this.chkCSDALCommon.Location = new System.Drawing.Point(331, 22);
            this.chkCSDALCommon.Name = "chkCSDALCommon";
            this.chkCSDALCommon.Size = new System.Drawing.Size(121, 16);
            this.chkCSDALCommon.TabIndex = 3;
            this.chkCSDALCommon.Text = "DAL Common Class";
            this.chkCSDALCommon.UseVisualStyleBackColor = true;
            // 
            // chkCSBLL
            // 
            this.chkCSBLL.AutoSize = true;
            this.chkCSBLL.Checked = true;
            this.chkCSBLL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCSBLL.Location = new System.Drawing.Point(238, 22);
            this.chkCSBLL.Name = "chkCSBLL";
            this.chkCSBLL.Size = new System.Drawing.Size(76, 16);
            this.chkCSBLL.TabIndex = 2;
            this.chkCSBLL.Text = "BLL Layer";
            this.chkCSBLL.UseVisualStyleBackColor = true;
            // 
            // chkCSDAL
            // 
            this.chkCSDAL.AutoSize = true;
            this.chkCSDAL.Checked = true;
            this.chkCSDAL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCSDAL.Location = new System.Drawing.Point(147, 22);
            this.chkCSDAL.Name = "chkCSDAL";
            this.chkCSDAL.Size = new System.Drawing.Size(77, 16);
            this.chkCSDAL.TabIndex = 1;
            this.chkCSDAL.Text = "DAL Layer";
            this.chkCSDAL.UseVisualStyleBackColor = true;
            // 
            // chkCSModel
            // 
            this.chkCSModel.AutoSize = true;
            this.chkCSModel.Checked = true;
            this.chkCSModel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCSModel.Location = new System.Drawing.Point(31, 22);
            this.chkCSModel.Name = "chkCSModel";
            this.chkCSModel.Size = new System.Drawing.Size(84, 16);
            this.chkCSModel.TabIndex = 0;
            this.chkCSModel.Text = "Model Layer";
            this.chkCSModel.UseVisualStyleBackColor = true;
            // 
            // tabPageVB
            // 
            this.tabPageVB.Controls.Add(this.groupBox7);
            this.tabPageVB.Controls.Add(this.gbxLFTwoTier);
            this.tabPageVB.Location = new System.Drawing.Point(4, 22);
            this.tabPageVB.Name = "tabPageVB";
            this.tabPageVB.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVB.Size = new System.Drawing.Size(583, 116);
            this.tabPageVB.TabIndex = 1;
            this.tabPageVB.Text = "VB";
            this.tabPageVB.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rbLFTwoTier);
            this.groupBox7.Location = new System.Drawing.Point(7, 8);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(570, 44);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Framework Select";
            // 
            // rbLFTwoTier
            // 
            this.rbLFTwoTier.AutoSize = true;
            this.rbLFTwoTier.Checked = true;
            this.rbLFTwoTier.Location = new System.Drawing.Point(33, 19);
            this.rbLFTwoTier.Name = "rbLFTwoTier";
            this.rbLFTwoTier.Size = new System.Drawing.Size(76, 16);
            this.rbLFTwoTier.TabIndex = 2;
            this.rbLFTwoTier.TabStop = true;
            this.rbLFTwoTier.Text = "LFTwoTier";
            this.rbLFTwoTier.UseVisualStyleBackColor = true;
            // 
            // SingleCodeGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 672);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SingleCodeGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SingleCodeGenerator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SingleCodeGenerator_FormClosed);
            this.Load += new System.EventHandler(this.SingleCodeGenerator_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.gbxLFTwoTier.ResumeLayout(false);
            this.gbxLFTwoTier.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageCS.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPageVB.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboDataBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentServer;
        private System.Windows.Forms.TextBox txtContain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnInverse;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.ComboBox cboCondition;
        private System.Windows.Forms.Button btnSetConditon;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSubfolder;
        private System.Windows.Forms.TextBox txtTLN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox gbxLFTwoTier;
        private System.Windows.Forms.CheckBox chkVBProcedure;
        private System.Windows.Forms.CheckBox chkVBMiddle;
        private System.Windows.Forms.CheckBox chkVBModel;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtSaveFilePath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbLFThreeTier;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCS;
        private System.Windows.Forms.TabPage tabPageVB;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton rbLFTwoTier;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkCSBLL;
        private System.Windows.Forms.CheckBox chkCSDAL;
        private System.Windows.Forms.CheckBox chkCSModel;
        private System.Windows.Forms.CheckBox chkCSDALCommon;
    }
}