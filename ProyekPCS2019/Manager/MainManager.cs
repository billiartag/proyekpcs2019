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
    public partial class MainManager : Form
    {
        string user;
        OracleConnection conn;
        public MainManager(string username,OracleConnection konek)
        {
            InitializeComponent();
            user = username;
            conn = konek;
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manager.ManagerKamar mk = new ManagerKamar(user,conn);
            mk.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Manager.ManagerFasilitas mf = new ManagerFasilitas(user, conn);
            this.Hide();
            mf.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Manager.ManagerKaryawan mk = new ManagerKaryawan(user, conn);
            this.Hide();
            mk.ShowDialog();
            this.Close();
        }

        private void MainManager_Load(object sender, EventArgs e)
        {

        }
    }
}
