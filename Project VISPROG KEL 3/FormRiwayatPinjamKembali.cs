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
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";

        // Variabel buat nangkep data pas baris tabel diklik
        string idPinjamTerpilih = "";
        string statusTerpilih = "";
        public FormRiwayatPinjamKembali()
        {
            InitializeComponent();
        }

        private void FormRiwayatPinjamKembali_Load(object sender, EventArgs e)
        {
            TampilData("");
            ThemeHelper.FormatTabel(dataGridView1);
        }

        private void TampilData(string kataKunci)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {

                string query = @"SELECT L.LoanID, U.Nama AS 'Nama Peminjam', B.JudulBuku AS 'Judul Buku', 
                                 L.LoanDate AS 'Tanggal Pinjam', L.DueDate AS 'Batas Kembali', L.ReturnDate AS 'Tanggal Balik',
                                 L.StatusPeminjaman AS Status 
                                 FROM Loan L 
                                 INNER JOIN Book B ON L.BookID = B.BookID 
                                 INNER JOIN Member M ON L.MemberID = M.MemberID
                                 INNER JOIN [User] U ON M.UserID = U.UserID ";


                if (!string.IsNullOrEmpty(kataKunci))
                {
                    query += "WHERE U.Nama LIKE @Cari OR B.JudulBuku LIKE @Cari ";
                }

                query += "ORDER BY L.LoanDate DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrEmpty(kataKunci))
                {
                    cmd.Parameters.AddWithValue("@Cari", "%" + kataKunci + "%");
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (idPinjamTerpilih == "")
            {
                MessageBox.Show("Klik dulu data peminjamannya di tabel", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (statusTerpilih == "Dikembalikan")
            {
                MessageBox.Show("Buku Sudah Dikembalikan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dialog = MessageBox.Show("Apakah Sudah Di Kembalikan?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();

                    try
                    {
                        
                        string queryCekDueDate = "SELECT DueDate FROM Loan WHERE LoanID = @LoanID";
                        SqlCommand cmdCek = new SqlCommand(queryCekDueDate, conn, trans);
                        cmdCek.Parameters.AddWithValue("@LoanID", idPinjamTerpilih);

                       
                        DateTime dueDate = Convert.ToDateTime(cmdCek.ExecuteScalar());
                        DateTime hariIni = DateTime.Now;

                        if (hariIni.Date > dueDate.Date)
                        {
                            TimeSpan selisihWaktu = hariIni.Date - dueDate.Date;
                            int telatBerapaHari = (int)selisihWaktu.TotalDays;

                            int tarifDendaPerHari = 2000; // Rp 2.000 per hari
                            int totalDenda = telatBerapaHari * tarifDendaPerHari;

                            MessageBox.Show($"Member terlambat mengembalikan buku selama {telatBerapaHari} hari.\nBatas waktu: {dueDate.ToString("dd MMM yyyy")}\n\nHarap tagih DENDA sebesar:\nRp {totalDenda:N0}", "Peringatan Denda!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        
                        string queryLoan = "UPDATE Loan SET ReturnDate = GETDATE(), StatusPeminjaman = 'Dikembalikan' WHERE LoanID = @LoanID";
                        SqlCommand cmdLoan = new SqlCommand(queryLoan, conn, trans);
                        cmdLoan.Parameters.AddWithValue("@LoanID", idPinjamTerpilih);
                        cmdLoan.ExecuteNonQuery();

                        string queryBook = "UPDATE Book SET Stok = Stok + 1 WHERE BookID = (SELECT BookID FROM Loan WHERE LoanID = @LoanID)";
                        SqlCommand cmdBook = new SqlCommand(queryBook, conn, trans);
                        cmdBook.Parameters.AddWithValue("@LoanID", idPinjamTerpilih);
                        cmdBook.ExecuteNonQuery();

                        // Kalau aman semua, simpan permanen
                        trans.Commit();

                        MessageBox.Show("Buku sukses dikembalikan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        idPinjamTerpilih = "";
                        statusTerpilih = "";
                        TampilData(textBox1.Text);
                    }
                    catch (Exception ex)
                    {
                        // Kalau ada error, batalkan semua perintah!
                        trans.Rollback();
                        MessageBox.Show("Gagal memproses pengembalian: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            TampilData(textBox1.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                idPinjamTerpilih = row.Cells["LoanID"].Value.ToString();
                statusTerpilih = row.Cells["Status"].Value.ToString();
            }
        }


    }
}
