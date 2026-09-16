using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>Integracioni testovi za KreirajKvalifikacijuSO.</summary>
public class KreirajKvalifikacijuSOTestovi : SOTestBase
{
    [Fact]
    public void KreirajKvalifikaciju_UpisujeKvalifikacijuUBazu()
    {
        string naziv = $"Kval_{Guid.NewGuid():N}";
        Kvalifikacija nova = new Kvalifikacija { Naziv = naziv, Nivo = Nivo.Napredni };

        try
        {
            KreirajKvalifikacijuSO so = new KreirajKvalifikacijuSO(nova);
            so.ExecuteTemplate();

            List<IEntity> rezultat = broker.GetByCondition(new Kvalifikacija { Naziv = "" }, $"Naziv = '{naziv}'");
            Kvalifikacija sacuvana = Assert.Single(rezultat.Cast<Kvalifikacija>());
            Assert.Equal(Nivo.Napredni, sacuvana.Nivo);
        }
        finally
        {
            broker.Delete(new Kvalifikacija { Naziv = "" }, $"Naziv = '{naziv}'");
        }
    }
}
