using System;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    [Authorize]
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
            var movie = _context.Movies.Single(c => c.Id == id);
            if (movie != null)
            {
                var movieModel = new MovieFormViewModel()
                {
                    Genres = _context.Genres.ToList(),
                    Movie = movie
                };

                return View("MovieForm", movieModel);
            }
            else
                return HttpNotFound();
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.FirstOrDefault(c => c.Id == id);
            return View(movie);
        }

        public ActionResult Index()
        {
            if (User.IsInRole("CanManageMovies"))
                return View("List");
            else

                return View("ReadOnlyList");
        }

        [HttpGet]
        public ActionResult Create()
        {
            var genres = _context.Genres.ToList();

            var viewmodel = new MovieFormViewModel()
            {
                Genres = genres
            };
            return View("MovieForm", viewmodel);
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            //  Check if Model content is valid
            if (!ModelState.IsValid)
            {
                var viewmodel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewmodel);
            }

            // In case of addition of new movie
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Today;
                _context.Movies.Add(movie);
            }
            else
            {   // In case of update 
                var existingmovie = _context.Movies.Single(c => c.Id == movie.Id);
                existingmovie.GenreId = movie.GenreId;
                existingmovie.Name = movie.Name;
                existingmovie.NumberInStock = movie.NumberInStock;
                existingmovie.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}