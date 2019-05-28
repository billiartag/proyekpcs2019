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
        Image img;
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
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
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
                            img = Image.FromFile(Application.StartupPath+"/gambar_fasilitas/" + textBoxIDFasilitas.Text + ".jpg");
                            pictureBox1.Image = img;
                        }
                        catch (Exception ex)
                        {
                            pictureBox1.Image.Dispose();
                            pictureBox1.Image = null; 
                        }
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                img.Dispose();
            }
            catch (Exception)
            {
                
            }
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Title = "Pilih gambar untuk fasilitas " + textBoxNamaFasilitas.Text;
            openFileDialog1.Filter = "File jpg|*.jpg";
            string filepath1 = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                try
                {
                    img = Image.FromFile(openFileDialog1.FileName);
                    string filepath = Application.StartupPath + "\\gambar_fasilitas\\" + textBoxIDFasilitas.Text + ".jpg";
                    filepath1 = filepath;
                    if (!System.IO.Directory.Exists("\\gambar_fasilitas\\")) {
                        System.IO.Directory.CreateDirectory("\\gambar_fasilitas\\");
                    }
                    if (System.IO.File.Exists(filepath))
                    {
                        System.IO.File.Delete(filepath);
                        img.Save(filepath);
                    }
                    else
                    {
                        img.Save(filepath);
                    }
                    pictureBox1.Image = Image.FromFile(Application.StartupPath+"\\gambar_fasilitas\\" + textBoxIDFasilitas.Text + ".jpg");
                    MessageBox.Show("\\Gambar berhasil diubah!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(filepath1+"\n"+ex.ToString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleTransaction ot = conn.BeginTransaction();
            try
            { 
                OracleCommand cmd = new OracleCommand("UPDATE FASILITAS SET HARGA_FASILITAS=" + numericUpDownHargaFasilitas.Value.ToString() + " ,DESKRIPSI='" + richTextBoxDeskripsi.Text + "' WHERE ID_FASILITAS='" + textBoxIDFasilitas.Text + "'", conn);
                cmd.ExecuteNonQuery();
                ot.Commit();
                MessageBox.Show("Berhasil mengubah detail fasilitas!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ot.Rollback();
            }
        }
    }
}
