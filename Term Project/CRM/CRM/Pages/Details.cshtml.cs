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
    public class DetailsModel : PageModel
    {
        private readonly CRM.Models.CustContext _context;
        public bool Updated { get; set; }
        


        public DetailsModel(CRM.Models.CustContext context)
        {
            _context = context;
           
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer.SingleOrDefaultAsync(m => m.ID == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {

            Customer = _context.Customer.SingleOrDefault(m => m.ID == id);


            if (Request.Form["Updated"].Contains("true"))
            {
                Customer.LastContact = DateTime.Now;
            }
            Customer.Notes = Request.Form["Customer.Notes"];
            _context.Entry(Customer).State = EntityState.Modified;


            _context.SaveChanges();


            return Page();
        }
    }
}
