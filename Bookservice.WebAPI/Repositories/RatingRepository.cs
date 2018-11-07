using Bookservice.WebAPI.Data;
using Bookservice.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookservice.WebAPI.Repositories
{
    public class RatingRepository : Repository<Rating>
    {
        public RatingRepository(BookServiceContext context) : base(context)
        {
        }

        public async Task<List<Rating>> GetAllInclusive()
        {
            return await GetAll()
                .Include(r => r.Book)
                .Include(r => r.Reader)
                .ToListAsync();
        }
    }
}
