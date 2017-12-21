using System.Collections.Generic;

namespace ApacheLogs.Models
{
    public class RequestViewModel
    {
        public IEnumerable<Request> Requests { get; set; }
        public PageViewModel PageView { get; set; }
    }
}
