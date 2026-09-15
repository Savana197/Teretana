using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>
    /// Izračunava ukupnu cenu članstva - osnovna cena članstva plus cene
    /// svih njegovih stavki (treninga).
    /// </summary>
    public class IzracunajUkupnuCenuClanstvaSO : SOBase
    {
        private readonly int clanstvoID;

        /// <summary>Rezultat - ukupna cena članstva.</summary>
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

            Result = clanstvo.Cena + cenaStavki;
        }
    }
}
