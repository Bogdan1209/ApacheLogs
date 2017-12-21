using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApacheLogs.Models
{
    public class WhoisRecord
    {
        [System.Xml.Serialization.XmlElement("createdDate")]
        public string createdDate { get; set; }
        [System.Xml.Serialization.XmlElement("updatedDate")]
        public string updatedDate { get; set; }
        [System.Xml.Serialization.XmlElement("expiresDate")]
        public string expiresDate { get; set; }
        [System.Xml.Serialization.XmlElement("registrant")]
        public WhoisRecordContact registrant { get; set; }
        [System.Xml.Serialization.XmlElement("administrativeContact")]
        public WhoisRecordContact administrativeContact { get; set; }
        [System.Xml.Serialization.XmlElement("billingContact")]
        public WhoisRecordContact billingContact { get; set; }
        [System.Xml.Serialization.XmlElement("technicalContact")]
        public WhoisRecordContact technicalContact { get; set; }
        [System.Xml.Serialization.XmlElement("zoneContact")]
        public WhoisRecordContact zoneContact { get; set; }
        [System.Xml.Serialization.XmlElement("domainName")]
        public string domainName { get; set; }
        [System.Xml.Serialization.XmlElement("nameServers")]
        public WhoisRecordNameServers nameServers { get; set; }
        [System.Xml.Serialization.XmlElement("rawText")]
        public string rawText { get; set; }
        [System.Xml.Serialization.XmlElement("header")]
        public string header { get; set; }
        [System.Xml.Serialization.XmlElement("strippedText")]
        public string strippedText { get; set; }
        [System.Xml.Serialization.XmlElement("footer")]
        public string footer { get; set; }
        [System.Xml.Serialization.XmlElement("audit")]
        public WhoisRecordAudit audit { get; set; }
        [System.Xml.Serialization.XmlElement("registrarName")]
        public string registrarName { get; set; }
        [System.Xml.Serialization.XmlElement("registryData")]
        public WhoisRecordRegistryData registryData { get; set; }
        [System.Xml.Serialization.XmlElement("domainAvailability")]
        public string domainAvailability { get; set; }
        [System.Xml.Serialization.XmlElement("contactEmail")]
        public string contactEmail { get; set; }
        [System.Xml.Serialization.XmlElement("domainNameExt")]
        public string domainNameExt { get; set; }
    }
}
