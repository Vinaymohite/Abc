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
    public partial class ProductDetails : Form
    {
        Class1 c = new Class1();

        public ProductDetails()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {

                string sql1 = "select ProductID as ID,PName as NAME,PType as Type,Quantity as Quantity,Price as Price from Product where ProductID like '" + textBox1.Text.Trim() + "' or PName like '" + textBox1.Text.Trim() + "%'";



                SqlDataAdapter da = new SqlDataAdapter(sql1, c.cnn);
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "temp");
                dataGridView1.DataSource = ds.Tables["temp"];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PRODUCT f = new PRODUCT();
            f.Show();
            this.Hide();
        
        }

        private void ProductDetails_Load(object sender, EventArgs e)
        {
            string sql1 = "select * from Product";

            SqlDataAdapter da = new SqlDataAdapter(sql1, c.cnn);
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "temp");
            dataGridView1.DataSource = ds.Tables["temp"];
        }
    }
}
