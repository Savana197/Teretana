using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>Integracioni testovi za PretraziRadnikaSO.</summary>
public class PretraziRadnikaSOTestovi : SOTestBase
{
    [Fact]
    public void PretraziRadnika_PronalaziPoDelimicnomPrezimenu()
    {
        string jedinstvenoPrezime = $"Jedinstveno{Guid.NewGuid():N}";
        string email = $"pretraga_{Guid.NewGuid():N}@test.com";

        try
        {
            broker.Add(new Radnik { Ime = "Test", Prezime = jedinstvenoPrezime, Sifra = "test123", Email = email, BrojTelefona = "0600000000", Aktivan = true });

            PretraziRadnikaSO so = new PretraziRadnikaSO(jedinstvenoPrezime);
            so.ExecuteTemplate();

            Assert.Single(so.Result);
            Assert.Equal(jedinstvenoPrezime, so.Result[0].Prezime);
        }
        finally
        {
            broker.Delete(new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" }, $"Email = '{email}'");
        }
    }

    [Fact]
    public void PretraziRadnika_NemaPoklapanja_VracaPraznuListu()
    {
        string nepostojeciKriterijum = $"NePostoji{Guid.NewGuid():N}";

        PretraziRadnikaSO so = new PretraziRadnikaSO(nepostojeciKriterijum);
        so.ExecuteTemplate();

        Assert.Empty(so.Result);
    }
}
