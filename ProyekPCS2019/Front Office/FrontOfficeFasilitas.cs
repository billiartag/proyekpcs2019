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
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                try
                {
                    conn.Open();
                    string sql2 = "SELECT id_transaksi FROM kamar WHERE id_kamar = '" + comboBox1.Text + "'";
                    OracleCommand cmd2 = new OracleCommand(sql2, conn);
                    string kode = cmd2.ExecuteScalar().ToString();
                    
                    string sql = "INSERT INTO d_transaksi VALUES('"+kode+"','"+comboBox1.Text+"','"+comboBox2.Text+"')";
                    OracleCommand cmd = new OracleCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message);
                }
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
                MessageBox.Show(ex.Message);
            }
        }
        private void FrontOfficeFasilitas_Load(object sender, EventArgs e)
        {
            isifasilitas();
            isikamar();
        }

    }
}
