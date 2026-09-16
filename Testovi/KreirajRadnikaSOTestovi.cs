using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>Integracioni testovi za KreirajRadnikaSO.</summary>
public class KreirajRadnikaSOTestovi : SOTestBase
{
    [Fact]
    public void KreirajRadnika_UpisujeRadnikaUBazu()
    {
        string email = $"kreiraj_{Guid.NewGuid():N}@test.com";
        Radnik noviRadnik = new Radnik
        {
            Ime = "Testni",
            Prezime = "Radnik",
            Sifra = "test123",
            Email = email,
            BrojTelefona = "0600000000"
        };

        try
        {
            KreirajRadnikaSO so = new KreirajRadnikaSO(noviRadnik);
            so.ExecuteTemplate();

            List<IEntity> rezultat = broker.GetByCondition(
                new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" },
                $"Email = '{email}'");
            Radnik sacuvani = Assert.Single(rezultat.Cast<Radnik>());
            Assert.Equal("Testni", sacuvani.Ime);
            Assert.Equal("Radnik", sacuvani.Prezime);
        }
        finally
        {
            broker.Delete(new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" }, $"Email = '{email}'");
        }
    }

    [Fact]
    public void KreirajRadnika_UvekPostavljaAktivanNaTrue_BezObziraNaUlaz()
    {
        string email = $"kreiraj_{Guid.NewGuid():N}@test.com";
        Radnik noviRadnik = new Radnik
        {
            Ime = "Testni",
            Prezime = "Radnik",
            Sifra = "test123",
            Email = email,
            BrojTelefona = "0600000000",
            Aktivan = false // namerno false - operacija treba da ovo ignoriše i postavi na true
        };

        try
        {
            KreirajRadnikaSO so = new KreirajRadnikaSO(noviRadnik);
            so.ExecuteTemplate();

            List<IEntity> rezultat = broker.GetByCondition(
                new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" },
                $"Email = '{email}'");
            Radnik sacuvani = Assert.Single(rezultat.Cast<Radnik>());
            Assert.True(sacuvani.Aktivan);
        }
        finally
        {
            broker.Delete(new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" }, $"Email = '{email}'");
        }
    }
}
