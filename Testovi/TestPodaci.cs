using Common.Domen;
using DBBroker;

namespace Testovi;

/// <summary>
/// Pomoćne metode za pripremu test podataka (preduslova) u bazi - koriste
/// se u integracionim testovima sistemskih operacija da bi se izbeglo
/// ponavljanje istog Arrange koda u svakom testu. Svaka metoda upisuje red
/// preko Broker-a (van transakcije testirane operacije) i vraća njegov
/// IDENTITY ID tako što ga odmah pročita nazad preko jedinstvene vrednosti
/// (Broker.Add ne vraća generisani ID direktno).
/// </summary>
public static class TestPodaci
{
    /// <summary>Kreira kategoriju sa datim nazivom (treba da bude jedinstven u testu) i popustom, vraća njen KategorijaID.</summary>
    public static int KreirajKategoriju(Broker broker, string naziv, decimal popust = 0)
    {
        broker.Add(new Kategorija { Naziv = naziv, Popust = popust });
        List<IEntity> rezultat = broker.GetByCondition(new Kategorija { Naziv = "" }, $"Naziv = '{naziv}'");
        return rezultat.Cast<Kategorija>().First().KategorijaID;
    }

    /// <summary>Kreira osobu sa datim (jedinstvenim) JMBG-om u zadatoj kategoriji, vraća njen OsobaID.</summary>
    public static int KreirajOsobu(Broker broker, int kategorijaID, string jmbg)
    {
        broker.Add(new Osoba
        {
            KategorijaID = kategorijaID,
            Ime = "Test",
            Prezime = "Osoba",
            JMBG = jmbg,
            DatumRodjenja = new DateTime(1990, 1, 1),
            Email = $"{jmbg}@test.com",
            Adresa = "Testna 1",
            BrojTelefona = "0600000000"
        });
        List<IEntity> rezultat = broker.GetByCondition(
            new Osoba { Ime = "", Prezime = "", JMBG = "", Email = "", Adresa = "", BrojTelefona = "" },
            $"JMBG = '{jmbg}'");
        return rezultat.Cast<Osoba>().First().OsobaID;
    }

    /// <summary>Kreira aktivnog radnika sa datim (jedinstvenim) email-om, vraća njegov RadnikID.</summary>
    public static int KreirajRadnika(Broker broker, string email, string sifra = "test123")
    {
        broker.Add(new Radnik
        {
            Ime = "Test",
            Prezime = "Radnik",
            Sifra = sifra,
            Email = email,
            BrojTelefona = "0600000000",
            Aktivan = true
        });
        List<IEntity> rezultat = broker.GetByCondition(
            new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" },
            $"Email = '{email}'");
        return rezultat.Cast<Radnik>().First().RadnikID;
    }

    /// <summary>Kreira aktivnog trenera sa datim (jedinstvenim) email-om, vraća njegov TrenerID.</summary>
    public static int KreirajTrenera(Broker broker, string email)
    {
        broker.Add(new Trener
        {
            Ime = "Test",
            Prezime = "Trener",
            Specijalnost = "Fitnes",
            BrojTelefona = "0600000000",
            Email = email,
            GodineIskustva = 1,
            Aktivan = true
        });
        List<IEntity> rezultat = broker.GetByCondition(
            new Trener { Ime = "", Prezime = "", Specijalnost = "", BrojTelefona = "", Email = "" },
            $"Email = '{email}'");
        return rezultat.Cast<Trener>().First().TrenerID;
    }

    /// <summary>Kreira kvalifikaciju sa datim (jedinstvenim) nazivom, vraća njen KvalifikacijaID.</summary>
    public static int KreirajKvalifikaciju(Broker broker, string naziv)
    {
        broker.Add(new Kvalifikacija { Naziv = naziv, Nivo = Nivo.Osnovni });
        List<IEntity> rezultat = broker.GetByCondition(new Kvalifikacija { Naziv = "" }, $"Naziv = '{naziv}'");
        return rezultat.Cast<Kvalifikacija>().First().KvalifikacijaID;
    }

    /// <summary>Kreira aktivno članstvo za datu osobu/radnika, vraća njegov ČlanstvoID. OsobaID mora biti jedinstven (nova osoba) da bi pretraga nazad bila pouzdana.</summary>
    public static int KreirajClanstvo(Broker broker, int osobaID, int radnikID, decimal cena = 1000m)
    {
        broker.Add(new Članstvo
        {
            OsobaID = osobaID,
            RadnikID = radnikID,
            DatumPočetka = DateTime.Today,
            DatumIsteka = DateTime.Today.AddMonths(1),
            Cena = cena,
            Status = StatusČlanstva.Aktivno
        });
        List<IEntity> rezultat = broker.GetByCondition(new Članstvo(), $"OsobaID = {osobaID}");
        return rezultat.Cast<Članstvo>().First().ČlanstvoID;
    }
}
