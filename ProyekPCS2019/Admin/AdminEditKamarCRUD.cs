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

namespace ProyekPCS2019.Admin
{
    public partial class AdminEditKamarCRUD : Form
    {
        OracleConnection conn = new OracleConnection();
        public AdminEditKamarCRUD()
        {
            InitializeComponent();
        }

        private void AdminEditKamarCRUD_Load(object sender, EventArgs e)
        {
            //2 UNTUK JENIS KAMAR 4 UNTUK KAMAR
            dataGridView2.Visible = false;
            dataGridView4.Visible = false;
            //didisable dulu ini buat auto insert kamar
            label4.Visible = false;
            numericUpDown1.Visible = false;
            numericUpDown1.Enabled = false;

            conn.ConnectionString = "User ID=proyek;Password=1;Data Source=orcl";
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.ConnectionString = "User ID=proyek;Password=1;Data Source=orcl";
                    conn.Open();
                }
                else
                {
                    conn.ConnectionString = "User ID=proyek;Password=1;Data Source=orcl";
                    conn.Open();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            refresh();
        }

        public void refresh()
        {
            //JENIS KAMAR
            conn.Open();
            OracleDataAdapter da = new OracleDataAdapter();
            DataTable dt = new DataTable();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from jenis_kamar";
            da.SelectCommand = cmd;
            da.Fill(dt);
            dataGridViewJenis.DataSource = dt;

            if (dataGridViewJenis.Columns.Count < 4)
            {
                DataGridViewButtonColumn newbtn = new DataGridViewButtonColumn();
                newbtn.DefaultCellStyle.SelectionForeColor = Color.Green;
                newbtn.DefaultCellStyle.BackColor = Color.Green;
                newbtn.DefaultCellStyle.ForeColor = Color.Green;
                newbtn.HeaderText = "Action";
                newbtn.Name = "Button";
                newbtn.Text = "Delete";
                newbtn.UseColumnTextForButtonValue = true;
                dataGridViewJenis.Columns.Add(newbtn);
            }

            OracleDataAdapter da1 = new OracleDataAdapter();
            DataTable dt1 = new DataTable();
            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "select kode_jenis from jenis_kamar";
            da1.SelectCommand = cmd1;
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox4.Items.Clear();
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                comboBox1.Items.Add(dataGridView2.Rows[i].Cells[0].Value.ToString());
                comboBox2.Items.Add(dataGridView2.Rows[i].Cells[0].Value.ToString());
                comboBox4.Items.Add(dataGridView2.Rows[i].Cells[0].Value.ToString());
            }


            //KAMAR

            OracleDataAdapter da2 = new OracleDataAdapter();
            DataTable dt2 = new DataTable();
            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "select * from kamar";
            da2.SelectCommand = cmd2;
            da2.Fill(dt2);
            dataGridViewKamar.DataSource = dt2;

            if (dataGridViewKamar.Columns.Count < 5)
            {
                DataGridViewButtonColumn newbtn = new DataGridViewButtonColumn();
                newbtn.DefaultCellStyle.SelectionForeColor = Color.Green;
                newbtn.DefaultCellStyle.BackColor = Color.Green;
                newbtn.DefaultCellStyle.ForeColor = Color.Green;
                newbtn.HeaderText = "Action";
                newbtn.Name = "Button";
                newbtn.Text = "Delete";
                newbtn.UseColumnTextForButtonValue = true;
                dataGridViewKamar.Columns.Add(newbtn);
            }

            OracleDataAdapter da3 = new OracleDataAdapter();
            DataTable dt3 = new DataTable();
            OracleCommand cmd3 = new OracleCommand();
            cmd3.Connection = conn;
            cmd3.CommandText = "select id_kamar from kamar";
            da3.SelectCommand = cmd3;
            da3.Fill(dt3);
            dataGridView4.DataSource = dt3;
            comboBox3.Items.Clear();
            for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
            {
                comboBox3.Items.Add(dataGridView4.Rows[i].Cells[0].Value.ToString());
            }
            conn.Close();

        }

