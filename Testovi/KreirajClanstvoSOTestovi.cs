using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>Integracioni testovi za KreirajClanstvoSO.</summary>
public class KreirajClanstvoSOTestovi : SOTestBase
{
    [Fact]
    public void KreirajClanstvo_UpisujeČlanstvoUBazu()
    {
        string nazivKat = $"Kat_{Guid.NewGuid():N}";
        string jmbg = Guid.NewGuid().ToString("N")[..13];
        string emailRadnik = $"radnik_{Guid.NewGuid():N}@test.com";
        int osobaID = 0;

        try
        {
            int kategorijaID = TestPodaci.KreirajKategoriju(broker, nazivKat);
            osobaID = TestPodaci.KreirajOsobu(broker, kategorijaID, jmbg);
            int radnikID = TestPodaci.KreirajRadnika(broker, emailRadnik);

            Članstvo novo = new Članstvo
            {
                OsobaID = osobaID,
                RadnikID = radnikID,
                DatumPočetka = DateTime.Today,
                DatumIsteka = DateTime.Today.AddMonths(1),
                Cena = 3000m,
                Status = StatusČlanstva.Aktivno
            };

            KreirajClanstvoSO so = new KreirajClanstvoSO(novo);
            so.ExecuteTemplate();

            List<IEntity> rezultat = broker.GetByCondition(new Članstvo(), $"OsobaID = {osobaID}");
            Članstvo sacuvano = Assert.Single(rezultat.Cast<Članstvo>());
            Assert.Equal(3000m, sacuvano.Cena);
        }
        finally
        {
            broker.Delete(new Članstvo(), $"OsobaID = {osobaID}");
            broker.Delete(new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" }, $"JMBG = '{jmbg}'");
            broker.Delete(new Kategorija { Naziv = "" }, $"Naziv = '{nazivKat}'");
            broker.Delete(new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" }, $"Email = '{emailRadnik}'");
        }
    }

    [Fact]
    public void KreirajClanstvo_UvekPostavljaStatusNaAktivno_BezObziraNaUlaz()
    {
        string nazivKat = $"Kat_{Guid.NewGuid():N}";
        string jmbg = Guid.NewGuid().ToString("N")[..13];
        string emailRadnik = $"radnik_{Guid.NewGuid():N}@test.com";
        int osobaID = 0;

        try
        {
            int kategorijaID = TestPodaci.KreirajKategoriju(broker, nazivKat);
            osobaID = TestPodaci.KreirajOsobu(broker, kategorijaID, jmbg);
            int radnikID = TestPodaci.KreirajRadnika(broker, emailRadnik);

            Članstvo novo = new Članstvo
            {
                OsobaID = osobaID,
                RadnikID = radnikID,
                DatumPočetka = DateTime.Today,
                DatumIsteka = DateTime.Today.AddMonths(1),
                Cena = 500m,
                Status = StatusČlanstva.Otkazano // namerno pogrešno, mora biti prepisano na Aktivno
            };

            KreirajClanstvoSO so = new KreirajClanstvoSO(novo);
            so.ExecuteTemplate();

            List<IEntity> rezultat = broker.GetByCondition(new Članstvo(), $"OsobaID = {osobaID}");
            Članstvo sacuvano = Assert.Single(rezultat.Cast<Članstvo>());
            Assert.Equal(StatusČlanstva.Aktivno, sacuvano.Status);
        }
        finally
        {
            broker.Delete(new Članstvo(), $"OsobaID = {osobaID}");
            broker.Delete(new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" }, $"JMBG = '{jmbg}'");
            broker.Delete(new Kategorija { Naziv = "" }, $"Naziv = '{nazivKat}'");
            broker.Delete(new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" }, $"Email = '{emailRadnik}'");
        }
    }
}
