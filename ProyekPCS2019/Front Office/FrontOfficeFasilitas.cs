using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Windows.Forms;

namespace ProyekPCS2019.Front_Office
{
    public partial class FrontOfficeFasilitas : Form
    {
        public FrontOfficeFasilitas()
        {
            InitializeComponent();
        }
        OracleConnection conn = new OracleConnection("User ID=proyek;Password=1;Data Source=orcl");
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                try
                {
                    conn.Open();

                    string sql2 = "SELECT id_transaksi FROM h_transaksi WHERE id_kamar = '" + comboBox1.Text + "' ORDER BY tgl_checkin DESC";
                    OracleCommand cmd2 = new OracleCommand(sql2, conn);
                    string kode = cmd2.ExecuteScalar().ToString();
               // MessageBox.Show("1");

                string sqlcek = "SELECT tgl_checkout FROM h_transaksi WHERE id_kamar = '" + comboBox1.Text + "' ORDER BY tgl_checkin DESC";
                    OracleCommand cmd3 = new OracleCommand(sqlcek,conn);
                    string tgl2 = cmd3.ExecuteScalar().ToString();

                //MessageBox.Show("2");


                string sqlcek2 = "SELECT tgl_checkin FROM h_transaksi WHERE id_kamar = '" + comboBox1.Text + "' ORDER BY tgl_checkin DESC";
                    OracleCommand cmd4 = new OracleCommand(sqlcek2, conn);
                    string tgl3 = cmd4.ExecuteScalar().ToString();
                //MessageBox.Show("3");




                DateTime tglmsk = Convert.ToDateTime(tgl3);
                    DateTime tglkeluar = Convert.ToDateTime(tgl2);

                    DateTime a = dateTimePicker1.Value;
                    Boolean cektgl = false;
                    if (tglmsk <= a && a <= tglkeluar)
                    {
                        cektgl = true;
                    }
                    else
                    {
                        cektgl = false;
                    }
                    if(cektgl)
                    {
                        for (int i = 0; i < numericUpDown1.Value; i++)
                        {
                            string sql = "INSERT INTO d_transaksi VALUES('" + kode + "','" + comboBox2.SelectedValue + "')";
                            OracleCommand cmd = new OracleCommand(sql, conn);
                            cmd.ExecuteNonQuery();

                        //MessageBox.Show("4");

                    }
                    //update h_trans
                    sql2 = "select id_fasilitas from d_transaksi where id_transaksi = '"+kode+"'";
                        cmd2 = new OracleCommand(sql2, conn);
                        OracleDataAdapter da = new OracleDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        int hargatotal = 0;

                    //MessageBox.Show("5");



                    foreach (DataRow row in dt.Rows)
                        {
                            sql2 = "select harga_fasilitas from fasilitas where id_fasilitas = '"+row[0]+"'";
                            cmd2 = new OracleCommand(sql2, conn);
                            hargatotal += Convert.ToInt32(cmd2.ExecuteScalar().ToString());
                        //MessageBox.Show("6");

                    }
                    //cari harga jenis
                    sql2 = "select kode_jenis from kamar where id_kamar = '"+comboBox1.SelectedValue+"'";
                        cmd2 = new OracleCommand(sql2, conn);
                        string jenis = cmd2.ExecuteScalar().ToString();

                    //MessageBox.Show("7");


                    sql2 = "select harga_jenis from jenis_kamar where kode_jenis = '"+jenis+"'";
                        cmd2 = new OracleCommand(sql2, conn);
                        int hargakamar = Convert.ToInt32(cmd2.ExecuteScalar().ToString());
                        hargatotal += hargakamar;

                    //MessageBox.Show("8");


                    sql2 = "update h_transaksi set total_harga = " + hargatotal+"where id_transaksi = '"+kode+"'";
                        cmd2 = new OracleCommand(sql2, conn);
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Fasilitas berhasil ditambahkan!");

                    //MessageBox.Show("9");

                }
                else
                    {
                        MessageBox.Show("Ruangan tidak ada yang menempati!");
                    }
                    
                       
                    conn.Close();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message);
                }
            
        }
        public void isifasilitas() {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("SELECT * FROM fasilitas",conn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "nama_fasilitas";
                comboBox2.ValueMember = "id_fasilitas";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void isikamar() {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("SELECT * FROM kamar",conn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "id_kamar";
                comboBox1.ValueMember = "id_kamar";

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Kamar tidak ada penghuni!");
            }
        }
        private void FrontOfficeFasilitas_Load(object sender, EventArgs e)
        {
            isifasilitas();
            isikamar();
        }

    }
}
