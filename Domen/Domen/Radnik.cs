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
        /// <summary>Jedinstveni identifikator radnika.</summary>
        public int RadnikID { get; set; }
        /// <summary>Ime radnika.</summary>
        public required string Ime { get; set; }
        /// <summary>Prezime radnika.</summary>
        public required string Prezime { get; set; }
        /// <summary>Šifra za prijavu na sistem.</summary>
        public required string Sifra { get; set; }
        /// <summary>Email adresa - koristi se i kao identifikator prilikom prijave.</summary>
        public required string Email { get; set; }
        /// <summary>Broj telefona radnika.</summary>
        public required string BrojTelefona { get; set; }
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
