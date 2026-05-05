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
                    string query = "SELECT UserID, Nama, Role FROM [User] WHERE (Email = @loginInput OR Nama = @loginInput) AND Password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // mengambil data dari textbox (username & password)
                        cmd.Parameters.AddWithValue("@loginInput", textBox1.Text);  
                        cmd.Parameters.AddWithValue("@password", textBox2.Text);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // jika akun ditemukan dan cocok
                            {
                                // menyimpan data ke dalam class session
                                Session.UserID = reader["UserID"].ToString();
                                Session.Nama = reader["Nama"].ToString();
                                Session.Role = reader["Role"].ToString();

                                if (Session.Role == "Pustakawan")
                                {
                                    // jika role == "admin" maka masuk ke halaman admin
                                    FormAdmin adminPage = new FormAdmin();
                                    adminPage.Show();
                                }
                                else if (Session.Role == "Member")
                                {
                                    // jika role == "member" makan muncul ke menu member
                                    FormMember memberPage = new FormMember();
                                    memberPage.Show();
                                }


                                // menutup form login ini
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
