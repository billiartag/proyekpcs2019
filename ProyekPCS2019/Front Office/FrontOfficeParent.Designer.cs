namespace ProyekPCS2019.Front_Office
{
    partial class FrontOfficeParent
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
            this.membershipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fasilitasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.membershipToolStripMenuItem,
            this.bookingToolStripMenuItem,
            this.fasilitasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // membershipToolStripMenuItem
            // 
            this.membershipToolStripMenuItem.Name = "membershipToolStripMenuItem";
            this.membershipToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.membershipToolStripMenuItem.Text = "Membership";
            this.membershipToolStripMenuItem.Click += new System.EventHandler(this.membershipToolStripMenuItem_Click);
            // 
            // bookingToolStripMenuItem
            // 
            this.bookingToolStripMenuItem.Name = "bookingToolStripMenuItem";
            this.bookingToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.bookingToolStripMenuItem.Text = "Booking";
            this.bookingToolStripMenuItem.Click += new System.EventHandler(this.bookingToolStripMenuItem_Click);
            // 
            // fasilitasToolStripMenuItem
            // 
            this.fasilitasToolStripMenuItem.Name = "fasilitasToolStripMenuItem";
            this.fasilitasToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.fasilitasToolStripMenuItem.Text = "Fasilitas";
            this.fasilitasToolStripMenuItem.Click += new System.EventHandler(this.fasilitasToolStripMenuItem_Click);
            // 
            // FrontOfficeParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrontOfficeParent";
            this.Text = "FrontOfficeParent";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem membershipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fasilitasToolStripMenuItem;
    }
}