using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrystalReportViewHelper
{
    public partial class Form1 : Form
    {
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";
        string jenisLaporan = "";


        public Form1(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0)
            {
                jenisLaporan = args[0]; // Mengambil parameter "Pinjam" atau "Buku"
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DataSetLibra ds = new DataSetLibra();
            //ds.WriteXmlSchema(Application.StartupPath + @"\SkemaData.xml");

            if (string.IsNullOrEmpty(jenisLaporan))
            {
                MessageBox.Show("Parameter laporan tidak ditemukan.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    string query = "";
                    string rptName = "";
                    string dataTableNameInDataSet = "";

                    if (jenisLaporan == "Pinjam")
                    {
                        query = @"SELECT L.LoanID, U.Nama AS Nama, B.JudulBuku, L.LoanDate, L.DueDate, 
                                 CASE WHEN L.ReturnDate IS NULL THEN 'Dipinjam' ELSE 'Dikembalikan' END AS Status 
                                 FROM Loan L 
                                 INNER JOIN Book B ON L.BookID = B.BookID 
                                 INNER JOIN Member M ON L.MemberID = M.MemberID
                                 INNER JOIN [User] U ON M.UserID = U.UserID";
                        rptName = "LaporanPeminjaman.rpt";
                        dataTableNameInDataSet = "TabelPinjam"; 
                    }
                    else if (jenisLaporan == "Buku")
                    {
                        query = "SELECT BookID, JudulBuku, Penulis, TahunTerbit, TipeBuku, " +
                                "CASE WHEN Stok > 0 THEN 'Tersedia' ELSE 'Habis' END AS 'Status' " +
                                "FROM Book";
                        rptName = "ReportBuku.rpt";
                        dataTableNameInDataSet = "TabelBuku"; 
                    }

             
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);

                 
                    DataSetLibra ds = new DataSetLibra();


                    da.Fill(ds, dataTableNameInDataSet);

                    int jumlahBaris = ds.Tables[dataTableNameInDataSet].Rows.Count;
                    MessageBox.Show("DEBUG INFO:\n" +
                                    "- Parameter Terbaca: " + jenisLaporan + "\n" +
                                    "- Nama Tabel Tujuan: " + dataTableNameInDataSet + "\n" +
                                    "- Jumlah Data Terambil: " + jumlahBaris + " baris.");


                    ReportDocument cr = new ReportDocument();
                    string rptPath = Path.Combine(Application.StartupPath, rptName);

                    if (!File.Exists(rptPath))
                    {
                        MessageBox.Show("File report tidak ditemukan di: " + rptPath);
                        return;
                    }

                    cr.Load(rptPath);

                   
                    cr.SetDataSource(ds);

                   
                    crystalReportViewer1.ReportSource = cr;
                    crystalReportViewer1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saat memproses data laporan: " + ex.Message);
                }
            }
        }
    }
}
