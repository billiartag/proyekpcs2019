﻿using ProyekPCS2019.Admin;
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
    public partial class MainAdmin : Form
    {
        public MainAdmin()
        {
            InitializeComponent();
        }

        private void pEGAWAIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditPegawaiCRUD ep = new EditPegawaiCRUD();
            ep.MdiParent = this;
            ep.Show();
        }

        private void MainMaster_Load(object sender, EventArgs e)
        {

        }

        private void fASILITASToolStripMenuItem_Click(object sender, EventArgs e)
        {

            EditMembership em = new EditMembership();
            em.MdiParent = this;
            em.Show();

        }

        private void kAMARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminEditBookingCRUD eb = new AdminEditBookingCRUD();
            eb.MdiParent = this;
            eb.Show();
        }
    }
}
