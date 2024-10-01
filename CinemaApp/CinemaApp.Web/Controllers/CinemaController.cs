﻿using CinemaApp.Data;
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
                    Id = cinemas.Id.ToString(),
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

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            bool isGuidValid = Guid.TryParse(id, out Guid guidId);

            if (!isGuidValid)
            {
                return RedirectToAction(nameof(Index));
            }

            Cinema? cinema = await _context
                .Cinemas
                .Include(c => c.CinemasMovies)
                .ThenInclude(cm => cm.Movie)
                .FirstOrDefaultAsync(c => c.Id == guidId);

            if(cinema == null)
            {
                return RedirectToAction(nameof(Index));
            }

            CinemaDetailsViewModel cinemaDetailsViewModel = new CinemaDetailsViewModel()
            {
                Id = cinema.Id.ToString(),
                Name= cinema.Name,
                Location= cinema.Location,
                Movies = cinema.CinemasMovies
                    .Where(c => c.IsDeleted == false)
                    .Select(cm => new MovieProgramViewModel
                    { 
                        Title = cm.Movie.Title,
                        Duration = cm.Movie.Duration,
                    }).ToList()
            };

            return View(cinemaDetailsViewModel);
        }
    }
}
