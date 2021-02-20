using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibraryGenius; 

namespace CodeGenius
{
    public partial class Encryption : Form
    {
        public Encryption()
        {
            InitializeComponent();
        }

        #region Radio Button Checked Changed Event
        private void rbEncryptMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMD5.Checked == true)
            {
                rbType1.Text = "String's MD5";
                rbType2.Text = "File's MD5";
            }
            else
            {
                rbType1.Text = "Encrypt";
                rbType2.Text = "Decrypt";
            }
            this.rbType_CheckedChanged(null, null);
        }

        private void rbType_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMD5.Checked == true && rbType2.Checked == true)
            {
                txtOriginalInfo.AllowDrop = true;
                txtOriginalInfo.ReadOnly = true;
            }
            else
            {
                txtOriginalInfo.AllowDrop = false;
                txtOriginalInfo.ReadOnly = false;
            }
            txtOriginalInfo.Text = string.Empty;
        }
        #endregion

        #region txtEncryptInfo TextChanged Event
        private void txtEncryptInfo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOriginalInfo.Text) == true)
            {
                txtProcesstedValue.Text = string.Empty;
                return;
            }
            if (rbMD5.Checked == true)
            {
                if (rbType1.Checked == true)
                {
                    txtProcesstedValue.Text = MD5Encrypt.TextEncrypt(txtOriginalInfo.Text);
                }
                else
                {
                    txtProcesstedValue.Text = MD5Encrypt.FileEncrypt(txtOriginalInfo.Text);
                }
            }
            else
            {
                if (rbType1.Checked == true)
                {
                    txtProcesstedValue.Text = DESEncrypt.Encrypt(txtOriginalInfo.Text);
                }
                else
                {
                    txtProcesstedValue.Text = DESEncrypt.Decrypt(txtOriginalInfo.Text);
                }
            }
        }
        #endregion

        #region txtOriginalInfo drag Event
        private void txtOriginalInfo_DragDrop(object sender, DragEventArgs e)
        {
            String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                txtOriginalInfo.Text = files[0];
            }
        }

        private void txtOriginalInfo_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }
        #endregion

        private void Encryption_Load(object sender, EventArgs e)
        {

        }
    }
}
