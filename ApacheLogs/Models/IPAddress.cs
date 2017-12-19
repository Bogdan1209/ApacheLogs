using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApacheLogs.Models
{
    public class IPAddress
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(16)")]
        public string IP { get; set; }
        public string CompanyName { get; set; }
        public LoggedRequest Request { get; set; }
    }
}
