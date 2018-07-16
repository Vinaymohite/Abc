using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace Pet_Shop_Management
{
    public partial class CustomerBill : Form
    {
        public CustomerBill()
        {
            InitializeComponent();
        }
        Class1 c = new Class1();

        private void CustomerBill_Load(object sender, EventArgs e)
        {
            if (c.cnn.State == ConnectionState.Open)
                c.cnn.Close();
            c.cnn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from customerdetails", c.cnn);
            ReportDocument rpdocument = new ReportDocument();
            string rppath = Application.StartupPath;
            rppath = rppath.Substring(0, rppath.LastIndexOf("bin"));
            rpdocument.Load(rppath + "Customerbillrpt.rpt");

            try
            {
                DataSet dsetSer = new DataSet();
                sqlda.Fill(dsetSer, "customerdetails");
                rpdocument.SetDataSource(dsetSer);
                crystalReportViewer1.ReportSource = rpdocument;

                string selctcust = Application.OpenForms["BILL"].Controls["comboBox1"].Text;

                if (selctcust != "")
                {
                    ParameterFields paramfields = new ParameterFields();
                    ParameterField pfcustID = new ParameterField();

                    pfcustID.ParameterFieldName = "paramCustID";
                    ParameterDiscreteValue discrit = new ParameterDiscreteValue();
                    discrit.Value = selctcust;
                    pfcustID.CurrentValues.Add(discrit);
                    paramfields.Add(pfcustID);
                }

                try
                {

                    crystalReportViewer1.SelectionFormula = "{customerdetails.customerid}='"+selctcust+"'";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error 5" + ex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }  
        }

}
