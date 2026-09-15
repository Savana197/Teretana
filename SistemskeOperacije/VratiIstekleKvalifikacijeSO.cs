using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>Vraća listu kvalifikacija radnika kojima je istekao rok važenja.</summary>
    public class VratiIstekleKvalifikacijeSO : SOBase
    {
        /// <summary>Rezultat - lista isteklih kvalifikacija radnika.</summary>
        public List<RadnikKvalifikacija> Result { get; set; } = new();

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            string condition = $"DatumIsteka IS NOT NULL AND DatumIsteka < '{DateTime.Now:yyyyMMdd}'";
            List<IEntity> lista = broker.GetByCondition(new RadnikKvalifikacija(), condition);
            Result = lista.Cast<RadnikKvalifikacija>().ToList();
        }
    }
}
