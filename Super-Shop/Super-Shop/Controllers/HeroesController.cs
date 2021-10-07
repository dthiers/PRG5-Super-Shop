using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Super_Shop.Models;

namespace Super_Shop.Controllers
{
    public class HeroesController : Controller
    {
        private Database _database;

        public HeroesController()
        {
            _database = new Database();
        }

        public IActionResult Index()
        {
            var heroes = _database.GetHeroes();
            return View(heroes);
        }

        public IActionResult Details(int id)
        {
            if (id > 0)
            {
                var hero = _database.GetHero(id);
                if (hero != null)
                {
                    return View(hero);
                }
            }
            return RedirectToAction("index");
        }
    }
}
