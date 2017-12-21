using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApacheLogs.Interfaces;
using System.Net;
using System.Xml;
using ApacheLogs.Models;

namespace ApacheLogs.Utils
{
    public class SendRequest:ISendRequest
    {
        IRegexParser regexParser;
        string domain;

        public SendRequest(string domain)
        {
            this.domain = domain;
            regexParser = new RegexParser();
        }
        public string GetCompanyName(string ip)
        {
            string username = "bogdan1209";
            string password = "donthackmeplease";
            string domain = ip;

            
            string format = "XML";
            string url = "http://www.whoisxmlapi.com/whoisserver/WhoisService?domainName=" + domain + "&username=" + username + "&password=" + password + "&outputFormat=" + format;
            
            var settings = new XmlReaderSettings();
            var reader = XmlReader.Create(url, settings);
            WhoisRecord record = new WhoisRecord();
            //Бесплатно можно сделать ограниченое число запросов на Whois сервер,
            //поэтому эта часть кода закомментирована.
            /*try
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(WhoisRecord));
                record = (WhoisRecord)serializer.Deserialize(reader);

                reader.Close();

                return record.administrativeContact.name;
            }
            catch
            {
                return "Default name";
            }*/
            return "Default name";

        }
        public string GetPageName(string path)
        {
            string html;
            using (WebClient client = new WebClient())
            {
                try
                {
                    html = client.DownloadString(domain + path);
                }
                catch(WebException we)
                {
                    return ((HttpWebResponse)we.Response).StatusCode.ToString();
                }
            }
            return regexParser.GetPageName(html);
        }
    }
}
