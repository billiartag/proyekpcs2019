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

namespace ProyekPCS2019.Client
{
    public partial class ClientGantiPassword : Form
    {
        OracleConnection conn;
        string userID;
        public ClientGantiPassword(OracleConnection cn, string id)
        {
            userID = id;
            conn = cn;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable user = new DataTable();
            OracleDataAdapter od = new OracleDataAdapter("SELECT * FROM USERS WHERE username='"+userID+"'", conn);
            od.Fill(user);
            if (textBox1.Text == user.Rows[0].ItemArray[1].ToString())
            {
                OracleTransaction tr = conn.BeginTransaction();
                try
                {
                    OracleCommand cmd = new OracleCommand("UPDATE USERS SET PASSWORD='" + textBox2.Text + "' WHERE   USERNAME='" + userID + "'", conn);
                    cmd.ExecuteNonQuery();
                    tr.Commit();
                    MessageBox.Show("Berhasil ganti password!");
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show("gagal ganti password!"+ex.ToString());
                }
            }
            user.Clear();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainClient mc = new MainClient(userID);
            this.Hide();
            mc.ShowDialog();
            this.Close();
        }
    }
}
