using ProyekPCS2019.Report.FasilitasPalingBanyakPerBulan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyekPCS2019.Report.FasilitasPalingBanyakPerBulan
{
    public partial class FormFasilitas : Form
    {
        public FormFasilitas()
        {
            InitializeComponent();
        }

        private void FormFasilitas_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            comboBox1.Text = "May";
            DataFasilitas rep = new DataFasilitas();
            rep.SetDatabaseLogon("proyek", "1");
            rep.SetParameterValue("bulan", comboBox1.Text);
            crystalReportViewer1.ReportSource = rep;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataFasilitas rep = new DataFasilitas();
            rep.SetDatabaseLogon("proyek", "1");
            rep.SetParameterValue("bulan", comboBox1.Text);
            crystalReportViewer1.ReportSource = rep;
        }
    }
}
