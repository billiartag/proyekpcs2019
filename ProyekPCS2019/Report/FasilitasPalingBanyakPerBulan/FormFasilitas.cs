using Oracle.DataAccess.Client;
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

        OracleConnection conn = new OracleConnection();
        private void FormFasilitas_Load(object sender, EventArgs e)
        {
                        conn.ConnectionString = "User ID=proyek;Password=1;Data Source=orcl";
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.ConnectionString = "User ID=proyek;Password=1;Data Source=orcl";
                    conn.Open();
                }
                else
                {
                    conn.ConnectionString = "User ID=proyek;Password=1;Data Source=orcl";
                    conn.Open();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            comboBox1.Text = "May";
            DataFasilitas rep = new DataFasilitas();
            rep.SetDatabaseLogon("proyek", "1");
            /*
            rep.SetParameterValue("bulan", comboBox1.Text);
            rep.SetParameterValue("jenis_terbanyak", JenisKamarTerbanyak(comboBox1.Text));
            */
            crystalReportViewer1.ReportSource = rep;
        }
    }
}
