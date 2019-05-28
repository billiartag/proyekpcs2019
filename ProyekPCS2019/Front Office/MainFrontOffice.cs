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
        OracleConnection conn = new OracleConnection("User ID=proyek;Password=1;Data Source=orcl");
        
        private void MainFrontOffice_Load(object sender, EventArgs e)
        {
            loadjeniskamar();
            loadmembership();
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

        public void loadmembership()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("Select * from membership", conn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "nama";
                comboBox2.ValueMember = "id_membership";
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
        public void loadDataKamar(string id_jenis,string key)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("Select * from kamar where kode_jenis = '" + id_jenis + "' and id_kamar like '%"+key+"%'", conn);
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
                OracleCommand cmd = new OracleCommand("Select count(*) from kamar where kode_jenis = '" + comboBox1.SelectedValue + "' and upper(tersedia) = 'Y'", conn);
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
                string tgl = dateTimePicker5.Value.Day + "-" + dateTimePicker5.Value.Month + "-" + dateTimePicker5.Value.Year;
                string sql = "SELECT count(id_kamar) from booking where tgl_msk = to_date('"+tgl+"','dd-mm-yyyy') and id_kamar = '"+id_kamar+"'";
                OracleCommand cmdcek = new OracleCommand(sql, conn);
                int num = Convert.ToInt32(cmdcek.ExecuteScalar().ToString());
                Boolean book = true;
                if (num == 0)
                {
                    book = false;
                    MessageBox.Show("Room isn't book yet!");
                }
                if (book)
                {
                    OracleCommand cmd = new OracleCommand("Select count(id_kamar) from kamar where id_kamar = '" + id_kamar + "' and upper(tersedia) = 'Y'", conn);
                    int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    //MessageBox.Show("Test -->"+temp);
                    if (temp == 0)
                    {
                        MessageBox.Show("Room is not Available Right now!", "error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        string date = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
                        string update = "update kamar set tersedia = 'N' where id_kamar = '" + id_kamar + "'";
                        cmd = new OracleCommand(update, conn);
                        cmd.ExecuteNonQuery();
                        //MessageBox.Show("update kamar lewat");
                        //buat kode trans
                        //MessageBox.Show("Test : "+ dateTimePicker5.Value.Month.ToString());
                        string kodetrans = dateTimePicker5.Value.Month.ToString() + dateTimePicker5.Value.Year.ToString().Substring(2, 2);

                        //MessageBox.Show("kodetrans : "+kodetrans);
                        sql = "select count(id_transaksi) from h_transaksi where substr(id_transaksi,0,3) = '"+kodetrans+"'";
                        cmd = new OracleCommand(sql, conn);
                        int jum = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                        jum++;
                        kodetrans += jum.ToString().PadLeft(3,'0');
                        //MessageBox.Show("buat kode lewat");
                        //ambil tgl keluar
                        sql = "select to_char(tgl_keluar,'dd-mm-yyyy') from booking where tgl_msk = to_date('"+tgl+"','dd-mm-yyyy') and id_kamar = '"+id_kamar+"'";
                        cmd = new OracleCommand(sql, conn);
                        string tglkeluar = cmd.ExecuteScalar().ToString();
                        //MessageBox.Show("ambil tgl keluar lewat");
                        //ambil tgl membership
                        sql = "select id_membership from booking where tgl_msk = to_date('" + tgl + "','dd-mm-yyyy') and id_kamar = '" + id_kamar + "'";
                        cmd = new OracleCommand(sql, conn);
                        string member = cmd.ExecuteScalar().ToString();
                        //MessageBox.Show("ambil membership lewat : "+member);
                        //ambil tgl kode_booking
                        sql = "select kode_booking from booking where tgl_msk = to_date('" + tgl + "','dd-mm-yyyy') and id_kamar = '" + id_kamar + "'";
                        cmd = new OracleCommand(sql, conn);
                        string kodebook = cmd.ExecuteScalar().ToString();
                        //MessageBox.Show("ambil kode booking lewat");


                        sql = "insert into h_transaksi values('"+kodetrans+"','"+id_kamar+"','0','"+member+"','"+kodebook+"',to_date('"+tgl+"','dd-mm-yyyy'),to_date('"+tglkeluar+"','dd-mm-yyyy'))";
                        cmd = new OracleCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                        loadDataKamar(comboBox1.SelectedValue.ToString());
                        MessageBox.Show(id_kamar + " has Checked in");
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Oracle Error : "+ex.Message);
            }
        }
        public void checkOut(string id_kamar)
        {
            //MessageBox.Show("Test");
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("Select count(*) from kamar where id_kamar = '" + id_kamar + "' and tersedia = 'N'", conn);
                int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                
                if(temp == 0)
                {
                    MessageBox.Show("Room is Empty!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    DateTime curtime = Convert.ToDateTime(dateTimePicker5.Value.ToShortDateString());
                    string sqlcek = "SELECT tgl_checkout FROM h_transaksi WHERE id_kamar = '" + id_kamar + "' ORDER BY tgl_checkin DESC";
                    OracleCommand cmd3 = new OracleCommand(sqlcek, conn);
                    string tgl2 = cmd3.ExecuteScalar().ToString();
                    DateTime tglout = Convert.ToDateTime(tgl2);
                    Boolean cektgl;
                    //MessageBox.Show(tglout+" -- now : "+curtime);
                    if (curtime == tglout)
                    {
                        cektgl = true;
                    }
                    else
                    {
                        cektgl = false;
                    }
                    if (cektgl)
                    {
                        if(conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        conn.Open();
                        string update = "update kamar set tersedia = 'Y' where id_kamar = '" + id_kamar + "'";
                        cmd = new OracleCommand(update, conn);
                        cmd.ExecuteNonQuery();
                        loadDataKamar(comboBox1.SelectedValue.ToString());
                        MessageBox.Show(id_kamar + " has Checked out");

                        conn.Open();
                        //total fasilitas 
                        string sql = "SELECT id_transaksi FROM h_transaksi WHERE id_kamar = '" + id_kamar + "' ORDER BY tgl_checkin DESC";
                        cmd = new OracleCommand(sql, conn);
                        string idtrans = cmd.ExecuteScalar().ToString();
                        //MessageBox.Show("1");


                        sql = "select DISTINCT id_fasilitas from d_transaksi where id_transaksi = '"+idtrans+"'";
                        cmd = new OracleCommand(sql, conn);
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        //MessageBox.Show("2");


                        sql = "select j.harga_jenis from kamar k, jenis_kamar j where k.id_kamar = '"+id_kamar+"' and k.kode_jenis = j.kode_jenis";
                        cmd = new OracleCommand(sql,conn);
                        int hrg = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                        //MessageBox.Show("3");


                        sql = "select j.nama_jenis from kamar k, jenis_kamar j where k.id_kamar = '" + id_kamar + "' and k.kode_jenis = j.kode_jenis";
                        cmd = new OracleCommand(sql,conn);
                        string jenis = cmd.ExecuteScalar().ToString();
                        
                        sql = "select total_harga from h_transaksi where id_transaksi = '"+idtrans+"'";
                        cmd = new OracleCommand(sql, conn);
                        int totalhrg = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                        string muncul = "------------------" + id_kamar+ "------------------" + "\n";
                        muncul +=" Jenis Kamar  :  "+jenis+"(Rp."+hrg.ToString()+")\n";
                        muncul += "\n" + "Fasilitas tambahan : ";
                        foreach (DataRow row in dt.Rows)
                        {
                            sql = "select nama_fasilitas from fasilitas where id_fasilitas = '" + row[0] + "'";
                            cmd = new OracleCommand(sql, conn);
                            jenis = cmd.ExecuteScalar().ToString();
                            

                            sql = "select harga_fasilitas from fasilitas where id_fasilitas = '" + row[0] + "'";
                            cmd = new OracleCommand(sql, conn);
                            hrg = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                            

                            sql = "select count(*) from d_transaksi where id_fasilitas = '"+row[0]+"' and id_transaksi = '"+idtrans+"'";
                            cmd = new OracleCommand(sql, conn);
                            int jum = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                            

                            muncul += "\n -> " + jenis + " x " + jum + " : Rp." + hrg;

                        }
                        muncul += "\n" + "Total   :   Rp."+totalhrg;
                        muncul += "\n" + "------------------Thank You------------------";
                        MessageBox.Show(muncul);
                    }
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
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("0"))
            {
                MessageBox.Show("Tidak ada kamar tersedia!");
            }
            else if (!textBox1.Text.Equals(""))
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                try
                {
                    conn.Open();
                    String sql = "Select id_kamar from kamar where kode_jenis = '"+comboBox1.SelectedValue.ToString()+"' and tersedia = 'Y'";
                    OracleCommand cmd = new OracleCommand(sql,conn);
                    OracleDataAdapter datmp = new OracleDataAdapter(cmd);
                    DataTable dttemp = new DataTable();
                    datmp.Fill(dttemp);
                    Boolean cek = true;
                    string kodefix = "";
                    string msk = dateTimePicker1.Value.Day + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Year;
                    string keluar = dateTimePicker2.Value.Day + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Year;
                    DateTime dmsk = Convert.ToDateTime(msk);
                    DateTime dkeluar = Convert.ToDateTime(keluar);
                    foreach (DataRow row2 in dttemp.Rows)
                    {
                        string code = row2[0].ToString();

                        sql = "SELECT to_char(tgl_msk,'dd-mm-yyyy'),to_char(tgl_keluar,'dd-mm-yyyy') FROM booking WHERE id_kamar = '" + code + "'";
                        cmd = new OracleCommand(sql, conn);
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cek = true;
                        foreach (DataRow row in dt.Rows)
                        {
                            string ci = row[0].ToString();
                            string co = row[1].ToString();
                            DateTime a = Convert.ToDateTime(ci);
                            DateTime b = Convert.ToDateTime(co);
                            if (dmsk >= a && dmsk <= b)
                            {
                                cek = false;
                            }
                            else if (dkeluar >= a && dkeluar <= b)
                            {
                                cek = false;
                            }
                            else if (a >= dmsk && a <= dkeluar)
                            {
                                cek = false;
                            }
                            else if (b >= dmsk && b <= dkeluar)
                            {
                                cek = false;
                            }
                        }
                        if (cek)
                        {
                            kodefix = code;
                            break;
                        }
                    }

                    //string code = cmd.ExecuteScalar().ToString();
                    //MessageBox.Show("kode : "+code);


                    if (!cek)
                    {
                        MessageBox.Show("Kamar penuh");
                    }
                    else
                    {
                        //MessageBox.Show(comboBox2.SelectedValue.ToString());
                        sql = "insert into booking values('','"+comboBox2.SelectedValue.ToString()+"','"+kodefix+"',to_date('"+msk+"','dd-mm-yyyy'),to_date('"+keluar+"','dd-mm-yyyy'))";
                        cmd = new OracleCommand(sql,conn);
                        MessageBox.Show("Kamar berhasil dibooking, nomor kamar : " + kodefix);
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message);
                }
            }

        }
        
        public void filter(int index,string id_jenis)
        {
            string pilihan = "";
            if(index == 0)
            {
                pilihan = "tgl_checkin";
            }
            else if(index == 1)
            {
                pilihan = "tgl_checkout";
            }

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                conn.Open();
                string tgl1 = dateTimePicker3.Value.Day + "-" + dateTimePicker3.Value.Month + "-" + dateTimePicker3.Value.Year;
                string tgl2 = dateTimePicker4.Value.Day + "-" + dateTimePicker4.Value.Month + "-" + dateTimePicker4.Value.Year; ;
                OracleCommand cmd = new OracleCommand("Select * from kamar k,where kode_jenis = '" + id_jenis + "' and "+pilihan+" > to_date('"+tgl1+ "','dd-mm-yyyy') and " + pilihan + " < to_date('" + tgl2 + "','dd-mm-yyyy') ", conn);
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

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                filter(comboBox3.SelectedIndex, comboBox1.SelectedValue.ToString());
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                filter(comboBox3.SelectedIndex, comboBox1.SelectedValue.ToString());
            }
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                filter(comboBox3.SelectedIndex, comboBox1.SelectedValue.ToString());
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            loadDataKamar(comboBox1.SelectedValue.ToString(), textBox1.Text);
        }
    }
}
