using Microsoft.Data.SqlClient;
using System.Security.Principal;

namespace Common.Domen
{
    /// <summary>
    /// Predstavlja zaposlenog (radnika) koji upravlja sistemom teretane -
    /// kreira, menja i pretražuje članstva, osobe, trenere i šifarnike.
    /// </summary>
    public class Radnik : IEntity
    {
        private int radnikID;
        private string ime = "";
        private string prezime = "";
        private string sifra = "";
        private string email = "";
        private string brojTelefona = "";

        /// <summary>Jedinstveni identifikator radnika. Ne sme biti negativan.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Ako je vrednost negativna.</exception>
        public int RadnikID
        {
            get => radnikID;
            set => radnikID = Validacija.NenegativanBroj(value, nameof(RadnikID));
        }

        /// <summary>Ime radnika. Ne sme biti null, sadržati samo razmake, niti biti duže od 50 karaktera.</summary>
        /// <exception cref="ArgumentNullException">Ako je vrednost null.</exception>
        /// <exception cref="ArgumentException">Ako vrednost sadrži samo razmake ili je predugačka.</exception>
        public required string Ime
        {
            get => ime;
            set => ime = Validacija.ObaveznoPolje(value, nameof(Ime), 50);
        }

        /// <summary>Prezime radnika. Ne sme biti null, sadržati samo razmake, niti biti duže od 50 karaktera.</summary>
        /// <exception cref="ArgumentNullException">Ako je vrednost null.</exception>
        /// <exception cref="ArgumentException">Ako vrednost sadrži samo razmake ili je predugačka.</exception>
        public required string Prezime
        {
            get => prezime;
            set => prezime = Validacija.ObaveznoPolje(value, nameof(Prezime), 50);
        }

        /// <summary>Šifra za prijavu na sistem. Ne sme biti null, a ako je popunjena mora imati bar 4 karaktera.</summary>
        /// <exception cref="ArgumentNullException">Ako je vrednost null.</exception>
        /// <exception cref="ArgumentException">Ako je vrednost kraća od 4 karaktera.</exception>
        public required string Sifra
        {
            get => sifra;
            set => sifra = Validacija.Lozinka(value);
        }

        /// <summary>Email adresa - koristi se i kao identifikator prilikom prijave. Ako je popunjena, mora biti validnog formata.</summary>
        /// <exception cref="ArgumentNullException">Ako je vrednost null.</exception>
        /// <exception cref="ArgumentException">Ako vrednost nije validna email adresa.</exception>
        public required string Email
        {
            get => email;
            set => email = Validacija.Email(value);
        }

        /// <summary>Broj telefona radnika. Ako je popunjen, mora sadržati samo cifre i imati bar 6 cifara.</summary>
        /// <exception cref="ArgumentNullException">Ako je vrednost null.</exception>
        /// <exception cref="ArgumentException">Ako vrednost nije validan broj telefona.</exception>
        public required string BrojTelefona
        {
            get => brojTelefona;
            set => brojTelefona = Validacija.BrojTelefona(value);
        }

        /// <summary>Da li je radnik trenutno aktivan (zaposlen) u sistemu.</summary>
        public bool Aktivan { get; set; }
        /// <summary>Naziv tabele u bazi za ovaj entitet.</summary>
        public string TableName => "Radnik";

        /// <summary>Vrednosti za SQL INSERT, redosledom kolona iz tabele (bez IDENTITY kolone).</summary>
        public string Values => $"'{Ime}', '{Prezime}', '{Sifra}', '{Email}', '{BrojTelefona}', {(Aktivan ? 1 : 0)}";

        /// <summary>Dodatni JOIN deo upita - nije potreban za ovaj entitet.</summary>
        public string Join => "";

        /// <summary>Mapira redove iz SqlDataReader-a u listu objekata tipa Radnik.</summary>
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new Radnik
                {
                    RadnikID = (int)reader["RadnikID"],
                    Ime = (string)reader["Ime"],
                    Prezime = (string)reader["Prezime"],
                    Sifra = (string)reader["Sifra"],
                    Email = (string)reader["Email"],
                    BrojTelefona = (string)reader["BrojTelefona"],
                    Aktivan = (bool)reader["Aktivan"]
                });
            }
            return lista;
        }

    }
}
