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
            panel2 = new Panel();
            label2 = new Label();
            panel3 = new Panel();
            panel1 = new Panel();
            menuStrip2 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            masterDataToolStripMenuItem = new ToolStripMenuItem();
            kelolaBukuToolStripMenuItem1 = new ToolStripMenuItem();
            kelolaAnggotaToolStripMenuItem1 = new ToolStripMenuItem();
            dataTransaksiToolStripMenuItem = new ToolStripMenuItem();
            peminjamanPengembalianToolStripMenuItem = new ToolStripMenuItem();
            riwayatDendaToolStripMenuItem = new ToolStripMenuItem();
            laporanToolStripMenuItem = new ToolStripMenuItem();
            laporanPeminjamanToolStripMenuItem = new ToolStripMenuItem();
            laporanInventarisBukuToolStripMenuItem = new ToolStripMenuItem();
            akunToolStripMenuItem = new ToolStripMenuItem();
            gantiPasswordToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            panel4 = new Panel();
            panel7 = new Panel();
            label5 = new Label();
            lblStokKosong = new Label();
            panel6 = new Panel();
            label3 = new Label();
            lblTotalBuku = new Label();
            panel5 = new Panel();
            label4 = new Label();
            lblTotalMember = new Label();
            dataGridView1 = new DataGridView();
            label6 = new Label();
            lblTanggal = new Label();
            homeText = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            menuStrip2.SuspendLayout();
            panel4.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.System;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(178, 9);
            label1.Name = "label1";
            label1.Size = new Size(477, 41);
            label1.TabIndex = 0;
            label1.Text = "APLIKASI PERPUSTAKAAN LibRa";
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
            menuStrip2.BackColor = Color.CornflowerBlue;
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
            menuToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            menuToolStripMenuItem.ForeColor = Color.White;
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(121, 26);
            menuToolStripMenuItem.Text = "🏠Dashboard";
            menuToolStripMenuItem.Click += menuToolStripMenuItem1_Click;
            // 
            // masterDataToolStripMenuItem
            // 
            masterDataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kelolaBukuToolStripMenuItem1, kelolaAnggotaToolStripMenuItem1 });
            masterDataToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            masterDataToolStripMenuItem.ForeColor = Color.White;
            masterDataToolStripMenuItem.Name = "masterDataToolStripMenuItem";
            masterDataToolStripMenuItem.Size = new Size(131, 26);
            masterDataToolStripMenuItem.Text = "💾Master Data";
            // 
            // kelolaBukuToolStripMenuItem1
            // 
            kelolaBukuToolStripMenuItem1.Name = "kelolaBukuToolStripMenuItem1";
            kelolaBukuToolStripMenuItem1.Size = new Size(222, 26);
            kelolaBukuToolStripMenuItem1.Text = "📚Kelola Buku";
            kelolaBukuToolStripMenuItem1.Click += kelolaBukuToolStripMenuItem1_Click;
            // 
            // kelolaAnggotaToolStripMenuItem1
            // 
            kelolaAnggotaToolStripMenuItem1.Name = "kelolaAnggotaToolStripMenuItem1";
            kelolaAnggotaToolStripMenuItem1.Size = new Size(222, 26);
            kelolaAnggotaToolStripMenuItem1.Text = "👤Kelola Anggota";
            kelolaAnggotaToolStripMenuItem1.Click += kelolaAnggotaToolStripMenuItem1_Click;
            // 
            // dataTransaksiToolStripMenuItem
            // 
            dataTransaksiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { peminjamanPengembalianToolStripMenuItem, riwayatDendaToolStripMenuItem });
            dataTransaksiToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataTransaksiToolStripMenuItem.ForeColor = Color.White;
            dataTransaksiToolStripMenuItem.Name = "dataTransaksiToolStripMenuItem";
            dataTransaksiToolStripMenuItem.Size = new Size(147, 26);
            dataTransaksiToolStripMenuItem.Text = "🔄Data Transaksi";
            // 
            // peminjamanPengembalianToolStripMenuItem
            // 
            peminjamanPengembalianToolStripMenuItem.Name = "peminjamanPengembalianToolStripMenuItem";
            peminjamanPengembalianToolStripMenuItem.Size = new Size(308, 26);
            peminjamanPengembalianToolStripMenuItem.Text = "📚Peminjaman & Pengembalian";
            peminjamanPengembalianToolStripMenuItem.Click += peminjamanPengembalianToolStripMenuItem_Click;
            // 
            // riwayatDendaToolStripMenuItem
            // 
            riwayatDendaToolStripMenuItem.Name = "riwayatDendaToolStripMenuItem";
            riwayatDendaToolStripMenuItem.Size = new Size(308, 26);
            riwayatDendaToolStripMenuItem.Text = "📝Riwayat Denda";
            riwayatDendaToolStripMenuItem.Click += riwayatDendaToolStripMenuItem_Click;
            // 
            // laporanToolStripMenuItem
            // 
            laporanToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { laporanPeminjamanToolStripMenuItem, laporanInventarisBukuToolStripMenuItem });
            laporanToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            laporanToolStripMenuItem.ForeColor = Color.White;
            laporanToolStripMenuItem.Name = "laporanToolStripMenuItem";
            laporanToolStripMenuItem.Size = new Size(102, 26);
            laporanToolStripMenuItem.Text = "📄Laporan";
            // 
            // laporanPeminjamanToolStripMenuItem
            // 
            laporanPeminjamanToolStripMenuItem.Name = "laporanPeminjamanToolStripMenuItem";
            laporanPeminjamanToolStripMenuItem.Size = new Size(285, 26);
            laporanPeminjamanToolStripMenuItem.Text = "📜Laporan Peminjaman";
            laporanPeminjamanToolStripMenuItem.Click += laporanPeminjamanToolStripMenuItem_Click;
            // 
            // laporanInventarisBukuToolStripMenuItem
            // 
            laporanInventarisBukuToolStripMenuItem.Name = "laporanInventarisBukuToolStripMenuItem";
            laporanInventarisBukuToolStripMenuItem.Size = new Size(285, 26);
            laporanInventarisBukuToolStripMenuItem.Text = "📖Laporan Inventaris Buku";
            laporanInventarisBukuToolStripMenuItem.Click += laporanInventarisBukuToolStripMenuItem_Click;
            // 
            // akunToolStripMenuItem
            // 
            akunToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gantiPasswordToolStripMenuItem, logOutToolStripMenuItem });
            akunToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            akunToolStripMenuItem.ForeColor = Color.White;
            akunToolStripMenuItem.Name = "akunToolStripMenuItem";
            akunToolStripMenuItem.Size = new Size(82, 26);
            akunToolStripMenuItem.Text = "⚙Akun";
            // 
            // gantiPasswordToolStripMenuItem
            // 
            gantiPasswordToolStripMenuItem.Name = "gantiPasswordToolStripMenuItem";
            gantiPasswordToolStripMenuItem.Size = new Size(223, 26);
            gantiPasswordToolStripMenuItem.Text = "🔑Ganti Password";
            gantiPasswordToolStripMenuItem.Click += gantiPasswordToolStripMenuItem_Click;
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(223, 26);
            logOutToolStripMenuItem.Text = "➜]Log Out";
            logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(panel7);
            panel4.Controls.Add(panel6);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(dataGridView1);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(lblTanggal);
            panel4.Controls.Add(homeText);
            panel4.Controls.Add(panel2);
            panel4.Dock = DockStyle.Fill;
            panel4.ForeColor = SystemColors.ControlText;
            panel4.Location = new Point(0, 93);
            panel4.Margin = new Padding(2);
            panel4.Name = "panel4";
            panel4.Size = new Size(826, 454);
            panel4.TabIndex = 4;
            panel4.Paint += panel4_Paint;
            // 
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.Controls.Add(label5);
            panel7.Controls.Add(lblStokKosong);
            panel7.Location = new Point(582, 80);
            panel7.Name = "panel7";
            panel7.Size = new Size(205, 81);
            panel7.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.ForeColor = Color.FromArgb(100, 116, 139);
            label5.Location = new Point(37, 10);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(132, 23);
            label5.TabIndex = 7;
            label5.Text = "📉 Stok Kosong";
            // 
            // lblStokKosong
            // 
            lblStokKosong.AutoSize = true;
            lblStokKosong.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblStokKosong.ForeColor = Color.FromArgb(239, 68, 68);
            lblStokKosong.Location = new Point(96, 33);
            lblStokKosong.Margin = new Padding(2, 0, 2, 0);
            lblStokKosong.Name = "lblStokKosong";
            lblStokKosong.Size = new Size(28, 32);
            lblStokKosong.TabIndex = 10;
            lblStokKosong.Text = "0";
            lblStokKosong.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(label3);
            panel6.Controls.Add(lblTotalBuku);
            panel6.Location = new Point(307, 80);
            panel6.Name = "panel6";
            panel6.Size = new Size(205, 81);
            panel6.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.FromArgb(100, 116, 139);
            label3.Location = new Point(45, 10);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(117, 23);
            label3.TabIndex = 5;
            label3.Text = "📕 Total Buku";
            // 
            // lblTotalBuku
            // 
            lblTotalBuku.AutoSize = true;
            lblTotalBuku.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalBuku.ForeColor = Color.FromArgb(37, 99, 235);
            lblTotalBuku.Location = new Point(92, 33);
            lblTotalBuku.Margin = new Padding(2, 0, 2, 0);
            lblTotalBuku.Name = "lblTotalBuku";
            lblTotalBuku.Size = new Size(28, 32);
            lblTotalBuku.TabIndex = 9;
            lblTotalBuku.Text = "0";
            lblTotalBuku.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(label4);
            panel5.Controls.Add(lblTotalMember);
            panel5.Location = new Point(30, 80);
            panel5.Name = "panel5";
            panel5.Size = new Size(205, 81);
            panel5.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = Color.FromArgb(100, 116, 139);
            label4.Location = new Point(29, 10);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(145, 23);
            label4.TabIndex = 6;
            label4.Text = "👤 Total Anggota";
            // 
            // lblTotalMember
            // 
            lblTotalMember.AutoSize = true;
            lblTotalMember.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalMember.ForeColor = Color.FromArgb(37, 99, 235);
            lblTotalMember.Location = new Point(89, 33);
            lblTotalMember.Margin = new Padding(2, 0, 2, 0);
            lblTotalMember.Name = "lblTotalMember";
            lblTotalMember.Size = new Size(28, 32);
            lblTotalMember.TabIndex = 8;
            lblTotalMember.Text = "0";
            lblTotalMember.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(11, 217);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(803, 191);
            dataGridView1.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(11, 191);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(217, 23);
            label6.TabIndex = 11;
            label6.Text = "Buku Baru Ditambahkan: ";
            label6.Click += label6_Click;
            // 
            // lblTanggal
            // 
            lblTanggal.AutoSize = true;
            lblTanggal.Font = new Font("Segoe UI", 8F);
            lblTanggal.ForeColor = Color.FromArgb(100, 116, 139);
            lblTanggal.Location = new Point(11, 39);
            lblTanggal.Margin = new Padding(2, 0, 2, 0);
            lblTanggal.Name = "lblTanggal";
            lblTanggal.Size = new Size(55, 19);
            lblTanggal.TabIndex = 4;
            lblTanggal.Text = "Tanggal";
            lblTanggal.Click += lblTanggal_Click;
            // 
            // homeText
            // 
            homeText.AutoSize = true;
            homeText.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            homeText.Location = new Point(3, 2);
            homeText.Margin = new Padding(2, 0, 2, 0);
            homeText.Name = "homeText";
            homeText.Size = new Size(222, 37);
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
            IsMdiContainer = true;
            Name = "FormAdmin";
            Text = "Aplikasi Perpustakaan";
            FormClosed += FormAdmin_FormClosed;
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
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Label label2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel1;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem menuToolStripMenuItem;
        private Label homeText;
        private ToolStripMenuItem masterDataToolStripMenuItem;
        private ToolStripMenuItem kelolaBukuToolStripMenuItem1;
        private ToolStripMenuItem kelolaAnggotaToolStripMenuItem1;
        private ToolStripMenuItem dataTransaksiToolStripMenuItem;
        private ToolStripMenuItem peminjamanPengembalianToolStripMenuItem;
        private ToolStripMenuItem riwayatDendaToolStripMenuItem;
        private ToolStripMenuItem laporanToolStripMenuItem;
        private ToolStripMenuItem laporanPeminjamanToolStripMenuItem;
        private ToolStripMenuItem akunToolStripMenuItem;
        private ToolStripMenuItem gantiPasswordToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private ToolStripMenuItem laporanInventarisBukuToolStripMenuItem;
        private Label lblTanggal;
        private Label label5;
        private Label label4;
        private Label label3;
        private DataGridView dataGridView1;
        private Label label6;
        private Label lblStokKosong;
        private Label lblTotalBuku;
        private Label lblTotalMember;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
    }
}
