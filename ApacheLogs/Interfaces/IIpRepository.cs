using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApacheLogs.Models;

namespace ApacheLogs.Interfaces
{
    public interface IIpRepository
    {
        Task CreateAsync(IpAddress ip);
        Task DeleteAsync(int id);
    }
}
