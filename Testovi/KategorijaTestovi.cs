using Common.Domen;

namespace Testovi;

/// <summary>Testovi domenske klase Kategorija (svojstva, TableName, Values format za SQL INSERT).</summary>
public class KategorijaTestovi
{
    [Fact]
    public void Konstrukcija_PostavljaSvaPolja()
    {
        Kategorija kategorija = new Kategorija { KategorijaID = 1, Naziv = "VIP", Popust = 20m };

        Assert.Equal(1, kategorija.KategorijaID);
        Assert.Equal("VIP", kategorija.Naziv);
        Assert.Equal(20m, kategorija.Popust);
    }

    [Fact]
    public void TableName_JeKategorija()
    {
        Kategorija kategorija = new Kategorija { Naziv = "" };
        Assert.Equal("Kategorija", kategorija.TableName);
    }

    [Fact]
    public void Values_FormatiraPoljaZaInsert()
    {
        Kategorija kategorija = new Kategorija { Naziv = "VIP", Popust = 20m };
        Assert.Equal("'VIP', 20", kategorija.Values);
    }

    [Fact]
    public void Values_BezPopusta_DajeNulu()
    {
        Kategorija kategorija = new Kategorija { Naziv = "Standard", Popust = 0m };
        Assert.Equal("'Standard', 0", kategorija.Values);
    }

    [Fact]
    public void Join_JePrazan()
    {
        Kategorija kategorija = new Kategorija { Naziv = "" };
        Assert.Equal("", kategorija.Join);
    }

    [Fact]
    public void KategorijaID_NegativnaVrednost_BacaIzuzetak()
    {
        Kategorija kategorija = new Kategorija { Naziv = "" };
        Assert.Throws<ArgumentOutOfRangeException>(() => kategorija.KategorijaID = -1);
    }

    [Fact]
    public void Naziv_Null_BacaIzuzetak()
    {
        Kategorija kategorija = new Kategorija { Naziv = "" };
        Assert.Throws<ArgumentNullException>(() => kategorija.Naziv = null!);
    }

    [Fact]
    public void Popust_Negativan_BacaIzuzetak()
    {
        Kategorija kategorija = new Kategorija { Naziv = "" };
        Assert.Throws<ArgumentOutOfRangeException>(() => kategorija.Popust = -5m);
    }

    [Fact]
    public void Popust_VeciOd100_BacaIzuzetak()
    {
        Kategorija kategorija = new Kategorija { Naziv = "" };
        Assert.Throws<ArgumentOutOfRangeException>(() => kategorija.Popust = 150m);
    }
}
