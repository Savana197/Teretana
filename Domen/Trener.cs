using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Trener
    {
        public int TrenerID { get; set; }
        public required string Ime { get; set; }
        public required string Prezime { get; set; }
        public required string Specijalnost { get; set; }
        public required string BrojTelefona { get; set; }
        public required string Email { get; set; }
        public int GodineIskustva { get; set; }
        public bool Aktivan { get; set; }
    }
}
