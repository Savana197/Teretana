using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>Kreira novu kvalifikaciju.</summary>
    public class KreirajKvalifikacijuSO : SOBase
    {
        private readonly Kvalifikacija kvalifikacija;

        /// <summary>Kreira operaciju kreiranja kvalifikacije.</summary>
        /// <param name="kvalifikacija">Popunjen objekat kvalifikacije (Naziv i Nivo) za upis u bazu.</param>
        public KreirajKvalifikacijuSO(Kvalifikacija kvalifikacija)
        {
            this.kvalifikacija = kvalifikacija;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(kvalifikacija);
        }
    }
}
