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
            //refresh data grid view member aktif
            conn.Open();
            OracleDataAdapter da = new OracleDataAdapter();
            DataTable dt = new DataTable();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from membership where status=1";
            da.SelectCommand = cmd;
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
            //refresh data grid view member tidak aktif
            OracleDataAdapter da2 = new OracleDataAdapter();
            DataTable dt2 = new DataTable();
            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "select * from membership where status=0";
            da2.SelectCommand = cmd2;
            da2.Fill(dt2);
            dataGridView3.DataSource = dt2;

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
                    //users
                    cmd.CommandText = "select max(to_number(substr(id_membership,3,3))) from membership";
                    string username = "ME";
                    username = username + cmd.ExecuteScalar().ToString().PadLeft(3,'0');
                    cmd.CommandText = "insert into users values('" + username + "','" + username + "','CUSTOMER')";
                    cmd.ExecuteNonQuery();
                    mytrans.Commit();
                    MessageBox.Show("USERNAME ANDA : "+username+"\nPASSWORD ANDA : "+ username);
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
                    //STATUS
                    cmd.CommandText = "select STATUS from membership where id_membership='" + comboBox1.Text + "'";
                    if (cmd.ExecuteScalar().ToString()=="1")
                    {
                        comboBox2.Text = "AKTIF";
                    }
                    else if (cmd.ExecuteScalar().ToString() == "0")
                    {
                        comboBox2.Text = "TIDAK AKTIF";
                    }
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

                //STATUS
                OracleCommand cmd4 = new OracleCommand();
                if (comboBox2.Text=="TIDAK AKTIF")
                {
                    cmd4.CommandText = "update membership set STATUS=0 where id_membership='" + comboBox1.Text + "'";
                    cmd4.Connection = conn;
                    cmd4.ExecuteNonQuery();
                }
                else if (comboBox2.Text=="AKTIF")
                {
                    cmd4.CommandText = "update membership set STATUS=1 where id_membership='" + comboBox1.Text + "'";
                    cmd4.Connection = conn;
                    cmd4.ExecuteNonQuery();
                }

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
