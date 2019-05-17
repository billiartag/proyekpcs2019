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
        DataTable dt=new DataTable();
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
            numericUpDown1.Value = 0;
            try
            {
                refreshKamar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Manager.MainManager mm = new MainManager(user, conn);
                this.Hide();
                mm.ShowDialog();
                this.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1) {
                numericUpDown1.Value =Convert.ToInt32( comboBox1.SelectedValue.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleTransaction trx = conn.BeginTransaction();
            try
            {
                OracleCommand cmd = new OracleCommand("UPDATE JENIS_KAMAR SET HARGA_JENIS=" + numericUpDown1.Value.ToString() + " WHERE NAMA_JENIS='" + comboBox1.Text + "'", conn);
                cmd.ExecuteNonQuery();
                trx.Commit();
                refreshKamar();
                MessageBox.Show("Harga berhasil diubah");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, "+ex);
                trx.Rollback();
            }
        }
        void refreshKamar() {
            dt.Clear();
            OracleDataAdapter od = new OracleDataAdapter("SELECT * FROM JENIS_KAMAR", conn);
            od.Fill(dt);
            comboBox1.DisplayMember = "nama_jenis";
            comboBox1.ValueMember = "harga_jenis";
            comboBox1.DataSource = dt;
            listBox1.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listBox1.Items.Add(dt.Rows[i].ItemArray[1]+" - "+ dt.Rows[i].ItemArray[2]);
            }
        }
    }
}
