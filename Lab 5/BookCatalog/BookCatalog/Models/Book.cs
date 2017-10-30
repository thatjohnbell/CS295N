using System;

namespace BookCatalog
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime DatePublished { get; set; }
        public string Author { get; set; }
        public int Rating { get; set; }
        public string Rater { get; set; }

    }
}