using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_VISPROG_KEL_3
{
    public partial class KelolaAnggota : Form
    {
        // naruh string koneksi sql server lokal kita di sini
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";

        public KelolaAnggota()
        {
            InitializeComponent();

            // setingan awal biar tabel (data gridview) tampilannya rapih
            // biar kolomnya mekar menuhin ruang kosong
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // biar pas diklik langsung keblok satu baris full
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // dikunci biar datanya ga bisa diedit langsung dari tabel
            dataGridView1.ReadOnly = true;

            // ngilangin baris kosong sisa di paling bawah tabel
            dataGridView1.AllowUserToAddRows = false;
        }

        // fungsi utama buat narik data anggota dari database
        private void TampilDataAnggota()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    // ngambil data member gabungan dari tabel user sama member
                    // pake inner join biar sinkron, dan difilter cuma narik yang role-nya 'member' aja (admin ga ikut ketarik)
                    string query = "SELECT U.UserID AS 'ID Anggota', U.Nama AS 'Nama Lengkap', U.Email, U.PhoneNumber AS 'Nomor Telpon', U.StatusAkun AS 'Status' " +
                                   "FROM [User] U INNER JOIN Member M ON U.UserID = M.UserID " +
                                   "WHERE U.Role = 'Member'";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // masukin hasil tarikannya ke tabel
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                // kalo misal koneksi database putus, kasih tau errornya
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        // fungsi buat nyapu bersih layar balik ke mode awal
        private void BersihkanForm()
        {
            // kosongin semua kotak isian
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            // sembunyiin tombol-tombol aksi biar aman pas ga ada member yang dipilih
            button2.Visible = false; // tombol suspend/buka suspend
            button3.Visible = false; // tombol hapus
            button4.Visible = false; // tombol edit
        }

        // jalan otomatis pas halaman kelola anggota ini kebuka
        private void KelolaAnggota_Load(object sender, EventArgs e)
        {
            // panggil data anggotanya
            TampilDataAnggota();

            // bersihin layar
            BersihkanForm();

            // pake helper buat ngerapiin desain warnanya
            ThemeHelper.FormatTabel(dataGridView1);
        }

        // kalo admin ngeklik area kosong di form, kita reset juga pilihannya
        private void KelolaAnggota_Click(object sender, EventArgs e)
        {
            BersihkanForm();
        }

        // fungsi pas tombol "suspend / buka suspend" diklik
        private void button2_Click(object sender, EventArgs e)
        {
            // mastiin textbox id ga kosong (berarti ada member yang lagi diplih)
            if (string.IsNullOrWhiteSpace(textBox1.Text)) return;

            // ngecek status akun member yang lagi dipilih sekarang ini apa
            string statusSaatIni = dataGridView1.CurrentRow.Cells["Status"].Value.ToString();

            // pake logika ternary buat nge-flip statusnya
            // kalo sekarang aktif, nanti diubah jadi suspend. kalo sekarang suspend, diubah balik jadi aktif
            string statusBaru = (statusSaatIni == "Aktif") ? "Suspend" : "Aktif";
            string pesanLog = (statusBaru == "Suspend") ? "diblokir sementara" : "diaktifkan kembali";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // nembak query update ke database buat ngubah status akun
                    string query = "UPDATE [User] SET StatusAkun = @status WHERE UserID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", statusBaru);
                        cmd.Parameters.AddWithValue("@id", textBox1.Text);
                        cmd.ExecuteNonQuery();
                    }

                    // kasih notif sukses ke admin
                    MessageBox.Show($"Akun {textBox2.Text} berhasil {pesanLog}!", "Informasi");

                    // refresh tabel sama layar biar langsung kelihatan perubahannya
                    TampilDataAnggota();
                    BersihkanForm();
                }
                catch (Exception ex) { MessageBox.Show("Gagal mengubah status: " + ex.Message); }
            }
        }

        // fungsi pas tombol "edit / update data" diklik
        private void button4_Click(object sender, EventArgs e)
        {
            // ngecek jangan sampe admin malah ngosongin textbox pas mau ngedit
            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Harap Isi Semua Data Terlebih Dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validasi tipis-tipis buat ngecek format email (wajib ada @ dan titik)
            if (!textBox3.Text.Contains("@") || !textBox3.Text.Contains("."))
            {
                MessageBox.Show("Format email tidak valid! Pastikan menggunakan '@' dan domain (contoh: wilsen@email.com).", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validasi nomer hape wajib angka semua, pake linq bawaan c#
            if (!textBox4.Text.All(char.IsDigit))
            {
                MessageBox.Show("Nomor telepon wajib diisi dengan angka!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // timpa data lama pake data baru yang diketik admin
                    string query = "UPDATE [User] SET Nama = @nama, Email = @email, PhoneNumber = @phone WHERE UserID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", textBox1.Text);
                        cmd.Parameters.AddWithValue("@nama", textBox2.Text);
                        cmd.Parameters.AddWithValue("@email", textBox3.Text);
                        cmd.Parameters.AddWithValue("@phone", textBox4.Text);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data Anggota berhasil di-update!", "Sukses");

                    // refresh lagi
                    TampilDataAnggota();
                    BersihkanForm();
                }
                catch (Exception ex) { MessageBox.Show("Gagal mengupdate: " + ex.Message); }
            }
        }

        // fungsi pas tombol "hapus anggota" diklik
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) return;

            // munculin popup nanya beneran yakin mau dihapus ga nih membernya
            DialogResult dr = MessageBox.Show($"Yakin ingin menghapus member {textBox2.Text}?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // kalo admin klik yes
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        // hapus data secara berurutan, dari tabel anaknya dulu (member) baru bapaknya (user)
                        // biar ga kena error foreign key constraint sql
                        SqlCommand cmdMember = new SqlCommand("DELETE FROM Member WHERE UserID = @id", conn);
                        cmdMember.Parameters.AddWithValue("@id", textBox1.Text);
                        cmdMember.ExecuteNonQuery();

                        SqlCommand cmdUser = new SqlCommand("DELETE FROM [User] WHERE UserID = @id", conn);
                        cmdUser.Parameters.AddWithValue("@id", textBox1.Text);
                        cmdUser.ExecuteNonQuery();

                        MessageBox.Show("Anggota berhasil dihapus!", "Sukses");

                        // refresh
                        TampilDataAnggota();
                        BersihkanForm();
                    }
                    catch (Exception ex)
                    {
                        // biasanya error kelempar kesini kalo membernya masih punya tanggungan minjem buku (kecantol di tabel loan)
                        MessageBox.Show("Gagal menghapus (Mungkin member masih meminjam buku): " + ex.Message);
                    }
                }
            }
        }

        // fungsi kalo salah satu baris di tabel diklik sama admin
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // mastiin yang diklik emang isi datanya, bukan headernya
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                // narik data dari tabel buat diisi ke textbox
                textBox1.Text = row.Cells["ID Anggota"].Value.ToString();
                textBox2.Text = row.Cells["Nama Lengkap"].Value.ToString();
                textBox3.Text = row.Cells["Email"].Value.ToString();
                textBox4.Text = row.Cells["Nomor Telpon"].Value.ToString();

                // nah ini trik buat ngeganti teks tombol suspend secara dinamis
                string statusSaatIni = row.Cells["Status"].Value.ToString();
                if (statusSaatIni == "Suspend")
                {
                    // kalo akunnya lagi kena blokir, teks tombol berubah jadi 'buka suspend'
                    button2.Text = "Buka Suspend";
                }
                else
                {
                    // sebaliknya
                    button2.Text = "Suspend";
                }

                // munculin tombol-tombol aksinya
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        // fungsi event tambahan buat ngejaga biar textbox telepon cuma bisa diisi angka dari keyboard
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // kalo yang dipencet dari keyboard BUKAN angka dan BUKAN tombol kontrol (kayak backspace), maka inputannya diblok
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}