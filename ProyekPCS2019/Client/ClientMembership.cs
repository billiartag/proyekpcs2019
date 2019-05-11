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

        private void button1_Click(object sender, EventArgs e)
        {
            groupBoxCek.Visible = false;
            groupBoxBuat.Visible = true;
            cekButton();
        }

        private void ClientMembership_Load(object sender, EventArgs e)
        {
            groupBoxCek.Visible = true;
            groupBoxBuat.Visible = false;
            cekButton();
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
        }
        void cekButton()
        {
            if (groupBoxCek.Visible) { buttonCek.Enabled = false; buttonBuat.Enabled = true; }
            else if (groupBoxBuat.Visible) { buttonCek.Enabled = true; buttonBuat.Enabled = false; }
        }

        private void buttonCek_Click(object sender, EventArgs e)
        {
            groupBoxCek.Visible = true;
            groupBoxBuat.Visible = false;
            cekButton();
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
                        Console.WriteLine("ahaha");
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("aha");
                        string userid = getuserid.ExecuteScalar().ToString();
                        MessageBox.Show(userid);
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
            OracleDataAdapter tampung = new OracleDataAdapter("select * from membership where id_membership='" + textBoxidMember.Text.ToUpper() + "'", conn);
            DataTable tabeldatamember = new DataTable();
            tampung.Fill(tabeldatamember);
            labelnamamember.Text = tabeldatamember.Rows[0].ItemArray[1].ToString();
            labelAlamatMember.Text = tabeldatamember.Rows[0].ItemArray[2].ToString();
            labelNoMember.Text = tabeldatamember.Rows[0].ItemArray[3].ToString();
            labelEmailMember.Text = tabeldatamember.Rows[0].ItemArray[4].ToString();

            OracleDataAdapter tampung2 = new OracleDataAdapter("select * from membership where id_membership='" + textBoxidMember.Text + "'", conn);
            DataTable tabeldatatrx = new DataTable();
            tampung2.Fill(tabeldatatrx);
            listBox1.DataSource = tabeldatatrx;
        }
    }
}
