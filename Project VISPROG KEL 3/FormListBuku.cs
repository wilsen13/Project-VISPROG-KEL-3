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
        public FormListBuku()
        {
            InitializeComponent();
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
        List<Book> daftarBuku = new List<Book>();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!radioButton1.Checked && !radioButton2.Checked)//untuk mengecek apakah radio button 1 dan 2 di centang, jika tidak tidak bisa lanjut
                {
                    MessageBox.Show("Pilih tipe buku Terlebih Dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //membuat objek buku baru
                Book buku = new Book();
                buku.JudulBuku = textBox1.Text;
                buku.Penulis = textBox2.Text;
                buku.TahunTerbit = textBox3.Text;

                // pemilihan tipe buku (fiksi & nonfiksi)
                if (radioButton1.Checked)
                {
                    buku.TipeBuku = radioButton1.Text;
                }
                else
                {
                    buku.TipeBuku = radioButton2.Text;
                }

                // memasukkan buku ke dalam list (dilakukan oleh librarian) 
                Librarian admin = new Librarian();
                admin.AddBook(buku, daftarBuku);

                // menggunakan data grid view untuk menampilkan list
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = daftarBuku;//menyambungkan list daftar buku dengan data grid view

                MessageBox.Show("Data Buku berhasil masuk ke tabel!", "Sukses");

                //Membersihkan text box setelah berhasil inpput
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormListBuku_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Book bukuTerpilih = (Book)dataGridView1.CurrentRow.DataBoundItem;//mengambil data buku dari baris yang d select

                //pop up konfirmasi jika ingin menghapus buku
                DialogResult dialogResult = MessageBox.Show($"Yakin ingin menghapus buku '{bukuTerpilih.JudulBuku}'?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    //librarian menghapus data buku
                    Librarian admin = new Librarian();
                    admin.RemoveBook(bukuTerpilih, daftarBuku);

                    //memperbarui tampilan tabel 
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = daftarBuku;

                    MessageBox.Show("Buku berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Silakan klik dulu buku mana yang mau dihapus di tabel.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
