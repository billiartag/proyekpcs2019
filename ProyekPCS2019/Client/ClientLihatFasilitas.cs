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
    public partial class ClientLihatFasilitas : Form
    {
        OracleConnection conn;
        string userID;
        public ClientLihatFasilitas(OracleConnection cn,string id)
        {
            userID = id;
            conn = cn;
            InitializeComponent();
        }

        private void ClientLihatFasilitas_Load(object sender, EventArgs e)
        {
            OracleDataAdapter od = new OracleDataAdapter("SELECT * FROM FASILITAS", conn);
            DataTable dt = new DataTable();
            od.Fill(dt);
            listBox1.DisplayMember = "nama_fasilitas";
            listBox1.ValueMember= "id_fasilitas";
            listBox1.DataSource = dt;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleDataAdapter data_fasilitas = new OracleDataAdapter("SELECT * FROM FASILITAS WHERE ID_FASILITAS='"+listBox1.SelectedValue.ToString()+"'", conn);
            DataTable dt = new DataTable();
            data_fasilitas.Fill(dt);
            richTextBox1.Text = dt.Rows[0].ItemArray[3].ToString();
            Image gambar = Image.FromFile("gambar_fasilitas/" + listBox1.SelectedValue.ToString() + ".jpg");
            pictureBox1.Image = gambar;
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
