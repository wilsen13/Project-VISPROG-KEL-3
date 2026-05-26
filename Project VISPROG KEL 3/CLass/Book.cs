using System;
using System.Collections.Generic;
using System.Text;

namespace Project_VISPROG_KEL_3
{
    internal class Book
    {
        public string BookID { get; set; }// id buku , untuk membedakan buku satu dengan yang lain 
        public string JudulBuku { get; set; }
        public string Penulis { get; set; }
        public String TipeBuku { get; set; }
        public string TahunTerbit { get; set; }
        public string Status { get; set; }

        public void UpdateStatus()// fungsi untuk update status buku (tersedia/di pinjam)
        {
            
        }
    }
}
