using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>Deaktivira radnika (soft delete preko Aktivan flag-a).</summary>
    public class DeaktivirajRadnikaSO : SOBase
    {
        private readonly int radnikID;

        /// <summary>Kreira operaciju deaktiviranja radnika.</summary>
        /// <param name="radnikID">ID radnika koji se deaktivira.</param>
        public DeaktivirajRadnikaSO(int radnikID)
        {
            this.radnikID = radnikID;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            // "prazan" Radnik ovde služi samo kao nosilac TableName-a za Broker.Update,
            // njegov sadržaj se ne upisuje u bazu.
            Radnik prazan = new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" };
            broker.Update(prazan, "Aktivan = 0", $"RadnikID = {radnikID}");
        }
    }
}
