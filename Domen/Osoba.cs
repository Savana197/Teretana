using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Osoba
    {
        public int OsobaID { get; set; }
        public int KategorijaID { get; set; }
        public required string Ime { get; set; }
        public required string Prezime { get; set; }
        public required string JMBG { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public required string Email { get; set; }
        public required string Adresa { get; set; }
        public required string BrojTelefona { get; set; }
    }
}
