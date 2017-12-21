using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApacheLogs.Models;

namespace ApacheLogs.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Request> Requests { get; set; }
        public DbSet<IpAddress> IPs { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<LogFile> logFiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=appacheLog;Trusted_Connection=True;");
        }
    }
}
