using Common.Domen;

namespace SistemskeOperacije
{
    /// <summary>Pretražuje osobe po imenu, prezimenu ili JMBG-u.</summary>
    public class PretraziOsobuSO : SOBase
    {
        private readonly string kriterijum;

        /// <summary>Rezultat pretrage.</summary>
        public List<Osoba> Result { get; set; } = new();

        /// <summary>Kreira operaciju pretrage osoba.</summary>
        /// <param name="kriterijum">Deo imena, prezimena ili JMBG-a po kom se traži.</param>
        public PretraziOsobuSO(string kriterijum)
        {
            this.kriterijum = kriterijum;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            Osoba prazna = new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" };
            string condition = $"Ime LIKE '%{kriterijum}%' OR Prezime LIKE '%{kriterijum}%' OR JMBG LIKE '%{kriterijum}%'";
            List<IEntity> lista = broker.GetByCondition(prazna, condition);
            Result = lista.Cast<Osoba>().ToList();
        }
    }
}
