using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamlu
{
    public static class Exts
    {
        public static int SafeInt(this string value, int min, int max)
        {
            int val = int.MinValue;
            do
            {
                try
                {
                    val = int.Parse(value);
                    if (val < min || val > max)
                    {
                        Console.WriteLine(Frasi.GetFrase(TipoFrase.NumeroErrato, value, min, max));
                        value = Console.ReadLine();
                    }
                }
                catch
                {
                    Console.WriteLine(Frasi.GetFrase(TipoFrase.NumeroErrato, value, min, max));
                    value = Console.ReadLine();
                }
            }
            while (val < min || val > max);
            return val;
        }

        public static int SafeInt(this string value)
        {
            int val = int.MinValue;
            do
            {
                try
                {
                    val = int.Parse(value);
                }
                catch
                {
                    Console.WriteLine(Frasi.GetFrase(TipoFrase.NumeroErrato, value, int.MinValue, int.MaxValue));
                    value = Console.ReadLine();
                }
            }
            while (val == int.MinValue);
            return val;
        }
    }
}
