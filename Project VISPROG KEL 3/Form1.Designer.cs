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
            groupBox1 = new GroupBox();
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            peninjamanBukuToolStripMenuItem = new ToolStripMenuItem();
            kelolaBukuToolStripMenuItem = new ToolStripMenuItem();
            kelolaAnggotaToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            label2 = new Label();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(menuStrip1);
            groupBox1.Location = new Point(212, 144);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(402, 298);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Menu";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(3, 23);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(396, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { peninjamanBukuToolStripMenuItem, kelolaBukuToolStripMenuItem, kelolaAnggotaToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(60, 24);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // peninjamanBukuToolStripMenuItem
            // 
            peninjamanBukuToolStripMenuItem.Name = "peninjamanBukuToolStripMenuItem";
            peninjamanBukuToolStripMenuItem.Size = new Size(224, 26);
            peninjamanBukuToolStripMenuItem.Text = "Peninjaman Buku";
            peninjamanBukuToolStripMenuItem.Click += peninjamanBukuToolStripMenuItem_Click;
            // 
            // kelolaBukuToolStripMenuItem
            // 
            kelolaBukuToolStripMenuItem.Name = "kelolaBukuToolStripMenuItem";
            kelolaBukuToolStripMenuItem.Size = new Size(224, 26);
            kelolaBukuToolStripMenuItem.Text = "Kelola Buku";
            kelolaBukuToolStripMenuItem.Click += kelolaBukuToolStripMenuItem_Click;
            // 
            // kelolaAnggotaToolStripMenuItem
            // 
            kelolaAnggotaToolStripMenuItem.Name = "kelolaAnggotaToolStripMenuItem";
            kelolaAnggotaToolStripMenuItem.Size = new Size(224, 26);
            kelolaAnggotaToolStripMenuItem.Text = "Kelola Anggota";
            kelolaAnggotaToolStripMenuItem.Click += kelolaAnggotaToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-2, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(832, 120);
            panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(138, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(116, 104);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.System;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(393, 65);
            label3.Name = "label3";
            label3.Size = new Size(89, 37);
            label3.TabIndex = 2;
            label3.Text = "LibRa";
            label3.Click += label3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.System;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(275, 24);
            label1.Name = "label1";
            label1.Size = new Size(390, 41);
            label1.TabIndex = 0;
            label1.Text = "APLIKASI PERPUSTAKAAN";
            label1.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Highlight;
            panel2.Controls.Add(label2);
            panel2.Location = new Point(-2, 479);
            panel2.Name = "panel2";
            panel2.Size = new Size(832, 67);
            panel2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.System;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(363, 25);
            label2.Name = "label2";
            label2.Size = new Size(107, 23);
            label2.TabIndex = 4;
            label2.Text = "Kelompok 3";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 547);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Aplikasi Perpustakaan";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Panel panel1;
        private Label label1;
        private Label label3;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Label label2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem peninjamanBukuToolStripMenuItem;
        private ToolStripMenuItem kelolaBukuToolStripMenuItem;
        private ToolStripMenuItem kelolaAnggotaToolStripMenuItem;
    }
}
