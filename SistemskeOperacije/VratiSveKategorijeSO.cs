using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>
    /// Sistemska operacija koja vraća sve kategorije iz baze (koristi se za popunjavanje
    /// izborne liste pri kreiranju/izmeni osobe).
    /// </summary>
    public class VratiSveKategorijeSO : SOBase
    {
        /// <summary>Rezultat - lista svih kategorija.</summary>
        public List<Kategorija> Result { get; set; } = new();
        protected override void ExecuteConcreteOperation()
        {
            Kategorija praznaKategorija = new Kategorija { Naziv = "" };
            List<IEntity> kategorije = broker.GetAll(praznaKategorija);
            Result = kategorije.Cast<Kategorija>().ToList();
        }
    }
}
