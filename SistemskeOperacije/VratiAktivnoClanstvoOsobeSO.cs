using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>Vraća aktivno članstvo date osobe, ako postoji.</summary>
    public class VratiAktivnoClanstvoOsobeSO : SOBase
    {
        private readonly int osobaID;

        /// <summary>Rezultat - pronađeno aktivno članstvo.</summary>
        public Članstvo? Result { get; set; }

        /// <summary>Kreira operaciju pronalaženja aktivnog članstva osobe.</summary>
        /// <param name="osobaID">ID osobe čije se aktivno članstvo traži.</param>
        public VratiAktivnoClanstvoOsobeSO(int osobaID)
        {
            this.osobaID = osobaID;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetByCondition(new Članstvo(), $"OsobaID = {osobaID} AND Status = 'Aktivno'");
            Result = lista.Cast<Članstvo>().FirstOrDefault();

            if (Result == null)
            {
                throw new Exception("Osoba nema aktivno članstvo.");
            }
        }
    }
}
