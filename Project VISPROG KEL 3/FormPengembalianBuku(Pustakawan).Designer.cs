namespace Project_VISPROG_KEL_3
{
    partial class FormPengembalianBuku_Pustakawan_
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
            textBox1 = new TextBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            label2 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(29, 59);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(310, 200);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pengembalian";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 57);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 0;
            label1.Text = "Cari ID Anggota";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(159, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(20, 122);
            button1.Name = "button1";
            button1.Size = new Size(264, 29);
            button1.TabIndex = 2;
            button1.Text = "Cari";
            button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(372, 59);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(416, 200);
            dataGridView1.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(178, 374);
            button2.Name = "button2";
            button2.Size = new Size(388, 64);
            button2.TabIndex = 3;
            button2.Text = "Proses Pengembalian";
            button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(372, 280);
            label2.Name = "label2";
            label2.Size = new Size(124, 20);
            label2.TabIndex = 3;
            label2.Text = "Total Denda: Rp...";
            // 
            // FormPengembalianBuku_Pustakawan_
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Name = "FormPengembalianBuku_Pustakawan_";
            Text = "FormPengembalianBuku_Pustakawan_";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private DataGridView dataGridView1;
        private Button button2;
        private Label label2;
    }
}