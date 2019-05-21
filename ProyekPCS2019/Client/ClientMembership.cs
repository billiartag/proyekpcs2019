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

namespace ProyekPCS2019.Client
{
    public partial class ClientMembership : Form
    {
        OracleConnection conn;
        string mode_login;
        string user;
        public ClientMembership(string mode,string username)
        {
            InitializeComponent();
            mode_login = mode;
            user = username;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (mode_login == "login") {
                Login mc = new Login();
                this.Hide();
                mc.ShowDialog();
                this.Close();
            }
            else {
                MainClient mc = new MainClient(user);
                this.Hide();
                mc.ShowDialog();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBoxCek.Visible = false;
            groupBoxBuat.Visible = true;
            buttonBuat.Enabled = false;
            buttonBuat.Visible= true;
            buttonCek.Enabled = true;
            buttonCek.Visible = true;
            if (mode_login == "normal") {
                buttonBuat.Enabled = false;
            }
        }

        private void ClientMembership_Load(object sender, EventArgs e)
        {
            textBoxidMember.Text = user;
            try
            {
                conn = new OracleConnection("User ID=proyek;Password=1;Data Source=orcl");
                conn.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("gagal buka db");
                throw;
            }
            if (mode_login == "normal")
            {
                groupBox1.Visible = false;
                groupBoxCek.Visible = true;
                groupBoxBuat.Visible = false;

                buttonBuat.Enabled = false;
                buttonBuat.Visible = false; ;
                buttonCek.Enabled = true;
                buttonCek.Visible = true;
            }
            else if (mode_login=="login")
            {
                groupBoxCek.Visible = false;
                groupBoxBuat.Visible = true;

                buttonBuat.Enabled = false;
                buttonBuat.Visible = true;
                buttonCek.Enabled = true;
                buttonCek.Visible = true;
            }
        }

        private void buttonCek_Click(object sender, EventArgs e)
        {
            groupBoxCek.Visible = true;
            groupBoxBuat.Visible = false;
            buttonBuat.Enabled = true;
            buttonBuat.Visible = true;
            buttonCek.Enabled = false;
            buttonCek.Visible = true;
        }

        private void buttonbuatMember_Click(object sender, EventArgs e)
        {
            if (textBoxNamaMember.Text != "" && textBoxAlamatMember.Text != "" && textBoxNomorMember.Text != "" && textBoxEmailMember.Text != "" && textBoxEmailMember.Text != "" && textBoxNomorMember.Text.Length >= 10 && textBoxNomorMember.Text.Length <=12 && textBoxNomorMember.Text.Substring(0,1)=="0")
            {
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "INSERT INTO membership(ID_MEMBERSHIP, NAMA, ALAMAT,NO_TELP,EMAIL) VALUES (:ID_MEMBER,:NAMA_MEMBER,:ALAMAT_MEMBER,:NOTEL_MEMBER, :EMAIL_MEMBER)";
                cmd.Parameters.Add(":ID_MEMBER", "");
                cmd.Parameters.Add(":NAMA_MEMBER", textBoxNamaMember.Text);
                cmd.Parameters.Add(":ALAMAT_MEMBER", textBoxAlamatMember.Text);
                cmd.Parameters.Add(":NOTEL_MEMBER", textBoxNomorMember.Text);
                cmd.Parameters.Add(":EMAIL_MEMBER", textBoxEmailMember.Text);
                cmd.Connection = conn;
                OracleTransaction trx = conn.BeginTransaction();
                try
                {
                    //cari yang sama
                    OracleCommand cek = new OracleCommand("SELECT COUNT(NAMA) FROM MEMBERSHIP WHERE NAMA = '" + textBoxNamaMember.Text + "' and EMAIL='" + textBoxEmailMember.Text + "'", conn);
                    OracleCommand getuserid = new OracleCommand("SELECT ID_MEMBERSHIP FROM MEMBERSHIP WHERE nama='" + textBoxNamaMember.Text + "'", conn);
                    String hasil = cek.ExecuteScalar().ToString();
                    MessageBox.Show(hasil);
                    if (hasil == "0")
                    {
                        cmd.ExecuteNonQuery();
                        string userid = getuserid.ExecuteScalar().ToString();
                        MessageBox.Show("Username anda adalah: "+userid+"\nDimohon diingat untuk melakukan login.");
                        OracleCommand buat_user = new OracleCommand("INSERT INTO USERS(USERNAME,PASSWORD, ROLE) VALUES ('"+userid+"','"+textBoxPassword.Text+"','CUSTOMER')", conn);
                        buat_user.ExecuteNonQuery();
                        trx.Commit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    trx.Rollback();
                }
            }
            else {
                MessageBox.Show("Semua field harus diisi dengan lengkap dan sesuai");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBoxidMember.Text.ToUpper() == user||mode_login=="login")
            {
                OracleDataAdapter tampung = new OracleDataAdapter("select * from membership where id_membership='" + textBoxidMember.Text.ToUpper() + "'", conn);
                DataTable tabeldatamember = new DataTable();
                tampung.Fill(tabeldatamember);
                labelnamamember.Text = tabeldatamember.Rows[0].ItemArray[1].ToString();
                labelAlamatMember.Text = tabeldatamember.Rows[0].ItemArray[2].ToString();
                labelNoMember.Text = tabeldatamember.Rows[0].ItemArray[3].ToString();
                labelEmailMember.Text = tabeldatamember.Rows[0].ItemArray[4].ToString();
                loadList();
            }
            else { MessageBox.Show("Maaf, hanya bisa cek diri sendiri");}
        }
        void loadList() {
            listBox1.Items.Clear();
            OracleDataAdapter od = new OracleDataAdapter("SELECT * FROM BOOKING WHERE ID_MEMBERSHIP='"+user+"'", conn);
            DataTable dt = new DataTable();
            od.Fill(dt);
            listBox1.DisplayMember = "kode_booking";
            listBox1.ValueMember = "kode_booking";
            listBox1.DataSource = dt;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleDataAdapter od = new OracleDataAdapter("SELECT * FROM BOOKING WHERE KODE_BOOKING='"+listBox1.Text+"' ORDER BY KODE_BOOKING DESC", conn);
            DataTable dt = new DataTable();
            od.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
