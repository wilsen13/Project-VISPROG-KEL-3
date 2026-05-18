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
    public partial class FormRIwayatPeminjaman : Form
    {
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";
        public FormRIwayatPeminjaman()
        {
            InitializeComponent();
        }

        private void FormRIwayatPeminjaman_Load(object sender, EventArgs e)
        {
            TampilRiwayat();
        }

        private void TampilRiwayat()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    // Ambil semua riwayat transaksi si user yang lagi login
                    // Diurutkan dari transaksi yang paling baru (ORDER BY DESC)
                    string query = "SELECT L.LoanID, B.JudulBuku, L.LoanDate AS 'Tgl Pinjam', L.DueDate AS 'Batas Kembali', L.ReturnDate AS 'Tgl Dikembalikan', " +
                                    "CASE WHEN L.ReturnDate IS NULL THEN 'Dipinjam' ELSE 'Dikembalikan' END AS 'Status' " +
                                    "FROM Loan L " +
                                    "INNER JOIN Book B ON L.BookID = B.BookID " +
                                    "INNER JOIN Member M ON L.MemberID = M.MemberID " +
                                    "WHERE M.UserID = @userID " +
                                    "ORDER BY L.LoanDate DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userID", Session.UserID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Ubah tampilan NULL menjadi teks biar lebih rapi di mata user
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["Tgl Dikembalikan"] == DBNull.Value)
                        {
                            // Kalau ReturnDate kosong, biarkan aja atau biarkan bawaannya
                            // Ini cuma jaga-jaga kalau kamu mau ngolah datanya lebih lanjut
                        }
                    }

                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat riwayat: " + ex.Message);
                }
            }
        }
    }
 }
