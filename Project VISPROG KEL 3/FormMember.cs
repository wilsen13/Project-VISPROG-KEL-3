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

                halamanPeminjaman.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Halaman Peminjaman: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
