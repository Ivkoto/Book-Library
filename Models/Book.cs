using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_library.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Title:")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Author:")]
        [Required]
        public string Author { get; set; }

        [Display(Name = "Genre:")]
        [Required]
        public string Genre { get; set; }

        [Display(Name = "Shared with:")]
        public string SharedWith { get; set; }

        [Display(Name ="Pages:")]
        public int Pages { get; set; }
    }
}
