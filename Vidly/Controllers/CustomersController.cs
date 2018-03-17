using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>()
            {
                new Customer() { Name = "John Smith"},
                new Customer() { Name ="Mary Williams" }

            };

            return View(customers);
        }
    }
}