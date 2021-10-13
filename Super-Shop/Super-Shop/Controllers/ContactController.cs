using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Super_Shop.Dal;
using Super_Shop.Entities;
using Super_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Super_Shop.Controllers
{
    public class ContactController : Controller
    {
        private readonly SupershopContext _context;

        public ContactController(SupershopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var contactFormRequestModel = new ContactFormRequestModel
            {
                Heroes = GetHeroesForSelectList()
            };
            return View(contactFormRequestModel);
        }

        public IActionResult Details()
        {
            return View();
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
                    return View("Details", model);
                }
                else
                {
                    var newModel = model;
                    newModel.Heroes = GetHeroesForSelectList();
                    return View("Index", model);
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = $"{e.Message}";
                return View("Index");
            }
        }

        #region private helpers
        /// <summary>
        /// Gets a IEnumerable<SelectListItem> of { Hero.Name, Hero.Id }.
        /// Use this to satisfy the view's model Heroes property.
        /// </summary>
        /// <returns>IEnumerable<SelectListItem></returns>
        private IEnumerable<SelectListItem> GetHeroesForSelectList()
        {
            return _context.Heroes.Select(h => new SelectListItem(h.Name, h.Id.ToString()));
        }
        #endregion
    }
}
