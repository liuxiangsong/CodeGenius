namespace CodeGenius
{
    partial class Encryption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Encryption));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDES = new System.Windows.Forms.RadioButton();
            this.rbMD5 = new System.Windows.Forms.RadioButton();
            this.txtOriginalInfo = new System.Windows.Forms.TextBox();
            this.txtProcesstedValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbType2 = new System.Windows.Forms.RadioButton();
            this.rbType1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDES);
            this.groupBox1.Controls.Add(this.rbMD5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encrypt Mode";
            // 
            // rbDES
            // 
            this.rbDES.AutoSize = true;
            this.rbDES.Location = new System.Drawing.Point(113, 21);
            this.rbDES.Name = "rbDES";
            this.rbDES.Size = new System.Drawing.Size(44, 16);
            this.rbDES.TabIndex = 1;
            this.rbDES.Text = "DES";
            this.rbDES.UseVisualStyleBackColor = true;
            this.rbDES.CheckedChanged += new System.EventHandler(this.rbEncryptMode_CheckedChanged);
            // 
            // rbMD5
            // 
            this.rbMD5.AutoSize = true;
            this.rbMD5.Checked = true;
            this.rbMD5.Location = new System.Drawing.Point(39, 21);
            this.rbMD5.Name = "rbMD5";
            this.rbMD5.Size = new System.Drawing.Size(47, 16);
            this.rbMD5.TabIndex = 0;
            this.rbMD5.TabStop = true;
            this.rbMD5.Text = "MD5";
            this.rbMD5.UseVisualStyleBackColor = true;
            this.rbMD5.CheckedChanged += new System.EventHandler(this.rbEncryptMode_CheckedChanged);
            // 
            // txtOriginalInfo
            // 
            this.txtOriginalInfo.Location = new System.Drawing.Point(115, 133);
            this.txtOriginalInfo.Multiline = true;
            this.txtOriginalInfo.Name = "txtOriginalInfo";
            this.txtOriginalInfo.Size = new System.Drawing.Size(302, 100);
            this.txtOriginalInfo.TabIndex = 1;
            this.txtOriginalInfo.TextChanged += new System.EventHandler(this.txtEncryptInfo_TextChanged);
            this.txtOriginalInfo.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtOriginalInfo_DragDrop);
            this.txtOriginalInfo.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtOriginalInfo_DragEnter);
            // 
            // txtProcesstedValue
            // 
            this.txtProcesstedValue.Location = new System.Drawing.Point(115, 239);
            this.txtProcesstedValue.Name = "txtProcesstedValue";
            this.txtProcesstedValue.ReadOnly = true;
            this.txtProcesstedValue.Size = new System.Drawing.Size(302, 22);
            this.txtProcesstedValue.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Encrypt Info:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Processed Value:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbType2);
            this.groupBox2.Controls.Add(this.rbType1);
            this.groupBox2.Location = new System.Drawing.Point(12, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 42);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Type";
            // 
            // rbType2
            // 
            this.rbType2.AutoSize = true;
            this.rbType2.Location = new System.Drawing.Point(154, 15);
            this.rbType2.Name = "rbType2";
            this.rbType2.Size = new System.Drawing.Size(73, 16);
            this.rbType2.TabIndex = 1;
            this.rbType2.Text = "File\'s MD5";
            this.rbType2.UseVisualStyleBackColor = true;
            this.rbType2.CheckedChanged += new System.EventHandler(this.rbType_CheckedChanged);
            // 
            // rbType1
            // 
            this.rbType1.AutoSize = true;
            this.rbType1.Checked = true;
            this.rbType1.Location = new System.Drawing.Point(39, 15);
            this.rbType1.Name = "rbType1";
            this.rbType1.Size = new System.Drawing.Size(84, 16);
            this.rbType1.TabIndex = 0;
            this.rbType1.TabStop = true;
            this.rbType1.Text = "String\'s MD5";
            this.rbType1.UseVisualStyleBackColor = true;
            this.rbType1.CheckedChanged += new System.EventHandler(this.rbType_CheckedChanged);
            // 
            // Encryption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 266);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProcesstedValue);
            this.Controls.Add(this.txtOriginalInfo);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Encryption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Encryption";
            this.Load += new System.EventHandler(this.Encryption_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDES;
        private System.Windows.Forms.RadioButton rbMD5;
        private System.Windows.Forms.TextBox txtOriginalInfo;
        private System.Windows.Forms.TextBox txtProcesstedValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbType2;
        private System.Windows.Forms.RadioButton rbType1;
    }
}