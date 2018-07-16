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
    public partial class CUSTOMER_DETAILS : Form
    {
        Class1 c = new Class1();

        public CUSTOMER_DETAILS()
        {
            InitializeComponent();
        }


        private void CUSTOMER_DETAILS_Load(object sender, EventArgs e)
        {
            string sql1 = "select * from customerdetails";

            SqlDataAdapter da = new SqlDataAdapter(sql1, c.cnn);
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "temp");
            DataGridView1.DataSource = ds.Tables["temp"];
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            if (textBox2.Text.Trim()!= "")
            {

                string sql1 = "select * from customerdetails where customerid like '" + textBox2.Text.Trim() + "' or Fname like '" + textBox2.Text.Trim() + "%'";


                SqlDataAdapter da = new SqlDataAdapter(sql1, c.cnn);
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "temp");
                DataGridView1.DataSource = ds.Tables["temp"];
            }
        }
               

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            CUSTOMER_REGISTER f = new CUSTOMER_REGISTER();
            f.Show();
            this.Hide();
        }
    }
}

       
    
