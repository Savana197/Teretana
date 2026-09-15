using Microsoft.Data.SqlClient;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DBBroker
{
    /// <summary>
    /// Generički broker za rad sa bazom podataka - otvara/zatvara konekciju,
    /// upravlja transakcijama i izvršava CRUD operacije nad objektima koji
    /// implementiraju IEntity.
    /// </summary>
    public class Broker
    {
        private DbConnection connection;

        /// <summary>Kreira novu instancu broker-a i pripravlja konekciju ka bazi.</summary>
        public Broker()
        {
            connection = new DbConnection();
        }

        /// <summary>Poništava (rollback) trenutnu transakciju.</summary>
        public void Rollback()
        {
            connection.Rollback();
        }

        /// <summary>Potvrđuje (commit) trenutnu transakciju.</summary>
        public void Commit()
        {
            connection.Commit();
        }

        /// <summary>Otvara novu transakciju nad bazom.</summary>
        public void BeginTransaction()
        {
            connection.BeginTransaction();
        }

        /// <summary>Zatvara konekciju ka bazi.</summary>
        public void CloseConnection()
        {
            connection.CloseConnection();
        }

        /// <summary>Otvara konekciju ka bazi.</summary>
        public void OpenConnection()
        {
            connection.OpenConnection();
        }

        /// <summary>Dodaje novi red u tabelu koja odgovara datom entitetu.</summary>
        /// <param name="obj">Entitet čiji se TableName i Values koriste za INSERT upit.</param>
        public void Add(IEntity obj)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"insert into {obj.TableName} values({obj.Values} )";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }


        /// <summary>Vraća sve redove iz tabele koja odgovara datom entitetu.</summary>
        /// <param name="entity">Entitet čiji se TableName, Join i GetReaderList koriste za upit i mapiranje rezultata.</param>
        /// <returns>Lista svih objekata pronađenih u tabeli.</returns>
        public List<IEntity> GetAll(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from {entity.TableName} {entity.Join}";
            using SqlDataReader reader = command.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            command.Dispose();
            return list;
        }

        /// <summary>Vraća redove iz tabele koji zadovoljavaju dati uslov.</summary>
        /// <param name="entity">Entitet čiji se TableName i GetReaderList koriste za upit i mapiranje rezultata.</param>
        /// <param name="condition">SQL WHERE uslov (bez reči "WHERE"), npr. "Aktivan = 1".</param>
        /// <returns>Lista objekata koji zadovoljavaju uslov.</returns>
        public List<IEntity> GetByCondition(IEntity entity, string condition)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {entity.TableName} WHERE {condition}";
            using SqlDataReader reader = command.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            command.Dispose();
            return list;
        }

        /// <summary>Menja postojeći red koji odgovara datom uslovu.</summary>
        /// <param name="obj">Entitet čiji TableName se koristi (sadržaj objekta se ne koristi direktno).</param>
        /// <param name="setClause">SET deo upita, npr. "Ime = 'Pera', Aktivan = 1".</param>
        /// <param name="condition">WHERE uslov koji identifikuje red(ove) za izmenu, npr. "RadnikID = 5".</param>
        public void Update(IEntity obj, string setClause, string condition)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"UPDATE {obj.TableName} SET {setClause} WHERE {condition}";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        /// <summary>Briše red(ove) koji odgovaraju datom uslovu.</summary>
        /// <param name="obj">Entitet čiji TableName se koristi.</param>
        /// <param name="condition">WHERE uslov koji identifikuje red(ove) za brisanje, npr. "OsobaID = 5".</param>
        public void Delete(IEntity obj, string condition)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"DELETE FROM {obj.TableName} WHERE {condition}";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
    }
}
