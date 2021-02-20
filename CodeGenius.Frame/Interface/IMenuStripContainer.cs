using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenius.Frame.Interface
{
    public interface IMenuStripContainer
    {
        Dictionary<string, MenuStripHandler> DictMenuStripInvoke { get; }
        //void InitMenuStrip();
        void AddMenuStripInvoke(string invokeKey, MenuStripHandler invoke);
        void RemoveMenuStripInvoke(string invokeKey);
        void MenuStripClick(object sender, EventArgs e, string invokeKey);
    }
}
