using System;
using System.Collections.Generic;
using System.Text;

namespace Modul5_Kel7
{
    class userService
    {
        private string[,] data;
        private string[,] histories;
        private string email, password, roles = "";
        int book;

        public userService(string emails, string passwords)
        {
            email = emails;
            password = passwords;
            data = new string[2, 3] {
                {"Bowokelompok07@gmail.com", "12345", "superadmin" },
                {"Gustikelompok07@gmail.com", "12345", "user"  }
            };
            histories = new string[2, 4]
            {
                {"Nama1elompokxx@gamil.com", "Fisika Dasar", "Dasar Komputer dan Pemrograman", "25-04-2020" },
                {"Nama2kelompokxx@gamil.com", "Dasar Komputer dan Pemrograman", "Konsep Jaringan Komputer", "25-04-2020" }
            };
        }

        public void login()
        {
            var (status, role) = checkCredentials();
            if (status == true)
            {
                Console.WriteLine("\nWelcome " + role);
                Console.WriteLine("Logged it as user email: " + email);
                Console.WriteLine(email + " Meminjam buku : ");
                for(int i=1; i<3; i++)
                {
                    Console.WriteLine(histories[book, i]);
                }
                Console.WriteLine("Tanggal Peminjaman : "+ histories[book, 3]);
            }
            else
            {
                Console.WriteLine("\nInvalid Login");
            }
        }
        private (bool, string) checkCredentials()
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (data[i, 0] == email && data[i, 1] == password)
                {
                    if (data[i, 0] == histories[i, 0])
                        book = i;
                    roles = data[i, 2];
                    return (true, roles);
                }
            }
            return (false, roles);
        }
    }
}
