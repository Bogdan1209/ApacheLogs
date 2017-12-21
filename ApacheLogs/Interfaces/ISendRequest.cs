using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApacheLogs.Interfaces
{
    interface ISendRequest
    {
        string GetCompanyName(string ip);
        string GetPageName(string path);
    }
}
