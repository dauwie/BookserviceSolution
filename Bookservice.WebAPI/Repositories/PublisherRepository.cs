using Bookservice.WebAPI.Data;
using Bookservice.WebAPI.Models;

namespace Bookservice.WebAPI.Repositories
{
    public class PublisherRepository : Repository<Publisher>
    {       
        public PublisherRepository(BookServiceContext context): base (context)
        {            
        }       
    }
}