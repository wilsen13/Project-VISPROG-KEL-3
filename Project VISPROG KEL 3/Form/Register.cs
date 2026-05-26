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
        // string koneksi buat nyambung ke database sql server di laptop kita
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";

        public Register()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // ini fungsi utama pas tombol register atau daftar diklik
        private void button1_Click(object sender, EventArgs e)
        {
            // ngecek dulu nih, jangan sampe ada kotak isian yang masih kosong terlewat
            if (string.IsNullOrWhiteSpace(textBox1.Text) || // Nama
            string.IsNullOrWhiteSpace(textBox2.Text) || // Email
            string.IsNullOrWhiteSpace(textBox3.Text) || // No Telp
            string.IsNullOrWhiteSpace(textBox4.Text) || // Username
            string.IsNullOrWhiteSpace(textBox5.Text) || // Password
            string.IsNullOrWhiteSpace(textBox6.Text))   // Konfirmasi Password
            {
                // kalo ada yang kosong, keluarin peringatan terus stop prosesnya
                MessageBox.Show("Mohon Isi Semua Kolom Terlebih Dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validasi email simpel, pokoknya wajib ada lambang keong (@) sama titik (.)
            if (!textBox2.Text.Contains("@") || !textBox2.Text.Contains("."))
            {
                MessageBox.Show("Email tidak valid! Silahkan Memasukkan Email Yang Benar! (contoh: wilsen@gmail.com).", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validasi nomer hape, mastiin yang diketik beneran angka semua bukan huruf
            if (!long.TryParse(textBox3.Text, out _))
            {
                MessageBox.Show("Nomor Telepon tidak valid! Pastikan hanya memasukkan angka (contoh: 08123456789).", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ngecek panjang nomer hape, masa iya nomer hape kurang dari 10 digit
            if (textBox3.Text.Length < 10)
            {
                MessageBox.Show("Nomor Telepon terlalu pendek! Minimal harus 10 digit (contoh: 081234567890).", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ngecek panjang password biar lumayan aman, minimal 8 karakter lah
            if (textBox5.Text.Length < 8)
            {
                MessageBox.Show("Password terlalu pendek! Password minimal harus 8 karakter.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validasi buat ngecek apakah ketikan password sama konfirmasinya udah bener-bener sama persis
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

                    // nembak query buat ngecek ke database, ini username atau email udah pernah dipake daftar orang lain belom
                    string cekQuery = "SELECT COUNT(*) FROM [User] WHERE Username = @user OR Email = @email";
                    SqlCommand cekCmd = new SqlCommand(cekQuery, conn);
                    cekCmd.Parameters.AddWithValue("@user", textBox4.Text);
                    cekCmd.Parameters.AddWithValue("@email", textBox2.Text);

                    // eksekusi pengecekan
                    int userExist = (int)cekCmd.ExecuteScalar();
                    if (userExist > 0)
                    {
                        // kalo nemu ada yang sama (angkanya lebih dari 0), tolak pendaftarannya
                        MessageBox.Show("Username atau Email sudah terdaftar!", "Gagal");
                        return;
                    }

                    // proses simpan ke database pake transaction
                    // pake transaction nih, biar kalo misal insert ke tabel user sukses tapi ke tabel member gagal, datanya dibatalin otomatis (ga masuk setengah-setengah)
                    SqlTransaction trans = conn.BeginTransaction();
                    try
                    {
                        // bikin id user otomatis dari tulisan USR digabung waktu sekarang sampe ke detik-detiknya
                        string newUserID = "USR-" + DateTime.Now.ToString("ssmmHHddMMyy");

                        // masukin data pendaftaran ke tabel user dulu (sebagai parent)
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

                        // abis itu baru daftarin juga ke tabel member (sebagai child)
                        // otomatis dikasih jatah pinjem maksimal 3 buku dari awal daftar
                        string qMember = "INSERT INTO Member (MemberID, UserID, MaxBooksLimit) " +
                                         "VALUES (@mid, @uid, 3)";
                        SqlCommand cmdMember = new SqlCommand(qMember, conn, trans);

                        // bikin id membernya ngambil potongan huruf dari id user biar seragam
                        cmdMember.Parameters.AddWithValue("@mid", "MEM-" + newUserID.Substring(4));
                        cmdMember.Parameters.AddWithValue("@uid", newUserID);
                        cmdMember.ExecuteNonQuery();

                        // kalo dua-duanya sukses keinput, baru disimpen permanen ke database
                        trans.Commit();
                        MessageBox.Show("Registrasi Berhasil! Silakan Login.", "Sukses");

                        // langsung otomatis buka halaman login biar dia bisa masuk
                        Login log = new Login();
                        log.Show();

                        // tutup form registrasi ini
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        // kalo ada gagal pas proses insert, batalkan semuanya
                        trans.Rollback();
                        MessageBox.Show("Terjadi kesalahan saat menyimpan data: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    // jaga-jaga kalo server sql nya belom nyala atau bermasalah
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

        // fungsi pas tulisan link 'sudah punya akun? login' diklik
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // buka form login
            Login logForm = new Login();
            logForm.Show();

            // sembunyikan form register saat sedang membuka form login biar rapih
            this.Hide();
        }
    }
}