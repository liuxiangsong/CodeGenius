using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenius.Component
{
    public class DbFolderTreeNode : DbTreeNode
    {
        public DbFolderTreeNode()
        {
            ImageKey = SelectedImageKey = "Folder";
        }
    }
}
