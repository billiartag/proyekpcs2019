namespace ProyekPCS2019.Manager
{
    partial class ManagerFasilitas
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBoxIDFasilitas = new System.Windows.Forms.TextBox();
            this.richTextBoxDeskripsi = new System.Windows.Forms.RichTextBox();
            this.textBoxNamaFasilitas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.numericUpDownHargaFasilitas = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHargaFasilitas)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(621, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Kembali ke Main Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(390, 44);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ubah Detail Fasilitas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "ID Fasilitas:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(621, 86);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(175, 420);
            this.listBox1.TabIndex = 11;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // textBoxIDFasilitas
            // 
            this.textBoxIDFasilitas.Enabled = false;
            this.textBoxIDFasilitas.Location = new System.Drawing.Point(94, 86);
            this.textBoxIDFasilitas.Name = "textBoxIDFasilitas";
            this.textBoxIDFasilitas.Size = new System.Drawing.Size(195, 22);
            this.textBoxIDFasilitas.TabIndex = 12;
            // 
            // richTextBoxDeskripsi
            // 
            this.richTextBoxDeskripsi.Location = new System.Drawing.Point(94, 213);
            this.richTextBoxDeskripsi.Name = "richTextBoxDeskripsi";
            this.richTextBoxDeskripsi.Size = new System.Drawing.Size(502, 236);
            this.richTextBoxDeskripsi.TabIndex = 13;
            this.richTextBoxDeskripsi.Text = "";
            // 
            // textBoxNamaFasilitas
            // 
            this.textBoxNamaFasilitas.Enabled = false;
            this.textBoxNamaFasilitas.Location = new System.Drawing.Point(94, 128);
            this.textBoxNamaFasilitas.Name = "textBoxNamaFasilitas";
            this.textBoxNamaFasilitas.Size = new System.Drawing.Size(195, 22);
            this.textBoxNamaFasilitas.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nama:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Harga:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(503, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 100);
            this.button2.TabIndex = 17;
            this.button2.Text = "Ubah Gambar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(503, 455);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 58);
            this.button3.TabIndex = 18;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Deskripsi";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(314, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 105);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // numericUpDownHargaFasilitas
            // 
            this.numericUpDownHargaFasilitas.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownHargaFasilitas.Location = new System.Drawing.Point(94, 169);
            this.numericUpDownHargaFasilitas.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownHargaFasilitas.Name = "numericUpDownHargaFasilitas";
            this.numericUpDownHargaFasilitas.Size = new System.Drawing.Size(195, 22);
            this.numericUpDownHargaFasilitas.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 472);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(311, 34);
            this.label6.TabIndex = 23;
            this.label6.Text = "Untuk mengganti gambar dapat langsung \r\ndilakukan dengan button ubah gambar";
            // 
            // ManagerFasilitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(808, 525);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDownHargaFasilitas);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNamaFasilitas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBoxDeskripsi);
            this.Controls.Add(this.textBoxIDFasilitas);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Name = "ManagerFasilitas";
            this.Text = "Ubah Fasilitas";
            this.Load += new System.EventHandler(this.ManagerFasilitas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHargaFasilitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBoxIDFasilitas;
        private System.Windows.Forms.RichTextBox richTextBoxDeskripsi;
        private System.Windows.Forms.TextBox textBoxNamaFasilitas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownHargaFasilitas;
        private System.Windows.Forms.Label label6;
    }
}