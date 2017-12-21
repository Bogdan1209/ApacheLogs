using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApacheLogs.Interfaces;
using ApacheLogs.Models;

namespace ApacheLogs.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        ApplicationContext db;
        ILogRepository logRepository;
        IFileRepository fileRepository;
        IRequestRepository requestRepository;
        IIpRepository ipRepository;

        public UnitOfWork()
        {
            db = new ApplicationContext();
        }

        public ILogRepository LogFiles
        {
            get
            {
                if (logRepository == null)
                {
                    logRepository = new LogRepository(db);
                }
                return logRepository;
            }
        }

        public IFileRepository Files
        {
            get
            {
                if (fileRepository == null)
                {
                    fileRepository = new FileRepository(db);
                }
                return fileRepository;
            }
        }

        public IRequestRepository Requests
        {
            get
            {
                if (requestRepository == null)
                {
                    requestRepository = new RequestRepository(db);
                }
                return requestRepository;
            }
        }

        public IIpRepository IPs
        {
            get
            {
                if (ipRepository == null)
                {
                    ipRepository = new IpRepository(db);
                }
                return ipRepository;
            }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
