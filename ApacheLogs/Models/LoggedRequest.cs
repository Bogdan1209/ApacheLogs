using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApacheLogs.Models
{
    public class LoggedRequest
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public string TypeOfRequest { get; set; }
        public int ResultOfRequest { get; set; }
        public DownloadedFile File { get; set; }
        public IPAddress IP { get; set; }
    }
}
