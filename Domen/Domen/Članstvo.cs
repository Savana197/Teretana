using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domen
{
    /// <summary>Trenutni status članstva.</summary>
    public enum StatusČlanstva
    {
        /// <summary>Članstvo je trenutno aktivno.</summary>
        Aktivno,
        /// <summary>Članstvu je istekao period važenja.</summary>
        Isteklo,
        /// <summary>Članstvo je otkazano pre isteka.</summary>
        Otkazano
    }
    /// <summary>
    /// Predstavlja članarinu - dokument koji povezuje radnika koji ju je
    /// kreirao sa osobom kojoj članarina pripada.
    /// </summary>
    public class Članstvo : IEntity
    {
        /// <summary>Jedinstveni identifikator članstva.</summary>
        public int ČlanstvoID { get; set; }
        /// <summary>Strani ključ ka osobi kojoj članstvo pripada.</summary>
        public int OsobaID { get; set; }
        /// <summary>Strani ključ ka radniku koji je kreirao članstvo.</summary>
        public int RadnikID { get; set; }
        /// <summary>Datum početka važenja članstva.</summary>
        public DateTime DatumPočetka { get; set; }
        /// <summary>Datum isteka važenja članstva.</summary>
        public DateTime DatumIsteka { get; set; }
        /// <summary>Ukupna cena članstva.</summary>
        public decimal Cena { get; set; }
        /// <summary>Trenutni status članstva.</summary>
        public StatusČlanstva Status { get; set; }
        /// <summary>Naziv tabele u bazi za ovaj entitet.</summary>
        public string TableName => "Clanstvo";

        /// <summary>Vrednosti za SQL INSERT, redosledom kolona iz tabele (bez IDENTITY kolone).</summary>
        public string Values => $"{OsobaID}, {RadnikID}, '{DatumPočetka:yyyyMMdd}', '{DatumIsteka:yyyyMMdd}', {Cena.ToString(CultureInfo.InvariantCulture)}, '{Status}'";

        /// <summary>Dodatni JOIN deo upita - nije potreban za ovaj entitet.</summary>
        public string Join => "";

        /// <summary>Mapira redove iz SqlDataReader-a u listu objekata tipa Članstvo.</summary>
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new Članstvo
                {
                    ČlanstvoID = (int)reader["ClanstvoID"],
                    OsobaID = (int)reader["OsobaID"],
                    RadnikID = (int)reader["RadnikID"],
                    DatumPočetka = (DateTime)reader["DatumPocetka"],
                    DatumIsteka = (DateTime)reader["DatumIsteka"],
                    Cena = (decimal)reader["Cena"],
                    Status = Enum.Parse<StatusČlanstva>((string)reader["Status"])
                });
            }
            return lista;
        }
    }
}
