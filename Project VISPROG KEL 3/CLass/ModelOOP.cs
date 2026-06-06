using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_VISPROG_KEL_3.CLass
{
    public class UserBase
    {
        public string UserID { get; set; }
        public string Nama { get; set; }
        public string Email { get; set; }

        // encapsulation: password disembunyiin dari luar
        private string passwordRahasia;

        public void SetPassword(string pass) { passwordRahasia = pass; }
        public bool CekPassword(string inputPass) { return passwordRahasia == inputPass; }

        // virtual method biar bisa ditindih sama class anaknya (polymorphism)
        public virtual string TampilInfo()
        {
            return $"ID: {UserID} | Nama: {Nama}";
        }
    }

    // member (mewarisi dari userbase)
    public class MemberApp : UserBase
    {
        public int MaxBooksLimit { get; set; }

        public override string TampilInfo()
        {
            return base.TampilInfo() + $" | Role: Member | Max Pinjam: {MaxBooksLimit} Buku";
        }
    }

    // admin (mewarisi dari userbase)
    public class AdminApp : UserBase
    {
        public string ShiftKerja { get; set; }

        public override string TampilInfo()
        {
            return base.TampilInfo() + $" | Role: Pustakawan | Shift: {ShiftKerja}";
        }
    }

    //class dasar untuk urusan cetak dokumen
    public abstract class DokumenSistem
    {
        public string JudulDokumen { get; set; }
        public DateTime TanggalDibuat { get; set; }

        // abstract method yang wajib dijalanin sama child-nya
        public abstract string BuatHeaderDokumen();
    }

    //dokumen khusus untuk diekspor ke txt
    public class EksporRiwayatTxt : DokumenSistem
    {
        public string NamaPengekspor { get; set; }

        public override string BuatHeaderDokumen()
        {
            return $"=== {JudulDokumen} ===\r\nDicetak pada: {TanggalDibuat}\r\nOleh: {NamaPengekspor}\r\n-----------------------------";
        }
    }
}
