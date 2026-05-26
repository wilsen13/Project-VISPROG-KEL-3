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

            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;

            picCover.Visible = false;
            lblIsiJudul.Visible = false;
            lblIsiPenulis.Visible = false;
            lblIsiTahun.Visible = false;
            lblIsiTipe.Visible = false;
        }

        private void TampilDataBuku(string kataKunci)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {

                string query = @"SELECT BookID AS 'ID Buku', JudulBuku AS 'Judul Buku', 
                                 Penulis AS 'Penulis', TahunTerbit AS 'Tahun', 
                                 TipeBuku AS 'Kategori', Status AS 'Ketersediaan' 
                                 FROM Book ";


                if (!string.IsNullOrEmpty(kataKunci))
                {
                    query += "WHERE JudulBuku LIKE @Cari OR Penulis LIKE @Cari ";
                }

                query += "ORDER BY JudulBuku ASC";

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1)
            {
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                picCover.Visible = false;
                lblIsiJudul.Visible = false; lblIsiJudul.Visible = false;
                lblIsiPenulis.Visible = false; lblIsiPenulis.Visible = false;
                lblIsiTahun.Visible = false; lblIsiTahun.Visible = false;
                lblIsiTipe.Visible = false; lblIsiTipe.Visible = false;
                if (picCover != null) picCover.Image = null;

                return;
            }

            if (e.RowIndex >= 0)
            {


                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];


                lblIsiJudul.Text = row.Cells["Judul Buku"].Value?.ToString() ?? "-";
                lblIsiPenulis.Text = row.Cells["Penulis"].Value?.ToString() ?? "-";
                lblIsiTahun.Text = row.Cells["Tahun"].Value?.ToString() ?? "-";
                lblIsiTipe.Text = row.Cells["Kategori"].Value?.ToString() ?? "-";


                string idBuku = row.Cells["ID Buku"].Value.ToString();


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
        private void LoadDataBuku()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // Pakai AS alias biar nama kolomnya rapi dan seragam
                string query = @"SELECT BookID AS 'ID Buku', 
                                JudulBuku AS 'Judul Buku', 
                                Penulis, 
                                TahunTerbit AS 'Tahun', 
                                TipeBuku AS 'Kategori', 
                                Status AS 'Ketersediaan' 
                         FROM Book";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Ganti dataGridView1 dengan nama tabel di form cari buku lu
                dataGridView1.DataSource = dt;
            }
        }
        private void btnCari_Click(object sender, EventArgs e)
        {
            string kataKunci = textBox1.Text.Trim(); // Ganti textBox1 dengan nama kotak pencarian lu

            using (SqlConnection conn = new SqlConnection(connString))
            {
                // PENTING: Kita pakai query yang AS (alias) nya SAMA PERSIS kayak di fungsi LoadBukuTersedia()
                string query = @"SELECT BookID AS 'ID Buku', 
                                JudulBuku AS 'Judul Buku', 
                                Penulis, 
                                TahunTerbit AS 'Tahun', 
                                TipeBuku AS 'Kategori', 
                                Stok, 
                                Status AS 'Ketersediaan' 
                         FROM Book 
                         WHERE Status = 'Tersedia' 
                         AND (JudulBuku LIKE @search OR Penulis LIKE @search)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Tanda % di kiri kanan ini gunanya biar nyari kata yang mengandung (Contains) inputan lu
                    cmd.Parameters.AddWithValue("@search", "%" + kataKunci + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                  
                    if (dt.Rows.Count > 0)
                    {
                       
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Buku yang kamu cari tidak ditemukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        
                        LoadDataBuku();
                    }
                }
            }
        }
    }
}
