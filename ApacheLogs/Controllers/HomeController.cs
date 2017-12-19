using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApacheLogs.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ApacheLogs.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<string> UploadLog(IFormFile logFile)
        {
            if (logFile != null)
            {
                
            }
            
            return "Ok))0))00)))";
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
