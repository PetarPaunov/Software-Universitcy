namespace Library.Contracts
{
    using Library.Data.Models;
    using Library.Models.BookViewModels;

    public interface IBookService
    {
        Task<IEnumerable<BookViewModel>> GetAllBooks();
        Task<IEnumerable<MineBooksViewModel>> GetAllMineBooks(string userId);
        Task<IEnumerable<Category>> GetCategories();
        Task AddBook(AddBookViewModel model);
        Task AddBookToCollection(string userId, int bookId);
        Task RemoveMovieFromUserCollection(string userId, int bookId);
    }
}