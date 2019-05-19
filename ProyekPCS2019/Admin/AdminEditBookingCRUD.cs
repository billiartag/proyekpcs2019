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

namespace ProyekPCS2019.Admin
{
    public partial class AdminEditBookingCRUD : Form
    {
        OracleConnection conn = new OracleConnection();
        public AdminEditBookingCRUD()
        {
            InitializeComponent();
        }

        private void AdminEditBookingCRUD_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            dateTimePicker1.Enabled = false;
            comboBox4.Enabled = false;
            comboBox3.Enabled = false;
            dateTimePicker3.Enabled = false;
            dataGridView2.Visible = false;
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
            refresh();
        }
        public void refresh()
        {
            //refresh data grid view
            conn.Open();
            OracleDataAdapter da = new OracleDataAdapter();
            DataTable dt = new DataTable();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from booking";
            da.SelectCommand = cmd;
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            if (dataGridView1.Columns.Count < 6)
            {
                DataGridViewButtonColumn newbtn = new DataGridViewButtonColumn();
                newbtn.DefaultCellStyle.SelectionForeColor = Color.Green;
                newbtn.DefaultCellStyle.BackColor = Color.Green;
                newbtn.DefaultCellStyle.ForeColor = Color.Green;
                newbtn.HeaderText = "Action";
                newbtn.Name = "Button";
                newbtn.Text = "Delete";
                newbtn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(newbtn);
            }
            conn.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                OracleCommand cmd = new OracleCommand("select nama from membership where id_membership='" + textBox2.Text + "'");
                cmd.Connection = conn;
                string nama = cmd.ExecuteScalar().ToString();
                DialogResult dialogResult = MessageBox.Show("Jika Benar Maka Akan Dilanjutkan Ke Proses Selanjutnya, Apakah Anda Bersedia ? ", "Nama Anda : " + nama, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    textBox1.BackColor = Color.Green;
                    dateTimePicker1.Enabled = true;
                    textBox2.Enabled = false;
                    button3.Enabled = false;
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

            }
            catch (Exception)
            {
                textBox1.BackColor = Color.Red;
                MessageBox.Show("ID Member Anda Tidak Ditemukan ! ");
            }
            conn.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Apakah Anda Yakin Ingin Melakukan Check In, Sesuai Dengan Data Waktu Yang Anda Berikan ? ", "Confirmation ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dateTimePicker1.Enabled = false;
                comboBox4.Enabled = true;
                comboBox3.Enabled = true;
                dateTimePicker3.Enabled = true;
                button1.Enabled = true;
                //isi combo box jenis kamar
                conn.Open();
                OracleCommand cmd = new OracleCommand("select nama_jenis from jenis_kamar");
                cmd.Connection = conn;
                OracleDataReader reader = cmd.ExecuteReader();
                comboBox4.Items.Clear();
                while (reader.Read())
                {
                    comboBox4.Items.Add(String.Format("{0}", reader[0]));
                }
                conn.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
        public void search_kodejenis(string nama,ref string id)
        {
            conn.Open();
            try
            {
                OracleCommand cmd = new OracleCommand("select kode_jenis from jenis_kamar where nama_jenis='" + nama + "'");
                cmd.Connection = conn;
                id = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                
            }
            conn.Close();
        }
        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            string kodejenis = "";
            search_kodejenis(comboBox4.Text,ref kodejenis);
            //mengisi combo box kamar yang tersedia
            conn.Open();
            try
            {
                //cek untuk kamar yang tersedia
                List<string> datakamar = new List<string>();
                OracleCommand cmd = new OracleCommand("select id_kamar from kamar where kode_jenis='"+ kodejenis + "' and tersedia='Y'");
                cmd.Connection = conn;
                OracleDataReader reader = cmd.ExecuteReader();
                comboBox3.Items.Clear();
                while (reader.Read())
                {
                    OracleCommand cmd1 = new OracleCommand("select tgl_keluar from booking where id_kamar='" + String.Format("{0}", reader[0]) + "'");
                    cmd1.Connection = conn;
                    //tanggal dalam data booking
                    string tgl = cmd1.ExecuteScalar().ToString();
                    string[] pisahtgl = tgl.Substring(0, 10).Split('/');
                    int jumlah_hari = 0;
                    jumlah_hari = int.Parse(pisahtgl[0]);
                    jumlah_hari = jumlah_hari + (int.Parse(pisahtgl[1]) * 30);
                    jumlah_hari = jumlah_hari + (int.Parse(pisahtgl[2]) * 365);
                    //tanggal booking yang diinginkan
                    string tgl2 = dateTimePicker1.Value.ToShortDateString();
                    string[] pisahtgl2 = tgl2.Substring(0, 10).Split('/');
                    int jumlah_hari2 = 0;
                    jumlah_hari2 = int.Parse(pisahtgl2[0]);
                    jumlah_hari2 = jumlah_hari2 + (int.Parse(pisahtgl2[1]) * 30);
                    jumlah_hari2 = jumlah_hari2 + (int.Parse(pisahtgl2[2]) * 365);
                    if (jumlah_hari2-jumlah_hari>=0)
                    {
                        comboBox3.Items.Add(String.Format("{0}", reader[0]));
                    }
                }
                //cek untuk kamar yang tidak tersedia
                
            }
            catch (Exception)
            {

            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool berhasil = false;
            //tambah booking
            if (comboBox3.Text != "" && comboBox4.Text != "" )
            {
                conn.Open();
                OracleTransaction mytrans = conn.BeginTransaction();
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into booking values('','" + textBox2.Text + "','" + comboBox3.Text + "',to_date('"+ dateTimePicker1.Text + "','dd/mm/yy'),to_date('" + dateTimePicker3.Text + "','dd/mm/yy'))";
                    cmd.ExecuteNonQuery();
                    mytrans.Commit();
                    berhasil = true;
                    MessageBox.Show("INSERT BOOKING BERHASIL");
                }
                catch (Exception ex)
                {
                    mytrans.Rollback();
                    berhasil = false;
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Anda Belum Memilih Kamar ! ");
            }
            if (berhasil)
            {
                textBox2.Focus();
                textBox2.Text = "";
                comboBox4.Text = "";
                comboBox3.Text = "";
                button1.Enabled = false;
                comboBox4.Enabled = false;
                comboBox3.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker3.Enabled = false;
                button1.Enabled = false;
                button3.Enabled = true;
                textBox2.Enabled = true;
            }
            refresh();
        }
        
    }
}
