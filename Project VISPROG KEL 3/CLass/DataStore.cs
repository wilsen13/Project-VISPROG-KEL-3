using System;
using System.Collections.Generic;
using System.Text;

namespace Project_VISPROG_KEL_3
{
    internal class DataStore
    {
        public static Book[] ArrayBuku = new Book[] //array data buku 
        {
            new Book { BookID = "B001", JudulBuku = "Buku 1", Penulis = "Wilsen Gomes", TahunTerbit = "2025", TipeBuku = "Nonfiksi", Status = "Tersedia" },
            new Book { BookID = "B002", JudulBuku = "Buku 2", Penulis = "Rafly Ahmad", TahunTerbit = "2026", TipeBuku = "Nonfiksi", Status = "Tersedia" },
            new Book { BookID = "B003", JudulBuku = "Buku 3", Penulis = "Fiksi Penulis", TahunTerbit = "2024", TipeBuku = "Fiksi", Status = "Tersedia" }
        };

        public static Loan[] ArrayPeminjaman = new Loan[0];//array yang mengatur peminjaman, awalnya 0 karena belum ada peminjaman

        public static Member PenggunaAktif = new Member //simulasi ada member yang aktif
        {
            MemberID = "M001",
            Name = "Anggota Test",
            MaxBooksLimit = 3
        };
    }
}
