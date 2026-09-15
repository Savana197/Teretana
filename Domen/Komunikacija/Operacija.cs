using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Komunikacija
{
    /// <summary>
    /// Vrste sistemskih operacija koje klijent može da zatraži od servera.
    /// </summary>
    public enum Operacija
    {
        /// <summary>Prijava korisnika (radnika) na sistem preko email-a i šifre.</summary>
        Prijava,

        /// <summary>Kreiranje novog radnika.</summary>
        KreirajRadnika,

        /// <summary>Izmena podataka postojećeg radnika.</summary>
        PromeniRadnika,

        /// <summary>Deaktiviranje radnika (soft delete preko Aktivan flag-a).</summary>
        DeaktivirajRadnika,

        /// <summary>Pretraga radnika po zadatim kriterijumima.</summary>
        PretraziRadnika,

        /// <summary>Kreiranje nove osobe (člana teretane).</summary>
        KreirajOsobu,

        /// <summary>Izmena podataka postojeće osobe.</summary>
        PromeniOsobu,

        /// <summary>Brisanje osobe.</summary>
        ObrisiOsobu,

        /// <summary>Pretraga osoba po zadatim kriterijumima.</summary>
        PretraziOsobu,

        /// <summary>Kreiranje novog trenera.</summary>
        KreirajTrenera,

        /// <summary>Brisanje trenera.</summary>
        ObrisiTrenera,

        /// <summary>Vraćanje liste svih trenera.</summary>
        VratiSveTrenere,

        /// <summary>Kreiranje novog članstva za osobu.</summary>
        KreirajClanstvo,

        /// <summary>Otkazivanje postojećeg članstva.</summary>
        OtkaziClanstvo,

        /// <summary>Izračunavanje ukupne cene članstva na osnovu stavki članstva.</summary>
        IzracunajUkupnuCenuClanstva,

        /// <summary>Dodela kvalifikacije radniku.</summary>
        DodeliKvalifikacijuRadniku,

        /// <summary>Vraćanje liste kvalifikacija radnika kojima je istekao rok važenja.</summary>
        VratiIstekleKvalifikacije
    }

}
