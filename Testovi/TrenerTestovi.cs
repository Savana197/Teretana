using Common.Domen;

namespace Testovi;

/// <summary>Testovi domenske klase Trener (svojstva, TableName, Values format za SQL INSERT).</summary>
public class TrenerTestovi
{
    [Fact]
    public void Konstrukcija_PostavljaSvaPolja()
    {
        Trener trener = new Trener
        {
            TrenerID = 4,
            Ime = "Marko",
            Prezime = "Marković",
            Specijalnost = "Joga",
            BrojTelefona = "0622222222",
            Email = "marko@test.com",
            GodineIskustva = 5,
            Aktivan = true
        };

        Assert.Equal(4, trener.TrenerID);
        Assert.Equal("Marko", trener.Ime);
        Assert.Equal("Marković", trener.Prezime);
        Assert.Equal("Joga", trener.Specijalnost);
        Assert.Equal("0622222222", trener.BrojTelefona);
        Assert.Equal("marko@test.com", trener.Email);
        Assert.Equal(5, trener.GodineIskustva);
        Assert.True(trener.Aktivan);
    }

    [Fact]
    public void TableName_JeTrener()
    {
        Trener trener = new Trener { Ime = "", Prezime = "", Specijalnost = "", BrojTelefona = "", Email = "" };
        Assert.Equal("Trener", trener.TableName);
    }

    [Fact]
    public void Values_FormatiraPoljaZaInsert()
    {
        Trener trener = new Trener
        {
            Ime = "Marko",
            Prezime = "Marković",
            Specijalnost = "Joga",
            BrojTelefona = "0622222222",
            Email = "marko@test.com",
            GodineIskustva = 5,
            Aktivan = true
        };

        string ocekivano = "'Marko', 'Marković', 'Joga', '0622222222', 'marko@test.com', 5, 1";
        Assert.Equal(ocekivano, trener.Values);
    }

    [Fact]
    public void Values_AktivanFalse_DajeNulu()
    {
        Trener trener = new Trener
        {
            Ime = "Marko",
            Prezime = "Marković",
            Specijalnost = "Joga",
            BrojTelefona = "0622222222",
            Email = "marko@test.com",
            GodineIskustva = 5,
            Aktivan = false
        };

        Assert.EndsWith(", 0", trener.Values);
    }

    [Fact]
    public void Join_JePrazan()
    {
        Trener trener = new Trener { Ime = "", Prezime = "", Specijalnost = "", BrojTelefona = "", Email = "" };
        Assert.Equal("", trener.Join);
    }
}
