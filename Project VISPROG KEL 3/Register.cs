using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace Project_VISPROG_KEL_3
{
    public partial class Register : Form
    {
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";
        public Register()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // logika kode jika input kosong
        if (string.IsNullOrWhiteSpace(textBox1.Text) || // Nama
        string.IsNullOrWhiteSpace(textBox2.Text) || // Email
        string.IsNullOrWhiteSpace(textBox3.Text) || // No Telp
        string.IsNullOrWhiteSpace(textBox4.Text) || // Username
        string.IsNullOrWhiteSpace(textBox5.Text) || // Password
        string.IsNullOrWhiteSpace(textBox6.Text))   // Konfirmasi Password
    {
                MessageBox.Show("Mohon Isi Semua Kolom Terlebih Dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // memunculkan pop up peringatan
            }

            //validasi email sederhana: harus mengandung '@' dan '.'
            if (!textBox2.Text.Contains("@") || !textBox2.Text.Contains("."))
            {
                MessageBox.Show("Email tidak valid! Silahkan Memasukkan Email Yang Benar! (contoh: wilsen@gmail.com).", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //validasi nomor telpon hanya angka dan minimal 10 digit
            if (!long.TryParse(textBox3.Text, out _))
            {
                MessageBox.Show("Nomor Telepon tidak valid! Pastikan hanya memasukkan angka (contoh: 08123456789).", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox3.Text.Length < 10)// validasi nomor telpon minimal 10 digit
            {
                MessageBox.Show("Nomor Telepon terlalu pendek! Minimal harus 10 digit (contoh: 081234567890).", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop proses
            }

            if (textBox5.Text.Length < 8)
            {
                MessageBox.Show("Password terlalu pendek! Password minimal harus 8 karakter.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop proses
            }

            // validasi untuk mengecek apakah password dan confirm password cocok
            if (textBox5.Text != textBox6.Text)
            {
                MessageBox.Show("Password dan Konfirmasi Password tidak cocok!", "Gagal");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // kode untuk cek apakah username atau email sudah terdaftar
                    string cekQuery = "SELECT COUNT(*) FROM [User] WHERE Username = @user OR Email = @email";
                    SqlCommand cekCmd = new SqlCommand(cekQuery, conn);
                    cekCmd.Parameters.AddWithValue("@user", textBox4.Text);
                    cekCmd.Parameters.AddWithValue("@email", textBox2.Text);

                    int userExist = (int)cekCmd.ExecuteScalar();
                    if (userExist > 0)
                    {
                        MessageBox.Show("Username atau Email sudah terdaftar!", "Gagal");
                        return;
                    }

                    // 4. Proses Simpan ke Database (Transaction)
                    // Kita gunakan Transaction agar jika salah satu gagal, semua dibatalkan
                    SqlTransaction trans = conn.BeginTransaction();
                    try
                    {
                        string newUserID = "USR-" + DateTime.Now.ToString("ssmmHHddMMyy");

                        // Insert ke tabel [User]
                        string qUser = "INSERT INTO [User] (UserID, Nama, Email, PhoneNumber, Password, Role, Username) " +
                                       "VALUES (@uid, @nama, @email, @phone, @pass, 'Member', @uname)";
                        SqlCommand cmdUser = new SqlCommand(qUser, conn, trans);
                        cmdUser.Parameters.AddWithValue("@uid", newUserID);
                        cmdUser.Parameters.AddWithValue("@nama", textBox1.Text);
                        cmdUser.Parameters.AddWithValue("@email", textBox2.Text);
                        cmdUser.Parameters.AddWithValue("@phone", textBox3.Text);
                        cmdUser.Parameters.AddWithValue("@pass", textBox5.Text);
                        cmdUser.Parameters.AddWithValue("@uname", textBox4.Text);
                        cmdUser.ExecuteNonQuery();

                        // Insert ke tabel Member
                        string qMember = "INSERT INTO Member (MemberID, UserID, MaxBooksLimit) " +
                                         "VALUES (@mid, @uid, 3)";
                        SqlCommand cmdMember = new SqlCommand(qMember, conn, trans);
                        cmdMember.Parameters.AddWithValue("@mid", "MEM-" + newUserID.Substring(4));
                        cmdMember.Parameters.AddWithValue("@uid", newUserID);
                        cmdMember.ExecuteNonQuery();

                        trans.Commit();
                        MessageBox.Show("Registrasi Berhasil! Silakan Login.", "Sukses");

                        // Balik ke Form Login
                        Login log = new Login();
                        log.Show();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Terjadi kesalahan saat menyimpan data: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Koneksi gagal: " + ex.Message);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login logForm = new Login();
            logForm.Show();
            this.Hide(); //sembunyikan form register saat sedang membuka form login
        }
    }
}
