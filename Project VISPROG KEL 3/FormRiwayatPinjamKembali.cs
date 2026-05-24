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
                MessageBox.Show("Klik dulu data peminjamannya di tabe");
                return;
            }

            if (statusTerpilih == "Dikembalikan")
            {
                MessageBox.Show("Buku Sudah Dikembalikan.");
                return;
            }

            DialogResult dialog = MessageBox.Show("Apakah Sudah Di Kembalikan?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {

                    string query = "UPDATE Loan SET ReturnDate = GETDATE(), StatusPeminjaman = 'Dikembalikan' WHERE LoanID = @LoanID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@LoanID", idPinjamTerpilih);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Buku sukses dikembalikan!");
                idPinjamTerpilih = ""; 
                statusTerpilih = "";
                TampilData(textBox1.Text); 
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
