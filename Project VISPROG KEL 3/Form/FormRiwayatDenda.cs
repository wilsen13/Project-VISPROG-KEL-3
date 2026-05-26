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

namespace Project_VISPROG_KEL_3
{
    public partial class FormRiwayatDenda : Form
    {
        // string koneksi buat nyambung ke database sql server lokal
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";

        public FormRiwayatDenda()
        {
            InitializeComponent();
        }

        // otomatis jalan pas halaman riwayat denda ini dibuka
        private void FormRiwayatDenda_Load(object sender, EventArgs e)
        {
            // panggil fungsi buat nampilin semua data denda (kosongin parameternya biar tampil semua)
            TampilDataDenda("");

            // rapiin desain tabel pake helper
            ThemeHelper.FormatTabel(dataGridView1);
        }

        // fungsi utama buat narik data siapa aja yang telat balikin buku
        private void TampilDataDenda(string kataKunci)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // query panjang nih, kita gabungin 4 tabel sekaligus (loan, book, member, user)
                // tujuannya biar dapet nama peminjam sama judul buku yang lengkap
                string query = @"SELECT L.LoanID, U.Nama AS 'Nama Peminjam', B.JudulBuku AS 'Judul Buku', 
                                 L.DueDate AS 'Batas Kembali', 
                                 
                                 -- pake isnull, kalo returndate nya kosong (belom dibalikin), ganti teksnya jadi 'Belum Balik'
                                 ISNULL(CONVERT(varchar, L.ReturnDate, 103), 'Belum Balik') AS 'Tanggal Balik',
                                 
                                 -- ngitung selisih hari dari batas waktu ke tanggal dikembaliin (atau ke hari ini kalo belom balik)
                                 DATEDIFF(day, L.DueDate, ISNULL(L.ReturnDate, GETDATE())) AS 'Telat (Hari)',
                                 
                                 -- denda per harinya 2000 perak, jadi selisih hari telat tadi langsung dikali 2000
                                 (DATEDIFF(day, L.DueDate, ISNULL(L.ReturnDate, GETDATE())) * 2000) AS 'Total Denda (Rp)'
                                 
                                 FROM Loan L 
                                 INNER JOIN Book B ON L.BookID = B.BookID 
                                 INNER JOIN Member M ON L.MemberID = M.MemberID
                                 INNER JOIN [User] U ON M.UserID = U.UserID 
                                 
                                 -- filter paling penting: cuma nampilin yang telatnya lebih dari 0 hari aja
                                 WHERE DATEDIFF(day, L.DueDate, ISNULL(L.ReturnDate, GETDATE())) > 0 ";

                // ngecek kalo admin ngetik sesuatu di kotak pencarian
                if (!string.IsNullOrEmpty(kataKunci))
                {
                    // tambahin filter buat nyari berdasarkan nama orang atau judul bukunya
                    query += "AND (U.Nama LIKE @Cari OR B.JudulBuku LIKE @Cari) ";
                }

                // urutin datanya dari yang telatnya paling lama ditaruh di paling atas
                query += "ORDER BY [Telat (Hari)] DESC";

                SqlCommand cmd = new SqlCommand(query, conn);

                // kalo tadi emang ada kata kuncinya, masukin ke parameter sql
                if (!string.IsNullOrEmpty(kataKunci))
                {
                    cmd.Parameters.AddWithValue("@Cari", "%" + kataKunci + "%");
                }

                // eksekusi dan tampung hasilnya ke datatable
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // tempel ke layar
                dataGridView1.DataSource = dt;
            }
        }

        // fungsi pas tombol cari denda diklik
        private void btnCari_Click(object sender, EventArgs e)
        {
            // jalanin ulang fungsi tampil data, tapi kali ini bawa teks dari kotak pencarian
            TampilDataDenda(textBox1.Text);
        }
    }
}