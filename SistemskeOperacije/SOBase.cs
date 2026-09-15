using DBBroker;

namespace SistemskeOperacije
{
    /// <summary>
    /// Bazna klasa za sve sistemske operacije - implementira Template Method
    /// šablon koji obezbeđuje da svaka operacija ide kroz isti okvir:
    /// otvori konekciju, započni transakciju, izvrši konkretnu operaciju,
    /// commit-uj (ili rollback-uj pri grešci), zatvori konekciju.
    /// </summary>
    public abstract class SOBase
    {
        /// <summary>Broker preko kog konkretna operacija pristupa bazi.</summary>
        protected Broker broker;

        /// <summary>Kreira novu instancu operacije i pripremljen broker.</summary>
        public SOBase()
        {
            broker = new Broker();
        }

        /// <summary>
        /// Izvršava operaciju kroz standardni okvir (konekcija, transakcija,
        /// commit/rollback). Ovo je metoda koju poziva Kontroler.
        /// </summary>
        public void ExecuteTemplate()
        {
            try
            {
                broker.OpenConnection();
                broker.BeginTransaction();

                ExecuteConcreteOperation();

                broker.Commit();
            }
            catch (Exception)
            {
                broker.Rollback();
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        /// <summary>
        /// Konkretna logika operacije - implementira svaka izvedena klasa.
        /// </summary>
        protected abstract void ExecuteConcreteOperation();
    }
}