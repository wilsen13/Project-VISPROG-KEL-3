namespace Project_VISPROG_KEL_3
{
    public partial class Form1 : Form
    {
        public Form1()
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
            FormPeminjaman halamanPeminjaman = new FormPeminjaman();// object dari form list buku 
            halamanPeminjaman.ShowDialog();// menggunakan fungsi show dialog
        }

        private void kelolaBukuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListBuku halamanBuku = new FormListBuku();// object dari form list buku 

            // menggunakan fungsi show dialog, agar halaman utama terkunci saat form list buku dibuka
            halamanBuku.ShowDialog();
        }

        private void kelolaAnggotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KelolaAnggota halamanAnggota = new KelolaAnggota();// object dari form list buku 

            halamanAnggota.ShowDialog();
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
    }
}
