using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using DBHelper;
using System.IO;
using System.Data.SqlClient; 
using Microsoft.SqlServer.Management.Common;
using System.Data.Sql;
using System.Data.Common; 
using LibraryGenius;
using CodeGenius.Entity;
using Microsoft.VisualStudio.TextTemplating;
using System.CodeDom.Compiler;

namespace Test 
{
    public partial class Form1 : Form
    {
       //[Obsolete("Don't use Old method, use New method", true)]
       // public int ID
       // { get; set; }

 

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            if (Console.CapsLock == true)
            {
                toolStripStatusLabel1.Text = "True";
            }
            else
            { toolStripStatusLabel1.Text = "false"; }
        }

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "asdf;server=192.168.5.10;uid='mguser';pwd='mgpass';Trusted_Connection=sspi;";
            //textBox1.Text = "June 26, 1111";
            //textBox1.Text = ID.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
string t = File.ReadAllText("C:\\1.txt");
            string s = RazorEngine.Razor.Parse(t, new { Name = "Word" });
            MessageBox.Show(s);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
            //TemplateHost host = new TemplateHost();
            //Match match = Regex.Match(textBox1.Text, @"server=(.+?);");
           //textBox2.Text=Regex.Replace(textBox1.Text, @"server1=(.+?);", "@@");

           //Match match = Regex.Match(textBox1.Text, @"server=(.+?);");
           //if (match.Success)
           //{
           //    foreach (Group g in match.Groups)
           //    {
           //        MessageBox.Show(g.Value);
           //    }
           //}
         //   //Match match = Regex.Match(textBox1.Text, @"server=(.+?);");
         //   //Match match = Regex.Match(textBox1.Text, @"uid=\'(.+?)';");
         //   //Match match = Regex.Match(textBox1.Text, @"pwd=\'(.+?)';");
         //   //Match match = Regex.Match(textBox1.Text, @"Trusted_Connection=(.+?)");
         //   //if (match.Success)
         //   //{
         //   //    foreach (Group g in match.Groups)
         //   //    {
         //   //        MessageBox.Show(g.Value);
         //   //    }
         //   //}
         //   SqlHelper.SqlConnectionString = "server=.;Trusted_Connection=sspi;database='inser'";
         //   string str = string.Empty ;
         //   SQLDMO.SQLServer oServer = new SQLDMO.SQLServer();
         //   oServer.LoginSecure = true;
         //   oServer.Connect(".");
         //   SQLDMO._Database mydb = oServer.Databases.Item("inser", "owner");
         //   //SQLDMO.QueryResults qr = mydb. (richTextBox1.Text, null);

