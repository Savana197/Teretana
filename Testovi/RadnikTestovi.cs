using Common.Domen;

namespace Testovi;

/// <summary>Testovi domenske klase Radnik (svojstva, TableName, Values format za SQL INSERT).</summary>
public class RadnikTestovi
{
    [Fact]
    public void Konstrukcija_PostavljaSvaPolja()
    {
        Radnik radnik = new Radnik
        {
            RadnikID = 5,
            Ime = "Petar",
            Prezime = "Petrović",
            Sifra = "sifra123",
            Email = "petar@test.com",
            BrojTelefona = "0641234567",
            Aktivan = true
        };

        Assert.Equal(5, radnik.RadnikID);
        Assert.Equal("Petar", radnik.Ime);
        Assert.Equal("Petrović", radnik.Prezime);
        Assert.Equal("sifra123", radnik.Sifra);
        Assert.Equal("petar@test.com", radnik.Email);
        Assert.Equal("0641234567", radnik.BrojTelefona);
        Assert.True(radnik.Aktivan);
    }

    [Fact]
    public void TableName_JeRadnik()
    {
        Radnik radnik = new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" };
        Assert.Equal("Radnik", radnik.TableName);
    }

    [Fact]
    public void Values_FormatiraPoljaZaInsert_AktivanTrue()
    {
        Radnik radnik = new Radnik
        {
            Ime = "Petar",
            Prezime = "Petrović",
            Sifra = "sifra123",
            Email = "petar@test.com",
            BrojTelefona = "0641234567",
            Aktivan = true
        };

        string ocekivano = "'Petar', 'Petrović', 'sifra123', 'petar@test.com', '0641234567', 1";
        Assert.Equal(ocekivano, radnik.Values);
    }

    [Fact]
    public void Values_AktivanFalse_DajeNulu()
    {
        Radnik radnik = new Radnik
        {
            Ime = "Petar",
            Prezime = "Petrović",
            Sifra = "sifra123",
            Email = "petar@test.com",
            BrojTelefona = "0641234567",
            Aktivan = false
        };

        Assert.EndsWith(", 0", radnik.Values);
    }

    [Fact]
    public void Join_JePrazan()
    {
        Radnik radnik = new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" };
        Assert.Equal("", radnik.Join);
    }
}
