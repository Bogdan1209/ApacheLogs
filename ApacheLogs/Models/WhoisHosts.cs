using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApacheLogs.Models
{
    [Serializable()]
    public class WhoisHosts
    {
        [System.Xml.Serialization.XmlElement("Address")]
        public List<string> Items { get; set; }
    }
}
