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
            FormListBuku halamanBuku = new FormListBuku();// object dari form list buku 

            // menggunakan fungsi show dialog, agar halaman utama terkunci saat form list buku dibuka
            halamanBuku.ShowDialog();
        }
    }
}
