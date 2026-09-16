using Common.Domen;

namespace Testovi;

/// <summary>Testovi domenske klase RadnikKvalifikacija (svojstva, TableName, Values format za SQL INSERT).</summary>
public class RadnikKvalifikacijaTestovi
{
    [Fact]
    public void Konstrukcija_PostavljaSvaPolja()
    {
        DateTime sticanje = new DateTime(2024, 1, 10);
        DateTime isteka = new DateTime(2026, 1, 10);
        RadnikKvalifikacija rk = new RadnikKvalifikacija
        {
            RadnikID = 2,
            KvalifikacijaID = 5,
            DatumSticanja = sticanje,
            DatumIsteka = isteka
        };

        Assert.Equal(2, rk.RadnikID);
        Assert.Equal(5, rk.KvalifikacijaID);
        Assert.Equal(sticanje, rk.DatumSticanja);
        Assert.Equal(isteka, rk.DatumIsteka);
    }

    [Fact]
    public void TableName_JeRadnikKvalifikacija()
    {
        RadnikKvalifikacija rk = new RadnikKvalifikacija();
        Assert.Equal("RadnikKvalifikacija", rk.TableName);
    }

    [Fact]
    public void Values_SaDatumomIsteka_FormatiraObaDatuma()
    {
        RadnikKvalifikacija rk = new RadnikKvalifikacija
        {
            RadnikID = 2,
            KvalifikacijaID = 5,
            DatumSticanja = new DateTime(2024, 1, 10),
            DatumIsteka = new DateTime(2026, 1, 10)
        };

        Assert.Equal("2, 5, '20240110', '20260110'", rk.Values);
    }

    [Fact]
    public void Values_BezDatumaIsteka_DajeNULL()
    {
        RadnikKvalifikacija rk = new RadnikKvalifikacija
        {
            RadnikID = 2,
            KvalifikacijaID = 5,
            DatumSticanja = new DateTime(2024, 1, 10),
            DatumIsteka = null
        };

        Assert.Equal("2, 5, '20240110', NULL", rk.Values);
    }

    [Fact]
    public void Join_JePrazan()
    {
        RadnikKvalifikacija rk = new RadnikKvalifikacija();
        Assert.Equal("", rk.Join);
    }
}
