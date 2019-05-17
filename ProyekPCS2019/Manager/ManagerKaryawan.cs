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
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM JABATAN WHERE nama_jabatan!='MANAGER'", conn);
            jabatan = new DataTable();
            cmd.Fill(jabatan);
        }
        void loadKaryawan() {
            listBox1.Items.Clear();
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM PEGAWAI", conn);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            listBox1.DisplayMember = "nama_pegawai";
            listBox1.ValueMember = "id_pegawai";
            listBox1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
