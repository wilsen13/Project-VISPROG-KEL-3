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
        // string koneksi buat nyambungin aplikasi ke database lokal kita
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";

        public FormCariBuku()
        {
            InitializeComponent();
        }

        // fungsi yang otomatis jalan pertama kali pas halaman cari buku ini dibuka
        private void FormCariBuku_Load(object sender, EventArgs e)
        {
            // manggil fungsi buat nampilin semua buku (parameternya dikosongin biar nampil semua)
            TampilDataBuku("");

            // manggil helper buat ngerapiin warna dan desain tabel biar estetik
            ThemeHelper.FormatTabel(dataGridView1);

            // nyembunyiin label-label judul detail buku pas awal buka biar rapi
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;

            // nyembunyiin foto cover dan isian detail bukunya juga
            picCover.Visible = false;
            lblIsiJudul.Visible = false;
            lblIsiPenulis.Visible = false;
            lblIsiTahun.Visible = false;
            lblIsiTipe.Visible = false;
        }

        // fungsi serbaguna buat nampilin data buku, bisa buat nampil semua atau hasil search
        private void TampilDataBuku(string kataKunci)
        {
            // buka jembatan ke database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // query dasar buat narik data buku pake alias biar nama kolomnya rapi bahasa indonesia
                string query = @"SELECT BookID AS 'ID Buku', JudulBuku AS 'Judul Buku', 
                                 Penulis AS 'Penulis', TahunTerbit AS 'Tahun', 
                                 TipeBuku AS 'Kategori', Status AS 'Ketersediaan' 
                                 FROM Book ";

                // ngecek misal user masukin kata kunci pencarian, kita tambahin filter WHERE ke querynya
                if (!string.IsNullOrEmpty(kataKunci))
                {
                    // cari buku yang judul atau penulisnya mirip sama ketikan user
                    query += "WHERE JudulBuku LIKE @Cari OR Penulis LIKE @Cari ";
                }

                // urutin data yang tampil berdasarkan judul buku dari a sampai z
                query += "ORDER BY JudulBuku ASC";

                SqlCommand cmd = new SqlCommand(query, conn);

                // kalo tadi user emang ngetik kata kunci, masukin nilainya ke parameter @Cari
                if (!string.IsNullOrEmpty(kataKunci))
                {
                    // pake tanda % di kiri kanan biar bisa nyari kata di tengah-tengah kalimat
                    cmd.Parameters.AddWithValue("@Cari", "%" + kataKunci + "%");
                }

                // wadah buat nampung hasil tarikan dari database
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // masukin hasilnya ke tabel di layar
                dataGridView1.DataSource = dt;
            }
        }

        // fungsi yang jalan pas salah satu kotak di dalem tabel diklik sama user
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // kalo e.rowindex -1, berarti user ngeklik header (judul kolom yang warna biru di atas)
            if (e.RowIndex == -1)
            {
                // sembunyiin lagi semua detail dan gambar bukunya
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                picCover.Visible = false;
                lblIsiJudul.Visible = false;
                lblIsiPenulis.Visible = false;
                lblIsiTahun.Visible = false;
                lblIsiTipe.Visible = false;

                // bersihin memori gambar di picturebox biar ga error
                if (picCover != null) picCover.Image = null;

                // berhentiin proses kodingannya sampai sini aja
                return;
            }

            // kalo yang diklik beneran baris isi data (indexnya 0 ke atas)
            if (e.RowIndex >= 0)
            {
                // tangkep data dari baris yang lagi diklik
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // lempar teks dari sel tabel ke label-label detail di bawah
                // pake tanda tanya sama ?? "-" buat jaga-jaga misal datanya kosong (null) di database
                lblIsiJudul.Text = row.Cells["Judul Buku"].Value?.ToString() ?? "-";
                lblIsiPenulis.Text = row.Cells["Penulis"].Value?.ToString() ?? "-";
                lblIsiTahun.Text = row.Cells["Tahun"].Value?.ToString() ?? "-";
                lblIsiTipe.Text = row.Cells["Kategori"].Value?.ToString() ?? "-";

                // ambil id bukunya buat nyari file gambar covernya nanti
                string idBuku = row.Cells["ID Buku"].Value.ToString();

                // nentuin alamat folder tempat kita nyimpen gambar cover
                string folderGambar = Application.StartupPath + @"\Covers\";
                string pathGambar = folderGambar + idBuku + ".jpg";

                try
                {
                    // ngecek apakah file gambarnya beneran ada di dalem folder itu
                    if (System.IO.File.Exists(pathGambar))
                    {
                        // kalo nemu, tampilin gambarnya
                        picCover.Image = Image.FromFile(pathGambar);
                    }
                    else
                    {
                        // kalo ga nemu gambarnya, pictureboxnya dikosongin aja
                        picCover.Image = null;
                    }
                }
                catch (Exception)
                {
                    // kalo terjadi error pas muat gambar (misal file rusak), kosongin juga
                    picCover.Image = null;
                }

                // pasang status visible ke true buat nampilin semua label dan gambar yang disembunyiin tadi
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

        // fungsi khusus buat nampilin ulang semua data (dipake pas buku yang dicari ga ketemu)
        private void LoadDataBuku()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // nulis query pake alias bahasa indonesia biar nama kolom di layar seragam
                string query = @"SELECT BookID AS 'ID Buku', 
                                JudulBuku AS 'Judul Buku', 
                                Penulis, 
                                TahunTerbit AS 'Tahun', 
                                TipeBuku AS 'Kategori', 
                                Status AS 'Ketersediaan' 
                         FROM Book";

                // siapin perintahnya dan tarik datanya
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // tampilin ke layar
                dataGridView1.DataSource = dt;
            }
        }

        // fungsi yang dijalanin pas tombol cari diklik
        private void btnCari_Click(object sender, EventArgs e)
        {
            // ngambil tulisan dari textbox pencarian, dibikin huruf kecil semua biar gampang dicocokin
            string kataKunci = textBox1.Text.Trim().ToLower(); 

            using (SqlConnection conn = new SqlConnection(connString))
            {
                // tarik semua buku yang tersedia dulu ke memori dataset
                string query = @"SELECT BookID AS 'ID Buku', 
                                JudulBuku AS 'Judul Buku', 
                                Penulis, 
                                TahunTerbit AS 'Tahun', 
                                TipeBuku AS 'Kategori', 
                                Stok, 
                                Status AS 'Ketersediaan' 
                         FROM Book WHERE Status = 'Tersedia'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // implementasi linq untuk fitur search buku
                    var hasilPencarian = from baris in dt.AsEnumerable()
                                         let judul = baris.Field<string>("Judul Buku").ToLower()
                                         let penulis = baris.Field<string>("Penulis").ToLower()
                                         where judul.Contains(kataKunci) || penulis.Contains(kataKunci)
                                         orderby judul ascending // nerapin fitur sorting a-z
                                         select baris;

                    // ngecek misal hasil linq-nya dapet data
                    if (hasilPencarian.Any())
                    {
                        // ubah hasil linq balik ke bentuk datatable biar bisa masuk gridview
                        dataGridView1.DataSource = hasilPencarian.CopyToDataTable();
                    }
                    else
                    {
                        MessageBox.Show("Buku yang kamu cari tidak ditemukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // panggil ulang semua data aslinya
                        LoadDataBuku();
                    }
                }
            }
        }

    }
}