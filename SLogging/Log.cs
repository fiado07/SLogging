using SLogging.Common;
using SLogging.Contracts;
using SLogging.SourceLog;
using System;
using System.Data;

namespace SLogging
{
    public class Log : ILog
    {
        static IDbConnection DbConnection { get; set; }
        private static string LoggingPathFile { get; set; }
        private static readonly Lazy<Log> lazyLogging = new Lazy<Log>(() => new Log());


        private Log()
        {

        }


        public static Log GetLog(IDbConnection dbConnection, string loggingPath = null)
        {

            DbConnection = dbConnection;
            LoggingPathFile = loggingPath;

            return lazyLogging.Value;

        }


        public void Error(string user, string message, Exception exception, LogAppender logAppender, bool canNotify = false)
        {

            bool canAppendWithSQL = logAppender == LogAppender.all || logAppender == LogAppender.sql;
            bool canAppendWithFILE = logAppender == LogAppender.all || logAppender == LogAppender.file;
            Action<ILogBase> log = x => x.Error(user, message, exception);


            try
            {


                if (canAppendWithSQL)
                    log.Invoke(LogDB.GetLog(DbConnection));


                if (canAppendWithFILE)
                {
                    if (string.IsNullOrEmpty(LoggingPathFile))
                        throw new Exception("file path is empty.");

                    log.Invoke(LogFile.GetLog(LoggingPathFile));

                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Error<T>(T valueObject, string user, string message, Exception exception, LogAppender logAppender, bool canNotify = false) where T : class
        {

            bool canAppendWithSQL = logAppender == LogAppender.all || logAppender == LogAppender.sql;
            bool canAppendWithFILE = logAppender == LogAppender.all || logAppender == LogAppender.file;

            Action<ILogBase> log = x => x.Error(valueObject, user, message, exception);


            try
            {


                if (canAppendWithSQL)
                    log.Invoke(LogDB.GetLog(DbConnection));


                if (canAppendWithFILE)
                {
                    if (string.IsNullOrEmpty(LoggingPathFile))
                        throw new Exception("file path is empty.");

                    log.Invoke(LogFile.GetLog(LoggingPathFile));

                }



            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Info(string user, string message, LogAppender logAppender, bool canNotify = false)
        {

            bool canAppendWithSQL = logAppender == LogAppender.all || logAppender == LogAppender.sql;
            bool canAppendWithFILE = logAppender == LogAppender.all || logAppender == LogAppender.file;

            Action<ILogBase> log = x => x.Info(user, message);


            try
            {


                if (canAppendWithSQL)
                    log.Invoke(LogDB.GetLog(DbConnection));


                if (canAppendWithFILE)
                {
                    if (string.IsNullOrEmpty(LoggingPathFile))
                        throw new Exception("file path is empty.");

                    LogFile.GetLog(LoggingPathFile).Info(user, message);


                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Debug(string user, string message, Exception exception, LogAppender logAppender, bool canNotify = false)
        {
            bool canAppendWithSQL = logAppender == LogAppender.all || logAppender == LogAppender.sql;
            bool canAppendWithFILE = logAppender == LogAppender.all || logAppender == LogAppender.file;

            Action<ILogBase> log = x => x.Debug(user, message, exception);

            try
            {

                if (canAppendWithSQL)
                    log.Invoke(LogDB.GetLog(DbConnection));


                if (canAppendWithFILE)
                {
                    if (string.IsNullOrEmpty(LoggingPathFile))
                        throw new Exception("file path is empty.");

                    log.Invoke(LogFile.GetLog(LoggingPathFile));

                }



            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void Debug<T>(T valueObject, string user, string message, Exception exception, LogAppender logAppender, bool canNotify = false) where T : class
        {

            bool canAppendWithSQL = logAppender == LogAppender.all || logAppender == LogAppender.sql;
            bool canAppendWithFILE = logAppender == LogAppender.all || logAppender == LogAppender.file;

            Action<ILogBase> log = x => x.Debug(valueObject, user, message, exception);


            try
            {


                if (canAppendWithSQL)
                    log.Invoke(LogDB.GetLog(DbConnection));


                if (canAppendWithFILE)
                {
                    if (string.IsNullOrEmpty(LoggingPathFile))
                        throw new Exception("file path is empty.");

                    log.Invoke(LogFile.GetLog(LoggingPathFile));

                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Info<T>(T valueObject, string user, string message, LogAppender logAppender, bool canNotify = false)
        {

            bool canAppendWithSQL = logAppender == LogAppender.all || logAppender == LogAppender.sql;
            bool canAppendWithFILE = logAppender == LogAppender.all || logAppender == LogAppender.file;

            Action<ILogBase> log = x => x.Info(valueObject, user, message);


            try
            {


                if (canAppendWithSQL)
                    log.Invoke(LogDB.GetLog(DbConnection));


                if (canAppendWithFILE)
                {
                    if (string.IsNullOrEmpty(LoggingPathFile))
                        throw new Exception("file path is empty.");

                    log.Invoke(LogFile.GetLog(LoggingPathFile));

                }


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
