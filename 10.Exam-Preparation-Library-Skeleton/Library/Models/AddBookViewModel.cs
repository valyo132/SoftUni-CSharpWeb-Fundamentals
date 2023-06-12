using Library.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class AddBookViewModel
    {
        [Required]
        [MaxLength(50), MinLength(10)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(50), MinLength(5)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(5000), MinLength(5)]
        public string Description { get; set; } = null!;

        [Required]
        public string Url { get; set; } = null!;

        [Required]
        [Range(0.00, 10.00)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
