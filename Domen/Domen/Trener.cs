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
        /// <summary>Jedinstveni identifikator trenera.</summary>
        public int TrenerID { get; set; }
        /// <summary>Ime trenera.</summary>
        public required string Ime { get; set; }
        /// <summary>Prezime trenera.</summary>
        public required string Prezime { get; set; }
        /// <summary>Oblast u kojoj je trener specijalizovan (npr. Fitnes, Joga, Pilates).</summary>
        public required string Specijalnost { get; set; }
        /// <summary>Broj telefona trenera.</summary>
        public required string BrojTelefona { get; set; }
        /// <summary>Email adresa trenera.</summary>
        public required string Email { get; set; }
        /// <summary>Broj godina radnog iskustva trenera.</summary>
        public int GodineIskustva { get; set; }
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
