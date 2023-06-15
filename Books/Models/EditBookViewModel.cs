using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class EditBookViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int NumberOfPages { get; set; }

        public List<string> Categories { get; set; }
    }
}
