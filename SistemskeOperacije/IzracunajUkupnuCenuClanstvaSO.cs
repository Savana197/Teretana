using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>
    /// Izračunava ukupnu cenu članstva (članarinu) - osnovna cena članstva
    /// plus cene svih njegovih stavki (treninga), umanjeno za procenat
    /// popusta kategorije kojoj pripada osoba.
    /// </summary>
    public class IzracunajUkupnuCenuClanstvaSO : SOBase
    {
        private readonly int clanstvoID;

        /// <summary>Rezultat - ukupna cena članstva nakon primenjenog popusta.</summary>
        public decimal Result { get; set; }

        /// <summary>Kreira operaciju izračunavanja ukupne cene članstva.</summary>
        /// <param name="clanstvoID">ID članstva za koje se računa cena.</param>
        public IzracunajUkupnuCenuClanstvaSO(int clanstvoID)
        {
            this.clanstvoID = clanstvoID;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> clanstva = broker.GetByCondition(new Članstvo(), $"ClanstvoID = {clanstvoID}");
            Članstvo clanstvo = clanstva.Cast<Članstvo>().FirstOrDefault()
                ?? throw new Exception("Članstvo sa datim ID-jem ne postoji.");

            List<IEntity> stavke = broker.GetByCondition(new StavkaČlanstva(), $"ClanstvoID = {clanstvoID}");
            decimal cenaStavki = stavke.Cast<StavkaČlanstva>().Sum(s => s.CenaStavke);

            decimal ukupnoPrePopusta = clanstvo.Cena + cenaStavki;

            Osoba praznaOsoba = new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" };
            List<IEntity> osobe = broker.GetByCondition(praznaOsoba, $"OsobaID = {clanstvo.OsobaID}");
            Osoba osoba = osobe.Cast<Osoba>().FirstOrDefault()
                ?? throw new Exception("Osoba vezana za ovo članstvo ne postoji.");

            Kategorija praznaKategorija = new Kategorija { Naziv = "" };
            List<IEntity> kategorije = broker.GetByCondition(praznaKategorija, $"KategorijaID = {osoba.KategorijaID}");
            Kategorija kategorija = kategorije.Cast<Kategorija>().FirstOrDefault()
                ?? throw new Exception("Kategorija osobe ne postoji.");

            Result = ukupnoPrePopusta - (ukupnoPrePopusta * kategorija.Popust / 100m);
        }
    }
}