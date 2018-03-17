using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Movies
        public ActionResult Random()
        {
            return View();
        }


        public ActionResult Edit(int id)
        {
            return Content("Id=" + id);
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"Year is {year} and month is {month}");
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.FirstOrDefault(c => c.Id == id);
            return View(movie);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }

    }
}