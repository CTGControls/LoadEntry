using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models.Shared
{
    public class APIError
    {
        public int status { get; set; } = 0;
        public int code { get; set; } = 0;
        public string message { get; set; } = "";
        public string developerMessage { get; set; } = "";
        public string moreinfo { get; set; } = "";
        public string requestId { get; set; } = "";

    }
}