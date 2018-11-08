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
            CreateMap<Book, BookDetail>()
                .ForMember(
                    dest => dest.AuthorName,
                    opts => opts.MapFrom(src => $"{src.Author.FirstName}, {src.Author.LastName}"));
            CreateMap<Publisher, PublisherBasic>();
            CreateMap<Book, BookStatistics>()
                .ForMember(dest => dest.RatingsCount,
                            opts => opts.MapFrom(src => src.Ratings.Count))
                .ForMember(dest => dest.ScoreAverage,
                            opts => opts.MapFrom(src => src.Ratings.Average(r => r.Score)));
        }
    }
}
