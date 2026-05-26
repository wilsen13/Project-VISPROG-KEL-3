using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_VISPROG_KEL_3
{
    public partial class FormPeminjaman : Form
    {
        // nyimpen alamat database sql server kita
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";

        public FormPeminjaman()
        {
            InitializeComponent();

            // settingan awal tabel katalog biar kolomnya menuhin layar dan rapi
            KatalogBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // biar kalo diklik langsung keblok satu baris full, bukan per sel
            KatalogBuku.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // dikunci biar user ga bisa iseng ngetik/ngubah data langsung di tabel
            KatalogBuku.ReadOnly = true;

            // ngilangin baris kosong sisa di paling bawah tabel
            KatalogBuku.AllowUserToAddRows = false;

            try
            {
                // ngumpetin tombol pinjam sama kembali pas awal buka
                button1.Visible = false;
                button2.Visible = false;
            }
            catch (Exception ex)
            {
                // kalo misal pas setting awal ini ada yang crash, keluarin errornya
                MessageBox.Show($"Error in FormPeminjaman constructor: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // fungsi yang otomatis jalan pas form peminjaman kebuka
        private void FormPeminjaman_Load(object sender, EventArgs e)
        {
            LoadBukuTersedia(); // panggil data buku yang statusnya tersedia buat tab 1
            LoadBukuSaya();     // panggil data buku yang lagi dipinjem user ini buat tab 2

            // panggil helper buat warnain tabel biar estetik
            ThemeHelper.FormatTabel(bukuSaya);
            ThemeHelper.FormatTabel(KatalogBuku);

            // ngumpetin semua label judul sama isi detail buku di bawah layar
            // biar tampilannya ga keramean pas belom ada buku yang diklik
            label16.Visible = false;
            label15.Visible = false;
            label14.Visible = false;
            label13.Visible = false;

            pictureBox1.Visible = false;
            label12.Visible = false;
            label11.Visible = false;
            label10.Visible = false;
            label9.Visible = false;

            label1.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;

            lblIsiJudul.Visible = false;
            lblIsiPenulis.Visible = false;
            lblIsiTahun.Visible = false;
            lblIsiTipe.Visible = false;

            picCover.Visible = false;
        }

        // fungsi buat narik data list buku buat dipinjem
        private void LoadBukuTersedia()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // narik data buku pake alias bahasa indonesia biar rapi di layar
                string query = "SELECT BookID AS 'ID Buku', JudulBuku AS 'Judul Buku', Penulis, TahunTerbit AS 'Tahun', TipeBuku AS 'Kategori', Stok, Status AS 'Ketersediaan' FROM Book";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // tempel hasilnya ke tabel katalog buku
                KatalogBuku.DataSource = dt;
            }
        }

        // fungsi buat narik data buku yang lagi dipinjem sama member yang login
        private void LoadBukuSaya()
        {
            if (bukuSaya != null)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    // gabungin 3 tabel sekaligus (loan, book, member) biar bisa narik nama buku sama tanggalnya
                    // pake syarat returndate is null buat nampilin buku yang belom dibalikin aja
                    string query = "SELECT L.LoanID, B.BookID, B.JudulBuku, L.LoanDate AS 'Tgl Pinjam', L.DueDate AS 'Batas Kembali'" +
                                   "FROM Loan L " +
                                   "INNER JOIN Book B ON L.BookID = B.BookID " +
                                   "INNER JOIN Member M ON L.MemberID = M.MemberID " +
                                   "WHERE M.UserID = @userID AND L.ReturnDate IS NULL";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    // nembak userid orang yang lagi pake aplikasi ini
                    cmd.Parameters.AddWithValue("@userID", Session.UserID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // masukin data pinjamannya ke tabel buku saya
                    bukuSaya.DataSource = dt;
                }
            }
        }

        // ini kodingan pas tombol "pinjam buku" diklik
        private void button1_Click(object sender, EventArgs e)
        {
            // ngecek beneran ada buku yang lagi dipilih apa ngga di tabel
            if (KatalogBuku.CurrentRow != null && KatalogBuku.CurrentRow.Index >= 0)
            {
                string idBuku = KatalogBuku.CurrentRow.Cells["ID Buku"].Value.ToString();
                string judul = KatalogBuku.CurrentRow.Cells["Judul Buku"].Value.ToString();

                // 1. cek stok bukunya dulu, sisa ga nih?
                int stokBuku = Convert.ToInt32(KatalogBuku.CurrentRow.Cells["Stok"].Value);
                if (stokBuku <= 0)
                {
                    MessageBox.Show("Mohon Maaf Buku Sedang Tidak Tersedia.", "Stok Kosong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. cek status akun membernya secara live ke database
                using (SqlConnection connCek = new SqlConnection(connString))
                {
                    // nyari kolom statusakun di tabel user
                    string queryCek = "SELECT StatusAkun FROM [User] WHERE UserID = @userID";
                    SqlCommand cmdCek = new SqlCommand(queryCek, connCek);
                    cmdCek.Parameters.AddWithValue("@userID", Session.UserID);

                    connCek.Open();
                    object result = cmdCek.ExecuteScalar();
                    string statusMember = result != null ? result.ToString() : "Aktif";

                    // kalo statusnya di database ternyata suspend, tolak mentah-mentah
                    if (statusMember.Equals("Suspend", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Akun Anda sedang di-SUSPEND! Anda tidak diizinkan untuk meminjam buku. Silahkan hubungi Admin.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return; // berhentiin proses, jangan kasih minjem
                    }
                }

                // kalo lolos stok dan status, baru tanyain konfirmasi minjem
                DialogResult dr = MessageBox.Show($"Yakin ingin meminjam buku '{judul}'?", "Konfirmasi Pinjam", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();

                        // pake mode transaksi biar data tabel book sama loan keupdatenya barengan
                        SqlTransaction trans = conn.BeginTransaction();
                        try
                        {
                            // potong stok buku -1, sekalian ganti statusnya kalo misal stoknya nyentuh 0
                            string updateBook = @"UPDATE Book 
                                                SET Stok = Stok - 1, 
                                                Status = CASE WHEN (Stok - 1) <= 0 THEN 'Tidak Tersedia' ELSE 'Tersedia' END 
                                                WHERE BookID = @bookID AND Stok > 0";
                            SqlCommand cmdBook = new SqlCommand(updateBook, conn, trans);
                            cmdBook.Parameters.AddWithValue("@bookID", idBuku);
                            cmdBook.ExecuteNonQuery();

                            // abis itu catat sejarah pinjamnya di tabel loan
                            // bikin id pinjam unik pake prefix LN- sama waktu saat ini
                            string newLoanID = "LN-" + DateTime.Now.ToString("yyMMddHHmmss");
                            string insertLoan = "INSERT INTO Loan (LoanID, BookID, MemberID, LoanDate, DueDate, ReturnDate, StatusPeminjaman) " +
                                                "VALUES (@loanID, @bookID, (SELECT MemberID FROM Member WHERE UserID = @userID), GETDATE(), DATEADD(day, 7, GETDATE()), NULL, 'Dipinjam')";

                            SqlCommand cmdLoan = new SqlCommand(insertLoan, conn, trans);
                            cmdLoan.Parameters.AddWithValue("@loanID", newLoanID);
                            cmdLoan.Parameters.AddWithValue("@bookID", idBuku);
                            cmdLoan.Parameters.AddWithValue("@userID", Session.UserID);
                            cmdLoan.ExecuteNonQuery();

                            // kalo ga ada yang error, simpen kedua perubahan di atas secara permanen
                            trans.Commit();
                            MessageBox.Show("Berhasil! Buku telah masuk ke daftar 'Buku Saya'.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // manggil ulang fungsi load tabel biar sisa stok sama daftar bukunya keupdate live
                            LoadBukuTersedia();
                            LoadBukuSaya();

                            // umpetin lagi tombol pinjamnya
                            button1.Visible = false;
                        }
                        catch (Exception ex)
                        {
                            // kalo misal di tengah jalan error, batalkan semua proses biar stok ga ngurang sia-sia
                            trans.Rollback();
                            MessageBox.Show("Gagal meminjam buku: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                // kalo dia ngeklik pinjam tapi belom milih buku di tabel
                MessageBox.Show("Pilih buku di tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // fungsi cadangan buat search buku (di kodingan bawah lu bikin lagi di button4)
        private void btnCari_Click(object sender, EventArgs e)
        {
            // ngambil tulisan dari kotak pencarian
            string kataKunci = textBox1.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                // bikin query search yang alias kolomnya persis sama tabel awal biar ga error pas diklik
                string query = @"SELECT BookID AS 'ID Buku', 
                                JudulBuku AS 'Judul Buku', 
                                Penulis, 
                                TahunTerbit AS 'Tahun', 
                                TipeBuku AS 'Kategori', 
                                Stok, 
                                Status AS 'Ketersediaan' 
                         FROM Book 
                         WHERE Status = 'Tersedia' 
                         AND (JudulBuku LIKE @search OR Penulis LIKE @search)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // pake persen biar bisa nyari kata ngacak di tengah kalimat
                    cmd.Parameters.AddWithValue("@search", "%" + kataKunci + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // kalo nemu hasilnya
                    if (dt.Rows.Count > 0)
                    {
                        KatalogBuku.DataSource = dt;
                    }
                    else
                    {
                        // kalo ga nemu, munculin notif terus tampilin ulang semua bukunya
                        MessageBox.Show("Buku yang kamu cari tidak ditemukan bro!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBukuTersedia();
                    }
                }
            }
        }

        private void KatalogBuku_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // fungsi pas tombol "kembalikan buku" diklik di tab buku saya
        private void button2_Click(object sender, EventArgs e)
        {
            // mastiin user udah ngeklik buku yang mau dibalikin di tabel buku saya
            if (bukuSaya.CurrentRow == null || bukuSaya.CurrentRow.Index < 0)
            {
                MessageBox.Show("Pilih dulu buku di tabel yang mau dikembalikan bro!");
                return;
            }

            // tangkep id peminjamannya
            string idPinjam = bukuSaya.CurrentRow.Cells["LoanID"].Value.ToString();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                // update statusnya dari dipinjam jadi nunggu verifikasi (nanti admin yang ngeklik beres)
                string query = "UPDATE Loan SET StatusPeminjaman = 'Menunggu Verifikasi' WHERE LoanID = @LoanID AND ReturnDate IS NULL";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LoanID", idPinjam);

                conn.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    // notif kalo pengajuannya berhasil
                    MessageBox.Show("Pengajuan berhasil! Silahkan bawa buku fisik ke meja Admin untuk verifikasi.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // ini buat jaga-jaga kalo bukunya ternyata udah proses pengembalian
                    MessageBox.Show("Buku ini sudah diajukan atau sudah dikembalikan!");
                }
            }
        }

        // fungsi pas ngeklik baris di tabel tab "buku saya"
        private void bukuSaya_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // kalo yang diklik itu bagian atas tabel (header), kita reset umpetin semua infonya
            if (e.RowIndex == -1)
            {
                button2.Visible = false;
                label16.Visible = false;
                label15.Visible = false;
                label14.Visible = false;
                label13.Visible = false;

                pictureBox1.Visible = false;
                label12.Visible = false;
                label11.Visible = false;
                label10.Visible = false;
                label9.Visible = false;

                // buang gambar yang nyangkut
                if (pictureBox1 != null) pictureBox1.Image = null;

                return;
            }

            // nah kalo yang diklik itu beneran baris data pinjamannya
            if (e.RowIndex >= 0)
            {
                // munculin tombol kembalikan
                button2.Visible = true;

                DataGridViewRow row = bukuSaya.Rows[e.RowIndex];

                string idBuku = row.Cells["BookID"].Value.ToString();
                label12.Text = row.Cells["JudulBuku"].Value?.ToString() ?? "-";

                // nembak database lagi buat nyari info tambahan (penulis, tahun, dll) karena di tabel buku saya ga ada
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "SELECT Penulis, TahunTerbit, TipeBuku FROM Book WHERE BookID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idBuku);
                        conn.Open();
                        // pake sql data reader buat ngebaca per kolom
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                // lempar ke label di layar bawah
                                label11.Text = dr["Penulis"].ToString();
                                label10.Text = dr["TahunTerbit"].ToString();
                                label9.Text = dr["TipeBuku"].ToString();
                            }
                        }
                    }
                }

                // nyari gambar cover bukunya dari id 
                string folderGambar = Application.StartupPath + @"\Covers\";
                string pathGambar = folderGambar + idBuku + ".jpg";

                try
                {
                    if (System.IO.File.Exists(pathGambar))
                    {
                        pictureBox1.Image = Image.FromFile(pathGambar);
                    }
                    else
                    {
                        pictureBox1.Image = null;
                    }
                }
                catch (Exception)
                {
                    pictureBox1.Image = null;
                }

                // karena bukunya udah diklik, kita munculin semua label detailnya biar bisa dibaca
                label16.Visible = true;
                label15.Visible = true;
                label14.Visible = true;
                label13.Visible = true;
                pictureBox1.Visible = true;
                label12.Visible = true;
                label11.Visible = true;
                label10.Visible = true;
                label9.Visible = true;
            }
        }

        // fungsi pas ngeklik baris di tabel tab "katalog buku"
        private void KatalogBuku_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // kalo yang diklik area header (judul kolom)
            if (e.RowIndex == -1)
            {
                // reset dan umpetin lagi semua datanya kayak baru buka form
                label1.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;

                button1.Visible = false;
                picCover.Visible = false;

                lblIsiJudul.Visible = false;
                lblIsiPenulis.Visible = false;
                lblIsiTahun.Visible = false;
                lblIsiTipe.Visible = false;

                if (picCover != null) picCover.Image = null;

                return;
            }

            // kalo yang diklik beneran baris bukunya
            if (e.RowIndex >= 0)
            {
                // munculin tombol pinjam buku
                button1.Visible = true;

                DataGridViewRow row = KatalogBuku.Rows[e.RowIndex];

                // narik data dari sel tabel ke label preview di bawah
                picCover.Visible = true;
                lblIsiJudul.Text = row.Cells["Judul Buku"].Value?.ToString() ?? "-";
                lblIsiPenulis.Text = row.Cells["Penulis"].Value?.ToString() ?? "-";
                lblIsiTahun.Text = row.Cells["Tahun"].Value?.ToString() ?? "-";
                lblIsiTipe.Text = row.Cells["Kategori"].Value?.ToString() ?? "-";

                // nyari lokasi cover gambarnya
                string idBuku = row.Cells["ID Buku"].Value.ToString();
                string folderGambar = Application.StartupPath + @"\Covers\";
                string pathGambar = folderGambar + idBuku + ".jpg";

                // munculin semua label teksnya biar nampil cakep
                label1.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                picCover.Visible = true;
                lblIsiJudul.Visible = true;
                lblIsiPenulis.Visible = true;
                lblIsiTahun.Visible = true;
                lblIsiTipe.Visible = true;

                // proses nampilin gambar kayak biasa, di try catch biar ga crash kalo file rusak
                try
                {
                    if (System.IO.File.Exists(pathGambar))
                    {
                        picCover.Image = Image.FromFile(pathGambar);
                    }
                    else
                    {
                        picCover.Image = null;
                    }
                }
                catch (Exception)
                {
                    picCover.Image = null;
                }
            }
        }

        // ini fungsi tombol cari buku (search yang beneran dipake di aplikasi lu)
        private void button4_Click(object sender, EventArgs e)
        {
            // ambil ketikan dari textbox search
            string kataKunci = textBox1.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                // query buat nyari buku yang statusnya cuma tersedia, trus disaring pake like
                string query = @"SELECT BookID AS 'ID Buku', 
                                JudulBuku AS 'Judul Buku', 
                                Penulis, 
                                TahunTerbit AS 'Tahun', 
                                TipeBuku AS 'Kategori', 
                                Stok, 
                                Status AS 'Ketersediaan' 
                         FROM Book 
                         WHERE Status = 'Tersedia' 
                         AND (JudulBuku LIKE @search OR Penulis LIKE @search)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // masukin persen biar nyarinya bisa potong-potongan kata
                    cmd.Parameters.AddWithValue("@search", "%" + kataKunci + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // kalo ada hasil bukunya
                    if (dt.Rows.Count > 0)
                    {
                        // timpakan datanya ke katalog buku
                        KatalogBuku.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Buku yang kamu cari tidak ditemukan bro!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // reset list balik jadi semua buku lagi
                        LoadBukuTersedia();
                    }
                }
            }
        }
    }
}