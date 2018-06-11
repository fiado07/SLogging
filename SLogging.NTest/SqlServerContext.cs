using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLogging.NTest
{
    public class SqlServerContext
    {

        public readonly IDbConnection SqlContext;

        public SqlServerContext()
        {

            SqlContext = new SqlConnection( @"Persist Security Info = False; Integrated Security = true; Initial Catalog =; server = ");

        }

    }
}
