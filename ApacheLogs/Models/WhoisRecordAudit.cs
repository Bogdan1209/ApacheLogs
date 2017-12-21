using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApacheLogs.Models
{
    [Serializable()]
    public class WhoisRecordAudit
    {
        [System.Xml.Serialization.XmlElement("createdDate")]
        public string createdDate { get; set; }
        [System.Xml.Serialization.XmlElement("updatedDate")]
        public string updatedDate { get; set; }
    }
}
