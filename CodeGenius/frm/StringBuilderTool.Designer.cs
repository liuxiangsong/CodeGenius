namespace CodeGenius
{
    partial class StringBuilderTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StringBuilderTool));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnChsToCht = new System.Windows.Forms.Button();
            this.btnChtToChs = new System.Windows.Forms.Button();
            this.btnClipboardFix = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtxBefore = new System.Windows.Forms.RichTextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.chkReverse = new System.Windows.Forms.CheckBox();
            this.txtSBObj = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtxAfter = new System.Windows.Forms.RichTextBox();
            this.btnTextCompare = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.btnTextCompare);
            this.splitContainer1.Panel1.Controls.Add(this.btnChsToCht);
            this.splitContainer1.Panel1.Controls.Add(this.btnChtToChs);
            this.splitContainer1.Panel1.Controls.Add(this.btnClipboardFix);
            this.splitContainer1.Panel1.Controls.Add(this.btnPaste);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.btnCopy);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenerate);
            this.splitContainer1.Panel1.Controls.Add(this.chkReverse);
            this.splitContainer1.Panel1.Controls.Add(this.txtSBObj);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1000, 517);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnChsToCht
            // 
            this.btnChsToCht.Location = new System.Drawing.Point(719, 14);
            this.btnChsToCht.Name = "btnChsToCht";
            this.btnChsToCht.Size = new System.Drawing.Size(75, 23);
            this.btnChsToCht.TabIndex = 8;
            this.btnChsToCht.Text = "简转繁";
            this.btnChsToCht.UseVisualStyleBackColor = true;
            this.btnChsToCht.Click += new System.EventHandler(this.btnChsToCht_Click);
            // 
            // btnChtToChs
            // 
            this.btnChtToChs.Location = new System.Drawing.Point(638, 14);
            this.btnChtToChs.Name = "btnChtToChs";
            this.btnChtToChs.Size = new System.Drawing.Size(75, 23);
            this.btnChtToChs.TabIndex = 8;
            this.btnChtToChs.Text = "繁转简";
            this.btnChtToChs.UseVisualStyleBackColor = true;
            this.btnChtToChs.Click += new System.EventHandler(this.btnChtToChs_Click);
            // 
            // btnClipboardFix
            // 
            this.btnClipboardFix.Location = new System.Drawing.Point(800, 13);
            this.btnClipboardFix.Name = "btnClipboardFix";
            this.btnClipboardFix.Size = new System.Drawing.Size(85, 23);
            this.btnClipboardFix.TabIndex = 7;
            this.btnClipboardFix.Text = "Clipboard Fix";
            this.btnClipboardFix.UseVisualStyleBackColor = true;
            this.btnClipboardFix.Click += new System.EventHandler(this.btnClipboardFix_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(521, 14);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(111, 23);
            this.btnPaste.TabIndex = 6;
            this.btnPaste.Text = "粘贴至待转化文本";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rtxBefore);
            this.groupBox1.Location = new System.Drawing.Point(3, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(994, 217);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "待转化文本";
            // 
            // rtxBefore
            // 
            this.rtxBefore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxBefore.Location = new System.Drawing.Point(3, 18);
            this.rtxBefore.Name = "rtxBefore";
            this.rtxBefore.Size = new System.Drawing.Size(988, 196);
            this.rtxBefore.TabIndex = 0;
            this.rtxBefore.Text = "";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(403, 14);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(111, 23);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "复制转换后的内容";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(321, 14);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "生成";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // chkReverse
            // 
            this.chkReverse.AutoSize = true;
            this.chkReverse.Location = new System.Drawing.Point(242, 18);
            this.chkReverse.Name = "chkReverse";
            this.chkReverse.Size = new System.Drawing.Size(72, 16);
            this.chkReverse.TabIndex = 2;
            this.chkReverse.Text = "反向生成";
            this.chkReverse.UseVisualStyleBackColor = true;
            // 
            // txtSBObj
            // 
            this.txtSBObj.Location = new System.Drawing.Point(135, 15);
            this.txtSBObj.Name = "txtSBObj";
            this.txtSBObj.Size = new System.Drawing.Size(100, 22);
            this.txtSBObj.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "StringBuilder对象名称：";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rtxAfter);
            this.groupBox2.Location = new System.Drawing.Point(3, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(994, 235);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "转化后";
            // 
            // rtxAfter
            // 
            this.rtxAfter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxAfter.Location = new System.Drawing.Point(3, 18);
            this.rtxAfter.Name = "rtxAfter";
            this.rtxAfter.Size = new System.Drawing.Size(988, 214);
            this.rtxAfter.TabIndex = 1;
            this.rtxAfter.Text = "";
            // 
            // btnTextCompare
            // 
            this.btnTextCompare.Location = new System.Drawing.Point(891, 13);
            this.btnTextCompare.Name = "btnTextCompare";
            this.btnTextCompare.Size = new System.Drawing.Size(85, 23);
            this.btnTextCompare.TabIndex = 9;
            this.btnTextCompare.Text = "文本对比";
            this.btnTextCompare.UseVisualStyleBackColor = true;
            this.btnTextCompare.Click += new System.EventHandler(this.btnTextCompare_Click);
            // 
            // StringBuilderTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 517);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StringBuilderTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StringBuilderTool";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtxBefore;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox chkReverse;
        private System.Windows.Forms.TextBox txtSBObj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtxAfter;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnClipboardFix;
        private System.Windows.Forms.Button btnChsToCht;
        private System.Windows.Forms.Button btnChtToChs;
        private System.Windows.Forms.Button btnTextCompare;
    }
}