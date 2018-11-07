using System.Collections.Generic;

namespace Bookservice.WebAPI.Models
{
    public class Reader : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Rating> Ratings { get; set; }

        public Reader()
        {
        }

        public Reader(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
