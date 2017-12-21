using System.Collections.Generic;
using System.Threading.Tasks;
using ApacheLogs.Interfaces;
using ApacheLogs.Models;

namespace ApacheLogs.Repositories
{
    public class LogRepository:ILogRepository
    {
        ApplicationContext context;
        public LogRepository(ApplicationContext applicationContext)
        {
            context = applicationContext;
        }

        public async Task CreateAsync(LogFile file)
        {
            await context.logFiles.AddAsync(file);
        }

        public IEnumerable<LogFile> GetAll()
        {
            return context.logFiles;
        }
    }
}
