using Bookservice.WebAPI.Data;
using Bookservice.Lib.Models;

namespace Bookservice.WebAPI.Repositories
{
    public class ReaderRepository : Repository<Reader>
    {
        public ReaderRepository(BookServiceContext context) : base(context)
        {
        }
    }
}
