namespace Test
{
    partial class frmHotKeysTest
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
            this.btnRegist = new System.Windows.Forms.Button();
            this.btnUnRegist = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRegist
            // 
            this.btnRegist.Location = new System.Drawing.Point(125, 54);
            this.btnRegist.Name = "btnRegist";
            this.btnRegist.Size = new System.Drawing.Size(75, 23);
            this.btnRegist.TabIndex = 0;
            this.btnRegist.Text = "注冊";
            this.btnRegist.UseVisualStyleBackColor = true;
            this.btnRegist.Click += new System.EventHandler(this.btnRegist_Click);
            // 
            // btnUnRegist
            // 
            this.btnUnRegist.Location = new System.Drawing.Point(125, 103);
            this.btnUnRegist.Name = "btnUnRegist";
            this.btnUnRegist.Size = new System.Drawing.Size(75, 23);
            this.btnUnRegist.TabIndex = 0;
            this.btnUnRegist.Text = "注銷";
            this.btnUnRegist.UseVisualStyleBackColor = true;
            this.btnUnRegist.Click += new System.EventHandler(this.btnUnRegist_Click);
            // 
            // frmHotKeysTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnUnRegist);
            this.Controls.Add(this.btnRegist);
            this.Name = "frmHotKeysTest";
            this.Text = "frmHotKeysTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRegist;
        private System.Windows.Forms.Button btnUnRegist;
    }
}