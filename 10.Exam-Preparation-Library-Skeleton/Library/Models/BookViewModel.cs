using Library.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Category { get; set; } = null!;
    }
}

//•	Has Id – a unique integer, Primary Key 
//•	Has Title – a string with min length 10 and max length 50 (required) 
//•	Has Author – a string with min length 5 and max length 50 (required) 
//•	Has Description – a string with min length 5 and max length 5000 (required) 
//•	Has ImageUrl – a string (required) 
//•	Has Rating – a decimal with min value 0.00 and max value 10.00 (required) 
//•	Has CategoryId – an integer, foreign key (required) 
//•	Has Category – a Category (required) 
//•	Has UsersBooks – a collection of type IdentityUserBook 