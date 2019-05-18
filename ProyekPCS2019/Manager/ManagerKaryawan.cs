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

namespace ProyekPCS2019.Manager
{
    public partial class ManagerKaryawan : Form
    {
        OracleConnection conn;
        string user;
        DataTable jabatan=new DataTable();
        string id_pegawai_global = "";
        public ManagerKaryawan(string username,OracleConnection oc)
        {
            InitializeComponent();
            user = username;
            conn = oc;
        }

            private void button1_Click(object sender, EventArgs e)
        {
            Manager.MainManager mm = new MainManager(user,conn);
            this.Hide();
            mm.ShowDialog();
            this.Close();
        }

        private void ManagerKaryawan_Load(object sender, EventArgs e)
        {
            try
            {
                loadJabatan();
                loadKaryawan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Manager.MainManager mm = new MainManager(user, conn);
                this.Hide();
                mm.ShowDialog();
                this.Close();
            }
        }

        void loadJabatan() {
            jabatan.Clear();
            comboBox1.Items.Clear();
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM JABATAN WHERE nama_jabatan!='MANAGER' AND nama_jabatan!='ADMIN'", conn);
            jabatan = new DataTable();
            cmd.Fill(jabatan);
            comboBox1.DisplayMember = "nama_jabatan";
            comboBox1.ValueMember= "nama_jabatan";
            comboBox1.DataSource = jabatan;
        }
        void loadKaryawan() {
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM PEGAWAI WHERE jabatan!='MANAGER' AND jabatan!='ADMIN'", conn);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            listBox1.DisplayMember = "nama_pegawai";
            listBox1.ValueMember = "id_pegawai";
            listBox1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_pegawai_global= listBox1.SelectedValue.ToString();
            MessageBox.Show(id_pegawai_global);

            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM PEGAWAI", conn);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            string nama = "";string jabatan = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].ItemArray[0].ToString() == id_pegawai_global)
                {
                    nama = dt.Rows[i].ItemArray[1].ToString();
                    jabatan= dt.Rows[i].ItemArray[3].ToString();
                }
            }
            MessageBox.Show(nama + jabatan);
            textBoxNamaKaryawan.Text = nama;comboBox1.Text = jabatan;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleTransaction trx = conn.BeginTransaction();
            try
            {
                OracleCommand cmd = new OracleCommand("UPDATE PEGAWAI SET JABATAN='"+comboBox1.Text+"' WHERE ID_PEGAWAI='"+id_pegawai_global+"'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Pengubahan telah berhasil");
                loadKaryawan();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
