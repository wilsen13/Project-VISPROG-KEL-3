namespace Project_VISPROG_KEL_3
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1 = new Panel();
            button1 = new Button();
            textBox2 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(68, 133);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(218, 201);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Highlight;
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(356, 450);
            panel2.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(panel1);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(356, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(444, 450);
            panel3.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(26, 118);
            panel1.Name = "panel1";
            panel1.Size = new Size(390, 227);
            panel1.TabIndex = 8;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Highlight;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(86, 162);
            button1.Name = "button1";
            button1.Size = new Size(227, 39);
            button1.TabIndex = 12;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Segoe UI", 10F);
            textBox2.Location = new Point(165, 102);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(182, 30);
            textBox2.TabIndex = 11;
            textBox2.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(64, 106);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 10;
            label4.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(59, 49);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 9;
            label3.Text = "Username";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 10F);
            textBox1.Location = new Point(165, 45);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(182, 30);
            textBox1.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 0);
            label2.Name = "label2";
            label2.Size = new Size(288, 20);
            label2.TabIndex = 7;
            label2.Text = "Silahkan Melakukan Login Terlebih Dahulu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(108, 68);
            label1.Name = "label1";
            label1.Size = new Size(231, 37);
            label1.TabIndex = 6;
            label1.Text = "Selamat Datang!";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 244, 246);
            ClientSize = new Size(800, 450);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Name = "Login";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel1;
        private Button button1;
        private TextBox textBox2;
        private Label label4;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
    }
}