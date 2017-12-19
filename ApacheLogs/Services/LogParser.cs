using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApacheLogs.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ApacheLogs.Services
{
    public class LogParser:ILogParser
    {
        public void ParseFile(IFormFile formFile)
        {
            var stream = formFile.OpenReadStream();
            var logs = new List<string>();

            using (var streamReader = new StreamReader(stream))
            {
                while (!streamReader.EndOfStream)
                {
                    logs.Add(streamReader.ReadLine());
                }
            }

        }
    }
}
