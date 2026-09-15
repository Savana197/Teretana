using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Komunikacija
{
    /// <summary>
    /// Predstavlja zahtev koji klijent šalje serveru - sadrži vrstu operacije koja se
    /// izvršava i objekat sa podacima potrebnim za tu operaciju.
    /// </summary>
    public class Zahtev
    {
        /// <summary>
        /// Vrsta operacije koju server treba da izvrši.
        /// </summary>
        public Operacija Operacija { get; set; }

        /// <summary>
        /// Podaci potrebni za izvršenje operacije (npr. domenski objekat, ID, kriterijum pretrage).
        /// </summary>
        public required object Objekat { get; set; }
    }
}
