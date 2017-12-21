using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApacheLogs.Models;

namespace ApacheLogs.Interfaces
{
    public interface IRequestRepository
    {
        Task CreateAsync(Request file);
        void Create(Request file);
        Task DeleteAsync(int id);
        IEnumerable<Request> Get(int logFileId, int pageNumber = 1, string orderBy = "Date", int pageSize = 15);
        int GetTotalCount(int id);
    }
}
