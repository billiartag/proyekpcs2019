using ProyekPCS2019.Admin;
using ProyekPCS2019.Report.FasilitasPalingBanyakPerBulan;
using ProyekPCS2019.Report.BulanTerbaikPenjualan;
using ProyekPCS2019.Report.JenisKamarPerBulan;
using ProyekPCS2019.Report.Jumlah_Customer_Per_Bulan;
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
    public partial class MainAdmin : Form
    {
        EditPegawaiCRUD ep = new EditPegawaiCRUD();//pegawai
        EditMembership em = new EditMembership();//membership
        AdminEditBookingCRUD eb = new AdminEditBookingCRUD();//booking
        AdminEditKamarCRUD ek = new AdminEditKamarCRUD();//kamar
        AdminJabatanCRUD ej = new AdminJabatanCRUD();//jabatan
        AdminEditFasilitasCRUD ef = new AdminEditFasilitasCRUD();//fasilitas
        FormReportCustomer rc = new FormReportCustomer();//report customer per bulan
        FormReportJenisKamar rj = new FormReportJenisKamar();//report jenis kamar perbulan
        FormFasilitas rf = new FormFasilitas();//report fasilitas per bulan
        FormBulanTerbaik rb = new FormBulanTerbaik();//report bulan penjualan terbaik
        public MainAdmin()
        {
            InitializeComponent();
        }

        private void pEGAWAIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            em.Hide();
            eb.Hide();
            ek.Hide();
            ef.Hide();
            rc.Hide();
            rj.Hide();
            rf.Hide();
            rb.Hide();
            ej.Hide();
            ep.MdiParent = this;
            ep.Show();
            ep.Location = new Point(0,0);
        }

        private void MainMaster_Load(object sender, EventArgs e)
        {

        }

        private void fASILITASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ep.Hide();
            eb.Hide();
            ek.Hide();
            ef.Hide();
            rc.Hide();
            rj.Hide();
            rf.Hide();
            ej.Hide();
            rb.Hide();
            em.MdiParent = this;
            em.Show();
            em.Location = new Point(0, 0);

        }

        private void kAMARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ep.Hide();
            em.Hide();
            ek.Hide();
            ej.Hide();
            ef.Hide();
            rc.Hide();
            rj.Hide();
            rf.Hide();
            rb.Hide();
            eb.MdiParent = this;
            eb.Show();
            eb.Location = new Point(0, 0);
        }

        private void kAMARToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ep.Hide();
            em.Hide();
            eb.Hide();
            ej.Hide();
            ef.Hide();
            rc.Hide();
            rj.Hide();
            rf.Hide();
            rb.Hide();
            ek.MdiParent = this;
            ek.Show();
            ek.Location = new Point(0, 0);
        }

        private void fASILITASToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ep.Hide();
            em.Hide();
            eb.Hide();
            ek.Hide();
            rc.Hide();
            ej.Hide();
            rj.Hide();
            rf.Hide();
            rb.Hide();
            ef.MdiParent = this;
            ef.Show();
            ef.Location = new Point(0, 0);
        }

        private void cUSTOMERPERBULANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ep.Hide();
            em.Hide();
            eb.Hide();
            ek.Hide();
            ej.Hide();
            ef.Hide();
            rj.Hide();
            rf.Hide();
            rb.Hide();
            rc.MdiParent = this;
            rc.Show();
            rc.Location = new Point(0, 0);

        }

        private void dATAKAMARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ep.Hide();
            em.Hide();
            eb.Hide();
            ej.Hide();
            ek.Hide();
            ef.Hide();
            rc.Hide();
            rf.Hide();
            rb.Hide();
            rj.MdiParent = this;
            rj.Show();
            rj.Location = new Point(0, 0);
        }

        private void bULANTERBAIKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ep.Hide();
            em.Hide();
            eb.Hide();
            ek.Hide();
            ej.Hide();
            ef.Hide();
            rj.Hide();
            rc.Hide();
            rf.Hide();
            rb.MdiParent = this;
            rb.Show();
            rb.Location = new Point(0, 0);
        }

        private void dATAFASILITASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ep.Hide();
            em.Hide();
            eb.Hide();
            ej.Hide();
            ek.Hide();
            ef.Hide();
            rj.Hide();
            rc.Hide();
            rb.Hide();
            rf.MdiParent = this;
            rf.Show();
            rf.Location = new Point(0, 0);
        }

        private void eXITTOMENUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login x = new Login();
            this.Hide();
            x.ShowDialog();
            this.Close();
        }

        private void jABATANToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ep.Hide();
            em.Hide();
            eb.Hide();
            rf.Hide();
            ek.Hide();
            ef.Hide();
            rj.Hide();
            rc.Hide();
            rb.Hide();
            ej.MdiParent = this;
            ej.Show();
            ej.Location = new Point(0, 0);
        }
    }
}
