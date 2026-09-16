using Common.Domen;
using SistemskeOperacije;

namespace Testovi;

/// <summary>Integracioni testovi za PromeniRadnikaSO.</summary>
public class PromeniRadnikaSOTestovi : SOTestBase
{
    [Fact]
    public void PromeniRadnika_MenjaPodatkeUBazi()
    {
        string email = $"promeni_{Guid.NewGuid():N}@test.com";

        try
        {
            int radnikID = TestPodaci.KreirajRadnika(broker, email);

            Radnik izmenjen = new Radnik
            {
                RadnikID = radnikID,
                Ime = "Izmenjeno",
                Prezime = "Prezime",
                Sifra = "novaSifra",
                Email = email,
                BrojTelefona = "0699999999"
            };

            PromeniRadnikaSO so = new PromeniRadnikaSO(izmenjen);
            so.ExecuteTemplate();

            List<IEntity> rezultat = broker.GetByCondition(
                new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" },
                $"RadnikID = {radnikID}");
            Radnik sacuvani = Assert.Single(rezultat.Cast<Radnik>());
            Assert.Equal("Izmenjeno", sacuvani.Ime);
            Assert.Equal("Prezime", sacuvani.Prezime);
            Assert.Equal("novaSifra", sacuvani.Sifra);
            Assert.Equal("0699999999", sacuvani.BrojTelefona);
        }
        finally
        {
            broker.Delete(new Radnik { Ime = "", Prezime = "", Sifra = "", Email = "", BrojTelefona = "" }, $"Email = '{email}'");
        }
    }
}
