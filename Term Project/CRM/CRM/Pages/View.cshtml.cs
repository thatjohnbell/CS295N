using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRM;
using CRM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRM.Pages
{
    public class ViewModel : PageModel
    {
        private readonly CRM.Models.CustContext _context;
        public IList<Customer> Customer { get; set; }
        public SelectList Types;
        public string Type;
        public string NameSort { get; set; }
        public string DateSort { get; set; }

        public ViewModel(CRM.Models.CustContext context)
        {
            _context = context;
        }



        public async Task OnGetAsync(string type, string sortOrder)
        {

            var customers = from c in _context.Customer
                         select c;

            IQueryable<string> typeQuery = from c in _context.Customer
                                           orderby c.CustomerType
                                           select c.CustomerType;

            if (!String.IsNullOrEmpty(type))
            {
                customers = customers.Where(s => s.CustomerType.Equals(type));
            }


                    NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        DateSort = sortOrder == "Date" ? "date_desc" : "Date";


            switch (sortOrder)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    customers = customers.OrderBy(s => s.LastContact);
                    break;
                case "date_desc":
                    customers = customers.OrderByDescending(s => s.LastContact);
                    break;
                default:
                    customers = customers.OrderBy(s => s.LastName);
                    break;
            }


            Types = new SelectList(await typeQuery.Distinct().ToListAsync());
            Customer = await customers.ToListAsync();
        }


    }
}
