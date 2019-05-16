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
    public partial class ManagerFasilitas : Form
    {
        OracleConnection conn;
        string user;
        public ManagerFasilitas(string username, OracleConnection oc)
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
    }
}
