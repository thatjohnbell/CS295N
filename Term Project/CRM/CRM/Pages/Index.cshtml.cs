using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRM;
using CRM.Models;

namespace CRM.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CRM.Models.CustContext _context;

        public IndexModel(CRM.Models.CustContext context)
        {
            _context = context;
        }

        public Customer Customer { get;set; }
        public Customer Lead { get; set; }

        public void OnGet()
        {
            Customer = (from c in _context.Customer
                        select c).Where(s => s.CustomerType.Equals("Customer")).OrderBy(s => s.LastContact).FirstOrDefault();
            Lead = (from c in _context.Customer
                    select c).Where(s => s.CustomerType.Equals("Lead")).OrderBy(s => s.LastContact).FirstOrDefault();
        }
    }
}
