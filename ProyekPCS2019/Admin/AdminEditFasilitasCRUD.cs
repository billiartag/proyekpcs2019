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
    public partial class AdminEditFasilitasCRUD : Form
    {
        OracleConnection conn = new OracleConnection();

        public AdminEditFasilitasCRUD()
        {
            InitializeComponent();
        }

        private void AdminEditFasilitasCRUD_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            dataGridView2.Visible = false;
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
            cmd.CommandText = "select * from fasilitas";
            da.SelectCommand = cmd;
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            if (dataGridView1.Columns.Count < 5)
            {
                DataGridViewButtonColumn newbtn = new DataGridViewButtonColumn();
                newbtn.DefaultCellStyle.SelectionForeColor = Color.Green;
                newbtn.DefaultCellStyle.BackColor = Color.Green;
                newbtn.DefaultCellStyle.ForeColor = Color.Green;
                newbtn.HeaderText = "Action";
                newbtn.Name = "Button";
                newbtn.Text = "Delete";
                newbtn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(newbtn);
            }

            OracleDataAdapter da1 = new OracleDataAdapter();
            DataTable dt1 = new DataTable();
            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "select id_fasilitas from fasilitas";
            da1.SelectCommand = cmd1;
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            comboBox1.Items.Clear();
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                comboBox1.Items.Add(dataGridView2.Rows[i].Cells[0].Value.ToString());
            }
            conn.Close();
        }

        //read
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                conn.Open();
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    //nama
                    cmd.CommandText = "select nama_fasilitas from fasilitas where id_fasilitas='" + comboBox1.Text + "'";
                    textBox4.Text = cmd.ExecuteScalar().ToString();
                    //harga
                    cmd.CommandText = "select harga_fasilitas from fasilitas where id_fasilitas='" + comboBox1.Text + "'";
                    numericUpDown2.Value = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    //desc
                    cmd.CommandText = "select deskripsi from fasilitas where id_fasilitas='" + comboBox1.Text + "'";
                    richTextBox2.Text = cmd.ExecuteScalar().ToString();

                }
                catch (Exception)
                {

                }
                conn.Close();
            }
        }

        //insert
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && numericUpDown1.Value != 0 && richTextBox1.Text != "")
            {
                conn.Open();
                OracleTransaction mytrans = conn.BeginTransaction();
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into fasilitas (nama_fasilitas, harga_fasilitas, deskripsi) values('" + textBox1.Text + "','" + numericUpDown1.Value + "','" + richTextBox1.Text + "')";
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
            else MessageBox.Show("Semua field harus terisi");
            refresh();
        }

        //update
        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleTransaction mytrans = conn.BeginTransaction();
            if (comboBox1.SelectedIndex > -1 && numericUpDown2.Value != 0 && textBox4.Text != "" && richTextBox2.Text != "") {
                try
                {
                    //nama
                    OracleCommand cmd = new OracleCommand();
                    cmd.CommandText = "update fasilitas set nama_fasilitas='" + textBox4.Text + "' where id_fasilitas='" + comboBox1.Text + "'";
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();

                    //harga
                    OracleCommand cmd1 = new OracleCommand();
                    cmd1.CommandText = "update fasilitas set harga_fasilitas='" + numericUpDown2.Value + "' where id_fasilitas='" + comboBox1.Text + "'";
                    cmd1.Connection = conn;
                    cmd1.ExecuteNonQuery();

                    //desc
                    OracleCommand cmd2 = new OracleCommand();
                    cmd2.CommandText = "update fasilitas set deskripsi='" + richTextBox2.Text + "' where id_fasilitas='" + comboBox1.Text + "'";
                    cmd2.Connection = conn;
                    cmd2.ExecuteNonQuery();

                    mytrans.Commit();
                }
                catch (Exception ex)
                {
                    mytrans.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Semua field harus terisi");

            conn.Close();
            refresh();
        }

        //delete
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                conn.Open();
                OracleTransaction mytrans = conn.BeginTransaction();
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.CommandText = "delete from fasilitas where id_fasilitas='" + id + "'";
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
    }
}
