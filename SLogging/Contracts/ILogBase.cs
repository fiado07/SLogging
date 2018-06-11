using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLogging.Contracts
{

    internal interface ILogBase
    {

        void Error(string user, string message, Exception exception);
        void Error<T>(T valueObject, string user, string message, Exception exception) where T : class;

        void Info(string user, string message);
        void Info<T>(T valueObject, string user, string message);

        void Debug(string user, string message, Exception exception);
        void Debug<T>(T valueObject, string user, string message, Exception exception) where T : class;

    }

}
