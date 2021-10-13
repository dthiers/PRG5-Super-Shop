using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Super_Shop.Models
{
    public class ContactFormRequestModel
    {
        [StringLength(128, MinimumLength = 3)]
        [Required]
        public String Title { get; set; }
        [Required]
        public int SelectedHeroId { get; set; }
        public IEnumerable<SelectListItem> Heroes { get; set; }
        public Hero SelectedHero { get; set; }
        [StringLength(1024, MinimumLength = 3)]
        [Required]
        public String Message { get; set; }
        [StringLength(256, MinimumLength = 6)]
        [DataType(DataType.EmailAddress)]
        [Required]
        public String Email { get; set; }
    }
}
