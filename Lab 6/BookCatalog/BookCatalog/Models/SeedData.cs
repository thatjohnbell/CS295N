using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookContext(
                serviceProvider.GetRequiredService<DbContextOptions<BookContext>>()))
            {
                // Look for any movies.
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book
                    {
                        Title = "Walden",
                        DatePublished = DateTime.Parse("1854-08-09"),
                        Author = "Henry David Thoreau",
                        Rating = 4,
                        Rater = "John"
                    },
                    new Book
                    {
                        Title = "Post Office",
                        DatePublished = DateTime.Parse("1971-01-01"),
                        Author = "Charles Bukowski",
                        Rating = 4,
                        Rater = "John"
                    },
                    new Book
                    {
                        Title = "Factotum",
                        DatePublished = DateTime.Parse("1975-01-01"),
                        Author = "Charles Bukowski",
                        Rating = 4,
                        Rater = "John"
                    },
                    new Book
                    {
                        Title = "Ham on Rye",
                        DatePublished = DateTime.Parse("1982-09-01"),
                        Author = "Charles Bukowski",
                        Rating = 4,
                        Rater = "John"
                    },
                    new Book
                    {
                        Title = "Tao Te Ching",
                        DatePublished = DateTime.Parse("1868-01-01"),
                        Author = "Laozi",
                        Rating = 4,
                        Rater = "John"
                    },
                    new Book
                    {
                        Title = "The Orientalist",
                        DatePublished = DateTime.Parse("2005-02-01"),
                        Author = "Tom Reiss",
                        Rating = 4,
                        Rater = "John"
                    },
                    new Book
                    {
                        Title = "Requiem for a Dream",
                        DatePublished = DateTime.Parse("1978-01-01"),
                        Author = "Hubert Selby Jr. ",
                        Rating = 4,
                        Rater = "John"
                    });

                context.SaveChanges();
            }
        }

    }
}