         //   //SQLDMO.QueryResults qr = oServer.ExecuteWithResultsAndMessages(richTextBox1.Text,null , out str);
         //   MessageBox.Show(str);
         //DataTable   dt= SqlHelper.GetDataTable(richTextBox1.Text );
         //if (dt is object)
         //{
         //    MessageBox.Show(dt.Rows.Count.ToString());
         //}
         //else
         //{ MessageBox.Show("dt isn't exists"); }
        }

   

        private void Form1_Load(object sender, EventArgs e)
        {
            NPOITest();
            //List<usersInfo> s = new List<usersInfo>();
            //SqlHelper.SqlConnectionString="server='192.168.5.10';database='blog';uid='mguser';pwd='mgpass';";
            //DataTable dt = SqlHelper.GetDataTable("select * from users");
            //s = TableToEntityList<usersInfo>.ConvertToEntity(typeof(usersInfo), dt);



           // SqlDataSourceEnumerator se = SqlDataSourceEnumerator.Instance;
           //DataTable dt =se.GetDataSources();
           //gridControl1.DataSource = dt;

            //string t = "Hello @Model.Name+sd! Welcome to Razor!";
            //string s = RazorEngine.Razor.Parse(t, new { Name = "Word." });
            //MessageBox.Show(s);

            //string tt = "dsdsd @for(var i = 0; i < Model.table.Rows.Count; i++){ @i }";
            //DataTable dt = new DataTable();
            //dt.Columns.Add("ID");
            //dt.Rows.Add(3);
            //string s = RazorEngine.Razor.Parse(tt, new { table = dt });
            //MessageBox.Show(s); 

            //DataTable dt = new DataTable();
            //dt.Columns.Add("ID");
            //ArrayList a = new ArrayList();
            //a.Add("1");
            //a.Add("2");
            //string tt = "@foreach(var col in Model.s){ @col}";
            //string s = RazorEngine.Razor.Parse(tt, new { s = dt.Columns });
            //MessageBox.Show(s); 
            
            //T4Create();
            //Application.Exit();
            //Button btn = (Button)(this.GetType().GetField("button1", System.Reflection.BindingFlags.NonPublic
            //    | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));
            //MessageBox.Show(btn.Text);
            //SQLDMO.SQLServer oServer = new SQLDMO.SQLServer();
            //oServer.LoginSecure = true;
            //oServer.Connect(".");
            //SQLDMO._Database mydb = oServer.Databases.Item("TDD", "owner");
            //SQLDMO._View myView = mydb.Views.Item("vwtesst", "dbo");
            //string s = myView.Script(SQLDMO.SQLDMO_SCRIPT_TYPE.SQLDMOScript_Default, null, SQLDMO.SQLDMO_SCRIPT2_TYPE.SQLDMOScript2_Default);

            //SQLDMO._Table myTable = mydb.Tables.Item("Bom_D", "dbo");
            //string s = myTable.Script(SQLDMO.SQLDMO_SCRIPT_TYPE.SQLDMOScript_Aliases, null, null, SQLDMO.SQLDMO_SCRIPT2_TYPE.SQLDMOScript2_ExtendedProperty);

            //SQLDMO = mydb.ExecuteWithResults(
            //string s = myTable.Script(SQLDMO.SQLDMO_SCRIPT_TYPE.SQLDMOScript_Aliases, null, null, SQLDMO.SQLDMO_SCRIPT2_TYPE.SQLDMOScript2_ExtendedProperty);

            //oServer.DisConnect();
            //richTextBox1.Text = s;

           // string connectionString="server='.';database='demosql';uid='sa';pwd='123';"; 
           // string m_TemplateFilePath = @"D:\C#\CodeGenius\CodeGenius\Template\ORMModel.cshtml";
           //string m_TemplateContext = string.Empty;
           // if (File.Exists(m_TemplateFilePath))
           //{
           //    TableInfo tbInfo = new TableInfo();
           //    tbInfo.TableName = "Purchase"; 
           //    tbInfo.NameSpace = "Lau";
           //    tbInfo.Folder = "1";  
           //    tbInfo.Columns = SqlSchemaHelper.ReadTableColumnSchema(connectionString, "DemoSQL", tbInfo.TableName);
           //    m_TemplateContext = File.ReadAllText(m_TemplateFilePath);
           //    try
           //    {
           //        RazorEngine.Razor.DefaultTemplateService.Namespaces.Add("CodeGenius.DBSchema");
           //        RazorEngine.Razor.DefaultTemplateService.Namespaces.Add("CodeGenius");
           //        RazorEngine.Razor.DefaultTemplateService.Namespaces.Add("LibraryGenius");
           //        string s = RazorEngine.Razor.Parse(m_TemplateContext, new { tableInfo = tbInfo });
           //        File.WriteAllText("D:\\1.cs", s);
           //        MessageBox.Show("生成成功");
           //    }
           //    catch (Exception ex)
           //    {
           //        MsgBox.ShowInformation(ex.Message);
           //    }
           ////    Application.Exit();
           //}
        }
         
        private void richEditControl1_SelectionChanged(object sender, EventArgs e)
        {
            DevExpress.XtraRichEdit.API.Native.DocumentRange range=richEditControl1.Document.Selection;

            richTextBox1.Text = richEditControl1.Document.GetText(range);            
            }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlHelper.Class1.CreateXmlDocument("as").Save("C:\\xml.xml");
            //File.WriteAllText("C://xml.xml", 
            MessageBox.Show("s");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //DBHelper.SqlHelper.SqlConnectionString="server='.';database='tdd';uid='sa';pwd='123'";
            //string sqlString = "select * from a123";
            //SqlParameter[] parameters = {new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
            //        };
            //parameters[0].Value = "where TableName like 's'";
            //gridControl1.DataSource = DBHelper.SqlHelper.ExecuteDataTable(sqlString);
      
        }

        private void NPOITest()
        {
            string path = @"C:\Users\13082602\Documents\11.xlsx";
            DataSet ds = new DataSet();
            ds.Tables.Add(NewTable());
            ds.Tables.Add(NewTable2());
            NPOIHelper.DataSetToExcel(path,ds,false);
            //NPOIHelper.DataTableToExcel(NewTable(), path);
        }

        private DataTable NewTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("sd");
            dt.Columns.Add("kk");
            dt.Rows.Add("s12121212", "k");
            dt.Rows.Add("k", "d");
            return dt;
        }

        private DataTable NewTable2()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("s1dsd");
            dt.Columns.Add("kdk");
            dt.Rows.Add("s1", "k11");
            dt.Rows.Add("k1", "d132");
            return dt;
        }

 
    }

    public class PerSon
    {
        public string name="asdf";
    }
}
