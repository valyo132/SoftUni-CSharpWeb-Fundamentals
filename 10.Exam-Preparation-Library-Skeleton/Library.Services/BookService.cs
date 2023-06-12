using Library.Data;
using Library.Models;
using Library.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _context;

        public BookService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<AllBooksViewModel>> GetAllBooksAsync()
        {
            return await _context.Books
                .Select(b => new AllBooksViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                }).ToListAsync();
        }
    }
}
