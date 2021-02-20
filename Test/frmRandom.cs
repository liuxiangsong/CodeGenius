using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Test
{
    public partial class frmRandom : Form
    {
        DataTable dt = new DataTable();
        public frmRandom()
        {
            InitializeComponent();
        }

        private void frmRandom_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Num");
            dt.Columns.Add("Text");
            gridControl1.DataSource = dt;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Test1();
            //this.Test2();
            this.Test3();
        }

        private void Test1()
        {
            DateTime begin = DateTime.Now;
            int seed = 0;
            for (int i = 0; i < 20000; i++)
            {
                DataRow dr = dt.NewRow();
                Random rd = new Random(seed);
                seed = rd.Next();
                //dr[0] = seed;
                dr[0] = rd.NextDouble();
                dt.Rows.Add(dr);
            }
            MessageBox.Show(DateTime.Now.Subtract(begin).ToString());
        }

        private void Test2()
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] randomData = new byte[50];
            rng.GetBytes(randomData);
            richTextBox1.Text = BitConverter.ToString(randomData);
            
        }

        private void Test3()
        {
            int length=10;
            string possibles = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            char[] passwords = new char[length];
            Random rd = new Random();

            for (int i = 0; i < length; i++)
            {
                passwords[i] = possibles[rd.Next(0, possibles.Length)];
            }

            richTextBox1.Text = new string(passwords);
        }
    }
}
