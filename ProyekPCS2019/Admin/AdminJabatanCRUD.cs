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

namespace ProyekPCS2019.Admin
{
    public partial class AdminJabatanCRUD : Form
    {
        OracleConnection conn = new OracleConnection();
        public AdminJabatanCRUD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //insert
            conn.Open();
            OracleTransaction mytrans = conn.BeginTransaction();
            if (textBox1.Text != "")
            {
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into jabatan values('" + textBox1.Text + "'," + numericUpDown1.Value + ")";
                    cmd.ExecuteNonQuery();
                    mytrans.Commit();
                }
                catch (Exception ex)
                {
                    mytrans.Rollback();
                    if (ex.Message== "ORA-00001: unique constraint (PROYEK.PK_JABATAN) violated")
                    {
                        MessageBox.Show("JABATAN SUDAH ADA ! ");
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            conn.Close();
            refresh();
        }

        private void AdminJabatanCRUD_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            numericUpDown1.Maximum = 999999999999;
            numericUpDown2.Maximum = 999999999999;
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
            cmd.CommandText = "select * from jabatan";
            da.SelectCommand = cmd;
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            OracleDataAdapter da1 = new OracleDataAdapter();
            DataTable dt1 = new DataTable();
            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "select nama_jabatan from jabatan";
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

        private void button2_Click(object sender, EventArgs e)
        {
            //update
            conn.Open();
            OracleTransaction mytrans = conn.BeginTransaction();
            try
            {
                //gaji
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "update jabatan set gaji_jabatan=" + numericUpDown2.Value + " where nama_jabatan='" + comboBox1.Text + "'";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select gaji_jabatan from jabatan where nama_jabatan='"+comboBox1.Text+"'";
            numericUpDown2.Value = Convert.ToInt64(cmd.ExecuteScalar().ToString());
            conn.Close();
        }
    }

}
