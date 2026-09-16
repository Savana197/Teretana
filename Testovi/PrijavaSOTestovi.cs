using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>Integracioni testovi za PrijavaSO.</summary>
public class PrijavaSOTestovi : SOTestBase
{
    [Fact]
    public void Prijava_TacniPodaci_VracaRadnika()
    {
        string email = $"prijava_{Guid.NewGuid():N}@test.com";

        try
        {
            int radnikID = TestPodaci.KreirajRadnika(broker, email, "sifra123");

            PrijavaSO so = new PrijavaSO(new Radnik { Ime = "", Prezime = "", Sifra = "sifra123", Email = email, BrojTelefona = "" });
            so.ExecuteTemplate();

            Assert.NotNull(so.Result);
            Assert.Equal(radnikID, so.Result!.RadnikID);
            Assert.Equal(email, so.Result.Email);
        }
        finally
        {
            broker.Delete(new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" }, $"Email = '{email}'");
        }
    }

    [Fact]
    public void Prijava_PogresnaSifra_BacaIzuzetak()
    {
        string email = $"prijava_{Guid.NewGuid():N}@test.com";

        try
        {
            TestPodaci.KreirajRadnika(broker, email, "sifra123");

            PrijavaSO so = new PrijavaSO(new Radnik { Ime = "", Prezime = "", Sifra = "pogresna", Email = email, BrojTelefona = "" });
            Assert.Throws<Exception>(() => so.ExecuteTemplate());
        }
        finally
        {
            broker.Delete(new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" }, $"Email = '{email}'");
        }
    }
}
