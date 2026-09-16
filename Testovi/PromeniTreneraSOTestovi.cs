using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>Integracioni testovi za PromeniTreneraSO.</summary>
public class PromeniTreneraSOTestovi : SOTestBase
{
    [Fact]
    public void PromeniTrenera_MenjaPodatkeIStatusAktivnosti()
    {
        string email = $"trener_{Guid.NewGuid():N}@test.com";

        try
        {
            int trenerID = TestPodaci.KreirajTrenera(broker, email);

            Trener izmenjen = new Trener
            {
                TrenerID = trenerID,
                Ime = "Izmenjeno",
                Prezime = "Prezime",
                Specijalnost = "Pilates",
                BrojTelefona = "0677777777",
                Email = email,
                GodineIskustva = 8,
                Aktivan = false
            };

            PromeniTreneraSO so = new PromeniTreneraSO(izmenjen);
            so.ExecuteTemplate();

            List<IEntity> rezultat = broker.GetByCondition(
                new Trener { Ime = "", Prezime = "", Specijalnost = "", BrojTelefona = "", Email = "" },
                $"TrenerID = {trenerID}");
            Trener sacuvani = Assert.Single(rezultat.Cast<Trener>());
            Assert.Equal("Izmenjeno", sacuvani.Ime);
            Assert.Equal("Pilates", sacuvani.Specijalnost);
            Assert.Equal(8, sacuvani.GodineIskustva);
            Assert.False(sacuvani.Aktivan);
        }
        finally
        {
            broker.Delete(new Trener { Ime = "", Prezime = "", Specijalnost = "", BrojTelefona = "", Email = "" }, $"Email = '{email}'");
        }
    }
}
