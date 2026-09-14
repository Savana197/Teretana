using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    /// <summary>Vrsta treninga koji stavka članstva pokriva.</summary>
    public enum VrstaTreninga
    {
        /// <summary>Individualni (personalni) trening.</summary>
        Individualni,
        /// <summary>Grupni trening.</summary>
        Grupni
    }
    /// <summary>
    /// Asocijativna klasa koja predstavlja jednu stavku u okviru članstva -
    /// povezuje članstvo sa trenerom i definiše vrstu i broj treninga.
    /// </summary>
    public class StavkaČlanstva
    {
        /// <summary>Redni broj stavke unutar članstva (deo složenog ključa).</summary>
        public int Rb { get; set; }
        /// <summary>Strani ključ ka članstvu kom stavka pripada (deo složenog ključa).</summary>
        public int ČlanstvoID { get; set; }
        /// <summary>Strani ključ ka treneru koji vodi ovu stavku treninga.</summary>
        public int TrenerID { get; set; }
        /// <summary>Vrsta treninga (individualni ili grupni).</summary>
        public VrstaTreninga VrstaTreninga { get; set; }
        /// <summary>Ukupan broj termina uključenih u ovu stavku.</summary>
        public int BrojTermina { get; set; }
        /// <summary>Broj do sada iskorišćenih termina.</summary>
        public int Iskorišćeno { get; set; }
        /// <summary>Cena ove stavke članstva.</summary>
        public decimal CenaStavke { get; set; }
    }
}
