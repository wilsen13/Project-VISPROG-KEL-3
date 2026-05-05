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
            KatalogBuku = new DataGridView();
            label2 = new Label();
            label4 = new Label();
            bukuSaya = new DataGridView();
            button2 = new Button();
            label5 = new Label();
            textBox2 = new TextBox();
            button4 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            label3 = new Label();
            textBox1 = new TextBox();
            btnCari = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)KatalogBuku).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bukuSaya).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
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
            KatalogBuku.Size = new Size(697, 228);
            KatalogBuku.TabIndex = 1;
            KatalogBuku.CellContentClick += KatalogBuku_CellContentClick;
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
            bukuSaya.Size = new Size(695, 223);
            bukuSaya.TabIndex = 6;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Highlight;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(498, 265);
            button2.Name = "button2";
            button2.Size = new Size(203, 53);
            button2.TabIndex = 8;
            button2.Text = "Kembalikan Buku ";
            button2.UseVisualStyleBackColor = false;
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
            // tabPage2
            // 
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
            button1.Location = new Point(497, 274);
            button1.Name = "button1";
            button1.Size = new Size(204, 44);
            button1.TabIndex = 7;
            button1.Text = "Pinjam Buku";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
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
            ((System.ComponentModel.ISupportInitialize)KatalogBuku).EndInit();
            ((System.ComponentModel.ISupportInitialize)bukuSaya).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView KatalogBuku;
        private Label label2;
        private Label label4;
        private DataGridView bukuSaya;
        private Button button2;
        private Label label5;
        private TextBox textBox2;
        private Button button4;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label3;
        private Button button1;
        private TextBox textBox1;
        private Button btnCari;
    }
}