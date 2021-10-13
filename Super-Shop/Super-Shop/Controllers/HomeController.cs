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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            var employees = _context.Employees.Where(e => e.Role != "Intern").ToList();
            ViewBag.Employees = employees;

            ViewBag.Name = "Super Store inc.";
            ViewBag.address = "200 Park Ave";
            ViewBag.City = "New York";
            ViewBag.Postalcode = "NY 10166";
            ViewBag.Country = "Verenigde Staten";
            ViewBag.Phone = "024-7856341";
            ViewBag.Mail = "helpdesk@super-store.net";

            ViewBag.Interns = _context.Employees.Where(e => e.Role == "Intern").ToList();

            var contactFormRequestModel = new ContactFormRequestModel
            {
                // Heroes is a SelectList<{ name, id}>
                Heroes = _context.Heroes.Select(h => new SelectListItem(h.Name, h.Id.ToString()))
            };
            
            return View(contactFormRequestModel);
        }

        [HttpPost]
        public IActionResult SubmitContactForm(ContactFormRequestModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contactFormRequest = new ContactFormRequest
                    {
                        Title = model.Title,
                        HeroId = model.SelectedHeroId,
                        Message = model.Message,
                        Email = model.Email
                    };

                    _context.ContactFormRequests.Add(contactFormRequest);
                    _context.SaveChanges();

                    model.SelectedHero = _context.Heroes.Find(model.SelectedHeroId);
                    return View("ContactDetail", model);
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
