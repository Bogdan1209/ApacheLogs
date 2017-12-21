using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApacheLogs.Models
{
    [Serializable()]
    public class WhoisRecordNameServers
    {
        [System.Xml.Serialization.XmlElement("rawText")]
        public string rawText { get; set; }
        [System.Xml.Serialization.XmlElement("hostNames")]
        public WhoisHosts hostNames { get; set; }
        [System.Xml.Serialization.XmlElement("ips")]
        public WhoisHosts ips { get; set; }
    }
}
