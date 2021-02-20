using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeGenius.CodeEngine;
using LibraryGenius;
using System.IO;
using CodeGenius.Entity;

namespace Test
{
    public partial class FrmT4Test : Form
    {
        string m_CatchPath=Application.StartupPath + "/T4Catch.txt";

        public FrmT4Test()
        {
            InitializeComponent();
        }

        private void FrmT4Test_Load(object sender, EventArgs e)
        {
            //if (File.Exists(m_CatchPath))
            //    rtxTemplate.Text = File.ReadAllText(m_CatchPath);
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            TemplateHost host = new TemplateHost();
            host.NameSpace = "TestNamespace";
            host.TableName = "TestTableName";
            //tbInfo.Folder = "";
            string m_ConnectionString = "server=.;database=test;uid=sa;pwd=123;";
            host.Columns = SqlSchemaHelper.ReadTableColumnSchema(m_ConnectionString, "Test", "Student");

            TemplateGenerator generator = new TemplateGenerator();
            string input = this.rtxTemplate.Text;
            this.rtxResult.Text= generator.Generate(input, host);
            if (string.IsNullOrEmpty(this.rtxResult.Text))
                this.rtxResult.Text = generator.ErrorMessage;

        }

        private void FrmT4Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.rtxTemplate.Text))
            {
                File.WriteAllText(m_CatchPath, this.rtxTemplate.Text);
            }
        }

    }
}
