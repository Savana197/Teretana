using System;
using System.Linq;

namespace Common.Domen
{
    /// <summary>
    /// Pomoćne metode za validaciju vrednosti u set metodama domenskih klasa.
    /// Prazan string ("") se svuda tretira kao "još nije postavljeno" i
    /// propušta se bez provere formata (koristi se u Broker pozivima kao
    /// "prazan" objekat samo za pristup TableName/GetReaderList) - baca se
    /// izuzetak samo za null i za stvarno nevalidne, popunjene vrednosti.
    /// </summary>
    internal static class Validacija
    {
        /// <summary>Proverava da tekstualno polje nije null, da nije samo razmaci (ako je popunjeno) i da ne prelazi maksimalnu dužinu.</summary>
        public static string ObaveznoPolje(string vrednost, string nazivPolja, int maksimalnaDuzina = 100)
        {
            if (vrednost == null)
                throw new ArgumentNullException(nazivPolja, $"{nazivPolja} ne sme biti null.");
            if (vrednost.Length > 0 && string.IsNullOrWhiteSpace(vrednost))
                throw new ArgumentException($"{nazivPolja} ne sme sadržati samo razmake.", nazivPolja);
            if (vrednost.Length > maksimalnaDuzina)
                throw new ArgumentException($"{nazivPolja} ne sme biti duži od {maksimalnaDuzina} karaktera.", nazivPolja);
            return vrednost;
        }

        /// <summary>Proverava da je vrednost validna email adresa (ako je popunjena).</summary>
        public static string Email(string vrednost, string nazivPolja = "Email")
        {
            vrednost = ObaveznoPolje(vrednost, nazivPolja, 150);
            if (vrednost.Length > 0 &&
                (!vrednost.Contains('@') || !vrednost.Contains('.') ||
                 vrednost.StartsWith("@") || vrednost.EndsWith("@") || vrednost.Count(c => c == '@') != 1))
            {
                throw new ArgumentException($"{nazivPolja} nije validna email adresa.", nazivPolja);
            }
            return vrednost;
        }

        /// <summary>Proverava da broj telefona (ako je popunjen) sadrži samo cifre i ima razumnu dužinu.</summary>
        public static string BrojTelefona(string vrednost, string nazivPolja = "BrojTelefona")
        {
            vrednost = ObaveznoPolje(vrednost, nazivPolja, 20);
            if (vrednost.Length > 0 && (!vrednost.All(char.IsDigit) || vrednost.Length < 6))
                throw new ArgumentException($"{nazivPolja} mora sadržati samo cifre i najmanje 6 cifara.", nazivPolja);
            return vrednost;
        }

        /// <summary>Proverava da lozinka (ako je popunjena) ima bar 4 karaktera.</summary>
        public static string Lozinka(string vrednost, string nazivPolja = "Sifra")
        {
            vrednost = ObaveznoPolje(vrednost, nazivPolja, 50);
            if (vrednost.Length > 0 && vrednost.Length < 4)
                throw new ArgumentException($"{nazivPolja} mora imati bar 4 karaktera.", nazivPolja);
            return vrednost;
        }

        /// <summary>Proverava da JMBG (ako je popunjen) ima tačno 13 cifara.</summary>
        public static string Jmbg(string vrednost)
        {
            vrednost = ObaveznoPolje(vrednost, "JMBG", 13);
            if (vrednost.Length > 0 && (vrednost.Length != 13 || !vrednost.All(char.IsDigit)))
                throw new ArgumentException("JMBG mora sadržati tačno 13 cifara.", "JMBG");
            return vrednost;
        }

        /// <summary>Proverava da ceo broj nije negativan.</summary>
        public static int NenegativanBroj(int vrednost, string nazivPolja)
        {
            if (vrednost < 0)
                throw new ArgumentOutOfRangeException(nazivPolja, $"{nazivPolja} ne sme biti negativan.");
            return vrednost;
        }

        /// <summary>Proverava da decimalni broj nije negativan.</summary>
        public static decimal NenegativanBroj(decimal vrednost, string nazivPolja)
        {
            if (vrednost < 0)
                throw new ArgumentOutOfRangeException(nazivPolja, $"{nazivPolja} ne sme biti negativan.");
            return vrednost;
        }

        /// <summary>Proverava da je procenat u granicama od 0 do 100.</summary>
        public static decimal Procenat(decimal vrednost, string nazivPolja)
        {
            if (vrednost < 0 || vrednost > 100)
                throw new ArgumentOutOfRangeException(nazivPolja, $"{nazivPolja} mora biti između 0 i 100.");
            return vrednost;
        }

        /// <summary>Proverava da broj godina iskustva nije negativan niti nerealno velik.</summary>
        public static int GodineIskustva(int vrednost, string nazivPolja = "GodineIskustva")
        {
            if (vrednost < 0 || vrednost > 70)
                throw new ArgumentOutOfRangeException(nazivPolja, $"{nazivPolja} mora biti između 0 i 70.");
            return vrednost;
        }

        /// <summary>Proverava da enum vrednost pripada definisanim vrednostima svog tipa.</summary>
        public static T ValidnaEnumVrednost<T>(T vrednost, string nazivPolja) where T : struct, Enum
        {
            if (!Enum.IsDefined(typeof(T), vrednost))
                throw new ArgumentOutOfRangeException(nazivPolja, $"{nazivPolja} sadrži nepoznatu vrednost enuma {typeof(T).Name}.");
            return vrednost;
        }

        /// <summary>Proverava da datum nije u budućnosti.</summary>
        public static DateTime NijeUBuducnosti(DateTime vrednost, string nazivPolja)
        {
            if (vrednost > DateTime.Today)
                throw new ArgumentOutOfRangeException(nazivPolja, $"{nazivPolja} ne sme biti u budućnosti.");
            return vrednost;
        }
    }
}
