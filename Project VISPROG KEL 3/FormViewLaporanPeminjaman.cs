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
        string connString = @"Data Source=.\SQLEXPRESS05;Initial Catalog=LibRaDB;Integrated Security=True;TrustServerCertificate=True;";
        string jenisLaporan = "";


        public FormViewLaporanPeminjaman(string perintahLaporan)
        {
            InitializeComponent();
            jenisLaporan = perintahLaporan;

        }

        private void FormViewLaporanPeminjaman_Load(object sender, EventArgs e)
        {
            try
            {
            
                string helperPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CrystalReportViewHelper.exe");


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = helperPath;
                psi.Arguments = jenisLaporan;
                psi.UseShellExecute = true;

                Process.Start(psi);

                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyambungkan ke Crystal Report Viewer: " + ex.Message);
            }
        }
    }
}
