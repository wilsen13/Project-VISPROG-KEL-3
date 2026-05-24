using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project_VISPROG_KEL_3
{
    public partial class FormMember : Form
    {
        public FormMember()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void FormMember_Load(object sender, EventArgs e)
        {

        }

        private void pinjamKembalikanBukuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormPeminjaman halamanPeminjaman = new FormPeminjaman();// object dari form peminjaman

                halamanPeminjaman.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Halaman Peminjaman: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logIutToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void riwayatPeminjamanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRIwayatPeminjaman riwayat = new FormRIwayatPeminjaman();
            //riwayat.MdiParent = this; // Biar rapi di dalam kotak induk
            riwayat.Show();
        }

        private void cariBukuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCariBuku cariBuku = new FormCariBuku();
            cariBuku.Show();
        }
    }
}
