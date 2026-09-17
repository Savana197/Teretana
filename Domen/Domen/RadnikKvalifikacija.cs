using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domen
{
    /// <summary>
    /// Asocijativna klasa koja povezuje radnika sa kvalifikacijom koju
    /// poseduje (many-to-many veza između Radnika i Kvalifikacije).
    /// </summary>
    public class RadnikKvalifikacija : IEntity
    {
        private int radnikID;
        private int kvalifikacijaID;
        private DateTime datumSticanja;

        /// <summary>Strani ključ ka radniku (deo složenog ključa). Ne sme biti negativan.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Ako je vrednost negativna.</exception>
        public int RadnikID
        {
            get => radnikID;
            set => radnikID = Validacija.NenegativanBroj(value, nameof(RadnikID));
        }

        /// <summary>Strani ključ ka kvalifikaciji (deo složenog ključa). Ne sme biti negativan.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Ako je vrednost negativna.</exception>
        public int KvalifikacijaID
        {
            get => kvalifikacijaID;
            set => kvalifikacijaID = Validacija.NenegativanBroj(value, nameof(KvalifikacijaID));
        }

        /// <summary>Datum sticanja kvalifikacije. Ne sme biti u budućnosti.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Ako je datum u budućnosti.</exception>
        public DateTime DatumSticanja
        {
            get => datumSticanja;
            set => datumSticanja = Validacija.NijeUBuducnosti(value, nameof(DatumSticanja));
        }

        /// <summary>Datum isteka kvalifikacije, ako kvalifikacija ističe (null ako ne ističe).</summary>
        public DateTime? DatumIsteka { get; set; }
        /// <summary>Naziv tabele u bazi za ovaj entitet.</summary>
        public string TableName => "RadnikKvalifikacija";

        /// <summary>Vrednosti za SQL INSERT, redosledom kolona iz tabele (uključujući oba dela složenog ključa).</summary>
        public string Values => $"{RadnikID}, {KvalifikacijaID}, '{DatumSticanja:yyyyMMdd}', {(DatumIsteka.HasValue ? $"'{DatumIsteka.Value:yyyyMMdd}'" : "NULL")}";

        /// <summary>Dodatni JOIN deo upita - nije potreban za ovaj entitet.</summary>
        public string Join => "";

        /// <summary>Mapira redove iz SqlDataReader-a u listu objekata tipa RadnikKvalifikacija.</summary>
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new RadnikKvalifikacija
                {
                    RadnikID = (int)reader["RadnikID"],
                    KvalifikacijaID = (int)reader["KvalifikacijaID"],
                    DatumSticanja = (DateTime)reader["DatumSticanja"],
                    DatumIsteka = reader["DatumIsteka"] == DBNull.Value ? null : (DateTime)reader["DatumIsteka"]
                });
            }
            return lista;
        }
    }
}
