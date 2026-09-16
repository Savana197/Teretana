using DBBroker;

namespace Testovi;

/// <summary>
/// Bazna klasa za integracione testove sistemskih operacija. Otvara broker
/// konekciju pre svakog testa i zatvara je posle - xUnit pravi novu instancu
/// test klase za svaki [Fact], pa konstruktor/Dispose ovde rade kao
/// setup/teardown po pojedinačnom testu.
/// </summary>
public abstract class SOTestBase : IDisposable
{
    /// <summary>Broker koji test koristi za pripremu podataka, proveru rezultata i čišćenje.</summary>
    protected readonly Broker broker;

    /// <summary>Otvara konekciju ka bazi pre testa.</summary>
    protected SOTestBase()
    {
        broker = new Broker();
        broker.OpenConnection();
    }

    /// <summary>Zatvara konekciju ka bazi posle testa.</summary>
    public void Dispose()
    {
        broker.CloseConnection();
        GC.SuppressFinalize(this);
    }
}
