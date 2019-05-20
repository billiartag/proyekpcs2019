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
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            dateTimePicker4.Enabled = false;
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

            //refresh isi combo box
            OracleDataAdapter da1 = new OracleDataAdapter();
            DataTable dt1 = new DataTable();
            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "select kode_booking from booking";
            da1.SelectCommand = cmd1;
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            comboBox1.Items.Clear();
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                comboBox1.Items.Add(dataGridView2.Rows[i].Cells[0].Value.ToString());
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
                List<string> datakamar = new List<string>();
                OracleCommand cmd = new OracleCommand("select id_kamar from kamar where kode_jenis='"+ kodejenis +"'");
                cmd.Connection = conn;
                OracleDataReader reader = cmd.ExecuteReader();
                comboBox3.Items.Clear();
                //tanggal masuk yang dipilih
                string tgl00 = dateTimePicker1.Value.ToShortDateString();
                string[] pisahtgl00 = tgl00.Substring(0, 10).Split('/');
                int jumlah_hari00 = 0;
                jumlah_hari00 = int.Parse(pisahtgl00[0]);
                jumlah_hari00 = jumlah_hari00 + (int.Parse(pisahtgl00[1]) * 30);
                jumlah_hari00 = jumlah_hari00 + (int.Parse(pisahtgl00[2]) * 365);
                //tanggal keluar yang dipilih
                string tgl01 = dateTimePicker3.Value.ToShortDateString();
                string[] pisahtgl01 = tgl01.Substring(0, 10).Split('/');
                int jumlah_hari01 = 0;
                jumlah_hari01 = int.Parse(pisahtgl01[0]);
                jumlah_hari01 = jumlah_hari01 + (int.Parse(pisahtgl01[1]) * 30);
                jumlah_hari01 = jumlah_hari01 + (int.Parse(pisahtgl01[2]) * 365);
                while (reader.Read())
                {
                    OracleCommand cmd1 = new OracleCommand("select tgl_msk,tgl_keluar from booking where id_kamar='" + String.Format("{0}", reader[0]) + "'");
                    cmd1.Connection = conn;
                    OracleDataAdapter da = new OracleDataAdapter(cmd1);
                    DataTable tgl = new DataTable();
                    da.Fill(tgl);
                    bool cekbisa = true;
                    foreach (DataRow x in tgl.Rows)
                    {
                        if (cekbisa==true)
                        {
                            //tanggal masuk
                            string tgl1 = x[0].ToString();
                            string[] pisahtgl1 = tgl1.Substring(0, 10).Split('/');
                            int jumlah_hari1 = 0;
                            jumlah_hari1 = int.Parse(pisahtgl1[0]);
                            jumlah_hari1 = jumlah_hari1 + (int.Parse(pisahtgl1[1]) * 30);
                            jumlah_hari1 = jumlah_hari1 + (int.Parse(pisahtgl1[2]) * 365);
                            //tanggal keluar
                            string tgl2 = x[1].ToString();
                            string[] pisahtgl2 = tgl2.Substring(0, 10).Split('/');
                            int jumlah_hari2 = 0;
                            jumlah_hari2 = int.Parse(pisahtgl2[0]);
                            jumlah_hari2 = jumlah_hari2 + (int.Parse(pisahtgl2[1]) * 30);
                            jumlah_hari2 = jumlah_hari2 + (int.Parse(pisahtgl2[2]) * 365);
                            if (jumlah_hari00 >= jumlah_hari1 && jumlah_hari00 <= jumlah_hari2)
                            {
                                cekbisa = false;
                            }
                            if (jumlah_hari01 >= jumlah_hari1 && jumlah_hari01 <= jumlah_hari2)
                            {
                                cekbisa = false;
                            }
                            if (jumlah_hari00 <= jumlah_hari1 && jumlah_hari01>=jumlah_hari2)
                            {
                                cekbisa = false;
                            }
                        }
                    }
                    if (cekbisa)
                    {
                        comboBox3.Items.Add(String.Format("{0}", reader[0]));
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //delete
            if (e.ColumnIndex == 0)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                //delete
                conn.Open();
                OracleTransaction mytrans = conn.BeginTransaction();
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.CommandText = "delete from booking where kode_booking='" + id + "'";
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    mytrans.Commit();
                }
                catch (Exception ex)
                {
                    mytrans.Rollback();
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
                refresh();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                conn.Open();
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    //ID_MEMBERSHIP
                    cmd.CommandText = "select ID_MEMBERSHIP from booking where kode_booking='" + comboBox1.Text + "'";
                    textBox5.Text = cmd.ExecuteScalar().ToString();
                    //ID_KAMAR
                    cmd.CommandText = "select ID_KAMAR from booking where kode_booking='" + comboBox1.Text + "'";
                    textBox6.Text = cmd.ExecuteScalar().ToString();
                    //TGL_MSK
                    cmd.CommandText = "select TGL_MSK from booking where kode_booking='" + comboBox1.Text + "'";
                    dateTimePicker4.Text = cmd.ExecuteScalar().ToString();
                    //TGL_KELUAR
                    cmd.CommandText = "select TGL_KELUAR from booking where kode_booking='" + comboBox1.Text + "'";
                    dateTimePicker2.Text = cmd.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cekbisaupdate = true;
            //mengecek tanggal tersebut bisa atau tidak
            string kodejenis = textBox6.Text;
            conn.Open();
            try
            {
                //tanggal masuk yang dipilih
                string tgl00 = dateTimePicker4.Value.ToShortDateString();
                string[] pisahtgl00 = tgl00.Substring(0, 10).Split('/');
                int jumlah_hari00 = 0;
                jumlah_hari00 = int.Parse(pisahtgl00[0]);
                jumlah_hari00 = jumlah_hari00 + (int.Parse(pisahtgl00[1]) * 30);
                jumlah_hari00 = jumlah_hari00 + (int.Parse(pisahtgl00[2]) * 365);
                //tanggal keluar yang dipilih
                string tgl01 = dateTimePicker2.Value.ToShortDateString();
                string[] pisahtgl01 = tgl01.Substring(0, 10).Split('/');
                int jumlah_hari01 = 0;
                jumlah_hari01 = int.Parse(pisahtgl01[0]);
                jumlah_hari01 = jumlah_hari01 + (int.Parse(pisahtgl01[1]) * 30);
                jumlah_hari01 = jumlah_hari01 + (int.Parse(pisahtgl01[2]) * 365);

                OracleCommand cmd1 = new OracleCommand("select tgl_msk,tgl_keluar from booking where id_kamar='" + textBox6.Text + "' and kode_booking!='"+comboBox1.Text+"'");
                cmd1.Connection = conn;
                OracleDataAdapter da = new OracleDataAdapter(cmd1);
                DataTable tgl = new DataTable();
                da.Fill(tgl);
                foreach (DataRow x in tgl.Rows)
                {
                    if (cekbisaupdate == true)
                    {
                        //tanggal masuk
                        string tgl1 = x[0].ToString();
                        string[] pisahtgl1 = tgl1.Substring(0, 10).Split('/');
                        int jumlah_hari1 = 0;
                        jumlah_hari1 = int.Parse(pisahtgl1[0]);
                        jumlah_hari1 = jumlah_hari1 + (int.Parse(pisahtgl1[1]) * 30);
                        jumlah_hari1 = jumlah_hari1 + (int.Parse(pisahtgl1[2]) * 365);
                        //tanggal keluar
                        string tgl2 = x[1].ToString();
                        string[] pisahtgl2 = tgl2.Substring(0, 10).Split('/');
                        int jumlah_hari2 = 0;
                        jumlah_hari2 = int.Parse(pisahtgl2[0]);
                        jumlah_hari2 = jumlah_hari2 + (int.Parse(pisahtgl2[1]) * 30);
                        jumlah_hari2 = jumlah_hari2 + (int.Parse(pisahtgl2[2]) * 365);
                        if (jumlah_hari01 >= jumlah_hari1 && jumlah_hari01 <= jumlah_hari2)
                        {
                            cekbisaupdate = false;
                        }
                        if (jumlah_hari00 <= jumlah_hari1 && jumlah_hari01 >= jumlah_hari2)
                        {
                            cekbisaupdate = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            if (cekbisaupdate)
            {
                //update booking
                conn.Open();
                OracleTransaction mytrans = conn.BeginTransaction();
                try
                {
                    //TGL_KELUAR
                    OracleCommand cmd3 = new OracleCommand();
                    cmd3.CommandText = "update booking set TGL_KELUAR=to_date('" + dateTimePicker2.Value.ToShortDateString() + "','dd/mm/yyyy') where kode_booking='" + comboBox1.Text + "'";
                    cmd3.Connection = conn;
                    cmd3.ExecuteNonQuery();
                    mytrans.Commit();
                    MessageBox.Show("Booking Berhasil di Update !");
                }
                catch (Exception ex)
                {
                    mytrans.Rollback();
                    MessageBox.Show(ex.Message);
                }

                conn.Close();
                refresh();
            }
            else
            {
                MessageBox.Show("tanggal tersebut tidak bisa dibooking");
            }
        }

        bool cekbisaupdate = true;

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            button3.Enabled = true;
            dateTimePicker1.Enabled = false;
            comboBox4.Enabled = false;
            comboBox3.Enabled = false;
            dateTimePicker3.Enabled = false;
        }
    }
}
