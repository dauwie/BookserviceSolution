using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bookservice.WebAPI.Data;
using Bookservice.Lib.DTO;
using Bookservice.Lib.Models;
using Bookservice.WebAPI.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookservice.WebAPI.Repositories
{
    public class BookRepository : MappingRepository<Book>
    {
        public BookRepository(BookServiceContext context, IMapper mapper) : base(context, mapper)
        {
        }
               
        public async Task<List<Book>> GetAllInclusive()
        {
            return await GetAll()
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToListAsync();
        }

        public async Task<List<BookBasic>> ListBasic()
        {
            return await _bookServiceContext.Books
                .ProjectTo<BookBasic>(mapper.ConfigurationProvider)
                .OrderBy(b => b.Title)
                .ToListAsync();

            //return await _bookServiceContext.Books.Select(
            //    b => new BookBasic
            //    {
            //        Id = b.Id,
            //        Title = b.Title
            //    }).ToListAsync();
        }

        public async Task<List<BookStatistics>> ListStatistics()
        {
            return await _bookServiceContext.Books
                    .Include(b => b.Ratings)
                    .Where(b => b.Ratings.Count > 0)
                    .ProjectTo<BookStatistics>(mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<BookDetail> GetDetailById(int id)
        {
            return mapper.Map<BookDetail>(
                await _bookServiceContext.Books
                        .Include(b => b.Author)
                        .Include(b => b.Publisher)
                        .FirstOrDefaultAsync(b => b.Id == id)
                );

            //return await _bookServiceContext.Books.Select(b => new BookDetail
            //{
            //    Id = b.Id,
            //    Title = b.Title,
            //    ISBN = b.ISBN,
            //    Year = b.Year,
            //    Price = b.Price,
            //    NumberOfPages = b.NumberOfPages,
            //    AuthorId = b.Author.Id,
            //    AuthorName = $"{b.Author.LastName} {b.Author.FirstName}",
            //    PublisherId = b.Publisher.Id,
            //    PublisherName = b.Publisher.Name,
            //    FileName = b.FileName
            //}).FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
