using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CodeGenius.Frame.Interface;
using LibraryGenius;

namespace CodeGenius.Frame
{
    public partial class BaseMainForm : Form, IMenuStripContainer
    {
        #region Singleton Pattern
        //单例模式（把构造方法私有化，外部代码不能直接实例化它）
        private static BaseMainForm frm = null;
        private BaseMainForm()
        {
            InitializeComponent();
        }

        public static BaseMainForm GetInstance()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new BaseMainForm();
            }
            return frm;
        }
        #endregion

        private readonly Dictionary<string, MenuStripHandler> dictMenuStripInvoke = new Dictionary<string, MenuStripHandler>();

        public Dictionary<string, MenuStripHandler> DictMenuStripInvoke
        {
            get { return dictMenuStripInvoke; }
        }

        public void AddMenuStripInvoke(string invokeKey, MenuStripHandler invoke)
        {
            if (DictMenuStripInvoke.ContainsKey(invokeKey))
                DictMenuStripInvoke[invokeKey] = invoke;
            else
                DictMenuStripInvoke.Add(invokeKey, invoke);
        }

        public void RemoveMenuStripInvoke(string invokeKey)
        {
            if (DictMenuStripInvoke.ContainsKey(invokeKey))
                DictMenuStripInvoke.Remove(invokeKey);
        }

        public void MenuStripClick(object sender, EventArgs e, string invokeKey)
        {
            if ((!string.IsNullOrEmpty(invokeKey)) && DictMenuStripInvoke.ContainsKey(invokeKey) && DictMenuStripInvoke[invokeKey] != null)
            {
                MenuStripHandler invoke = DictMenuStripInvoke[invokeKey];
                invoke.Invoke(sender, e);
            }
            else if (string.IsNullOrEmpty(invokeKey))
                MsgBox.ShowError("Key值无效!");
            else
                MsgBox.ShowError(string.Format("未能找到 {0} 的实现!", invokeKey));
        }


    }
}
