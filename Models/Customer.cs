using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSONObject.Models
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}