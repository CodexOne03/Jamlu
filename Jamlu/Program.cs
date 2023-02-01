using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamlu
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Giocatore giocatore = new Giocatore();
                Console.WriteLine("Inserisci la tua armatura:");
                giocatore.Armatura = Console.ReadLine().SafeInt();
                Console.WriteLine("Inserisci il tuo danno:");
                giocatore.Danno = Console.ReadLine().SafeInt();
                Console.WriteLine("Inserisci la tua agilità:");
                giocatore.Agilita = Console.ReadLine().SafeInt();
                Console.WriteLine("Inserisci la tua resistenza:");
                giocatore.Resistenza = Console.ReadLine().SafeInt();
                Console.WriteLine("Inserisci la tua vita:");
                giocatore.Vita = Console.ReadLine().SafeInt();
                Nemico nemico = new Nemico();
                Console.WriteLine("È apparso un nemico!");
                Console.WriteLine("Tira un D4 per il suo livello:");
                nemico.Livello = Dado.D4(Console.ReadLine());
                Console.WriteLine($"Tira un D6 per la sua armatura: (+{nemico.Livello} per il livello)");
                nemico.Armatura = Dado.D6(Console.ReadLine()) + nemico.Livello;
                if (nemico.Livello < 4)
                {
                    Console.WriteLine($"Tira un D6 per il suo danno: (+{nemico.Livello} per il livello)");
                    nemico.Danno = Dado.D6(Console.ReadLine()) + nemico.Livello;
                }
                else
                {
                    Console.WriteLine($"Tira un D6 per il suo danno:");
                    nemico.Danno = Dado.D6(Console.ReadLine()) + 8;
                    Console.WriteLine($"+8 danno per livello 4 ({nemico.Danno})");
                }
                Console.WriteLine($"Tira un D6 per la sua agilità: (+{nemico.Livello} per il livello)");
                nemico.Agilita = Dado.D6(Console.ReadLine()) + nemico.Livello;
                Console.WriteLine($"Tira un D6 per la sua resistenza: (+{nemico.Livello} per il livello)");
                nemico.Resistenza = Dado.D6(Console.ReadLine()) + nemico.Livello;
                if (nemico.Livello < 4)
                {
                    Console.WriteLine($"Tira un D6 per la sua vita: (+{nemico.Livello} per il livello)");
                    nemico.Vita = Dado.D6(Console.ReadLine()) + nemico.Livello;
                }
                else
                {
                    nemico.Vita = 24;
                    Console.WriteLine("La vita del nemico è 24");
                }
                int numeroAttacchi = Math.Max(giocatore.Agilita / nemico.Agilita, 1);
                Console.WriteLine($"Il tuo personaggio attaccherà {numeroAttacchi} volte per turno");
                bool turnoGiocatore = giocatore.Agilita > nemico.Agilita;
                if (turnoGiocatore)
                {
                    Console.WriteLine("Il tuo personaggio ha il primo turno");
                }
                else
                {
                    Console.WriteLine("Il nemico ha il primo turno");
                }
                int dannoTotale = giocatore.Danno * numeroAttacchi;
                Console.WriteLine($"Il tuo personaggio farà {dannoTotale} punti danno ad ogni turno");
                int turno = 1;
                do
                {
                    Console.Write($"{turno}° turno ");
                    if (turnoGiocatore)
                    {
                        Console.WriteLine("al giocatore");
                        Console.WriteLine($"Il giocatore arreca {dannoTotale} punti danno");
                        nemico.Danneggia(dannoTotale);
                        if (nemico.Vita == 0)
                        {
                            if (turno == 1)
                            {
                                Console.WriteLine(Frasi.GetFrase(TipoFrase.NemicoDistrutto));
                            }
                            else
                            {
                                Console.WriteLine("Il nemico è morto");
                            }
                            Console.WriteLine("I tuoi stats:");
                            Console.WriteLine($"Armatura: {giocatore.Armatura}");
                            Console.WriteLine($"Resistenza: {giocatore.Resistenza}");
                            Console.WriteLine($"Vita: {giocatore.Vita}");
                        }
                        else
                        {
                            Console.WriteLine($"Il nemico ha {nemico.Armatura} punti armatura, {nemico.Resistenza} punti resistenza e {nemico.Vita} punti vita");
                        }
                        turnoGiocatore = !turnoGiocatore;
                    }
                    else
                    {
                        Console.WriteLine("al nemico");
                        Console.WriteLine($"Il nemico arreca {nemico.Danno} punti danno");
                        giocatore.Danneggia(nemico.Danno);
                        if (giocatore.Vita == 0)
                        {
                            if (turno == 1)
                            {
                                Console.WriteLine(Frasi.GetFrase(TipoFrase.GiocatoreDistrutto));
                            }
                            else
                            {
                                Console.WriteLine("Il tuo personaggio è morto");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Il tuo personaggio ha {giocatore.Armatura} punti armatura, {giocatore.Resistenza} punti resistenza e {giocatore.Vita} punti vita");
                        }
                        turnoGiocatore = !turnoGiocatore;
                    }
                    Console.ReadLine();
                    turno++;
                }
                while (giocatore.Vita > 0 && nemico.Vita > 0);
                Console.WriteLine("Spawnare un altro nemico? (s/n)");
            }
            while (Console.ReadLine().ToLower().Contains("s"));
        }
    }

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

    class Nemico : Character
    {
        public int Livello;
        public Nemico(int armatura, int danno, int agilita, int resistenza, int vita, int livello)
        {
            this.Armatura = armatura;
            this.Danno = danno;
            this.Agilita = agilita;
            this.Resistenza = resistenza;
            this.Vita = vita;
            this.Livello = livello;
        }
        public Nemico()
        {

        }
    }

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
    }

    public class Abilita
    {
        public TipoAbilita Tipo;
        public string Nome;
        public int Ricarica = 3;

        public Abilita(TipoAbilita tipo, string nome)
        {
            this.Tipo = tipo;
            this.Nome = nome;
        }

        public Abilita()
        {
            Console.WriteLine("Seleziona il tipo di abilita:");
            Console.WriteLine("1\t-\tSerie colpi: Tira un dado D4 all'inizio del tuo turno per segnare la quatità di colpi in serie che verranno tirati");
            Console.WriteLine("2\t-\tRange danni: Tira un dado D4 all'inizio del tuo turno per segnare il range di danni da apportare al nemico, poi tira un altro D4 per segnare il numero nel range indicato");
            Console.WriteLine("3\t-\tDanni bonus: Tira un dado D4 all'inizio del tuo turno per segnare la quantità di danni bonus da infliggere al nemico nel turno corrente");
            int scelta = Console.ReadLine().SafeInt(1, 3);
            string sicuro = "n";
            do
            {
                Console.WriteLine("Scrivi il nome dell'abilità:");
                this.Nome = Console.ReadLine();
                Console.WriteLine($"Hai scritto \"{this.Nome}\"\nSei sicuro? (s/n)");
                sicuro = Console.ReadLine();
            }
            while (!sicuro.ToLower().Contains("s"));
            Console.WriteLine("Scrivi la quantità di turni impiegati per poter riutilizzare l'abilità:");
            this.Ricarica = Console.ReadLine().SafeInt();
        }
    }

    public enum TipoAbilita
    {
        SerieColpi,
        RangeDanni,
        DanniBonus
    }
}
