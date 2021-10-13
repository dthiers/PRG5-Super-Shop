using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Super_Shop.Dal;
using Super_Shop.Models;

namespace Super_Shop.Controllers
{
    public class HeroesController : Controller
    {
        private readonly SupershopContext _context;

        public HeroesController(SupershopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var heroes = _context.Heroes.ToList();
            return View(heroes);
        }

        public IActionResult Details(int id)
        {
            if (id > 0)
            {
                var hero = _context.Heroes.Find(id);
                if (hero != null)
                {
                    return View(hero);
                }
            }
            return RedirectToAction("index");
        }
    }
}
