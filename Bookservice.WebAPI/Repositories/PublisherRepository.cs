using AutoMapper;
using Bookservice.WebAPI.Data;
using Bookservice.WebAPI.Models;
using Bookservice.WebAPI.DTO;
using Bookservice.WebAPI.Repositories.Base;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bookservice.WebAPI.Repositories
{
    public class PublisherRepository : MappingRepository<Publisher>
    {       
        public PublisherRepository(BookServiceContext context, IMapper mapper): base (context, mapper)
        {            
        }       

        public async Task<List<PublisherBasic>> ListBasic()
        {
            return await _bookServiceContext.Publishers
                .ProjectTo<PublisherBasic>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}