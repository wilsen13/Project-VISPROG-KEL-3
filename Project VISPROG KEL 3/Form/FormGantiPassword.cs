using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_VISPROG_KEL_3
{
    public partial class FormGantiPassword : Form
    {
        // naruh string koneksi buat nyambungin aplikasi ke database sql server lokal
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";

        // siapin variabel buat nampung id, meski ujung-ujungnya kita narik dari session login
        private string idUserTarget = "";

        public FormGantiPassword()
        {
            InitializeComponent();
        }

        // fungsi bawaan kalo label diklik, biarin kosong aja ga ngefek
        private void label1_Click(object sender, EventArgs e)
        {

        }

        // jalan otomatis pas form dibuka, karena ga butuh apa-apa dikosongin aja
        private void FormGantiPassword_Load(object sender, EventArgs e)
        {

        }

        // nah ini inti kodingannya, dieksekusi pas tombol simpan diklik
        private void button1_Click(object sender, EventArgs e)
        {
            // ngecek dulu nih, takutnya ada textbox yang masih kosong alias belum diisi
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Password baru dan konfirmasi wajib diisi bro!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // paksa stop kodingannya di sini, jangan lanjut proses ke bawah
                return;
            }

            // validasi kedua, mastiin password baru sama ketikan konfirmasinya beneran sama persis
            if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("Password baru dan konfirmasi tidak cocok! Coba ketik ulang.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // bungkus pake try catch biar kalo database tiba-tiba ngambek, aplikasi ga langsung force close
            try
            {
                // bikin dan buka jembatan koneksi ke database sql
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // bikin query sql buat ngubah password di tabel user berdasarkan userid yang lagi login
                    // dikasih fungsi trim biar aman kalo misal ada spasi nyasar di id-nya
                    string queryUpdate = "UPDATE [User] SET Password = @passBaru WHERE TRIM(UserID) = @id";

                    // nyiapin perintah sql-nya buat dikirim ke database
                    using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conn))
                    {
                        // masukin isi textbox password baru ke dalem parameter sql
                        cmdUpdate.Parameters.AddWithValue("@passBaru", textBox1.Text);

                        // narik userid orang yang lagi login pake fungsi session kita
                        cmdUpdate.Parameters.AddWithValue("@id", Session.UserID.Trim());

                        // jalanin eksekusi update-nya, terus simpen status angkanya ke dalem variabel rowsaffected
                        int rowsAffected = cmdUpdate.ExecuteNonQuery();

                        // ngecek kalo angkanya lebih dari 0 (artinya ada baris di tabel yang sukses keubah)
                        if (rowsAffected > 0)
                        {
                            // kasih notif sukses ke user kalo passwordnya udah aman
                            MessageBox.Show("Password sukses diganti!", "Aman", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // langsung auto tutup form ganti passwordnya setelah beres
                            this.Close();
                        }
                        else
                        {
                            // ini buat jaga-jaga doang misal entah kenapa userid-nya ga ketemu di database
                            MessageBox.Show($"'{idUserTarget}' tidak ditemukan di database.\n\nSilahkan Coba Kembali!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // kalo ada error kodingan atau server, munculin pesan error aslinya biar gampang kita cari penyakitnya
                MessageBox.Show("Gagal, Silahkan coba lagi!: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}