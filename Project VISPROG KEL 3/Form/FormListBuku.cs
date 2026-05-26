using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; // nambahin ini biar path sama file bisa jalan
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_VISPROG_KEL_3
{
    public partial class FormListBuku : Form
    {
        // nyimpen alamat database lokal kita
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";

        // variabel bantuan buat nyimpen lokasi file gambar yang dipilih admin dari komputernya
        string pathGambarDipilih = "";

        public FormListBuku()
        {
            InitializeComponent();
        }

        List<Book> daftarBuku = new List<Book>();

        // fungsi dasar buat narik semua data buku dari sql server
        private void TampilDataBuku()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    // narik kolom-kolom yang dibutuhin aja dari tabel book
                    string query = "SELECT BookID, JudulBuku, Penulis, TahunTerbit, TipeBuku, Stok, Status FROM Book";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // masukin hasil tarikan ke dalam tabel yang ada di layar
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                // kalo misal server mati atau error, munculin pesan
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // jalan otomatis pas halaman kelola buku ini kebuka
        private void FormListBuku_Load(object sender, EventArgs e)
        {
            // langsung panggil data bukunya
            TampilDataBuku();

            // panggil fungsi ngerapiin desain tabel biar rapi
            ThemeHelper.FormatTabel(dataGridView1);

            // sembunyiin tombol hapus dan edit pas awal banget form dibuka soalnya kan belom ada buku yang dipilih
            button2.Visible = false;
            button3.Visible = false;
        }

        // ini kodingan pas tombol hapus diklik
        private void button2_Click(object sender, EventArgs e)
        {
            // mastiin emang beneran ada baris buku yang lagi diklik di tabel
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                // ngambil id sama judul buku dari baris yang lagi dipilih
                string idBukuTerpilih = dataGridView1.CurrentRow.Cells["BookID"].Value.ToString();
                string judulBuku = dataGridView1.CurrentRow.Cells["JudulBuku"].Value.ToString();

                // munculin pop up peringatan nanya beneran yakin ga mau hapus
                DialogResult dialogResult = MessageBox.Show($"Yakin ingin menghapus buku '{judulBuku}' beserta riwayat peminjamannya dari database?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // kalo admin klik yes
                if (dialogResult == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();

                        // kita pake transaction biar kalo error di tengah jalan, datanya ga setengah-setengah kehapusnya
                        SqlTransaction trans = conn.BeginTransaction();

                        try
                        {
                            // 1. hapus riwayat peminjamannya dulu di tabel loan (kalo ga dihapus duluan nanti kena error foreign key)
                            string querySejarah = "DELETE FROM Loan WHERE BookID = @id";
                            using (SqlCommand cmdSejarah = new SqlCommand(querySejarah, conn, trans))
                            {
                                cmdSejarah.Parameters.AddWithValue("@id", idBukuTerpilih);
                                cmdSejarah.ExecuteNonQuery();
                            }

                            // 2. kalo riwayatnya udah bersih, baru boleh hapus data asli bukunya
                            string queryBuku = "DELETE FROM Book WHERE BookID = @id";
                            using (SqlCommand cmdBuku = new SqlCommand(queryBuku, conn, trans))
                            {
                                cmdBuku.Parameters.AddWithValue("@id", idBukuTerpilih);
                                cmdBuku.ExecuteNonQuery();
                            }

                            // simpen permanen perubahannya kalo dua proses di atas aman semua
                            trans.Commit();

                            MessageBox.Show("Buku dan riwayat peminjamannya berhasil dihapus permanen!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // refresh tampilan tabel
                            TampilDataBuku();

                            // bersihin semua kotak isian biar kayak baru buka form lagi
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();

                            // atur ulang posisi tombolnya
                            button1.Visible = true;
                            button2.Visible = false;
                            button3.Visible = false;
                        }
                        catch (Exception ex)
                        {
                            // batalkan semua proses kalo tiba-tiba ngadat (rollback)
                            trans.Rollback();
                            MessageBox.Show("Gagal menghapus buku.\n\nDetail: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                // kalo admin iseng ngeklik hapus tapi belom milih bukunya
                MessageBox.Show("Silakan klik dulu buku mana yang mau dihapus di tabel.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // kodingan cadangan kalo ngeklik isi sel tabel
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["JudulBuku"].Value.ToString();
                textBox2.Text = row.Cells["Penulis"].Value.ToString();
                textBox3.Text = row.Cells["TahunTerbit"].Value.ToString();

                if (row.Cells["TipeBuku"].Value.ToString() == "Fiksi")
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;
            }
        }

        // ini kodingan pas tombol edit (simpan perubahan) diklik
        private void button3_Click(object sender, EventArgs e)
        {
            // ngecek jangan sampe ada textbox judul, penulis, dll yang sengaja dikosongin
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Mohon Plih Buku Terlebih Dahulu, pastikan semua kotak terisi sebelum klik Edit!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // stop proses
                return;
            }

            // mastiin yang diketik di kotak tahun terbit itu beneran angka, bukan huruf
            if (!int.TryParse(textBox3.Text, out int tahunAngka))
            {
                MessageBox.Show("Tahun Terbit harus berupa angka!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // mastiin input stok juga harus berupa angka beneran
            if (!int.TryParse(textBox4.Text, out int stokAngka))
            {
                MessageBox.Show("Stok Buku harus berupa angka!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // narik id buku yang lagi diklik buat acuan update
                string idBukuTerpilih = dataGridView1.CurrentRow.Cells["BookID"].Value.ToString();

                // nentuin dia milih fiksi atau nonfiksi dari radio button
                string tipeBuku = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // nembak query update ke database sekalian nimpa data lamanya
                    string query = "UPDATE Book SET JudulBuku = @judul, Penulis = @penulis, TahunTerbit = @tahun, TipeBuku = @tipe, Stok = @stok WHERE BookID = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idBukuTerpilih);
                        cmd.Parameters.AddWithValue("@judul", textBox1.Text);
                        cmd.Parameters.AddWithValue("@penulis", textBox2.Text);
                        cmd.Parameters.AddWithValue("@tahun", tahunAngka);
                        cmd.Parameters.AddWithValue("@tipe", tipeBuku);
                        cmd.Parameters.AddWithValue("@stok", stokAngka);

                        cmd.ExecuteNonQuery();
                    }
                }

                // ngecek kalo pas ngedit ini admin juga milih gambar baru
                if (pathGambarDipilih != "")
                {
                    // panggil fungsi buat nimpa file gambar lama pake gambar baru di folder
                    SimpanGambarKeFolder(idBukuTerpilih, pathGambarDipilih);
                }

                MessageBox.Show("Data buku berhasil di update!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // manggil datanya ulang biar tabelnya ngerefresh
                TampilDataBuku();

                // bersihin semua kotak isian
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;

                // reset tempat memori path gambar
                pathGambarDipilih = "";

                // balikin tombolnya ke mode awal (mode tambah buku)
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;

                // hapus gambar yang masih nyangkut di memori layar
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data buku gagal di update." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ini kodingan pas tombol tambahkan buku (buku baru) diklik
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // validasi biar radio button fiksi nonfiksinya wajib dipilih salah satu
                if (!radioButton1.Checked && !radioButton2.Checked)
                {
                    MessageBox.Show("Pilih tipe buku Terlebih Dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ngecek stok ga boleh dibiarin kosong
                if (textBox4.Text == "")
                {
                    MessageBox.Show("Stok buku wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ngecek tipe bukunya apa
                string tipeBuku = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;

                // bikin kode id buku secara otomatis pake kombinasi tulisan bk dan waktu realtime
                string newBookID = "BK-" + DateTime.Now.ToString("yyMMddHHmmss");

                int stokInput = int.Parse(textBox4.Text);

                // nentuin status otomatis, kalo stok lebih dari 0 ya tersedia, kalo 0 langsung tidak tersedia
                string statusBuku = stokInput > 0 ? "Tersedia" : "Tidak Tersedia";

                // persiapan masukin data ke database
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "INSERT INTO Book (BookID, JudulBuku, Penulis, TahunTerbit, TipeBuku, Stok, Status) " +
                                   "VALUES (@id, @judul, @penulis, @tahun, @tipe, @stok, 'Tersedia')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", newBookID);
                        cmd.Parameters.AddWithValue("@judul", textBox1.Text);
                        cmd.Parameters.AddWithValue("@penulis", textBox2.Text);
                        cmd.Parameters.AddWithValue("@tahun", int.Parse(textBox3.Text));
                        cmd.Parameters.AddWithValue("@tipe", tipeBuku);
                        cmd.Parameters.AddWithValue("@stok", stokInput);
                        cmd.Parameters.AddWithValue("@status", statusBuku);

                        int result = cmd.ExecuteNonQuery();

                        // kalo sukses nambahin data teksnya, dan admin milih gambar, kita copy gambarnya
                        if (result > 0 && pathGambarDipilih != "")
                        {
                            SimpanGambarKeFolder(newBookID, pathGambarDipilih);
                        }
                    }
                }

                MessageBox.Show("Data Buku & Gambar berhasil masuk ke Database!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // refresh tabel dan sapu bersih isi layarnya
                TampilDataBuku();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;

                // fokusin cursor ngetik balik ke kotak judul buku
                textBox1.Focus();

                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;

                // ngilangin gambar dari layar 
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
            }
            catch (FormatException)
            {
                // kalo error gara gara tahun diisi huruf
                MessageBox.Show("Tahun Terbit harus berupa angka!", "Error Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // kodingan pas area tabel atau baris diklik sama admin
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // nah kalo yang diklik itu bagian header biru (judul kolom) tabelnya
            if (e.RowIndex == -1)
            {
                // ini kita jadiin semacam trik rahasia buat ngereset seluruh layar kembali kayak awal
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;

                // buang gambarnya juga
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }

                pathGambarDipilih = "";

                // balikin settingan tombol
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;

                // ilangin warna biru yang nandain baris dipilih
                dataGridView1.ClearSelection();

                return;
            }

            // nah kalo yang diklik beneran baris datanya (index 0 ke atas)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                // tarik id bukunya
                string idBukuTerpilih = row.Cells["BookID"].Value.ToString();

                // pindahin tulisan dari tabel ke textbox di sebelah kiri biar gampang diedit
                textBox1.Text = row.Cells["JudulBuku"].Value.ToString();
                textBox2.Text = row.Cells["Penulis"].Value.ToString();
                textBox3.Text = row.Cells["TahunTerbit"].Value.ToString();
                textBox4.Text = row.Cells["Stok"].Value.ToString();

                // ngecek tipe fiksi atau nonfiksinya
                if (row.Cells["TipeBuku"].Value.ToString() == "Fiksi")
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;

                // nentuin alamat file gambar cover buat buku yang lagi diklik ini
                string imagePath = Path.Combine(Application.StartupPath, "Covers", idBukuTerpilih + ".jpg");

                // kalo file gambarnya ada di folder
                if (File.Exists(imagePath))
                {
                    // pake metode filestream sama memorystream biar file gambarnya ga kena lock sama c#
                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        MemoryStream ms = new MemoryStream();
                        fs.CopyTo(ms);
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // kosongin layarnya kalo dia belom punya cover
                    pictureBox1.Image = null;
                }

                // tampilin tombol edit sama hapusnya, terus umpetin tombol tambahnya
                button2.Visible = true;
                button3.Visible = true;
                button1.Visible = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        // kodingan pas tombol upload/pilih gambar diklik
        private void button4_Click(object sender, EventArgs e)
        {
            // munculin jendela windows explorer buat milih file
            OpenFileDialog ofd = new OpenFileDialog();

            // saring tipe filenya khusus gambar doang (jpg, png)
            ofd.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";

            // kalo admin udah milih gambar dan ngeklik open
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // simpen lokasi file asli di komputernya ke variabel ini
                pathGambarDipilih = ofd.FileName;

                // nampilin preview gambarnya ke picturebox pake sistem stream biar aman
                using (FileStream fs = new FileStream(pathGambarDipilih, FileMode.Open, FileAccess.Read))
                {
                    MemoryStream ms = new MemoryStream();
                    fs.CopyTo(ms);
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
        }

        // fungsi khusus yang tugasnya ngopy file gambar ke dalem sistem
        private void SimpanGambarKeFolder(string idBuku, string pathAsli)
        {
            // nentuin lokasi folder covers yang ada di dalem folder project aplikasinya
            string folderTujuan = Path.Combine(Application.StartupPath, "Covers");

            // kalo ternyata foldernya belum ada, sistem bakal otomatis bikin foldernya dulu
            if (!Directory.Exists(folderTujuan)) Directory.CreateDirectory(folderTujuan);

            // tentuin nama file barunya (id buku ditambahin format .jpg)
            string ruteFileTujuan = Path.Combine(folderTujuan, idBuku + ".jpg");

            // proses copy file pake metode filestream baca dan tulis
            using (FileStream fsRead = new FileStream(pathAsli, FileMode.Open, FileAccess.Read))
            {
                using (FileStream fsWrite = new FileStream(ruteFileTujuan, FileMode.Create, FileAccess.Write))
                {
                    fsRead.CopyTo(fsWrite);
                }
            }
        }
    }
}