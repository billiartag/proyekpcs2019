using Oracle.DataAccess.Client;
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
    public partial class EditPegawaiCRUD : Form
    {
        OracleConnection conn = new OracleConnection();
        public EditPegawaiCRUD()
        {
            InitializeComponent();
        }

        private void MainMaster_Load(object sender, EventArgs e)
        {
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
            conn.Open();
            OracleDataAdapter da = new OracleDataAdapter();
            DataTable dt = new DataTable();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from pegawai";
            da.SelectCommand = cmd;
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            if (dataGridView1.Columns.Count<6)
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
            cmd1.CommandText = "select id_pegawai from pegawai";
            da1.SelectCommand = cmd1;
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            comboBox3.Items.Clear();
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                comboBox3.Items.Add(dataGridView2.Rows[i].Cells[0].Value.ToString());
            }
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //insert
            conn.Open();
            OracleTransaction mytrans = conn.BeginTransaction();
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    if (radioButton1.Checked == true)
                    {
                        cmd.CommandText = "insert into pegawai values('','" + textBox1.Text + "','L','" + comboBox1.Text + "','" + textBox2.Text + "')";
                    }
                    else if (radioButton2.Checked == true)
                    {
                        cmd.CommandText = "insert into pegawai values('','" + textBox1.Text + "','P','" + comboBox1.Text + "','" + textBox2.Text + "')";
                    }
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    mytrans.Commit();
                }
                catch (Exception ex)
                {
                    mytrans.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
            conn.Close();
            refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==0)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                //delete
                conn.Open();
                OracleTransaction mytrans = conn.BeginTransaction();
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.CommandText = "delete from pegawai where id_pegawai='"+id+"'";
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex>-1)
            {
                conn.Open();
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    //nama
                    cmd.CommandText = "select nama_pegawai from pegawai where id_pegawai='"+comboBox3.Text+"'";
                    textBox3.Text = cmd.ExecuteScalar().ToString();
                    //jenis kelamin
                    cmd.CommandText = "select jenis_kelamin from pegawai where id_pegawai='" + comboBox3.Text + "'";
                    if (cmd.ExecuteScalar().ToString()=="L")
                    {
                        radioButton4.Checked = true;
                    }
                    else if (cmd.ExecuteScalar().ToString() == "P")
                    {
                        radioButton3.Checked = true;
                    }
                    //jabatan
                    cmd.CommandText = "select jabatan from pegawai where id_pegawai='" + comboBox3.Text + "'";
                    comboBox2.Text = cmd.ExecuteScalar().ToString();
                    //alamat
                    cmd.CommandText = "select alamat from pegawai where id_pegawai='" + comboBox3.Text + "'";
                    textBox4.Text = cmd.ExecuteScalar().ToString();
                }
                catch (Exception)
                {
                    
                }
                conn.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update
            conn.Open();
            OracleTransaction mytrans = conn.BeginTransaction();
            try
            {
                //jenis kelamin
                OracleCommand cmd = new OracleCommand();
                string jenis = "";
                if (radioButton4.Checked == true)
                {
                    jenis = "L";
                }
                else if (radioButton3.Checked == true)
                {
                    jenis = "P";
                }
                cmd.CommandText = "update pegawai set jenis_kelamin='" + jenis + "' where id_pegawai='" + comboBox3.Text + "'";
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                //nama
                OracleCommand cmd1 = new OracleCommand();
                cmd1.CommandText = "update pegawai set nama_pegawai='" + textBox3.Text + "' where id_pegawai='" + comboBox3.Text + "'";
                cmd1.Connection = conn;
                cmd1.ExecuteNonQuery();

                //jabatan
                OracleCommand cmd2 = new OracleCommand();
                cmd2.CommandText = "update pegawai set jabatan='" + comboBox2.Text + "' where id_pegawai='" + comboBox3.Text + "'";
                cmd2.Connection = conn;
                cmd2.ExecuteNonQuery();

                //alamat
                OracleCommand cmd3 = new OracleCommand();
                cmd3.CommandText = "update pegawai set alamat='" + textBox4.Text + "' where id_pegawai='" + comboBox3.Text + "'";
                cmd3.Connection = conn;
                cmd3.ExecuteNonQuery();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
