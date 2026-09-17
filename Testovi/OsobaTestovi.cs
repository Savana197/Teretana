using Common.Domen;

namespace Testovi;

/// <summary>Testovi domenske klase Osoba (svojstva, TableName, Values format za SQL INSERT).</summary>
public class OsobaTestovi
{
    [Fact]
    public void Konstrukcija_PostavljaSvaPolja()
    {
        DateTime datumRodjenja = new DateTime(1995, 3, 20);
        Osoba osoba = new Osoba
        {
            OsobaID = 7,
            KategorijaID = 2,
            Ime = "Ana",
            Prezime = "Anić",
            JMBG = "1234567890123",
            DatumRodjenja = datumRodjenja,
            Email = "ana@test.com",
            Adresa = "Trg 1",
            BrojTelefona = "0611111111"
        };

        Assert.Equal(7, osoba.OsobaID);
        Assert.Equal(2, osoba.KategorijaID);
        Assert.Equal("Ana", osoba.Ime);
        Assert.Equal("Anić", osoba.Prezime);
        Assert.Equal("1234567890123", osoba.JMBG);
        Assert.Equal(datumRodjenja, osoba.DatumRodjenja);
        Assert.Equal("ana@test.com", osoba.Email);
        Assert.Equal("Trg 1", osoba.Adresa);
        Assert.Equal("0611111111", osoba.BrojTelefona);
    }

    [Fact]
    public void TableName_JeOsoba()
    {
        Osoba osoba = new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" };
        Assert.Equal("Osoba", osoba.TableName);
    }

    [Fact]
    public void Values_FormatiraPoljaZaInsert()
    {
        Osoba osoba = new Osoba
        {
            KategorijaID = 3,
            Ime = "Ana",
            Prezime = "Anić",
            JMBG = "1234567890123",
            DatumRodjenja = new DateTime(1995, 3, 20),
            Email = "ana@test.com",
            Adresa = "Trg 1",
            BrojTelefona = "0611111111"
        };

        string ocekivano = "3, 'Ana', 'Anić', '1234567890123', '19950320', 'ana@test.com', 'Trg 1', '0611111111'";
        Assert.Equal(ocekivano, osoba.Values);
    }

    [Fact]
    public void Join_JePrazan()
    {
        Osoba osoba = new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" };
        Assert.Equal("", osoba.Join);
    }

    [Fact]
    public void OsobaID_NegativnaVrednost_BacaIzuzetak()
    {
        Osoba osoba = new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" };
        Assert.Throws<ArgumentOutOfRangeException>(() => osoba.OsobaID = -1);
    }

    [Fact]
    public void KategorijaID_NegativnaVrednost_BacaIzuzetak()
    {
        Osoba osoba = new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" };
        Assert.Throws<ArgumentOutOfRangeException>(() => osoba.KategorijaID = -5);
    }

    [Fact]
    public void Ime_Null_BacaIzuzetak()
    {
        Osoba osoba = new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" };
        Assert.Throws<ArgumentNullException>(() => osoba.Ime = null!);
    }

    [Fact]
    public void JMBG_PogresnaDuzina_BacaIzuzetak()
    {
        Osoba osoba = new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" };
        Assert.Throws<ArgumentException>(() => osoba.JMBG = "12345");
    }

    [Fact]
    public void JMBG_SadrziSlova_BacaIzuzetak()
    {
        Osoba osoba = new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" };
        Assert.Throws<ArgumentException>(() => osoba.JMBG = "abcdefghijklm");
    }

    [Fact]
    public void DatumRodjenja_UBuducnosti_BacaIzuzetak()
    {
        Osoba osoba = new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" };
        Assert.Throws<ArgumentOutOfRangeException>(() => osoba.DatumRodjenja = DateTime.Today.AddDays(1));
    }

    [Fact]
    public void Email_BezTacke_BacaIzuzetak()
    {
        Osoba osoba = new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" };
        Assert.Throws<ArgumentException>(() => osoba.Email = "ana@test");
    }

    [Fact]
    public void BrojTelefona_SadrziSlova_BacaIzuzetak()
    {
        Osoba osoba = new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" };
        Assert.Throws<ArgumentException>(() => osoba.BrojTelefona = "06AB12345");
    }
}
