using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamlu.Safe
{
    class Testo
    {
        public static string SN(string testo)
        {
            string sicuro = "n";
            string @out;
            do
            {
                Console.WriteLine(testo);
                @out = Console.ReadLine();
                Console.WriteLine($"Hai scritto \"{@out}\"\nSei sicuro? (s/n)");
                sicuro = Console.ReadLine();
            }
            while (!sicuro.ToLower().Contains("s"));
            return @out;
        }
    }
}
