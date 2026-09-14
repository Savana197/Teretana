using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class RadnikKvalifikacija
    {
        public int RadnikID { get; set; }
        public int KvalifikacijaID { get; set; }
        public DateTime DatumSticanja { get; set; }
        public DateTime? DatumIsteka { get; set; }
    }
}
