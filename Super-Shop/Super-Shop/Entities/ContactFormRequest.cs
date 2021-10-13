using Super_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super_Shop.Entities
{
    public class ContactFormRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// Navigation properties.
        /// </summary>
        public int HeroId { get; set; }
        public Hero Hero { get; set; }
    }
}
