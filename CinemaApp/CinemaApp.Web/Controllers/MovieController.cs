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
            IEnumerable<Movie> allMovies = await _context.Movies.ToListAsync();

            return View(allMovies);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string movieId)
        {
            bool isIdGuid = Guid.TryParse(movieId, out Guid idGuid);

            if (!isIdGuid)
            {
                return RedirectToAction(nameof(Index));
            }

            Movie? movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == idGuid);

            if (movie is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieInputViewModel inputModel)
        {
            string dateFormat = "dd/MM/yyyy";

            bool isReleaseDateValid = DateTime.TryParseExact(inputModel.ReleaseDate, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validReleaseDate);

            if (!ModelState.IsValid)
            {
                if (!isReleaseDateValid)
                {
                    ModelState.AddModelError(nameof(inputModel.ReleaseDate), "The Release Date must be in the following format: dd/MM/yyy!");

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
