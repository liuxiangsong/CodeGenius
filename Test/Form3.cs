using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Test
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Hashtable table = new Hashtable();
            for (int i = 0; i < 3; i++)
            {
                table.Add("fileName" + i.ToString(), "version" + i.ToString());
            }
            this.treeList1.BeginUnboundLoad();
            foreach (DictionaryEntry v in table)
            {
                this.treeList1.AppendNode(new object[]{ v.Key,v.Value}, -1);
            }
            //for (int index = 0; index < table.Count; index++)
            //{
            //    this.treeList1.AppendNode(table[index], -1);
            //}
            this.treeList1.EndUnboundLoad();
        }
    }
}
