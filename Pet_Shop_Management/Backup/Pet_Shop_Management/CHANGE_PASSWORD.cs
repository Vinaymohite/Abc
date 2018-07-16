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
    public partial class CHANGE_PASSWORD : Form
    {
        SqlCommand sqlcom;
        SqlDataReader sqldr;
        public CHANGE_PASSWORD()
        {
            InitializeComponent();
        }

        Class1 c = new Class1();

        private void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Clear();
            TextBox2.Clear();
            TextBox3.Clear();
           
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(c.cnn.State==ConnectionState.Open)
                c.cnn.Close();
            c.cnn.Open();

            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" )
            {
                MessageBox.Show("Fill the form properly", "Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                sqlcom = c.cnn.CreateCommand();
                sqlcom.CommandText = "select * from adlogin where AdmName='" + TextBox1.Text + "' and APassword='" + TextBox2.Text + "'";
                sqldr = sqlcom.ExecuteReader();
                if (sqldr.Read())
                {
                    if (c.cnn.State == ConnectionState.Open)
                        c.cnn.Close();
                    c.cnn.Open();
                    sqlcom = c.cnn.CreateCommand();
                    sqlcom.CommandText = "update adlogin set APassword='" + TextBox3.Text + "' where AdmName='" + TextBox1.Text + "'";
                    sqldr = sqlcom.ExecuteReader();
                    
                        TextBox1.Clear();
                        TextBox2.Clear();
                        TextBox3.Clear();
                    
                }
            }
        }
    }
}
