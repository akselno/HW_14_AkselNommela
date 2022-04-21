using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EX_04_StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Accounts accounts = new Accounts();
            Console.WriteLine(accounts.FindUserName("aksel.nommela@gmail.com"));
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(accounts.CreateUsername("Ülar Älly Tõnis Öölaps"));
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(accounts.CreateEmailAddress("Juhan Mati Kalle Juurikas Company"));
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(accounts.CreateDomainAccount("Juhan Mati Kalle Juurikas Company"));

        }
    }
}
        
    