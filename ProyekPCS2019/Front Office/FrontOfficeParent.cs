using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyekPCS2019.Front_Office
{
    public partial class FrontOfficeParent : Form
    {
        public FrontOfficeParent()
        {
            InitializeComponent();
        }

        private void membershipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                this.MdiChildren[i].Close();
            }
            FrontOfficeMembership a = new FrontOfficeMembership();
            a.MdiParent = this;
            a.Show();
        }

        private void bookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                this.MdiChildren[i].Close();
            }
            MainFrontOffice a = new MainFrontOffice();
            a.MdiParent = this;
            a.Show();
        }

        private void fasilitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                this.MdiChildren[i].Close();
            }
            FrontOfficeFasilitas a = new FrontOfficeFasilitas();
            a.MdiParent = this;
            a.Show();
        }

        private void FrontOfficeParent_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login a = new Login();
            a.Show();
            this.Close();
        }
    }
}
