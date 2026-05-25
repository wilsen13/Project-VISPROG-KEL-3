using Microsoft.Data.SqlClient;
using System.Data;

namespace Project_VISPROG_KEL_3
{
    public partial class FormAdmin : Form
    {
        bool isLogOut = false;
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";
        public FormAdmin()
        {
            InitializeComponent();

        }
        List<Book> daftarBuku = new List<Book>();
        private void Form1_Load(object sender, EventArgs e)
        {
            ThemeHelper.FormatTabel(dataGridView1);
            homeText.Text = "Selamat Datang, " + Session.Nama + "!";
            lblTanggal.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy"); // Contoh: Monday, 25 May 2026

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // 2. STATISTIK 1: Total Semua Buku
                    string queryTotalBuku = "SELECT COUNT(*) FROM Book";
                    using (SqlCommand cmd = new SqlCommand(queryTotalBuku, conn))
                    {
                        lblTotalBuku.Text = cmd.ExecuteScalar().ToString();
                    }

                    // 3. STATISTIK 2: Total Member Aktif
                    string queryTotalMember = "SELECT COUNT(*) FROM [User] WHERE Role = 'Member'";
                    using (SqlCommand cmd = new SqlCommand(queryTotalMember, conn))
                    {
                        lblTotalMember.Text = cmd.ExecuteScalar().ToString();
                    }

                    // 4. STATISTIK 3: Jumlah Buku yang Stoknya Kosong (Biar Pustakawan tau)
                    string queryStokKosong = "SELECT COUNT(*) FROM Book WHERE Stok <= 0";
                    using (SqlCommand cmd = new SqlCommand(queryStokKosong, conn))
                    {
                        lblStokKosong.Text = cmd.ExecuteScalar().ToString();
                    }

                    // 5. MENGISI TABEL BAWAH: 5 Buku Terbaru (Dilihat dari ID atau Tahun)
                    // Menggunakan TOP 5 biar tabelnya rapi dan nampilin data paling fresh
                    string queryTabelBawah = @"
                SELECT TOP 5 
                    BookID AS 'ID Buku', 
                    JudulBuku AS 'Judul', 
                    Penulis, 
                    Stok 
                FROM Book 
                ORDER BY BookID DESC"; // Diurutkan dari yang paling baru ditambah

                    SqlDataAdapter da = new SqlDataAdapter(queryTabelBawah, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Masukin datanya ke DataGridView yang di bawah
                    dataGridView1.DataSource = dt;

                    // Biar tabelnya auto mekar menyesuaikan lebar kolom
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AllowUserToAddRows = false; // Ngilangin baris kosong di paling bawah
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat isi Dashboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void kelolaAnggotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                KelolaAnggota halamanAnggota = new KelolaAnggota();// object dari form list buku 

                halamanAnggota.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Kelola Anggota: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void kelolaBukuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                FormListBuku halamanBuku = new FormListBuku();// object dari form list buku 

                // menggunakan fungsi show dialog, agar halaman utama terkunci saat form list buku dibuk
                halamanBuku.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Kelola Buku: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kelolaAnggotaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                KelolaAnggota halamanAnggota = new KelolaAnggota();// object dari form list buku 

                halamanAnggota.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Kelola Anggota: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin Log Out?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
              
                isLogOut = true;

              
                Session.Clear();

                Login loginForm = new Login();
                loginForm.Show();

               
                this.Close();
            }
        }

        private void laporanPeminjamanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormViewLaporanPeminjaman lapPinjam = new FormViewLaporanPeminjaman("Pinjam");
            lapPinjam.Show();
        }

        private void laporanInventarisBukuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormViewLaporanPeminjaman lapBuku = new FormViewLaporanPeminjaman("Buku");
            lapBuku.Show();
        }

        private void peminjamanPengembalianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRiwayatPinjamKembali halPinjamKembali = new FormRiwayatPinjamKembali();
            halPinjamKembali.Show();
        }

        private void riwayatDendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRiwayatDenda halDenda = new FormRiwayatDenda();
            halDenda.Show();
        }

        private void gantiPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGantiPassword formGantiAdmin = new FormGantiPassword();
            formGantiAdmin.Show();
        }

        private void lblTanggal_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isLogOut == false)
            {
                Application.Exit();
            }
        }
    }
}
