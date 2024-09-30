using Azure.Core;
using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace CinemaApp.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly CinemaAppDbContext _context;

        public MovieController(CinemaAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Movie> allMovies = await _context
                .Movies
                .AsNoTracking()
                .ToListAsync();

            IEnumerable<MovieIndexViewModel> movieIndexViewModels = allMovies
                .Select(movie => new MovieIndexViewModel
                {
                    Id = movie.Id.ToString(),
                    Title = movie.Title,
                    Genre = movie.Genre,
                    ReleaseDate = movie.ReleaseDate,
                    Director = movie.Director,
                    Duration = movie.Duration,
                    Description = movie.Description,
                });

            return View(movieIndexViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? movieId)
        {
            bool isIdGuid = Guid.TryParse(movieId, out Guid idGuid);

            if (!isIdGuid)
            {
                return RedirectToAction(nameof(Index));
            }

            Movie? movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == idGuid);

            Console.WriteLine(idGuid);

            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }

            MovieIndexViewModel movieIndexViewModel = new MovieIndexViewModel()
            {
                Id = movie.Id.ToString(),
                Title = movie.Title,
                Genre = movie.Genre,
                ReleaseDate = movie.ReleaseDate,
                Director = movie.Director,
                Duration = movie.Duration,
                Description = movie.Description,
            };

            return View(movieIndexViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieInputViewModel inputModel)
        {
            string dateFormat = "yyyy-MM";

            bool isReleaseDateValid = DateTime.TryParseExact(inputModel.ReleaseDate, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validReleaseDate);

            if (!ModelState.IsValid)
            {
                if (!isReleaseDateValid)
                {
                    ModelState.AddModelError(nameof(inputModel.ReleaseDate), "The Release Date must be in the following format: yyyy-MM!");

                    return View(inputModel);
                }
            }

            Movie newMovie = new Movie()
            {
                Title = inputModel.Title,
                Genre = inputModel.Genre,
                ReleaseDate = validReleaseDate,
                Director = inputModel.Director,
                Duration = inputModel.Duration,
                Description = inputModel.Description,
            };
            
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
