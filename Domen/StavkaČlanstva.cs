using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public enum VrstaTreninga
    {
        Individualni,
        Grupni
    }
    public class StavkaČlanstva
    {
        public int Rb { get; set; }
        public int ČlanstvoID { get; set; }
        public int TrenerID { get; set; }
        public VrstaTreninga VrstaTreninga { get; set; }
        public int BrojTermina { get; set; }
        public int Iskorišćeno { get; set; }
        public decimal CenaStavke { get; set; }
    }
}
