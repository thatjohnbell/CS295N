
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookCatalog.Models;
using System.Linq;

namespace BookCatalog.Controllers
{
    [Route("api/books")]
    public class BookController : Controller
    {
        private readonly BookContext _context;

        public BookController(BookContext context)
        {
            _context = context;

 
        }


        //get all books
        [HttpGet]
        public IEnumerable<Book> GetAll()
        {
            return _context.Book.ToList();
        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetById(long id)
        {
            var item = _context.Book.FirstOrDefault(t => t.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //create a book
        [HttpPost]
        public IActionResult Create([FromBody] Book item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Book.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetBook", new { id = item.ID }, item);
        }


        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Book item)
        {
            if (item == null || item.ID != id)
            {
                return BadRequest();
            }

            var book = _context.Book.FirstOrDefault(t => t.ID == id);
            if (book == null)
            {
                return NotFound();
            }

            book.ID = item.ID;
            book.Author = item.Author;
            book.DatePublished = item.DatePublished;
            book.Publisher = item.Publisher;
            book.Rater = item.Rater;
            book.Rating = item.Rating;
            book.Title = item.Title;
          
  
            _context.Book.Update(book);
            _context.SaveChanges();
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var book = _context.Book.FirstOrDefault(t => t.ID == id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Book.Remove(book);
            _context.SaveChanges();
            return new NoContentResult();
        }

    }
}