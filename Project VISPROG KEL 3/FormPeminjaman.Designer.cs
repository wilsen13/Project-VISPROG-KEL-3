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
            label1 = new Label();
            KatalogBuku = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            bukuSaya = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            label5 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            btnCari = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)KatalogBuku).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bukuSaya).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(291, 9);
            label1.Name = "label1";
            label1.Size = new Size(214, 37);
            label1.TabIndex = 0;
            label1.Text = "Selamat Datang!";
            // 
            // KatalogBuku
            // 
            KatalogBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            KatalogBuku.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            KatalogBuku.Location = new Point(12, 73);
            KatalogBuku.Name = "KatalogBuku";
            KatalogBuku.RowHeadersWidth = 51;
            KatalogBuku.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            KatalogBuku.Size = new Size(365, 148);
            KatalogBuku.TabIndex = 1;
            KatalogBuku.CellContentClick += KatalogBuku_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(12, 50);
            label2.Name = "label2";
            label2.Size = new Size(137, 20);
            label2.TabIndex = 2;
            label2.Text = "Buku yang tersedia:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(384, 76);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 4;
            label3.Text = "Cari Buku:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(12, 247);
            label4.Name = "label4";
            label4.Size = new Size(212, 20);
            label4.TabIndex = 5;
            label4.Text = "Buku yang sedang saya pinjam";
            // 
            // bukuSaya
            // 
            bukuSaya.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bukuSaya.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            bukuSaya.Location = new Point(12, 270);
            bukuSaya.Name = "bukuSaya";
            bukuSaya.RowHeadersWidth = 51;
            bukuSaya.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bukuSaya.Size = new Size(365, 148);
            bukuSaya.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(403, 122);
            button1.Name = "button1";
            button1.Size = new Size(327, 99);
            button1.TabIndex = 7;
            button1.Text = "Pinjam Buku";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(403, 319);
            button2.Name = "button2";
            button2.Size = new Size(327, 99);
            button2.TabIndex = 8;
            button2.Text = "Kembalikan Buku ";
            button2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F);
            label5.Location = new Point(396, 273);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 10;
            label5.Text = "Cari Buku:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(478, 270);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(169, 27);
            textBox2.TabIndex = 9;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(478, 73);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(169, 27);
            textBox1.TabIndex = 3;
            // 
            // btnCari
            // 
            btnCari.Location = new Point(663, 73);
            btnCari.Name = "btnCari";
            btnCari.Size = new Size(94, 29);
            btnCari.TabIndex = 11;
            btnCari.Text = "Cari";
            btnCari.UseVisualStyleBackColor = true;
            btnCari.Click += btnCari_Click;
            // 
            // button4
            // 
            button4.Location = new Point(663, 270);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 12;
            button4.Text = "Cari";
            button4.UseVisualStyleBackColor = true;
            // 
            // FormPeminjaman
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(btnCari);
            Controls.Add(label5);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(bukuSaya);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(KatalogBuku);
            Controls.Add(label1);
            Name = "FormPeminjaman";
            Text = "FormPeminjaman";
            Load += FormPeminjaman_Load;
            ((System.ComponentModel.ISupportInitialize)KatalogBuku).EndInit();
            ((System.ComponentModel.ISupportInitialize)bukuSaya).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView KatalogBuku;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView bukuSaya;
        private Button button1;
        private Button button2;
        private Label label5;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button btnCari;
        private Button button4;
    }
}