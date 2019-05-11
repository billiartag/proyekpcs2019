namespace ProyekPCS2019.Client
{
    partial class ClientPesanKamar
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxJenisKamar = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelStatusKamar = new System.Windows.Forms.Label();
            this.labelHargaKamar = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.labelHargaKamar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.labelStatusKamar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxJenisKamar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(797, 516);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jenis Kamar:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(608, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Kembali ke Menu Utama";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxJenisKamar
            // 
            this.comboBoxJenisKamar.FormattingEnabled = true;
            this.comboBoxJenisKamar.Location = new System.Drawing.Point(141, 54);
            this.comboBoxJenisKamar.Name = "comboBoxJenisKamar";
            this.comboBoxJenisKamar.Size = new System.Drawing.Size(121, 24);
            this.comboBoxJenisKamar.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Status:";
            // 
            // labelStatusKamar
            // 
            this.labelStatusKamar.AutoSize = true;
            this.labelStatusKamar.Location = new System.Drawing.Point(138, 108);
            this.labelStatusKamar.Name = "labelStatusKamar";
            this.labelStatusKamar.Size = new System.Drawing.Size(13, 17);
            this.labelStatusKamar.TabIndex = 3;
            this.labelStatusKamar.Text = "-";
            this.labelStatusKamar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHargaKamar
            // 
            this.labelHargaKamar.AutoSize = true;
            this.labelHargaKamar.Location = new System.Drawing.Point(138, 151);
            this.labelHargaKamar.Name = "labelHargaKamar";
            this.labelHargaKamar.Size = new System.Drawing.Size(13, 17);
            this.labelHargaKamar.TabIndex = 5;
            this.labelHargaKamar.Text = "-";
            this.labelHargaKamar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Harga:";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(48, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(214, 40);
            this.button2.TabIndex = 6;
            this.button2.Text = "Pesan Kamar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ClientPesanKamar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 579);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ClientPesanKamar";
            this.Text = "ClientPesanKamar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelHargaKamar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelStatusKamar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxJenisKamar;
        private System.Windows.Forms.Button button2;
    }
}