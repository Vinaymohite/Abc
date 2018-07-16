using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pet_Shop_Management
{
    public partial class SALARY_DETAILS : Form
    {
        Class1 c = new Class1();
        public SALARY_DETAILS()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {

                string sql1 = "select Employee_ID as Salary_ID,FName as NAME,Department as DEPARTMENT,Salary as SALARY,Total as TOTAL_AMOUNT,Payment as PAYMENT,Date as DATE_TIME from salary where Employee_ID like '" + textBox1.Text.Trim() + "' or FName like '" + textBox1.Text.Trim() + "%'";
                SqlDataAdapter da = new SqlDataAdapter(sql1, c.cnn);
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "temp");
                dataGridView1.DataSource = ds.Tables["temp"];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SALARY f = new SALARY();
            f.Show();
            this.Hide();
        }

        private void SALARY_DETAILS_Load(object sender, EventArgs e)
        {
           

                string sql1 = "select Employee_ID as Salary_ID,FName as NAME,Department as DEPARTMENT,Salary as SALARY,Total as TOTAL_AMOUNT,Payment as PAYMENT,Date as DATE_TIME from salary where Employee_ID like '" + textBox1.Text.Trim() + "' or FName like '" + textBox1.Text.Trim() + "%'";
                SqlDataAdapter da = new SqlDataAdapter(sql1, c.cnn);
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "temp");
                dataGridView1.DataSource = ds.Tables["temp"];
            }
        }
    }
