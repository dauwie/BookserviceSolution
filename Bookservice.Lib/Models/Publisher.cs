using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookservice.Lib.Models
{
    public class Publisher : EntityBase
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public Publisher()
        {
        }

        public Publisher(int id, string name, string country)
        {
            Id = id;
            Name = name;
            Country = country;
        }
    }
}
