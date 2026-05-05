namespace Project_VISPROG_KEL_3
{
    partial class FormAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdmin));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            panel2 = new Panel();
            label2 = new Label();
            panel3 = new Panel();
            panel1 = new Panel();
            menuStrip2 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            kelolaBukuToolStripMenuItem = new ToolStripMenuItem();
            masterDataToolStripMenuItem = new ToolStripMenuItem();
            kelolaBukuToolStripMenuItem1 = new ToolStripMenuItem();
            kelolaAnggotaToolStripMenuItem1 = new ToolStripMenuItem();
            kategoriBukuToolStripMenuItem = new ToolStripMenuItem();
            dataTransaksiToolStripMenuItem = new ToolStripMenuItem();
            peminjamanPengembalianToolStripMenuItem = new ToolStripMenuItem();
            riwayatDendaToolStripMenuItem = new ToolStripMenuItem();
            laporanToolStripMenuItem = new ToolStripMenuItem();
            laporanPeminjamanToolStripMenuItem = new ToolStripMenuItem();
            akunToolStripMenuItem = new ToolStripMenuItem();
            gantiPasswordToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
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
            label1.Location = new Point(230, 14);
            label1.Name = "label1";
            label1.Size = new Size(390, 41);
            label1.TabIndex = 0;
            label1.Text = "APLIKASI PERPUSTAKAAN";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(57, 54);
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
            label3.Location = new Point(94, 14);
            label3.Name = "label3";
            label3.Size = new Size(89, 37);
            label3.TabIndex = 2;
            label3.Text = "LibRa";
            label3.Click += label3_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Highlight;
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 414);
            panel2.Name = "panel2";
            panel2.Size = new Size(826, 40);
            panel2.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.System;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(362, 10);
            label2.Name = "label2";
            label2.Size = new Size(107, 23);
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
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(826, 93);
            panel3.TabIndex = 3;
            panel3.Paint += panel3_Paint;
            // 
            // panel1
            // 
            panel1.Controls.Add(menuStrip2);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 63);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(826, 30);
            panel1.TabIndex = 4;
            // 
            // menuStrip2
            // 
            menuStrip2.Dock = DockStyle.Fill;
            menuStrip2.ImageScalingSize = new Size(24, 24);
            menuStrip2.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem, masterDataToolStripMenuItem, dataTransaksiToolStripMenuItem, laporanToolStripMenuItem, akunToolStripMenuItem });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Padding = new Padding(5, 2, 0, 2);
            menuStrip2.Size = new Size(826, 30);
            menuStrip2.TabIndex = 0;
            menuStrip2.Text = "menuStrip2";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kelolaBukuToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(96, 26);
            menuToolStripMenuItem.Text = "Dashboard";
            menuToolStripMenuItem.Click += menuToolStripMenuItem1_Click;
            // 
            // kelolaBukuToolStripMenuItem
            // 
            kelolaBukuToolStripMenuItem.Name = "kelolaBukuToolStripMenuItem";
            kelolaBukuToolStripMenuItem.Size = new Size(83, 26);
            // 
            // masterDataToolStripMenuItem
            // 
            masterDataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kelolaBukuToolStripMenuItem1, kelolaAnggotaToolStripMenuItem1, kategoriBukuToolStripMenuItem });
            masterDataToolStripMenuItem.Name = "masterDataToolStripMenuItem";
            masterDataToolStripMenuItem.Size = new Size(104, 26);
            masterDataToolStripMenuItem.Text = "Master Data";
            // 
            // kelolaBukuToolStripMenuItem1
            // 
            kelolaBukuToolStripMenuItem1.Name = "kelolaBukuToolStripMenuItem1";
            kelolaBukuToolStripMenuItem1.Size = new Size(196, 26);
            kelolaBukuToolStripMenuItem1.Text = "Kelola Buku";
            kelolaBukuToolStripMenuItem1.Click += kelolaBukuToolStripMenuItem1_Click;
            // 
            // kelolaAnggotaToolStripMenuItem1
            // 
            kelolaAnggotaToolStripMenuItem1.Name = "kelolaAnggotaToolStripMenuItem1";
            kelolaAnggotaToolStripMenuItem1.Size = new Size(196, 26);
            kelolaAnggotaToolStripMenuItem1.Text = "Kelola Anggota";
            kelolaAnggotaToolStripMenuItem1.Click += kelolaAnggotaToolStripMenuItem1_Click;
            // 
            // kategoriBukuToolStripMenuItem
            // 
            kategoriBukuToolStripMenuItem.Name = "kategoriBukuToolStripMenuItem";
            kategoriBukuToolStripMenuItem.Size = new Size(196, 26);
            kategoriBukuToolStripMenuItem.Text = "Kategori Buku";
            // 
            // dataTransaksiToolStripMenuItem
            // 
            dataTransaksiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { peminjamanPengembalianToolStripMenuItem, riwayatDendaToolStripMenuItem });
            dataTransaksiToolStripMenuItem.Name = "dataTransaksiToolStripMenuItem";
            dataTransaksiToolStripMenuItem.Size = new Size(118, 26);
            dataTransaksiToolStripMenuItem.Text = "Data Transaksi";
            // 
            // peminjamanPengembalianToolStripMenuItem
            // 
            peminjamanPengembalianToolStripMenuItem.Name = "peminjamanPengembalianToolStripMenuItem";
            peminjamanPengembalianToolStripMenuItem.Size = new Size(275, 26);
            peminjamanPengembalianToolStripMenuItem.Text = "Peminjaman & Pengembalian";
            // 
            // riwayatDendaToolStripMenuItem
            // 
            riwayatDendaToolStripMenuItem.Name = "riwayatDendaToolStripMenuItem";
            riwayatDendaToolStripMenuItem.Size = new Size(275, 26);
            riwayatDendaToolStripMenuItem.Text = "Riwayat Denda";
            // 
            // laporanToolStripMenuItem
            // 
            laporanToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { laporanPeminjamanToolStripMenuItem });
            laporanToolStripMenuItem.Name = "laporanToolStripMenuItem";
            laporanToolStripMenuItem.Size = new Size(77, 26);
            laporanToolStripMenuItem.Text = "Laporan";
            // 
            // laporanPeminjamanToolStripMenuItem
            // 
            laporanPeminjamanToolStripMenuItem.Name = "laporanPeminjamanToolStripMenuItem";
            laporanPeminjamanToolStripMenuItem.Size = new Size(231, 26);
            laporanPeminjamanToolStripMenuItem.Text = "Laporan Peminjaman";
            // 
            // akunToolStripMenuItem
            // 
            akunToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gantiPasswordToolStripMenuItem, logOutToolStripMenuItem });
            akunToolStripMenuItem.Name = "akunToolStripMenuItem";
            akunToolStripMenuItem.Size = new Size(56, 26);
            akunToolStripMenuItem.Text = "Akun";
            // 
            // gantiPasswordToolStripMenuItem
            // 
            gantiPasswordToolStripMenuItem.Name = "gantiPasswordToolStripMenuItem";
            gantiPasswordToolStripMenuItem.Size = new Size(224, 26);
            gantiPasswordToolStripMenuItem.Text = "Ganti Password";
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(224, 26);
            logOutToolStripMenuItem.Text = "Log Out";
            logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(homeText);
            panel4.Controls.Add(panel2);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 93);
            panel4.Margin = new Padding(2);
            panel4.Name = "panel4";
            panel4.Size = new Size(826, 454);
            panel4.TabIndex = 4;
            panel4.Paint += panel4_Paint;
            // 
            // homeText
            // 
            homeText.AutoSize = true;
            homeText.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            homeText.Location = new Point(243, 20);
            homeText.Margin = new Padding(2, 0, 2, 0);
            homeText.Name = "homeText";
            homeText.Size = new Size(303, 54);
            homeText.TabIndex = 3;
            homeText.Text = "Selamat Datang";
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 547);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Name = "FormAdmin";
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
        private ToolStripMenuItem kelolaBukuToolStripMenuItem;
        private Label homeText;
        private ToolStripMenuItem masterDataToolStripMenuItem;
        private ToolStripMenuItem kelolaBukuToolStripMenuItem1;
        private ToolStripMenuItem kelolaAnggotaToolStripMenuItem1;
        private ToolStripMenuItem kategoriBukuToolStripMenuItem;
        private ToolStripMenuItem dataTransaksiToolStripMenuItem;
        private ToolStripMenuItem peminjamanPengembalianToolStripMenuItem;
        private ToolStripMenuItem riwayatDendaToolStripMenuItem;
        private ToolStripMenuItem laporanToolStripMenuItem;
        private ToolStripMenuItem laporanPeminjamanToolStripMenuItem;
        private ToolStripMenuItem akunToolStripMenuItem;
        private ToolStripMenuItem gantiPasswordToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
    }
}
