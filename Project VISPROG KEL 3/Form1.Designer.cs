namespace Project_VISPROG_KEL_3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            panel2 = new Panel();
            label2 = new Label();
            panel3 = new Panel();
            panel1 = new Panel();
            menuStrip2 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            peminjamanBukuToolStripMenuItem = new ToolStripMenuItem();
            kelolaBukuToolStripMenuItem = new ToolStripMenuItem();
            kelolaAnggotaToolStripMenuItem = new ToolStripMenuItem();
            panel4 = new Panel();
            homeText = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            menuStrip2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.System;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(288, 17);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(462, 48);
            label1.TabIndex = 0;
            label1.Text = "APLIKASI PERPUSTAKAAN";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(4, 4);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(71, 67);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.System;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(118, 17);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(103, 45);
            label3.TabIndex = 2;
            label3.Text = "LibRa";
            label3.Click += label3_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Highlight;
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 518);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1032, 50);
            panel2.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.System;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(453, 13);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(125, 28);
            label2.TabIndex = 4;
            label2.Text = "Kelompok 3";
            // 
            // panel3
            // 
            panel3.BackColor = Color.CornflowerBlue;
            panel3.Controls.Add(panel1);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(pictureBox1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1032, 116);
            panel3.TabIndex = 3;
            panel3.Paint += panel3_Paint;
            // 
            // panel1
            // 
            panel1.Controls.Add(menuStrip2);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 78);
            panel1.Name = "panel1";
            panel1.Size = new Size(1032, 38);
            panel1.TabIndex = 4;
            // 
            // menuStrip2
            // 
            menuStrip2.Dock = DockStyle.Fill;
            menuStrip2.ImageScalingSize = new Size(24, 24);
            menuStrip2.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(1032, 38);
            menuStrip2.TabIndex = 0;
            menuStrip2.Text = "menuStrip2";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { peminjamanBukuToolStripMenuItem, kelolaBukuToolStripMenuItem, kelolaAnggotaToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(73, 34);
            menuToolStripMenuItem.Text = "Menu";
            menuToolStripMenuItem.Click += menuToolStripMenuItem1_Click;
            // 
            // peminjamanBukuToolStripMenuItem
            // 
            peminjamanBukuToolStripMenuItem.Name = "peminjamanBukuToolStripMenuItem";
            peminjamanBukuToolStripMenuItem.Size = new Size(254, 34);
            peminjamanBukuToolStripMenuItem.Text = "Peminjaman Buku";
            peminjamanBukuToolStripMenuItem.Click += peminjamanBukuToolStripMenuItem_Click;
            // 
            // kelolaBukuToolStripMenuItem
            // 
            kelolaBukuToolStripMenuItem.Name = "kelolaBukuToolStripMenuItem";
            kelolaBukuToolStripMenuItem.Size = new Size(254, 34);
            kelolaBukuToolStripMenuItem.Text = "Kelola Buku";
            kelolaBukuToolStripMenuItem.Click += kelolaBukuToolStripMenuItem_Click;
            // 
            // kelolaAnggotaToolStripMenuItem
            // 
            kelolaAnggotaToolStripMenuItem.Name = "kelolaAnggotaToolStripMenuItem";
            kelolaAnggotaToolStripMenuItem.Size = new Size(254, 34);
            kelolaAnggotaToolStripMenuItem.Text = "Kelola Anggota";
            kelolaAnggotaToolStripMenuItem.Click += kelolaAnggotaToolStripMenuItem_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(homeText);
            panel4.Controls.Add(panel2);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 116);
            panel4.Name = "panel4";
            panel4.Size = new Size(1032, 568);
            panel4.TabIndex = 4;
            panel4.Paint += panel4_Paint;
            // 
            // homeText
            // 
            homeText.AutoSize = true;
            homeText.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            homeText.Location = new Point(348, 148);
            homeText.Name = "homeText";
            homeText.Size = new Size(362, 65);
            homeText.TabIndex = 3;
            homeText.Text = "Selamat Datang";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 684);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Aplikasi Perpustakaan";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Label label3;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Label label2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel1;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem peminjamanBukuToolStripMenuItem;
        private ToolStripMenuItem kelolaBukuToolStripMenuItem;
        private ToolStripMenuItem kelolaAnggotaToolStripMenuItem;
        private Label homeText;
    }
}
