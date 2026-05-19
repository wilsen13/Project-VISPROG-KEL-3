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
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace Project_VISPROG_KEL_3
{
    public partial class FormViewLaporanPeminjaman : Form
    {
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";
        string jenisLaporan = "";

        CrystalReportViewer crystalReportViewer1 = new CrystalReportViewer();
        public FormViewLaporanPeminjaman(string perintahLaporan)
        {
            InitializeComponent();

            jenisLaporan = perintahLaporan;

            
            crystalReportViewer1.Dock = DockStyle.Fill;
            this.Controls.Add(crystalReportViewer1);
        }

        private void FormViewLaporanPeminjaman_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    if (jenisLaporan == "Pinjam")
                    {
                        string query = "SELECT L.LoanID, M.NamaLengkap AS 'Nama', B.JudulBuku, L.LoanDate, L.DueDate, " +
                                       "CASE WHEN L.ReturnDate IS NULL THEN 'Dipinjam' ELSE 'Dikembalikan' END AS 'Status' " +
                                       "FROM Loan L " +
                                       "INNER JOIN Book B ON L.BookID = B.BookID " +
                                       "INNER JOIN Member M ON L.MemberID = M.MemberID";

                        SqlDataAdapter da = new SqlDataAdapter(query, conn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        ReportDocument cr = new ReportDocument();
                        //otomatis mencari laporan di dalam path folder
                        cr.Load(Application.StartupPath + "\\..\\..\\LaporanPeminjaman.rpt");
                        cr.SetDataSource(dt);
                        crystalReportViewer1.ReportSource = cr;
                    }
                    else if (jenisLaporan == "Buku")
                    {
                        string query = "SELECT BookID, JudulBuku, Penulis, TahunTerbit, TipeBuku, " +
                                       "CASE WHEN Stok > 0 THEN 'Tersedia' ELSE 'Habis' END AS 'Status' " +
                                       "FROM Book";

                        SqlDataAdapter da = new SqlDataAdapter(query, conn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        ReportDocument cr = new ReportDocument();
                        //otomatis mencari laporan di dalam path folder
                        cr.Load(Application.StartupPath + "\\..\\..\\ReportBuku.rpt"); // Pastikan nama filenya bener ReportBuku.rpt
                        cr.SetDataSource(dt);
                        crystalReportViewer1.ReportSource = cr;
                    }

                    crystalReportViewer1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat laporan: " + ex.Message);
                }
            }
        }
    }
}
