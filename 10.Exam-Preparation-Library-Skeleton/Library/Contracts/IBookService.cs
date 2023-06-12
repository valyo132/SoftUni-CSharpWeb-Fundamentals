using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<List<AllBooksViewModel>> GetAllBooksAsync();
        Task<UsersBooksViewModel> GetUsersBooks(string userId);
        Task AddBook(AddBookViewModel model);
        Task<AddBookViewModel> GetAddBookViewModel();
        Task AddBookToCollection(int id, string userId);
        Task RemoveBookFromCollection(int id, string userId);
    }
}
