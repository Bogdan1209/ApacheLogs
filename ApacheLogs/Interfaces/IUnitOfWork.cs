using System;
using ApacheLogs.Models;
using System.Threading.Tasks;

namespace ApacheLogs.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        ILogRepository LogFiles { get; }
        IRequestRepository Requests { get; }
        IIpRepository IPs { get; }
        IFileRepository Files { get; }
        Task SaveAsync();
        void Save();
    }
}
