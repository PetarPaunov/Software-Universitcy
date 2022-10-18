using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Watchlist.Contracts;
using Watchlist.Models;

namespace Watchlist.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService _movieService)
        {
            movieService = _movieService;
        }

        public async Task<IActionResult> All()
        {
            var movies = await movieService.GetAllMovies();

            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var genres = await movieService.GetAllGenres();

            var model = new MovieViewModel()
            {
                Genres = genres
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await movieService.AddMovie(model);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int movieId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await movieService.AddMovieToCollection(userId, movieId);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Watched()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await movieService.GetAllMarckedAsWatchedMovies(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await movieService.RemoveFromMovieCollection(userId, movieId);

            return RedirectToAction(nameof(All));
        }
    }
}
