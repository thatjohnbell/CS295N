using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookCatalog;
using Microsoft.AspNetCore.Http;

namespace BookCatalog.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly BookCatalog.BookContext _context;
        const string NAME = "username";

        public CreateModel(BookCatalog.BookContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            SetName(Book.Rater);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public void SetName(string n)
        {
            HttpContext.Session.SetString(NAME, n);

        }

        public string GetName()
        {
            string n = HttpContext.Session.GetString(NAME);
            if (n == null) n = "";
            return n;
        }
    }
}