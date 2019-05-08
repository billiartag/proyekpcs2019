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
    public partial class ClientMembership : Form
    {
        public ClientMembership()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainClient mc = new MainClient();
            this.Hide();
            mc.ShowDialog();
            this.Close();
        }
    }
}
