using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookCatalog.Pages.Books
{
    public class IndexModel : PageModel
    {

        private readonly BookContext _context;


        public string BookAuthor {get; set;}

        public IndexModel(BookContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }


        public async Task OnGetAsync(string bookAuthor, string searchString)
        {


            var books = from b in _context.Book
                        select b;
            Book = await books.ToListAsync();
        }
    }
}
