using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Pages.Books
{
    public class SearchModel : PageModel
    {

        private readonly BookContext _context;
        public SelectList Authors;


        [Display(Name = "Book Author")]
        public string BookAuthor {get; set;}

        [Display(Name = "Book Title")]
        public string BookTitle { get; set; }

        [Display(Name = "Book Publisher")]
        public string BookPublisher { get; set; }

        [Display(Name = "Date Published")]
        [DataType(DataType.Date)]
        public DateTime MinDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime MaxDate { get; set; }

        public SearchModel(BookContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }


        public async Task OnGetAsync(string bookAuthor, string bookTitle, string bookPublisher, DateTime minDate, DateTime maxDate)
        {

            IQueryable<string> authorQuery = from m in _context.Book
                                            orderby m.Author
                                            select m.Author;


            var books = from b in _context.Book
                        select b;

            if (!String.IsNullOrEmpty(bookTitle))
            {
                books = books.Where(s => s.Title.Contains(bookTitle));
            }

            if (!String.IsNullOrEmpty(bookAuthor))
            {
                //non lambda linq
                books = from b in books where b.Author == bookAuthor select b;
                //books = books.Where(x => x.Author == bookAuthor);
            }


            if (!String.IsNullOrEmpty(bookPublisher))
            {
                books = books.Where(x => x.Publisher.Contains(bookPublisher));
            }

            
            if (maxDate.Year!=0001)
            {
                books = books.Where(x => x.DatePublished > minDate && x.DatePublished<maxDate);
            }
            

            Authors = new SelectList(await authorQuery.Distinct().ToListAsync());
            Book = await books.ToListAsync();
        }
    }
}
