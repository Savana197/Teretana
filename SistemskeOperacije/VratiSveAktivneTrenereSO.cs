using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>Vraća listu svih aktivnih trenera.</summary>
    public class VratiSveAktivneTrenereSO : SOBase
    {
        /// <summary>Rezultat - lista aktivnih trenera.</summary>
        public List<Trener> Result { get; set; } = new();

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            Trener prazan = new Trener { Ime = "", Prezime = "", Specijalnost = "", BrojTelefona = "", Email = "" };
            List<IEntity> lista = broker.GetByCondition(prazan, "Aktivan = 1");
            Result = lista.Cast<Trener>().ToList();
        }
    }
}
