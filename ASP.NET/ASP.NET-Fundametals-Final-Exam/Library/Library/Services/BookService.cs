namespace Library.Services
{
    using Library.Contracts;
    using Library.Data;
    using Library.Data.Models;
    using Library.Models.BookViewModels;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext _context)
        {
            context = _context;
        }

        public async Task AddBook(AddBookViewModel model)
        {
            var book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                CategoryId = model.CategoryId
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public async Task AddBookToCollection(string userId, int bookId)
        {
            var user = await context
                .Users
                .Where(x => x.Id == userId)
                .Include(x => x.ApplicationUsersBooks)
                .ThenInclude(x => x.Book)
                .ThenInclude(x => x.Category)
                .FirstOrDefaultAsync();

            if (!user.ApplicationUsersBooks.Any(x => x.BookId == bookId))
            {
                user.ApplicationUsersBooks
                    .Add(new ApplicationUserBook()
                    {
                        BookId = bookId,
                        ApplicationUserId = userId,
                    });

                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BookViewModel>> GetAllBooks()
        {
            var model = await context
                .Books
                .Select(x => new BookViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Author = x.Author,
                    ImageUrl = x.ImageUrl,
                    Rating = x.Rating,
                    Category = x.Category.Name
                })
                .ToListAsync();

            return model;
        }

        public async Task<IEnumerable<MineBooksViewModel>> GetAllMineBooks(string userId)
        {
            var books = await context
                .ApplicationUsersBooks
                .Where(x => x.ApplicationUserId == userId)
                .Select(x => new MineBooksViewModel
                {
                    Id = x.Book.Id,
                    Title = x.Book.Title,
                    Description = x.Book.Description,
                    Author = x.Book.Author,
                    ImageUrl = x.Book.ImageUrl,
                    Category = x.Book.Category.Name
                })
                .ToListAsync();

            return books;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task RemoveMovieFromUserCollection(string userId, int bookId)
        {
            var user = await context
                .Users
                .Where(x => x.Id == userId)
                .Include(x => x.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            var userBook = await context
                .ApplicationUsersBooks
                .Where(x => x.BookId == bookId && x.ApplicationUserId == userId)
                .FirstOrDefaultAsync();

            user.ApplicationUsersBooks.Remove(userBook);

            await context.SaveChangesAsync();
        }
    }
}