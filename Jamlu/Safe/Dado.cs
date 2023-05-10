using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamlu
{
    /// <summary>
    /// Classe per il controllo dei tiri dei dadi
    /// </summary>
    /// <remarks>
    /// Questa classe è utilizzata per controllare che un numero generato esternamente sia conforme con il dado specificato ed eventualmente richiederne uno nuovo.
    /// </remarks>
    public static class Dado
    {
        /// <summary>
        /// Controllo del tiro di un dado d4
        /// </summary>
        /// <param name="value">
        /// Il valore da controllare
        /// </param>
        /// <returns>
        /// Restituisce il numero controllato, compreso tra 1 e 4
        /// </returns>
        public static int D4(string value)
        {
            return value.SafeInt(1, 4);
        }

        /// <summary>
        /// Controllo del tiro di un dado d6
        /// </summary>
        /// <param name="value">
        /// Il valore da controllare
        /// </param>
        /// <returns>
        /// Restituisce il numero controllato, compreso tra 1 e 6
        /// </returns>
        public static int D6(string value)
        {
            return value.SafeInt(1, 6);
        }

        /// <summary>
        /// Controllo del tiro di un dado d20
        /// </summary>
        /// <param name="value">
        /// Il valore da controllare
        /// </param>
        /// <returns>
        /// Restituisce il numero controllato, compreso tra 1 e 20
        /// </returns>
        public static int D20(string value)
        {
            return value.SafeInt(1, 20);
        }
    }
}
