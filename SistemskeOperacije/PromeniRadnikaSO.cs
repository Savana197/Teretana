using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>Menja podatke postojećeg radnika.</summary>
    public class PromeniRadnikaSO : SOBase
    {
        private readonly Radnik radnik;

        /// <summary>Kreira operaciju izmene radnika.</summary>
        /// <param name="radnik">Radnik sa popunjenim RadnikID i novim vrednostima ostalih polja.</param>
        public PromeniRadnikaSO(Radnik radnik)
        {
            this.radnik = radnik;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            string setClause = $"Ime = '{radnik.Ime}', Prezime = '{radnik.Prezime}', Sifra = '{radnik.Sifra}', Email = '{radnik.Email}', BrojTelefona = '{radnik.BrojTelefona}'";
            string condition = $"RadnikID = {radnik.RadnikID}";
            broker.Update(radnik, setClause, condition);
        }
    }
}
