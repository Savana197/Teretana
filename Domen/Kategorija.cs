using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    /// <summary>
    /// Šifarnik kategorija osoba (npr. Standard, Junior, Senior, VIP) -
    /// određuje popust koji se primenjuje na članarinu osobe iz te kategorije.
    /// </summary>
    public class Kategorija
    {
        /// <summary>Jedinstveni identifikator kategorije.</summary>
        public int KategorijaID { get; set; }
        /// <summary>Naziv kategorije.</summary>
        public required string Naziv { get; set; }
        /// <summary>Procenat popusta koji se primenjuje na osobe ove kategorije.</summary>
        public decimal Popust { get; set; }

    }
}
