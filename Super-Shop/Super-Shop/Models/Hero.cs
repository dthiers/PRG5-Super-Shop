using System;
using System.Collections.Generic;

namespace Super_Shop.Models
{
    public class Hero
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int PowerLevel { get; set; }

        public string ImageUri { get; set; }
        public DateTime CreatedAt { get; set; }

        //public int TeamForeignKey { get; set; }
        //public Team Team { get; set; }

        public ICollection<Team> Teams {get; set; }
    }
}