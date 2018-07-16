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
    public partial class PRODUCT : Form
    {
        //public static SqlConnection sqlcon;
        public static SqlCommand sqlcom;
        public static SqlDataReader sqldr;
        Class1 c = new Class1();
        //public string gender;
        int n = 0;
        void clear()
        {

            SqlCommand cmd = new SqlCommand("select max(ProductID) as max from product ", c.cnn);
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
                TextBox1.Text = max.ToString();

            }

            c.cnn.Close();
            ComboBox2.Text = "";
            ComboBox1.Text = "";
            TextBox3.Text = "";
            TextBox2.Text = "";
            textBox7.Text = "";
            btnupdt.Enabled = false;
            btndel.Enabled = false;
        }
        
        public PRODUCT()
        {
            InitializeComponent();
            sqlcom = new SqlCommand();

        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Trim() == "" || ComboBox2.Text.Trim() == "" || ComboBox1.Text.Trim() == "" || TextBox3.Text.Trim() == "" || TextBox2.Text.Trim() == "")
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
                    string sqlstmt = "insert into product(ProductID,PName,PType,Quantity,Price) values ('" + TextBox1.Text + "','" + ComboBox2.Text + "','" + ComboBox1.Text + "','" + TextBox3.Text + "','" + TextBox2.Text + "')";

                    SqlCommand cmd = new SqlCommand(sqlstmt, c.cnn);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inserted Successfuly ", "Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    c.cnn.Close();
                    clear();
                }
                catch { MessageBox.Show("Invalid Entry"); }
            }
        }

        private void btnupdt_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Trim() == "" || ComboBox2.Text.Trim() == "" || ComboBox1.Text.Trim() == "" || TextBox3.Text.Trim() == "" || TextBox2.Text.Trim() == "")
            {
                MessageBox.Show("Fill The Form Completly");
            }
            else
            {
                if (c.cnn.State == ConnectionState.Open)
                    c.cnn.Close();
                c.cnn.Open();


                string sqlstmt = "update product set PName='" + ComboBox2.Text + "',PType='" + ComboBox1.Text + "',Quantity='" + TextBox3.Text + "',Price='" + TextBox2.Text +"' where ProductID='" + TextBox1.Text + "'  ";

                SqlCommand cmd = new SqlCommand(sqlstmt, c.cnn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfuly ", "Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Trim() == "" || ComboBox2.Text.Trim() == "" || ComboBox1.Text.Trim() == "" || TextBox3.Text.Trim() == "" || TextBox2.Text.Trim() == "")
            {
                MessageBox.Show("Fill The Form Completly");
            }
            else
            {
                if (c.cnn.State == ConnectionState.Open)
                    c.cnn.Close();
                c.cnn.Open();



                string sqlstmt = "delete from product where ProductID='" + TextBox1.Text + "'  ";

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
            adp = new SqlDataAdapter("select * from product", c.cnn);
            ds = new DataSet();
            adp.Fill(ds, "temp");
            dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["ProductID"] };

            string id = textBox7.Text;
            dr = dt.Rows.Find(id);
            if (dr != null)
            {
                TextBox1.Text = dr[0].ToString();
                ComboBox2.Text = dr[1].ToString();
                ComboBox1.Text = dr[2].ToString();
                TextBox3.Text = dr[3].ToString();
                TextBox2.Text = dr[4].ToString();
                
                
                btnupdt.Enabled = true;
                btndel.Enabled = true;
            }
            else MessageBox.Show("Not Found");

        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void PRODUCT_Load(object sender, EventArgs e)
        {
            clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp;
            DataSet ds;
            DataRow dr;
            DataTable dt;
            adp = new SqlDataAdapter("select * from product", c.cnn);
            ds = new DataSet();
            adp.Fill(ds, "temp");
            dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["ProductID"] };

            string id = textBox7.Text;
            dr = dt.Rows.Find(id);
            n = 0;
            dr = dt.Rows[n];
            
            if (dr != null)
            {
                TextBox1.Text = dr[0].ToString();
                ComboBox2.Text = dr[1].ToString();
                ComboBox1.Text = dr[2].ToString();
                TextBox3.Text = dr[3].ToString();
                TextBox2.Text = dr[4].ToString();


                btnupdt.Enabled = true;
                btndel.Enabled = true;
            }
            else MessageBox.Show("Not Found");

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp;
            DataSet ds;
            DataRow dr;
            DataTable dt;
            adp = new SqlDataAdapter("select * from product", c.cnn);
            ds = new DataSet();
            adp.Fill(ds, "temp");
            dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["ProductID"] };

            string id = textBox7.Text;
            dr = dt.Rows.Find(id);
            if (n < (dt.Rows.Count - 1))
            {
                n = n + 1;
            }

            dr = dt.Rows[n];
            if (dr != null)
            {
                TextBox1.Text = dr[0].ToString();
                ComboBox2.Text = dr[1].ToString();
                ComboBox1.Text = dr[2].ToString();
                TextBox3.Text = dr[3].ToString();
                TextBox2.Text = dr[4].ToString();


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
            adp = new SqlDataAdapter("select * from product", c.cnn);
            ds = new DataSet();
            adp.Fill(ds, "temp");
            dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["ProductID"] };

            string id = textBox7.Text;
            dr = dt.Rows.Find(id);
            if (n > 0)
                n = n - 1;

            dr = dt.Rows[n];
            if (dr != null)
            {
                TextBox1.Text = dr[0].ToString();
                ComboBox2.Text = dr[1].ToString();
                ComboBox1.Text = dr[2].ToString();
                TextBox3.Text = dr[3].ToString();
                TextBox2.Text = dr[4].ToString();


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
            adp = new SqlDataAdapter("select * from product", c.cnn);
            ds = new DataSet();
            adp.Fill(ds, "temp");
            dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["ProductID"] };

            string id = textBox7.Text;
            dr = dt.Rows.Find(id);
            n = (dt.Rows.Count - 1);
            dr = dt.Rows[n];
            if (dr != null)
            {
                TextBox1.Text = dr[0].ToString();
                ComboBox2.Text = dr[1].ToString();
                ComboBox1.Text = dr[2].ToString();
                TextBox3.Text = dr[3].ToString();
                TextBox2.Text = dr[4].ToString();


                btnupdt.Enabled = true;
                btndel.Enabled = true;
            }
            else MessageBox.Show("Not Found");

        }

        private void button10_Click(object sender, EventArgs e)
        {
            ProductDetails f = new ProductDetails();
            f.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
