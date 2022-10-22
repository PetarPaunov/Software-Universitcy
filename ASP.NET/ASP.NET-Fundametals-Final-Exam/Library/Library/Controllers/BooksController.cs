namespace Library.Controllers
{
    using Library.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Library.Models.BookViewModels;

    public class BooksController : BaseController
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> All()
        {
            var model = await bookService.GetAllBooks();

            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var userId = GetUserId();

            var model = await bookService.GetAllMineBooks(userId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await bookService.GetCategories();

            var model = new AddBookViewModel()
            {
                Categories = categories
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await bookService.AddBook(model);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> AddToCollection(int bookId)
        {
            var userId = GetUserId();

            await bookService.AddBookToCollection(userId, bookId);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            var userId = GetUserId();

            await bookService.RemoveMovieFromUserCollection(userId, bookId);

            return RedirectToAction(nameof(Mine));
        }
    }
}