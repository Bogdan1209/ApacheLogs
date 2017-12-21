using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApacheLogs.Models
{
    public class IpAddress
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(16)")]
        public string IP { get; set; }
        public string CompanyName { get; set; }
        public Request Request { get; set; }
    }
}
