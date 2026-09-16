using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>Integracioni testovi za DeaktivirajRadnikaSO.</summary>
public class DeaktivirajRadnikaSOTestovi : SOTestBase
{
    [Fact]
    public void DeaktivirajRadnika_PostavljaAktivanNaFalse()
    {
        string email = $"deakt_{Guid.NewGuid():N}@test.com";

        try
        {
            int radnikID = TestPodaci.KreirajRadnika(broker, email);

            DeaktivirajRadnikaSO so = new DeaktivirajRadnikaSO(radnikID);
            so.ExecuteTemplate();

            List<IEntity> rezultat = broker.GetByCondition(
                new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" },
                $"RadnikID = {radnikID}");
            Radnik sacuvani = Assert.Single(rezultat.Cast<Radnik>());
            Assert.False(sacuvani.Aktivan);
        }
        finally
        {
            broker.Delete(new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" }, $"Email = '{email}'");
        }
    }
}
