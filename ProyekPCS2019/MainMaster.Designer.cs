﻿namespace ProyekPCS2019
{
    partial class MainMaster
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pEGAWAIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fASILITASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kAMARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jENISKAMARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pEGAWAIToolStripMenuItem,
            this.fASILITASToolStripMenuItem,
            this.kAMARToolStripMenuItem,
            this.jENISKAMARToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(960, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pEGAWAIToolStripMenuItem
            // 
            this.pEGAWAIToolStripMenuItem.Name = "pEGAWAIToolStripMenuItem";
            this.pEGAWAIToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.pEGAWAIToolStripMenuItem.Text = "PEGAWAI";
            this.pEGAWAIToolStripMenuItem.Click += new System.EventHandler(this.pEGAWAIToolStripMenuItem_Click);
            // 
            // fASILITASToolStripMenuItem
            // 
            this.fASILITASToolStripMenuItem.Name = "fASILITASToolStripMenuItem";
            this.fASILITASToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.fASILITASToolStripMenuItem.Text = "FASILITAS";
            // 
            // kAMARToolStripMenuItem
            // 
            this.kAMARToolStripMenuItem.Name = "kAMARToolStripMenuItem";
            this.kAMARToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.kAMARToolStripMenuItem.Text = "KAMAR";
            // 
            // jENISKAMARToolStripMenuItem
            // 
            this.jENISKAMARToolStripMenuItem.Name = "jENISKAMARToolStripMenuItem";
            this.jENISKAMARToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.jENISKAMARToolStripMenuItem.Text = "JENIS KAMAR";
            // 
            // MainMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 535);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMaster";
            this.Text = "MainMaster";
            this.Load += new System.EventHandler(this.MainMaster_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pEGAWAIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fASILITASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kAMARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jENISKAMARToolStripMenuItem;
    }
}