namespace Project_VISPROG_KEL_3
{
    partial class FormPeminjaman
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
            label4 = new Label();
            bukuSaya = new DataGridView();
            button2 = new Button();
            label5 = new Label();
            textBox2 = new TextBox();
            button4 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            lblIsiTipe = new Label();
            lblIsiTahun = new Label();
            lblIsiPenulis = new Label();
            lblIsiJudul = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label1 = new Label();
            picCover = new PictureBox();
            btnCari = new Button();
            button1 = new Button();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            KatalogBuku = new DataGridView();
            tabPage2 = new TabPage();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)bukuSaya).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCover).BeginInit();
            ((System.ComponentModel.ISupportInitialize)KatalogBuku).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(6, 13);
            label4.Name = "label4";
            label4.Size = new Size(224, 20);
            label4.TabIndex = 5;
            label4.Text = "Buku yang sedang saya pinjam";
            // 
            // bukuSaya
            // 
            bukuSaya.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bukuSaya.BackgroundColor = Color.White;
            bukuSaya.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            bukuSaya.Location = new Point(6, 36);
            bukuSaya.Name = "bukuSaya";
            bukuSaya.RowHeadersWidth = 51;
            bukuSaya.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bukuSaya.Size = new Size(695, 197);
            bukuSaya.TabIndex = 6;
            bukuSaya.CellClick += bukuSaya_CellClick;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Highlight;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(498, 239);
            button2.Name = "button2";
            button2.Size = new Size(203, 53);
            button2.TabIndex = 8;
            button2.Text = "Kembalikan Buku ";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(281, 13);
            label5.Name = "label5";
            label5.Size = new Size(80, 20);
            label5.TabIndex = 10;
            label5.Text = "Cari Buku:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(367, 6);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(169, 27);
            textBox2.TabIndex = 9;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.Highlight;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button4.ForeColor = Color.White;
            button4.Location = new Point(555, 6);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 12;
            button4.Text = "Cari";
            button4.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tabControl1.Location = new Point(0, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(717, 437);
            tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(lblIsiTipe);
            tabPage1.Controls.Add(lblIsiTahun);
            tabPage1.Controls.Add(lblIsiPenulis);
            tabPage1.Controls.Add(lblIsiJudul);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(picCover);
            tabPage1.Controls.Add(btnCari);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(KatalogBuku);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(709, 404);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Pinjam Buku";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblIsiTipe
            // 
            lblIsiTipe.AutoSize = true;
            lblIsiTipe.Location = new Point(258, 367);
            lblIsiTipe.Name = "lblIsiTipe";
            lblIsiTipe.Size = new Size(15, 20);
            lblIsiTipe.TabIndex = 36;
            lblIsiTipe.Text = "-";
            // 
            // lblIsiTahun
            // 
            lblIsiTahun.AutoSize = true;
            lblIsiTahun.Location = new Point(258, 326);
            lblIsiTahun.Name = "lblIsiTahun";
            lblIsiTahun.Size = new Size(15, 20);
            lblIsiTahun.TabIndex = 35;
            lblIsiTahun.Text = "-";
            // 
            // lblIsiPenulis
            // 
            lblIsiPenulis.AutoSize = true;
            lblIsiPenulis.Location = new Point(258, 283);
            lblIsiPenulis.Name = "lblIsiPenulis";
            lblIsiPenulis.Size = new Size(15, 20);
            lblIsiPenulis.TabIndex = 34;
            lblIsiPenulis.Text = "-";
            // 
            // lblIsiJudul
            // 
            lblIsiJudul.AutoSize = true;
            lblIsiJudul.Location = new Point(258, 241);
            lblIsiJudul.Name = "lblIsiJudul";
            lblIsiJudul.Size = new Size(15, 20);
            lblIsiJudul.TabIndex = 33;
            lblIsiJudul.Text = "-";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(156, 367);
            label8.Name = "label8";
            label8.Size = new Size(47, 20);
            label8.TabIndex = 32;
            label8.Text = "Tipe: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(156, 326);
            label7.Name = "label7";
            label7.Size = new Size(105, 20);
            label7.TabIndex = 31;
            label7.Text = "Tahun Terbit: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(156, 283);
            label6.Name = "label6";
            label6.Size = new Size(67, 20);
            label6.TabIndex = 30;
            label6.Text = "Penulis: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(156, 241);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 29;
            label1.Text = "Judul: ";
            // 
            // picCover
            // 
            picCover.Location = new Point(8, 241);
            picCover.Name = "picCover";
            picCover.Size = new Size(125, 157);
            picCover.SizeMode = PictureBoxSizeMode.Zoom;
            picCover.TabIndex = 28;
            picCover.TabStop = false;
            // 
            // btnCari
            // 
            btnCari.BackColor = SystemColors.Highlight;
            btnCari.FlatAppearance.BorderSize = 0;
            btnCari.FlatStyle = FlatStyle.Flat;
            btnCari.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCari.ForeColor = Color.White;
            btnCari.Location = new Point(607, 9);
            btnCari.Name = "btnCari";
            btnCari.Size = new Size(94, 29);
            btnCari.TabIndex = 11;
            btnCari.Text = "Cari";
            btnCari.UseVisualStyleBackColor = false;
            btnCari.Click += btnCari_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Highlight;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(499, 232);
            button1.Name = "button1";
            button1.Size = new Size(204, 44);
            button1.TabIndex = 7;
            button1.Text = "Pinjam Buku";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(328, 15);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 4;
            label3.Text = "Cari Buku:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(423, 10);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(169, 27);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(6, 17);
            label2.Name = "label2";
            label2.Size = new Size(147, 20);
            label2.TabIndex = 2;
            label2.Text = "Buku yang tersedia:";
            // 
            // KatalogBuku
            // 
            KatalogBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            KatalogBuku.BackgroundColor = Color.White;
            KatalogBuku.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            KatalogBuku.Location = new Point(6, 40);
            KatalogBuku.Name = "KatalogBuku";
            KatalogBuku.RowHeadersWidth = 51;
            KatalogBuku.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            KatalogBuku.Size = new Size(697, 186);
            KatalogBuku.TabIndex = 1;
            KatalogBuku.CellClick += KatalogBuku_CellClick;
            KatalogBuku.CellContentClick += KatalogBuku_CellContentClick;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(label13);
            tabPage2.Controls.Add(label14);
            tabPage2.Controls.Add(label15);
            tabPage2.Controls.Add(label16);
            tabPage2.Controls.Add(pictureBox1);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(button4);
            tabPage2.Controls.Add(bukuSaya);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(709, 404);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Buku Saya";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(270, 367);
            label9.Name = "label9";
            label9.Size = new Size(15, 20);
            label9.TabIndex = 45;
            label9.Text = "-";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(270, 326);
            label10.Name = "label10";
            label10.Size = new Size(15, 20);
            label10.TabIndex = 44;
            label10.Text = "-";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(270, 283);
            label11.Name = "label11";
            label11.Size = new Size(15, 20);
            label11.TabIndex = 43;
            label11.Text = "-";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(270, 241);
            label12.Name = "label12";
            label12.Size = new Size(15, 20);
            label12.TabIndex = 42;
            label12.Text = "-";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(168, 367);
            label13.Name = "label13";
            label13.Size = new Size(47, 20);
            label13.TabIndex = 41;
            label13.Text = "Tipe: ";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(168, 326);
            label14.Name = "label14";
            label14.Size = new Size(105, 20);
            label14.TabIndex = 40;
            label14.Text = "Tahun Terbit: ";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(168, 283);
            label15.Name = "label15";
            label15.Size = new Size(67, 20);
            label15.TabIndex = 39;
            label15.Text = "Penulis: ";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(168, 241);
            label16.Name = "label16";
            label16.Size = new Size(55, 20);
            label16.TabIndex = 38;
            label16.Text = "Judul: ";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(20, 241);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 157);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 37;
            pictureBox1.TabStop = false;
            // 
            // FormPeminjaman
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 450);
            Controls.Add(tabControl1);
            Name = "FormPeminjaman";
            Text = "FormPeminjaman";
            Load += FormPeminjaman_Load;
            ((System.ComponentModel.ISupportInitialize)bukuSaya).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picCover).EndInit();
            ((System.ComponentModel.ISupportInitialize)KatalogBuku).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label4;
        private DataGridView bukuSaya;
        private Button button2;
        private Label label5;
        private TextBox textBox2;
        private Button button4;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private Label lblIsiTipe;
        private Label lblIsiTahun;
        private Label lblIsiPenulis;
        private Label lblIsiJudul;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label1;
        private PictureBox picCover;
        private Button btnCari;
        private Button button1;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private DataGridView KatalogBuku;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private PictureBox pictureBox1;
    }
}