using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Komunikacija
{
    /// <summary>
    /// Predstavlja odgovor servera na zahtev klijenta - sadrži informaciju o uspešnosti
    /// izvršene operacije, eventualnu poruku o grešci i rezultujući objekat (ako postoji).
    /// </summary>
    public class Odgovor
    {
        /// <summary>
        /// Da li je operacija na serveru uspešno izvršena.
        /// </summary>
        public bool Uspesno { get; set; }

        /// <summary>
        /// Tekst greške ako operacija nije uspela; prazan string ako je operacija uspešna.
        /// </summary>
        public string Greska { get; set; } = string.Empty;

        /// <summary>
        /// Rezultat operacije (npr. objekat, lista objekata ili null ako operacija ne vraća podatke).
        /// </summary>
        public object? Objekat { get; set; }
    }
}
