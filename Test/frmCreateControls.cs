using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;

namespace Test
{
    public partial class frmCreateControls : Form
    {
        DataTable dt = new DataTable();
        private static int tabIndex = 0;
        private static int TabIndex
        {
            get { return tabIndex++; }
        }
        public frmCreateControls()
        {
            InitializeComponent();
            dt.Columns.Add("fieldName");
            dt.Columns.Add("description");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form2 fr = new Form2();
            //fr.Show();
          //this.panel1.Controls.Add(this.CreateTextBox());
            //AddLabelTextBox("name", "姓名", new Point(44, 44));
            dt.Rows.Add("name", "姓名1：");
            dt.Rows.Add("ndame", "姓d名2：");
            dt.Rows.Add("nadme", "姓名d3：");
            dt.Rows.Add("naddme", "姓d名d4：");
            dt.Rows.Add("nadodme", "姓d名d5：");
            dt.Rows.Add("nadodme", "姓d名d5：");
            for (int i = 0; i < 33; i++)
            {
                dt.Rows.Add("nadodme", "姓d名d5：");
            }

            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            foreach (DataRow dr in dt.Rows)
            {
                AddLayoutControlItem(dr);
            }
            this.layoutControl1.ResumeLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            
        }
        private int layoutItemCount = 0;
        private void AddLayoutControlItem(DataRow dr)
        {
            int XLocation = (layoutItemCount % 2) * 245;
            int YLocation = (layoutItemCount / 2) * 24;
            LayoutControlItem layoutControlItem = new LayoutControlItem();
            layoutControlItem.Control = this.CreateTextBox(dr["fieldName"].ToString());
            layoutControlItem.CustomizationFormText = dr["description"].ToString();
            layoutControlItem.Location = new System.Drawing.Point(XLocation, YLocation);
            layoutControlItem.Name = dr["fieldName"].ToString();
            layoutControlItem.Size = new System.Drawing.Size(245, 24);
            layoutControlItem.Text = dr["description"].ToString();  
            layoutControlItem.TextSize = new System.Drawing.Size(105, 14);
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
             layoutControlItem });
            layoutItemCount++;
        }

        //private void AddTextBoxToLayout(string fieldName,string description)
        //{
        //    LayoutControlItem layoutControlItem = new LayoutControlItem();
        //    ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
        //    //layoutControl1.SuspendLayout();
        //    //((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
        //    //((System.ComponentModel.ISupportInitialize)(layoutControlItem)).BeginInit();

        //    layoutControlItem.Control = this.CreateTextBox(fieldName);
        //    layoutControlItem.CustomizationFormText = description;
        //    //layoutControlItem.Location = new System.Drawing.Point(0, 0);
        //    layoutControlItem.Name = fieldName;
        //    layoutControlItem.Size = new System.Drawing.Size(60, 24);
        //    layoutControlItem.Text = description;
        //    layoutControlItem.TextSize = new System.Drawing.Size(105, 14);
        //    layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
        //     layoutControlItem });

        //    ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
        //   //layoutControl1.ResumeLayout(false);
        //   // ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
        //   // ((System.ComponentModel.ISupportInitialize)(layoutControlItem)).EndInit(); 
        //   // this.ResumeLayout(false);
        //}

        private TextBox CreateTextBox(string fieldName)
        {
            TextBox txt = new TextBox();
            //txt.Location = location;
            txt.Name = "txt" + fieldName;
           txt.Size = new System.Drawing.Size(100, 21);
            txt.TabIndex = TabIndex;
            return txt;
        }


    }
}
