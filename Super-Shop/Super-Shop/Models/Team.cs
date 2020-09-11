using System.Collections.Generic;

namespace Super_Shop.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int PowerLevel
        {
            get
            {
                //TODO: How to calculate team power?
                return 0;
            }
        }

        public string ImageUri { get; set; }

        public int[] MemberIds { get; set; }

        public List<Hero> Members { get; set; }
    }
}