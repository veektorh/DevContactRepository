using DevContactDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevContactDirectory.Helper
{
    public class HelperClasses
    {
    }

    public class Response
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public DeveloperViewModel Developer { get; set; }
    }
}