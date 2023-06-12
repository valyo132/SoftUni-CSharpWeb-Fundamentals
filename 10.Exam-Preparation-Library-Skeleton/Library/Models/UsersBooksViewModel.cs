namespace Library.Models
{
    public class UsersBooksViewModel
    {
        public ICollection<BookViewModel> Books { get; set; } = new List<BookViewModel>();
    }
}
