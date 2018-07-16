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
    public partial class USER_LOGIN : Form
    {
        SqlCommand sqlcom;
        SqlDataReader sqldr;

        Class1 c = new Class1();
        public USER_LOGIN()
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
                sqlcom.CommandText = "select * from userlogin where uName ='" + txtus.Text + "' and uPassword ='" + txtpsw.Text + "'";
                sqldr = sqlcom.ExecuteReader();
                if (sqldr.Read())
                {
                    MDI frm = new MDI();
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

        private void USER_LOGIN_Load(object sender, EventArgs e)
        {

        }
    }
}
