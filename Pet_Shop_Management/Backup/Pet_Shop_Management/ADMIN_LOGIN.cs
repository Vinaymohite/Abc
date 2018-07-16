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
    public partial class ADMIN_LOGIN : Form
    {
        SqlCommand sqlcom;
        SqlDataReader sqldr;
        Class1 c = new Class1();

        public ADMIN_LOGIN()
        {
            InitializeComponent();
            sqlcom = new SqlCommand();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (c.cnn.State == ConnectionState.Open)
                c.cnn.Close();
            c.cnn.Open();
            if (txtpsw.Text == "" || txtpsw.Text == "")
            {
                MessageBox.Show("Please Enter the Valid UserName and Password", "LogIn", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                sqlcom = c.cnn.CreateCommand();
                sqlcom.CommandText = "select * from adlogin where AdmName ='" + txtus.Text + "' and APassword ='" + txtpsw.Text + "'";
                sqldr = sqlcom.ExecuteReader();
                if (sqldr.Read())
                {
                    MDI frm = new MDI();
                    frm.Controls["textBox1"].Text = txtpsw.Text;
                    this.Hide();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Please Enter the Valid UserName and Password", "LogIn", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ADMIN_LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void txtus_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void txtpsw_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
