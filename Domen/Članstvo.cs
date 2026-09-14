using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
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
    public class Članstvo
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
    }
}
