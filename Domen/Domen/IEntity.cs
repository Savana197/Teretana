using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domen
{
    /// <summary>
    /// Ugovor koji svaka domenska klasa mora da implementira da bi mogla
    /// da se čuva/čita iz baze preko generičkog Broker-a.
    /// </summary>
    public interface IEntity
    {
        /// <summary>Naziv tabele u bazi (sa alijasom ako je potreban za JOIN).</summary>
        string TableName { get; }

        /// <summary>Vrednosti objekta formatirane za SQL INSERT, redosledom kolona iz tabele.</summary>
        string Values { get; }

        /// <summary>Dodatni JOIN deo upita, ako su potrebni podaci iz povezane tabele.</summary>
        string Join { get; }

        /// <summary>Mapira redove iz SqlDataReader-a u listu objekata ovog tipa.</summary>
        List<IEntity> GetReaderList(SqlDataReader reader);
    }
}
