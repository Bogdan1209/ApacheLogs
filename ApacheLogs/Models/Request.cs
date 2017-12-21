using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApacheLogs.Models
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string TypeOfRequest { get; set; }
        public int ResultOfRequest { get; set; }
        public int FileId { get; set; }
        public File File { get; set; }
        public int IPAddressId { get; set; }
        public IpAddress IP { get; set; }
        public int LogFileId { get; set; }
        public LogFile LogFile { get; set; }
    }
}
