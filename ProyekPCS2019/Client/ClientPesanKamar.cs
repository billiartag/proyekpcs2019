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
    public partial class ClientPesanKamar : Form
    {
        OracleConnection conn;
        string userID;
        DataTable listJenisKamar = new DataTable();
        string harga_kamar = "";
        public ClientPesanKamar(string username,OracleConnection cnn)
        {
            InitializeComponent();
            userID = username;
            conn = cnn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainClient mc = new MainClient(userID);
            this.Hide();
            mc.ShowDialog();
            this.Close();
        }

        private void ClientPesanKamar_Load(object sender, EventArgs e)
        {
            OracleDataAdapter od = new OracleDataAdapter("SELECT * FROM JENIS_KAMAR", conn);
            od.Fill(listJenisKamar);
            comboBoxJenisKamar.DisplayMember = "nama_jenis";
            comboBoxJenisKamar.ValueMember= "kode_jenis";
            comboBoxJenisKamar.DataSource = listJenisKamar;
            dateTimePicker2.Value = DateTime.Now.AddDays(1);
        }

        string id_kamar_fix = "";
        private void comboBoxJenisKamar_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_kamar_fix = "";
            OracleCommand cmd = new OracleCommand("SELECT COUNT(ID_KAMAR) FROM KAMAR WHERE KODE_JENIS='"+comboBoxJenisKamar.SelectedValue.ToString()+"'", conn);
            int jumlah =Convert.ToInt32(cmd.ExecuteScalar().ToString());
            string ada = "Tidak tersedia";
            buttonPesan.Enabled = false;
            OracleCommand cm = new OracleCommand("SELECT HARGA_JENIS FROM JENIS_KAMAR WHERE KODE_JENIS='" + comboBoxJenisKamar.SelectedValue.ToString() + "'",conn);
            harga_kamar= cm.ExecuteScalar().ToString();
            labelHargaKamar.Text = harga_kamar;
            //cari kamar kosong
            //cari kamar
            OracleDataAdapter od_kamar = new OracleDataAdapter("SELECT * FROM KAMAR where kode_jenis='"+comboBoxJenisKamar.SelectedValue.ToString()+"'", conn);
            DataTable data_kamar = new DataTable();
            od_kamar.Fill(data_kamar);
            DateTime input_masuk = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
            DateTime input_keluar = Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString());
            List<DateTime> list_range_inputan = new List<DateTime>();
            Console.WriteLine("range");
            Console.WriteLine(input_keluar.Day - input_masuk.Day+"");
            for (int i = 0; i <= input_keluar.Day- input_masuk.Day; i++)
            {
                list_range_inputan.Add(input_masuk.AddDays(i));
            }
            for (int i = 0; i < list_range_inputan.Count; i++)
            {
                Console.WriteLine(list_range_inputan[i].ToShortDateString());
            }
            Console.WriteLine("end");
            bool tidak_ada_kamar = false;
            for (int i = 0; i < data_kamar.Rows.Count; i++)
            {
                string id_kamar = data_kamar.Rows[i].ItemArray[0].ToString();
                //cari booking dari kamar
                OracleDataAdapter od_booking = new OracleDataAdapter("SELECT * FROM BOOKING WHERE ID_KAMAR='"+id_kamar+"'", conn);
                DataTable data_booking = new DataTable();
                od_booking.Fill(data_booking);
                bool ada_di_tanggal_ini_kamar_ini = true;
                for (int j = 0; j < data_booking.Rows.Count; j++)
                {
                    Console.WriteLine(id_kamar);
                    DateTime tanggal_masuk=Convert.ToDateTime(data_booking.Rows[j].ItemArray[3].ToString());
                    DateTime tanggal_keluar = Convert.ToDateTime(data_booking.Rows[j].ItemArray[4].ToString());
                    List<DateTime> list_range_booking = new List<DateTime>();
                    Console.WriteLine("range booking");
                    for (int jx= 0; jx <= tanggal_keluar.Day - tanggal_masuk.Day; jx++)
                    {
                        list_range_booking.Add(tanggal_masuk.AddDays(jx));
                    }
                    for (int xj = 0; xj < list_range_booking.Count; xj++)
                    {
                        Console.WriteLine(list_range_booking[xj].ToShortDateString());
                    }
                    Console.WriteLine("end range");
                    //cek kalo input masuk ada yang tabrak sama 
                    int counter_sama = 0;
                    for (int n = 0; n < list_range_inputan.Count; n++)
                    {
                        for (int m = 0; m < list_range_booking.Count; m++)
                        {
                            if (list_range_inputan[n].Equals(list_range_booking[m]))
                            {
                                counter_sama++;
                            }
                        }
                    }
                    Console.WriteLine(counter_sama+"");
                    if (counter_sama >1) {
                        ada_di_tanggal_ini_kamar_ini = false;
                    }
                }
                if (ada_di_tanggal_ini_kamar_ini)
                {
                    id_kamar_fix = id_kamar;
                    break;
                }
            }
            if (id_kamar_fix != "") {
                ada = "Tersedia"; buttonPesan.Enabled = true;
            }
            else if (id_kamar_fix == "")
            {
                ada = "Tidak tersedia"; buttonPesan.Enabled = false;

            }
            labelStatusKamar.Text = ada;
            MessageBox.Show(id_kamar_fix);
        }

        private void buttonPesan_Click(object sender, EventArgs e)
        {
            OracleTransaction ot = conn.BeginTransaction();
            try
            {
                OracleCommand cmd = new OracleCommand("INSERT INTO BOOKING VALUES('','"+userID+"','"+id_kamar_fix+ "',to_date('" + dateTimePicker1.Value.ToShortDateString() + "','dd/mm/yyyy'),to_date('" + dateTimePicker2.Value.ToShortDateString() + "','dd/mm/yyyy'))", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kamar telah berhasil di book! Anda mendapatkan kamar "+id_kamar_fix);
                ot.Commit();
            }
            catch (Exception ex)
            {
                ot.Rollback();
                MessageBox.Show(ex.ToString());
            }
            id_kamar_fix = "";
            comboBoxJenisKamar_SelectedIndexChanged(sender, e);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value < DateTime.Now)
            {
                dateTimePicker1.Value = DateTime.Now;
            }
            if (dateTimePicker1.Value < dateTimePicker2.Value)
            {
                comboBoxJenisKamar_SelectedIndexChanged(sender,e);
            }
            else if(dateTimePicker1.Value > dateTimePicker2.Value)
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
            }
        }
    }
}
