using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApacheLogs.Models;

namespace ApacheLogs.Interfaces
{
    public interface IFileRepository
    {
        Task CreateAsync(File file);
        Task DeleteAsync(int id);
    }
}
