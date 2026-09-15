using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>Pretražuje radnike po imenu ili prezimenu.</summary>
    public class PretraziRadnikaSO : SOBase
    {
        private readonly string kriterijum;

        /// <summary>Rezultat pretrage.</summary>
        public List<Radnik> Result { get; set; } = new();

        /// <summary>Kreira operaciju pretrage radnika.</summary>
        /// <param name="kriterijum">Deo imena ili prezimena po kom se traži.</param>
        public PretraziRadnikaSO(string kriterijum)
        {
            this.kriterijum = kriterijum;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            Radnik prazan = new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" };
            string condition = $"Ime LIKE '%{kriterijum}%' OR Prezime LIKE '%{kriterijum}%'";
            List<IEntity> lista = broker.GetByCondition(prazan, condition);
            Result = lista.Cast<Radnik>().ToList();
        }
    }
}
