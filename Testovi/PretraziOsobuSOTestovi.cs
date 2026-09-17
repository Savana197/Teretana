using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>Integracioni testovi za PretraziOsobuSO.</summary>
public class PretraziOsobuSOTestovi : SOTestBase
{
    [Fact]
    public void PretraziOsobu_PronalaziPoJMBG()
    {
        string nazivKat = $"Kat_{Guid.NewGuid():N}";
        string jmbg = TestPodaci.NoviJmbg();

        try
        {
            int kategorijaID = TestPodaci.KreirajKategoriju(broker, nazivKat);
            TestPodaci.KreirajOsobu(broker, kategorijaID, jmbg);

            PretraziOsobuSO so = new PretraziOsobuSO(jmbg);
            so.ExecuteTemplate();

            Assert.Single(so.Result);
            Assert.Equal(jmbg, so.Result[0].JMBG);
        }
        finally
        {
            broker.Delete(new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" }, $"JMBG = '{jmbg}'");
            broker.Delete(new Kategorija { Naziv = "" }, $"Naziv = '{nazivKat}'");
        }
    }
}
