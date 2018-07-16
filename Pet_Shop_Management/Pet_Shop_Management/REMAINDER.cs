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
    public partial class REMAINDER : Form
    {
        SqlDataReader sqldr;
        SqlCommand sqlcom;
        string p,sql1, CI, z;
        int rowNo,n;
        Class1 c = new Class1();
        public REMAINDER()
        {
            InitializeComponent();
        }

        public void clear()
        {
            TextBox9.Clear();
            TextBox7.Clear();
            TextBox15.Clear();
            TextBox13.Clear();
            TextBox11.Clear();
            TextBox10.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void REMAINDER_Load(object sender, EventArgs e)
        {
            if (c.cnn.State == ConnectionState.Open)
                c.cnn.Close();
            c.cnn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select distinct(rdate) from remainder where delivery_status ='Pending'", c.cnn);
            DataSet dset = new DataSet();
            sqlda.Fill(dset, "temp");
            comboBox2.DataSource = dset.Tables["temp"];
            comboBox2.DisplayMember = dset.Tables["temp"].Columns["rdate"].ToString();
            comboBox2.ValueMember = dset.Tables["temp"].Columns["rdate"].ToString();
            comboBox2.SelectedIndex = -1;

            }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void comboBox2_Validating(object sender, CancelEventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (c.cnn.State == ConnectionState.Open)
                    c.cnn.Close();
                c.cnn.Open();
                sqlcom = c.cnn.CreateCommand();
                sqlcom.CommandText = "select * from remainder where rdate ='" + comboBox2.SelectedValue + "' and delivery_status ='Pending'";
                sqldr = sqlcom.ExecuteReader();
                if (sqldr.Read())
                {
                    z = sqldr.GetString(0);
                    CI = sqldr.GetString(1);
                    TextBox9.Text = sqldr.GetString(2);
                    TextBox10.Text = sqldr.GetString(3);
                    TextBox11.Text = sqldr.GetString(4);
                    comboBox1.Text = sqldr.GetString(5);
                    TextBox13.Text = sqldr.GetString(6);
                    TextBox7.Text = sqldr.GetString(7);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error1" + ex);
            }

            try
            {
                if (c.cnn.State == ConnectionState.Open)
                    c.cnn.Close();
                c.cnn.Open();
                sqlcom = c.cnn.CreateCommand();
                sqlcom.CommandText = "select count(CustID) from remainder where rdate ='" + comboBox2.SelectedValue + "' and delivery_status = 'Pending'";
                sqldr = sqlcom.ExecuteReader();
                if (sqldr.Read())
                {
                    TextBox15.Text = sqldr.GetInt32(0).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error2" + ex);
            }
        }
                
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (c.cnn.State == ConnectionState.Open)
                    c.cnn.Close();
                c.cnn.Open();
                sqlcom = c.cnn.CreateCommand();
                sqlcom.CommandText = "update remainder set delivery_status='" + comboBox1.SelectedItem + "', delivery_boy='" + TextBox13.Text + "',phone_no='" + TextBox7.Text + "' where custname='" + TextBox9.Text + "'";
                sqldr = sqlcom.ExecuteReader();
                if (sqldr.Read())
                {
                    MessageBox.Show("record updated Successfuly", "Remainder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                clear();
                REMAINDER_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
           clear();
            REMAINDER_Load(null,null);
        }

       private void button2_Click(object sender, EventArgs e)
        {

            if (c.cnn.State == ConnectionState.Open)
                c.cnn.Close();
            c.cnn.Open();
           string sql1 = "select * from remainder";

            SqlDataAdapter da = new SqlDataAdapter(sql1, c.cnn);
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "temp");
            dataGridView1.DataSource = ds.Tables["temp"];
            c.cnn.Close();
       }

       private void TextBox15_TextChanged(object sender, EventArgs e)
       {

       }

       private void TextBox13_TextChanged(object sender, EventArgs e)
       {

       }

       private void TextBox7_TextChanged(object sender, EventArgs e)
       {

       }

       private void button3_Click(object sender, EventArgs e)
       {
           this.Hide();
       }
    }
}
