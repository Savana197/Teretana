using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>
/// Integracioni testovi za KreirajTreneraSO.
/// NAPOMENA: test "KreirajTrenera_UvekPostavljaAktivanNaTrue_BezObziraNaUlaz" zahteva
/// da KreirajTreneraSO postavlja trener.Aktivan = true u konstruktoru (isti obrazac kao
/// KreirajRadnikaSO). Ako to nije primenjeno u SO klasi, ovaj test će pasti - videti
/// napomenu u odgovoru uz kod.
/// </summary>
public class KreirajTreneraSOTestovi : SOTestBase
{
    [Fact]
    public void KreirajTrenera_UpisujeTreneraUBazu()
    {
        string email = $"trener_{Guid.NewGuid():N}@test.com";
        Trener noviTrener = new Trener
        {
            Ime = "Marko",
            Prezime = "Marković",
            Specijalnost = "Fitnes",
            BrojTelefona = "0622222222",
            Email = email,
            GodineIskustva = 3
        };

        try
        {
            KreirajTreneraSO so = new KreirajTreneraSO(noviTrener);
            so.ExecuteTemplate();

            List<IEntity> rezultat = broker.GetByCondition(
                new Trener { Ime = "", Prezime = "", Specijalnost = "", BrojTelefona = "", Email = "" },
                $"Email = '{email}'");
            Trener sacuvani = Assert.Single(rezultat.Cast<Trener>());
            Assert.Equal("Marko", sacuvani.Ime);
            Assert.Equal(3, sacuvani.GodineIskustva);
        }
        finally
        {
            broker.Delete(new Trener { Ime = "", Prezime = "", Specijalnost = "", BrojTelefona = "", Email = "" }, $"Email = '{email}'");
        }
    }

    [Fact]
    public void KreirajTrenera_UvekPostavljaAktivanNaTrue_BezObziraNaUlaz()
    {
        string email = $"trener_{Guid.NewGuid():N}@test.com";
        Trener noviTrener = new Trener
        {
            Ime = "Marko",
            Prezime = "Marković",
            Specijalnost = "Fitnes",
            BrojTelefona = "0622222222",
            Email = email,
            GodineIskustva = 3,
            Aktivan = false // namerno false - operacija treba da ovo ignoriše i postavi na true
        };

        try
        {
            KreirajTreneraSO so = new KreirajTreneraSO(noviTrener);
            so.ExecuteTemplate();

            List<IEntity> rezultat = broker.GetByCondition(
                new Trener { Ime = "", Prezime = "", Specijalnost = "", BrojTelefona = "", Email = "" },
                $"Email = '{email}'");
            Trener sacuvani = Assert.Single(rezultat.Cast<Trener>());
            Assert.True(sacuvani.Aktivan);
        }
        finally
        {
            broker.Delete(new Trener { Ime = "", Prezime = "", Specijalnost = "", BrojTelefona = "", Email = "" }, $"Email = '{email}'");
        }
    }
}
