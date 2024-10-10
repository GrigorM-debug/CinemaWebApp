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
                .Where(um => um.UserId == user.Id)
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
    }
}
