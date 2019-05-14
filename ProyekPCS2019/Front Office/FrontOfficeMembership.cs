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

namespace ProyekPCS2019.Front_Office
{
    public partial class FrontOfficeMembership : Form
    {
        public FrontOfficeMembership()
        {
            InitializeComponent();
        }

        OracleConnection conn = new OracleConnection("User ID=proyek;Password=1;Data Source=orcl");
        private void FrontOfficeMembership_Load(object sender, EventArgs e)
        {
            isimembership();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                conn.Open();
                string sql = "INSERT INTO membership VALUES('','"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"')";
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
        public void isimembership() {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                conn.Open();
                string sql = "SELECT * FROM membership";
                OracleCommand cmd = new OracleCommand(sql, conn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "nama";
                comboBox1.ValueMember = "id_membership";

                
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a = comboBox1.SelectedValue.ToString();
            string hasil = "";
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                conn.Open();
                string sql = "SELECT status FROM membership WHERE id_membership = '"+a+"'";
                OracleCommand cmd = new OracleCommand(sql, conn);
                hasil = cmd.ExecuteScalar().ToString();

                if (hasil.Equals("1"))
                {
                    hasil = "Aktif";
                }
                else if (hasil.Equals("0"))
                {
                    hasil = "Tidak Aktif";
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Status Member anda saat ini "+hasil);
        }
    }
}
