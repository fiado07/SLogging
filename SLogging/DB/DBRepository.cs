using System;
using System.Data;

namespace SLogging.DB
{
    public class DBRepository : Contracts.IDBRepository
    {


        public IDbConnection DbConnection { set; get; }

        public DBRepository(IDbConnection dbConnection)
        {
            DbConnection = dbConnection;
        }


        public void ExecuteSql(string sql, string exception = null)
        {

            if (string.IsNullOrEmpty(DbConnection.ConnectionString))
                throw new Exception("ConnectionString not found!");



            if (DbConnection.State == ConnectionState.Closed)
                DbConnection.Open();

            using (IDbCommand commands = DbConnection.CreateCommand())
            {
                commands.CommandType = CommandType.Text;


                if (exception != null)
                {

                    IDbDataParameter parameters = commands.CreateParameter();

                    parameters.ParameterName = "@exception";
                    parameters.Value = exception;

                    commands.Parameters.Add(parameters);


                }

                commands.ExecuteNonQuery();


                if (DbConnection.State == ConnectionState.Open)
                    DbConnection.Close();

            }


        }
    }
}
