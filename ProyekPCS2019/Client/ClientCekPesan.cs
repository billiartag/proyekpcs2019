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

namespace ProyekPCS2019.Client
{
    public partial class ClientCekPesan : Form
    {
        string userID;
        OracleConnection conn;
        public ClientCekPesan(string user, OracleConnection cn)
        {
            conn = cn;
            userID = user;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainClient mc = new MainClient(userID);
            this.Hide();
            mc.ShowDialog();
            this.Close();
        }

        private void buttonCekBooking_Click(object sender, EventArgs e)
        {
            labelNoKamar.Text = "-";
            labelTanggalKeluar.Text = "-";
            labelTanggalMasuk.Text = "-";
            OracleDataAdapter od = new OracleDataAdapter("SELECT * FROM BOOKING WHERE KODE_BOOKING='"+textBoxKodeBooking.Text+"' AND ID_MEMBERSHIP='"+userID+"'", conn);
            DataTable dt = new DataTable();
            od.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                labelNoKamar.Text = dr.ItemArray[2].ToString();
                labelTanggalMasuk.Text = Convert.ToDateTime(dr.ItemArray[3].ToString()).ToShortDateString();
                labelTanggalKeluar.Text = Convert.ToDateTime(dr.ItemArray[4].ToString()).ToShortDateString();
            }
            else
            {
                MessageBox.Show("Maaf! Kode booking tidak dapat ditemukan, ");
            }

        }
    }
}
