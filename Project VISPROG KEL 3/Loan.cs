using System;
using System.Collections.Generic;
using System.Text;

namespace Project_VISPROG_KEL_3
{
    public class Loan
    {
        public string LoanID { get; set; }
        public string BookID { get; set; }
        public string MemberID { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; } //'?' berarti tanggal bisa kosong jika buku belum dikembalikan

        public double CalculateFine()//logika menghitung denda jika member mengembalikan buku nya terlambat
        {
           
            return 0;
        }

        public void ProcessReturn()// fungsi untuk memproses pengembalian buku
        {
           
        }
    }
}
