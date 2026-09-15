using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>Dodaje novu stavku (trening) u okviru postojećeg članstva - redni broj (Rb) se računa automatski.</summary>
    public class DodajStavkuClanstvaSO : SOBase
    {
        private readonly StavkaČlanstva stavka;

        /// <summary>Kreira operaciju dodavanja stavke članstva.</summary>
        /// <param name="stavka">Popunjena stavka (Rb se ne unosi - postavlja se automatski).</param>
        public DodajStavkuClanstvaSO(StavkaČlanstva stavka)
        {
            this.stavka = stavka;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> postojece = broker.GetByCondition(new StavkaČlanstva(), $"ClanstvoID = {stavka.ČlanstvoID}");
            stavka.Rb = postojece.Count + 1;
            broker.Add(stavka);
        }
    }
}
