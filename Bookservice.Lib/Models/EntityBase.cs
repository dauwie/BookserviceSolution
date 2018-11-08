using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookservice.Lib.Models
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        private DateTime? created;

        public DateTime? Created
        {
            get
            {
                return created ?? DateTime.Now;
            }
            set
            {
                if (value != null)
                    created = value;
                else created = DateTime.Now;
            }
        }      

    }
}
