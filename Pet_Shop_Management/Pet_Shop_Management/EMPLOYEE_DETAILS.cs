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
    public partial class EMPLOYEE_DETAILS : Form
    {
        Class1 c = new Class1();

        public EMPLOYEE_DETAILS()
        {
            InitializeComponent();
        }

             private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {

                string sql1 = "select EmployeeID as ID,FName as NAME,Phoneno as PHONENO,FAddress as ADDRESS,AddressP as ADDRESSPROOF,Department as DEPARTMENT,Salary as SALARY,Gender as GENDER from employeeregister where EmployeeID like '" + textBox1.Text.Trim() + "' or FName like '" + textBox1.Text.Trim() + "%'";


                SqlDataAdapter da = new SqlDataAdapter(sql1, c.cnn);
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "temp");
                dataGridView1.DataSource = ds.Tables["temp"];
            }
        }

             private void EMPLOYEE_DETAILS_Load(object sender, EventArgs e)
             {
                 string sql1 = "select EmployeeID as ID,FName as NAME,Phoneno as PHONENO,FAddress as ADDRESS,AddressP as ADDRESSPROOF,Department as DEPARTMENT,Salary as SALARY,Gender as GENDER from employeeregister";

                 SqlDataAdapter da = new SqlDataAdapter(sql1, c.cnn);
                 SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                 DataSet ds = new DataSet();
                 da.Fill(ds, "temp");
                 dataGridView1.DataSource = ds.Tables["temp"];
             }

             private void button1_Click(object sender, EventArgs e)
             {
                 EMPLOYEE_REGISTER f = new EMPLOYEE_REGISTER();
                 f.Show();
                 this.Hide();
             }
    }
}
