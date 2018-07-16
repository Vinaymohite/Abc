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
    public partial class SALARY : Form
    {
        Class1 c = new Class1();

        void clear()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select EmployeeID from employeeregister", c.cnn);
            SqlCommandBuilder cbd = new SqlCommandBuilder(adp);
            DataSet ds = new DataSet();
            adp.Fill(ds, "temp");
            DataTable dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["EmployeeID"] };
            int i = 0;
            comboBox1.Items.Clear();
            while (i < dt.Rows.Count)
            {
                DataRow dr = dt.Rows[i];
                string row = "" + dr[0];
                comboBox1.Items.Add("" + row);
                i++;
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox2.Text = "";
        }

        public SALARY()
        {
            InitializeComponent();
        }

                private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = comboBox1.SelectedItem.ToString();
            string[] aa = a.Split('-');

            SqlDataAdapter adp = new SqlDataAdapter("select FName,Department,Salary from employeeregister where EmployeeID='" + aa[0].Trim() + "'", c.cnn);
            SqlCommandBuilder cbd = new SqlCommandBuilder(adp);
            DataSet ds = new DataSet();
            adp.Fill(ds, "temp");
            DataTable dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["EmployeeID"] };
            DataRow dr = dt.Rows[0];
            textBox2.Text = dr[0].ToString();
            textBox3.Text = dr[1].ToString();
            textBox4.Text = dr[2].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
            {
                if (c.cnn.State == ConnectionState.Open)
                    c.cnn.Close();
                c.cnn.Open();


                string sqlstmt = "insert into salary(Employee_ID,FName,Department,Salary,Total,Payment,Date) values ('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox1.Text + "','" + comboBox2.Text + "','" + textBox5.Text + "' )";

                SqlCommand cmd = new SqlCommand(sqlstmt, c.cnn);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted Successfuly ", "Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                c.cnn.Close();

            }
            else MessageBox.Show("Fill Complete Form ");
        }

        private void SALARY_Load(object sender, EventArgs e)
        {
            clear();
           textBox5.Text = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SALARY_DETAILS f = new SALARY_DETAILS();
            f.Show();
            this.Hide();

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                int i = Convert.ToInt32(textBox4.Text);
                int j = Convert.ToInt32(textBox6.Text);
                textBox1.Text = Convert.ToString(i - j);
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        }

        }
    