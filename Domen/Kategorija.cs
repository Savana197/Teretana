using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Kategorija
    {
        public int KategorijaID { get; set; }
        public required string Naziv { get; set; }
        public decimal Popust { get; set; }

    }
}
