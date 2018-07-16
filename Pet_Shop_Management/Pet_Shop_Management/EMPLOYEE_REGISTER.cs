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
    public partial class EMPLOYEE_REGISTER : Form
    {
        //public static SqlConnection sqlcon;
        public static SqlCommand sqlcom;
        public static SqlDataReader sqldr;
        Class1 c = new Class1();
        int n = 0;

        void clear()
        {

            SqlCommand cmd = new SqlCommand("select max(EmployeeID) as max from employeeregister ", c.cnn);
            SqlDataReader na;
            if (c.cnn.State == ConnectionState.Open)
                c.cnn.Close();
            c.cnn.Open();
            na = cmd.ExecuteReader();
            string str;
            if (na.Read())
            {
                str = na["max"].ToString();
                int max = 1 + Convert.ToInt32(str);
                textBox4.Text = max.ToString();

            }
            c.cnn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "..Select..";
            textBox5.Text = "";
            textBox6.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox7.Text = "";
            btnupdt.Enabled = false;
            btndel.Enabled = false;
        }
        
        public EMPLOYEE_REGISTER()
        {
            InitializeComponent();
            
        }            
           
          private void EMPLOYEE_REGISTER_Load(object sender, EventArgs e)
        {
            clear();

        }

        private void btnadd_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "..Select.." || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "" || (radioButton1.Checked == false && radioButton2.Checked == false))
            {
                MessageBox.Show("Fill The Form Completly");
            }
            else
            {
                if (c.cnn.State == ConnectionState.Open)
                    c.cnn.Close();
                c.cnn.Open();

                string gender;
                if (radioButton1.Checked == true) gender = "Male"; else gender = "Female";
                try
                {
                    string sqlstmt = "insert into employeeregister(FName,Phoneno,FAddress,AddressP,EmployeeID,Department,Salary,Gender) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + gender + "' )";

                    SqlCommand cmd = new SqlCommand(sqlstmt, c.cnn);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inserted Successfuly ", "Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    c.cnn.Close();
                    clear();
                }
                catch { MessageBox.Show("Invalid Entry"); }
            }
        }

        private void btnupdt_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "..Select.." || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "" || (radioButton1.Checked == false && radioButton2.Checked == false))
            {
                MessageBox.Show("Fill The Form Completly");
            }
            else
            {
                if (c.cnn.State == ConnectionState.Open)
                    c.cnn.Close();
                c.cnn.Open();

                string gender;
                if (radioButton1.Checked == true) gender = "Male"; else gender = "Female";

                string sqlstmt = "update employeeregister set FName='" + textBox1.Text + "',Phoneno='" + textBox2.Text + "',FAddress='" + textBox3.Text + "',AddressP='" + comboBox1.Text + "',Department='" + textBox5.Text + "',Salary='" + textBox6.Text + "',Gender='" + gender + "' where EmployeeID='" + textBox4.Text + "'  ";

                SqlCommand cmd = new SqlCommand(sqlstmt, c.cnn);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfuly ", "Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clear();
            }
        }

        private void btnnew_Click_1(object sender, EventArgs e)
        {
            clear();
        }

        private void btndel_Click(object sender, EventArgs e)
        {
             if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "..Select.." || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "" || (radioButton1.Checked == false && radioButton2.Checked == false))
            {
                MessageBox.Show("Fill The Form Completly");
            }
            else
            {
                if (c.cnn.State == ConnectionState.Open)
                    c.cnn.Close();
                c.cnn.Open();

                string sqlstmt = "delete from employeeregister where EmployeeID='" + textBox4.Text + "'  ";

                SqlCommand cmd = new SqlCommand(sqlstmt, c.cnn);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfuly ", "Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clear();
            }
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp;
            DataSet ds;
            DataRow dr;
            DataTable dt;
            adp = new SqlDataAdapter("select * from employeeregister", c.cnn);
            ds = new DataSet();
            adp.Fill(ds, "temp");
            dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["EmployeeID"] };

            string id = textBox7.Text;
            dr = dt.Rows.Find(id);
            if (dr != null)
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                comboBox1.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                textBox6.Text = dr[6].ToString();

                if (Convert.ToString(dr[7]).Trim() == "Male")
                    radioButton1.Checked = true;
                else
                    if (Convert.ToString(dr[7]).Trim() == "Female")
                        radioButton2.Checked = true;

                btnupdt.Enabled = true;
                btndel.Enabled = true;
            }
            else MessageBox.Show("Not Found");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp;
            DataSet ds;
            DataRow dr;
            DataTable dt;
            adp = new SqlDataAdapter("select * from employeeregister", c.cnn);
            ds = new DataSet();
            adp.Fill(ds, "temp");
            dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["EmployeeID"] };

            n = 0;

            dr = dt.Rows[n];
            if (dr != null)
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                comboBox1.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                textBox6.Text = dr[6].ToString();

                if (Convert.ToString(dr[7]).Trim() == "Male")
                    radioButton1.Checked = true;
                else
                    if (Convert.ToString(dr[7]).Trim() == "Female")
                        radioButton2.Checked = true;

                btnupdt.Enabled = true;
                btndel.Enabled = true;
            }
            else MessageBox.Show("Not Found");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp;
            DataSet ds;
            DataRow dr;
            DataTable dt;
            adp = new SqlDataAdapter("select * from employeeregister", c.cnn);
            ds = new DataSet();
            adp.Fill(ds, "temp");
            dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["EmployeeID"] };

            if (n < (dt.Rows.Count - 1))
            {
                n = n + 1;
            }

            dr = dt.Rows[n];
            if (dr != null)
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                comboBox1.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                textBox6.Text = dr[6].ToString();

                if (Convert.ToString(dr[7]).Trim() == "Male")
                    radioButton1.Checked = true;
                else
                    if (Convert.ToString(dr[7]).Trim() == "Female")
                        radioButton2.Checked = true;

                btnupdt.Enabled = true;
                btndel.Enabled = true;
            }
            else MessageBox.Show("Not Found");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp;
            DataSet ds;
            DataRow dr;
            DataTable dt;
            adp = new SqlDataAdapter("select * from employeeregister", c.cnn);
            ds = new DataSet();
            adp.Fill(ds, "temp");
            dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["EmployeeID"] };
            if (n > 0)
                n = n - 1;

            dr = dt.Rows[n];
            if (dr != null)
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                comboBox1.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                textBox6.Text = dr[6].ToString();

                if (Convert.ToString(dr[7]).Trim() == "Male")
                    radioButton1.Checked = true;
                else
                    if (Convert.ToString(dr[7]).Trim() == "Female")
                        radioButton2.Checked = true;

                btnupdt.Enabled = true;
                btndel.Enabled = true;
            }
            else MessageBox.Show("Not Found");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp;
            DataSet ds;
            DataRow dr;
            DataTable dt;
            adp = new SqlDataAdapter("select * from employeeregister", c.cnn);
            ds = new DataSet();
            adp.Fill(ds, "temp");
            dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["EmployeeID"] };


            n = (dt.Rows.Count - 1);
            dr = dt.Rows[n];
            if (dr != null)
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                comboBox1.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                textBox6.Text = dr[6].ToString();

                if (Convert.ToString(dr[7]).Trim() == "Male")
                    radioButton1.Checked = true;
                else
                    if (Convert.ToString(dr[7]).Trim() == "Female")
                        radioButton2.Checked = true;

                btnupdt.Enabled = true;
                btndel.Enabled = true;
            }
            else MessageBox.Show("Not Found");
            if (dr != null)
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                comboBox1.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                textBox6.Text = dr[6].ToString();

                if (Convert.ToString(dr[7]).Trim() == "Male")
                    radioButton1.Checked = true;
                else
                    if (Convert.ToString(dr[7]).Trim() == "Female")
                        radioButton2.Checked = true;

                btnupdt.Enabled = true;
                btndel.Enabled = true;
            }
            else MessageBox.Show("Not Found");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            EMPLOYEE_DETAILS f = new EMPLOYEE_DETAILS();
            f.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        }
        }

       

        
        



        
