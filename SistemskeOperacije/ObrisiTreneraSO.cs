using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>Briše trenera iz sistema.</summary>
    public class ObrisiTreneraSO : SOBase
    {
        private readonly int trenerID;

        /// <summary>Kreira operaciju brisanja trenera.</summary>
        /// <param name="trenerID">ID trenera koji se briše.</param>
        public ObrisiTreneraSO(int trenerID)
        {
            this.trenerID = trenerID;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            Trener prazan = new Trener { Ime = "", Prezime = "", Specijalnost = "", BrojTelefona = "", Email = "" };
            broker.Delete(prazan, $"TrenerID = {trenerID}");
        }
    }
}
