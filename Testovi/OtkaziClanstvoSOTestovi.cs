using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>Integracioni testovi za OtkaziClanstvoSO.</summary>
public class OtkaziClanstvoSOTestovi : SOTestBase
{
    [Fact]
    public void OtkaziClanstvo_PostavljaStatusNaOtkazano()
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

            OtkaziClanstvoSO so = new OtkaziClanstvoSO(clanstvoID);
            so.ExecuteTemplate();

            List<IEntity> rezultat = broker.GetByCondition(new Članstvo(), $"ClanstvoID = {clanstvoID}");
            Članstvo sacuvano = Assert.Single(rezultat.Cast<Članstvo>());
            Assert.Equal(StatusČlanstva.Otkazano, sacuvano.Status);
        }
        finally
        {
            broker.Delete(new Članstvo(), $"OsobaID = {osobaID}");
            broker.Delete(new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" }, $"OsobaID = {osobaID}");
            broker.Delete(new Kategorija { Naziv = "" }, $"KategorijaID = {kategorijaID}");
            broker.Delete(new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" }, $"RadnikID = {radnikID}");
        }
    }
}
