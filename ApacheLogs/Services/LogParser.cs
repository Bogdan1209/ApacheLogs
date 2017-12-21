using System;
using System.Collections.Generic;
using ApacheLogs.Interfaces;
using ApacheLogs.Models;
using ApacheLogs.Utils;
using Microsoft.AspNetCore.Http;
using ApacheLogs.Repositories;
using System.IO;
using System.Threading.Tasks;

namespace ApacheLogs.Services
{
    public class LogParser:ILogParser
    {
        IUnitOfWork uow;
        IRegexParser logRegex;
        ISendRequest sendRequest;
        string userDomain;
        public LogParser(string userDomain)
        {
            uow = new UnitOfWork();
            this.userDomain = userDomain;
            sendRequest = new SendRequest(userDomain);
            logRegex = new RegexParser();
        }

        public List<string> ConvertToList(IFormFile logFile)
        {
            var stream = logFile.OpenReadStream();
            var logs = new List<string>();

            using (var streamReader = new StreamReader(stream))
            {
                while (!streamReader.EndOfStream)
                {
                    logs.Add(streamReader.ReadLine());
                }
            }
            return logs;
        }
        /// <summary>
        /// Save logs from list to database and return id of saved log file
        /// </summary>
        /// <param name="logs"></param>
        /// <returns>Id of saved log file</returns>
        public async Task<int> SaveLogsToDataBaseAsync(List<string> logs)
        {
            LogFile logFile = new LogFile
            {
                Date = DateTime.Now,
                Name = userDomain
            };
            for(int i = 0; i < logs.Count; i++)
            {
                try
                {
                    var file = GetFileData(logs[i]);
                    if (file == null)
                    {
                        continue;
                    }
                    var ip = GetIPAddress(logs[i]);
                    var request = GetLoggedRequest(logs[i], file, ip, logFile);
                    await uow.Requests.CreateAsync(request);
                }
                catch
                {
                    continue;
                }
            }
            await uow.SaveAsync();
            return logFile.Id;
        }


        private IpAddress GetIPAddress(string logLine)
        {
            var ip = logRegex.GetIP(logLine);
            var companyName = sendRequest.GetCompanyName(ip);
            return new IpAddress
            {
                IP = ip,
                CompanyName = companyName
            };
        }

        private Models.File GetFileData(string logLine)
        {
            var fileName = logRegex.GetFileName(logLine);
            //if file is image, style ot script return null
            if (!fileName.Item2)
            {
                return null;
            }
            var path = logRegex.GetPath(logLine);
            var size = logRegex.GetSizeOfData(logLine);
            var pageName = sendRequest.GetPageName(path);
            return new Models.File
            {
                Path = path,
                FileName = fileName.Item1,
                SizeFile = size,
                PageName = pageName
            };

        }

        private Request GetLoggedRequest(string logLine, Models.File file, IpAddress ip, LogFile logFile)
        {
            var date = logRegex.GetDateTime(logLine);
            var resultOfRequest = logRegex.GetResultOfRequest(logLine);
            var typeOfRequest = logRegex.GetTypeOfRequest(logLine);
            var request = new Request
            {
                Date = date,
                ResultOfRequest = resultOfRequest,
                TypeOfRequest = typeOfRequest
            };
            
            return new Request
            {
                Date = date,
                ResultOfRequest = resultOfRequest,
                TypeOfRequest = typeOfRequest,
                File = file,
                IP = ip,
                LogFile = logFile
            };
        }
    }
}
