using System.Collections.Generic;
using System.Threading.Tasks;
using ApacheLogs.Models;

namespace ApacheLogs.Interfaces
{
    public interface ILogRepository
    {
        Task CreateAsync(LogFile item);
        IEnumerable<LogFile> GetAll();
    }
}
