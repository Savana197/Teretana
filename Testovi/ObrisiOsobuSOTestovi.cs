using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>Integracioni testovi za ObrisiOsobuSO.</summary>
public class ObrisiOsobuSOTestovi : SOTestBase
{
    [Fact]
    public void ObrisiOsobu_UklanjaOsobuIzBaze()
    {
        string nazivKat = $"Kat_{Guid.NewGuid():N}";
        string jmbg = TestPodaci.NoviJmbg();

        try
        {
            int kategorijaID = TestPodaci.KreirajKategoriju(broker, nazivKat);
            int osobaID = TestPodaci.KreirajOsobu(broker, kategorijaID, jmbg);

            ObrisiOsobuSO so = new ObrisiOsobuSO(osobaID);
            so.ExecuteTemplate();

            List<IEntity> rezultat = broker.GetByCondition(
                new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" },
                $"OsobaID = {osobaID}");
            Assert.Empty(rezultat);
        }
        finally
        {
            broker.Delete(new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" }, $"JMBG = '{jmbg}'");
            broker.Delete(new Kategorija { Naziv = "" }, $"Naziv = '{nazivKat}'");
        }
    }
}
