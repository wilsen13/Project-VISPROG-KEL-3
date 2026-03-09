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
            groupBox1 = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            button3 = new Button();
            button4 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 54);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(356, 370);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tambahkan Anggota";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 71);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 1;
            label1.Text = "ID Anggota";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 116);
            label2.Name = "label2";
            label2.Size = new Size(109, 20);
            label2.TabIndex = 2;
            label2.Text = "Nama Lengkap";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 162);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 3;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 208);
            label4.Name = "label4";
            label4.Size = new Size(105, 20);
            label4.TabIndex = 4;
            label4.Text = "Nomor Telpon";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(141, 68);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(198, 27);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(141, 116);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(198, 27);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(141, 162);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(198, 27);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(141, 208);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(198, 27);
            textBox4.TabIndex = 8;
            // 
            // button1
            // 
            button1.Location = new Point(16, 268);
            button1.Name = "button1";
            button1.Size = new Size(309, 43);
            button1.TabIndex = 9;
            button1.Text = "Tambahkan";
            button1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(388, 54);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(380, 370);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "List Anggota";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 26);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(368, 248);
            dataGridView1.TabIndex = 0;
            // 
            // button3
            // 
            button3.Location = new Point(6, 282);
            button3.Name = "button3";
            button3.Size = new Size(186, 29);
            button3.TabIndex = 11;
            button3.Text = "Hapus";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(198, 282);
            button4.Name = "button4";
            button4.Size = new Size(176, 29);
            button4.TabIndex = 11;
            button4.Text = "Edit";
            button4.UseVisualStyleBackColor = true;
            // 
            // KelolaAnggota
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "KelolaAnggota";
            Text = "KelolaAnggota";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button button1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private Button button4;
        private Button button3;
        private DataGridView dataGridView1;
    }
}