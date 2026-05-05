namespace Project_VISPROG_KEL_3
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();

        }
        List<Book> daftarBuku = new List<Book>();
        private void Form1_Load(object sender, EventArgs e)
        {

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
        private void peminjamanBukuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormPeminjaman halamanPeminjaman = new FormPeminjaman();// object dari form list buku 
                halamanPeminjaman.ShowDialog();// menggunakan fungsi show dialog
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Peminjaman: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kelolaBukuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormListBuku halamanBuku = new FormListBuku();// object dari form list buku 

                // menggunakan fungsi show dialog, agar halaman utama terkunci saat form list buku dibuka
                halamanBuku.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Kelola Buku: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kelolaAnggotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                KelolaAnggota halamanAnggota = new KelolaAnggota();// object dari form list buku 

                halamanAnggota.ShowDialog();
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

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin Log Out?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                // clear sesi
                Session.Clear();

                // menampilkan form login yang sebelumnya di sembunyikan setelah berhasil melakukan login
                Login loginForm = new Login();
                loginForm.Show();

                //menutup halaman 
                this.Close();
            }
        }
    }
}
