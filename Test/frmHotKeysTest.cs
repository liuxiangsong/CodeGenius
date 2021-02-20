using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibraryGenius;

namespace Test
{
    public partial class frmHotKeysTest : Form
    {
        HotKeys h = new HotKeys();

        public frmHotKeysTest()
        {
            InitializeComponent();
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            //这里注册了Ctrl+Alt+E 快捷键
            h.Regist(this.Handle, (int)HotKeys.HotkeyModifiers.Control + (int)HotKeys.HotkeyModifiers.Alt, Keys.E, CallBack);
            MessageBox.Show("注册成功");
        }

        private void btnUnRegist_Click(object sender, EventArgs e)
        {
            h.UnRegist(this.Handle, CallBack);
            MessageBox.Show("卸载成功");
        }

        protected override void WndProc(ref Message m)
        {
            //窗口消息处理函数
            h.ProcessHotKey(m);
            base.WndProc(ref m);
        }

        //按下快捷键时被调用的方法
        public void CallBack()
        {
            MessageBox.Show("快捷键被调用！");
        }
    }
}
