using System;
using System.Collections.Generic;
using System.Text;

namespace Project_VISPROG_KEL_3
{
    internal class Librarian : User 
    {
        public string EmployeeID { get; set; }
        public string Shift { get; set; }

        public void AddBook(Book newBook, List<Book> databaseBuku)// fungsi untuk menambahkan buku baru 
        {
            databaseBuku.Add(newBook); 
        }

        public void RemoveBook(Book hapusBuku, List<Book> databaseBuku)// fungsi untuk menghapus buku
        {
            databaseBuku.Remove(hapusBuku);
        }

        public void RegisterMember()// fungsi untuk mendaftarkan member baru
        {
            
        }

        public void GenerateReport()//fungsi untuk generate laporan perpustakaan 
        {
            
        }
    }
}
