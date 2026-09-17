using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domen
{
    /// <summary>
    /// Predstavlja trenera koji je dodeljen jednoj ili više stavki članstva
    /// (npr. individualni ili grupni treninzi).
    /// </summary>
    public class Trener : IEntity
    {
        private int trenerID;
        private string ime = "";
        private string prezime = "";
        private string specijalnost = "";
        private string brojTelefona = "";
        private string email = "";
        private int godineIskustva;

        /// <summary>Jedinstveni identifikator trenera. Ne sme biti negativan.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Ako je vrednost negativna.</exception>
        public int TrenerID
        {
            get => trenerID;
            set => trenerID = Validacija.NenegativanBroj(value, nameof(TrenerID));
        }

        /// <summary>Ime trenera. Ne sme biti null, sadržati samo razmake, niti biti duže od 50 karaktera.</summary>
        /// <exception cref="ArgumentNullException">Ako je vrednost null.</exception>
        /// <exception cref="ArgumentException">Ako vrednost sadrži samo razmake ili je predugačka.</exception>
        public required string Ime
        {
            get => ime;
            set => ime = Validacija.ObaveznoPolje(value, nameof(Ime), 50);
        }

        /// <summary>Prezime trenera. Ne sme biti null, sadržati samo razmake, niti biti duže od 50 karaktera.</summary>
        /// <exception cref="ArgumentNullException">Ako je vrednost null.</exception>
        /// <exception cref="ArgumentException">Ako vrednost sadrži samo razmake ili je predugačka.</exception>
        public required string Prezime
        {
            get => prezime;
            set => prezime = Validacija.ObaveznoPolje(value, nameof(Prezime), 50);
        }

        /// <summary>Oblast u kojoj je trener specijalizovan (npr. Fitnes, Joga, Pilates). Ne sme biti null niti duža od 50 karaktera.</summary>
        /// <exception cref="ArgumentNullException">Ako je vrednost null.</exception>
        /// <exception cref="ArgumentException">Ako vrednost sadrži samo razmake ili je predugačka.</exception>
        public required string Specijalnost
        {
            get => specijalnost;
            set => specijalnost = Validacija.ObaveznoPolje(value, nameof(Specijalnost), 50);
        }

        /// <summary>Broj telefona trenera. Ako je popunjen, mora sadržati samo cifre i imati bar 6 cifara.</summary>
        /// <exception cref="ArgumentNullException">Ako je vrednost null.</exception>
        /// <exception cref="ArgumentException">Ako vrednost nije validan broj telefona.</exception>
        public required string BrojTelefona
        {
            get => brojTelefona;
            set => brojTelefona = Validacija.BrojTelefona(value);
        }

        /// <summary>Email adresa trenera. Ako je popunjena, mora biti validnog formata.</summary>
        /// <exception cref="ArgumentNullException">Ako je vrednost null.</exception>
        /// <exception cref="ArgumentException">Ako vrednost nije validna email adresa.</exception>
        public required string Email
        {
            get => email;
            set => email = Validacija.Email(value);
        }

        /// <summary>Broj godina radnog iskustva trenera. Mora biti između 0 i 70.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Ako vrednost nije u dozvoljenom opsegu.</exception>
        public int GodineIskustva
        {
            get => godineIskustva;
            set => godineIskustva = Validacija.GodineIskustva(value);
        }

        /// <summary>Da li je trener trenutno aktivan (dostupan za dodelu treninga).</summary>
        public bool Aktivan { get; set; }
        /// <summary>Naziv tabele u bazi za ovaj entitet.</summary>
        public string TableName => "Trener";

        /// <summary>Vrednosti za SQL INSERT, redosledom kolona iz tabele (bez IDENTITY kolone).</summary>
        public string Values => $"'{Ime}', '{Prezime}', '{Specijalnost}', '{BrojTelefona}', '{Email}', {GodineIskustva}, {(Aktivan ? 1 : 0)}";

        /// <summary>Dodatni JOIN deo upita - nije potreban za ovaj entitet.</summary>
        public string Join => "";

        /// <summary>Mapira redove iz SqlDataReader-a u listu objekata tipa Trener.</summary>
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new Trener
                {
                    TrenerID = (int)reader["TrenerID"],
                    Ime = (string)reader["Ime"],
                    Prezime = (string)reader["Prezime"],
                    Specijalnost = (string)reader["Specijalnost"],
                    BrojTelefona = (string)reader["BrojTelefona"],
                    Email = (string)reader["Email"],
                    GodineIskustva = (int)reader["GodineIskustva"],
                    Aktivan = (bool)reader["Aktivan"]
                });
            }
            return lista;
        }
    }
}
