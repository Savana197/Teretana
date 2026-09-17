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
        private int kategorijaID;
        private string naziv = "";
        private decimal popust;

        /// <summary>Jedinstveni identifikator kategorije. Ne sme biti negativan.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Ako je vrednost negativna.</exception>
        public int KategorijaID
        {
            get => kategorijaID;
            set => kategorijaID = Validacija.NenegativanBroj(value, nameof(KategorijaID));
        }

        /// <summary>Naziv kategorije. Ne sme biti null, sadržati samo razmake, niti biti duži od 50 karaktera.</summary>
        /// <exception cref="ArgumentNullException">Ako je vrednost null.</exception>
        /// <exception cref="ArgumentException">Ako vrednost sadrži samo razmake ili je predugačka.</exception>
        public required string Naziv
        {
            get => naziv;
            set => naziv = Validacija.ObaveznoPolje(value, nameof(Naziv), 50);
        }

        /// <summary>Procenat popusta koji se primenjuje na osobe ove kategorije. Mora biti između 0 i 100.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Ako vrednost nije u opsegu 0-100.</exception>
        public decimal Popust
        {
            get => popust;
            set => popust = Validacija.Procenat(value, nameof(Popust));
        }

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
