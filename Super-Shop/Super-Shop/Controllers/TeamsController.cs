using Microsoft.AspNetCore.Mvc;
using Super_Shop.Dal;
using Super_Shop.Models;
using System.Linq;

namespace Super_Shop.Controllers
{
    public class TeamsController : Controller
    {
        private SupershopContext _context;

        public TeamsController(SupershopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            /// There's efficiency oppertunities in code below. We only need name for Heroes.
            /// 
            //var teams = _context.Teams.Include(t => t.Heroes).ToList();
            /// And even more in snippet below by using extension method. 
            /// The extension method doesn't hide relations from EF.
            //var teams = _context.Teams
            //    //.Include(t => t.Heroes) /// unnecessary include when using t.Heroes.Select(). EF Core will work out what to pull in. 
            //    .Select(t => new TeamModel
            //    {
            //        Id = t.Id,
            //        Name = t.Name,
            //        PowerLevel = t.PowerLevel,
            //        ImageUri = t.ImageUri,
            //        HeroNames = t.Heroes.Select(h => h.Name).ToList() /// <---
            //    })
            //    .ToList();
            /// 
            var teams = _context.Teams.ToModel().ToList();
            return View(teams);
        }

        public IActionResult Details(int id)
        {
            var team = _context.Teams.ToModel().SingleOrDefault(t => t.Id == id);

            if (team == null)
            {
                return NotFound();
            }
            else
            {
                return View(team);
            }
        }
    }
}
