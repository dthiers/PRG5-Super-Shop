using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Super_Shop.Models;

namespace Super_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
            ViewBag.Adres = "200 Park Ave";  
            ViewBag.City = "New York";
            ViewBag.Postalcode = "NY 10166";
            ViewBag.Country = "Verenigde Staten";
            //TODO: Add phone number
            //TODO: Add email

            //TODO: Add 1 intern (Employee, Role = intern)

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
