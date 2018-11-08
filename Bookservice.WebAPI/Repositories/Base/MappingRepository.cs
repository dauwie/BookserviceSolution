using AutoMapper;
using Bookservice.WebAPI.Data;
using Bookservice.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookservice.WebAPI.Repositories.Base
{
    public class MappingRepository<T> : Repository<T> where T : EntityBase
    {
        protected readonly IMapper mapper;

        public MappingRepository(BookServiceContext bookserviceContext, IMapper mapper) 
            :base(bookserviceContext)
        {
            this.mapper = mapper;
        }
    }
}
