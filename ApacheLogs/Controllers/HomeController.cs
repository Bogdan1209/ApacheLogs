using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApacheLogs.Models;
using ApacheLogs.Interfaces;
using ApacheLogs.Services;
using Microsoft.AspNetCore.Http;
using ApacheLogs.Repositories;
using System.IO;

namespace ApacheLogs.Controllers
{
    public class HomeController : Controller
    {
        ILogParser logParser;
        IUnitOfWork uow;
        public HomeController()
        {
            uow = new UnitOfWork();
        }
        public IActionResult Index()
        {
            
            return View(uow.LogFiles.GetAll());
        }

        public async Task<IActionResult> UploadLog(IFormFile logFile, string siteDomain)
        {
            int logId;
            logParser = new LogParser(siteDomain);
            if (logFile != null && siteDomain != null)
            {
                var logs = logParser.ConvertToList(logFile);
                logId = await logParser.SaveLogsToDataBaseAsync(logs);
                return RedirectToAction("LogFile", new { id = logId });
            }
            return RedirectToAction("Index");
        }

        public IActionResult LogFile(int id, int pageNumber = 1)
        {
            var pageSize = 10;
            var requests = uow.Requests.Get(id, pageNumber,pageSize: pageSize).ToList();
            var totalCount = uow.Requests.GetTotalCount(id);
            PageViewModel pageView = new PageViewModel(totalCount, pageNumber, pageSize);
            var requestView = new RequestViewModel
            {
                Requests = requests,
                PageView = pageView
            };
            return View(requestView);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
