using Microsoft.Data.SqlClient;

namespace DBBroker
{
    /// <summary>
    /// Upravlja niskim nivoom konekcije ka bazi - otvaranje/zatvaranje konekcije,
    /// upravljanje transakcijom i kreiranje SqlCommand objekata vezanih za nju.
    /// </summary>
    internal class DbConnection
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        /// <summary>Kreira konekciju ka lokalnoj bazi TeretanaSistem preko LocalDB-a.</summary>
        public DbConnection()
        {
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TeretanaSistem;Integrated Security=True");
        }

        /// <summary>Otvara konekciju ka bazi.</summary>
        public void OpenConnection()
        {
            connection?.Open();
        }

        /// <summary>Zatvara konekciju ka bazi.</summary>
        public void CloseConnection()
        {
            connection?.Close();
        }

        /// <summary>Započinje novu transakciju nad trenutnom konekcijom.</summary>
        public void BeginTransaction()
        {
            transaction = connection.BeginTransaction();
        }

        /// <summary>Potvrđuje (commit) trenutnu transakciju.</summary>
        public void Commit()
        {
            transaction?.Commit();
        }

        /// <summary>Poništava (rollback) trenutnu transakciju.</summary>
        public void Rollback()
        {
            transaction?.Rollback();
        }

        /// <summary>Kreira novu SQL komandu vezanu za trenutnu konekciju i transakciju.</summary>
        /// <returns>Prazan SqlCommand spreman za popunjavanje CommandText-a.</returns>
        public SqlCommand CreateCommand()
        {
            return new SqlCommand("", connection, transaction);
        }
    }
}
