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

namespace ProyekPCS2019
{
    public partial class MainClient : Form
    {
        string userID;
        OracleConnection conn;
        public MainClient(string username)
        {
            InitializeComponent();
            userID = username;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Client.ClientMembership cm = new Client.ClientMembership("normal", userID);
            cm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Client.ClientPesanKamar cp = new Client.ClientPesanKamar(userID,conn);
            cp.ShowDialog();
            this.Close();
        }

        private void MainClient_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new OracleConnection("User ID=proyek;Password=1;Data Source=orcl");
                conn.Open();
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Client.ClientCekPesan cp = new Client.ClientCekPesan(userID,conn);
            cp.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Client.ClientLihatFasilitas cp = new Client.ClientLihatFasilitas(conn,userID);
            cp.ShowDialog();
            this.Close();

        }
    }
}
