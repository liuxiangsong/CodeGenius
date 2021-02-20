using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CodeGenius.Frame.TreeNodeBase;
using System.Windows.Forms;

namespace CodeGenius.Frame.Interface
{
    /// <summary>
    /// 窗体导航栏 触发转向处理事件；
    /// </summary>
    public delegate void MenuStripHandler(object sender, EventArgs e);

    public interface IMenuStripItem
    {
        string Key { get; set; }
        string Caption { get; set; }
        int Order { get; set; }
        Image Image { get; set; }

        bool Enable(DbTreeNode node);
        bool Visible(DbTreeNode node);

        //MenuStripPanel MenuStripPanel { get; set; }
        MenuStripHandler MenuStripHandler { get; set; }

        void Initialize();
        ToolStripMenuItem GetUI(DbTreeNode node);
    }
}
