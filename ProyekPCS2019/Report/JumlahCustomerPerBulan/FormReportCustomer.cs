using ProyekPCS2019.Report.JumlahCustomerPerBulan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyekPCS2019.Report.Jumlah_Customer_Per_Bulan
{
    public partial class FormReportCustomer : Form
    {
        public FormReportCustomer()
        {
            InitializeComponent();
        }

        private void FormReportCustomer_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            comboBox1.Text = "May";
            ReportCustomer rep = new ReportCustomer();
            rep.SetDatabaseLogon("proyek", "1");
            rep.SetParameterValue("bulan", comboBox1.Text);
            crystalReportViewer1.ReportSource = rep;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportCustomer rep = new ReportCustomer();
            rep.SetDatabaseLogon("proyek", "1");
            rep.SetParameterValue("bulan", comboBox1.Text);
            crystalReportViewer1.ReportSource = rep;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
