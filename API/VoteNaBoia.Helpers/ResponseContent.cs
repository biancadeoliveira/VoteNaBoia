using System;
using System.Collections.Generic;
using System.Text;

namespace VoteNaBoia.Helpers
{
    public class ResponseContent
    {
        public object Object { get; set; }
        public string Message { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
