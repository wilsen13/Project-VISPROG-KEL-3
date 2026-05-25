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
            ThemeHelper.FormatTabel(bukuSaya);
            ThemeHelper.FormatTabel(KatalogBuku);
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

            lblIsiJudul.Visible = false; lblIsiJudul.Visible = false;
            lblIsiPenulis.Visible = false; lblIsiPenulis.Visible = false;
            lblIsiTahun.Visible = false; lblIsiTahun.Visible = false;
            lblIsiTipe.Visible = false; lblIsiTipe.Visible = false;

            picCover.Visible = false;


        }

        private void LoadBukuTersedia()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // Hanya memunculkan buku yang statusnya 'Tersedia'
                string query = "SELECT BookID AS 'ID Buku', JudulBuku AS 'Judul Buku', Penulis, TahunTerbit AS 'Tahun', TipeBuku AS 'Kategori', Stok, Status AS 'Ketersediaan' FROM Book";
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
                    string query = "SELECT L.LoanID, B.BookID, B.JudulBuku, L.LoanDate AS 'Tgl Pinjam', L.DueDate AS 'Batas Kembali'" +
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
                string idBuku = KatalogBuku.CurrentRow.Cells["ID Buku"].Value.ToString();
                string judul = KatalogBuku.CurrentRow.Cells["Judul Buku"].Value.ToString();

                int stokBuku = Convert.ToInt32(KatalogBuku.CurrentRow.Cells["Stok"].Value);
                if (stokBuku <= 0)
                {
                    MessageBox.Show("Mohon Maaf Buku Sedang Tidak Tersedia.", "Stok Kosong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Berhenti di sini, jangan lanjut ke database!
                }

                DialogResult dr = MessageBox.Show($"Yakin ingin meminjam buku '{judul}'?", "Konfirmasi Pinjam", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        SqlTransaction trans = conn.BeginTransaction();
                        try
                        {
                            //update tabel buku
                            string updateBook = @"UPDATE Book 
                                                SET Stok = Stok - 1, 
                                                Status = CASE WHEN (Stok - 1) <= 0 THEN 'Tidak Tersedia' ELSE 'Tersedia' END 
                                                WHERE BookID = @bookID AND Stok > 0"; 
                            SqlCommand cmdBook = new SqlCommand(updateBook, conn, trans);
                            cmdBook.Parameters.AddWithValue("@bookID", idBuku);
                            cmdBook.ExecuteNonQuery();

                            // catat transaksi peminjaman di tabel loan
                            string newLoanID = "LN-" + DateTime.Now.ToString("yyMMddHHmmss");
                            string insertLoan = "INSERT INTO Loan (LoanID, BookID, MemberID, LoanDate, DueDate, ReturnDate, StatusPeminjaman) " +
                                                "VALUES (@loanID, @bookID, (SELECT MemberID FROM Member WHERE UserID = @userID), GETDATE(), DATEADD(day, 7, GETDATE()), NULL, 'Dipinjam')";

                            SqlCommand cmdLoan = new SqlCommand(insertLoan, conn, trans);
                            cmdLoan.Parameters.AddWithValue("@loanID", newLoanID);
                            cmdLoan.Parameters.AddWithValue("@bookID", idBuku);
                            cmdLoan.Parameters.AddWithValue("@userID", Session.UserID);
                            cmdLoan.ExecuteNonQuery();

                            // kalau kedua proses di atas sukses, simpan permanen 
                            trans.Commit();
                            MessageBox.Show("Berhasil! Buku telah masuk ke daftar 'Buku Saya'.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // merefresh kedua tabel biar datanya update secara real-time
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
       
            if (bukuSaya.CurrentRow == null || bukuSaya.CurrentRow.Index < 0)
            {
                MessageBox.Show("Pilih dulu buku di tabel yang mau dikembalikan bro!");
                return;
            }

       
            string idPinjam = bukuSaya.CurrentRow.Cells["LoanID"].Value.ToString();


            using (SqlConnection conn = new SqlConnection(connString))
            {
                
                string query = "UPDATE Loan SET StatusPeminjaman = 'Menunggu Verifikasi' WHERE LoanID = @LoanID AND ReturnDate IS NULL";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LoanID", idPinjam);

                conn.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Pengajuan berhasil! Silahkan bawa buku fisik ke meja Admin untuk verifikasi.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                else
                {
                    MessageBox.Show("Buku ini sudah diajukan atau sudah dikembalikan!");
                }
            }
        }

        private void bukuSaya_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        
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

                if (pictureBox1 != null) pictureBox1.Image = null;

                return;
            }

          
            if (e.RowIndex >= 0)
            {
                button2.Visible = true; 

                DataGridViewRow row = bukuSaya.Rows[e.RowIndex];

                string idBuku = row.Cells["BookID"].Value.ToString();
                label12.Text = row.Cells["JudulBuku"].Value?.ToString() ?? "-";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "SELECT Penulis, TahunTerbit, TipeBuku FROM Book WHERE BookID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idBuku);
                        conn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                label11.Text = dr["Penulis"].ToString();
                                label10.Text = dr["TahunTerbit"].ToString();
                                label9.Text = dr["TipeBuku"].ToString();
                            }
                        }
                    }
                }

          
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

        private void KatalogBuku_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (e.RowIndex == -1)
            {
                label1.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;


                button1.Visible = false;
                picCover.Visible = false;
                lblIsiJudul.Visible = false; lblIsiJudul.Visible = false;
                lblIsiPenulis.Visible = false; lblIsiPenulis.Visible = false;
                lblIsiTahun.Visible = false; lblIsiTahun.Visible = false;
                lblIsiTipe.Visible = false; lblIsiTipe.Visible = false;
                if (picCover != null) picCover.Image = null;

                return; 
            }

        
            if (e.RowIndex >= 0)
            {
                button1.Visible = true; 

                DataGridViewRow row = KatalogBuku.Rows[e.RowIndex];

                picCover.Visible = true;
                lblIsiJudul.Text = row.Cells["Judul Buku"].Value?.ToString() ?? "-";
                lblIsiPenulis.Text = row.Cells["Penulis"].Value?.ToString() ?? "-";
                lblIsiTahun.Text = row.Cells["Tahun"].Value?.ToString() ?? "-";
                lblIsiTipe.Text = row.Cells["Kategori"].Value?.ToString() ?? "-";

                string idBuku = row.Cells["ID Buku"].Value.ToString();
                string folderGambar = Application.StartupPath + @"\Covers\";
                string pathGambar = folderGambar + idBuku + ".jpg";

                label1.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                picCover.Visible = true;
                lblIsiJudul.Visible = true; lblIsiJudul.Visible = true;
                lblIsiPenulis.Visible = true; lblIsiPenulis.Visible = true;
                lblIsiTahun.Visible = true; lblIsiTahun.Visible = true;
                lblIsiTipe.Visible = true; lblIsiTipe.Visible = true;

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
    }
}
    