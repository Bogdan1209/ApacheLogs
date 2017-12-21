using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApacheLogs.Interfaces
{
    public interface IRegexParser
    {
        string GetIP(string logLine);
        DateTime GetDateTime(string logLine);
        string GetTypeOfRequest(string logLine);
        int GetResultOfRequest(string logLine);
        string GetPath(string logLine);
        (string, bool) GetFileName(string logLine);
        int GetSizeOfData(string logLine);
        string GetPageName(string htmlPage);
    }
}
