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
    public partial class KelolaAnggota : Form
    {
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";
        public KelolaAnggota()
        {
            InitializeComponent();

            //agar data gridview rapih
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void TampilDataAnggota()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    // mengambil data member sekaligus nampilin StatusAkun nya
                    string query = "SELECT U.UserID AS 'ID Anggota', U.Nama AS 'Nama Lengkap', U.Email, U.PhoneNumber AS 'Nomor Telpon', U.StatusAkun AS 'Status' " +
                                   "FROM [User] U INNER JOIN Member M ON U.UserID = M.UserID " +
                                   "WHERE U.Role = 'Member'";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private void BersihkanForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            button2.Visible = false; // Tombol Hapus nonaktif
            button3.Visible = false; // Tombol Edit nonaktif
            button4.Visible = false; // Tombol Suspend nonaktif
        }

        private void KelolaAnggota_Load(object sender, EventArgs e)
        {
            TampilDataAnggota();
            BersihkanForm();
        }

        private void KelolaAnggota_Click(object sender, EventArgs e)
        {
            BersihkanForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) return;

            // tentukan status saat ini dari akun yang dipilih, kalau Aktif maka akan di Suspend, kalau Suspend maka akan di Aktifkan kembali
            string statusSaatIni = dataGridView1.CurrentRow.Cells["Status"].Value.ToString();

            // kode untuk menentukan status baru dan pesan log berdasarkan status saat ini
            string statusBaru = (statusSaatIni == "Aktif") ? "Suspend" : "Aktif";
            string pesanLog = (statusBaru == "Suspend") ? "diblokir sementara" : "diaktifkan kembali";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE [User] SET StatusAkun = @status WHERE UserID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", statusBaru);
                        cmd.Parameters.AddWithValue("@id", textBox1.Text);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show($"Akun {textBox2.Text} berhasil {pesanLog}!", "Informasi");
                    TampilDataAnggota();
                    BersihkanForm();
                }
                catch (Exception ex) { MessageBox.Show("Gagal mengubah status: " + ex.Message); }
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) return;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE [User] SET Nama = @nama, Email = @email, PhoneNumber = @phone WHERE UserID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", textBox1.Text);
                        cmd.Parameters.AddWithValue("@nama", textBox2.Text);
                        cmd.Parameters.AddWithValue("@email", textBox3.Text);
                        cmd.Parameters.AddWithValue("@phone", textBox4.Text);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Data Anggota berhasil di-update!", "Sukses");
                    TampilDataAnggota();
                    BersihkanForm();
                }
                catch (Exception ex) { MessageBox.Show("Gagal mengupdate: " + ex.Message); }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) return;

            DialogResult dr = MessageBox.Show($"Yakin ingin menghapus member {textBox2.Text}?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        // Hapus dari Member dulu (Child), baru User (Parent)
                        SqlCommand cmdMember = new SqlCommand("DELETE FROM Member WHERE UserID = @id", conn);
                        cmdMember.Parameters.AddWithValue("@id", textBox1.Text);
                        cmdMember.ExecuteNonQuery();

                        SqlCommand cmdUser = new SqlCommand("DELETE FROM [User] WHERE UserID = @id", conn);
                        cmdUser.Parameters.AddWithValue("@id", textBox1.Text);
                        cmdUser.ExecuteNonQuery();

                        MessageBox.Show("Anggota berhasil dihapus!", "Sukses");
                        TampilDataAnggota();
                        BersihkanForm();
                    }
                    catch (Exception ex) { MessageBox.Show("Gagal menghapus (Mungkin member masih meminjam buku): " + ex.Message); }
                }
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["ID Anggota"].Value.ToString();
                textBox2.Text = row.Cells["Nama Lengkap"].Value.ToString();
                textBox3.Text = row.Cells["Email"].Value.ToString();
                textBox4.Text = row.Cells["Nomor Telpon"].Value.ToString();

                // untuk cek status akun saat ini, kalau Suspend maka tombol akan berubah jadi Buka Suspend, kalau Aktif maka tombol tetap Suspend
                string statusSaatIni = row.Cells["Status"].Value.ToString();
                if (statusSaatIni == "Suspend")
                {
                    button2.Text = "Buka Suspend"; // Kalau lagi diblokir, tombol berubah jadi Buka Blokir
                }
                else
                {
                    button2.Text = "Suspend";
                }
                button2.Visible = true;
                button3.Visible = true; 
                button4.Visible = true;
            }
        }
    }
}
