using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>Kreira novog trenera.</summary>
    public class KreirajTreneraSO : SOBase
    {
        private readonly Trener trener;

        /// <summary>Kreira operaciju kreiranja trenera.</summary>
        /// <param name="trener">Popunjen objekat trenera za upis u bazu.</param>
        public KreirajTreneraSO(Trener trener)
        {
            this.trener = trener;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(trener);
        }
    }
}
