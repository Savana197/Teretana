using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>Integracioni testovi za VratiSveAktivneTrenereSO.</summary>
public class VratiSveAktivneTrenereSOTestovi : SOTestBase
{
    [Fact]
    public void VratiSveAktivneTrenere_VracaSamoAktivne()
    {
        string emailAktivan = $"aktivan_{Guid.NewGuid():N}@test.com";
        string emailNeaktivan = $"neaktivan_{Guid.NewGuid():N}@test.com";

        try
        {
            int aktivanID = TestPodaci.KreirajTrenera(broker, emailAktivan);
            int neaktivanID = TestPodaci.KreirajTrenera(broker, emailNeaktivan);
            broker.Update(new Trener { Ime = "", Prezime = "", Specijalnost = "", BrojTelefona = "", Email = "" }, "Aktivan = 0", $"TrenerID = {neaktivanID}");

            VratiSveAktivneTrenereSO so = new VratiSveAktivneTrenereSO();
            so.ExecuteTemplate();

            Assert.Contains(so.Result, t => t.TrenerID == aktivanID);
            Assert.DoesNotContain(so.Result, t => t.TrenerID == neaktivanID);
        }
        finally
        {
            broker.Delete(new Trener { Ime = "", Prezime = "", Specijalnost = "", BrojTelefona = "", Email = "" }, $"Email = '{emailAktivan}'");
            broker.Delete(new Trener { Ime = "", Prezime = "", Specijalnost = "", BrojTelefona = "", Email = "" }, $"Email = '{emailNeaktivan}'");
        }
    }
}
