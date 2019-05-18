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

namespace ProyekPCS2019.Manager
{
    public partial class ManagerFasilitas : Form
    {
        OracleConnection conn;
        string user;
        DataTable listFasilitas = new DataTable();
        public ManagerFasilitas(string username, OracleConnection oc)
        {
            InitializeComponent();
            user = username;
            conn = oc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manager.MainManager mm = new MainManager(user,conn);
            this.Hide();
            mm.ShowDialog();
            this.Close();
        }
        void loadFasilitas() {
            OracleDataAdapter od = new OracleDataAdapter("SELECT * FROM FASILITAS", conn);
            listFasilitas.Clear();
            od.Fill(listFasilitas);
        }
        private void ManagerFasilitas_Load(object sender, EventArgs e)
        {
            loadFasilitas();
            listBox1.DisplayMember = "nama_fasilitas";
            listBox1.ValueMember = "id_fasilitas";
            listBox1.DataSource = listFasilitas;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                for (int i = 0; i < listFasilitas.Rows.Count; i++)
                {
                    if (listFasilitas.Rows[i].ItemArray[0].ToString() == listBox1.SelectedValue.ToString())
                    {
                        textBoxIDFasilitas.Text = listFasilitas.Rows[i].ItemArray[0].ToString();
                        textBoxNamaFasilitas.Text = listFasilitas.Rows[i].ItemArray[1].ToString();
                        numericUpDownHargaFasilitas.Value=Convert.ToInt32(listFasilitas.Rows[i].ItemArray[2].ToString());
                        richTextBoxDeskripsi.Text = listFasilitas.Rows[i].ItemArray[3].ToString();
                        try
                        {
                            Image img = Image.FromFile("z2.png");
                            pictureBox1.Image = img;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
        }
    }
}
