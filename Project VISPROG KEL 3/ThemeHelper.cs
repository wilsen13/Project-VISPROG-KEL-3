using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_VISPROG_KEL_3
{
    internal class ThemeHelper
    {
        public static void FormatTabel(DataGridView dgv)
        {
            // 1. Pengaturan Dasar Tabel
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false; // Ngilangin kolom panah abu-abu di ujung kiri
            dgv.AllowUserToAddRows = false; // Ngilangin baris kosong di paling bawah
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 2. Garis Pembatas (Cuma horizontal tipis kayak di gambar)
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(235, 235, 235);

            // 3. Desain Font & Warna Baris Normal
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(100, 100, 100); // Warna teks abu-abu gelap
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(237, 240, 255); // Ungu muda pas diklik
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowTemplate.Height = 45; // Bikin barisnya agak lega (padding)

            // 4. Desain Baris Selang-Seling (Zebra Cross)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 255);

            // 5. Desain Header (Warna Ungu/Biru)
            dgv.EnableHeadersVisualStyles = false; // WAJIB FALSE biar warnanya mau berubah
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(107, 126, 226); // Warna ungu/biru header
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 45;
        }
    }
}
