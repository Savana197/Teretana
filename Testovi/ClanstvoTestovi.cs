using Common.Domen;

namespace Testovi;

/// <summary>Testovi domenske klase Članstvo (svojstva, TableName, Values format za SQL INSERT).</summary>
public class ClanstvoTestovi
{
    [Fact]
    public void Konstrukcija_PostavljaSvaPolja()
    {
        DateTime pocetak = new DateTime(2026, 1, 1);
        DateTime istek = new DateTime(2026, 2, 1);
        Članstvo clanstvo = new Članstvo
        {
            ČlanstvoID = 9,
            OsobaID = 1,
            RadnikID = 2,
            DatumPočetka = pocetak,
            DatumIsteka = istek,
            Cena = 1500m,
            Status = StatusČlanstva.Aktivno
        };

        Assert.Equal(9, clanstvo.ČlanstvoID);
        Assert.Equal(1, clanstvo.OsobaID);
        Assert.Equal(2, clanstvo.RadnikID);
        Assert.Equal(pocetak, clanstvo.DatumPočetka);
        Assert.Equal(istek, clanstvo.DatumIsteka);
        Assert.Equal(1500m, clanstvo.Cena);
        Assert.Equal(StatusČlanstva.Aktivno, clanstvo.Status);
    }

    [Fact]
    public void TableName_JeClanstvo_BezDijakritika()
    {
        Članstvo clanstvo = new Članstvo();
        Assert.Equal("Clanstvo", clanstvo.TableName);
    }

    [Fact]
    public void Values_FormatiraPoljaZaInsert()
    {
        Članstvo clanstvo = new Članstvo
        {
            OsobaID = 1,
            RadnikID = 2,
            DatumPočetka = new DateTime(2026, 1, 1),
            DatumIsteka = new DateTime(2026, 2, 1),
            Cena = 1500m,
            Status = StatusČlanstva.Aktivno
        };

        Assert.Equal("1, 2, '20260101', '20260201', 1500, 'Aktivno'", clanstvo.Values);
    }

    [Fact]
    public void Status_PodrazumevanaVrednost_JeAktivno()
    {
        // enum default (0) je prva deklarisana vrednost - Aktivno
        Članstvo clanstvo = new Članstvo();
        Assert.Equal(StatusČlanstva.Aktivno, clanstvo.Status);
    }

    [Fact]
    public void Join_JePrazan()
    {
        Članstvo clanstvo = new Članstvo();
        Assert.Equal("", clanstvo.Join);
    }

    [Fact]
    public void ČlanstvoID_NegativnaVrednost_BacaIzuzetak()
    {
        Članstvo clanstvo = new Članstvo();
        Assert.Throws<ArgumentOutOfRangeException>(() => clanstvo.ČlanstvoID = -1);
    }

    [Fact]
    public void OsobaID_NegativnaVrednost_BacaIzuzetak()
    {
        Članstvo clanstvo = new Članstvo();
        Assert.Throws<ArgumentOutOfRangeException>(() => clanstvo.OsobaID = -1);
    }

    [Fact]
    public void Cena_Negativna_BacaIzuzetak()
    {
        Članstvo clanstvo = new Članstvo();
        Assert.Throws<ArgumentOutOfRangeException>(() => clanstvo.Cena = -100m);
    }

    [Fact]
    public void Status_NedefinisanaVrednostEnuma_BacaIzuzetak()
    {
        Članstvo clanstvo = new Članstvo();
        Assert.Throws<ArgumentOutOfRangeException>(() => clanstvo.Status = (StatusČlanstva)99);
    }
}
