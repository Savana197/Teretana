using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>
    /// Kreira novog radnika u sistemu.
    /// </summary>
    public class KreirajRadnikaSO : SOBase
    {
        private readonly Radnik radnik;

        /// <summary>Kreira operaciju kreiranja radnika.</summary>
        /// <param name="radnik">Popunjen objekat radnika za upis u bazu.</param>
        public KreirajRadnikaSO(Radnik radnik)
        {
            this.radnik = radnik;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(radnik);
        }
    }
}
