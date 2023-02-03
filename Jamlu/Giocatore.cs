using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamlu
{
    class Giocatore : Character
    {
        public string Classe;
        public string Arma;
        public int Exp;
        public int Soldi;
        public Abilita Abilita;

        public Giocatore(int armatura, int danno, int agilita, int resistenza, int vita, string classe, string arma, Abilita abilita)
        {
            this.Classe = classe;
            this.Arma = arma;
            this.Armatura = armatura;
            this.Danno = danno;
            this.Agilita = agilita;
            this.Resistenza = resistenza;
            this.Vita = vita;
            Abilita = abilita;
        }

        public Giocatore()
        {

        }

        public void Attacca(Character nemico, bool usaAbilita)
        {
            if (usaAbilita)
            {

            }
        }

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
