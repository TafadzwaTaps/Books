using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Number of Pages is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of Pages must be a positive value")]
        public int NumberOfPages { get; set; }

        [Required(ErrorMessage = "Categories are required")]
        public List<string> Categories { get; set; }

        public Book(int id, string title, string author, int numberOfPages, List<string> categories)
        {
            Id = id;
            Title = title;
            Author = author;
            NumberOfPages = numberOfPages;
            Categories = categories;
        }
    }
}
