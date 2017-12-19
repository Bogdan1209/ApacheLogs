using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApacheLogs.Interfaces;
using System.Text.RegularExpressions;
using ApacheLogs.Exceptions;

namespace ApacheLogs.Utils
{
    public class LogRegex:ILogRegex
    {
        enum Month
        {
            Jan =1, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec
        };
        public string GetIP(string logLine)
        {
            Regex patternIP = new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
            if (Regex.IsMatch(logLine, patternIP.ToString()))
            {
                string IP = patternIP.Match(logLine).Value;
                return IP;
            }
            throw new NoMatchesFoundException("IP was not found");
        }
        public DateTime GetDateTime(string logLine)
        {
                var date = GetDate(logLine);
                var time = GetTime(logLine);
                var dateTime = new DateTime(date[2], date[1], date[0], time[0], time[1], time[2], DateTimeKind.Utc);
                dateTime.AddHours(-GetTimeZone(logLine));
                return dateTime;
        }

        private int[] GetDate(string logLine)
        {
            Regex patternDate = new Regex(@"\d{2}\/\w{3}\/\d{4}");
            if (Regex.IsMatch(logLine, patternDate.ToString())){
                string dateStr = patternDate.Match(logLine).Value;
                var dateStrArray = dateStr.Split('/');
                var month = (int)Enum.Parse(typeof(Month), dateStrArray[1]);
                dateStrArray[1] = month.ToString();

                return Array.ConvertAll(dateStrArray, int.Parse);
            }
            throw new NoMatchesFoundException("Date was not found");
        }

        private int[] GetTime(string logLine)
        {
            Regex patternTime = new Regex(@":\d{2}\:\d{2}\:\d{2}");
            if (Regex.IsMatch(logLine, patternTime.ToString()))
            {
                string timeStr = patternTime.Match(logLine).Value;
                return Array.ConvertAll(timeStr.Split(':'), int.Parse);
            }
            throw new NoMatchesFoundException("Time was not found");
        }

        private double GetTimeZone(string logLine)
        {
            Regex patternTimeZone = new Regex(@"[-|+]\d{4}");
            if (Regex.IsMatch(logLine, patternTimeZone.ToString()))
            {
                string timeZoneStr = patternTimeZone.Match(logLine).Value;
                timeZoneStr = timeZoneStr.Insert(3, ".");
                return double.Parse(timeZoneStr);
            }
            throw new NoMatchesFoundException("Time zone was not found");
        }


        public string GetTypeOfRequest(string logLine)
        {
            Regex patternTypeOfRequest = new Regex(@"POST|GET|HEAD");
            if (Regex.IsMatch(logLine, patternTypeOfRequest.ToString()))
            {
                return patternTypeOfRequest.Match(logLine).Value;
            }
            throw new NoMatchesFoundException("Type of request was not found");
        }
        public int GetResultOfRequest(string logLine)
        {
            Regex patternResultOfRequestAndSizeOfData = new Regex(@"\d{3}\s\d+");
            if (Regex.IsMatch(logLine, patternResultOfRequestAndSizeOfData.ToString()))
            {
                return int.Parse(patternResultOfRequestAndSizeOfData.Matches(logLine)[0].Value);
            }
            throw new NoMatchesFoundException("Result of request was not found");
        }
        public string GetPath(string logLine)
        {
            Regex patternPath = new Regex(@"(POST|GET|HEAD)\s\S*");
            if (Regex.IsMatch(logLine, patternPath.ToString()))
            {
                return patternPath.Matches(logLine)[1].Value;
            }
            throw new NoMatchesFoundException("Path was not found");
        }
        public (string, bool) GetFileName(string logLine)
        {
            Regex patternFileName = new Regex(@"\w+(\.html|\.php)");
            if (Regex.IsMatch(logLine, patternFileName.ToString()))
            {
                return (patternFileName.Match(logLine).Value, true);
            }

            throw new NoMatchesFoundException("File name was not found");
        }
        public int GetSizeOfData(string logLine)
        {
            Regex patternResultOfRequestAndSizeOfData = new Regex(@"\d{3}\s\d+");
            if (Regex.IsMatch(logLine, patternResultOfRequestAndSizeOfData.ToString()))
            {
                return int.Parse(patternResultOfRequestAndSizeOfData.Matches(logLine)[1].Value);
            }
            throw new NoMatchesFoundException("Size of data was not found");
        }
    }
}
