using Microsoft.Data.SqlClient;
using System.Data;

namespace Project_VISPROG_KEL_3
{
    public partial class FormAdmin : Form
    {
        // bikin penanda buat ngecek admin ini beneran klik logout atau malah nutup aplikasi dari tanda silang
        bool isLogOut = false;

        // alamat koneksi buat nyambungin aplikasi ke database sql server lokal
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";

        public FormAdmin()
        {
            InitializeComponent();
        }

        // nyiapin list kosong buat nampung data buku sementara kalo dibutuhin nanti
        List<Book> daftarBuku = new List<Book>();

        private void Form1_Load(object sender, EventArgs e)
        {
            // manggil fungsi dari file ThemeHelper buat ngerapiin desain tabel biar seragam
            ThemeHelper.FormatTabel(dataGridView1);

            // nampilin teks sapaan ditambah nama user yang ditarik dari session login
            homeText.Text = "Selamat Datang, " + Session.Nama + "!";

            // ngambil tanggal hari ini dari sistem komputer dan diformat jadi tulisan yang gampang dibaca
            lblTanggal.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy"); // Contoh: Monday, 25 May 2026

            // pake blok try-catch biar misal databasenya ngadat, aplikasinya ga langsung force close
            try
            {
                // buka jembatan koneksi ke database, pake using biar jembatannya otomatis ditutup kalo udah beres
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    // buka pintunya
                    conn.Open();

                    // 2. STATISTIK 1: ngitung total semua buku yang ada di perpus
                    string queryTotalBuku = "SELECT COUNT(*) FROM Book";
                    using (SqlCommand cmd = new SqlCommand(queryTotalBuku, conn))
                    {
                        // jalanin perintah hitung dan ubah hasilnya jadi teks buat ditampilin ke layar
                        lblTotalBuku.Text = cmd.ExecuteScalar().ToString();
                    }

                    // 3. STATISTIK 2: ngitung total akun yang role-nya cuma sebagai member biasa
                    string queryTotalMember = "SELECT COUNT(*) FROM [User] WHERE Role = 'Member'";
                    using (SqlCommand cmd = new SqlCommand(queryTotalMember, conn))
                    {
                        // tampilin hasil hitungan membernya ke label
                        lblTotalMember.Text = cmd.ExecuteScalar().ToString();
                    }

                    // 4. STATISTIK 3: ngitung buku yang stoknya udah abis atau 0
                    string queryStokKosong = "SELECT COUNT(*) FROM Book WHERE Stok <= 0";
                    using (SqlCommand cmd = new SqlCommand(queryStokKosong, conn))
                    {
                        // tampilin jumlah buku yang kosong ke label biar admin tau
                        lblStokKosong.Text = cmd.ExecuteScalar().ToString();
                    }

                    // 5. ngisi tabel yang di bawah pake 5 data buku yang paling baru ditambahin
                    string queryTabelBawah = @"
                SELECT TOP 5 
                    BookID AS 'ID Buku', 
                    JudulBuku AS 'Judul', 
                    Penulis, 
                    Stok 
                FROM Book 
                ORDER BY BookID DESC"; // urutin dari id paling gede (paling baru) ke bawah

                    // eksekusi query dan siapin wadah tabel virtual buat nampung hasilnya
                    SqlDataAdapter da = new SqlDataAdapter(queryTabelBawah, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // masukin data dari wadah virtual tadi ke tabel asli yang ada di form
                    dataGridView1.DataSource = dt;

                    // seting biar lebar kolom tabelnya otomatis mekar menuhin ruang kosong
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // ngilangin baris kosong default bawaan windows form di bagian paling bawah tabel
                    dataGridView1.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                // kalo ada error pas narik data, munculin popup pesannya
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

        // fungsi pas tombol menu kelola anggota di klik
        private void kelolaAnggotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // bikin objek halamannya dulu sebelum ditampilin
                KelolaAnggota halamanAnggota = new KelolaAnggota();

                // tampilin halaman kelola anggota ke layar
                halamanAnggota.Show();
            }
            catch (Exception ex)
            {
                // munculin error detail kalo gagal buka halamannya
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

        // fungsi buat tombol refresh atau balik ke menu awal
        private void menuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // panggil ulang fungsi load awal biar data di dashboard kerestart/update
            Form1_Load(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // fungsi pas tombol menu kelola buku di klik
        private void kelolaBukuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                // bikin objek dari halaman kelola list buku
                FormListBuku halamanBuku = new FormListBuku();

                // munculin halaman kelola bukunya
                halamanBuku.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Kelola Buku: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // fungsi cadangan atau duplikat buat menu kelola anggota (biasanya dari tombol di tempat lain)
        private void kelolaAnggotaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                // logikanya sama persis kayak yang di atas, buka halaman kelola anggota
                KelolaAnggota halamanAnggota = new KelolaAnggota();
                halamanAnggota.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Kelola Anggota: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // fungsi pas admin klik menu logout
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // munculin popup buat mastiin user beneran mau keluar atau ngga
            DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin Log Out?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // kalo dia klik tombol yes
            if (dialogResult == DialogResult.Yes)
            {
                // tandain kalo form ini ketutup karena proses logout
                isLogOut = true;

                // hapus semua data login admin dari memori session biar aman
                Session.Clear();

                // panggil form login biar admin bisa masuk lagi nanti
                Login loginForm = new Login();
                loginForm.Show();

                // matiin atau tutup form admin yang lagi jalan ini
                this.Close();
            }
        }

        // fungsi pas menu laporan peminjaman diklik
        private void laporanPeminjamanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // panggil form viewer laporan sambil ngirim kata kunci "Pinjam" biar program tau harus buka crystal report yang mana
            FormViewLaporanPeminjaman lapPinjam = new FormViewLaporanPeminjaman("Pinjam");
            lapPinjam.Show();
        }

        // fungsi pas menu laporan inventaris buku diklik
        private void laporanInventarisBukuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // panggil form viewer laporan sambil ngirim kata kunci "Buku"
            FormViewLaporanPeminjaman lapBuku = new FormViewLaporanPeminjaman("Buku");
            lapBuku.Show();
        }

        // fungsi pas menu riwayat peminjaman & pengembalian diklik
        private void peminjamanPengembalianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // buka form yang nampilin log atau riwayat aktivitas pinjam kembali
            FormRiwayatPinjamKembali halPinjamKembali = new FormRiwayatPinjamKembali();
            halPinjamKembali.Show();
        }

        // fungsi pas menu riwayat denda diklik
        private void riwayatDendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // buka form khusus buat ngecek denda member
            FormRiwayatDenda halDenda = new FormRiwayatDenda();
            halDenda.Show();
        }

        // fungsi pas menu ganti password diklik
        private void gantiPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // buka form buat admin ngubah password akunnya sendiri
            FormGantiPassword formGantiAdmin = new FormGantiPassword();
            formGantiAdmin.Show();
        }

        private void lblTanggal_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        // ini fungsi otomatis yang jalan pas form admin ditutup (misal disilang di pojok kanan atas)
        private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            // cek kalo form ditutupnya BUKAN karena tombol logout
            if (isLogOut == false)
            {
                // matiin aplikasinya secara total sampai ke akar-akarnya (biar ga jalan di background)
                Application.Exit();
            }
        }
    }
}