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
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }

        private void customerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            CUSTOMER_REGISTER f = new CUSTOMER_REGISTER();
            f.MdiParent = this;
            f.Show();
        }

   
        private void emplToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            EMPLOYEE_REGISTER f = new EMPLOYEE_REGISTER();
            f.MdiParent = this;
            f.Show();
        }

        private void MDI_Load(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                EmployeeToolStripMenuItem.Visible = true;
                sALARYToolStripMenuItem.Visible = true;

            }
            else
            {
                EmployeeToolStripMenuItem.Visible = false;
                sALARYToolStripMenuItem.Visible = false;
            }
        }

        private void EmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void employeeRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            EMPLOYEE_DETAILS f = new EMPLOYEE_DETAILS();
            f.MdiParent = this;
            f.Show();
        }

        private void customerRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            CUSTOMER_DETAILS f = new CUSTOMER_DETAILS();
            f.MdiParent = this;
            f.Show();
        }
                             
        
        private void SupplierToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            SUPPLIER_DETAILS f = new SUPPLIER_DETAILS();
            f.MdiParent = this;
            f.Show();
        }

        private void supplierToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            this.IsMdiContainer = true;
            SUPPLIER_RECORDS f = new SUPPLIER_RECORDS();
            f.MdiParent = this;
            f.Show();

        }

        private void customerDetailsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            CustomerReport f = new CustomerReport();
            f.MdiParent = this;
            f.Show();
        }

        private void salaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            SalaryReport f = new SalaryReport();
            f.MdiParent = this;
            f.Show();
        }

        private void ProductDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            PRODUCT f = new PRODUCT();
            f.MdiParent = this;
            f.Show();
        }

        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ProductDetails f = new ProductDetails();
            f.MdiParent = this;
            f.Show();
        }

        

        private void rEMAINDERDETAILSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            REMAINDER f = new REMAINDER();
            f.MdiParent = this;
            f.Show();
        
        }

        private void sALARYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            SALARY f = new SALARY();
            f.MdiParent = this;
            f.Show();
        }

        private void sALARYREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            SALARY_DETAILS f = new SALARY_DETAILS();
            f.MdiParent = this;
            f.Show();
        }

        private void nOTEPADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }

        private void cALCULATORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void employeeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            EmployeeReport f = new EmployeeReport();
            f.MdiParent = this;
            f.Show();
        }

        private void bILLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BILL f = new BILL();
            f.MdiParent = this;
            f.Show();
        }

        private void bILLREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            CustomerBill f = new CustomerBill();
            f.MdiParent = this;
            f.Show();
        }

        private void ChangeUserNameOrPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            CHANGE_PASSWORD f = new CHANGE_PASSWORD();
            f.MdiParent = this;
            f.Show();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            LOGIN f = new LOGIN();
            f.MdiParent = this;
            f.Show();
        }

       


        
    }
}
