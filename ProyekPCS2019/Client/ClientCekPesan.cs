using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyekPCS2019.Client
{
    public partial class ClientCekPesan : Form
    {
        string userID;
        public ClientCekPesan(string user)
        {
            userID = user;
            InitializeComponent();
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
