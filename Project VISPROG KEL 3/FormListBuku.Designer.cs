namespace Project_VISPROG_KEL_3
{
    partial class FormListBuku
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
            panel1 = new Panel();
            label5 = new Label();
            button1 = new Button();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label4 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label5);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(25, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(331, 410);
            panel1.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label5.Location = new Point(53, 10);
            label5.Name = "label5";
            label5.Size = new Size(209, 32);
            label5.TabIndex = 20;
            label5.Text = "Tambahkan Buku";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Highlight;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(22, 313);
            button1.Name = "button1";
            button1.Size = new Size(287, 36);
            button1.TabIndex = 19;
            button1.Text = "Tambahkan";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(130, 254);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(84, 24);
            radioButton2.TabIndex = 18;
            radioButton2.TabStop = true;
            radioButton2.Text = "Nonfiksi";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(130, 224);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(58, 24);
            radioButton1.TabIndex = 17;
            radioButton1.TabStop = true;
            radioButton1.Text = "Fiksi";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 224);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 16;
            label4.Text = "Jenis Buku";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(130, 170);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(179, 27);
            textBox3.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 177);
            label3.Name = "label3";
            label3.Size = new Size(47, 20);
            label3.TabIndex = 14;
            label3.Text = "Tahun";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(130, 123);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(179, 27);
            textBox2.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 123);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 12;
            label2.Text = "Penulis";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 79);
            label1.Name = "label1";
            label1.Size = new Size(43, 20);
            label1.TabIndex = 11;
            label1.Text = "Judul";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(130, 76);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(179, 27);
            textBox1.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label6.Location = new Point(528, 9);
            label6.Name = "label6";
            label6.Size = new Size(118, 32);
            label6.TabIndex = 21;
            label6.Text = "List Buku";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(376, 40);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(412, 296);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellClick += dataGridView1_CellClick_1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Highlight;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(376, 342);
            button2.Name = "button2";
            button2.Size = new Size(190, 29);
            button2.TabIndex = 10;
            button2.Text = "Hapus";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.Highlight;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(585, 342);
            button3.Name = "button3";
            button3.Size = new Size(203, 29);
            button3.TabIndex = 12;
            button3.Text = "Edit";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // FormListBuku
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(label6);
            Controls.Add(button2);
            Controls.Add(panel1);
            Name = "FormListBuku";
            Text = "FormListBuku";
            Load += FormListBuku_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Label label5;
        private Button button1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label4;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
        private Label label6;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button3;
    }
}