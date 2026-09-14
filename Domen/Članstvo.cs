using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public enum StatusČlanstva
    {
        Aktivno,
        Isteklo,
        Otkazano
    }
    public class Članstvo
    {
        public int ČlanstvoID { get; set; }
        public int OsobaID { get; set; }
        public int RadnikID { get; set; }
        public DateTime DatumPočetka { get; set; }
        public DateTime DatumIsteka { get; set; }
        public decimal Cena { get; set; }
        public StatusČlanstva Status { get; set; }
    }
}
