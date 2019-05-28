namespace ProyekPCS2019.Client
{
    partial class ClientMembership
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonBuat = new System.Windows.Forms.Button();
            this.buttonCek = new System.Windows.Forms.Button();
            this.groupBoxCek = new System.Windows.Forms.GroupBox();
            this.labelStatusMember = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID_KAMAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_BOOKING = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_MEMBERSHIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TGL_MSK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TGL_KELUAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelNoMember = new System.Windows.Forms.Label();
            this.labelEmailMember = new System.Windows.Forms.Label();
            this.labelAlamatMember = new System.Windows.Forms.Label();
            this.labelnamamember = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBoxidMember = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxBuat = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.buttonbuatMember = new System.Windows.Forms.Button();
            this.textBoxNamaMember = new System.Windows.Forms.TextBox();
            this.textBoxAlamatMember = new System.Windows.Forms.TextBox();
            this.textBoxEmailMember = new System.Windows.Forms.TextBox();
            this.textBoxNomorMember = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBoxCek.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxBuat.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MintCream;
            this.groupBox1.Controls.Add(this.buttonBuat);
            this.groupBox1.Controls.Add(this.buttonCek);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 87);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Membership";
            // 
            // buttonBuat
            // 
            this.buttonBuat.Location = new System.Drawing.Point(16, 31);
            this.buttonBuat.Name = "buttonBuat";
            this.buttonBuat.Size = new System.Drawing.Size(137, 41);
            this.buttonBuat.TabIndex = 0;
            this.buttonBuat.Text = "Buat Membership";
            this.buttonBuat.UseVisualStyleBackColor = true;
            this.buttonBuat.Visible = false;
            this.buttonBuat.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCek
            // 
            this.buttonCek.Location = new System.Drawing.Point(195, 31);
            this.buttonCek.Name = "buttonCek";
            this.buttonCek.Size = new System.Drawing.Size(137, 41);
            this.buttonCek.TabIndex = 1;
            this.buttonCek.Text = "Cek Membership";
            this.buttonCek.UseVisualStyleBackColor = true;
            this.buttonCek.Click += new System.EventHandler(this.buttonCek_Click);
            // 
            // groupBoxCek
            // 
            this.groupBoxCek.BackColor = System.Drawing.Color.SeaShell;
            this.groupBoxCek.Controls.Add(this.labelStatusMember);
            this.groupBoxCek.Controls.Add(this.label7);
            this.groupBoxCek.Controls.Add(this.listBox1);
            this.groupBoxCek.Controls.Add(this.label12);
            this.groupBoxCek.Controls.Add(this.label11);
            this.groupBoxCek.Controls.Add(this.dataGridView1);
            this.groupBoxCek.Controls.Add(this.labelNoMember);
            this.groupBoxCek.Controls.Add(this.labelEmailMember);
            this.groupBoxCek.Controls.Add(this.labelAlamatMember);
            this.groupBoxCek.Controls.Add(this.labelnamamember);
            this.groupBoxCek.Controls.Add(this.label6);
            this.groupBoxCek.Controls.Add(this.label5);
            this.groupBoxCek.Controls.Add(this.label4);
            this.groupBoxCek.Controls.Add(this.label2);
            this.groupBoxCek.Controls.Add(this.pictureBox1);
            this.groupBoxCek.Controls.Add(this.button4);
            this.groupBoxCek.Controls.Add(this.textBoxidMember);
            this.groupBoxCek.Controls.Add(this.label1);
            this.groupBoxCek.Location = new System.Drawing.Point(12, 114);
            this.groupBoxCek.Name = "groupBoxCek";
            this.groupBoxCek.Size = new System.Drawing.Size(1064, 620);
            this.groupBoxCek.TabIndex = 3;
            this.groupBoxCek.TabStop = false;
            this.groupBoxCek.Text = "Cek Membership";
            // 
            // labelStatusMember
            // 
            this.labelStatusMember.AutoSize = true;
            this.labelStatusMember.Location = new System.Drawing.Point(105, 302);
            this.labelStatusMember.Name = "labelStatusMember";
            this.labelStatusMember.Size = new System.Drawing.Size(13, 17);
            this.labelStatusMember.TabIndex = 20;
            this.labelStatusMember.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 302);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Status:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(642, 71);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(412, 260);
            this.listBox1.TabIndex = 18;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 368);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 17);
            this.label12.TabIndex = 17;
            this.label12.Text = "Rincian kunjungan";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(639, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(158, 17);
            this.label11.TabIndex = 15;
            this.label11.Text = "Daftar kunjungan Anda:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_KAMAR,
            this.ID_BOOKING,
            this.ID_MEMBERSHIP,
            this.TGL_MSK,
            this.TGL_KELUAR});
            this.dataGridView1.Location = new System.Drawing.Point(6, 400);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1048, 214);
            this.dataGridView1.TabIndex = 14;
            // 
            // ID_KAMAR
            // 
            this.ID_KAMAR.DataPropertyName = "ID_KAMAR";
            this.ID_KAMAR.HeaderText = "Nomor Kamar";
            this.ID_KAMAR.Name = "ID_KAMAR";
            this.ID_KAMAR.ReadOnly = true;
            this.ID_KAMAR.Width = 150;
            // 
            // ID_BOOKING
            // 
            this.ID_BOOKING.DataPropertyName = "KODE_BOOKING";
            this.ID_BOOKING.HeaderText = "ID BOOKING";
            this.ID_BOOKING.Name = "ID_BOOKING";
            this.ID_BOOKING.ReadOnly = true;
            this.ID_BOOKING.Visible = false;
            // 
            // ID_MEMBERSHIP
            // 
            this.ID_MEMBERSHIP.DataPropertyName = "ID_MEMBERSHIP";
            this.ID_MEMBERSHIP.HeaderText = "ID MEMBER";
            this.ID_MEMBERSHIP.Name = "ID_MEMBERSHIP";
            this.ID_MEMBERSHIP.ReadOnly = true;
            this.ID_MEMBERSHIP.Visible = false;
            // 
            // TGL_MSK
            // 
            this.TGL_MSK.DataPropertyName = "TGL_MSK";
            this.TGL_MSK.HeaderText = "Tanggal Masuk";
            this.TGL_MSK.Name = "TGL_MSK";
            this.TGL_MSK.ReadOnly = true;
            this.TGL_MSK.Width = 150;
            // 
            // TGL_KELUAR
            // 
            this.TGL_KELUAR.DataPropertyName = "TGL_KELUAR";
            this.TGL_KELUAR.HeaderText = "Tanggal Keluar";
            this.TGL_KELUAR.Name = "TGL_KELUAR";
            this.TGL_KELUAR.ReadOnly = true;
            this.TGL_KELUAR.Width = 150;
            // 
            // labelNoMember
            // 
            this.labelNoMember.AutoSize = true;
            this.labelNoMember.Location = new System.Drawing.Point(105, 271);
            this.labelNoMember.Name = "labelNoMember";
            this.labelNoMember.Size = new System.Drawing.Size(13, 17);
            this.labelNoMember.TabIndex = 13;
            this.labelNoMember.Text = "-";
            // 
            // labelEmailMember
            // 
            this.labelEmailMember.AutoSize = true;
            this.labelEmailMember.Location = new System.Drawing.Point(105, 230);
            this.labelEmailMember.Name = "labelEmailMember";
            this.labelEmailMember.Size = new System.Drawing.Size(13, 17);
            this.labelEmailMember.TabIndex = 12;
            this.labelEmailMember.Text = "-";
            // 
            // labelAlamatMember
            // 
            this.labelAlamatMember.AutoSize = true;
            this.labelAlamatMember.Location = new System.Drawing.Point(105, 189);
            this.labelAlamatMember.Name = "labelAlamatMember";
            this.labelAlamatMember.Size = new System.Drawing.Size(13, 17);
            this.labelAlamatMember.TabIndex = 11;
            this.labelAlamatMember.Text = "-";
            // 
            // labelnamamember
            // 
            this.labelnamamember.AutoSize = true;
            this.labelnamamember.Location = new System.Drawing.Point(105, 148);
            this.labelnamamember.Name = "labelnamamember";
            this.labelnamamember.Size = new System.Drawing.Size(13, 17);
            this.labelnamamember.TabIndex = 10;
            this.labelnamamember.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "No. Telepon:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "E-mail:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Alamat:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nama:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new System.Drawing.Point(12, 123);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(543, 2);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(546, 41);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 66);
            this.button4.TabIndex = 2;
            this.button4.Text = "Cek";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBoxidMember
            // 
            this.textBoxidMember.Location = new System.Drawing.Point(260, 61);
            this.textBoxidMember.Name = "textBoxidMember";
            this.textBoxidMember.Size = new System.Drawing.Size(280, 22);
            this.textBoxidMember.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Masukkan ID Membership:";
            // 
            // groupBoxBuat
            // 
            this.groupBoxBuat.BackColor = System.Drawing.Color.MintCream;
            this.groupBoxBuat.Controls.Add(this.label18);
            this.groupBoxBuat.Controls.Add(this.textBoxPassword);
            this.groupBoxBuat.Controls.Add(this.label17);
            this.groupBoxBuat.Controls.Add(this.buttonbuatMember);
            this.groupBoxBuat.Controls.Add(this.textBoxNamaMember);
            this.groupBoxBuat.Controls.Add(this.textBoxAlamatMember);
            this.groupBoxBuat.Controls.Add(this.textBoxEmailMember);
            this.groupBoxBuat.Controls.Add(this.textBoxNomorMember);
            this.groupBoxBuat.Controls.Add(this.label13);
            this.groupBoxBuat.Controls.Add(this.label14);
            this.groupBoxBuat.Controls.Add(this.label15);
            this.groupBoxBuat.Controls.Add(this.label16);
            this.groupBoxBuat.Location = new System.Drawing.Point(12, 114);
            this.groupBoxBuat.Name = "groupBoxBuat";
            this.groupBoxBuat.Size = new System.Drawing.Size(1065, 620);
            this.groupBoxBuat.TabIndex = 4;
            this.groupBoxBuat.TabStop = false;
            this.groupBoxBuat.Text = "Buat Membership";
            this.groupBoxBuat.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(14, 405);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(661, 51);
            this.label18.TabIndex = 21;
            this.label18.Text = "Keterangan:\r\n1. Password digunakan untuk melakukan login untuk melakukan pemesana" +
    "n atau pengecekan booking.\r\n2. No. telepon harus memiliki 10-12 digit angka.";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(110, 269);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(391, 22);
            this.textBoxPassword.TabIndex = 20;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(14, 268);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 17);
            this.label17.TabIndex = 19;
            this.label17.Text = "Password:";
            // 
            // buttonbuatMember
            // 
            this.buttonbuatMember.Location = new System.Drawing.Point(17, 322);
            this.buttonbuatMember.Name = "buttonbuatMember";
            this.buttonbuatMember.Size = new System.Drawing.Size(484, 43);
            this.buttonbuatMember.TabIndex = 18;
            this.buttonbuatMember.Text = "Buat Membership";
            this.buttonbuatMember.UseVisualStyleBackColor = true;
            this.buttonbuatMember.Click += new System.EventHandler(this.buttonbuatMember_Click);
            // 
            // textBoxNamaMember
            // 
            this.textBoxNamaMember.Location = new System.Drawing.Point(110, 41);
            this.textBoxNamaMember.Name = "textBoxNamaMember";
            this.textBoxNamaMember.Size = new System.Drawing.Size(391, 22);
            this.textBoxNamaMember.TabIndex = 17;
            // 
            // textBoxAlamatMember
            // 
            this.textBoxAlamatMember.Location = new System.Drawing.Point(110, 98);
            this.textBoxAlamatMember.Name = "textBoxAlamatMember";
            this.textBoxAlamatMember.Size = new System.Drawing.Size(391, 22);
            this.textBoxAlamatMember.TabIndex = 16;
            // 
            // textBoxEmailMember
            // 
            this.textBoxEmailMember.Location = new System.Drawing.Point(109, 155);
            this.textBoxEmailMember.Name = "textBoxEmailMember";
            this.textBoxEmailMember.Size = new System.Drawing.Size(391, 22);
            this.textBoxEmailMember.TabIndex = 15;
            // 
            // textBoxNomorMember
            // 
            this.textBoxNomorMember.Location = new System.Drawing.Point(109, 212);
            this.textBoxNomorMember.Name = "textBoxNomorMember";
            this.textBoxNomorMember.Size = new System.Drawing.Size(391, 22);
            this.textBoxNomorMember.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 212);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 17);
            this.label13.TabIndex = 13;
            this.label13.Text = "No. Telepon:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 17);
            this.label14.TabIndex = 12;
            this.label14.Text = "E-mail:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 100);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 17);
            this.label15.TabIndex = 11;
            this.label15.Text = "Alamat:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 44);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 17);
            this.label16.TabIndex = 10;
            this.label16.Text = "Nama:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(872, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(195, 41);
            this.button3.TabIndex = 2;
            this.button3.Text = "Kembali ke Menu Utama";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ClientMembership
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(1089, 746);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxBuat);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBoxCek);
            this.Name = "ClientMembership";
            this.Text = "Membership";
            this.Load += new System.EventHandler(this.ClientMembership_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBoxCek.ResumeLayout(false);
            this.groupBoxCek.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxBuat.ResumeLayout(false);
            this.groupBoxBuat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCek;
        private System.Windows.Forms.Button buttonBuat;
        private System.Windows.Forms.GroupBox groupBoxCek;
        private System.Windows.Forms.GroupBox groupBoxBuat;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBoxidMember;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label labelNoMember;
        private System.Windows.Forms.Label labelEmailMember;
        private System.Windows.Forms.Label labelAlamatMember;
        private System.Windows.Forms.Label labelnamamember;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxNamaMember;
        private System.Windows.Forms.TextBox textBoxAlamatMember;
        private System.Windows.Forms.TextBox textBoxEmailMember;
        private System.Windows.Forms.TextBox textBoxNomorMember;
        private System.Windows.Forms.Button buttonbuatMember;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_KAMAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_BOOKING;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_MEMBERSHIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TGL_MSK;
        private System.Windows.Forms.DataGridViewTextBoxColumn TGL_KELUAR;
        private System.Windows.Forms.Label labelStatusMember;
        private System.Windows.Forms.Label label7;
    }
}