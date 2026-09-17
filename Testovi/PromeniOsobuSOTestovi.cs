using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>Integracioni testovi za PromeniOsobuSO.</summary>
public class PromeniOsobuSOTestovi : SOTestBase
{
    [Fact]
    public void PromeniOsobu_MenjaPodatkeUBazi()
    {
        string nazivKat = $"Kat_{Guid.NewGuid():N}";
        string jmbg = TestPodaci.NoviJmbg();

        try
        {
            int kategorijaID = TestPodaci.KreirajKategoriju(broker, nazivKat);
            int osobaID = TestPodaci.KreirajOsobu(broker, kategorijaID, jmbg);

            Osoba izmenjena = new Osoba
            {
                OsobaID = osobaID,
                KategorijaID = kategorijaID,
                Ime = "Izmenjeno",
                Prezime = "Prezime",
                JMBG = jmbg,
                DatumRodjenja = new DateTime(1990, 1, 1),
                Email = $"{jmbg}@test.com",
                Adresa = "Nova adresa 5",
                BrojTelefona = "0688888888"
            };

            PromeniOsobuSO so = new PromeniOsobuSO(izmenjena);
            so.ExecuteTemplate();

            List<IEntity> rezultat = broker.GetByCondition(
                new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" },
                $"OsobaID = {osobaID}");
            Osoba sacuvana = Assert.Single(rezultat.Cast<Osoba>());
            Assert.Equal("Izmenjeno", sacuvana.Ime);
            Assert.Equal("Nova adresa 5", sacuvana.Adresa);
            Assert.Equal("0688888888", sacuvana.BrojTelefona);
        }
        finally
        {
            broker.Delete(new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" }, $"JMBG = '{jmbg}'");
            broker.Delete(new Kategorija { Naziv = "" }, $"Naziv = '{nazivKat}'");
        }
    }
}
