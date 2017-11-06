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
        public SelectList Authors;

        public string BookAuthor {get; set;}

        public IndexModel(BookContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }


        public async Task OnGetAsync(string bookAuthor, string searchString)
        {

            IQueryable<string> authorQuery = from m in _context.Book
                                            orderby m.Author
                                            select m.Author;

            var books = from b in _context.Book
                        select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(bookAuthor))
            {
                books = books.Where(x => x.Author == bookAuthor);
            }

            Authors = new SelectList(await authorQuery.Distinct().ToListAsync());
            Book = await books.ToListAsync();
        }
    }
}
