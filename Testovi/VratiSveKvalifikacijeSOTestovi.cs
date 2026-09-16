using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>Integracioni testovi za VratiSveKvalifikacijeSO.</summary>
public class VratiSveKvalifikacijeSOTestovi : SOTestBase
{
    [Fact]
    public void VratiSveKvalifikacije_SadrziNovokreiranu()
    {
        string naziv = $"Kval_{Guid.NewGuid():N}";
        int kvalifikacijaID = 0;

        try
        {
            kvalifikacijaID = TestPodaci.KreirajKvalifikaciju(broker, naziv);

            VratiSveKvalifikacijeSO so = new VratiSveKvalifikacijeSO();
            so.ExecuteTemplate();

            Assert.Contains(so.Result, k => k.KvalifikacijaID == kvalifikacijaID);
        }
        finally
        {
            broker.Delete(new Kvalifikacija { Naziv = "" }, $"KvalifikacijaID = {kvalifikacijaID}");
        }
    }
}
