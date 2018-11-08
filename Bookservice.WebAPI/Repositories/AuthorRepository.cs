using Bookservice.WebAPI.Data;
using Bookservice.Lib.DTO;
using Bookservice.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookservice.WebAPI.Repositories
{
    public class AuthorRepository : Repository<Author>
    {        
        public AuthorRepository(BookServiceContext context) : base(context)
        {            
        }

        public async Task<List<AuthorBasic>> ListBasic()
        {            
            return await _bookServiceContext.Authors.Select(a => new AuthorBasic
            {
                Id = a.Id,
                Name = $"{a.LastName} {a.FirstName}"
            }).ToListAsync();
        }        
    }
}
