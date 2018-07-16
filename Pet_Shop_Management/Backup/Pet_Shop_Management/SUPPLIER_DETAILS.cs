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
    public partial class SUPPLIER_DETAILS : Form
    {
        public static SqlCommand sqlcom;
        public static SqlDataReader sqldr;
        Class1 c = new Class1();
        int n;
        string p;
        void clear()
        {
            try
            {
                if (c.cnn.State == ConnectionState.Open)
                    c.cnn.Close();
                c.cnn.Open();
                sqlcom = c.cnn.CreateCommand();
                sqlcom.CommandText = "select max(supplierID) from supplier";
                sqldr = sqlcom.ExecuteReader();
                if (sqldr.Read())
                {
                    p = sqldr.GetString(0);
                }
                txtsupid.Text = Convert.ToString(1 + Convert.ToInt32(p));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            c.cnn.Close();
            textBox1.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";

            button3.Enabled = false;
            button4.Enabled = false;
        }

        public SUPPLIER_DETAILS()
        {
            InitializeComponent();
            sqlcom = new SqlCommand();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp;
            DataSet ds;
            DataRow dr;
            DataTable dt;
            adp = new SqlDataAdapter("select * from supplier", c.cnn);
            ds = new DataSet();
            adp.Fill(ds, "temp");
            dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["supplierID"] };

            string id = textBox6.Text;
            dr = dt.Rows.Find(id);
            if (dr != null)
            {
                txtsupid.Text = dr[0].ToString();
                textBox1.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox2.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                textBox7.Text = dr[6].ToString();
                button3.Enabled = true;
                button4.Enabled = true;
            }
            else MessageBox.Show("Not Found");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtsupid.Text.Trim() == "" || textBox1.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox7.Text.Trim() == "")
            {
                MessageBox.Show("Fill The Form Completly");
            }
            else
            {
                if (c.cnn.State == ConnectionState.Open)
                    c.cnn.Close();
                c.cnn.Open();

                try
                {
                    string sqlstmt = "insert into supplier(supplierID,Sname,IDproof,phoneNO,Saddress,Sproduct,Sdate) values ('" + txtsupid.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox7.Text + "')";

                    SqlCommand cmd = new SqlCommand(sqlstmt, c.cnn);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Inserted Successfuly ", "Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    c.cnn.Close();

                    clear();
                }
                catch { MessageBox.Show("Invalid Entry"); }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtsupid.Text.Trim() == "" || textBox1.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox7.Text.Trim() == "")
            {
                MessageBox.Show("Fill The Form Completly");
            }
            else
            {
                if (c.cnn.State == ConnectionState.Open)
                    c.cnn.Close();
                c.cnn.Open();

                string sqlstmt = "update supplier set Sname='" + textBox1.Text + "',IDproof='" + textBox3.Text + "',phoneNO='" + textBox2.Text + "',Saddress='" + textBox4.Text + "',Sproduct='" + textBox5.Text + "',Sdate='" + textBox7.Text + "' where supplierID='" + txtsupid.Text + "' ";
                SqlCommand cmd = new SqlCommand(sqlstmt, c.cnn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Updated Successfuly ", "Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtsupid.Text.Trim() == "" || textBox1.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox7.Text.Trim() == "")
            {
                MessageBox.Show("Fill The Form Completly");
            }
            else
            {
                if (c.cnn.State == ConnectionState.Open)
                    c.cnn.Close();
                c.cnn.Open();

                //string gender;
                //if (radioButton1.Checked == true) gender = "Male"; else gender = "Female";

                string sqlstmt = "delete from supplier where Sname='" + textBox1.Text + "'  ";

                SqlCommand cmd = new SqlCommand(sqlstmt, c.cnn);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfuly ", "Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clear();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void SUPPLIER_DETAILS_Load(object sender, EventArgs e)
        {
            clear();
            textBox7.Text = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp;
            DataSet ds;
            DataRow dr;
            DataTable dt;
            adp = new SqlDataAdapter("select * from supplier", c.cnn);
            ds = new DataSet();
            adp.Fill(ds, "temp");
            dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["supplierID"] };

            n = 0;

            dr = dt.Rows[n];
            if (dr != null)
            {
                txtsupid.Text = dr[0].ToString();
                textBox1.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox2.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                textBox7.Text = dr[6].ToString();
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp;
            DataSet ds;
            DataRow dr;
            DataTable dt;
            adp = new SqlDataAdapter("select * from supplier", c.cnn);
            ds = new DataSet();
            adp.Fill(ds, "temp");
            dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["supplierID"] };

            if (n < dt.Rows.Count - 1)
                n = n + 1;

            dr = dt.Rows[n];
            if (dr != null)
            {
                txtsupid.Text = dr[0].ToString();
                textBox1.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox2.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                textBox7.Text = dr[6].ToString();
                button3.Enabled = true;
                button4.Enabled = true;
            }
            }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp;
            DataSet ds;
            DataRow dr;
            DataTable dt;
            adp = new SqlDataAdapter("select * from supplier", c.cnn);
            ds = new DataSet();
            adp.Fill(ds, "temp");
            dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["supplierID"] };

            if (n > 0)
                n = n - 1;

            dr = dt.Rows[n];
            if (dr != null)
            {
                txtsupid.Text = dr[0].ToString();
                textBox1.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox2.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                textBox7.Text = dr[6].ToString();
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp;
            DataSet ds;
            DataRow dr;
            DataTable dt;
            adp = new SqlDataAdapter("select * from supplier", c.cnn);
            ds = new DataSet();
            adp.Fill(ds, "temp");
            dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["supplierID"] };

            n = dt.Rows.Count - 1;

            dr = dt.Rows[n];
            if (dr != null)
            {
                txtsupid.Text = dr[0].ToString();
                textBox1.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox2.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                textBox7.Text = dr[6].ToString();
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SUPPLIER_RECORDS f = new SUPPLIER_RECORDS();
            f.Show();
            this.Hide();
        
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
