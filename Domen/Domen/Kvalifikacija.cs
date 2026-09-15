using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domen
{
    /// <summary>Nivo stručnosti povezan sa kvalifikacijom.</summary>
    public enum Nivo
    {
        /// <summary>Osnovni nivo kvalifikacije.</summary>
        Osnovni,
        /// <summary>Napredni nivo kvalifikacije.</summary>
        Napredni,
        /// <summary>Ekspertski nivo kvalifikacije.</summary>
        Ekspert

    }
    /// <summary>
    /// Šifarnik kvalifikacija (sertifikata) koje radnik može posedovati
    /// (npr. Fitnes instruktor, Nutricionista).
    /// </summary>
    public class Kvalifikacija : IEntity
    {
        /// <summary>Jedinstveni identifikator kvalifikacije.</summary>
        public int KvalifikacijaID { get; set; }
        /// <summary>Naziv kvalifikacije.</summary>
        public required string Naziv { get; set; }
        /// <summary>Nivo stručnosti ove kvalifikacije.</summary>
        public Nivo Nivo { get; set; }
        /// <summary>Naziv tabele u bazi za ovaj entitet.</summary>
        public string TableName => "Kvalifikacija";

        /// <summary>Vrednosti za SQL INSERT, redosledom kolona iz tabele (bez IDENTITY kolone).</summary>
        public string Values => $"'{Naziv}', '{Nivo}'";

        /// <summary>Dodatni JOIN deo upita - nije potreban za ovaj entitet.</summary>
        public string Join => "";

        /// <summary>Mapira redove iz SqlDataReader-a u listu objekata tipa Kvalifikacija.</summary>
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new Kvalifikacija
                {
                    KvalifikacijaID = (int)reader["KvalifikacijaID"],
                    Naziv = (string)reader["Naziv"],
                    Nivo = Enum.Parse<Nivo>((string)reader["Nivo"])
                });
            }
            return lista;
        }

    }
}
