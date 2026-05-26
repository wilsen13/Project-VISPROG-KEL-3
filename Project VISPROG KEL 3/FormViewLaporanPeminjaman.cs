using Microsoft.Data.SqlClient;
using System;
using System.Diagnostics;
using System.IO;
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
    public partial class FormViewLaporanPeminjaman : Form
    {
        // naruh string koneksi sql server (walaupun di file ini ga kepake sih sebenernya, tapi biarin aja buat formalitas)
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";

        // siapin variabel kosong buat nampung jenis laporan yang mau dibuka
        string jenisLaporan = "";

        // form ini nerima lemparan parameter kata kunci dari form admin (misal kata kuncinya "Pinjam" atau "Buku")
        public FormViewLaporanPeminjaman(string perintahLaporan)
        {
            InitializeComponent();

            // tangkep kata kunci yang dilempar, terus simpen ke variabel global kita
            jenisLaporan = perintahLaporan;
        }

        // fungsi yang langsung otomatis jalan pas form ini dipanggil pake fungsi .Show()
        private void FormViewLaporanPeminjaman_Load(object sender, EventArgs e)
        {
            try
            {
                // karena kita pake trik ngebuka crystal report lewat aplikasi exe terpisah,
                // ini kita nyari dulu lokasi file helper exe-nya di dalem folder project kita
                string helperPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CrystalReportViewHelper.exe");

                // nyiapin konfigurasi buat ngejalanin program eksternal
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = helperPath; // targetin ke file exe yang udah kita temuin tadi

                // nah ini penting, kita masukin kata kuncinya ke argumen
                // biar si aplikasi helper tau dia harus nge-load desain laporan yang mana
                psi.Arguments = jenisLaporan;
                psi.UseShellExecute = true; // izinin windows buat ngejalanin filenya

                // gas eksekusi buka program helpernya
                Process.Start(psi);

                // karena jendela laporannya udah kebuka di aplikasi helper, 
                // form kosong ini langsung ditutup aja seketika biar ga menuh-menuhin taskbar
                this.Close();
            }
            catch (Exception ex)
            {
                // kalo misal file exe-nya ga ketemu atau ada error lain pas ngebuka
                MessageBox.Show("Gagal menyambungkan ke Crystal Report Viewer: " + ex.Message);
            }
        }
    }
}