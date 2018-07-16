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
    public partial class SUPPLIER_RECORDS : Form
    {
        Class1 c = new Class1();

        public SUPPLIER_RECORDS()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {

                string sql1 = "select supplierID as SupID,Sname as sName,IDproof as IDPROOF,sAddress as ADDRESS,sproduct as PRODUCT,sdate as Date from supplier where Sname like '" + textBox1.Text.Trim() + "%' or supplierID like'"+textBox1.Text+"%'";


                SqlDataAdapter da = new SqlDataAdapter(sql1, c.cnn);
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "temp");
                dataGridView1.DataSource = ds.Tables["temp"];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SUPPLIER_DETAILS f = new SUPPLIER_DETAILS();
            f.Show();
            this.Hide();
        }

        private void SUPPLIER_RECORDS_Load(object sender, EventArgs e)
        {
            
            string sql1 = "select supplierID as SupID,Sname as sName,IDproof as IDPROOF,sAddress as ADDRESS,sproduct as PRODUCT,sdate as Date from supplier";

            SqlDataAdapter da = new SqlDataAdapter(sql1, c.cnn);
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "temp");
            dataGridView1.DataSource = ds.Tables["temp"];
        }
    }
}
