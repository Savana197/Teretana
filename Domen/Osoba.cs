using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    /// <summary>
    /// Predstavlja osobu (člana teretane) - primaoca usluge kome se
    /// kreira članstvo.
    /// </summary>
    public class Osoba
    {
        /// <summary>Jedinstveni identifikator osobe.</summary>
        public int OsobaID { get; set; }
        /// <summary>Strani ključ ka kategoriji kojoj osoba pripada.</summary>
        public int KategorijaID { get; set; }
        /// <summary>Ime osobe.</summary>
        public required string Ime { get; set; }
        /// <summary>Prezime osobe.</summary>
        public required string Prezime { get; set; }
        /// <summary>Jedinstveni matični broj građana.</summary>
        public required string JMBG { get; set; }
        /// <summary>Datum rođenja osobe.</summary>
        public DateTime DatumRodjenja { get; set; }
        /// <summary>Email adresa osobe.</summary>
        public required string Email { get; set; }
        /// <summary>Adresa stanovanja osobe.</summary>
        public required string Adresa { get; set; }
        /// <summary>Broj telefona osobe.</summary>
        public required string BrojTelefona { get; set; }
    }
}
