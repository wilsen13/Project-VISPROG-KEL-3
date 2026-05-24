using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_VISPROG_KEL_3
{
    public partial class FormGantiPassword : Form
    {
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";
        private string idUserTarget = "";
        public FormGantiPassword()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormGantiPassword_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Password baru dan konfirmasi wajib diisi bro!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validasi kecocokan password baru
            if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("Password baru dan konfirmasi tidak cocok! Coba ketik ulang.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string queryUpdate = "UPDATE [User] SET Password = @passBaru WHERE TRIM(UserID) = @id";

                    using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@passBaru", textBox1.Text);
                        cmdUpdate.Parameters.AddWithValue("@id", Session.UserID.Trim());

                        
                        int rowsAffected = cmdUpdate.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            
                            MessageBox.Show("Password sukses diganti!", "Aman", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); 
                        }
                        else
                        {
                            
                            MessageBox.Show($"'{idUserTarget}' tidak ditemukan di database.\n\nSilahkan Coba Kembali!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal, Silahkan coba lagi!: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}


