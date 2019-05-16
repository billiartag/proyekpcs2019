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
    public partial class ManagerKamar : Form
    {
        OracleConnection conn;
        DataTable dt;
        string user;
        public ManagerKamar(string username,OracleConnection oc)
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

        private void ManagerKamar_Load(object sender, EventArgs e)
        {
            try
            {
                OracleDataAdapter od = new OracleDataAdapter("SELECT * FROM JENIS_KAMAR", conn);
                od.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "nama_jenis";
                comboBox1.ValueMember = "harga_jenis";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = Convert.ToInt32(comboBox1.SelectedValue);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleTransaction trx = conn.BeginTransaction();
            try
            {
                OracleCommand cmd = new OracleCommand("UPDATE JENIS_KAMAR SET HARGA_JENIS=" + numericUpDown1.Value.ToString() + " WHERE NAMA_JENIS='" + comboBox1.SelectedText.ToString() + "'", conn);
                cmd.ExecuteNonQuery();
                trx.Commit();
                MessageBox.Show("Harga berhasil diubah");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, "+ex.Message);
                trx.Rollback();
            }
        }
    }
}
