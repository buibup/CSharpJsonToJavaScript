using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSONObject.Models
{
    public class Todo
    {
        public string key { get; set; }
        public string name { get; set; }
        public bool isComplete { get; set; }
    }
}