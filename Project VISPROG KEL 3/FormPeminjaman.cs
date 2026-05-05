using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Project_VISPROG_KEL_3
{
    public partial class FormPeminjaman : Form
    {
        public FormPeminjaman()
        {
            InitializeComponent();

            try
            {
                RefreshBukuSaya();
                RefreshKatalog();

                //agar tampilan data grid menjadi lebih rapih 
                KatalogBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                KatalogBuku.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                KatalogBuku.ReadOnly = true;
                KatalogBuku.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in FormPeminjaman constructor: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormPeminjaman_Load(object sender, EventArgs e)
        {

        }

        private void RefreshKatalog()
        {
            // Menyaring Array: Hanya ambil buku yang statusnya "Tersedia"
            var bukuTersedia = DataStore.ArrayBuku.Where(b => b.Status == "Tersedia").ToArray();

            // Sambungkan data ke tabel
            KatalogBuku.DataSource = null;
            KatalogBuku.DataSource = bukuTersedia;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //cek apakah ada baris yang sedang dipilih di data grid
                if (KatalogBuku.CurrentRow == null)
                {
                    MessageBox.Show("Silakan klik salah satu buku di tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //mengambil data buku dari row di data grid yang sedang di select
                Book bukuDipilih = (Book)KatalogBuku.CurrentRow.DataBoundItem;

                // message box konfirmasi sebelum meminjam buku
                DialogResult konfirmasi = MessageBox.Show($"Apakah Anda yakin ingin meminjam buku '{bukuDipilih.JudulBuku}'?", "Konfirmasi Peminjaman", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (konfirmasi == DialogResult.Yes)
                {
                    //mengubah status buku menjadi di pinjam
                    bukuDipilih.Status = "Dipinjam";

                    //
                    Random rnd = new Random();
                    Loan transaksiBaru = new Loan();
                    transaksiBaru.LoanID = "LN" + rnd.Next(1000, 9999).ToString();
                    transaksiBaru.BookID = bukuDipilih.BookID;
                    transaksiBaru.MemberID = DataStore.PenggunaAktif.MemberID; // Diambil otomatis dari sesi
                    transaksiBaru.LoanDate = DateTime.Now;
                    transaksiBaru.DueDate = DateTime.Now.AddDays(7); // tenggat waktu seminggu
                    transaksiBaru.ReturnDate = null;

                    // memasukkan peminjaman baru ke dalam array peminjaman
                    Array.Resize(ref DataStore.ArrayPeminjaman, DataStore.ArrayPeminjaman.Length + 1);
                    DataStore.ArrayPeminjaman[DataStore.ArrayPeminjaman.Length - 1] = transaksiBaru;

                    //message berhasil meminjam dan informasi tenggat pengembalian
                    MessageBox.Show($"Buku berhasil dipinjam!\nTenggat Pengembalian: {transaksiBaru.DueDate.ToShortDateString()}", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // refresh tabel agar buku yang baru dipinjam langsung hilang dari daftar
                    RefreshKatalog();
                    RefreshBukuSaya();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan sistem: " + ex.Message);
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            // mengambil teks dari text box 
            string kataKunci = textBox1.Text.ToLower();

            // pencarian dalam array
            var hasilPencarian = DataStore.ArrayBuku.Where(b =>
                b.Status == "Tersedia" &&
                b.JudulBuku.ToLower().Contains(kataKunci) // Mengecek apakah judul mengandung kata yang diketik
            ).ToArray();

            // Tampilkan hasil pencarian ke tabel
            KatalogBuku.DataSource = null;
            KatalogBuku.DataSource = hasilPencarian;

            // notifikasi misal buku tidak ditemukan di array 
            if (hasilPencarian.Length == 0)
            {
                MessageBox.Show("Buku dengan judul tersebut tidak ditemukan atau sedang dipinjam.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Balikin tabel ke kondisi awal (tampilkan semua buku lagi)
                RefreshKatalog();
                textBox1.Clear();
            }
        }

        private void KatalogBuku_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RefreshBukuSaya()
        {
            // mencari daftar buku yang di pinjam oleh member (yang belum di kembalikan) 
            var riwayatPinjam = DataStore.ArrayPeminjaman
                .Where(p => p.MemberID == DataStore.PenggunaAktif.MemberID && p.ReturnDate == null)
                .Select(p => new
                {
                    ID_Transaksi = p.LoanID,
                    // Trik mencari Judul Buku dari ArrayBuku berdasarkan BookID yang ada di struk peminjaman
                    Judul_Buku = DataStore.ArrayBuku.FirstOrDefault(b => b.BookID == p.BookID)?.JudulBuku,
                    Tgl_Pinjam = p.LoanDate.ToShortDateString(),
                    Batas_Kembali = p.DueDate.ToShortDateString()
                }).ToArray();

            bukuSaya.DataSource = null;
            bukuSaya.DataSource = riwayatPinjam;

            // merapikan tampilan
            bukuSaya.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bukuSaya.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bukuSaya.ReadOnly = true;
            bukuSaya.AllowUserToAddRows = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}