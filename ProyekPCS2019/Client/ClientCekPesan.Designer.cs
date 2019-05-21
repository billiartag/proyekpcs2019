namespace ProyekPCS2019.Client
{
    partial class ClientCekPesan
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonCekBooking = new System.Windows.Forms.Button();
            this.textBoxKodeBooking = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelTanggalKeluar = new System.Windows.Forms.Label();
            this.labelTanggalMasuk = new System.Windows.Forms.Label();
            this.labelNoKamar = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(462, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Kembali ke Menu Utama";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonCekBooking);
            this.groupBox1.Controls.Add(this.textBoxKodeBooking);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 97);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cek Booking";
            // 
            // buttonCekBooking
            // 
            this.buttonCekBooking.Location = new System.Drawing.Point(467, 17);
            this.buttonCekBooking.Name = "buttonCekBooking";
            this.buttonCekBooking.Size = new System.Drawing.Size(121, 70);
            this.buttonCekBooking.TabIndex = 2;
            this.buttonCekBooking.Text = "Cek";
            this.buttonCekBooking.UseVisualStyleBackColor = true;
            this.buttonCekBooking.Click += new System.EventHandler(this.buttonCekBooking_Click);
            // 
            // textBoxKodeBooking
            // 
            this.textBoxKodeBooking.Location = new System.Drawing.Point(159, 41);
            this.textBoxKodeBooking.Name = "textBoxKodeBooking";
            this.textBoxKodeBooking.Size = new System.Drawing.Size(288, 22);
            this.textBoxKodeBooking.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kode booking:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelTanggalKeluar);
            this.groupBox2.Controls.Add(this.labelTanggalMasuk);
            this.groupBox2.Controls.Add(this.labelNoKamar);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(651, 179);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detail Booking";
            // 
            // labelTanggalKeluar
            // 
            this.labelTanggalKeluar.AutoSize = true;
            this.labelTanggalKeluar.Location = new System.Drawing.Point(198, 125);
            this.labelTanggalKeluar.Name = "labelTanggalKeluar";
            this.labelTanggalKeluar.Size = new System.Drawing.Size(13, 17);
            this.labelTanggalKeluar.TabIndex = 5;
            this.labelTanggalKeluar.Text = "-";
            // 
            // labelTanggalMasuk
            // 
            this.labelTanggalMasuk.AutoSize = true;
            this.labelTanggalMasuk.Location = new System.Drawing.Point(198, 82);
            this.labelTanggalMasuk.Name = "labelTanggalMasuk";
            this.labelTanggalMasuk.Size = new System.Drawing.Size(13, 17);
            this.labelTanggalMasuk.TabIndex = 4;
            this.labelTanggalMasuk.Text = "-";
            // 
            // labelNoKamar
            // 
            this.labelNoKamar.AutoSize = true;
            this.labelNoKamar.Location = new System.Drawing.Point(198, 39);
            this.labelNoKamar.Name = "labelNoKamar";
            this.labelNoKamar.Size = new System.Drawing.Size(13, 17);
            this.labelNoKamar.TabIndex = 3;
            this.labelNoKamar.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tanggal keluar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tanggal masuk:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nomor kamar:";
            // 
            // ClientCekPesan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 396);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "ClientCekPesan";
            this.Text = "Cek Booking";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCekBooking;
        private System.Windows.Forms.TextBox textBoxKodeBooking;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTanggalKeluar;
        private System.Windows.Forms.Label labelTanggalMasuk;
        private System.Windows.Forms.Label labelNoKamar;
    }
}