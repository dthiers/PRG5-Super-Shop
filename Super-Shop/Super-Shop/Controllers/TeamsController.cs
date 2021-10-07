using Microsoft.AspNetCore.Mvc;
using Super_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super_Shop.Controllers
{
    public class TeamsController : Controller
    {
        private Database _database;

        public TeamsController()
        {
            this._database = new Database();
        }

        public IActionResult Index()
        {
            var teams = _database.GetTeams();
            return View(teams);
        }
    }
}
