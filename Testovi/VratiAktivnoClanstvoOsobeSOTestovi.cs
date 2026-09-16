using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>Integracioni testovi za VratiAktivnoClanstvoOsobeSO.</summary>
public class VratiAktivnoClanstvoOsobeSOTestovi : SOTestBase
{
    [Fact]
    public void VratiAktivnoClanstvoOsobe_VracaAktivnoClanstvo()
    {
        string nazivKat = $"Kat_{Guid.NewGuid():N}";
        string jmbg = Guid.NewGuid().ToString("N")[..13];
        string emailRadnik = $"radnik_{Guid.NewGuid():N}@test.com";
        int kategorijaID = 0;
        int osobaID = 0;
        int radnikID = 0;

        try
        {
            kategorijaID = TestPodaci.KreirajKategoriju(broker, nazivKat);
            osobaID = TestPodaci.KreirajOsobu(broker, kategorijaID, jmbg);
            radnikID = TestPodaci.KreirajRadnika(broker, emailRadnik);
            int clanstvoID = TestPodaci.KreirajClanstvo(broker, osobaID, radnikID);

            VratiAktivnoClanstvoOsobeSO so = new VratiAktivnoClanstvoOsobeSO(osobaID);
            so.ExecuteTemplate();

            Assert.NotNull(so.Result);
            Assert.Equal(clanstvoID, so.Result!.ČlanstvoID);
            Assert.Equal(StatusČlanstva.Aktivno, so.Result.Status);
        }
        finally
        {
            broker.Delete(new Članstvo(), $"OsobaID = {osobaID}");
            broker.Delete(new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" }, $"OsobaID = {osobaID}");
            broker.Delete(new Kategorija { Naziv = "" }, $"KategorijaID = {kategorijaID}");
            broker.Delete(new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" }, $"RadnikID = {radnikID}");
        }
    }

    [Fact]
    public void VratiAktivnoClanstvoOsobe_NemaAktivnoClanstvo_BacaIzuzetak()
    {
        string nazivKat = $"Kat_{Guid.NewGuid():N}";
        string jmbg = Guid.NewGuid().ToString("N")[..13];
        int kategorijaID = 0;
        int osobaID = 0;

        try
        {
            kategorijaID = TestPodaci.KreirajKategoriju(broker, nazivKat);
            osobaID = TestPodaci.KreirajOsobu(broker, kategorijaID, jmbg);

            VratiAktivnoClanstvoOsobeSO so = new VratiAktivnoClanstvoOsobeSO(osobaID);
            Assert.Throws<Exception>(() => so.ExecuteTemplate());
        }
        finally
        {
            broker.Delete(new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" }, $"OsobaID = {osobaID}");
            broker.Delete(new Kategorija { Naziv = "" }, $"KategorijaID = {kategorijaID}");
        }
    }
}
