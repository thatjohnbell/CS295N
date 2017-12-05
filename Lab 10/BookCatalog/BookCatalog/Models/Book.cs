using System;
using System.ComponentModel.DataAnnotations;

namespace BookCatalog
{
    public class Book
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Publication Date")]
        [DataType(DataType.Date)]
        public DateTime DatePublished { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Author { get; set; }

        [Display(Name = "Rating (1-5)")]
        [Range(1,5)]
        public int Rating { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Rater { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Publisher { get; set; }

    }
}