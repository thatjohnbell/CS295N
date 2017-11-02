using System;
using System.ComponentModel.DataAnnotations;

namespace BookCatalog
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        [Display(Name = "Publication Date")]
        [DataType(DataType.Date)]
        public DateTime DatePublished { get; set; }
        public string Author { get; set; }
        [Range(1,5)]
        public int Rating { get; set; }
        public string Rater { get; set; }

    }
}