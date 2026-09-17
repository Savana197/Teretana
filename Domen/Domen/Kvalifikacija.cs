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
        private int kvalifikacijaID;
        private string naziv = "";
        private Nivo nivo;

        /// <summary>Jedinstveni identifikator kvalifikacije. Ne sme biti negativan.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Ako je vrednost negativna.</exception>
        public int KvalifikacijaID
        {
            get => kvalifikacijaID;
            set => kvalifikacijaID = Validacija.NenegativanBroj(value, nameof(KvalifikacijaID));
        }

        /// <summary>Naziv kvalifikacije. Ne sme biti null, sadržati samo razmake, niti biti duži od 50 karaktera.</summary>
        /// <exception cref="ArgumentNullException">Ako je vrednost null.</exception>
        /// <exception cref="ArgumentException">Ako vrednost sadrži samo razmake ili je predugačka.</exception>
        public required string Naziv
        {
            get => naziv;
            set => naziv = Validacija.ObaveznoPolje(value, nameof(Naziv), 50);
        }

        /// <summary>Nivo stručnosti ove kvalifikacije. Mora biti jedna od definisanih vrednosti enuma <see cref="Nivo"/>.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Ako vrednost nije definisana u enumu.</exception>
        public Nivo Nivo
        {
            get => nivo;
            set => nivo = Validacija.ValidnaEnumVrednost(value, nameof(Nivo));
        }

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
