using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
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

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            pageIndex = pageIndex ?? 1;
            sortBy = !(string.IsNullOrWhiteSpace(sortBy)) ? sortBy : "Name";


            var customers = new List<Customer>
            {
                new Customer(){Name = "Mark"},
                new Customer(){Name="Brian"}
            };



            return View(customers);
        }

    }
}