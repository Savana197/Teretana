using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>Kreira novu osobu (člana teretane).</summary>
    public class KreirajOsobuSO : SOBase
    {
        private readonly Osoba osoba;

        /// <summary>Kreira operaciju kreiranja osobe.</summary>
        /// <param name="osoba">Popunjen objekat osobe za upis u bazu.</param>
        public KreirajOsobuSO(Osoba osoba)
        {
            this.osoba = osoba;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(osoba);
        }
    }
}
