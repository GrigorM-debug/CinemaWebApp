﻿using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<IActionResult> AddToProgram(string? movieId)
        {
            bool isIdValid = Guid.TryParse(movieId, out Guid guidId);

            if (!isIdValid)
            {
                return RedirectToAction(nameof(Index));
            }

            Movie? movie = await _context.Movies.FirstOrDefaultAsync(m=> m.Id == guidId);

            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }

            AddMovieToCinemaProgramViewModel addMovieToCinemaProgramViewModel = new AddMovieToCinemaProgramViewModel
            {
                MovieId = guidId.ToString(),
                MovieTitle = movie.Title,
                Cinemas = await _context.Cinemas
                    .Include(c => c.CinemasMovies)
                    .ThenInclude(cm => cm.Movie)
                    .Select(c => new CinemaCheckBoxViewModel
                    {
                        Id = c.Id.ToString(),
                        Name = c.Name,
                        Location = c.Location,
                        IsSelected = c.CinemasMovies.Any(cm => cm.Movie.Id == guidId),
                    }).ToListAsync()
            };

            return View(addMovieToCinemaProgramViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToProgram(AddMovieToCinemaProgramViewModel addMovieToCinemaProgramViewModel)
        {
            string cinemaDetailsId = string.Empty;
            if (!ModelState.IsValid)
            {
                return View(addMovieToCinemaProgramViewModel);
            }

            bool isIdValid = Guid.TryParse(addMovieToCinemaProgramViewModel.MovieId, out Guid guidIdValid);

            if (!isIdValid)
            {
                return RedirectToAction(nameof(Index));
            }

            Movie? movie = await _context.Movies.FirstOrDefaultAsync(movie => movie.Id == guidIdValid);

            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }

            ICollection<CinemaMovie> entitiesToAdd = new HashSet<CinemaMovie>();

            foreach (CinemaCheckBoxViewModel cinemaCheckBoxViewModel in addMovieToCinemaProgramViewModel.Cinemas)
            {
                bool isIdValidGuid = Guid.TryParse(cinemaCheckBoxViewModel.Id, out Guid guidIdValidGuid);
                if (!isIdValidGuid)
                {
                    continue; //you can also throw exception and handle it
                }

                Cinema? cinema = await _context.Cinemas.FirstOrDefaultAsync(c => c.Id == guidIdValidGuid);

                if (cinema == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                CinemaMovie? cinemaMovie = await _context.CinemasMovies.FirstOrDefaultAsync(cm => cm.MovieId == movie.Id && cm.CinemaId == cinema.Id);

                if (cinemaCheckBoxViewModel.IsSelected)
                { 
                    if (cinemaMovie == null)
                    {
                        cinemaDetailsId = guidIdValidGuid.ToString();

                        entitiesToAdd.Add(new CinemaMovie()
                        {
                            Cinema = cinema,
                            Movie = movie
                        });
                    }
                    else
                    {
                        cinemaMovie.IsDeleted = false;
                    }
                }
                else // if is unchecked. This means we are removing the movie from the cinema program
                {
                    if(cinemaMovie != null)
                    {
                        cinemaDetailsId = guidIdValidGuid.ToString();
                        cinemaMovie.IsDeleted = true;
                    }
                }
            }
            await _context.CinemasMovies.AddRangeAsync(entitiesToAdd);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), "Cinema", new { id = cinemaDetailsId });
        }
    }
}
