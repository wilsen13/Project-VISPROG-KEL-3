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
            groupBox2 = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            button1 = new Button();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Location = new Point(257, 108);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(352, 271);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Login";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(320, 18);
            label1.Name = "label1";
            label1.Size = new Size(190, 32);
            label1.TabIndex = 2;
            label1.Text = "Selamat Datang!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(286, 61);
            label2.Name = "label2";
            label2.Size = new Size(288, 20);
            label2.TabIndex = 3;
            label2.Text = "Silahkan Melakukan Login Terlebih Dahulu";
            label2.Click += label2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(149, 64);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(155, 27);
            textBox1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 64);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 4;
            label3.Text = "Username";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 115);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 5;
            label4.Text = "Password";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(149, 115);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(155, 27);
            textBox2.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(69, 183);
            button1.Name = "button1";
            button1.Size = new Size(223, 29);
            button1.TabIndex = 7;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Name = "Login";
            Text = "Login";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Label label4;
        private Label label3;
        private TextBox textBox1;
        private Button button1;
    }
}