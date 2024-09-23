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
    }
}
