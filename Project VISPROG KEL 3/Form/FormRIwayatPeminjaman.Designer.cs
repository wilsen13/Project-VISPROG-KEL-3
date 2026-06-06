namespace Project_VISPROG_KEL_3
{
    partial class FormRIwayatPeminjaman
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
            dataGridView1 = new DataGridView();
            lblIsiTipe = new Label();
            lblIsiTahun = new Label();
            lblIsiPenulis = new Label();
            lblIsiJudul = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            picCover = new PictureBox();
            btnCari = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCover).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(776, 225);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // lblIsiTipe
            // 
            lblIsiTipe.AutoSize = true;
            lblIsiTipe.Location = new Point(262, 390);
            lblIsiTipe.Name = "lblIsiTipe";
            lblIsiTipe.Size = new Size(15, 20);
            lblIsiTipe.TabIndex = 36;
            lblIsiTipe.Text = "-";
            // 
            // lblIsiTahun
            // 
            lblIsiTahun.AutoSize = true;
            lblIsiTahun.Location = new Point(262, 349);
            lblIsiTahun.Name = "lblIsiTahun";
            lblIsiTahun.Size = new Size(15, 20);
            lblIsiTahun.TabIndex = 35;
            lblIsiTahun.Text = "-";
            // 
            // lblIsiPenulis
            // 
            lblIsiPenulis.AutoSize = true;
            lblIsiPenulis.Location = new Point(262, 306);
            lblIsiPenulis.Name = "lblIsiPenulis";
            lblIsiPenulis.Size = new Size(15, 20);
            lblIsiPenulis.TabIndex = 34;
            lblIsiPenulis.Text = "-";
            // 
            // lblIsiJudul
            // 
            lblIsiJudul.AutoSize = true;
            lblIsiJudul.Location = new Point(262, 264);
            lblIsiJudul.Name = "lblIsiJudul";
            lblIsiJudul.Size = new Size(15, 20);
            lblIsiJudul.TabIndex = 33;
            lblIsiJudul.Text = "-";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(160, 390);
            label8.Name = "label8";
            label8.Size = new Size(45, 20);
            label8.TabIndex = 32;
            label8.Text = "Tipe: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(160, 349);
            label7.Name = "label7";
            label7.Size = new Size(96, 20);
            label7.TabIndex = 31;
            label7.Text = "Tahun Terbit: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(160, 306);
            label6.Name = "label6";
            label6.Size = new Size(61, 20);
            label6.TabIndex = 30;
            label6.Text = "Penulis: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(160, 264);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 29;
            label5.Text = "Judul: ";
            // 
            // picCover
            // 
            picCover.Location = new Point(12, 264);
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
            btnCari.Location = new Point(621, 243);
            btnCari.Name = "btnCari";
            btnCari.Size = new Size(167, 41);
            btnCari.TabIndex = 37;
            btnCari.Text = "Export ke TXT";
            btnCari.UseVisualStyleBackColor = false;
            btnCari.Click += btnCari_Click;
            // 
            // FormRIwayatPeminjaman
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCari);
            Controls.Add(lblIsiTipe);
            Controls.Add(lblIsiTahun);
            Controls.Add(lblIsiPenulis);
            Controls.Add(lblIsiJudul);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(picCover);
            Controls.Add(dataGridView1);
            Name = "FormRIwayatPeminjaman";
            Text = "FormRIwayatPeminjaman";
            Load += FormRIwayatPeminjaman_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCover).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label lblIsiTipe;
        private Label lblIsiTahun;
        private Label lblIsiPenulis;
        private Label lblIsiJudul;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private PictureBox picCover;
        private Button btnCari;
    }
}