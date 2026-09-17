using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>Integracioni testovi za IzracunajUkupnuCenuClanstvaSO.</summary>
public class IzracunajUkupnuCenuClanstvaSOTestovi : SOTestBase
{
    [Fact]
    public void IzracunajUkupnuCenu_PrimenjujePopustKategorijeNaCenuPlusStavke()
    {
        string nazivKat = $"Kat_{Guid.NewGuid():N}";
        string jmbg = TestPodaci.NoviJmbg();
        string emailRadnik = $"radnik_{Guid.NewGuid():N}@test.com";
        string emailTrener = $"trener_{Guid.NewGuid():N}@test.com";
        int kategorijaID = 0;
        int osobaID = 0;
        int radnikID = 0;
        int trenerID = 0;
        int clanstvoID = 0;

        try
        {
            // Kategorija sa 10% popusta
            kategorijaID = TestPodaci.KreirajKategoriju(broker, nazivKat, popust: 10m);
            osobaID = TestPodaci.KreirajOsobu(broker, kategorijaID, jmbg);
            radnikID = TestPodaci.KreirajRadnika(broker, emailRadnik);
            // Clanstvo osnovna cena 1000
            clanstvoID = TestPodaci.KreirajClanstvo(broker, osobaID, radnikID, cena: 1000m);
            trenerID = TestPodaci.KreirajTrenera(broker, emailTrener);
            // Stavka clanstva cena 200
            broker.Add(new StavkaČlanstva
            {
                Rb = 1,
                ČlanstvoID = clanstvoID,
                TrenerID = trenerID,
                VrstaTreninga = VrstaTreninga.Individualni,
                BrojTermina = 5,
                Iskorišćeno = 0,
                CenaStavke = 200m
            });

            // (1000 + 200) - 10% = 1080
            IzracunajUkupnuCenuClanstvaSO so = new IzracunajUkupnuCenuClanstvaSO(clanstvoID);
            so.ExecuteTemplate();

            Assert.Equal(1080m, so.Result);
        }
        finally
        {
            broker.Delete(new StavkaČlanstva(), $"ClanstvoID = {clanstvoID}");
            broker.Delete(new Članstvo(), $"OsobaID = {osobaID}");
            broker.Delete(new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" }, $"OsobaID = {osobaID}");
            broker.Delete(new Kategorija { Naziv = "" }, $"KategorijaID = {kategorijaID}");
            broker.Delete(new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" }, $"RadnikID = {radnikID}");
            broker.Delete(new Trener { Ime = "", Prezime = "", Specijalnost = "", BrojTelefona = "", Email = "" }, $"TrenerID = {trenerID}");
        }
    }

    [Fact]
    public void IzracunajUkupnuCenu_NepostojeceClanstvo_BacaIzuzetak()
    {
        IzracunajUkupnuCenuClanstvaSO so = new IzracunajUkupnuCenuClanstvaSO(-1);
        Assert.Throws<Exception>(() => so.ExecuteTemplate());
    }
}
