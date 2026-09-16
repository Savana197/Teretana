using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>Integracioni testovi za VratiSveKategorijeSO.</summary>
public class VratiSveKategorijeSOTestovi : SOTestBase
{
    [Fact]
    public void VratiSveKategorije_SadrziNovokreiranu()
    {
        string naziv = $"Kat_{Guid.NewGuid():N}";
        int kategorijaID = 0;

        try
        {
            kategorijaID = TestPodaci.KreirajKategoriju(broker, naziv, popust: 15m);

            VratiSveKategorijeSO so = new VratiSveKategorijeSO();
            so.ExecuteTemplate();

            Assert.Contains(so.Result, k => k.KategorijaID == kategorijaID && k.Popust == 15m);
        }
        finally
        {
            broker.Delete(new Kategorija { Naziv = "" }, $"KategorijaID = {kategorijaID}");
        }
    }
}
