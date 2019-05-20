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
    public partial class EditMembership : Form
    {
        OracleConnection conn = new OracleConnection();
        public EditMembership()
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
            //refresh data grid view
            conn.Open();
            OracleDataAdapter da = new OracleDataAdapter();
            DataTable dt = new DataTable();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from membership";
            da.SelectCommand = cmd;
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            if (dataGridView1.Columns.Count < 7)
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
            //refresh isi combo box
            OracleDataAdapter da1 = new OracleDataAdapter();
            DataTable dt1 = new DataTable();
            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "select id_membership from membership";
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

        private void button1_Click(object sender, EventArgs e)
        {
            //insert
            if (textBox1.Text!=""&& textBox2.Text != ""&& textBox3.Text != ""&& textBox4.Text != "")
            {
                conn.Open();
                OracleTransaction mytrans = conn.BeginTransaction();
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into membership values('','"+textBox1.Text+ "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "',1)";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //delete
            if (e.ColumnIndex == 0)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                //delete
                conn.Open();
                OracleTransaction mytrans = conn.BeginTransaction();
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.CommandText = "delete from membership where id_membership='" + id + "'";
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    mytrans.Commit();
                }
                catch (Exception ex)
                {
                    mytrans.Rollback();
                    if (ex.Message== "ORA-02292: integrity constraint (PROYEK.FK_MEMBERBOOKING) violated - child record found")
                    {
                        MessageBox.Show("Member Sedang Menggunakan Ruangan Hotel");
                    }
                }
                conn.Close();
                refresh();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex>-1)
            {
                conn.Open();
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    //nama
                    cmd.CommandText = "select nama from membership where id_membership='" + comboBox1.Text + "'";
                    textBox5.Text = cmd.ExecuteScalar().ToString();
                    //alamat
                    cmd.CommandText = "select alamat from membership where id_membership='" + comboBox1.Text + "'";
                    textBox6.Text = cmd.ExecuteScalar().ToString();
                    //no_telp
                    cmd.CommandText = "select no_telp from membership where id_membership='" + comboBox1.Text + "'";
                    textBox7.Text = cmd.ExecuteScalar().ToString();
                    //email
                    cmd.CommandText = "select email from membership where id_membership='" + comboBox1.Text + "'";
                    textBox8.Text = cmd.ExecuteScalar().ToString();
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
                //nama
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "update membership set nama='" + textBox5.Text + "' where id_membership='" + comboBox1.Text + "'";
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                //alamat
                OracleCommand cmd1 = new OracleCommand();
                cmd1.CommandText = "update membership set alamat='" + textBox6.Text + "' where id_membership='" + comboBox1.Text + "'";
                cmd1.Connection = conn;
                cmd1.ExecuteNonQuery();

                //nomor telpon
                OracleCommand cmd2 = new OracleCommand();
                cmd2.CommandText = "update membership set no_telp='" + textBox7.Text + "' where id_membership='" + comboBox1.Text + "'";
                cmd2.Connection = conn;
                cmd2.ExecuteNonQuery();

                //email
                OracleCommand cmd3 = new OracleCommand();
                cmd3.CommandText = "update membership set email='" + textBox8.Text + "' where id_membership='" + comboBox1.Text + "'";
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
    }
}
