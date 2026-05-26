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
        // variabel cadangan buat nyimpen id (walaupun sekarang kita udah pake class Session sih)
        public static string idUserAktif = "";

        public Login()
        {
            InitializeComponent();
        }

        // fungsi bawaan form, biarin kosong aja ga ngaruh
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // ini kodingan inti pas tombol "Login" diklik
        private void button1_Click(object sender, EventArgs e)
        {
            // string koneksi buat nyambung ke database sql server lokal
            string connectionString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";

            // buka koneksi pake using biar kalo udah selesai otomatis diputusin sambungannya
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // nembak query ke tabel user. 
                    // pake logika OR biar user bisa bebas milih mau login ngetik email ATAU username
                    string query = "SELECT UserID, Nama, Role FROM [User] WHERE (Email = @loginInput OR Username = @loginInput) AND Password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // ngambil data ketikan dari textbox (username/email & password) buat dimasukin ke parameter
                        cmd.Parameters.AddWithValue("@loginInput", textBox1.Text);
                        cmd.Parameters.AddWithValue("@password", textBox2.Text);

                        // eksekusi pembacaan data
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // ngecek kalo akunnya ketemu dan passwordnya bener
                            if (reader.Read())
                            {
                                // nah ini penting, simpen data orang yang login ke dalem class session
                                // biar id, nama, sama rolenya bisa dipanggil di form manapun tanpa harus query ulang
                                Session.UserID = reader["UserID"].ToString();
                                Session.Nama = reader["Nama"].ToString();
                                Session.Role = reader["Role"].ToString();

                                // misahin halaman tujuan berdasarkan role dia
                                if (Session.Role == "Pustakawan")
                                {
                                    // kalo yang login admin/pustakawan, lempar ke dashboard admin
                                    FormAdmin adminPage = new FormAdmin();
                                    adminPage.Show();
                                }
                                else if (Session.Role == "Member")
                                {
                                    // kalo yang login member biasa, lempar ke dashboard member
                                    FormMember memberPage = new FormMember();
                                    memberPage.Show();
                                }

                                // umpetin jendela login ini dari layar biar ga menuh-menuhin
                                this.Hide();
                            }
                            else
                            {
                                // kalo datanya ga ada di tabel, atau passwordnya salah
                                MessageBox.Show("Email atau Password salah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // jaga-jaga misal sql servernya belom dinyalain atau ngadat
                    MessageBox.Show("Terjadi kesalahan koneksi: " + ex.Message);
                }
            }
        }

        // fungsi pas tulisan "Belum punya akun? Daftar" diklik
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // buka halaman registrasi
            Register regForm = new Register();
            regForm.Show();

            // sembunyikan form login saat sedang membuka form register biar layarnya bersih
            this.Hide();
        }
    }
}