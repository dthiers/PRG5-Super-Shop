using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Super_Shop.Dal;
using Super_Shop.Entities;
using Super_Shop.Models;

namespace Super_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly SupershopContext _context;

        public HomeController(
            ILogger<HomeController> logger,
            SupershopContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var homeModel = new HomeModel
            {
                Name = "Super Store inc.",
                Address = "200 Park Ave",
                City = "New York",
                Zipcode = "NY 10166",
                Country = "Verenigde Staten",
                Phone = "024-7856341",
                Mail = "helpdesk@super-store.net",
                Employees = _context.Employees.Where(e => e.Role != "Intern").ToList(),
                Interns = _context.Employees.Where(e => e.Role == "Intern").ToList()
            };

            return View(homeModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
