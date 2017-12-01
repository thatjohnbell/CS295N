using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM
{
    public class Customer
    {
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 1)]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(60, MinimumLength = 2)]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        [Range(10000,99999)]
        [DataType(DataType.PostalCode)]
        public int ZipCode { get; set; }

        [Display(Name = "Client Type")]
        public string CustomerType { get; set; }

        [Display(Name = "Account Notes")]
        public string Notes { get; set; }

        [Display(Name = "Last Contacted Time")]
        [DataType(DataType.DateTime)]
        public DateTime LastContact { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public long PhoneNumber { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Company Position")]
        public string Position { get; set; }
    }
}
