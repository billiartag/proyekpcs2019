using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyekPCS2019
{
    public partial class MainMaster : Form
    {
        public MainMaster()
        {
            InitializeComponent();
        }

        private void pEGAWAIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditPegawai ep = new EditPegawai();
            ep.MdiParent = this;
            ep.Show();

        }

        private void MainMaster_Load(object sender, EventArgs e)
        {

        }
    }
}
