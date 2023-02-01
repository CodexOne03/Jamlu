using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamlu
{
    public class Frasi
    {
        static string[] numeroErrato =
        {
            "Riprova",
            "Non so Rick, secondo me hai sbagliato a scrivere",
            "Ritenta, sarai più fortunato",
            "Mi sa che non volevi scrivere quello",
            "",//Sono piuttosto sicuro che {value} non sia un numero valido
            ""//Pensavo sapessi scrivere almeno un numero tra {min} e {max}, ma a quanto pare mi sbagliavo
        };

        static string[] nemicoDistrutto =
        {
            "Hai fatto il culo al nemico. (Oneshot)",
            "Ti sei almeno accorto che ci fosse un nemico prima di Oneshottarlo? (Oneshot)",
            "Hai disintegrato il nemico con un colpo, F. (Oneshot)",
            "Potresti anche andarci piano, Tryhardone. (Oneshot)",
            "Hai distrutto il nemico con un colpo, lol. (Oneshot)",
            "Se qualcuno mi bullizzerà, ora so chi chiamare. (Oneshot)",
            "Chiunque a questo mondo dovrebbe avere paura di te. (Oneshot)",
            "Ti prego non mi picchiare. (Oneshot)"
        };

        static string[] giocatoreDistrutto =
        {
            "Il nemico ti ha fatto il culo. (Oneshot)",
            "Ti sei almeno accorto che ci fosse un nemico prima di essere Oneshottato? (Oneshot)",
            "Il nemico ti ha disintegrato con un colpo, F. (Oneshot)",
            "Il nemico ti ha inculato senza vasellina. (Oneshot)",
            "Il nemico ti ha distrutto con un colpo, lol. (Oneshot)",
            "Se qualcuno mi bullizzerà, ora so di dover chiamare il nemico. (Oneshot)",
            "Chiunque a questo mondo dovrebbe avere paura del nemico. (Oneshot)",
            "Il nemico ti ha stracciato. (Oneshot)"
        };

        public static string GetFrase(TipoFrase tipo, string value, int min, int max)
        {
            Random random = new Random();
            switch (tipo)
            {
                case TipoFrase.NumeroErrato:
                    int r = random.Next(0, numeroErrato.Length);
                    if (r == 4)
                    {
                        return $"Sono piuttosto sicuro che \"{value}\" non sia un numero valido";
                    }
                    else if (r == 5)
                    {
                        return $"Pensavo sapessi scrivere almeno un numero tra {min} e {max}, ma a quanto pare mi sbagliavo";
                    }
                    else
                    {
                        return numeroErrato[r];
                    }
                case TipoFrase.NemicoDistrutto:
                    r = random.Next(0, nemicoDistrutto.Length);
                    return nemicoDistrutto[r];
                case TipoFrase.GiocatoreDistrutto:
                    r = random.Next(0, giocatoreDistrutto.Length);
                    return giocatoreDistrutto[r];
            }
            return null;
        }

        public static string GetFrase(TipoFrase tipo)
        {
            Random random = new Random();
            switch (tipo)
            {
                case TipoFrase.NumeroErrato:
                    int r = random.Next(0, numeroErrato.Length);
                    if (r == 4)
                    {
                        return numeroErrato[3];
                    }
                    else if (r == 5)
                    {
                        return numeroErrato[2];
                    }
                    else
                    {
                        return numeroErrato[r];
                    }
                case TipoFrase.NemicoDistrutto:
                    r = random.Next(0, nemicoDistrutto.Length);
                    return nemicoDistrutto[r];
                case TipoFrase.GiocatoreDistrutto:
                    r = random.Next(0, giocatoreDistrutto.Length);
                    return giocatoreDistrutto[r];
            }
            return null;
        }
    }

    public enum TipoFrase
    {
        NumeroErrato,
        NemicoDistrutto,
        GiocatoreDistrutto
    }
}
