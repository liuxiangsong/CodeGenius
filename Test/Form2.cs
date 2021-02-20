using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBHelper;
using System.Data.SqlClient;
using LibraryGenius;
using System.IO;
using System.Xml;

namespace Test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("s");
            dt.Rows.Add("1");
            ds.Tables.Add(dt);

       
            dataGridView3.DataSource = ds;
            gridControl1.DataSource = ds.Tables;
            ////Test();

            //Person p = new Person();
            //p.Name = "John";

            //Person p2 = new Person();
            //p2.Name = "John2";
            //List<Person> list=new List<Person>();
            //list.Add(p);
            //list.Add(p2);

            //List<Person> sd=list.FindAll(s => s.Name == "John");

            //MessageBox.Show("s");
            button2_Click(null, null);
        }

        private void Test()
        {
            Person p=new Person();
            p.Name="John";
            byte[] b = SerializationHelper.BinarySerialize<Person>(p);
            File.WriteAllBytes("d:/1.txt",b);

            Person p1 = SerializationHelper.BinaryDeserialize<Person>(File.ReadAllBytes("d:/1.txt"));
            MessageBox.Show(p1.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Execute();
        }

        private void Execute()
        {
            string connString = "server=.;Trusted_Connection=sspi;database='inser'";
            string sqlScript = @"
use [inser]
select  cstr.Name,
		cstr.create_date as CreateDate
from  sys.check_constraints as cstr
	inner join sys.tables as tb on cstr.parent_object_id=tb.object_id
Where SCHEMA_NAME(tb.schema_id)=@tableSchema and tb.name=@tableName
ORDER BY
[Name] ASC";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sqlScript;
                    cmd.Parameters.Add(new SqlParameter("@tableName", SqlDbType.NVarChar) { Value = "tb_dept" });
                    cmd.Parameters.Add(new SqlParameter("@tableSchema", SqlDbType.NVarChar) { Value = "dbo" });
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    { MessageBox.Show("sdf"); }
                }
            }

        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LibraryGenius.XmlHelper xml=new LibraryGenius.XmlHelper("D:\\1.xml");
            //xml.InsertNode("Test", "people","name1", "Jhon1");
          //XmlElement ele=  xml.InsertElementNode("/Test/Book", "C1123","innertssssssssssssext");
          XmlElement ele = xml.GetElement("/Test/Book");
          ele.InnerText = "sdf555dsdsdf";
          //ele.SetAttribute("as", "as");
          //xml.AddAttribute(ele, "sd", "sd");
            xml.Save();
        }
    }

    [Serializable]
    public class Person
    {
        public string Name { get; set; }
    }
}
