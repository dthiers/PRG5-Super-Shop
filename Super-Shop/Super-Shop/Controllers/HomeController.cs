using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Super_Shop.Models;

namespace Super_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private Database _database;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _database = new Database();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Employees = new List<Employee>()
            {
                new Employee() { Name = "Eric Kuijpers", Role = "CEO", ImageUri = "~/img/employees/eric.jfif" },
                new Employee() { Name = "Carron Schilders", Role = "CTO", ImageUri = "~/img/employees/carron.jfif"  },
                new Employee() { Name = "Stijn Smulders", Role = "Service desk", ImageUri = "~/img/employees/stijn.jfif"  },
            };


            ViewBag.Name = "Super Store inc.";
            ViewBag.address = "200 Park Ave";
            ViewBag.City = "New York";
            ViewBag.Postalcode = "NY 10166";
            ViewBag.Country = "Verenigde Staten";
            ViewBag.Phone = "024-7856341";
            ViewBag.Mail = "helpdesk@super-store.net";

            ViewBag.Interns = new List<Employee>()
            {
                new Employee() { Name = "Adam Sandler", Role = "Intern", ImageUri = "~/img/interns/adam.jpg" }
            };


            var contactViewModel = new ContactViewModel
            {
                Heroes = GetHeroes()
            };
            
            return View(contactViewModel);
        }

        [HttpPost]
        public IActionResult SubmitContactForm(ContactViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.SelectedHero = _database.GetHero(model.SelectedHeroId);
                    return View("ContactDetail", model);
                    //return Content($"{model.Title} {model.SelectedHeroId} {model.Message} {model.Mail}");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        private IEnumerable<SelectListItem> GetHeroes()
        {
            var heroes = _database.GetHeroes()
                .Select(h => new SelectListItem
                {
                    Value = h.Id.ToString(),
                    Text = h.Name
                });
            return new SelectList(heroes, "Value", "Text");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
