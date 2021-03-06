﻿using System;
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
    public partial class Login : Form
    {
        OracleConnection conn;
        DataTable tabeluser;
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client.ClientMembership cm = new Client.ClientMembership("login","");
            this.Hide();
            cm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = textBox2.Text;
            MessageBox.Show(user+pass);
            //tolong ini nanti buat user admin ya win huehehehe
            if (user == pass && user.ToUpper() == "ADMIN")
            {
                this.Hide();
                MainAdmin mm = new MainAdmin();
                mm.ShowDialog();
                this.Close();
            }
            else {
                string role = "";
                for (int i = 0; i < tabeluser.Rows.Count; i++)
                {
                    Console.WriteLine(tabeluser.Rows[i].ItemArray[0].ToString()+ tabeluser.Rows[i].ItemArray[1].ToString() + tabeluser.Rows[i].ItemArray[2].ToString());
                    if (user == tabeluser.Rows[i].ItemArray[0].ToString() && pass == tabeluser.Rows[i].ItemArray[1].ToString()) {
                        role = tabeluser.Rows[i].ItemArray[2].ToString();
                    }
                }
                MessageBox.Show(role);
                if (role != "")
                {
                    if (role == "CUSTOMER")
                    {
                        this.Hide();
                        MainClient mc = new MainClient(user.ToUpper());
                        mc.ShowDialog();
                        this.Close();
                    }
                    else if (role == "FRONT OFFICE")
                    {
                        this.Hide();
                        Front_Office.FrontOfficeParent mf = new Front_Office.FrontOfficeParent();
                        mf.ShowDialog();
                        this.Close();
                    }
                    else if (role == "MANAGER")
                    {
                        this.Hide();
                        Manager.MainManager mc = new Manager.MainManager(user.ToUpper(), conn);
                        mc.ShowDialog();
                        this.Close();
                    }/*
                    if (role == "ADMIN")
                    {
                        this.Hide();
                        MainClient mc = new MainClient();
                        mc.ShowDialog();
                        this.Close();
                    }*/
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new OracleConnection("User ID=proyek;Password=1;Data Source=orcl");
                conn.Open();
                OracleDataAdapter od = new OracleDataAdapter("SELECT * FROM USERS", conn);
                tabeluser = new DataTable();
                od.Fill(tabeluser);
            }
            catch (Exception ex)
            {
                MessageBox.Show("gagal buka db"); MessageBox.Show(ex.Message);
            }
        }
    }
}
