using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pet_Shop_Management
{
    public partial class progress : Form
    {
        float lbl = 0.0f;

        public progress()
        {
            InitializeComponent();
            timer1.Start();
            label2.Text = "0% Completed";
            progressBar1.Maximum = 100000;
            progressBar1.Minimum = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            do
            {
                progressBar1.Value += 2000;
                lbl += (float)2.0;
                label2.Text = lbl + "% ";
                if (progressBar1.Value == 100000)
                {

                    label2.Text = "100";
                    this.Hide();
                    LOGIN frm = new LOGIN();
                    frm.Show();
                    timer1.Stop();
                }

            }
            while (progressBar1.Value < 10000);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void progress_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
