using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>Vraća listu svih trenera.</summary>
    public class VratiSveTrenereSO : SOBase
    {
        /// <summary>Rezultat - lista svih trenera.</summary>
        public List<Trener> Result { get; set; } = new();

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            Trener prazan = new Trener { Ime = "", Prezime = "", Specijalnost = "", BrojTelefona = "", Email = "" };
            List<IEntity> lista = broker.GetAll(prazan);
            Result = lista.Cast<Trener>().ToList();
        }
    }
}
