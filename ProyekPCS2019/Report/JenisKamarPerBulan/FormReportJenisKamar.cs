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

namespace ProyekPCS2019.Report.JenisKamarPerBulan
{
    public partial class FormReportJenisKamar : Form
    {
        OracleConnection conn = new OracleConnection();
        public FormReportJenisKamar()
        {
            InitializeComponent();
        }

        private void FormReportJenisKamar_Load(object sender, EventArgs e)
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
            ReportJenisKamar rep = new ReportJenisKamar();
            rep.SetDatabaseLogon("proyek", "1");
            rep.SetParameterValue("bulan", comboBox1.Text);
            rep.SetParameterValue("jenis_terbanyak", JenisKamarTerbanyak(comboBox1.Text));
            crystalReportViewer1.ReportSource = rep;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
        public string JenisKamarTerbanyak(string bulan)
        {
            string hasilcmd = "";
            conn.Open();
            OracleCommand cmd = new OracleCommand("JENIS_KAMAR_TERBANYAK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            OracleParameter hasil = new OracleParameter();
            hasil.Direction = ParameterDirection.ReturnValue;
            hasil.OracleDbType = OracleDbType.Varchar2;
            hasil.Size = 50;
            cmd.Parameters.Add(hasil);

            OracleParameter input = new OracleParameter();
            input.Value = bulan;
            input.Direction = ParameterDirection.Input;
            input.OracleDbType = OracleDbType.Varchar2;
            input.Size = 50;
            cmd.Parameters.Add(input);

            cmd.ExecuteNonQuery();
            hasilcmd = hasil.Value.ToString();
            conn.Close();
            return hasilcmd;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportJenisKamar rep = new ReportJenisKamar();
            rep.SetDatabaseLogon("proyek", "1");
            rep.SetParameterValue("bulan", comboBox1.Text);
            rep.SetParameterValue("jenis_terbanyak", JenisKamarTerbanyak(comboBox1.Text));
            crystalReportViewer1.ReportSource = rep;
        }
    }
}
