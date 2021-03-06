using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsApplication37
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select employeeid,firstname,lastname,homephone,notes from employees", @"data source=.\sqlexpress;initial catalog=northwind;integrated security=true");
            da.Fill(ds, "employees");
            if (radioButton1.Checked)
            {
                ds.WriteXml(textBox1.Text, XmlWriteMode.IgnoreSchema);
            }
            if (radioButton2.Checked)
            {
                ds.WriteXml(textBox1.Text, XmlWriteMode.WriteSchema);
            }
            if (radioButton3.Checked)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    row.SetModified();
                }
                ds.WriteXml(textBox1.Text, XmlWriteMode.DiffGram);
            }
            if (radioButton4.Checked)
            {
                ds.WriteXmlSchema(textBox1.Text);
            }
            if (checkBox1.Checked)
            {
                Process.Start(textBox1.Text);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}