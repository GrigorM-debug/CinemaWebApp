using Azure.Core;
using CinemaApp.Data;
using CinemaApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                return View(nameof(Index));
            }

            Movie? movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == idGuid);

            if(movie is null)
            {
                return NotFound();
            }

           return View(movie);
        }
    }
}
