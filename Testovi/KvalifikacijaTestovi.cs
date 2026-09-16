using Common.Domen;

namespace Testovi;

/// <summary>Testovi domenske klase Kvalifikacija (svojstva, TableName, Values format za SQL INSERT).</summary>
public class KvalifikacijaTestovi
{
    [Fact]
    public void Konstrukcija_PostavljaSvaPolja()
    {
        Kvalifikacija kvalifikacija = new Kvalifikacija { KvalifikacijaID = 3, Naziv = "Fitnes instruktor", Nivo = Nivo.Napredni };

        Assert.Equal(3, kvalifikacija.KvalifikacijaID);
        Assert.Equal("Fitnes instruktor", kvalifikacija.Naziv);
        Assert.Equal(Nivo.Napredni, kvalifikacija.Nivo);
    }

    [Fact]
    public void TableName_JeKvalifikacija()
    {
        Kvalifikacija kvalifikacija = new Kvalifikacija { Naziv = "" };
        Assert.Equal("Kvalifikacija", kvalifikacija.TableName);
    }

    [Fact]
    public void Values_FormatiraPoljaZaInsert()
    {
        Kvalifikacija kvalifikacija = new Kvalifikacija { Naziv = "Nutricionista", Nivo = Nivo.Ekspert };
        Assert.Equal("'Nutricionista', 'Ekspert'", kvalifikacija.Values);
    }

    [Fact]
    public void Join_JePrazan()
    {
        Kvalifikacija kvalifikacija = new Kvalifikacija { Naziv = "" };
        Assert.Equal("", kvalifikacija.Join);
    }
}
