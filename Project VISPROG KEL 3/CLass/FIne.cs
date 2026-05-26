using System;
using System.Collections.Generic;
using System.Text;

namespace Project_VISPROG_KEL_3
{
    internal class FIne
    {
        public string FineID { get; set; }
        public string LoanID { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; } //status denda (lunas/belum lunas)
        public void CalculateAmount()// logika untuk menghitung jumlah denda berdasarkan hari keterlambatan pengembalian buku
        {
            
        }

        public void UpdatePaymentStatus()// fungsi untuk memperbarui status pembayaran denda
        {
           
        }
    }
}
