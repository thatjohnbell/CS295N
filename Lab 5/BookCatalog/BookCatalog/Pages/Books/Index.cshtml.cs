using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Pages.Books
{
    public class IndexModel : PageModel
    {

        private readonly BookCatalog.BookContext _context;

        public IndexModel(BookCatalog.BookContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }


        public async Task OnGetAsync()
        {

           Book = await _context.Book.ToListAsync();
        }
    }
}
