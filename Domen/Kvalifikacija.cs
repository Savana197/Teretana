using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    /// <summary>Nivo stručnosti povezan sa kvalifikacijom.</summary>
    public enum Nivo
    {
        /// <summary>Osnovni nivo kvalifikacije.</summary>
        Osnovni,
        /// <summary>Napredni nivo kvalifikacije.</summary>
        Napredni,
        /// <summary>Ekspertski nivo kvalifikacije.</summary>
        Ekspert

    }
    /// <summary>
    /// Šifarnik kvalifikacija (sertifikata) koje radnik može posedovati
    /// (npr. Fitnes instruktor, Nutricionista).
    /// </summary>
    public class Kvalifikacija
    {
        /// <summary>Jedinstveni identifikator kvalifikacije.</summary>
        public int KvalifikacijaID { get; set; }
        /// <summary>Naziv kvalifikacije.</summary>
        public required string Naziv { get; set; }
        /// <summary>Nivo stručnosti ove kvalifikacije.</summary>
        public Nivo Nivo { get; set; }

    }
}
