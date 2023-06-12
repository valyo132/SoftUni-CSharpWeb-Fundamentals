using Library.Models;

namespace Library.Services.Contracts
{
    public interface IBookService
    {
        Task<List<AllBooksViewModel>> GetAllBooksAsync();
    }
}
