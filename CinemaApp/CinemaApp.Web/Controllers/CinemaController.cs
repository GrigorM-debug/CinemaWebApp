using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Web.Controllers
{
    public class CinemaController : Controller
    {
        private readonly CinemaAppDbContext _context;

        public CinemaController(CinemaAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Cinema> cinemas = await _context
                .Cinemas
                .AsNoTracking()
                .ToArrayAsync();

            IEnumerable<CinemaIndexViewModel> cinemaIndexViewModels = cinemas
                .Select(cinemas => new CinemaIndexViewModel
                {
                    Id = cinemas.Id,
                    Name = cinemas.Name,
                    Location = cinemas.Location,
                });

            return View(cinemaIndexViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CinemaCreateViewModel cinemaCreateViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(cinemaCreateViewModel);
            }

            Cinema newCinema = new Cinema()
            {
                Name = cinemaCreateViewModel.Name,
                Location = cinemaCreateViewModel.Location,
            };

            await _context.Cinemas.AddAsync(newCinema);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
