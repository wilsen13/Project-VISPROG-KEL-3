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
        public FormListBuku()
        {
            InitializeComponent();
            try
            {
                //pengaturan visual untuk data grid view agar lebih menarik dan mudah digunakan
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//agar kolom menyesuaikan ukuran tabel
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;// agar saat di klik yang ter select adalah 1 baris penuh bukan hanya 1 cell

                //mencegah user mengedit di tabel dan menghilangkan baris kosong di bawah
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;

                //data grid view di berikan header style agar lebih menarik
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.EnableHeadersVisualStyles = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in FormListBuku constructor: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Cek apakah ada baris yang dipilih di DataGridView
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                // Mengambil BookID dan Judul dari baris yang diklik
                string idBukuTerpilih = dataGridView1.CurrentRow.Cells["BookID"].Value.ToString();
                string judulBuku = dataGridView1.CurrentRow.Cells["JudulBuku"].Value.ToString();

                DialogResult dialogResult = MessageBox.Show($"Yakin ingin menghapus buku '{judulBuku}' dari database?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connString))
                        {
                            conn.Open();
                            string query = "DELETE FROM Book WHERE BookID = @id";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", idBukuTerpilih);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Buku berhasil dihapus permanen!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh tabel
                        TampilDataBuku();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus. Buku ini mungkin sedang dipinjam.\n\nDetail: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                try
                {
                    string idBukuTerpilih = dataGridView1.CurrentRow.Cells["BookID"].Value.ToString();
                    string tipeBuku = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;

                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        string query = "UPDATE Book SET JudulBuku = @judul, Penulis = @penulis, TahunTerbit = @tahun, TipeBuku = @tipe WHERE BookID = @id";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", idBukuTerpilih);
                            cmd.Parameters.AddWithValue("@judul", textBox1.Text);
                            cmd.Parameters.AddWithValue("@penulis", textBox2.Text);
                            cmd.Parameters.AddWithValue("@tahun", int.Parse(textBox3.Text));
                            cmd.Parameters.AddWithValue("@tipe", tipeBuku);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Data Buku berhasil di-update!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TampilDataBuku(); // Refresh tabel
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mengupdate data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Pilih buku di tabel lalu isi textbox sebelum menekan Edit.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Validasi RadioButton
                if (!radioButton1.Checked && !radioButton2.Checked)
                {
                    MessageBox.Show("Pilih tipe buku Terlebih Dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Menentukan tipe buku
                string tipeBuku = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;

                // Generate ID Buku otomatis pakai format waktu biar unik
                string newBookID = "BK-" + DateTime.Now.ToString("yyMMddHHmmss");

                // Proses Insert ke Database
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

                        cmd.ExecuteNonQuery(); // Eksekusi query
                    }
                }

                MessageBox.Show("Data Buku berhasil masuk ke Database!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh tabel dan bersihkan TextBox
                TampilDataBuku();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                textBox1.Focus();
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
    }
}
