using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string CustomerType { get; set; }
        public string Notes { get; set; }
        public DateTime LastContact { get; set; }
        public long PhoneNumber { get; set; }
    }
}