        //insert jenis
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                conn.Open();
                OracleTransaction mytrans = conn.BeginTransaction();
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into jenis_kamar values('','" + textBox1.Text + "','" + textBox2.Text + "')";
                    cmd.ExecuteNonQuery();
                    mytrans.Commit();
                }
                catch (Exception ex)
                {
                    mytrans.Rollback();
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
            }
            refresh();
        }

        //update jenis
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox3.Text != "" && textBox4.Text != "")
            {
                conn.Open();
                OracleTransaction mytrans = conn.BeginTransaction();
                try
                {
                    //nama
                    OracleCommand cmd = new OracleCommand();
                    cmd.CommandText = "update jenis_kamar set nama_jenis='" + textBox3.Text + "' where kode_jenis='" + comboBox4.Text + "'";
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();

                    //jenis
                    OracleCommand cmd1 = new OracleCommand();
                    cmd1.CommandText = "update jenis_kamar set harga_jenis='" + textBox4.Text + "' where kode_jenis='" + comboBox4.Text + "'";
                    cmd1.Connection = conn;
                    cmd1.ExecuteNonQuery();
                
                    mytrans.Commit();
                }
                catch (Exception ex)
                {
                    mytrans.Rollback();
                    MessageBox.Show(ex.Message);
                }

                conn.Close();
            }
            else MessageBox.Show("Semua field harus terisi");

            refresh();
        }

        //insert kamar
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                conn.Open();
                OracleTransaction mytrans = conn.BeginTransaction();
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into kamar (kode_jenis, id_membership, tersedia) values('" + comboBox1.Text + "',null,'Y')";
                    cmd.ExecuteNonQuery();
                    mytrans.Commit();
                    comboBox1.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    mytrans.Rollback();
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
            }
            refresh();
        }

        //update kamar
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1 && comboBox2.SelectedIndex > -1)
            {
                conn.Open();
                OracleTransaction mytrans = conn.BeginTransaction();
                try
                {
                    //kode
                    OracleCommand cmd = new OracleCommand();
                    cmd.CommandText = "update kamar set kode_jenis='" + comboBox2.Text + "' where id_kamar='" + comboBox3.Text + "'";
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();

                    mytrans.Commit();
                }
                catch (Exception ex)
                {
                    mytrans.Rollback();
                    MessageBox.Show(ex.Message);
                }

                conn.Close();
            }
            refresh();
        }

        //delete jenis kamar
        private void dataGridViewJenis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string id = dataGridViewJenis.Rows[e.RowIndex].Cells[1].Value.ToString();
                conn.Open();
                OracleTransaction mytrans = conn.BeginTransaction();
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.CommandText = "delete from jenis_kamar where kode_jenis='" + id + "'";
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    mytrans.Commit();
                }
                catch (Exception ex)
                {
                    mytrans.Rollback();
                    if (ex.Message == "ORA-02292: integrity constraint (PROYEK.FK_KAMAR) violated - child record found")
                    {
                        MessageBox.Show("Delete Semua Kamar dengan Jenis ini terlebih dahulu");
                    }
                }
                conn.Close();
                refresh();
            }
        }

        //delete kamar
        private void dataGridViewKamar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string id = dataGridViewKamar.Rows[e.RowIndex].Cells[1].Value.ToString();
                conn.Open();
                OracleTransaction mytrans = conn.BeginTransaction();
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.CommandText = "delete from kamar where id_kamar='" + id + "'";
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    mytrans.Commit();
                }
                catch (Exception ex)
                {
                    mytrans.Rollback();
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
                refresh();
            }
        }

        //cek info update jenis
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex > -1)
            {
                conn.Open();
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    //nama
                    cmd.CommandText = "select nama_jenis from jenis_kamar where kode_jenis='" + comboBox4.Text + "'";
                    textBox3.Text = cmd.ExecuteScalar().ToString();
                    //harga
                    cmd.CommandText = "select harga_jenis from jenis_kamar where kode_jenis='" + comboBox4.Text + "'";
                    textBox4.Text = cmd.ExecuteScalar().ToString();

                }
                catch (Exception)
                {

                }
                conn.Close();
            }
        }

        //cek update kamar
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex > -1)
            {
                conn.Open();
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    //STATUS
                    cmd.CommandText = "select tersedia from kamar where id_kamar='" + comboBox3.Text + "'";
                    if (cmd.ExecuteScalar().ToString() == "N")
                    {
                        button1.Enabled = false;
                        button1.Text = "DIPAKAI";
                    }
                    else if (cmd.ExecuteScalar().ToString() == "Y")
                    {
                        button1.Enabled = true;
                        button1.Text = "UPDATE";
                    }
                }
                catch (Exception)
                {

                }
                conn.Close();
            }
        }
        
    }
}
