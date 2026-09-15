namespace Common.Komunikacija
{
    /// <summary>
    /// Vrste sistemskih operacija koje klijent može da zatraži od servera.
    /// </summary>
    public enum Operacija
    {
        /// <summary>Kreiranje nove kvalifikacije.</summary>
        KreirajKvalifikaciju,
        /// <summary>Prijava korisnika (radnika) na sistem preko email-a i šifre.</summary>
        Prijava,
        /// <summary>Pronalaženje aktivnog članstva date osobe.</summary>
        VratiAktivnoClanstvoOsobe,
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
        /// <summary>Izmena podataka trenera, uključujući status aktivnosti.</summary>
        PromeniTrenera,
        /// <summary>Vraćanje liste svih aktivnih trenera.</summary>
        VratiSveAktivneTrenere,
        /// <summary>Kreiranje novog članstva za osobu.</summary>
        KreirajClanstvo,
        /// <summary>Otkazivanje postojećeg članstva.</summary>
        OtkaziClanstvo,
        /// <summary>Izračunavanje ukupne cene članstva na osnovu stavki članstva.</summary>
        IzracunajUkupnuCenuClanstva,
        /// <summary>Dodela kvalifikacije radniku.</summary>
        DodeliKvalifikacijuRadniku,
        /// <summary>Dodavanje nove stavke (treninga) u okviru postojećeg članstva.</summary>
        DodajStavkuClanstva,
        /// <summary>Vraćanje liste svih kvalifikacija (šifarnik).</summary>
        VratiSveKvalifikacije,
        /// <summary>Vraćanje liste svih kategorija.</summary>
        VratiSveKategorije
    }
}
