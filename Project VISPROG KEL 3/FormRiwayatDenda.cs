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
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";
        public FormRiwayatDenda()
        {
            InitializeComponent();
        }

        private void FormRiwayatDenda_Load(object sender, EventArgs e)
        {
            TampilDataDenda("");
            ThemeHelper.FormatTabel(dataGridView1);
        }

        private void TampilDataDenda(string kataKunci)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {

                string query = @"SELECT L.LoanID, U.Nama AS 'Nama Peminjam', B.JudulBuku AS 'Judul Buku', 
                                 L.DueDate AS 'Batas Kembali', 
                                 ISNULL(CONVERT(varchar, L.ReturnDate, 103), 'Belum Balik') AS 'Tanggal Balik',
                                 DATEDIFF(day, L.DueDate, ISNULL(L.ReturnDate, GETDATE())) AS 'Telat (Hari)',
                                 (DATEDIFF(day, L.DueDate, ISNULL(L.ReturnDate, GETDATE())) * 2000) AS 'Total Denda (Rp)'
                                 FROM Loan L 
                                 INNER JOIN Book B ON L.BookID = B.BookID 
                                 INNER JOIN Member M ON L.MemberID = M.MemberID
                                 INNER JOIN [User] U ON M.UserID = U.UserID 
                                 WHERE DATEDIFF(day, L.DueDate, ISNULL(L.ReturnDate, GETDATE())) > 0 ";

                if (!string.IsNullOrEmpty(kataKunci))
                {
                    query += "AND (U.Nama LIKE @Cari OR B.JudulBuku LIKE @Cari) ";
                }

                query += "ORDER BY [Telat (Hari)] DESC";

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

        private void btnCari_Click(object sender, EventArgs e)
        {
            TampilDataDenda(textBox1.Text);
        }
    }
}
