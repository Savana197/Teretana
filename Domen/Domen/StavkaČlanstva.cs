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
        private int rb;
        private int članstvoID;
        private int trenerID;
        private VrstaTreninga vrstaTreninga;
        private int brojTermina;
        private int iskorišćeno;
        private decimal cenaStavke;

        /// <summary>Redni broj stavke unutar članstva (deo složenog ključa). Ne sme biti negativan.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Ako je vrednost negativna.</exception>
        public int Rb
        {
            get => rb;
            set => rb = Validacija.NenegativanBroj(value, nameof(Rb));
        }

        /// <summary>Strani ključ ka članstvu kom stavka pripada (deo složenog ključa). Ne sme biti negativan.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Ako je vrednost negativna.</exception>
        public int ČlanstvoID
        {
            get => članstvoID;
            set => članstvoID = Validacija.NenegativanBroj(value, nameof(ČlanstvoID));
        }

        /// <summary>Strani ključ ka treneru koji vodi ovu stavku treninga. Ne sme biti negativan.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Ako je vrednost negativna.</exception>
        public int TrenerID
        {
            get => trenerID;
            set => trenerID = Validacija.NenegativanBroj(value, nameof(TrenerID));
        }

        /// <summary>Vrsta treninga (individualni ili grupni). Mora biti jedna od definisanih vrednosti enuma <see cref="VrstaTreninga"/>.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Ako vrednost nije definisana u enumu.</exception>
        public VrstaTreninga VrstaTreninga
        {
            get => vrstaTreninga;
            set => vrstaTreninga = Validacija.ValidnaEnumVrednost(value, nameof(VrstaTreninga));
        }

        /// <summary>Ukupan broj termina uključenih u ovu stavku. Ne sme biti negativan.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Ako je vrednost negativna.</exception>
        public int BrojTermina
        {
            get => brojTermina;
            set => brojTermina = Validacija.NenegativanBroj(value, nameof(BrojTermina));
        }

        /// <summary>Broj do sada iskorišćenih termina. Ne sme biti negativan.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Ako je vrednost negativna.</exception>
        public int Iskorišćeno
        {
            get => iskorišćeno;
            set => iskorišćeno = Validacija.NenegativanBroj(value, nameof(Iskorišćeno));
        }

        /// <summary>Cena ove stavke članstva. Ne sme biti negativna.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Ako je vrednost negativna.</exception>
        public decimal CenaStavke
        {
            get => cenaStavke;
            set => cenaStavke = Validacija.NenegativanBroj(value, nameof(CenaStavke));
        }

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
