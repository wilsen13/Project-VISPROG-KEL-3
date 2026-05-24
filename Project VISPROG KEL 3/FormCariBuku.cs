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
    public partial class FormCariBuku : Form
    {
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";

        public FormCariBuku()
        {
            InitializeComponent();
        }

        private void FormCariBuku_Load(object sender, EventArgs e)
        {
            TampilDataBuku("");
            ThemeHelper.FormatTabel(dataGridView1);
        }

        private void TampilDataBuku(string kataKunci)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // Sesuai blueprint Crystal Report lu, ini kolom yang ditampilin
                string query = @"SELECT BookID AS 'ID Buku', JudulBuku AS 'Judul Buku', 
                                 Penulis AS 'Penulis', TahunTerbit AS 'Tahun', 
                                 TipeBuku AS 'Kategori', Status AS 'Ketersediaan' 
                                 FROM Book ";

                // Kalau mahasiswa ngetik sesuatu, kita cari berdasarkan Judul atau Penulis
                if (!string.IsNullOrEmpty(kataKunci))
                {
                    query += "WHERE JudulBuku LIKE @Cari OR Penulis LIKE @Cari ";
                }

                query += "ORDER BY JudulBuku ASC"; // Urutin sesuai abjad A-Z

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
    }
}
