using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SLogging.SourceLog
{
    internal class LogDB : Contracts.ILogBase
    {
              
        static IDbConnection DbConnection { set; get; }
        private readonly DB.DBRepository repository;

        private static readonly Lazy<LogDB> lazyLogging = new Lazy<LogDB>(() => new LogDB());


        private LogDB()
        {

            repository = new DB.DBRepository(DbConnection);

        }


        public static LogDB GetLog(IDbConnection dbConnection)
        {

            DbConnection = dbConnection;

            return lazyLogging.Value;

        }


        public void Debug(string user, string message, Exception exception)
        {

            string sql = "insert into logging(Logtype,Data,UserID,Message,Exception) values('{0}','{1}','{2}','{3}',@Exception)";

            sql = string.Format(sql, Common.LogLevel.Debug.ToString(), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), user, message);

            repository.ExecuteSql(sql, exception.ToString());

        }

        public void Debug<T>(T valueObject, string user, string message, Exception exception) where T : class
        {
            string sql = "insert into logging(Logtype,Data,UserID,Message,ValueObject,Exception) values('{0}','{1}','{2}','{3}','{4}',@Exception)";
            string objectContext = Common.Helpers.BuildStringLog(valueObject);

            sql = string.Format(sql, Common.LogLevel.Debug.ToString(), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), user, message, objectContext);

            repository.ExecuteSql(sql, exception.ToString());
        }

        public void Error(string user, string message, Exception exception)
        {
            string sql = "insert into logging(Logtype,Data,UserID,Message,Exception) values('{0}','{1}','{2}','{3}',@Exception)";

            sql = string.Format(sql, Common.LogLevel.Error.ToString(), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), user, message);

            repository.ExecuteSql(sql, exception.ToString());

        }

        public void Error<T>(T valueObject, string user, string message, Exception exception) where T : class
        {
            string sql = "insert into logging(Logtype,Data,UserID,Message,ValueObject,Exception) values('{0}','{1}','{2}','{3}','{4}',@Exception)";
            string objectContext = Common.Helpers.BuildStringLog(valueObject);

            sql = string.Format(sql, Common.LogLevel.Error.ToString(), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), user, message, objectContext);

            repository.ExecuteSql(sql, exception.ToString());
        }

        public void Info(string user, string message)
        {

            string sql = "insert into logging(Logtype,Data,UserID,Message) values('{0}','{1}','{2}','{3}')";

            sql = string.Format(sql, Common.LogLevel.Info.ToString(), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), user, message);

            repository.ExecuteSql(sql);

        }

        public void Info<T>(T valueObject, string user, string message)
        {

            string sql = "insert into logging(Logtype,Data,UserID,Message,ValueObject) values('{0}','{1}','{2}','{3}','{4}')";
            string objectContext = Common.Helpers.BuildStringLog(valueObject);

            sql = string.Format(sql, Common.LogLevel.Info.ToString(), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), user, message, objectContext);

            repository.ExecuteSql(sql);

        }
    }


}
