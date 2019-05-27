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
        private void button2_Click(object sender, EventArgs e)
        {
            OracleTransaction trx = conn.BeginTransaction();
            try
            {
                OracleCommand cmd = new OracleCommand("UPDATE JENIS_KAMAR SET HARGA_JENIS=" + numericUpDown1.Value.ToString() + " WHERE kode_jenis='" + id_jeniskamar+ "'", conn);
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
            listBox1.DisplayMember = "nama_jenis";
            listBox1.ValueMember = "kode_jenis";
            listBox1.DataSource = dt;            
        }
        string id_jeniskamar = "";
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                id_jeniskamar = listBox1.SelectedValue.ToString();
                textBox1.Text = id_jeniskamar;
                int indexrow = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i].ItemArray[0].ToString() == id_jeniskamar)
                    {
                        indexrow = i;
                        break;
                    }
                }
                numericUpDown1.Value = Convert.ToInt32(dt.Rows[indexrow].ItemArray[2].ToString());
            }
        }
    }
}
