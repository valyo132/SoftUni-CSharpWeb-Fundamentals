using Library.Contracts;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace Library.Controllers
{

    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> All()
        {
            var model = await _bookService.GetAllBooksAsync();

            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await _bookService.GetUsersBooks(userId);
            return View(model);
        }

        public async Task<IActionResult> AddToCollection(int id)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _bookService.AddBookToCollection(id, userId);

            return RedirectToAction("All", "Book");
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _bookService.RemoveBookFromCollection(id, userId);

            return RedirectToAction("Mine", "Book");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = await _bookService.GetAddBookViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel obj)
        {
            if (ModelState.IsValid)
            {
                await _bookService.AddBook(obj);

                return RedirectToAction("All", "Book");
            }

            return View(obj);
        }
    }
}
