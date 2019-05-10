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

namespace ProyekPCS2019
{
    public partial class MainFrontOffice : Form
    {
        public MainFrontOffice()
        {
            InitializeComponent();
        }
        OracleConnection conn = new OracleConnection("User ID=aaa;Password=1;Data Source=orcl");
        
        private void MainFrontOffice_Load(object sender, EventArgs e)
        {
            loadjeniskamar();
        }
        public void loadjeniskamar() {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("Select * from jenis_kamar", conn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.ValueMember = "kode_jenis";
                comboBox1.DisplayMember = "nama_jenis";
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }
        public void loadDataKamar(string id_jenis) {
            
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("Select * from kamar where kode_jenis = '" + id_jenis + "'", conn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                dataGridView1.DataSource = dt;
                if (dataGridView1.ColumnCount < 5)
                {
                    DataGridViewButtonColumn newbtn = new DataGridViewButtonColumn();
                    newbtn.DefaultCellStyle.SelectionForeColor = Color.Green;
                    newbtn.DefaultCellStyle.BackColor = Color.Green;
                    newbtn.DefaultCellStyle.ForeColor = Color.Green;
                    newbtn.HeaderText = "Action";
                    newbtn.Name = "Button";
                    newbtn.Text = "Check In";
                    newbtn.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(newbtn);


                    newbtn = new DataGridViewButtonColumn();
                    newbtn.DefaultCellStyle.SelectionForeColor = Color.Red;
                    newbtn.DefaultCellStyle.BackColor = Color.Red;
                    newbtn.DefaultCellStyle.ForeColor = Color.Red;
                    newbtn.HeaderText = "Action";
                    newbtn.Name = "Button";
                    newbtn.Text = "Check Out";
                    newbtn.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(newbtn);
                }


                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("Select count(*) from kamar where kode_jenis = '" + comboBox1.SelectedValue + "' and upper(tersedia) = 'YA'", conn);
                textBox1.Text = cmd.ExecuteScalar().ToString();
                loadDataKamar(comboBox1.SelectedValue.ToString());
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }
        public void checkIn(string id_kamar) {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("Select count(id_kamar) from kamar where id_kamar = '" + id_kamar + "' and tgl_checkin is null", conn);
                int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                //MessageBox.Show("Test -->"+temp);
                if(temp==0)
                {
                    MessageBox.Show("Room is not Available Right now!","error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                }
                else
                {
                    string date = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
                    string update = "update kamar set tersedia = 'tidak', tgl_checkin = to_date('"+date+"','dd-mm-yyyy') where id_kamar = '"+id_kamar+"'";
                    cmd = new OracleCommand(update, conn);
                    cmd.ExecuteNonQuery();
                    loadDataKamar(comboBox1.SelectedValue.ToString());
                    MessageBox.Show(id_kamar + " has Checked in");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }
        public void checkOut(string id_kamar)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("Select count(*) from kamar where id_kamar = '" + id_kamar + "' and tgl_checkin is not null", conn);
                int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                
                if(temp == 0)
                {
                    MessageBox.Show("Room is Empty!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    string date = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
                    string update = "update kamar set tersedia = 'ya', tgl_checkin = null where id_kamar = '"+id_kamar+"'";
                    cmd = new OracleCommand(update, conn);
                    cmd.ExecuteNonQuery();
                    loadDataKamar(comboBox1.SelectedValue.ToString());
                    MessageBox.Show(id_kamar + " has Checked out");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex+"clickeddddd");
            if (e.ColumnIndex == 4)
            {
                //MessageBox.Show("clicked -- >"+ dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                checkIn(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            else if(e.ColumnIndex == 5)
            {
                //MessageBox.Show("clicked -- >" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                checkOut(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }

        }
    }
}
