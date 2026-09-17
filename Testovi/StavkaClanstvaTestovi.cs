using Common.Domen;

namespace Testovi;

/// <summary>Testovi domenske klase StavkaČlanstva (svojstva, TableName, Values format za SQL INSERT).</summary>
public class StavkaClanstvaTestovi
{
    [Fact]
    public void Konstrukcija_PostavljaSvaPolja()
    {
        StavkaČlanstva stavka = new StavkaČlanstva
        {
            Rb = 1,
            ČlanstvoID = 9,
            TrenerID = 4,
            VrstaTreninga = VrstaTreninga.Individualni,
            BrojTermina = 10,
            Iskorišćeno = 2,
            CenaStavke = 300m
        };

        Assert.Equal(1, stavka.Rb);
        Assert.Equal(9, stavka.ČlanstvoID);
        Assert.Equal(4, stavka.TrenerID);
        Assert.Equal(VrstaTreninga.Individualni, stavka.VrstaTreninga);
        Assert.Equal(10, stavka.BrojTermina);
        Assert.Equal(2, stavka.Iskorišćeno);
        Assert.Equal(300m, stavka.CenaStavke);
    }

    [Fact]
    public void TableName_JeStavkaClanstva_BezDijakritika()
    {
        StavkaČlanstva stavka = new StavkaČlanstva();
        Assert.Equal("StavkaClanstva", stavka.TableName);
    }

    [Fact]
    public void Values_FormatiraPoljaZaInsert()
    {
        StavkaČlanstva stavka = new StavkaČlanstva
        {
            Rb = 1,
            ČlanstvoID = 9,
            TrenerID = 4,
            VrstaTreninga = VrstaTreninga.Grupni,
            BrojTermina = 10,
            Iskorišćeno = 0,
            CenaStavke = 300m
        };

        Assert.Equal("1, 9, 4, 'Grupni', 10, 0, 300", stavka.Values);
    }

    [Fact]
    public void Join_JePrazan()
    {
        StavkaČlanstva stavka = new StavkaČlanstva();
        Assert.Equal("", stavka.Join);
    }

    [Fact]
    public void Rb_NegativnaVrednost_BacaIzuzetak()
    {
        StavkaČlanstva stavka = new StavkaČlanstva();
        Assert.Throws<ArgumentOutOfRangeException>(() => stavka.Rb = -1);
    }

    [Fact]
    public void VrstaTreninga_NedefinisanaVrednostEnuma_BacaIzuzetak()
    {
        StavkaČlanstva stavka = new StavkaČlanstva();
        Assert.Throws<ArgumentOutOfRangeException>(() => stavka.VrstaTreninga = (VrstaTreninga)99);
    }

    [Fact]
    public void BrojTermina_Negativan_BacaIzuzetak()
    {
        StavkaČlanstva stavka = new StavkaČlanstva();
        Assert.Throws<ArgumentOutOfRangeException>(() => stavka.BrojTermina = -1);
    }

    [Fact]
    public void CenaStavke_Negativna_BacaIzuzetak()
    {
        StavkaČlanstva stavka = new StavkaČlanstva();
        Assert.Throws<ArgumentOutOfRangeException>(() => stavka.CenaStavke = -50m);
    }
}
