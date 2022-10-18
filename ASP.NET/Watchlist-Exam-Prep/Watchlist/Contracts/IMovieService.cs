using Watchlist.Data.Models;
using Watchlist.Models;

namespace Watchlist.Contracts
{
    public interface IMovieService
    {
        Task<IEnumerable<AllMoviesViewModel>> GetAllMovies();
        Task<IEnumerable<AllMoviesViewModel>> GetAllMarckedAsWatchedMovies(string userId);
        Task<IEnumerable<Genre>> GetAllGenres();
        Task AddMovie(MovieViewModel model);
        Task AddMovieToCollection(string userId, int movieId);
        Task RemoveFromMovieCollection(string userId, int movieId);
    }
}
