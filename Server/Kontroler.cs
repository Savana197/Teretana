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

        /// <summary>Briše trenera.</summary>
        public void ObrisiTrenera(int trenerID)
        {
            ObrisiTreneraSO so = new ObrisiTreneraSO(trenerID);
            so.ExecuteTemplate();
        }

        /// <summary>Vraća sve trenere.</summary>
        public List<Trener> VratiSveTrenere()
        {
            VratiSveTrenereSO so = new VratiSveTrenereSO();
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

        /// <summary>Vraća kvalifikacije radnika kojima je istekao rok.</summary>
        public List<RadnikKvalifikacija> VratiIsteklaKvalifikacije()
        {
            VratiIstekleKvalifikacijeSO so = new VratiIstekleKvalifikacijeSO();
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}
