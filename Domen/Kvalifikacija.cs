using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public enum Nivo
    {
        Osnovni,
        Napredni,
        Ekspert

    }
    public class Kvalifikacija
    {
        public int KvalifikacijaID { get; set; }
        public required string Naziv { get; set; }
        public Nivo Nivo { get; set; }

    }
}
