using SLogging.Common;
using System;

namespace SLogging.Contracts
{
    public interface ILog
    {
       
        void Debug(string user, string message, Exception exception, LogAppender logAppender, bool canNotify = false);
        void Debug<T>(T valueObject, string user, string message, Exception exception, LogAppender logAppender, bool canNotify = false) where T : class;
        void Error(string user, string message, Exception exception, LogAppender logAppender, bool canNotify = false);
        void Error<T>(T valueObject, string user, string message, Exception exception, LogAppender logAppender, bool canNotify = false) where T : class;
        void Info(string user, string message, LogAppender logAppender, bool canNotify = false);
        void Info<T>(T valueObject, string user, string message, LogAppender logAppender, bool canNotify = false);

    }

}
