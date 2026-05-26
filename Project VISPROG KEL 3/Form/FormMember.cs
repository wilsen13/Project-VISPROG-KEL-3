using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project_VISPROG_KEL_3
{
    public partial class FormMember : Form
    {
        // variabel buat nandain form ditutup karena tombol logout atau disilang manual
        bool isLogOut = false;

        // nyimpen alamat database lokal kita
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";

        public FormMember()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        // fungsi yang otomatis jalan pas member baru aja login dan buka halaman utama ini
        private void FormMember_Load(object sender, EventArgs e)
        {
            // manggil fungsi dari themehelper buat ngerapiin desain tabel
            ThemeHelper.FormatTabel(dataGridView1);

            // nampilin teks sambutan pake nama member yang ditarik dari session login
            label8.Text = "Selamat Datang, " + Session.Nama + "!";

            // narik tanggal hari ini dari sistem laptop terus diformat ke bahasa indonesia
            lblTanggal.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy", new System.Globalization.CultureInfo("id-ID"));

            // bungkus pake try catch biar aplikasi ga langsung force close kalo database ngambek
            try
            {
                // buka jembatan koneksi ke database sql server
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // 1. statistik 1: ngitung total buku yang lagi dipinjem dan belom dibalikin sama member ini
                    string queryDipinjam = @"
                SELECT COUNT(*) 
                FROM Loan l
                INNER JOIN Member m ON l.MemberID = m.MemberID
                WHERE TRIM(m.UserID) = @id AND l.StatusPeminjaman = 'Dipinjam'";

                    using (SqlCommand cmd = new SqlCommand(queryDipinjam, conn))
                    {
                        // masukin id member yang lagi login ke parameter query
                        cmd.Parameters.AddWithValue("@id", Session.UserID.Trim());

                        // tampilin hasil hitungannya ke label
                        lblBukuDipinjam.Text = cmd.ExecuteScalar().ToString();
                    }

                    // 2. statistik 2: ngitung total semua buku yang pernah dia pinjam dari awal daftar
                    string queryRiwayat = @"
                SELECT COUNT(*) 
                FROM Loan l
                INNER JOIN Member m ON l.MemberID = m.MemberID
                WHERE TRIM(m.UserID) = @id";

                    using (SqlCommand cmd = new SqlCommand(queryRiwayat, conn))
                    {
                        // masukin id lagi
                        cmd.Parameters.AddWithValue("@id", Session.UserID.Trim());

                        // eksekusi terus lempar hasilnya ke layar
                        lblTotalRiwayat.Text = cmd.ExecuteScalar().ToString();
                    }


                    // 3. statistik 3: ngecek status akunnya (aktif atau kena suspend)
                    using (SqlConnection connStatus = new SqlConnection(connString))
                    {
                        // nembak langsung ke tabel user buat ngecek kolom statusakun
                        string queryStatus = "SELECT StatusAkun FROM [User] WHERE UserID = @userID";

                        using (SqlCommand cmdStatus = new SqlCommand(queryStatus, connStatus))
                        {
                            cmdStatus.Parameters.AddWithValue("@userID", Session.UserID);
                            connStatus.Open();

                            // narik datanya, kalo misal datanya kosong di database bakal dianggep aktif
                            string statusRealTime = cmdStatus.ExecuteScalar()?.ToString() ?? "Aktif";

                            // tampilin statusnya ke label layar
                            lblStatusAkun.Text = statusRealTime;

                            // ngecek pake logika if buat ngubah warna teksnya
                            if (statusRealTime.Equals("Aktif", StringComparison.OrdinalIgnoreCase))
                            {
                                // kalo aktif kasih warna ijo biar seger
                                lblStatusAkun.ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                // kalo dia kena suspend (atau yang lain), otomatis warnanya merah
                                lblStatusAkun.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    }

                    // 4. ngisi tabel di bawah layar sama daftar buku yang lagi dia pinjem sekarang
                    // ini kita nggabungin 3 tabel sekaligus (loan, book, member) pake inner join biar datanya komplit
                    string queryTabel = @"
                SELECT 
                    b.JudulBuku AS 'Judul Buku', 
                    l.LoanDate AS 'Tanggal Pinjam',
                    l.StatusPeminjaman AS 'Status'
                FROM Loan l
                INNER JOIN Book b ON l.BookID = b.BookID
                INNER JOIN Member m ON l.MemberID = m.MemberID
                WHERE TRIM(m.UserID) = @id AND l.StatusPeminjaman = 'Dipinjam'";

                    using (SqlCommand cmdTabel = new SqlCommand(queryTabel, conn))
                    {
                        cmdTabel.Parameters.AddWithValue("@id", Session.UserID.Trim());

                        // wadah buat nampung hasil gabungan 3 tabel tadi
                        SqlDataAdapter da = new SqlDataAdapter(cmdTabel);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // tempel datanya ke tabel ui
                        dataGridView1.DataSource = dt;

                        // settingan biar kolom tabel otomatis nyesuain lebar layar
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // matiin baris kosong default di paling bawah
                        dataGridView1.AllowUserToAddRows = false;
                    }
                }
            }
            catch (Exception ex)
            {
                // kalo error, munculin pesannya sekalian tulisan nyantai biar gampang di debug
                MessageBox.Show("Penyakitnya disini bro: " + ex.Message);
            }
        }

        // fungsi pas menu pinjam buku diklik
        private void pinjamKembalikanBukuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // bikin objek halaman peminjaman terus ditampilin ke layar
                FormPeminjaman halamanPeminjaman = new FormPeminjaman();
                halamanPeminjaman.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Halaman Peminjaman: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // fungsi pas menu logout diklik sama member
        private void logIutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // munculin popup konfirmasi keluar
            DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin Log Out?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                // tandain kalo form ini ketutup karena tombol logout, bukan disilang
                isLogOut = true;

                // bersihin data session dia dari memori aplikasi
                Session.Clear();

                // panggil ulang form login
                Login loginForm = new Login();
                loginForm.Show();

                // matiin form dashboard member ini
                this.Close();
            }
        }

        // fungsi pas menu riwayat peminjaman diklik
        private void riwayatPeminjamanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ngebuka form riwayat
            FormRIwayatPeminjaman riwayat = new FormRIwayatPeminjaman();
            riwayat.Show();
        }

        // fungsi pas menu cari buku diklik
        private void cariBukuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ngebuka form khusus buat nyari list buku
            FormCariBuku cariBuku = new FormCariBuku();
            cariBuku.Show();
        }

        // fungsi pas menu profil saya diklik
        private void profilSayaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ngebuka form ganti password akun
            FormGantiPassword formGanti = new FormGantiPassword();
            formGanti.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        // fungsi pas logo atau menu refresh diklik
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // panggil ulang fungsi form load biar ngereload datanya
            FormMember_Load(sender, e);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        // ini event otomatis yang jalan pas form beneran ditutup (misal disilang di pojok kanan atas)
        private void FormMember_FormClosed(object sender, FormClosedEventArgs e)
        {
            // ngecek kalo form ini ketutupnya BUKAN karena logout
            if (isLogOut == false)
            {
                // paksa matiin aplikasinya ke akar-akarnya biar ga ada yang nyangkut jalan di background
                Application.Exit();
            }
        }
    }
}