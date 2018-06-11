using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLogging.Contracts
{
    internal interface IDBRepository
    {

        void ExecuteSql(string sql, string exception = null);

        //List<string> GetMailsAddress();

    }

}
