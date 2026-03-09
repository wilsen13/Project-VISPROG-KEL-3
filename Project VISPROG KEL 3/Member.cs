using System;
using System.Collections.Generic;
using System.Text;

namespace Project_VISPROG_KEL_3
{
    internal class Member : User
    {
        public string MemberID { get; set; }
        public int MaxBooksLimit { get; set; }// limit maksimal peminjaman buku

        public void BorrowBook()// fungsi untuk member jika ingin meminjam buku
        {
          
        }

        public void ReturnBook()// fungsi yang mengatur member jika inign mengembalikan buku
        {
            
        }

        public void ViewHistory() // fungsi melihat histori pinjaman untuk member
        {
            
        }
    }
}
