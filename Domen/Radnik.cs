using System.Security.Principal;

namespace Domen
{
    /// <summary>
    /// Predstavlja zaposlenog (radnika) koji upravlja sistemom teretane -
    /// kreira, menja i pretražuje članstva, osobe, trenere i šifarnike.
    /// </summary>
    public class Radnik
    {
        /// <summary>Jedinstveni identifikator radnika.</summary>
        public int RadnikID { get; set; }
        /// <summary>Ime radnika.</summary>
        public required string Ime { get; set; }
        /// <summary>Prezime radnika.</summary>
        public required string Prezime { get; set; }
        /// <summary>Šifra za prijavu na sistem.</summary>
        public required string Sifra { get; set; }
        /// <summary>Email adresa - koristi se i kao identifikator prilikom prijave.</summary>
        public required string Email { get; set; }
        /// <summary>Broj telefona radnika.</summary>
        public required string BrojTelefona { get; set; }
        /// <summary>Da li je radnik trenutno aktivan (zaposlen) u sistemu.</summary>
        public bool Aktivan { get; set; }

    }
}
