using System;
using System.Collections.Generic;
using System.Text;

namespace Project_VISPROG_KEL_3
{
    internal class Session
    {
        public static string UserID { get; set; }
        public static string Role { get; set; }

        public static void Clear()//method untuk menghapus data saat melakukan log out
        {
            UserID = null;
            Role = null;
        }
    }
}
