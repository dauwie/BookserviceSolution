using AutoMapper;
using Bookservice.WebAPI.DTO;
using Bookservice.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookservice.WebAPI.Services.AutoMapper
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() : this("MyProfile")
        {
        }

        protected AutoMapperProfileConfiguration(string profileName): base(profileName)
        {
            CreateMap<BookBasic, Book>();
        }
    }
}
