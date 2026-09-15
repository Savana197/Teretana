using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>Briše osobu iz sistema.</summary>
    public class ObrisiOsobuSO : SOBase
    {
        private readonly int osobaID;

        /// <summary>Kreira operaciju brisanja osobe.</summary>
        /// <param name="osobaID">ID osobe koja se briše.</param>
        public ObrisiOsobuSO(int osobaID)
        {
            this.osobaID = osobaID;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            Osoba prazna = new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" };
            broker.Delete(prazna, $"OsobaID = {osobaID}");
        }
    }
}
