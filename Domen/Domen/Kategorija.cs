using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domen
{
    /// <summary>
    /// Šifarnik kategorija osoba (npr. Standard, Junior, Senior, VIP) -
    /// određuje popust koji se primenjuje na članarinu osobe iz te kategorije.
    /// </summary>
    public class Kategorija : IEntity
    {
        /// <summary>Jedinstveni identifikator kategorije.</summary>
        public int KategorijaID { get; set; }
        /// <summary>Naziv kategorije.</summary>
        public required string Naziv { get; set; }
        /// <summary>Procenat popusta koji se primenjuje na osobe ove kategorije.</summary>
        public decimal Popust { get; set; }
        /// <summary>Naziv tabele u bazi za ovaj entitet.</summary>
        public string TableName => "Kategorija";

        /// <summary>Vrednosti za SQL INSERT, redosledom kolona iz tabele (bez IDENTITY kolone).</summary>
        public string Values => $"'{Naziv}', {Popust.ToString(CultureInfo.InvariantCulture)}";

        /// <summary>Dodatni JOIN deo upita - nije potreban za ovaj entitet.</summary>
        public string Join => "";

        /// <summary>Mapira redove iz SqlDataReader-a u listu objekata tipa Kategorija.</summary>
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new Kategorija
                {
                    KategorijaID = (int)reader["KategorijaID"],
                    Naziv = (string)reader["Naziv"],
                    Popust = (decimal)reader["Popust"]
                });
            }
            return lista;
        }

    }
}
