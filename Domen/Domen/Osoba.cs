using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domen
{
    /// <summary>
    /// Predstavlja osobu (člana teretane) - primaoca usluge kome se
    /// kreira članstvo.
    /// </summary>
    public class Osoba : IEntity
    {
        private int osobaID;
        private int kategorijaID;
        private string ime = "";
        private string prezime = "";
        private string jmbg = "";
        private string email = "";
        private string adresa = "";
        private string brojTelefona = "";
        private DateTime datumRodjenja;

        /// <summary>Jedinstveni identifikator osobe. Ne sme biti negativan.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Ako je vrednost negativna.</exception>
        public int OsobaID
        {
            get => osobaID;
            set => osobaID = Validacija.NenegativanBroj(value, nameof(OsobaID));
        }

        /// <summary>Strani ključ ka kategoriji kojoj osoba pripada. Ne sme biti negativan.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Ako je vrednost negativna.</exception>
        public int KategorijaID
        {
            get => kategorijaID;
            set => kategorijaID = Validacija.NenegativanBroj(value, nameof(KategorijaID));
        }

        /// <summary>Ime osobe. Ne sme biti null, sadržati samo razmake, niti biti duže od 50 karaktera.</summary>
        /// <exception cref="ArgumentNullException">Ako je vrednost null.</exception>
        /// <exception cref="ArgumentException">Ako vrednost sadrži samo razmake ili je predugačka.</exception>
        public required string Ime
        {
            get => ime;
            set => ime = Validacija.ObaveznoPolje(value, nameof(Ime), 50);
        }

        /// <summary>Prezime osobe. Ne sme biti null, sadržati samo razmake, niti biti duže od 50 karaktera.</summary>
        /// <exception cref="ArgumentNullException">Ako je vrednost null.</exception>
        /// <exception cref="ArgumentException">Ako vrednost sadrži samo razmake ili je predugačka.</exception>
        public required string Prezime
        {
            get => prezime;
            set => prezime = Validacija.ObaveznoPolje(value, nameof(Prezime), 50);
        }

        /// <summary>Jedinstveni matični broj građana. Ako je popunjen, mora sadržati tačno 13 cifara.</summary>
        /// <exception cref="ArgumentNullException">Ako je vrednost null.</exception>
        /// <exception cref="ArgumentException">Ako vrednost nema tačno 13 cifara.</exception>
        public required string JMBG
        {
            get => jmbg;
            set => jmbg = Validacija.Jmbg(value);
        }

        /// <summary>Datum rođenja osobe. Ne sme biti u budućnosti.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Ako je datum u budućnosti.</exception>
        public DateTime DatumRodjenja
        {
            get => datumRodjenja;
            set => datumRodjenja = Validacija.NijeUBuducnosti(value, nameof(DatumRodjenja));
        }

        /// <summary>Email adresa osobe. Ako je popunjena, mora biti validnog formata.</summary>
        /// <exception cref="ArgumentNullException">Ako je vrednost null.</exception>
        /// <exception cref="ArgumentException">Ako vrednost nije validna email adresa.</exception>
        public required string Email
        {
            get => email;
            set => email = Validacija.Email(value);
        }

        /// <summary>Adresa stanovanja osobe. Ne sme biti null niti duža od 150 karaktera.</summary>
        /// <exception cref="ArgumentNullException">Ako je vrednost null.</exception>
        /// <exception cref="ArgumentException">Ako vrednost sadrži samo razmake ili je predugačka.</exception>
        public required string Adresa
        {
            get => adresa;
            set => adresa = Validacija.ObaveznoPolje(value, nameof(Adresa), 150);
        }

        /// <summary>Broj telefona osobe. Ako je popunjen, mora sadržati samo cifre i imati bar 6 cifara.</summary>
        /// <exception cref="ArgumentNullException">Ako je vrednost null.</exception>
        /// <exception cref="ArgumentException">Ako vrednost nije validan broj telefona.</exception>
        public required string BrojTelefona
        {
            get => brojTelefona;
            set => brojTelefona = Validacija.BrojTelefona(value);
        }

        /// <summary>Naziv tabele u bazi za ovaj entitet.</summary>
        public string TableName => "Osoba";

        /// <summary>Vrednosti za SQL INSERT, redosledom kolona iz tabele (bez IDENTITY kolone).</summary>
        public string Values => $"{KategorijaID}, '{Ime}', '{Prezime}', '{JMBG}', '{DatumRodjenja:yyyyMMdd}', '{Email}', '{Adresa}', '{BrojTelefona}'";

        /// <summary>Dodatni JOIN deo upita - nije potreban za ovaj entitet.</summary>
        public string Join => "";

        /// <summary>Mapira redove iz SqlDataReader-a u listu objekata tipa Osoba.</summary>
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new Osoba
                {
                    OsobaID = (int)reader["OsobaID"],
                    KategorijaID = (int)reader["KategorijaID"],
                    Ime = (string)reader["Ime"],
                    Prezime = (string)reader["Prezime"],
                    JMBG = (string)reader["JMBG"],
                    DatumRodjenja = (DateTime)reader["DatumRodjenja"],
                    Email = (string)reader["Email"],
                    Adresa = (string)reader["Adresa"],
                    BrojTelefona = (string)reader["BrojTelefona"]
                });
            }
            return lista;
        }
    }
}
