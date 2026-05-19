namespace Project_VISPROG_KEL_3
{
    partial class KelolaAnggota
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
            label5 = new Label();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            button3 = new Button();
            button4 = new Button();
            button2 = new Button();
            panel1 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 21);
            panel1.Name = "panel1";
            panel1.Size = new Size(357, 403);
            panel1.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label5.Location = new Point(64, 35);
            label5.Name = "label5";
            label5.Size = new Size(224, 32);
            label5.TabIndex = 19;
            label5.Text = "Edit Data Anggota";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(144, 239);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(198, 27);
            textBox4.TabIndex = 17;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(144, 196);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(198, 27);
            textBox3.TabIndex = 16;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(144, 147);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(198, 27);
            textBox2.TabIndex = 15;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(144, 102);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(198, 27);
            textBox1.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 242);
            label4.Name = "label4";
            label4.Size = new Size(105, 20);
            label4.TabIndex = 13;
            label4.Text = "Nomor Telpon";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 196);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 12;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 150);
            label2.Name = "label2";
            label2.Size = new Size(109, 20);
            label2.TabIndex = 11;
            label2.Text = "Nama Lengkap";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 105);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 10;
            label1.Text = "ID Anggota";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label6.Location = new Point(651, 21);
            label6.Name = "label6";
            label6.Size = new Size(159, 32);
            label6.TabIndex = 20;
            label6.Text = "List Anggota";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(406, 56);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(676, 253);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick_1;
            // 
            // button3
            // 
            button3.BackColor = Color.Red;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button3.ForeColor = SystemColors.ControlLightLight;
            button3.Location = new Point(406, 315);
            button3.Name = "button3";
            button3.Size = new Size(192, 36);
            button3.TabIndex = 11;
            button3.Text = "Hapus";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.Highlight;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button4.ForeColor = SystemColors.ControlLightLight;
            button4.Location = new Point(651, 315);
            button4.Name = "button4";
            button4.Size = new Size(192, 36);
            button4.TabIndex = 11;
            button4.Text = "Edit";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Orange;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Location = new Point(892, 315);
            button2.Name = "button2";
            button2.Size = new Size(190, 36);
            button2.TabIndex = 21;
            button2.Text = "Suspend";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // KelolaAnggota
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1115, 450);
            Controls.Add(button2);
            Controls.Add(button4);
            Controls.Add(label6);
            Controls.Add(button3);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Name = "KelolaAnggota";
            Text = "KelolaAnggota";
            Load += KelolaAnggota_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private Label label6;
        private DataGridView dataGridView1;
        private Button button3;
        private Button button4;
        private Button button2;
    }
}