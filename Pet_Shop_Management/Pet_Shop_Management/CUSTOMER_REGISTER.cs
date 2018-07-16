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
    public partial class CUSTOMER_REGISTER : Form
    {
        //public static SqlConnection sqlcon;
        public static SqlCommand sqlcom;
        public static SqlDataReader sqldr;
        Class1 c = new Class1();
        public string product, p, g;
        int n = 0;

        void clear()
        {
            if (c.cnn.State == ConnectionState.Open)
                c.cnn.Close();
            c.cnn.Open();
            sqlcom = c.cnn.CreateCommand();
            sqlcom.CommandText = "select max(customerid) from customerdetails";
            sqldr = sqlcom.ExecuteReader();

            if (sqldr.Read())
            {
                g = sqldr.GetString(0);
            }
            txtcid.Text = Convert.ToString(1 + Convert.ToInt32(g));

            c.cnn.Close();
            txtnm.Text = "";
            txtph.Text = "";
            txtadd.Text = "";
            textBox2.Text = "";
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            
            RadioButton1.Checked = false;
            RadioButton2.Checked = false;
            textBox1.Text = "";
            btnupdt.Enabled = false;
            btndel.Enabled = false;
        }
        public CUSTOMER_REGISTER()
        {
            InitializeComponent();
        }

        private void btnnxt_Click(object sender, EventArgs e)
        {
           
           SqlDataAdapter adp;
            DataSet ds;
            DataRow dr;
            DataTable dt;
            adp = new SqlDataAdapter("select * from customerdetails", c.cnn);
            ds = new DataSet();
            adp.Fill(ds, "temp");
            dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["customerid"] };

            if (n < (dt.Rows.Count - 1))
            {
                n = n + 1;
            }

            dr = dt.Rows[n];
            
            if (dr != null)
            {
                txtcid.Text = dr[0].ToString();
                txtnm.Text = dr[1].ToString();
                txtph.Text = dr[2].ToString();
                txtadd.Text = dr[3].ToString();

                if (Convert.ToString(dr[4]).Trim() == "Delivered")
                    RadioButton1.Checked = true;
                else
                    if (Convert.ToString(dr[4]).Trim() == "Pending")
                        RadioButton2.Checked = true;
                textBox2.Text = dr[5].ToString();
                textBox3.Text = dr[6].ToString();
                textBox4.Text = dr[7].ToString();
                textBox5.Text = dr[8].ToString();

                btnupdt.Enabled = true;
                btndel.Enabled = true;
            }
            else MessageBox.Show("Not Found");

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtcid.Text.Trim() == "" || txtnm.Text.Trim() == "" || textBox3.Text=="" || textBox4.Text=="" || textBox5.Text=="" || textBox2.Text.Trim()=="" || txtph.Text.Trim() == "" || txtadd.Text.Trim() == "" || (RadioButton1.Checked == false && RadioButton2.Checked == false))
            {
                MessageBox.Show("Fill The Form Completly");
            }
            else
            {
                string p, z;
                p = "Null";
                z = "Null";

                if (c.cnn.State == ConnectionState.Open)
                    c.cnn.Close();
                c.cnn.Open();

                string product;
                if (RadioButton1.Checked == true) product = "Delivered"; else product = "Pending";
                try
                {
                    string sqlstmt = "insert into customerdetails(customerid,Fname,phoneno,AddressP,product_Status,product_name,quantity,mode,amount) values ('" + txtcid.Text + "','" + txtnm.Text + "','" + txtph.Text + "','" + txtadd.Text + "','" + product + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";

                    SqlCommand cmd = new SqlCommand(sqlstmt, c.cnn);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Inserted Successfuly ", "Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    c.cnn.Close();
                }
                catch(Exception ex)
                {

                    MessageBox.Show("Invalid Entry"+ex);
                           
                }
                if (RadioButton2.Checked)
                {
                    try
                    {
                        if (c.cnn.State == ConnectionState.Open)
                            c.cnn.Close();
                        c.cnn.Open();
                        sqlcom.Connection = c.cnn;
                        sqlcom = c.cnn.CreateCommand();
                        sqlcom.CommandText = "insert into remainder values('" + DateTime.Now.ToShortDateString() + "','" + txtcid.Text + "','" + txtnm.Text + "','" + txtph.Text + "','" + textBox2.Text + "','" + product + "','" + p + "','" + z + "')";
                        sqlcom.ExecuteNonQuery();
                        c.cnn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex);
                    }
                }
                clear();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (c.cnn.State == ConnectionState.Open)
                c.cnn.Close();
            c.cnn.Open();

            SqlDataAdapter adp;
            DataSet ds;
            DataRow dr;
            DataTable dt;
            adp = new SqlDataAdapter("select * from customerdetails", c.cnn);
            ds = new DataSet();
            adp.Fill(ds, "temp");
            dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["customerid"] };

            string id = textBox1.Text;
            dr = dt.Rows.Find(id);
            if (dr != null)
            {
                txtcid.Text = dr[0].ToString();
                txtnm.Text = dr[1].ToString();
                txtph.Text = dr[2].ToString();
                txtadd.Text = dr[3].ToString();
                
                if (Convert.ToString(dr[4]).Trim() == "Delivered")
                    RadioButton1.Checked = true;
                else
                    if (Convert.ToString(dr[4]).Trim() == "Pending")
                        RadioButton2.Checked = true;

                textBox2.Text = dr[5].ToString();
                textBox3.Text = dr[6].ToString();
                textBox4.Text = dr[7].ToString();
                textBox5.Text = dr[8].ToString();

                btnupdt.Enabled = true;
                btndel.Enabled = true;
            }
            else MessageBox.Show("Not Found");

        }

        private void btnupdt_Click(object sender, EventArgs e)
        {
            if (txtcid.Text.Trim() == "" || txtnm.Text.Trim() == "" || txtph.Text.Trim() == "" || txtadd.Text.Trim() == "" || (RadioButton1.Checked == false && RadioButton2.Checked == false) || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "")
            {
                MessageBox.Show("Fill The Form Completly");
            }
            else
            {
                if (c.cnn.State == ConnectionState.Open)
                    c.cnn.Close();
                c.cnn.Open();

                string product;
                if (RadioButton1.Checked == true) product = "Delivered"; else product = "Pending";

                string sqlstmt = "update customerdetails set customerid='" + txtcid.Text + "',Fname='" + txtnm.Text + "',phoneno='" + txtph.Text + "',AddressP='" + txtadd.Text + "',product_Status='" + product + "',product_name='" + textBox2.Text + "',quantity='" + textBox3.Text + "',mode='" + textBox4.Text + "',amount='" + textBox5.Text + "' where customerid='" + txtcid.Text + "'  ";

                SqlCommand cmd = new SqlCommand(sqlstmt, c.cnn);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfuly ", "Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clear();
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (txtcid.Text.Trim() == "" || txtnm.Text.Trim() == "" || txtph.Text.Trim() == "" || txtadd.Text.Trim() == "" || (RadioButton1.Checked == false && RadioButton2.Checked == false)|| textBox2.Text.Trim() == "" ||textBox3.Text.Trim() == "" ||textBox4.Text.Trim() == "" ||textBox5.Text.Trim() == "" )
            {
                MessageBox.Show("Fill The Form Completly");
            }
            else
            {
                if (c.cnn.State == ConnectionState.Open)
                    c.cnn.Close();
                c.cnn.Open();


                if (RadioButton1.Checked == true) product = "Delivered"; else product = "Pending";

                string sqlstmt = "delete from customerdetails where customerid='" + txtcid.Text + "'  ";

                SqlCommand cmd = new SqlCommand(sqlstmt, c.cnn);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfuly ", "Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clear();
            }
        }

        private void btnnw_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnfirst_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp;
            DataSet ds;
            DataRow dr;
            DataTable dt;
            adp = new SqlDataAdapter("select * from customerdetails", c.cnn);
            ds = new DataSet();
            adp.Fill(ds, "temp");
            dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["customerid"] };

            n = 0;

            dr = dt.Rows[n];
            
            if (dr != null)
            {
                txtcid.Text = dr[0].ToString();
                txtnm.Text = dr[1].ToString();
                txtph.Text = dr[2].ToString();
                txtadd.Text = dr[3].ToString();

                if (Convert.ToString(dr[4]).Trim() == "Delivered")
                    RadioButton1.Checked = true;
                else
                    if (Convert.ToString(dr[4]).Trim() == "Pending")
                        RadioButton2.Checked = true;
                textBox2.Text = dr[5].ToString();
                textBox3.Text = dr[6].ToString();
                textBox4.Text = dr[7].ToString();
                textBox5.Text = dr[8].ToString();
                btnupdt.Enabled = true;
                btndel.Enabled = true;
            }
            else MessageBox.Show("Not Found");

        }

        private void btnpre_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp;
            DataSet ds;
            DataRow dr;
            DataTable dt;
            adp = new SqlDataAdapter("select * from customerdetails", c.cnn);
            ds = new DataSet();
            adp.Fill(ds, "temp");
            dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["customerid"] };

            if (n > 0)
                n = n - 1;

            dr = dt.Rows[n];
           
            if (dr != null)
            {
                txtcid.Text = dr[0].ToString();
                txtnm.Text = dr[1].ToString();
                txtph.Text = dr[2].ToString();
                txtadd.Text = dr[3].ToString();

                if (Convert.ToString(dr[4]).Trim() == "Delivered")
                    RadioButton1.Checked = true;
                else
                    if (Convert.ToString(dr[4]).Trim() == "Pending")
                        RadioButton2.Checked = true;
                textBox2.Text = dr[5].ToString();
                textBox3.Text = dr[6].ToString();
                textBox4.Text = dr[7].ToString();
                textBox5.Text = dr[8].ToString();

                btnupdt.Enabled = true;
                btndel.Enabled = true;
            }
            else MessageBox.Show("Not Found");

        }

        private void btnlst_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp;
            DataSet ds;
            DataRow dr;
            DataTable dt;
            adp = new SqlDataAdapter("select * from customerdetails", c.cnn);
            ds = new DataSet();
            adp.Fill(ds, "temp");
            dt = ds.Tables["temp"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["customerid"] };

            n = (dt.Rows.Count - 1);
            dr = dt.Rows[n];
            if (dr != null)
            {
                txtcid.Text = dr[0].ToString();
                txtnm.Text = dr[1].ToString();
                txtph.Text = dr[2].ToString();
                txtadd.Text = dr[3].ToString();

                if (Convert.ToString(dr[4]).Trim() == "Delivered")
                    RadioButton1.Checked = true;
                else
                    if (Convert.ToString(dr[4]).Trim() == "Pending")
                        RadioButton2.Checked = true;

                textBox2.Text = dr[5].ToString();
                textBox3.Text = dr[6].ToString();
                textBox4.Text = dr[7].ToString();
                textBox5.Text = dr[8].ToString();

                btnupdt.Enabled = true;
                btndel.Enabled = true;
            }
            else MessageBox.Show("Not Found");

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CUSTOMER_Load(object sender, EventArgs e)
        {
            clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            CUSTOMER_DETAILS f = new CUSTOMER_DETAILS();
            f.Show();
            this.Hide();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtph_TextChanged(object sender, EventArgs e)
        {
            if (txtph.Text != "")
            {
                try
                {
                    int i = Convert.ToInt32(txtph.Text);
                }
                catch (Exception ex)
                {
                    txtph.Clear();
                }

            }
        }

        private void txtnm_TextChanged(object sender, EventArgs e)
        {
            if (txtnm.Text != "")
            {
                try
                {
                    int i = Convert.ToInt32(txtnm.Text);
                    txtnm.Clear();
                }
                catch (Exception ex)
                {
                    //txtph.Clear();
                    Console.Write("Error" + ex);
                }
            }

        }

        private void txtcid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

