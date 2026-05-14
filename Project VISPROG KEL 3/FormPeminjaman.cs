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
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";
        public FormPeminjaman()
        {
            InitializeComponent();

            KatalogBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            KatalogBuku.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            KatalogBuku.ReadOnly = true;
            KatalogBuku.AllowUserToAddRows = false;
            try
            {
                

                button1.Visible = false;
                button2.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in FormPeminjaman constructor: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormPeminjaman_Load(object sender, EventArgs e)
        {
            LoadBukuTersedia(); // Panggil function buat tab 1 (tab katalog buku)
            LoadBukuSaya();     // Panggil function buat tab 2 (tab buku saya)
        }

        private void LoadBukuTersedia()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // Hanya memunculkan buku yang statusnya 'Tersedia'
                string query = "SELECT BookID, JudulBuku, Penulis, TipeBuku, TahunTerbit, Status FROM Book WHERE Status = 'Tersedia'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                KatalogBuku.DataSource = dt;
            }
        }

        private void LoadBukuSaya()
        {
            if (bukuSaya != null)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    // Sesuaikan nama kolom dengan tabelmu: LoanDate dan ReturnDate IS NULL
                    string query = "SELECT L.LoanID, B.BookID, B.JudulBuku, L.LoanDate AS 'Tgl Pinjam', L.DueDate AS 'Batas Kembali' " +
                                   "FROM Loan L " +
                                   "INNER JOIN Book B ON L.BookID = B.BookID " +
                                   "INNER JOIN Member M ON L.MemberID = M.MemberID " +
                                   "WHERE M.UserID = @userID AND L.ReturnDate IS NULL";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userID", Session.UserID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    bukuSaya.DataSource = dt;
                }
            }
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            if (KatalogBuku.CurrentRow != null && KatalogBuku.CurrentRow.Index >= 0)
            {
                string idBuku = KatalogBuku.CurrentRow.Cells["BookID"].Value.ToString();
                string judul = KatalogBuku.CurrentRow.Cells["JudulBuku"].Value.ToString();

                DialogResult dr = MessageBox.Show($"Yakin ingin meminjam buku '{judul}'?", "Konfirmasi Pinjam", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        SqlTransaction trans = conn.BeginTransaction(); // Mulai pengamanan transaksi
                        try
                        {
                            // 1. UPDATE TABEL BOOK: Ubah status jadi Dipinjam
                            string updateBook = "UPDATE Book SET Status = 'Dipinjam' WHERE BookID = @bookID";
                            SqlCommand cmdBook = new SqlCommand(updateBook, conn, trans);
                            cmdBook.Parameters.AddWithValue("@bookID", idBuku);
                            cmdBook.ExecuteNonQuery();

                            // 2. INSERT TABEL LOAN: Catat transaksinya
                            string newLoanID = "LN-" + DateTime.Now.ToString("yyMMddHHmmss");
                            string insertLoan = "INSERT INTO Loan (LoanID, BookID, MemberID, LoanDate, DueDate, ReturnDate) " +
                                                "VALUES (@loanID, @bookID, (SELECT MemberID FROM Member WHERE UserID = @userID), GETDATE(), DATEADD(day, 7, GETDATE()), NULL)";

                            SqlCommand cmdLoan = new SqlCommand(insertLoan, conn, trans);
                            cmdLoan.Parameters.AddWithValue("@loanID", newLoanID);
                            cmdLoan.Parameters.AddWithValue("@bookID", idBuku);
                            cmdLoan.Parameters.AddWithValue("@userID", Session.UserID);
                            cmdLoan.ExecuteNonQuery();

                            // Jika kedua proses di atas sukses, simpan permanen (Commit)
                            trans.Commit();
                            MessageBox.Show("Berhasil! Buku telah masuk ke daftar 'Buku Saya'.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh kedua tabel biar datanya update secara real-time!
                            LoadBukuTersedia();
                            LoadBukuSaya();
                            button1.Visible = false;
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback(); // Batalkan semua jika ada error
                            MessageBox.Show("Gagal meminjam buku: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih buku di tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            // mengambil semua data buku yang ada
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT BookID, JudulBuku, Penulis, TipeBuku, TahunTerbit, Status FROM Book WHERE Status = 'Tersedia'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            //linq untuk search buku
            string kataKunci = textBox1.Text.ToLower(); 

            var hasilPencarian = dt.AsEnumerable().Where(buku =>
                buku.Field<string>("JudulBuku").ToLower().Contains(kataKunci) ||
                buku.Field<string>("Penulis").ToLower().Contains(kataKunci)
            );

            // menampilkan hasil pencarian ke dalam katalog buku
            if (hasilPencarian.Any()) 
            {
                KatalogBuku.DataSource = hasilPencarian.CopyToDataTable();
            }
            else
            {
                MessageBox.Show("Buku yang kamu cari tidak ditemukan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KatalogBuku.DataSource = dt; //jika ada buku yang tidak ditemukan maka akan di kembalikan kembali ke daftar awal
            }
        }

        private void KatalogBuku_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bukuSaya.CurrentRow != null && bukuSaya.CurrentRow.Index >= 0)
            {
                string idLoan = bukuSaya.CurrentRow.Cells["LoanID"].Value.ToString();
                string idBuku = bukuSaya.CurrentRow.Cells["BookID"].Value.ToString();

                DialogResult dr = MessageBox.Show("Kembalikan buku ini sekarang?", "Konfirmasi Kembali", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        SqlTransaction trans = conn.BeginTransaction();
                        try
                        {
                            // 1. UPDATE TABEL BOOK: Balikin status jadi Tersedia
                            string updateBook = "UPDATE Book SET Status = 'Tersedia' WHERE BookID = @bookID";
                            SqlCommand cmdBook = new SqlCommand(updateBook, conn, trans);
                            cmdBook.Parameters.AddWithValue("@bookID", idBuku);
                            cmdBook.ExecuteNonQuery();

                            // 2. UPDATE TABEL LOAN: Tandai sudah dikembalikan dan catat tanggalnya
                            // (Nanti logika denda bisa kita sisipkan di sini)
                            string updateLoan = "UPDATE Loan SET ReturnDate = GETDATE() WHERE LoanID = @loanID";
                            SqlCommand cmdLoan = new SqlCommand(updateLoan, conn, trans);
                            cmdLoan.Parameters.AddWithValue("@loanID", idLoan);
                            cmdLoan.ExecuteNonQuery();

                            trans.Commit();
                            MessageBox.Show("Terima kasih telah mengembalikan buku tepat waktu!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh kedua tabel
                            LoadBukuTersedia();
                            LoadBukuSaya();
                            button2.Visible = false;
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            MessageBox.Show("Gagal mengembalikan buku: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void bukuSaya_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                button2.Visible = true; // Tombol pinjam terlihat ketika ada konten yang di klik di cell
            }else if (e.RowIndex == -1)
            {
                button2.Visible = false; // Tombol pinjam tidak terlihat ketika header yang di klik
            }
        }

        

        private void KatalogBuku_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                button1.Visible = true; // Tombol pinjam terlihat ketika ada konten yang di klik di cell
            }else if (e.RowIndex == -1)
            {
                button1.Visible = false; // Tombol pinjam tidak terlihat ketika header yang di klik
            }  
        }
    }
}
    