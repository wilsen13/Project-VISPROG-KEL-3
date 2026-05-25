using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace Project_VISPROG_KEL_3
{
    public partial class FormListBuku : Form
    {
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";
        string pathGambarDipilih = "";
        public FormListBuku()
        {
            InitializeComponent();

        }


        List<Book> daftarBuku = new List<Book>();

        private void TampilDataBuku()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    // Query untuk mengambil data dari tabel Book
                    string query = "SELECT BookID, JudulBuku, Penulis, TahunTerbit, TipeBuku, Stok, Status FROM Book";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    //memasukkan data ke dalam data grid view 
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
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

        private void FormListBuku_Load(object sender, EventArgs e)
        {
            TampilDataBuku();
            ThemeHelper.FormatTabel(dataGridView1);
            button2.Visible = false; // sembunyikan tombol hapus saat form pertama kali dimuat
            button3.Visible = false; // sama halnya dengan tombol hapus, tombol edit juga di sembunyikan saat form pertama kali dimuat
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                
                string idBukuTerpilih = dataGridView1.CurrentRow.Cells["BookID"].Value.ToString();
                string judulBuku = dataGridView1.CurrentRow.Cells["JudulBuku"].Value.ToString();

               
                DialogResult dialogResult = MessageBox.Show($"Yakin ingin menghapus buku '{judulBuku}' beserta riwayat peminjamannya dari database?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                       
                        SqlTransaction trans = conn.BeginTransaction();

                        try
                        {
                            // 1. HAPUS SEJARAHNYA DULU DI TABEL LOAN
                            string querySejarah = "DELETE FROM Loan WHERE BookID = @id";
                            using (SqlCommand cmdSejarah = new SqlCommand(querySejarah, conn, trans))
                            {
                                cmdSejarah.Parameters.AddWithValue("@id", idBukuTerpilih);
                                cmdSejarah.ExecuteNonQuery();
                            }

                            // 2. SETELAH SEJARAH BERSIH, BARU HAPUS BUKUNYA
                            string queryBuku = "DELETE FROM Book WHERE BookID = @id";
                            using (SqlCommand cmdBuku = new SqlCommand(queryBuku, conn, trans))
                            {
                                cmdBuku.Parameters.AddWithValue("@id", idBukuTerpilih);
                                cmdBuku.ExecuteNonQuery();
                            }

                            // Kalau dua-duanya berhasil dieksekusi, simpan permanen
                            trans.Commit();

                            MessageBox.Show("Buku dan riwayat peminjamannya berhasil dihapus permanen!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // refresh tabel
                            TampilDataBuku();

                            //reset text box agar kosong kembali setelah proses hapus
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            button1.Visible = true;  // Munculkan kembali tombol Tambahkan
                            button2.Visible = false; // Sembunyikan tombol Hapus
                            button3.Visible = false; // Sembunyikan tombol Edit
                        }
                        catch (Exception ex)
                        {
                            // Kalau ada yang error, batalkan semua proses hapus (rollback)
                            trans.Rollback();
                            MessageBox.Show("Gagal menghapus buku.\n\nDetail: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Silakan klik dulu buku mana yang mau dihapus di tabel.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

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

        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)

        private void button3_Click(object sender, EventArgs e)
        {
            // Kode untuk cek apakah masih ada textbox yang kosong
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Mohon Plih Buku Terlebih Dahulu, pastikan semua kotak terisi sebelum klik Edit!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // stop program sampai disini (tidak melanjutkan kebawah)
            }

            //logika jika yang di input di textboxt tahun terbit bukan lah sebuah angka, akan memunculkan pesan peringatan
            if (!int.TryParse(textBox3.Text, out int tahunAngka))
            {
                MessageBox.Show("Tahun Terbit harus berupa angka!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // stop program sampai disini (tidak melanjutkan kebawah)
            }

            if (!int.TryParse(textBox4.Text, out int stokAngka))
            {
                MessageBox.Show("Stok Buku harus berupa angka!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // stop program sampai disini
            }

            try
            {
                // mengambil id buku dari tabel yang sedang di klik
                string idBukuTerpilih = dataGridView1.CurrentRow.Cells["BookID"].Value.ToString();
                string tipeBuku = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    // query untuk melakukan update data di database
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

                if (pathGambarDipilih != "")
                {
                    SimpanGambarKeFolder(idBukuTerpilih, pathGambarDipilih);
                }

                MessageBox.Show("Data buku berhasil di update!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TampilDataBuku(); // untuk refresh tabel nya 
                //reset text box agar kosong kembali setelah proses edit
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                button1.Visible = true;  // Munculkan kembali tombol Tambahkan
                button2.Visible = false; // Sembunyikan tombol Hapus
                button3.Visible = false; // Sembunyikan tombol Edit
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data buku gagal di update." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // untuk memvalidasi radio button
                if (!radioButton1.Checked && !radioButton2.Checked)
                {
                    MessageBox.Show("Pilih tipe buku Terlebih Dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (textBox4.Text == "") // Validasi Stok
                {
                    MessageBox.Show("Stok buku wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // kode untuk menentukan tipe buku mana yang akan di pilih
                string tipeBuku = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;

                // generate id buku otomatis
                string newBookID = "BK-" + DateTime.Now.ToString("yyMMddHHmmss");

                // proses untuk melakukan input ke database
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "INSERT INTO Book (BookID, JudulBuku, Penulis, TahunTerbit, TipeBuku, Stok, Status) " +
                                   "VALUES (@id, @judul, @penulis, @tahun, @tipe, 1, 'Tersedia')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", newBookID);
                        cmd.Parameters.AddWithValue("@judul", textBox1.Text); // Judul
                        cmd.Parameters.AddWithValue("@penulis", textBox2.Text); // Penulis
                        cmd.Parameters.AddWithValue("@tahun", int.Parse(textBox3.Text)); // Tahun (dikonversi ke angka)
                        cmd.Parameters.AddWithValue("@tipe", tipeBuku); // Tipe (Fiksi/NonFiksi)

                        int result = cmd.ExecuteNonQuery(); //mengeksekusi query

                        if (result > 0 && pathGambarDipilih != "")
                        {
                            SimpanGambarKeFolder(newBookID, pathGambarDipilih);
                        }
                    }
                }

                MessageBox.Show("Data Buku & Gambar berhasil masuk ke Database!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // refresh tabel dan mengosongkan text box
                TampilDataBuku();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                textBox1.Focus();

                button1.Visible = true;  // Munculkan kembali tombol Tambahkan
                button2.Visible = false; // Sembunyikan tombol Hapus
                button3.Visible = false; // Sembunyikan tombol Edit
            }
            catch (FormatException)
            {
                MessageBox.Show("Tahun Terbit harus berupa angka!", "Error Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                string idBukuTerpilih = row.Cells["BookID"].Value.ToString();
                textBox1.Text = row.Cells["JudulBuku"].Value.ToString();
                textBox2.Text = row.Cells["Penulis"].Value.ToString();
                textBox3.Text = row.Cells["TahunTerbit"].Value.ToString();
                textBox4.Text = row.Cells["Stok"].Value.ToString();

                if (row.Cells["TipeBuku"].Value.ToString() == "Fiksi")
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;

                string imagePath = Path.Combine(Application.StartupPath, "Covers", idBukuTerpilih + ".jpg");
                if (File.Exists(imagePath))
                {
                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        MemoryStream ms = new MemoryStream();
                        fs.CopyTo(ms);
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox1.Image = null; // Kosongin kalau ga ada cover
                }

                // memunculkan tombol Hapus dan Edit karena sudah ada buku yang dipilih
                button2.Visible = true;
                button3.Visible = true;
                // menyembunyikan tombol Tambah saat mode Edit agar tidak ada duplikasi data
                button1.Visible = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pathGambarDipilih = ofd.FileName;

                // Nampilin preview pake FileStream biar file asli ga ke-lock
                using (FileStream fs = new FileStream(pathGambarDipilih, FileMode.Open, FileAccess.Read))
                {
                    MemoryStream ms = new MemoryStream();
                    fs.CopyTo(ms);
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
        }
        private void SimpanGambarKeFolder(string idBuku, string pathAsli)
        {
            string folderTujuan = Path.Combine(Application.StartupPath, "Covers");
            if (!Directory.Exists(folderTujuan)) Directory.CreateDirectory(folderTujuan);

            string ruteFileTujuan = Path.Combine(folderTujuan, idBuku + ".jpg");

            // FileStream Write untuk mencopy gambar
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
