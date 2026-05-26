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
        // naruh lokasi database lokal kita biar gampang dipanggil
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";

        public FormRIwayatPeminjaman()
        {
            InitializeComponent();
        }

        // otomatis jalan pas form riwayat peminjaman ini dibuka sama user
        private void FormRIwayatPeminjaman_Load(object sender, EventArgs e)
        {
            // langsung panggil list riwayatnya
            TampilRiwayat();

            // rapiin desain tabel biar ga kaku
            ThemeHelper.FormatTabel(dataGridView1);
        }

        // fungsi utama buat narik data history peminjaman dari database
        private void TampilRiwayat()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    // gabungin tabel loan, book, sama member
                    // pake fungsi CASE di sql biar gampang: kalo returndate kosong (null) berarti statusnya 'dipinjam', kalo ada isinya berarti 'dikembalikan'
                    string query = "SELECT L.LoanID, B.JudulBuku, L.LoanDate AS 'Tgl Pinjam', L.DueDate AS 'Batas Kembali', L.ReturnDate AS 'Tgl Dikembalikan', " +
                                    "CASE WHEN L.ReturnDate IS NULL THEN 'Dipinjam' ELSE 'Dikembalikan' END AS 'Status' " +
                                    "FROM Loan L " +
                                    "INNER JOIN Book B ON L.BookID = B.BookID " +
                                    "INNER JOIN Member M ON L.MemberID = M.MemberID " +
                                    "WHERE M.UserID = @userID " +
                                    "ORDER BY L.LoanDate DESC"; // urutin dari tanggal pinjam paling baru

                    SqlCommand cmd = new SqlCommand(query, conn);

                    // nembak parameter pake session userid biar yang tampil cuma history punya user yang lagi login
                    cmd.Parameters.AddWithValue("@userID", Session.UserID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // ini kodingan lama buat ngecek null secara manual di c#, udah diganti pake CASE di query sql atas biar lebih efisien makanya dimatiin
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    if (row["Tgl Dikembalikan"] == DBNull.Value)
                    //    {

                    //    }
                    //}

                    // tempel datanya ke tabel
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    // jaga-jaga kalo server ngadat
                    MessageBox.Show("Gagal memuat riwayat: " + ex.Message);
                }
            }
        }

        // fungsi pas user ngeklik salah satu baris di tabel history
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // kalo user ngeklik judul tabel yang di atas (header)
            if (e.RowIndex == -1)
            {
                // sembunyiin lagi semua detail label sama gambar kayak tampilan awal
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;

                picCover.Visible = false;
                lblIsiJudul.Visible = false;
                lblIsiPenulis.Visible = false;
                lblIsiTahun.Visible = false;
                lblIsiTipe.Visible = false;

                // buang gambar dari memori layar
                if (picCover != null) picCover.Image = null;

                // stop proses
                return;
            }


            // kalo user beneran ngeklik baris datanya
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // narik id loan sama nampilin judul ke detail bawah layar
                string idLoan = row.Cells["LoanID"].Value.ToString();
                lblIsiJudul.Text = row.Cells["JudulBuku"].Value?.ToString() ?? "-";

                // nyiapin variabel kosong buat nyimpen id buku (nanti dipake buat nyari file gambar)
                string idBuku = "";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    // nembak query lagi ke database buat nyari info penulis, tahun, dll soalnya di tabel history tadi cuma ada judul
                    string query = @"SELECT B.BookID, B.Penulis, B.TahunTerbit, B.TipeBuku 
                                     FROM Book B 
                                     INNER JOIN Loan L ON B.BookID = L.BookID 
                                     WHERE L.LoanID = @loanID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@loanID", idLoan);
                        conn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                // pas dapet, langsung lempar ke label-label detail
                                lblIsiPenulis.Text = dr["Penulis"].ToString();
                                lblIsiTahun.Text = dr["TahunTerbit"].ToString();
                                lblIsiTipe.Text = dr["TipeBuku"].ToString();

                                // nah ini id bukunya disimpen buat nyari cover
                                idBuku = dr["BookID"].ToString();
                            }
                        }
                    }
                }


                // nentuin alamat folder tempat kita nyimpen gambar cover
                string folderGambar = Application.StartupPath + @"\Covers\";
                string pathGambar = folderGambar + idBuku + ".jpg";

                try
                {
                    // ngecek gambarnya beneran ada ga di komputernya
                    if (System.IO.File.Exists(pathGambar))
                    {
                        // kalo ada, tampilin ke picturebox
                        picCover.Image = Image.FromFile(pathGambar);
                    }
                    else
                    {
                        // kalo ga ada ya biarin kosong aja layarnya
                        picCover.Image = null;
                    }
                }
                catch (Exception)
                {
                    // kalo file gambarnya rusak, kosongin juga
                    picCover.Image = null;
                }

                // karena bukunya udah ketemu, kita munculin semua label teksnya biar nampil ke user
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;

                picCover.Visible = true;
                lblIsiJudul.Visible = true;
                lblIsiPenulis.Visible = true;
                lblIsiTahun.Visible = true;
                lblIsiTipe.Visible = true;
            }
        }
    }
}