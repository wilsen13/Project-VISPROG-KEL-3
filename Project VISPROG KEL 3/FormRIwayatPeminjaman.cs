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
            ThemeHelper.FormatTabel(dataGridView1);
        }

        private void TampilRiwayat()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {

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

                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    if (row["Tgl Dikembalikan"] == DBNull.Value)
                    //    {
                            
                    //    }
                    //}

                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat riwayat: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;

                picCover.Visible = false;
                lblIsiJudul.Visible = false;
                lblIsiPenulis.Visible = false;
                lblIsiTahun.Visible = false;
                lblIsiTipe.Visible = false;

                if (picCover != null) picCover.Image = null;

                return;
            }

        
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                string idLoan = row.Cells["LoanID"].Value.ToString();
                lblIsiJudul.Text = row.Cells["JudulBuku"].Value?.ToString() ?? "-";

              
                string idBuku = ""; 

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    
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
                                lblIsiPenulis.Text = dr["Penulis"].ToString();
                                lblIsiTahun.Text = dr["TahunTerbit"].ToString();
                                lblIsiTipe.Text = dr["TipeBuku"].ToString();
                                idBuku = dr["BookID"].ToString(); 
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

