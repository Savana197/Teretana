using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>Dodeljuje kvalifikaciju radniku.</summary>
    public class DodeliKvalifikacijuRadnikuSO : SOBase
    {
        private readonly RadnikKvalifikacija radnikKvalifikacija;

        /// <summary>Kreira operaciju dodele kvalifikacije radniku.</summary>
        /// <param name="radnikKvalifikacija">Popunjen objekat sa RadnikID, KvalifikacijaID i datumima.</param>
        public DodeliKvalifikacijuRadnikuSO(RadnikKvalifikacija radnikKvalifikacija)
        {
            this.radnikKvalifikacija = radnikKvalifikacija;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(radnikKvalifikacija);
        }
    }
}
