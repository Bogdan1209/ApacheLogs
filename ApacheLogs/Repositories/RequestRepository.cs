using ApacheLogs.Interfaces;
using ApacheLogs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApacheLogs.ExtensionMethods;

namespace ApacheLogs.Repositories
{
    public class RequestRepository: IRequestRepository
    {
        ApplicationContext context;
        public RequestRepository(ApplicationContext applicationContext)
        {
            context = applicationContext;
        }
        public async Task CreateAsync(Request file)
        {
            await context.Requests.AddAsync(file);
        }

        public void Create(Request file)
        {
            context.Requests.Add(file);
        }
        public async Task DeleteAsync(int id)
        {
            var request = await context.Requests.FindAsync(id);
            if(request != null)
            {
                context.Requests.Remove(request);
            }
        }
        public IEnumerable<Request> Get(int logFileId,int pageNumber = 1, string orderBy = "Date", int pageSize = 15)
        {
            var requests = context.Requests.Include(i => i.IP).Include(f => f.File).OrderByName(orderBy).Where(r => r.LogFileId == logFileId)
                .Skip((pageNumber - 1) * pageSize).ToList();
            return requests.Take(pageSize); 
        }

        public int GetTotalCount(int id)
        {
            return context.Requests.Where(o => o.LogFileId == id).Count();
        }
    }
}
