using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace ProyekPCS2019.Report.BulanTerbaikPenjualan
{
    public partial class FormBulanTerbaik : Form
    {
        public FormBulanTerbaik()
        {
            InitializeComponent();
        }
        OracleConnection conn = new OracleConnection();

        private void FormBulanTerbaik_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            //nama
            cmd.CommandText = "";


            BulanTerbaik rep = new BulanTerbaik();
            rep.SetDatabaseLogon("proyek", "1");
            rep.SetParameterValue("bulan", TransaksiTerbanyak());
            crystalReportViewer1.ReportSource = rep;
        }

        public string TransaksiTerbanyak()
        {
            string hasilcmd = "";
            conn.Open();
            OracleCommand cmd = new OracleCommand("TRANSAKSI_TERBANYAK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            OracleParameter hasil = new OracleParameter();
            hasil.Direction = ParameterDirection.ReturnValue;
            hasil.OracleDbType = OracleDbType.Varchar2;
            hasil.Size = 50;
            cmd.Parameters.Add(hasil);

            cmd.ExecuteNonQuery();
            hasilcmd = hasil.Value.ToString();
            conn.Close();
            return hasilcmd;
        }

        private void crystalReportViewer1_ReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
        {
            crystalReportViewer1.ParameterFieldInfo[0].DefaultValues.AddValue(TransaksiTerbanyak());
        }
    }
}
