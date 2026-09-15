using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>
    /// Prijavljuje radnika na sistem proverom email-a i šifre.
    /// </summary>
    public class PrijavaSO : SOBase
    {
        private readonly Radnik radnik;

        /// <summary>Rezultat prijave - pronađeni radnik ako su kredencijali tačni.</summary>
        public Radnik? Result { get; set; }

        /// <summary>Kreira operaciju prijave sa unetim email-om i šifrom.</summary>
        /// <param name="radnik">Objekat sa popunjenim Email i Sifra poljima.</param>
        public PrijavaSO(Radnik radnik)
        {
            this.radnik = radnik;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            string condition = $"Email = '{radnik.Email}' AND Sifra = '{radnik.Sifra}'";
            List<IEntity> lista = broker.GetByCondition(radnik, condition);

            Result = lista.Cast<Radnik>().FirstOrDefault();

            if (Result == null)
            {
                throw new Exception("Pogrešan email ili šifra.");
            }
        }
    }
}
