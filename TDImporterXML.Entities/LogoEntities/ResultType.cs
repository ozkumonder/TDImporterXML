using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBUretim.Mvc.Models
{   
    public class ResultType
    {
        public bool State { get; set; }
        public int ErrorId { get; set; }
        public string ErrorMessage { get; set; }
        public object Result { get; set; }
    }
}