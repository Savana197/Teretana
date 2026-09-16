using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>Kreira novo članstvo za osobu.</summary>
    public class KreirajClanstvoSO : SOBase
    {
        private readonly Članstvo clanstvo;

        /// <summary>Kreira operaciju kreiranja članstva.</summary>
        /// <param name="clanstvo">Popunjen objekat članstva za upis u bazu.</param>
        public KreirajClanstvoSO(Članstvo clanstvo)
        {
            this.clanstvo = clanstvo;
            clanstvo.Status = StatusČlanstva.Aktivno;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(clanstvo);
        }
    }
}
