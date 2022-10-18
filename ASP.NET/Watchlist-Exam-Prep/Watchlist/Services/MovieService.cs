using Microsoft.EntityFrameworkCore;
using Watchlist.Contracts;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models;

namespace Watchlist.Services
{
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext context;

        public MovieService(WatchlistDbContext _context)
        {
            context = _context;
        }

        public async Task AddMovie(MovieViewModel model)
        {
            var movie = new Movie()
            {
                Title = model.Title,
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                GenreId = model.GenreId
            };

            await context.Movies.AddAsync(movie);
            await context.SaveChangesAsync();
        }

        public async Task AddMovieToCollection(string userId, int movieId)
        {
            var user = await context
                .Users
                .Where(x => x.Id == userId)
                .Include(x => x.UsersMovies)
                .FirstOrDefaultAsync();

            var movie = await context.Movies.FirstOrDefaultAsync(x => x.Id == movieId);

            if (!user.UsersMovies.Any(x => x.MovieId == movieId))
            {
                user.UsersMovies
                .Add(new UserMovie
                {
                    MovieId = movieId,
                    UserId = userId,
                    Movie = movie,
                    User = user
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await context.Genres.ToListAsync();
        }

        public async Task<IEnumerable<AllMoviesViewModel>> GetAllMarckedAsWatchedMovies(string userId)
        {
            var user = await context
                .Users
                .Where(x => x.Id == userId)
                .Include(x => x.UsersMovies)
                .ThenInclude(x => x.Movie)
                .ThenInclude(x => x.Genre)
                .FirstOrDefaultAsync();

            var movies = await context
                .UserMovies
                .Select(x => new AllMoviesViewModel
                {
                    Id = x.Movie.Id,
                    Title = x.Movie.Title,
                    Director = x.Movie.Director,
                    Rating = x.Movie.Rating,
                    ImageUrl = x.Movie.ImageUrl,
                    Genre = x.Movie.Genre.Name
                })
                .ToListAsync();

            return movies;
        }

        public async Task<IEnumerable<AllMoviesViewModel>> GetAllMovies()
        {
            var movies = await context
                .Movies
                .Select(x => new AllMoviesViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Director = x.Director,
                    Rating = x.Rating,
                    ImageUrl = x.ImageUrl,
                    Genre = x.Genre.Name
                })
                .ToListAsync();

            return movies;
        }

        public async Task RemoveFromMovieCollection(string userId, int movieId)
        {
            var user = await context
                .Users
                .Where(x => x.Id == userId)
                .Include(x => x.UsersMovies)
                .FirstOrDefaultAsync();

            var userMovie = await context.UserMovies
                .Where(x => x.MovieId == movieId && x.UserId == userId)
                .FirstOrDefaultAsync();

            user.UsersMovies.Remove(userMovie);

            await context.SaveChangesAsync();
        }
    }
}
