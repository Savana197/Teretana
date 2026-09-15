using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>Otkazuje postojeće članstvo (postavlja status na Otkazano).</summary>
    public class OtkaziClanstvoSO : SOBase
    {
        private readonly int clanstvoID;

        /// <summary>Kreira operaciju otkazivanja članstva.</summary>
        /// <param name="clanstvoID">ID članstva koje se otkazuje.</param>
        public OtkaziClanstvoSO(int clanstvoID)
        {
            this.clanstvoID = clanstvoID;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            broker.Update(new Članstvo(), "Status = 'Otkazano'", $"ClanstvoID = {clanstvoID}");
        }
    }
}
