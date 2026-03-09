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
                if (!radioButton1.Checked && radioButton2.Checked)//untuk mengecek apakah radio button 1 dan 2 di centang, jika tidak tidak bisa lanjut
                {
                    MessageBox.Show("Pilih tipe buku Terlebih Dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //membuat objek buku baru
                Book buku = new Book();
                buku.JudulBuku = textBox1.Text;
                buku.Penulis = textBox2.Text;
                buku.TahunTerbit = textBox3.Text;

                // logika pemilihan tipe buku (fiksi & nonfiksi)
                if (radioButton1.Checked)
                {
                    buku.TipeBuku = radioButton1.Text;
                }
                else
                {
                    buku.TipeBuku = radioButton2.Text;
                }

                // memasukkan buku ke dalam list
                daftarBuku.Add(buku);

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

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
