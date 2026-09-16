using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>Integracioni testovi za DodeliKvalifikacijuRadnikuSO.</summary>
public class DodeliKvalifikacijuRadnikuSOTestovi : SOTestBase
{
    [Fact]
    public void DodeliKvalifikaciju_UpisujeVezuURadnikKvalifikacija()
    {
        string emailRadnik = $"radnik_{Guid.NewGuid():N}@test.com";
        string nazivKval = $"Kval_{Guid.NewGuid():N}";
        int radnikID = 0;
        int kvalifikacijaID = 0;

        try
        {
            radnikID = TestPodaci.KreirajRadnika(broker, emailRadnik);
            kvalifikacijaID = TestPodaci.KreirajKvalifikaciju(broker, nazivKval);

            RadnikKvalifikacija rk = new RadnikKvalifikacija
            {
                RadnikID = radnikID,
                KvalifikacijaID = kvalifikacijaID,
                DatumSticanja = DateTime.Today,
                DatumIsteka = null
            };

            DodeliKvalifikacijuRadnikuSO so = new DodeliKvalifikacijuRadnikuSO(rk);
            so.ExecuteTemplate();

            List<IEntity> rezultat = broker.GetByCondition(new RadnikKvalifikacija(), $"RadnikID = {radnikID} AND KvalifikacijaID = {kvalifikacijaID}");
            Assert.Single(rezultat);
        }
        finally
        {
            broker.Delete(new RadnikKvalifikacija(), $"RadnikID = {radnikID} AND KvalifikacijaID = {kvalifikacijaID}");
            broker.Delete(new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" }, $"RadnikID = {radnikID}");
            broker.Delete(new Kvalifikacija { Naziv = "" }, $"KvalifikacijaID = {kvalifikacijaID}");
        }
    }
}
