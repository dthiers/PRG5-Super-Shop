using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super_Shop.Models
{
    public class HomeModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Employee> Interns { get; set; }
    }
}
