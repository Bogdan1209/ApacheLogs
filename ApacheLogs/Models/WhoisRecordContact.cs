using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApacheLogs.Models
{
    [Serializable()]
    public class WhoisRecordContact
    {
        [System.Xml.Serialization.XmlElement("name")]
        public string name { get; set; }
        [System.Xml.Serialization.XmlElement("organization")]
        public string organization { get; set; }
        [System.Xml.Serialization.XmlElement("street1")]
        public string street1 { get; set; }
        [System.Xml.Serialization.XmlElement("street2")]
        public string street2 { get; set; }
        [System.Xml.Serialization.XmlElement("city")]
        public string city { get; set; }
        [System.Xml.Serialization.XmlElement("state")]
        public string state { get; set; }
        [System.Xml.Serialization.XmlElement("postalCode")]
        public string postalCode { get; set; }
        [System.Xml.Serialization.XmlElement("country")]
        public string country { get; set; }
        [System.Xml.Serialization.XmlElement("email")]
        public string email { get; set; }
        [System.Xml.Serialization.XmlElement("telephone")]
        public string telephone { get; set; }
        [System.Xml.Serialization.XmlElement("rawText")]
        public string rawText { get; set; }
        [System.Xml.Serialization.XmlElement("unparsable")]
        public string unparsable { get; set; }
    }
}
