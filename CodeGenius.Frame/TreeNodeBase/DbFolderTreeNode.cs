using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenius.Frame.TreeNodeBase
{
    public class DbFolderTreeNode : DbTreeNode
    {
        public DbFolderTreeNode()
        {
            ImageKey = SelectedImageKey = "Folder";
        }
    }
}
