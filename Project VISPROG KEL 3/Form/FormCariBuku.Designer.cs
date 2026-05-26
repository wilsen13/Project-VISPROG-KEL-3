namespace Project_VISPROG_KEL_3
{
    partial class FormCariBuku
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
            btnCari = new Button();
            label3 = new Label();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            picCover = new PictureBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            lblIsiJudul = new Label();
            lblIsiPenulis = new Label();
            lblIsiTahun = new Label();
            lblIsiTipe = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCover).BeginInit();
            SuspendLayout();
            // 
            // btnCari
            // 
            btnCari.BackColor = SystemColors.Highlight;
            btnCari.FlatAppearance.BorderSize = 0;
            btnCari.FlatStyle = FlatStyle.Flat;
            btnCari.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCari.ForeColor = Color.White;
            btnCari.Location = new Point(401, 12);
            btnCari.Name = "btnCari";
            btnCari.Size = new Size(94, 29);
            btnCari.TabIndex = 18;
            btnCari.Text = "Cari";
            btnCari.UseVisualStyleBackColor = false;
            btnCari.Click += btnCari_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(24, 18);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 17;
            label3.Text = "Cari Buku:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(119, 13);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(264, 27);
            textBox1.TabIndex = 16;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 47);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(776, 219);
            dataGridView1.TabIndex = 15;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // picCover
            // 
            picCover.Location = new Point(24, 281);
            picCover.Name = "picCover";
            picCover.Size = new Size(125, 157);
            picCover.SizeMode = PictureBoxSizeMode.Zoom;
            picCover.TabIndex = 19;
            picCover.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(172, 281);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 20;
            label5.Text = "Judul: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(172, 323);
            label6.Name = "label6";
            label6.Size = new Size(61, 20);
            label6.TabIndex = 21;
            label6.Text = "Penulis: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(172, 366);
            label7.Name = "label7";
            label7.Size = new Size(96, 20);
            label7.TabIndex = 22;
            label7.Text = "Tahun Terbit: ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(172, 407);
            label8.Name = "label8";
            label8.Size = new Size(45, 20);
            label8.TabIndex = 23;
            label8.Text = "Tipe: ";
            // 
            // lblIsiJudul
            // 
            lblIsiJudul.AutoSize = true;
            lblIsiJudul.Location = new Point(274, 281);
            lblIsiJudul.Name = "lblIsiJudul";
            lblIsiJudul.Size = new Size(15, 20);
            lblIsiJudul.TabIndex = 24;
            lblIsiJudul.Text = "-";
            // 
            // lblIsiPenulis
            // 
            lblIsiPenulis.AutoSize = true;
            lblIsiPenulis.Location = new Point(274, 323);
            lblIsiPenulis.Name = "lblIsiPenulis";
            lblIsiPenulis.Size = new Size(15, 20);
            lblIsiPenulis.TabIndex = 25;
            lblIsiPenulis.Text = "-";
            // 
            // lblIsiTahun
            // 
            lblIsiTahun.AutoSize = true;
            lblIsiTahun.Location = new Point(274, 366);
            lblIsiTahun.Name = "lblIsiTahun";
            lblIsiTahun.Size = new Size(15, 20);
            lblIsiTahun.TabIndex = 26;
            lblIsiTahun.Text = "-";
            // 
            // lblIsiTipe
            // 
            lblIsiTipe.AutoSize = true;
            lblIsiTipe.Location = new Point(274, 407);
            lblIsiTipe.Name = "lblIsiTipe";
            lblIsiTipe.Size = new Size(15, 20);
            lblIsiTipe.TabIndex = 27;
            lblIsiTipe.Text = "-";
            // 
            // FormCariBuku
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblIsiTipe);
            Controls.Add(lblIsiTahun);
            Controls.Add(lblIsiPenulis);
            Controls.Add(lblIsiJudul);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(picCover);
            Controls.Add(btnCari);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Name = "FormCariBuku";
            Text = "FormCariBuku";
            Load += FormCariBuku_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCover).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCari;
        private Label label3;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private PictureBox picCover;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label lblIsiJudul;
        private Label lblIsiPenulis;
        private Label lblIsiTahun;
        private Label lblIsiTipe;
    }
}