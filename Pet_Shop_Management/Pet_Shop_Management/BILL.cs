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
    public partial class BILL : Form
    {
        public BILL()
        {
            InitializeComponent();
        }

        Class1 c = new Class1();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void BILL_Load(object sender, EventArgs e)
        {
            if (c.cnn.State == ConnectionState.Open)
                c.cnn.Close();
            c.cnn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select customerid from customerdetails", c.cnn);
            DataSet sqldset = new DataSet();
            sqlda.Fill(sqldset, "temp");
            comboBox1.DataSource = sqldset.Tables["temp"];
            comboBox1.DisplayMember = sqldset.Tables["temp"].Columns["customerid"].ToString();
            comboBox1.ValueMember = sqldset.Tables["temp"].Columns["customerid"].ToString();
            comboBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerBill f = new CustomerBill();
            f.Show();
          //  Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
