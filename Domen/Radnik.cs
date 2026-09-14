using System.Security.Principal;

namespace Domen
{
    public class Radnik
    {
        public int RadnikID { get; set; }
        public required string Ime { get; set; }
        public required string Prezime { get; set; }
        public required string Sifra { get; set; }
        public required string Email { get; set; }
        public required string BrojTelefona { get; set; }
        public bool Aktivan { get; set; }

    }
}
