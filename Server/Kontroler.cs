using Common.Domen;
using SistemskeOperacije;

namespace Server
{
    /// <summary>
    /// Singleton kontroler koji prosleđuje zahteve odgovarajućim sistemskim
    /// operacijama i vraća njihove rezultate.
    /// </summary>
    internal class Kontroler
    {
        private static Kontroler? instance;

        /// <summary>Jedina instanca kontrolera.</summary>
        public static Kontroler Instance
        {
            get
            {
                if (instance == null) instance = new Kontroler();
                return instance;
            }
        }

        private Kontroler() { }

        /// <summary>Prijavljuje radnika na sistem.</summary>
        public Radnik PrijaviSe(Radnik radnik)
        {
            PrijavaSO so = new PrijavaSO(radnik);
            so.ExecuteTemplate();
            return so.Result!;
        }
        /// <summary>Kreira novu kvalifikaciju.</summary>
        public void KreirajKvalifikaciju(Kvalifikacija kvalifikacija)
        {
            KreirajKvalifikacijuSO so = new KreirajKvalifikacijuSO(kvalifikacija);
            so.ExecuteTemplate();
        }

        /// <summary>Kreira novog radnika.</summary>
        public void KreirajRadnika(Radnik radnik)
        {
            KreirajRadnikaSO so = new KreirajRadnikaSO(radnik);
            so.ExecuteTemplate();
        }

        /// <summary>Menja podatke radnika.</summary>
        public void PromeniRadnika(Radnik radnik)
        {
            PromeniRadnikaSO so = new PromeniRadnikaSO(radnik);
            so.ExecuteTemplate();
        }

        /// <summary>Deaktivira radnika.</summary>
        public void DeaktivirajRadnika(int radnikID)
        {
            DeaktivirajRadnikaSO so = new DeaktivirajRadnikaSO(radnikID);
            so.ExecuteTemplate();
        }

        /// <summary>Pretražuje radnike po imenu/prezimenu.</summary>
        public List<Radnik> PretraziRadnika(string kriterijum)
        {
            PretraziRadnikaSO so = new PretraziRadnikaSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        /// <summary>Kreira novu osobu.</summary>
        public void KreirajOsobu(Osoba osoba)
        {
            KreirajOsobuSO so = new KreirajOsobuSO(osoba);
            so.ExecuteTemplate();
        }

        /// <summary>Menja podatke osobe.</summary>
        public void PromeniOsobu(Osoba osoba)
        {
            PromeniOsobuSO so = new PromeniOsobuSO(osoba);
            so.ExecuteTemplate();
        }

        /// <summary>Briše osobu.</summary>
        public void ObrisiOsobu(int osobaID)
        {
            ObrisiOsobuSO so = new ObrisiOsobuSO(osobaID);
            so.ExecuteTemplate();
        }
        /// <summary>Vraća sve kvalifikacije.</summary>
        public List<Kvalifikacija> VratiSveKvalifikacije()
        {
            VratiSveKvalifikacijeSO so = new VratiSveKvalifikacijeSO();
            so.ExecuteTemplate();
            return so.Result;
        }
        public List<Kategorija> VratiSveKategorije()
        {
            VratiSveKategorijeSO so = new VratiSveKategorijeSO();
            so.ExecuteTemplate();
            return (List<Kategorija>)so.Result!;
        }
        /// <summary>Pretražuje osobe po imenu/prezimenu/JMBG-u.</summary>
        public List<Osoba> PretraziOsobu(string kriterijum)
        {
            PretraziOsobuSO so = new PretraziOsobuSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        /// <summary>Kreira novog trenera.</summary>
        public void KreirajTrenera(Trener trener)
        {
            KreirajTreneraSO so = new KreirajTreneraSO(trener);
            so.ExecuteTemplate();
        }

        /// <summary>Menja podatke trenera, uključujući status aktivnosti.</summary>
        public void PromeniTrenera(Trener trener)
        {
            PromeniTreneraSO so = new PromeniTreneraSO(trener);
            so.ExecuteTemplate();
        }

        /// <summary>Vraća sve aktivne trenere.</summary>
        public List<Trener> VratiSveAktivneTrenere()
        {
            VratiSveAktivneTrenereSO so = new VratiSveAktivneTrenereSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        /// <summary>Kreira novo članstvo.</summary>
        public void KreirajClanstvo(Članstvo clanstvo)
        {
            KreirajClanstvoSO so = new KreirajClanstvoSO(clanstvo);
            so.ExecuteTemplate();
        }

        /// <summary>Otkazuje članstvo.</summary>
        public void OtkaziClanstvo(int clanstvoID)
        {
            OtkaziClanstvoSO so = new OtkaziClanstvoSO(clanstvoID);
            so.ExecuteTemplate();
        }

        /// <summary>Izračunava ukupnu cenu članstva.</summary>
        public decimal IzracunajUkupnuCenuClanstva(int clanstvoID)
        {
            IzracunajUkupnuCenuClanstvaSO so = new IzracunajUkupnuCenuClanstvaSO(clanstvoID);
            so.ExecuteTemplate();
            return so.Result;
        }

        /// <summary>Dodeljuje kvalifikaciju radniku.</summary>
        public void DodeliKvalifikacijuRadniku(RadnikKvalifikacija radnikKvalifikacija)
        {
            DodeliKvalifikacijuRadnikuSO so = new DodeliKvalifikacijuRadnikuSO(radnikKvalifikacija);
            so.ExecuteTemplate();
        }

        /// <summary>Dodaje stavku (trening) u okviru postojećeg članstva.</summary>
        public void DodajStavkuClanstva(StavkaČlanstva stavka)
        {
            DodajStavkuClanstvaSO so = new DodajStavkuClanstvaSO(stavka);
            so.ExecuteTemplate();
        }
        /// <summary>Vraća aktivno članstvo date osobe.</summary>
        public Članstvo VratiAktivnoClanstvoOsobe(int osobaID)
        {
            VratiAktivnoClanstvoOsobeSO so = new VratiAktivnoClanstvoOsobeSO(osobaID);
            so.ExecuteTemplate();
            return so.Result!;

        }
    }
}