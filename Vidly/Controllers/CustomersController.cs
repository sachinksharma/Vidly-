using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer != null)
                return View(customer);
            else
                return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var existingcustomer = _context.Customers.Single(c => c.Id == customer.Id);
                existingcustomer.Name = customer.Name;
                existingcustomer.DateOfBirth = customer.DateOfBirth;
                existingcustomer.IsSubscribledToNewsLetter = customer.IsSubscribledToNewsLetter;
                existingcustomer.MemberShipTypeId = customer.MemberShipTypeId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        [HttpGet]
        public ActionResult Create()
        {
            var membershiptypes = _context.MembershipTypes.ToList();
            var newcustomerviewmodel = new CustomerFormViewModel
            {
                MembershipTypes = membershiptypes,
            };
            return View("CustomerForm", newcustomerviewmodel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);

            if (customer != null)
            {
                var viewmodel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewmodel);
            }

            else
                return HttpNotFound();
        }
    }
}