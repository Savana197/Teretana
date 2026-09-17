using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>Integracioni testovi za KreirajOsobuSO.</summary>
public class KreirajOsobuSOTestovi : SOTestBase
{
    [Fact]
    public void KreirajOsobu_UpisujeOsobuUBazu()
    {
        string nazivKat = $"Kat_{Guid.NewGuid():N}";
        string jmbg = TestPodaci.NoviJmbg();

        try
        {
            int kategorijaID = TestPodaci.KreirajKategoriju(broker, nazivKat);

            Osoba nova = new Osoba
            {
                KategorijaID = kategorijaID,
                Ime = "Ana",
                Prezime = "Anić",
                JMBG = jmbg,
                DatumRodjenja = new DateTime(1995, 1, 1),
                Email = $"{jmbg}@test.com",
                Adresa = "Trg 1",
                BrojTelefona = "0611111111"
            };

            KreirajOsobuSO so = new KreirajOsobuSO(nova);
            so.ExecuteTemplate();

            List<IEntity> rezultat = broker.GetByCondition(
                new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" },
                $"JMBG = '{jmbg}'");
            Osoba sacuvana = Assert.Single(rezultat.Cast<Osoba>());
            Assert.Equal("Ana", sacuvana.Ime);
            Assert.Equal(kategorijaID, sacuvana.KategorijaID);
        }
        finally
        {
            broker.Delete(new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" }, $"JMBG = '{jmbg}'");
            broker.Delete(new Kategorija { Naziv = "" }, $"Naziv = '{nazivKat}'");
        }
    }
}
