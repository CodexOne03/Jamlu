using Jamlu.Safe;
using System;

namespace Jamlu
{
    public class Abilita
    {
        public TipoAbilita Tipo;
        public string Nome;
        //public int Ricarica = 3;

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
            int scelta = Console.ReadLine().SafeInt(1, 3) - 1;
            this.Tipo = (TipoAbilita)scelta;
            this.Nome = Testo.SN("Scrivi il nome dell'abilità:");
            //Console.WriteLine("Scrivi la quantità di turni impiegati per poter riutilizzare l'abilità:");
            //this.Ricarica = Console.ReadLine().SafeInt();
        }/*

        public int Usa(int dannoIniziale)
        {
            switch (this.Tipo)
            {
                case TipoAbilita.SerieColpi:

            }
        }*/
    }
}
