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
    public partial class FormRiwayatPinjamKembali : Form
    {
        // nyimpen string koneksi ke database lokal
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";

        // nyiapin variabel kosong buat nangkep data id sama status pas admin ngeklik baris di tabel
        string idPinjamTerpilih = "";
        string statusTerpilih = "";

        public FormRiwayatPinjamKembali()
        {
            InitializeComponent();
        }

        // jalan otomatis pas form riwayat ini kebuka
        private void FormRiwayatPinjamKembali_Load(object sender, EventArgs e)
        {
            // panggil fungsi buat nampilin semua datanya ke tabel
            TampilData("");

            // panggil helper buat ngerapiin desain tabel biar ga kaku
            ThemeHelper.FormatTabel(dataGridView1);
        }

        // fungsi utama buat narik data gabungan riwayat pinjam dari database
        private void TampilData(string kataKunci)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // query lumayan panjang nih, gabungin 4 tabel (loan, book, member, user)
                // biar dapet nama asli peminjam sama judul buku yang lengkap
                string query = @"SELECT L.LoanID, U.Nama AS 'Nama Peminjam', B.JudulBuku AS 'Judul Buku', 
                                 L.LoanDate AS 'Tanggal Pinjam', L.DueDate AS 'Batas Kembali', L.ReturnDate AS 'Tanggal Balik',
                                 L.StatusPeminjaman AS Status 
                                 FROM Loan L 
                                 INNER JOIN Book B ON L.BookID = B.BookID 
                                 INNER JOIN Member M ON L.MemberID = M.MemberID
                                 INNER JOIN [User] U ON M.UserID = U.UserID ";

                // ngecek misal admin ngetik sesuatu di kotak pencarian
                if (!string.IsNullOrEmpty(kataKunci))
                {
                    // tambahin filter buat nyari nyocokin nama orang atau judul bukunya
                    query += "WHERE U.Nama LIKE @Cari OR B.JudulBuku LIKE @Cari ";
                }

                // urutin datanya dari riwayat yang paling baru (tanggal pinjamnya) ditaruh di paling atas
                query += "ORDER BY L.LoanDate DESC";

                SqlCommand cmd = new SqlCommand(query, conn);

                // kalo tadi emang ada kata kuncinya, masukin nilainya ke parameter sql
                if (!string.IsNullOrEmpty(kataKunci))
                {
                    // pake persen biar bisa nyari potongan kata
                    cmd.Parameters.AddWithValue("@Cari", "%" + kataKunci + "%");
                }

                // tampung hasilnya ke wadah datatable
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // tempel ke tabel di layar
                dataGridView1.DataSource = dt;
            }
        }

        // ini kodingan inti pas tombol "tandai dikembalikan" diklik sama admin
        private void button1_Click(object sender, EventArgs e)
        {
            // validasi pertama: mastiin admin udah milih baris datanya di tabel sebelum ngeklik tombol
            if (idPinjamTerpilih == "")
            {
                MessageBox.Show("Klik dulu data peminjamannya di tabel", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // stop prosesnya
            }

            // validasi kedua: mastiin buku yang dipilih belom pernah dikembaliin
            // biar ga ada kejadian buku udah balik tapi distempel balik lagi (nanti stoknya malah nambah error)
            if (statusTerpilih == "Dikembalikan")
            {
                MessageBox.Show("Buku Sudah Dikembalikan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // nanya konfirmasi ke admin udah beneran di cek belom bukunya
            DialogResult dialog = MessageBox.Show("Apakah Sudah Di Kembalikan?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // pake mode transaksi biar kalo gagal di tengah jalan, database tetep aman ga ada yang keubah
                    SqlTransaction trans = conn.BeginTransaction();

                    try
                    {
                        // 1. NGITUNG DENDA
                        // narik data batas waktu kembalinya dulu dari database
                        string queryCekDueDate = "SELECT DueDate FROM Loan WHERE LoanID = @LoanID";
                        SqlCommand cmdCek = new SqlCommand(queryCekDueDate, conn, trans);
                        cmdCek.Parameters.AddWithValue("@LoanID", idPinjamTerpilih);

                        // ubah tipe datanya ke datetime biar bisa dihitung selisihnya pake c#
                        DateTime dueDate = Convert.ToDateTime(cmdCek.ExecuteScalar());
                        DateTime hariIni = DateTime.Now;

                        // ngecek apakah hari ini udah lewat dari batas waktu yang ditentuin
                        if (hariIni.Date > dueDate.Date)
                        {
                            // ngitung telat berapa harinya
                            TimeSpan selisihWaktu = hariIni.Date - dueDate.Date;
                            int telatBerapaHari = (int)selisihWaktu.TotalDays;

                            // setting tarif denda per harinya
                            int tarifDendaPerHari = 2000; // Rp 2.000 per hari
                            int totalDenda = telatBerapaHari * tarifDendaPerHari;

                            // munculin popup peringatan ke admin buat nagih dendanya ke member
                            MessageBox.Show($"Member terlambat mengembalikan buku selama {telatBerapaHari} hari.\nBatas waktu: {dueDate.ToString("dd MMM yyyy")}\n\nHarap tagih DENDA sebesar:\nRp {totalDenda:N0}", "Peringatan Denda!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        // 2. UPDATE STATUS PINJAMAN
                        // catat tanggal hari ini pake getdate() trus ubah statusnya jadi dikembalikan
                        string queryLoan = "UPDATE Loan SET ReturnDate = GETDATE(), StatusPeminjaman = 'Dikembalikan' WHERE LoanID = @LoanID";
                        SqlCommand cmdLoan = new SqlCommand(queryLoan, conn, trans);
                        cmdLoan.Parameters.AddWithValue("@LoanID", idPinjamTerpilih);
                        cmdLoan.ExecuteNonQuery();

                        // 3. NAMBAHIN STOK BUKU
                        // karena bukunya udah balik, stok di tabel book harus ditambahin +1 lagi
                        string queryBook = "UPDATE Book SET Stok = Stok + 1 WHERE BookID = (SELECT BookID FROM Loan WHERE LoanID = @LoanID)";
                        SqlCommand cmdBook = new SqlCommand(queryBook, conn, trans);
                        cmdBook.Parameters.AddWithValue("@LoanID", idPinjamTerpilih);
                        cmdBook.ExecuteNonQuery();

                        // kalau semua proses dari 1 sampe 3 aman lancar jaya, baru disimpen permanen ke database
                        trans.Commit();

                        MessageBox.Show("Buku sukses dikembalikan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // reset variabel pemilihannya biar kosong lagi
                        idPinjamTerpilih = "";
                        statusTerpilih = "";

                        // refresh tabelnya biar data yang barusan dikembaliin ikutan ke-update di layar
                        TampilData(textBox1.Text);
                    }
                    catch (Exception ex)
                    {
                        // kalo ada yang error (misal server down), batalkan semua perintah yang mau diubah (rollback)
                        trans.Rollback();
                        MessageBox.Show("Gagal memproses pengembalian: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // fungsi pas tombol cari diklik
        private void btnCari_Click(object sender, EventArgs e)
        {
            // panggil fungsi nampil data terus kasih isi dari kotak teks pencarian
            TampilData(textBox1.Text);
        }

        // fungsi pas salah satu baris di tabel diklik sama admin
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // mastiin yang diklik beneran baris isi datanya, bukan judul kolom (header)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // tangkep id peminjaman sama statusnya terus disimpen di variabel global yang udah disiapin di atas
                idPinjamTerpilih = row.Cells["LoanID"].Value.ToString();
                statusTerpilih = row.Cells["Status"].Value.ToString();
            }
        }
    }
}