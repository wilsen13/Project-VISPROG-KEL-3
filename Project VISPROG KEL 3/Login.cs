using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


namespace Project_VISPROG_KEL_3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Query untuk cek kecocokan Username (Email) dan Password
                    string query = "SELECT UserID, Role FROM [User] WHERE (Email = @loginInput OR Nama = @loginInput) AND Password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Mengambil teks dari TextBox kamu (sesuaikan nama TextBox-nya jika berbeda)
                        cmd.Parameters.AddWithValue("@loginInput", textBox1.Text);  
                        cmd.Parameters.AddWithValue("@password", textBox2.Text);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Jika akun ditemukan
                            {
                                // 1. Simpan data ke Class Session
                                Session.UserID = reader["UserID"].ToString();
                                Session.Role = reader["Role"].ToString();

                                if (Session.Role == "Pustakawan")
                                {
                                    // Jika Admin, buka halaman Admin (misal: FormUtama atau Form dashboard admin kamu)
                                    Form1 adminPage = new Form1();
                                    adminPage.Show();
                                }
                                else if (Session.Role == "Member")
                                {
                                    // Jika Member, langsung buka Form Peminjaman yang udah kita desain rapi tadi
                                    FormPeminjaman memberPage = new FormPeminjaman();
                                    memberPage.Show();
                                }

                                // 2. Buka Halaman MDI Utama
                                Form1 mainForm = new Form1();
                                mainForm.Show();

                                // 3. Sembunyikan Form Login ini
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Email atau Password salah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan koneksi: " + ex.Message);
                }


            }
        }
    }
}
