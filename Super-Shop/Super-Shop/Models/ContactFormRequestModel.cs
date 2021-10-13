using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super_Shop.Models
{
    public class ContactFormRequestModel
    {
        public String Title { get; set; }
        public int SelectedHeroId { get; set; }
        public IEnumerable<SelectListItem> Heroes { get; set; }
        public Hero SelectedHero { get; set; }
        public String Message { get; set; }
        public String Email { get; set; }
    }
}
