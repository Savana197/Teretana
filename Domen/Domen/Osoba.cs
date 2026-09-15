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
        /// <summary>Jedinstveni identifikator osobe.</summary>
        public int OsobaID { get; set; }
        /// <summary>Strani ključ ka kategoriji kojoj osoba pripada.</summary>
        public int KategorijaID { get; set; }
        /// <summary>Ime osobe.</summary>
        public required string Ime { get; set; }
        /// <summary>Prezime osobe.</summary>
        public required string Prezime { get; set; }
        /// <summary>Jedinstveni matični broj građana.</summary>
        public required string JMBG { get; set; }
        /// <summary>Datum rođenja osobe.</summary>
        public DateTime DatumRodjenja { get; set; }
        /// <summary>Email adresa osobe.</summary>
        public required string Email { get; set; }
        /// <summary>Adresa stanovanja osobe.</summary>
        public required string Adresa { get; set; }
        /// <summary>Broj telefona osobe.</summary>
        public required string BrojTelefona { get; set; }
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
