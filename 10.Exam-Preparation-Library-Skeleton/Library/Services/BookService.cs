using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _context;

        public BookService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task AddBook(AddBookViewModel model)
        {
            Book book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                Rating = model.Rating,
                ImageUrl = model.Url,
                CategoryId = model.CategoryId
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task AddBookToCollection(int bookId, string userId)
        {
            bool isBookAlreadyAdded = await _context.IdentityUserBooks
                .AnyAsync(b => b.BookId == bookId && b.CollectorId == userId);

            if (!isBookAlreadyAdded)
            {
                _context.IdentityUserBooks.Add(new IdentityUserBook()
                {
                    CollectorId = userId,
                    BookId = bookId,
                });

                await _context.SaveChangesAsync();
            }
        }

        public async Task<AddBookViewModel> GetAddBookViewModel()
        {
            var categories = await _context.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();

            return new AddBookViewModel() { Categories = categories };
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

        public async Task<UsersBooksViewModel> GetUsersBooks(string userId)
        {
            var usersBooks = new UsersBooksViewModel()
            {
                Books = await _context.IdentityUserBooks
                    .Where(u => u.CollectorId == userId)
                    .Select(b => new BookViewModel()
                    {
                        Id = b.Book.Id,
                        Title = b.Book.Title,
                        Description = b.Book.Description,
                        Author = b.Book.Author,
                        ImageUrl = b.Book.ImageUrl,
                        Category = b.Book.Category.Name
                    }).ToListAsync()
            };

            return usersBooks;
        }

        public async Task RemoveBookFromCollection(int id, string userId)
        {
            var userBook = await _context.IdentityUserBooks
                .Where(ub => ub.CollectorId == userId && ub.BookId == id)
                .FirstOrDefaultAsync();

            _context.IdentityUserBooks.Remove(userBook);
            await _context.SaveChangesAsync();
        }
    }
}
