using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>Menja podatke postojeće osobe.</summary>
    public class PromeniOsobuSO : SOBase
    {
        private readonly Osoba osoba;

        /// <summary>Kreira operaciju izmene osobe.</summary>
        /// <param name="osoba">Osoba sa popunjenim OsobaID i novim vrednostima ostalih polja.</param>
        public PromeniOsobuSO(Osoba osoba)
        {
            this.osoba = osoba;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            string setClause = $"KategorijaID = {osoba.KategorijaID}, Ime = '{osoba.Ime}', Prezime = '{osoba.Prezime}', JMBG = '{osoba.JMBG}', DatumRodjenja = '{osoba.DatumRodjenja:yyyyMMdd}', Email = '{osoba.Email}', Adresa = '{osoba.Adresa}', BrojTelefona = '{osoba.BrojTelefona}'";
            string condition = $"OsobaID = {osoba.OsobaID}";
            broker.Update(osoba, setClause, condition);
        }
    }
}
