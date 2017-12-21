using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ApacheLogs.Interfaces
{
    public interface ILogParser
    {
        List<string> ConvertToList(IFormFile logFile);
        Task<int> SaveLogsToDataBaseAsync(List<string> logs);
    }
}
