using Microsoft.Data.SqlClient;
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
        bool isLogOut = false;
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";
        public FormMember()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void FormMember_Load(object sender, EventArgs e)
        {
            ThemeHelper.FormatTabel(dataGridView1);
            label8.Text = "Selamat Datang, " + Session.Nama + "!";
            lblTanggal.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy", new System.Globalization.CultureInfo("id-ID"));

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string queryDipinjam = @"
                SELECT COUNT(*) 
                FROM Loan l
                INNER JOIN Member m ON l.MemberID = m.MemberID
                WHERE TRIM(m.UserID) = @id AND l.StatusPeminjaman = 'Dipinjam'";

                    using (SqlCommand cmd = new SqlCommand(queryDipinjam, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", Session.UserID.Trim());
                        lblBukuDipinjam.Text = cmd.ExecuteScalar().ToString();
                    }

                    // 3. STATISTIK 2: Total SEMUA buku yang pernah dia pinjam
                    string queryRiwayat = @"
                SELECT COUNT(*) 
                FROM Loan l
                INNER JOIN Member m ON l.MemberID = m.MemberID
                WHERE TRIM(m.UserID) = @id";

                    using (SqlCommand cmd = new SqlCommand(queryRiwayat, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", Session.UserID.Trim());
                        lblTotalRiwayat.Text = cmd.ExecuteScalar().ToString();
                    }

                    // 4. STATISTIK 3: Status Akun
                    lblStatusAkun.Text = "Aktif";
                    lblStatusAkun.ForeColor = System.Drawing.Color.Green;

                    // 5. MENGISI TABEL BAWAH: Daftar buku yang sedang dipinjam
                    // Kita gabungin 3 Tabel sekaligus! (Loan, Book, dan Member)
                    string queryTabel = @"
                SELECT 
                    b.JudulBuku AS 'Judul Buku', 
                    l.LoanDate AS 'Tanggal Pinjam',
                    l.StatusPeminjaman AS 'Status'
                FROM Loan l
                INNER JOIN Book b ON l.BookID = b.BookID
                INNER JOIN Member m ON l.MemberID = m.MemberID
                WHERE TRIM(m.UserID) = @id AND l.StatusPeminjaman = 'Dipinjam'";

                    using (SqlCommand cmdTabel = new SqlCommand(queryTabel, conn))
                    {
                        cmdTabel.Parameters.AddWithValue("@id", Session.UserID.Trim());

                        SqlDataAdapter da = new SqlDataAdapter(cmdTabel);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.DataSource = dt;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridView1.AllowUserToAddRows = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Penyakitnya disini bro: " + ex.Message);
            }
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

                isLogOut = true;


                Session.Clear();

                Login loginForm = new Login();
                loginForm.Show();


                this.Close();
            }
        }

        private void riwayatPeminjamanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRIwayatPeminjaman riwayat = new FormRIwayatPeminjaman();
            riwayat.Show();
        }

        private void cariBukuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCariBuku cariBuku = new FormCariBuku();
            cariBuku.Show();
        }

        private void profilSayaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGantiPassword formGanti = new FormGantiPassword();
            formGanti.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormMember_Load(sender, e);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormMember_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isLogOut == false)
            {
                Application.Exit();
            }
        }
    }
}
