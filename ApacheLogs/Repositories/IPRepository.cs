using ApacheLogs.Interfaces;
using ApacheLogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApacheLogs.Repositories
{
    public class IpRepository:IIpRepository
    {
        ApplicationContext context;
        public IpRepository(ApplicationContext applicationContext)
        {
            context = applicationContext;
        }

        public async Task CreateAsync(IpAddress file)
        {
            await context.IPs.AddAsync(file);
        }
        public async Task DeleteAsync(int id)
        {
            var file = await context.IPs.FindAsync(id);
            if (file != null)
            {
                context.IPs.Remove(file);
            }
        }
    }
}
