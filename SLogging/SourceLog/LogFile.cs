using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLogging.SourceLog
{
    internal class LogFile : Contracts.ILogBase
    {
        private static string logPathFile = string.Empty;

        private static readonly Lazy<LogFile> lazyLogging = new Lazy<LogFile>(() => new LogFile(logPathFile));

        #region initilizers

        private LogFile(string logPath)
        {

            logPathFile = logPath;

        }

        public static LogFile GetLog(string logPath)
        {

            logPathFile = logPath;

            return lazyLogging.Value;

        }

        #endregion


        #region log input


        public void Error(string user, string message, Exception exception)
        {

            Log(user, message, exception, Common.LogLevel.Error);

        }

        public void Error<T>(T valueObject, string user, string message, Exception exception) where T : class
        {
            Log(valueObject, user, message, exception, Common.LogLevel.Error);

        }

        public void Info(string user, string message)
        {
            Log(user, message, Common.LogLevel.Info);
        }
        public void Info<T>(T valueObject, string user, string message)
        {
            Log(valueObject, user, message, null, Common.LogLevel.Info);
        }
        public void Debug(string user, string message, Exception exception)
        {
            Log(user, message, exception, Common.LogLevel.Debug);
        }

        public void Debug<T>(T valueObject, string user, string message, Exception exception) where T : class
        {
            Log(valueObject, user, message, exception, Common.LogLevel.Debug);
        }

        #endregion


        #region log treatment

        private void Log<T>(T logContext, string user, string message, Exception ex, Common.LogLevel logLevel)
        {

            //string LogFile = AppDomain.CurrentDomain.BaseDirectory + string.Format(@"\Log\{0}log.txt", DateTime.Today.ToString("yyyy_MM_dd_"));
            string LogFile = logPathFile + string.Format(@"\{0}log.txt", DateTime.Today.ToString("yyyy_MM_dd_"));

            if (!System.IO.File.Exists(LogFile))
            {
                System.IO.FileStream ficheiro = System.IO.File.Create(LogFile);
                ficheiro.Close();

            }

            using (System.IO.StreamWriter ficheiro = System.IO.File.AppendText(LogFile))
            {

                ficheiro.WriteLine(FormatFile(logContext, user, message, ex, logLevel));

            }

        }

        private void Log(string user, string message, Exception ex, Common.LogLevel logLevel)
        {

            //string LogFile = AppDomain.CurrentDomain.BaseDirectory + string.Format(@"\Log\{0}log.txt", DateTime.Today.ToString("yyyy_MM_dd_"));
            string LogFile = logPathFile + string.Format(@"\{0}log.txt", DateTime.Today.ToString("yyyy_MM_dd_"));

            if (!System.IO.File.Exists(LogFile))
            {
                System.IO.FileStream ficheiro = System.IO.File.Create(LogFile);
                ficheiro.Close();

            }

            using (System.IO.StreamWriter ficheiro = System.IO.File.AppendText(LogFile))
            {

                ficheiro.WriteLine(FormatFile(user, message, ex, logLevel));

            }

        }

        private void Log(string user, string message, Common.LogLevel logLevel)
        {

            string LogFile = logPathFile + string.Format(@"\{0}log.txt", DateTime.Today.ToString("yyyy_MM_dd_"));

            if (!System.IO.File.Exists(LogFile))
            {
                System.IO.FileStream ficheiro = System.IO.File.Create(LogFile);
                ficheiro.Close();

            }


            using (System.IO.StreamWriter ficheiro = System.IO.File.AppendText(LogFile))
            {

                ficheiro.WriteLine(FormatFile(user, message, logLevel));

            }

        }
        StringBuilder buildFormat = new StringBuilder();

        private string FormatFile(object logContext, string user, string message, Exception ex, Common.LogLevel logLevel)
        {

            buildFormat = new StringBuilder();

            buildFormat.AppendFormat("Date : {0} \n", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")).AppendLine();
            buildFormat.AppendFormat("Logtype : {0} \n", logLevel.ToString()).AppendLine();
            buildFormat.AppendFormat("User : {0} ", user).AppendLine();
            buildFormat.AppendFormat("Message : {0}", message).AppendLine();
            buildFormat.AppendFormat("ValueObject : \n {0} \n", Common.Helpers.BuildStringLog(logContext)).AppendLine();

            if (ex != null)
                buildFormat.AppendFormat("Exception : \n {0} \n ", ex.ToString());

            buildFormat.AppendLine("--------------------------");

            return buildFormat.ToString();

        }

        private string FormatFile(string user, string message, Exception ex, Common.LogLevel logLevel)
        {

            buildFormat = new StringBuilder();

            buildFormat.AppendFormat("Date : {0} \n", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")).AppendLine();
            buildFormat.AppendFormat("Logtype : {0} \n", logLevel.ToString()).AppendLine();
            buildFormat.AppendFormat("User : {0} \n", user).AppendLine();
            buildFormat.AppendFormat("Message : \n {0} \n", message).AppendLine();

            if (ex != null)
                buildFormat.AppendFormat("Exception : \n {0} \n ", ex.ToString());

            buildFormat.AppendLine("--------------------------");


            return buildFormat.ToString();

        }

        private string FormatFile(string user, string message, Common.LogLevel logLevel)
        {

            buildFormat = new StringBuilder();

            buildFormat.AppendFormat("Date : {0} \n", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")).AppendLine();
            buildFormat.AppendFormat("Logtype : {0} \n", logLevel.ToString()).AppendLine();
            buildFormat.AppendFormat("User : {0} \n", user).AppendLine();
            buildFormat.AppendFormat("Message : \n {0} \n", message).AppendLine();
            buildFormat.AppendLine("-------------------------");

            return buildFormat.ToString();

        }

        #endregion


    }

}
