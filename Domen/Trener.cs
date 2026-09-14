using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    /// <summary>
    /// Predstavlja trenera koji je dodeljen jednoj ili više stavki članstva
    /// (npr. individualni ili grupni treninzi).
    /// </summary>
    public class Trener
    {
        /// <summary>Jedinstveni identifikator trenera.</summary>
        public int TrenerID { get; set; }
        /// <summary>Ime trenera.</summary>
        public required string Ime { get; set; }
        /// <summary>Prezime trenera.</summary>
        public required string Prezime { get; set; }
        /// <summary>Oblast u kojoj je trener specijalizovan (npr. Fitnes, Joga, Pilates).</summary>
        public required string Specijalnost { get; set; }
        /// <summary>Broj telefona trenera.</summary>
        public required string BrojTelefona { get; set; }
        /// <summary>Email adresa trenera.</summary>
        public required string Email { get; set; }
        /// <summary>Broj godina radnog iskustva trenera.</summary>
        public int GodineIskustva { get; set; }
        /// <summary>Da li je trener trenutno aktivan (dostupan za dodelu treninga).</summary>
        public bool Aktivan { get; set; }
    }
}
