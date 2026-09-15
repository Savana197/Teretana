using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>Menja podatke trenera, uključujući status aktivnosti (zamenjuje brisanje).</summary>
    public class PromeniTreneraSO : SOBase
    {
        private readonly Trener trener;

        /// <summary>Kreira operaciju izmene trenera.</summary>
        /// <param name="trener">Trener sa popunjenim TrenerID i novim vrednostima ostalih polja, uključujući Aktivan.</param>
        public PromeniTreneraSO(Trener trener)
        {
            this.trener = trener;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            string setClause = $"Ime = '{trener.Ime}', Prezime = '{trener.Prezime}', Specijalnost = '{trener.Specijalnost}', BrojTelefona = '{trener.BrojTelefona}', Email = '{trener.Email}', GodineIskustva = {trener.GodineIskustva}, Aktivan = {(trener.Aktivan ? 1 : 0)}";
            string condition = $"TrenerID = {trener.TrenerID}";
            broker.Update(trener, setClause, condition);
        }
    }
}
