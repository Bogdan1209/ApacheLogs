﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApacheLogs.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string PageName { get; set; }
        public int SizeFile { get; set; }
        public Request Request { get; set; }
    }
}
