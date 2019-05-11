﻿using System;
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
    public partial class MainClient : Form
    {
        string userID;
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
            Client.ClientPesanKamar cp = new Client.ClientPesanKamar(userID);
            cp.ShowDialog();
            this.Close();
        }

        private void MainClient_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Client.ClientCekPesan cp = new Client.ClientCekPesan(userID);
            cp.ShowDialog();
            this.Close();
        }
    }
}