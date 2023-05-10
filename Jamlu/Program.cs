using System;
using Jamlu.Safe;

namespace Jamlu
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                #region CreaGiocatore
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
                #endregion
                #region CreaNemico
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
                #endregion
                #region Attacchi
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
                #endregion
                Console.WriteLine("Spawnare un altro nemico? (s/n)");
            }
            while (Console.ReadLine().ToLower().Contains("s"));
        }
    }
}
