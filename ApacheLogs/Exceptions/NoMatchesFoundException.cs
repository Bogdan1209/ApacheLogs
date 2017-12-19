using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApacheLogs.Exceptions
{
    public class NoMatchesFoundException: Exception
    {
        public NoMatchesFoundException(string message)
            :base(message)
        { }
    }
}
