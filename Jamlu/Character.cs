using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamlu
{
    class Character
    {
        public int Armatura;
        public int Danno;
        public int Agilita;
        public int Resistenza;
        public int Vita;

        public void Danneggia(int danno)
        {
            if (danno > this.Armatura)
            {
                Console.WriteLine($"Armatura distrutta ({this.Armatura} danni arrecati)");
                danno -= this.Armatura;
                this.Armatura = 0;
                if (danno > this.Resistenza)
                {
                    Console.WriteLine($"Resistenza azzerata ({this.Resistenza} danni arrecati)");
                    danno -= this.Resistenza;
                    this.Resistenza = 0;
                    if (danno >= this.Vita)
                    {
                        Console.WriteLine($"Vita azzerata ({this.Vita} danni arrecati)");
                        this.Vita = 0;
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Arrecati {danno} danni ai punti vita");
                        this.Vita -= danno;
                        return;
                    }
                }
                else if (danno == this.Resistenza)
                {
                    Console.WriteLine($"Resistenza azzerata");
                    this.Resistenza = 0;
                    return;
                }
                else
                {
                    Console.WriteLine($"Arrecati {this.Resistenza} danni ai punti resistenza");
                    this.Resistenza -= danno;
                    return;
                }
            }
            else if (danno == this.Armatura)
            {
                Console.WriteLine($"Armatura distrutta");
                this.Armatura = 0;
                return;
            }
            else
            {
                Console.WriteLine($"Arrecati {danno} danni ai punti armatura");
                this.Armatura -= danno;
                return;
            }
        }
    }
}
