using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApacheLogs.Interfaces;
using ApacheLogs.Models;

namespace ApacheLogs.Repositories
{
    public class FileRepository:IFileRepository
    {
        ApplicationContext context;
        public FileRepository(ApplicationContext applicationContext)
        {
            context = applicationContext;
        }

        public async Task CreateAsync(File file)
        {
            await context.Files.AddAsync(file);
        }
        public async Task DeleteAsync(int id)
        {
            var file = await context.Files.FindAsync(id);
            if(file != null)
            {
                context.Files.Remove(file);
            }
        }
    }
}
