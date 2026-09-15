using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>Vraća listu svih kvalifikacija (šifarnik).</summary>
    public class VratiSveKvalifikacijeSO : SOBase
    {
        /// <summary>Rezultat - lista svih kvalifikacija.</summary>
        public List<Kvalifikacija> Result { get; set; } = new();

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            Kvalifikacija prazna = new Kvalifikacija { Naziv = "" };
            List<IEntity> lista = broker.GetAll(prazna);
            Result = lista.Cast<Kvalifikacija>().ToList();
        }
    }
}
