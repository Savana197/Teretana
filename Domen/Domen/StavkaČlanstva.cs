using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domen
{
    /// <summary>Vrsta treninga koji stavka članstva pokriva.</summary>
    public enum VrstaTreninga
    {
        /// <summary>Individualni (personalni) trening.</summary>
        Individualni,
        /// <summary>Grupni trening.</summary>
        Grupni
    }
    /// <summary>
    /// Asocijativna klasa koja predstavlja jednu stavku u okviru članstva -
    /// povezuje članstvo sa trenerom i definiše vrstu i broj treninga.
    /// </summary>
    public class StavkaČlanstva : IEntity
    {
        /// <summary>Redni broj stavke unutar članstva (deo složenog ključa).</summary>
        public int Rb { get; set; }
        /// <summary>Strani ključ ka članstvu kom stavka pripada (deo složenog ključa).</summary>
        public int ČlanstvoID { get; set; }
        /// <summary>Strani ključ ka treneru koji vodi ovu stavku treninga.</summary>
        public int TrenerID { get; set; }
        /// <summary>Vrsta treninga (individualni ili grupni).</summary>
        public VrstaTreninga VrstaTreninga { get; set; }
        /// <summary>Ukupan broj termina uključenih u ovu stavku.</summary>
        public int BrojTermina { get; set; }
        /// <summary>Broj do sada iskorišćenih termina.</summary>
        public int Iskorišćeno { get; set; }
        /// <summary>Cena ove stavke članstva.</summary>
        public decimal CenaStavke { get; set; }
        /// <summary>Naziv tabele u bazi za ovaj entitet.</summary>
        public string TableName => "StavkaClanstva";

        /// <summary>Vrednosti za SQL INSERT, redosledom kolona iz tabele (uključujući oba dela složenog ključa).</summary>
        public string Values => $"{Rb}, {ČlanstvoID}, {TrenerID}, '{VrstaTreninga}', {BrojTermina}, {Iskorišćeno}, {CenaStavke.ToString(CultureInfo.InvariantCulture)}";

        /// <summary>Dodatni JOIN deo upita - nije potreban za ovaj entitet.</summary>
        public string Join => "";

        /// <summary>Mapira redove iz SqlDataReader-a u listu objekata tipa StavkaČlanstva.</summary>
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new StavkaČlanstva
                {
                    ČlanstvoID = (int)reader["ClanstvoID"],
                    Rb = (int)reader["Rb"],
                    TrenerID = (int)reader["TrenerID"],
                    VrstaTreninga = Enum.Parse<VrstaTreninga>((string)reader["VrstaTreninga"]),
                    BrojTermina = (int)reader["BrojTermina"],
                    Iskorišćeno = (int)reader["Iskorisceno"],
                    CenaStavke = (decimal)reader["CenaStavke"]
                });
            }
            return lista;
        }
    }
}
