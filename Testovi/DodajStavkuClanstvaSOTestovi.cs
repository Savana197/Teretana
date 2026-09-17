using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>Integracioni testovi za DodajStavkuClanstvaSO.</summary>
public class DodajStavkuClanstvaSOTestovi : SOTestBase
{
    [Fact]
    public void DodajStavkuClanstva_AutomatskiRacunaRb_ZaVisePozivaUzastopno()
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
            kategorijaID = TestPodaci.KreirajKategoriju(broker, nazivKat);
            osobaID = TestPodaci.KreirajOsobu(broker, kategorijaID, jmbg);
            radnikID = TestPodaci.KreirajRadnika(broker, emailRadnik);
            clanstvoID = TestPodaci.KreirajClanstvo(broker, osobaID, radnikID);
            trenerID = TestPodaci.KreirajTrenera(broker, emailTrener);

            DodajStavkuClanstvaSO prvaSO = new DodajStavkuClanstvaSO(new StavkaČlanstva
            {
                ČlanstvoID = clanstvoID,
                TrenerID = trenerID,
                VrstaTreninga = VrstaTreninga.Individualni,
                BrojTermina = 5,
                CenaStavke = 200m
            });
            prvaSO.ExecuteTemplate();

            DodajStavkuClanstvaSO drugaSO = new DodajStavkuClanstvaSO(new StavkaČlanstva
            {
                ČlanstvoID = clanstvoID,
                TrenerID = trenerID,
                VrstaTreninga = VrstaTreninga.Grupni,
                BrojTermina = 10,
                CenaStavke = 300m
            });
            drugaSO.ExecuteTemplate();

            List<IEntity> rezultat = broker.GetByCondition(new StavkaČlanstva(), $"ClanstvoID = {clanstvoID}");
            List<StavkaČlanstva> stavke = rezultat.Cast<StavkaČlanstva>().OrderBy(s => s.Rb).ToList();

            Assert.Equal(2, stavke.Count);
            Assert.Equal(1, stavke[0].Rb);
            Assert.Equal(2, stavke[1].Rb);
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
}
