using System.Security.Claims;
using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CinemaApp.Common.ApplicationConstants;

namespace CinemaApp.Web.Controllers
{
    [Authorize]
    public class WatchListController : Controller
    {
        private readonly CinemaAppDbContext _context;
        private readonly UserManager<CinemaAppUser> _userManager;

        public WatchListController(CinemaAppDbContext context, UserManager<CinemaAppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            CinemaAppUser user = await _userManager.GetUserAsync(User);

            List<WatchListViewModel> watchListMovie = await _context.UsersMovies
                .Where(um => um.UserId == user.Id && um.IsDeleted == false)
                .Include(um => um.Movie)
                .Select(um => new WatchListViewModel()
                {
                    MovieId = um.MovieId,
                    Title = um.Movie.Title,
                    Genre = um.Movie.Genre,
                    ReleaseDate = um.Movie.ReleaseDate.ToString(MovieReleaseDateFormat),
                    ImageUrl = um.Movie.ImageUrl
                })
                .ToListAsync();

            return View(watchListMovie);
        }

        [HttpPost]
        public async Task<IActionResult> AddToWatchlist(string? movieId)
        {
            CinemaAppUser user = await _userManager.GetUserAsync(User);

            bool isIdValid = Guid.TryParse(movieId, out Guid movieGuidId);

            if (!isIdValid)
            {
                return RedirectToAction(nameof(Index), "Movie");
            }

            bool isAlreadyAddedToWatchlist = await _context.UsersMovies.AnyAsync(um => um.MovieId.ToString() == movieGuidId.ToString() && um.UserId == user.Id);

            //UserMovie userMovie = await _context.UsersMovies.FirstOrDefaultAsync(um =>
            //    um.MovieId.ToString() == movieGuidId.ToString() && um.UserId == user.Id);

            //if (userMovie != null)
            //{
            //    if (userMovie.IsDeleted == true)
            //    {
            //        userMovie.IsDeleted = false;
            //    }
            //}

            if (isAlreadyAddedToWatchlist)
            {
                return RedirectToAction(nameof(Index), "Movie");
            }

            await _context.UsersMovies.AddAsync(new UserMovie()
            {
                MovieId = movieGuidId,
                UserId = user.Id
            });

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromWatchlist(string? movieId)
        {
            CinemaAppUser user = await _userManager.GetUserAsync(User);

            bool isMovieIdValid = Guid.TryParse(movieId, out Guid movieGuidId);

            if (!isMovieIdValid)
            {
                return RedirectToAction(nameof(Index), "Movie");
            }

            UserMovie userMovie =
                await _context.UsersMovies.FirstOrDefaultAsync(um => um.MovieId.ToString() == movieGuidId.ToString() && um.UserId == user.Id);

            if (userMovie == null)
            {
                return RedirectToAction(nameof(Index), "Movie");
            }

            userMovie.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
